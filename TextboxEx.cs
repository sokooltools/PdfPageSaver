using System;
using System.Linq;
using System.Windows.Forms;

namespace PdfPageSaver
{
	internal class TextBoxEx : TextBox
	{

		private readonly char[] _validChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', ' ', ',', ';' };
		private readonly int[] _validKeyValues = { 8, 16, 17, 18, 32, 33, 34, 35, 36, 37, 38, 39, 40, 46, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 186, 188, 189 };
		private readonly int[] _validShiftKeyValues = { 16, 35, 36, 37, 38, 39, 40 };

		//private const int WM_CUT = 0x0300;
		//private const int WM_COPY = 0x0301;
		private const int WM_PASTE = 0x0302;

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (!(e.Control || e.Alt))
				if (!e.Shift && !_validKeyValues.Contains(e.KeyValue))
					e.SuppressKeyPress = true;
				else if (e.Shift && !_validShiftKeyValues.Contains(e.KeyValue))
					e.SuppressKeyPress = true;
			base.OnKeyDown(e);
		}

		protected override void WndProc(ref Message m) // 1-2;a;3-4;
		{
			if (m.Msg == WM_PASTE)
			{
				string orgText = Clipboard.GetText();
				string newText = orgText.Where(c => _validChars.Contains(c)).Aggregate(String.Empty, (current, c) => current + c);
				if (newText != orgText)
				{
					if (String.IsNullOrEmpty(newText))
						return;
					Clipboard.SetText(newText.Trim());
					base.WndProc(ref m);
					Clipboard.SetText(orgText);
					return;
				}
			}
			base.WndProc(ref m);
		}
	}
}
