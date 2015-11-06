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
		/// <summary>
		/// Summary description for dbImageBox.
		/// </summary>
		public class SPImageBox : System.Windows.Forms.PictureBox
		{
			
			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.Container components = null;
			private string m_ImagePath;
			
			//		public delegate void ImgEventHandler (object s);
			//		public event ImgEventHandler ImagePathChanged;
			
			public SPImageBox()
			{
				// This call is required by the Windows.Forms Form Designer.
				InitializeComponent();
				
				// TODO: Add any initialization after the InitComponent call
			}
			
			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					if (components != null)
					{
						components.Dispose();
					}
				}
				base.Dispose(disposing);
			}
			#region Component Designer generated code
			/// <summary>
			/// Required method for Designer support - do not modify
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{
				components = new System.ComponentModel.Container();
			}
			#endregion
			
			protected override void OnPaint(PaintEventArgs pe)
			{
				// TODO: Add custom paint code here
				
				// Calling the base class OnPaint
				base.OnPaint(pe);
			}
			
			public string ImagePath
			{
				get
				{
					return this.m_ImagePath;
				}
				set
				{
					if (value != this.m_ImagePath)
					{
						this.m_ImagePath = value;
						if (System.IO.File.Exists(value))
						{
							UpdateImage();
						}
						else
						{
							this.Image = null;
						}
						//					ImagePathChanged(this);
					}
				}
			}
			
			public void UpdateImage()
			{
				try
				{
					this.Image = Image.FromFile(ImagePath);
				}
				catch (System.Exception e)
				{
					MessageBox.Show(e.Message);
					this.Image = null;
				}
			}
			
		}
	}
	
}
