namespace PdfPageSaver
{
	partial class MainForm
	{
		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Required designer variable.
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		private System.ComponentModel.IContainer components = null;

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		//----------------------------------------------------------------------------------------------------
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		//.............................................................................................................

		#region Windows Form Designer generated code

		//----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		//----------------------------------------------------------------------------------------------------
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdoAddSuffix = new System.Windows.Forms.RadioButton();
			this.rdoOverwrite = new System.Windows.Forms.RadioButton();
			this.txtSuffix = new System.Windows.Forms.TextBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnRemoveAll = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.lblPdfFiles = new System.Windows.Forms.Label();
			this.lblPageNumbersHelp = new System.Windows.Forms.Label();
			this.lblFileSize = new System.Windows.Forms.Label();
			this.lblPageNumbers = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.ctxMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ctxMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ctxMenuSave = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuSaveSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ctxMenuRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuRemoveAllButSelected = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.ctxMenuProperties = new System.Windows.Forms.ToolStripMenuItem();
			this.lblNumPages = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.chkSaveSettings = new System.Windows.Forms.CheckBox();
			this.lblCaption = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtPageNumbers = new PdfPageSaver.TextBoxEx();
			this.groupBox1.SuspendLayout();
			this.ctxMenu1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.rdoAddSuffix);
			this.groupBox1.Controls.Add(this.rdoOverwrite);
			this.groupBox1.Controls.Add(this.txtSuffix);
			this.groupBox1.Location = new System.Drawing.Point(271, 30);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(170, 76);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			// 
			// rdoAddSuffix
			// 
			this.rdoAddSuffix.AutoSize = true;
			this.rdoAddSuffix.Checked = true;
			this.rdoAddSuffix.Location = new System.Drawing.Point(9, 44);
			this.rdoAddSuffix.Name = "rdoAddSuffix";
			this.rdoAddSuffix.Size = new System.Drawing.Size(110, 19);
			this.rdoAddSuffix.TabIndex = 0;
			this.rdoAddSuffix.TabStop = true;
			this.rdoAddSuffix.Text = "New with Suffix:";
			this.toolTip1.SetToolTip(this.rdoAddSuffix, "Indicates each pdf file saved should be a new pdf file of the \r\nsame name and pat" +
        "h as the original, but with the specified \r\nsuffix appended to the end of its na" +
        "me.");
			this.rdoAddSuffix.UseVisualStyleBackColor = true;
			// 
			// rdoOverwrite
			// 
			this.rdoOverwrite.AutoSize = true;
			this.rdoOverwrite.Location = new System.Drawing.Point(9, 17);
			this.rdoOverwrite.Name = "rdoOverwrite";
			this.rdoOverwrite.Size = new System.Drawing.Size(143, 19);
			this.rdoOverwrite.TabIndex = 2;
			this.rdoOverwrite.Text = "Overwrite original PDF";
			this.toolTip1.SetToolTip(this.rdoOverwrite, "Indicates that each pdf file saved should just be \r\noverwritten with the specifie" +
        "d pages.");
			this.rdoOverwrite.UseVisualStyleBackColor = true;
			// 
			// txtSuffix
			// 
			this.txtSuffix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSuffix.Location = new System.Drawing.Point(119, 42);
			this.txtSuffix.Name = "txtSuffix";
			this.txtSuffix.Size = new System.Drawing.Size(43, 23);
			this.txtSuffix.TabIndex = 1;
			this.txtSuffix.Text = "_new";
			// 
			// btnExit
			// 
			this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnExit.Location = new System.Drawing.Point(291, 292);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(87, 27);
			this.btnExit.TabIndex = 11;
			this.btnExit.Text = "Exit";
			this.toolTip1.SetToolTip(this.btnExit, "Exits this application after saving or resetting the settings depending on whethe" +
        "r the \'Save Settings\' is checkmarked.");
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnRemoveAll
			// 
			this.btnRemoveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveAll.Enabled = false;
			this.btnRemoveAll.Location = new System.Drawing.Point(472, 130);
			this.btnRemoveAll.Name = "btnRemoveAll";
			this.btnRemoveAll.Size = new System.Drawing.Size(87, 27);
			this.btnRemoveAll.TabIndex = 8;
			this.btnRemoveAll.Text = "Remove All";
			this.toolTip1.SetToolTip(this.btnRemoveAll, "Removes all the file paths from the list of pdf files. \r\n(Right click on a file t" +
        "o see more choices...)");
			this.btnRemoveAll.UseVisualStyleBackColor = true;
			this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnSave.Enabled = false;
			this.btnSave.Location = new System.Drawing.Point(197, 292);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(87, 27);
			this.btnSave.TabIndex = 10;
			this.btnSave.Text = "Save";
			this.toolTip1.SetToolTip(this.btnSave, "Saves the specified pages of each pdf file in the list above to a \r\nnew pdf file " +
        "using the same directory and file name, but with the \r\nspecified suffix appended" +
        " to the end of each file name.");
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// lblPdfFiles
			// 
			this.lblPdfFiles.AutoSize = true;
			this.lblPdfFiles.Location = new System.Drawing.Point(17, 68);
			this.lblPdfFiles.Name = "lblPdfFiles";
			this.lblPdfFiles.Size = new System.Drawing.Size(63, 15);
			this.lblPdfFiles.TabIndex = 1;
			this.lblPdfFiles.Text = "PDF file(s):";
			this.toolTip1.SetToolTip(this.lblPdfFiles, "Contains the list of PDF files you want to save with just the specified pages fro" +
        "m each.");
			// 
			// lblPageNumbersHelp
			// 
			this.lblPageNumbersHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblPageNumbersHelp.Location = new System.Drawing.Point(6, 71);
			this.lblPageNumbersHelp.Name = "lblPageNumbersHelp";
			this.lblPageNumbersHelp.Size = new System.Drawing.Size(265, 33);
			this.lblPageNumbersHelp.TabIndex = 9;
			this.lblPageNumbersHelp.Text = "Delimit with commas, semi-colons, or spaces.\r\nCan also specify ranges such as  3-" +
    "7, 12-14, etc.";
			this.toolTip1.SetToolTip(this.lblPageNumbersHelp, resources.GetString("lblPageNumbersHelp.ToolTip"));
			// 
			// lblFileSize
			// 
			this.lblFileSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFileSize.AutoSize = true;
			this.lblFileSize.Location = new System.Drawing.Point(423, 68);
			this.lblFileSize.Name = "lblFileSize";
			this.lblFileSize.Size = new System.Drawing.Size(136, 15);
			this.lblFileSize.TabIndex = 2;
			this.lblFileSize.Text = "00.00 MB (000,000 bytes)";
			this.lblFileSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.toolTip1.SetToolTip(this.lblFileSize, "Indicates the current file size of the selected pdf file.");
			// 
			// lblPageNumbers
			// 
			this.lblPageNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblPageNumbers.AutoSize = true;
			this.lblPageNumbers.Location = new System.Drawing.Point(6, 27);
			this.lblPageNumbers.Name = "lblPageNumbers";
			this.lblPageNumbers.Size = new System.Drawing.Size(126, 15);
			this.lblPageNumbers.TabIndex = 5;
			this.lblPageNumbers.Text = "Page numbers to save:";
			this.toolTip1.SetToolTip(this.lblPageNumbers, "Contains the page numbers from each pdf file to save.");
			// 
			// listBox1
			// 
			this.listBox1.AllowDrop = true;
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox1.ContextMenuStrip = this.ctxMenu1;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 15;
			this.listBox1.Location = new System.Drawing.Point(17, 88);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(542, 34);
			this.listBox1.Sorted = true;
			this.listBox1.TabIndex = 3;
			this.toolTip1.SetToolTip(this.listBox1, "Contains the list of PDF files to save with just the specified pages.");
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
			this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
			this.listBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyUp);
			this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
			this.listBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDown);
			// 
			// ctxMenu1
			// 
			this.ctxMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuOpen,
            this.toolStripSeparator1,
            this.ctxMenuSave,
            this.ctxMenuSaveSelected,
            this.toolStripSeparator2,
            this.ctxMenuRemove,
            this.ctxMenuRemoveAll,
            this.ctxMenuRemoveAllButSelected,
            this.toolStripSeparator3,
            this.ctxMenuProperties});
			this.ctxMenu1.Name = "contextMenuStrip1";
			this.ctxMenu1.Size = new System.Drawing.Size(203, 176);
			this.ctxMenu1.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenu1_Opening);
			// 
			// ctxMenuOpen
			// 
			this.ctxMenuOpen.Name = "ctxMenuOpen";
			this.ctxMenuOpen.Size = new System.Drawing.Size(202, 22);
			this.ctxMenuOpen.Text = "Open";
			this.ctxMenuOpen.Click += new System.EventHandler(this.ctxMenuOpen_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(199, 6);
			// 
			// ctxMenuSave
			// 
			this.ctxMenuSave.Name = "ctxMenuSave";
			this.ctxMenuSave.Size = new System.Drawing.Size(202, 22);
			this.ctxMenuSave.Text = "Save";
			this.ctxMenuSave.Click += new System.EventHandler(this.ctxMenuSave_Click);
			// 
			// ctxMenuSaveSelected
			// 
			this.ctxMenuSaveSelected.Name = "ctxMenuSaveSelected";
			this.ctxMenuSaveSelected.Size = new System.Drawing.Size(202, 22);
			this.ctxMenuSaveSelected.Text = "Save Selected";
			this.ctxMenuSaveSelected.Click += new System.EventHandler(this.ctxMenuSaveSelected_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
			// 
			// ctxMenuRemove
			// 
			this.ctxMenuRemove.Name = "ctxMenuRemove";
			this.ctxMenuRemove.Size = new System.Drawing.Size(202, 22);
			this.ctxMenuRemove.Text = "Remove";
			this.ctxMenuRemove.Click += new System.EventHandler(this.ctxMenuRemove_Click);
			// 
			// ctxMenuRemoveAll
			// 
			this.ctxMenuRemoveAll.Name = "ctxMenuRemoveAll";
			this.ctxMenuRemoveAll.Size = new System.Drawing.Size(202, 22);
			this.ctxMenuRemoveAll.Text = "Remove All";
			this.ctxMenuRemoveAll.Click += new System.EventHandler(this.ctxMenuRemoveAll_Click);
			// 
			// ctxMenuRemoveAllButSelected
			// 
			this.ctxMenuRemoveAllButSelected.Name = "ctxMenuRemoveAllButSelected";
			this.ctxMenuRemoveAllButSelected.Size = new System.Drawing.Size(202, 22);
			this.ctxMenuRemoveAllButSelected.Text = "Remove All But Selected";
			this.ctxMenuRemoveAllButSelected.Click += new System.EventHandler(this.ctxMenuRemoveAllButSelected_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(199, 6);
			// 
			// ctxMenuProperties
			// 
			this.ctxMenuProperties.Name = "ctxMenuProperties";
			this.ctxMenuProperties.Size = new System.Drawing.Size(202, 22);
			this.ctxMenuProperties.Text = "Properties...";
			this.ctxMenuProperties.Click += new System.EventHandler(this.ctxMenuProperties_Click);
			// 
			// lblNumPages
			// 
			this.lblNumPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblNumPages.AutoSize = true;
			this.lblNumPages.Location = new System.Drawing.Point(18, 128);
			this.lblNumPages.Name = "lblNumPages";
			this.lblNumPages.Size = new System.Drawing.Size(152, 15);
			this.lblNumPages.TabIndex = 4;
			this.lblNumPages.Text = "Current number of pages: 0";
			this.toolTip1.SetToolTip(this.lblNumPages, "Indicates the current number of pages of the selected pdf file.");
			this.lblNumPages.Move += new System.EventHandler(this.lblNumPages_Move);
			// 
			// chkSaveSettings
			// 
			this.chkSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.chkSaveSettings.AutoSize = true;
			this.chkSaveSettings.Location = new System.Drawing.Point(446, 86);
			this.chkSaveSettings.Name = "chkSaveSettings";
			this.chkSaveSettings.Size = new System.Drawing.Size(95, 19);
			this.chkSaveSettings.TabIndex = 12;
			this.chkSaveSettings.Text = "Save Settings";
			this.toolTip1.SetToolTip(this.chkSaveSettings, "When checkmarked, indicates the settings will be saved between sessions.\r\nWhen no" +
        "t checkmarked, indicates settings will be reset to their default \r\nvalues the ne" +
        "xt time this application is opened .");
			this.chkSaveSettings.UseVisualStyleBackColor = true;
			// 
			// lblCaption
			// 
			this.lblCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCaption.Location = new System.Drawing.Point(15, 9);
			this.lblCaption.Name = "lblCaption";
			this.lblCaption.Size = new System.Drawing.Size(548, 56);
			this.lblCaption.TabIndex = 0;
			this.lblCaption.Text = resources.GetString("lblCaption.Text");
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.lblPageNumbersHelp);
			this.groupBox2.Controls.Add(this.txtPageNumbers);
			this.groupBox2.Controls.Add(this.lblPageNumbers);
			this.groupBox2.Controls.Add(this.chkSaveSettings);
			this.groupBox2.Controls.Add(this.groupBox1);
			this.groupBox2.Location = new System.Drawing.Point(15, 164);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(543, 118);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Settings";
			// 
			// txtPageNumbers
			// 
			this.txtPageNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.txtPageNumbers.Location = new System.Drawing.Point(9, 45);
			this.txtPageNumbers.Name = "txtPageNumbers";
			this.txtPageNumbers.Size = new System.Drawing.Size(252, 23);
			this.txtPageNumbers.TabIndex = 6;
			this.txtPageNumbers.Text = "1,3";
			// 
			// MainForm
			// 
			this.AcceptButton = this.btnSave;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnExit;
			this.ClientSize = new System.Drawing.Size(575, 330);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.lblCaption);
			this.Controls.Add(this.lblNumPages);
			this.Controls.Add(this.lblFileSize);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.lblPdfFiles);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnRemoveAll);
			this.Controls.Add(this.btnSave);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PDF Page Saver";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ctxMenu1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnRemoveAll;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.ContextMenuStrip ctxMenu1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblFileSize;
		private System.Windows.Forms.Label lblNumPages;
		private System.Windows.Forms.Label lblPageNumbers;
		private System.Windows.Forms.Label lblPageNumbersHelp;
		private System.Windows.Forms.Label lblPdfFiles;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.RadioButton rdoAddSuffix;
		private System.Windows.Forms.RadioButton rdoOverwrite;
		private TextBoxEx txtPageNumbers;
		private System.Windows.Forms.TextBox txtSuffix;
		private System.Windows.Forms.ToolStripMenuItem ctxMenuOpen;
		private System.Windows.Forms.ToolStripMenuItem ctxMenuRemove;
		private System.Windows.Forms.ToolStripMenuItem ctxMenuRemoveAll;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.CheckBox chkSaveSettings;
		private System.Windows.Forms.Label lblCaption;
		private System.Windows.Forms.ToolStripMenuItem ctxMenuRemoveAllButSelected;
		private System.Windows.Forms.ToolStripMenuItem ctxMenuSave;
		private System.Windows.Forms.ToolStripMenuItem ctxMenuSaveSelected;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem ctxMenuProperties;
	}
}

