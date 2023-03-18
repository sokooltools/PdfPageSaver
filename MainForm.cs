using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PdfPageSaver.Properties;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfPageSaver
{
	//----------------------------------------------------------------------------------------------------------------------------
	/// <summary>
	/// The main form used by this application.
	/// </summary>
	/// <seealso cref="System.Windows.Forms.Form" />
	//----------------------------------------------------------------------------------------------------------------------------
	public partial class MainForm : Form
	{
		//..................................................................................................................................

		#region Public Constructor

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="MainForm"/> class.
		/// </summary>
		/// <param name="args">The arguments.</param>
		//------------------------------------------------------------------------------------------------------------------------
		public MainForm(object[] args)
		{
			InitializeComponent();
			System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
			if (args.Length > 0)
				listBox1.Items.AddRange(args);

			lblFileSize.Text = String.Empty;
			lblNumPages.Text = String.Empty;

			ctxMenuOpen.Font = new Font(ctxMenuOpen.Font, ctxMenuOpen.Font.Style | FontStyle.Bold);
		}

		#endregion

		//..................................................................................................................................

		#region Private Form Event Handlers

		private void MainForm_Load(object sender, EventArgs e)
		{
			MinimumSize = Size;
			chkSaveSettings.Checked = Settings.Default.SaveSettings;
			if (!chkSaveSettings.Checked)
				return;
			StartPosition = FormStartPosition.Manual;
			Location = Settings.Default.Location;
			Size = Settings.Default.Size;
			txtPageNumbers.Text = Settings.Default.PageNumbers;
			txtSuffix.Text = Settings.Default.Suffix;
			lblNumPages.Top = listBox1.Bottom + 3;
			rdoOverwrite.Checked = Settings.Default.IsOverwrite;
		}

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Handles the event raised when this form is closing.
		/// </summary>
		//------------------------------------------------------------------------------------------------------------------------
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Default.SaveSettings = chkSaveSettings.Checked;
			if (chkSaveSettings.Checked)
			{
				Settings.Default.Location = Location;
				Settings.Default.Size = Size;
				Settings.Default.PageNumbers = txtPageNumbers.Text;
				Settings.Default.Suffix = txtSuffix.Text;
				Settings.Default.IsOverwrite = rdoOverwrite.Checked;
			}
			Settings.Default.Save();
		}

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Handles the event raised by the listBox1 control when the user drags files on top of it.
		/// Note: that this does not work while in debug!!!!
		/// </summary>
		//------------------------------------------------------------------------------------------------------------------------
		private void ListBox1_DragEnter(object sender, DragEventArgs e)
		{
			// Make sure they're actually dropping files (not text or anything else)
			if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
				// Allow them to continue (without this, the cursor stays a "NO" symbol
				e.Effect = DragDropEffects.All;
		}

		private bool _skipSelectedIndex;

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Handles the event raised by the listBox1 control when the user drops files onto it.
		/// </summary>
		//------------------------------------------------------------------------------------------------------------------------
		private void ListBox1_DragDrop(object sender, DragEventArgs e)
		{
			// Transfer the file names to a string array
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			AddFilesToListbox(files);
		}

		private void AddFilesToListbox(IReadOnlyList<string> files)
		{
			// Loop through the string array, adding each filename to the ListBox.
			_skipSelectedIndex = true;
			for (int i = 0; i < files.Count; i++)
			{
				string file = files[i];

				if (String.Compare(Path.GetExtension(file), ".pdf", StringComparison.InvariantCultureIgnoreCase) != 0)
					continue;
				if (!listBox1.Items.Contains(file))
					listBox1.Items.Add(file);
				if (i != files.Count - 1)
					continue;
				_skipSelectedIndex = false;
				listBox1.Refresh();
				listBox1.SelectedItem = file;
			}
			_skipSelectedIndex = false;
		}

		private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_skipSelectedIndex)
				UpdateForm();
		}

		private void ListBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
				return;
			int indexOfItem = listBox1.IndexFromPoint(e.X, e.Y);
			if (indexOfItem != ListBox.NoMatches)
				listBox1.SelectedIndex = indexOfItem;
		}

		private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int indexOfItem = listBox1.IndexFromPoint(e.X, e.Y);
			if (indexOfItem == ListBox.NoMatches)
				return;
			listBox1.SelectedIndex = indexOfItem;
			OpenPdf();
		}

		private void ListBox1_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete:
					RemovePdf();
					break;
				case Keys.Space:
					OpenPdf();
					break;
			}
		}

		private void CtxMenu1_Opening(object sender, CancelEventArgs e)
		{
			ctxMenuRemove.Enabled = ctxMenuOpen.Enabled = ctxMenuSaveSelected.Enabled = ctxMenuProperties.Enabled = listBox1.SelectedIndex >= 0;
			ctxMenuRemoveAll.Enabled = ctxMenuSave.Enabled = listBox1.Items.Count > 0;
			ctxMenuRemoveAllButSelected.Enabled = listBox1.Items.Count > 1;
		}

		private void CtxMenuOpen_Click(object sender, EventArgs e)
		{
			OpenPdf();
		}

		private void CtxMenuRemove_Click(object sender, EventArgs e)
		{
			RemovePdf();
		}

		private void CtxMenuSave_Click(object sender, EventArgs e)
		{
			SavePdfs();
		}

		private void CtxMenuSaveSelected_Click(object sender, EventArgs e)
		{
			SavePdfs(true);
		}

		private void CtxMenuRemoveAll_Click(object sender, EventArgs e)
		{
			RemoveAllPdfs();
		}

		private void CtxMenuRemoveAllButSelected_Click(object sender, EventArgs e)
		{
			RemoveAllButSelectedPdfs();
		}

		private void CtxMenuProperties_Click(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex == -1)
				return;
			string filename = listBox1.Items[listBox1.SelectedIndex].ToString();
			FileProperties.Show(filename);
		}

		private void BtnRemoveAll_Click(object sender, EventArgs e)
		{
			RemoveAllPdfs();
		}

		private void BtnBrowseFiles_Click(object sender, EventArgs e)
		{
			using var dlg = new OpenFileDialog();
			dlg.Multiselect = true;
			dlg.AddExtension = true;
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				AddFilesToListbox(dlg.FileNames);
			}
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			SavePdfs();
		}

		private void BtnExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void LblNumPages_Move(object sender, EventArgs e)
		{
			lblNumPages.Top = listBox1.Bottom + 3;
		}

		#endregion

		//..................................................................................................................................

		#region Private Helper Methods

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Opens the PDF file selected in the list.
		/// </summary>
		//------------------------------------------------------------------------------------------------------------------------
		private void OpenPdf()
		{
			if (listBox1.SelectedIndex == -1)
				return;
			string filename = listBox1.Items[listBox1.SelectedIndex].ToString();
			if (filename == null)
				return;
			try
			{
				Process p = new()
				{
					StartInfo = new ProcessStartInfo
					{
						FileName = filename,
						CreateNoWindow = false,
						UseShellExecute = true
					}
				};
				p.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, @"PDF Page Saver", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Removes the selected PDF file from the list.
		/// </summary>
		//------------------------------------------------------------------------------------------------------------------------
		private void RemovePdf()
		{
			int idx = listBox1.SelectedIndex;
			if (idx == -1)
				return;

			listBox1.Items.RemoveAt(idx);
			while (idx >= listBox1.Items.Count)
				idx--;
			listBox1.SelectedIndex = idx;
		}

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Removes all the PDFS from the list.
		/// </summary>
		//------------------------------------------------------------------------------------------------------------------------
		private void RemoveAllPdfs()
		{
			listBox1.SelectedIndex = -1;
			listBox1.Items.Clear();
			UpdateForm();
		}

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Removes all but the selected PDFs from the list.
		/// </summary>
		//------------------------------------------------------------------------------------------------------------------------
		private void RemoveAllButSelectedPdfs()
		{
			object tmp = listBox1.SelectedItem;
			listBox1.Items.Clear();
			listBox1.Items.Add(tmp);
			listBox1.SelectedItem = tmp;
			UpdateForm();
		}

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Saves the PDFs according to the current specifications on the form.
		/// </summary>
		/// <param name="isSelectedOnly">if set to <c>true</c> only the selected PDF file will be saved.</param>
		/// <exception cref="InvalidOperationException">
		/// Several PDF files were not saved because each would contain no pages.
		/// or
		/// The PDF file was not saved because it would contain no pages.
		/// </exception>
		//------------------------------------------------------------------------------------------------------------------------
		private void SavePdfs(bool isSelectedOnly = false)
		{
			string pageNumbers = txtPageNumbers.Text;
			if (!Regex.IsMatch(pageNumbers, "[0-9]"))
			{
				MessageBox.Show(this, @"You didn't specify any pages to save!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtPageNumbers.Focus();
				return;
			}
			if (!rdoAddSuffix.Checked)
			{
				if (MessageBox.Show(this,
						$@"Sure you want to overwrite the {(isSelectedOnly ? "selected PDF file" : $"{(listBox1.Items.Count > 1 ? $"{listBox1.Items.Count} PDF files" : "PDF file")}")}?", Text,
						MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					return;
			}
			Cursor = Cursors.WaitCursor;
			try
			{
				int invalidFileCnt = 0;
				int max = listBox1.Items.Count - 1;
				int min = 0;
				if (isSelectedOnly)
				{
					max = listBox1.SelectedIndex;
					min = max;
				}
				for (int i = max; i >= min; i--)
				{
					string pdfFile = listBox1.Items[i].ToString();
					try
					{
						listBox1.SelectedItem = pdfFile;
						SavePdfPages(pdfFile, pageNumbers, txtSuffix.Text, rdoAddSuffix.Checked);
						RemovePdf();
					}
					catch (InvalidOperationException ex)
					{
						Debug.WriteLine(ex.Message);
						invalidFileCnt++;
					}
				}
				switch (invalidFileCnt)
				{
					case > 1:
						throw new InvalidOperationException($"{invalidFileCnt} PDF files were not saved because they wouldn't have any pages.");
					case > 0:
						throw new InvalidOperationException("The PDF file was not saved because it wouldn't have any pages.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void UpdateForm()
		{
			btnSave.Enabled = btnRemoveAll.Enabled = listBox1.Items.Count > 0;
			lblFileSize.Text = String.Empty;
			lblNumPages.Text = String.Empty;

			if (listBox1.SelectedIndex == -1)
				return;

			string filename = listBox1.Items[listBox1.SelectedIndex].ToString();
			if (String.IsNullOrEmpty(filename))
				return;

			// Directories crash the program :|
			if ((new FileInfo(filename).Attributes & FileAttributes.Directory) == FileAttributes.Directory)
			{
				MessageBox.Show(this, @"Specifying a directory is not allowed!", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			// Set the label
			try
			{
				//PdfReader.unethicalreading = true;
				using PdfDocument doc = PdfReader.Open(filename, PdfDocumentOpenMode.InformationOnly);
				lblNumPages.Text = $@"Current number of pages: {doc.PageCount}";
				lblFileSize.Text = $@"Current file size: {GetFileSizeInfo(doc.FileSize)}";
				lblFileSize.Left = listBox1.Right - lblFileSize.Width;
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, @"PDF Page Saver", MessageBoxButtons.OK, MessageBoxIcon.Error);
				RemovePdf();
			}
		}

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Saves the specified pdf file to contain just the specified page numbers. By default, a new pdf file is created using
		/// the same file name as the existing file, but with the specified suffix appended to it. Optionally the existing file
		/// can just be overwritten when the last argument is set to true.
		/// </summary>
		/// <param name="inputFilename">The input filename.</param>
		/// <param name="pageNumbers">The page numbers.</param>
		/// <param name="suffix">The suffix.</param>
		/// <param name="isOverwriteExisting">if set to <c>true</c> the original file is overwritten.</param>
		/// <exception cref="InvalidOperationException"></exception>
		//------------------------------------------------------------------------------------------------------------------------
		private static void SavePdfPages(string inputFilename, string pageNumbers, string suffix, bool isOverwriteExisting = false)
		{
			// Process numeric range.
			string[] pageNumArray = GetPageNumberArray(pageNumbers);

			if (!File.Exists(inputFilename))
				return;

			string filename = Path.GetFileNameWithoutExtension(inputFilename);
			if (filename == null)
				return;

			string outputFilename = $"{Path.Combine(Path.GetDirectoryName(inputFilename) ?? String.Empty, filename)}{suffix}.pdf";

			if (File.Exists(outputFilename))
			{
				if (isOverwriteExisting)
					File.Delete(outputFilename);
				else
					return;
			}

			// Open the file
			using PdfDocument inputDocument = PdfReader.Open(inputFilename, PdfDocumentOpenMode.Import);
			// Create a new pdf document in memory using parts of the original document.
			var outputDocument = new PdfDocument
			{
				Info =
				{
					Author = inputDocument.Info.Author,
					Creator = inputDocument.Info.Creator,
					Keywords = inputDocument.Info.Keywords,
					Subject = inputDocument.Info.Subject,
					Title = inputDocument.Info.Title
				},
				Options =
				{
					NoCompression = inputDocument.Options.NoCompression,
					CompressContentStreams = inputDocument.Options.CompressContentStreams
				},
				PageLayout = inputDocument.PageLayout,
				//PageMode = inputDocument.PageMode,
				Version = inputDocument.Version,
				ViewerPreferences =
				{
					CenterWindow = inputDocument.ViewerPreferences.CenterWindow,
					DisplayDocTitle = inputDocument.ViewerPreferences.DisplayDocTitle,
					FitWindow = inputDocument.ViewerPreferences.FitWindow,
					HideMenubar = inputDocument.ViewerPreferences.HideMenubar,
					HideToolbar = inputDocument.ViewerPreferences.HideToolbar
				}
			};

			// Add the pages specified by the user to the new pdf document.
			for (int idx = 0; idx < inputDocument.PageCount; idx++)
			{
				if ((idx + 1).ToString().In(pageNumArray))
					outputDocument.AddPage(inputDocument.Pages[idx]);
			}

			if (outputDocument.PageCount == 0)
				throw new InvalidOperationException($@"""{Path.GetFileName(outputFilename)}"" was not saved because it would have zero pages.");

			// Save the document to disk.
			outputDocument.Save(outputFilename);

			// Set the file creation and modification dates the same as the original.
			File.SetCreationTimeUtc(outputFilename, File.GetCreationTimeUtc(inputFilename));
			File.SetLastWriteTimeUtc(outputFilename, File.GetLastWriteTimeUtc(inputFilename));
		}

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns a page number array by parsing the specified pageNumbers string.
		/// </summary>
		/// <param name="pageNumbers">The page numbers.</param>
		/// <returns></returns>
		//------------------------------------------------------------------------------------------------------------------------
		private static string[] GetPageNumberArray(string pageNumbers)
		{
			pageNumbers = pageNumbers.Trim(' ', ',', ';', '-');
			MatchCollection mc = Regex.Matches(pageNumbers, @"([0-9]+)[ ]*\-[ ]*([0-9]+)", RegexOptions.Singleline);
			if (mc.Count > 0)
			{
				for (int index = mc.Count - 1; index >= 0; index--)
				{
					Match m = mc[index];
					string newPageNumbers = String.Empty;
					int beg = Int32.Parse(m.Groups[1].Value);
					int end = Int32.Parse(m.Groups[2].Value);
					for (int i = beg; i <= end; i++)
						newPageNumbers += i + ",";
					pageNumbers = pageNumbers.Substring(0, m.Index) + newPageNumbers + pageNumbers[(m.Index + m.Length)..];
				}
			}
			string[] pageNumArray = null;
			if (pageNumbers.Length > 0)
				pageNumArray = pageNumbers.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
			return pageNumArray;
		}

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Gets the file size information.
		/// </summary>
		/// <param name="len">The length of the file.</param>
		/// <returns></returns>
		//------------------------------------------------------------------------------------------------------------------------
		private static string GetFileSizeInfo(double len)
		{
			double origLen = len;
			// Beat it down a bit until it's a number smaller than 1024
			byte type = 0;
			while (len > 1024)
			{
				len /= 1024;
				type++;
			}

			// Change the descriptive name based on how many times we divided
			string units;
			switch (type)
			{
				case 0:
					units = " bytes";
					break;
				case 1:
					units = " KB";
					break;
				case 2:
					units = " MB";
					break;
				case 3:
					units = " GB";
					break;
				default: // what is this? Just make it bytes...
					len = origLen;
					units = " bytes";
					break;
			}

			// Cut off 00 from the end of it
			string size = len.ToString("F");
			if (size.EndsWith(".00"))
				size = size.Remove(size.Length - 3, 3);

			return $"{size}{units} ({origLen:N0} bytes)";
		}

		#endregion
	}

	//..................................................................................................................................

	#region Public Extension Class

	public static class MyExtensions
	{
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Returns an indication as to whether this object exists in the specified enumerable collection.
		/// </summary>
		/// <param name="obj">What to look for in the collection.</param>
		/// <param name="col">Collection to iterate over.</param>
		/// <returns>True if this object exists in the specified collection; otherwise false.</returns>
		//------------------------------------------------------------------------------------------------------------------------
		public static bool In(this object obj, IEnumerable col)
		{
			return col.Cast<object>().Contains(obj);
		}
	}

	#endregion
}

