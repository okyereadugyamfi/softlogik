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
	namespace UI
	{
		public partial class SPFileDialog
		{
			
			
			public enum FileDialogTypes
			{
				General = 0,
				Picture,
				OfficeDocument,
				Video,
				Audio
				
			}
			
			public static string ShowDialog(FileDialogTypes FileType)
			{
				
				try
				{
					using (OpenFileDialog myFileDialog = new OpenFileDialog())
					{
						myFileDialog.Filter = GetFilters(FileType);
						if (myFileDialog.ShowDialog() == DialogResult.OK)
						{
							return myFileDialog.FileName;
						}
						
					}
					
					
				}
				catch (Exception)
				{
				}
				return null;
			}
			public static string[] ShowMultiDialog(FileDialogTypes FileType)
			{
				
				try
				{
					using (OpenFileDialog myFileDialog = new OpenFileDialog())
					{
						if (myFileDialog.ShowDialog() == DialogResult.OK)
						{
							return myFileDialog.FileNames;
						}
						
					}
					
					
				}
				catch (Exception)
				{
				}
				return null;
			}
			
			private static string GetFilters(FileDialogTypes filetype)
			{
				switch (filetype)
				{
					case FileDialogTypes.Picture:
						return "All Picture Files(*.jpeg,*.jpe,*.jpg,*.gif,*.png,*.bmp,*.wmf,*.ico)|*.jpeg;*.jpe;*.jpg;*.gif;*.png;*.bmp;*.wmf;*.ico|JPEG Files(*.jpg,*.jpe,*.jpeg)|*.jpg;*.jpe;*.jpeg";
					default:
						return "All Files(*.*)|*.*";
				}
				
				return null;
			}
		}
	}
	
	
}
