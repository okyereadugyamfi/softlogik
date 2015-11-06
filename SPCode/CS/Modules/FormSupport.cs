using System.Text.RegularExpressions;
using System.Diagnostics;
using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using WeifenLuo.WinFormsUI;
using Microsoft.Win32;
using WeifenLuo;


namespace SoftLogik.Win
{
	sealed class FormSupport
	{
		public static void FormCenter(Form frmCurrent)
		{
			int intLeft;
			int intTop;
			Form frm;
			
			frm = frmCurrent;
			intLeft = (Screen.PrimaryScreen.Bounds.Width / 2) - (frmCurrent.Width / 2);
			intTop = (Screen.PrimaryScreen.Bounds.Height / 2) - (frmCurrent.Height / 2);
			frm.Location = new Point(intLeft, intTop);
		}
		public static DialogResult FormClosingCheck(Form frmName)
		{
			if (frmName.WindowState == System.Windows.Forms.FormWindowState.Minimized)
			{
				frmName.WindowState = FormWindowState.Normal;
			}
			
			frmName.BringToFront();
			
			// Ask user what to do with the changes
			return MessageBox.Show(CultureSupport.TextDictionary("MS_DATACHANGED", TextReturnTypeEnum.PureString), frmName.Text, MessageBoxButtons.YesNoCancel);
		}
		public static void FormCenterChild(Form frmCurrent)
		{
			int intLeft;
			int intTop;
			Form frm;
			
			frm = frmCurrent;
			intLeft = (Common.MainShell.Width / 2) - (frmCurrent.Width / 2);
			intTop = (Common.MainShell.Height / 2) - (frmCurrent.Height / 2);
			frm.Location = new Point(intLeft, intTop);
		}
		public static bool DeleteAsk(string strMsg, string strCaption)
		{
			bool returnValue;
			if (Interaction.MsgBox(strMsg, MsgBoxStyle.Question || MsgBoxStyle.YesNo, (strCaption != "" ? strCaption : System.Windows.Forms.Form.ActiveForm.Text)) == MsgBoxResult.Yes)
			{
				returnValue = true;
			}
			else
			{
				returnValue = false;
			}
			return returnValue;
		}
	}
	
	
}
