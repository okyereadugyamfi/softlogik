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
		[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public partial class CompanyForm : SetupForm
		{
			//Form overrides dispose to clean up the component list.
			[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
			{
				if (disposing && (components != null))
				{
					components.Dispose();
				}
				base.Dispose(disposing);
			}
			
			//Required by the Windows Form Designer
			private System.ComponentModel.Container components = null;
			
			//NOTE: The following procedure is required by the Windows Form Designer
			//It can be modified using the Windows Form Designer.
			//Do not modify it using the code editor.
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyForm));
				this.lblAddress = new System.Windows.Forms.Label();
				this.TextBox1 = new System.Windows.Forms.TextBox();
				this.lblName = new System.Windows.Forms.Label();
				this.txtName = new System.Windows.Forms.TextBox();
				this.lblPhoneList = new System.Windows.Forms.Label();
				this.txtRegistrationNo = new System.Windows.Forms.TextBox();
				this.Logo = new System.Windows.Forms.PictureBox();
				this.Logo.BackgroundImageChanged += new System.EventHandler(Logo_BackgroundImageChanged);
				this.Logo.Invalidated += new System.Windows.Forms.InvalidateEventHandler(Logo_Invalidated);
				this.tabContacts = new System.Windows.Forms.TabPage();
				this.gbxPrimaryContact = new System.Windows.Forms.GroupBox();
				this.lblPhone2 = new System.Windows.Forms.Label();
				this.lblPhone1 = new System.Windows.Forms.Label();
				this.txtCPhone2 = new System.Windows.Forms.TextBox();
				this.txtCPhone1 = new System.Windows.Forms.TextBox();
				this.txtCFirstName = new System.Windows.Forms.TextBox();
				this.txtCLastName = new System.Windows.Forms.TextBox();
				this.lblCLastName = new System.Windows.Forms.Label();
				this.lblCFirstName = new System.Windows.Forms.Label();
				this.btnChangePhoto = new System.Windows.Forms.Button();
				this.btnChangePhoto.Click += new System.EventHandler(btnChangePhoto_Click);
				this.btnClearPhoto = new System.Windows.Forms.Button();
				this.btnClearPhoto.Click += new System.EventHandler(btnClearPhoto_Click);
				this.TextBox2 = new System.Windows.Forms.TextBox();
				this.Label1 = new System.Windows.Forms.Label();
				this.tabOther = new System.Windows.Forms.TabPage();
				this.Label3 = new System.Windows.Forms.Label();
				this.Label2 = new System.Windows.Forms.Label();
				this.TextBox4 = new System.Windows.Forms.TextBox();
				this.TextBox3 = new System.Windows.Forms.TextBox();
				this.tbcMain.SuspendLayout();
				this.tabGeneral.SuspendLayout();
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).BeginInit();
				((System.ComponentModel.ISupportInitialize) this.Logo).BeginInit();
				this.tabContacts.SuspendLayout();
				this.gbxPrimaryContact.SuspendLayout();
				this.tabOther.SuspendLayout();
				this.SuspendLayout();
				//
				//tvwName
				//
				this.tvwName.LineColor = System.Drawing.Color.Black;
				this.tvwName.Size = new System.Drawing.Size(215, 381);
				this.tvwName.TabIndex = 3;
				//
				//tbcMain
				//
				this.tbcMain.Controls.Add(this.tabContacts);
				this.tbcMain.Controls.Add(this.tabOther);
				this.tbcMain.Size = new System.Drawing.Size(434, 381);
				this.tbcMain.TabIndex = 5;
				this.tbcMain.Controls.SetChildIndex(this.tabOther, 0);
				this.tbcMain.Controls.SetChildIndex(this.tabGeneral, 0);
				this.tbcMain.Controls.SetChildIndex(this.tabContacts, 0);
				//
				//tabGeneral
				//
				this.tabGeneral.Controls.Add(this.Label1);
				this.tabGeneral.Controls.Add(this.TextBox2);
				this.tabGeneral.Controls.Add(this.btnClearPhoto);
				this.tabGeneral.Controls.Add(this.btnChangePhoto);
				this.tabGeneral.Controls.Add(this.lblAddress);
				this.tabGeneral.Controls.Add(this.TextBox1);
				this.tabGeneral.Controls.Add(this.lblName);
				this.tabGeneral.Controls.Add(this.txtName);
				this.tabGeneral.Controls.Add(this.lblPhoneList);
				this.tabGeneral.Controls.Add(this.txtRegistrationNo);
				this.tabGeneral.Controls.Add(this.Logo);
				this.tabGeneral.Size = new System.Drawing.Size(426, 358);
				this.tabGeneral.TabIndex = 6;
				//
				//IconSource
				//
				this.IconSource.ImageStream = (System.Windows.Forms.ImageListStreamer) (resources.GetObject("IconSource.ImageStream"));
				this.IconSource.Images.SetKeyName(0, "wi0111-48.gif");
				//
				//lblAddress
				//
				this.lblAddress.AutoSize = true;
				this.lblAddress.Location = new System.Drawing.Point(7, 85);
				this.lblAddress.Name = "lblAddress";
				this.lblAddress.Size = new System.Drawing.Size(57, 13);
				this.lblAddress.TabIndex = 21;
				this.lblAddress.Text = "Address 1:";
				//
				//TextBox1
				//
				this.TextBox1.Location = new System.Drawing.Point(89, 82);
				this.TextBox1.Multiline = true;
				this.TextBox1.Name = "TextBox1";
				this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
				this.TextBox1.Size = new System.Drawing.Size(172, 69);
				this.TextBox1.TabIndex = 20;
				this.TextBox1.Tag = "Address1";
				//
				//lblName
				//
				this.lblName.AutoSize = true;
				this.lblName.Location = new System.Drawing.Point(7, 33);
				this.lblName.Name = "lblName";
				this.lblName.Size = new System.Drawing.Size(38, 13);
				this.lblName.TabIndex = 19;
				this.lblName.Text = "&Name:";
				//
				//txtName
				//
				this.txtName.Location = new System.Drawing.Point(89, 30);
				this.txtName.Name = "txtName";
				this.txtName.Size = new System.Drawing.Size(172, 20);
				this.txtName.TabIndex = 18;
				this.txtName.Tag = "Name";
				//
				//lblPhoneList
				//
				this.lblPhoneList.AutoSize = true;
				this.lblPhoneList.Location = new System.Drawing.Point(7, 59);
				this.lblPhoneList.Name = "lblPhoneList";
				this.lblPhoneList.Size = new System.Drawing.Size(52, 13);
				this.lblPhoneList.TabIndex = 17;
				this.lblPhoneList.Text = "Phone(s):";
				//
				//txtRegistrationNo
				//
				this.txtRegistrationNo.Location = new System.Drawing.Point(89, 56);
				this.txtRegistrationNo.Name = "txtRegistrationNo";
				this.txtRegistrationNo.Size = new System.Drawing.Size(172, 20);
				this.txtRegistrationNo.TabIndex = 16;
				this.txtRegistrationNo.Tag = "PhoneList";
				//
				//Logo
				//
				this.Logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				this.Logo.Location = new System.Drawing.Point(283, 30);
				this.Logo.Name = "Logo";
				this.Logo.Size = new System.Drawing.Size(136, 120);
				this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
				this.Logo.TabIndex = 15;
				this.Logo.TabStop = false;
				this.Logo.Tag = "Logo";
				//
				//tabContacts
				//
				this.tabContacts.Controls.Add(this.gbxPrimaryContact);
				this.tabContacts.Location = new System.Drawing.Point(4, 19);
				this.tabContacts.Name = "tabContacts";
				this.tabContacts.Padding = new System.Windows.Forms.Padding(3);
				this.tabContacts.Size = new System.Drawing.Size(426, 358);
				this.tabContacts.TabIndex = 2;
				this.tabContacts.Text = "Contacts";
				this.tabContacts.UseVisualStyleBackColor = true;
				//
				//gbxPrimaryContact
				//
				this.gbxPrimaryContact.Controls.Add(this.lblPhone2);
				this.gbxPrimaryContact.Controls.Add(this.lblPhone1);
				this.gbxPrimaryContact.Controls.Add(this.txtCPhone2);
				this.gbxPrimaryContact.Controls.Add(this.txtCPhone1);
				this.gbxPrimaryContact.Controls.Add(this.txtCFirstName);
				this.gbxPrimaryContact.Controls.Add(this.txtCLastName);
				this.gbxPrimaryContact.Controls.Add(this.lblCLastName);
				this.gbxPrimaryContact.Controls.Add(this.lblCFirstName);
				this.gbxPrimaryContact.Dock = System.Windows.Forms.DockStyle.Fill;
				this.gbxPrimaryContact.Location = new System.Drawing.Point(3, 3);
				this.gbxPrimaryContact.Name = "gbxPrimaryContact";
				this.gbxPrimaryContact.Size = new System.Drawing.Size(420, 352);
				this.gbxPrimaryContact.TabIndex = 15;
				this.gbxPrimaryContact.TabStop = false;
				this.gbxPrimaryContact.Text = "Primary Contact";
				//
				//lblPhone2
				//
				this.lblPhone2.AutoSize = true;
				this.lblPhone2.Location = new System.Drawing.Point(19, 108);
				this.lblPhone2.Name = "lblPhone2";
				this.lblPhone2.Size = new System.Drawing.Size(72, 13);
				this.lblPhone2.TabIndex = 7;
				this.lblPhone2.Text = "2nd Phone #:";
				//
				//lblPhone1
				//
				this.lblPhone1.AutoSize = true;
				this.lblPhone1.Location = new System.Drawing.Point(19, 82);
				this.lblPhone1.Name = "lblPhone1";
				this.lblPhone1.Size = new System.Drawing.Size(68, 13);
				this.lblPhone1.TabIndex = 6;
				this.lblPhone1.Text = "1st Phone #:";
				//
				//txtCPhone2
				//
				this.txtCPhone2.Location = new System.Drawing.Point(93, 105);
				this.txtCPhone2.Name = "txtCPhone2";
				this.txtCPhone2.Size = new System.Drawing.Size(215, 20);
				this.txtCPhone2.TabIndex = 5;
				//
				//txtCPhone1
				//
				this.txtCPhone1.Location = new System.Drawing.Point(93, 79);
				this.txtCPhone1.Name = "txtCPhone1";
				this.txtCPhone1.Size = new System.Drawing.Size(215, 20);
				this.txtCPhone1.TabIndex = 4;
				//
				//txtCFirstName
				//
				this.txtCFirstName.Location = new System.Drawing.Point(93, 31);
				this.txtCFirstName.Name = "txtCFirstName";
				this.txtCFirstName.Size = new System.Drawing.Size(215, 20);
				this.txtCFirstName.TabIndex = 3;
				//
				//txtCLastName
				//
				this.txtCLastName.Location = new System.Drawing.Point(93, 53);
				this.txtCLastName.Name = "txtCLastName";
				this.txtCLastName.Size = new System.Drawing.Size(215, 20);
				this.txtCLastName.TabIndex = 2;
				//
				//lblCLastName
				//
				this.lblCLastName.AutoSize = true;
				this.lblCLastName.Location = new System.Drawing.Point(19, 56);
				this.lblCLastName.Name = "lblCLastName";
				this.lblCLastName.Size = new System.Drawing.Size(61, 13);
				this.lblCLastName.TabIndex = 1;
				this.lblCLastName.Text = "&Last Name:";
				//
				//lblCFirstName
				//
				this.lblCFirstName.AutoSize = true;
				this.lblCFirstName.Location = new System.Drawing.Point(19, 34);
				this.lblCFirstName.Name = "lblCFirstName";
				this.lblCFirstName.Size = new System.Drawing.Size(60, 13);
				this.lblCFirstName.TabIndex = 0;
				this.lblCFirstName.Text = "&First Name:";
				//
				//btnChangePhoto
				//
				this.btnChangePhoto.Location = new System.Drawing.Point(283, 156);
				this.btnChangePhoto.Name = "btnChangePhoto";
				this.btnChangePhoto.Size = new System.Drawing.Size(75, 23);
				this.btnChangePhoto.TabIndex = 22;
				this.btnChangePhoto.Text = "&Change";
				this.btnChangePhoto.UseVisualStyleBackColor = true;
				//
				//btnClearPhoto
				//
				this.btnClearPhoto.Location = new System.Drawing.Point(364, 156);
				this.btnClearPhoto.Name = "btnClearPhoto";
				this.btnClearPhoto.Size = new System.Drawing.Size(50, 23);
				this.btnClearPhoto.TabIndex = 23;
				this.btnClearPhoto.Text = "Clear";
				this.btnClearPhoto.UseVisualStyleBackColor = true;
				//
				//TextBox2
				//
				this.TextBox2.Location = new System.Drawing.Point(89, 158);
				this.TextBox2.Multiline = true;
				this.TextBox2.Name = "TextBox2";
				this.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
				this.TextBox2.Size = new System.Drawing.Size(172, 69);
				this.TextBox2.TabIndex = 24;
				this.TextBox2.Tag = "Address2";
				//
				//Label1
				//
				this.Label1.AutoSize = true;
				this.Label1.Location = new System.Drawing.Point(7, 161);
				this.Label1.Name = "Label1";
				this.Label1.Size = new System.Drawing.Size(57, 13);
				this.Label1.TabIndex = 25;
				this.Label1.Text = "Address 2:";
				//
				//tabOther
				//
				this.tabOther.Controls.Add(this.Label3);
				this.tabOther.Controls.Add(this.Label2);
				this.tabOther.Controls.Add(this.TextBox4);
				this.tabOther.Controls.Add(this.TextBox3);
				this.tabOther.Location = new System.Drawing.Point(4, 19);
				this.tabOther.Name = "tabOther";
				this.tabOther.Padding = new System.Windows.Forms.Padding(3);
				this.tabOther.Size = new System.Drawing.Size(426, 358);
				this.tabOther.TabIndex = 7;
				this.tabOther.Text = "Other";
				this.tabOther.UseVisualStyleBackColor = true;
				//
				//Label3
				//
				this.Label3.AutoSize = true;
				this.Label3.Location = new System.Drawing.Point(7, 103);
				this.Label3.Name = "Label3";
				this.Label3.Size = new System.Drawing.Size(76, 13);
				this.Label3.TabIndex = 30;
				this.Label3.Text = "Note(Reports):";
				//
				//Label2
				//
				this.Label2.AutoSize = true;
				this.Label2.Location = new System.Drawing.Point(7, 32);
				this.Label2.Name = "Label2";
				this.Label2.Size = new System.Drawing.Size(37, 13);
				this.Label2.TabIndex = 29;
				this.Label2.Text = "Motto:";
				//
				//TextBox4
				//
				this.TextBox4.Location = new System.Drawing.Point(91, 100);
				this.TextBox4.Multiline = true;
				this.TextBox4.Name = "TextBox4";
				this.TextBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
				this.TextBox4.Size = new System.Drawing.Size(311, 190);
				this.TextBox4.TabIndex = 28;
				this.TextBox4.Tag = "CustomNote";
				//
				//TextBox3
				//
				this.TextBox3.Location = new System.Drawing.Point(91, 32);
				this.TextBox3.Multiline = true;
				this.TextBox3.Name = "TextBox3";
				this.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
				this.TextBox3.Size = new System.Drawing.Size(311, 51);
				this.TextBox3.TabIndex = 27;
				this.TextBox3.Tag = "Motto";
				//
				//CompanyForm
				//
				this.AutoScaleDimensions = new System.Drawing.SizeF(6.0, 13.0);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(653, 406);
				this.Icon = (System.Drawing.Icon) (resources.GetObject("$this.Icon"));
				this.Name = "CompanyForm";
				this.Text = "Company";
				this.tbcMain.ResumeLayout(false);
				this.tabGeneral.ResumeLayout(false);
				this.tabGeneral.PerformLayout();
				((System.ComponentModel.ISupportInitialize) this.ErrorNotify).EndInit();
				((System.ComponentModel.ISupportInitialize) this.Logo).EndInit();
				this.tabContacts.ResumeLayout(false);
				this.gbxPrimaryContact.ResumeLayout(false);
				this.gbxPrimaryContact.PerformLayout();
				this.tabOther.ResumeLayout(false);
				this.tabOther.PerformLayout();
				this.ResumeLayout(false);
				this.PerformLayout();
				
			}
			internal System.Windows.Forms.TabPage tabContacts;
			internal System.Windows.Forms.GroupBox gbxPrimaryContact;
			internal System.Windows.Forms.Label lblPhone2;
			internal System.Windows.Forms.Label lblPhone1;
			internal System.Windows.Forms.TextBox txtCPhone2;
			internal System.Windows.Forms.TextBox txtCPhone1;
			internal System.Windows.Forms.TextBox txtCFirstName;
			internal System.Windows.Forms.TextBox txtCLastName;
			internal System.Windows.Forms.Label lblCLastName;
			internal System.Windows.Forms.Label lblCFirstName;
			internal System.Windows.Forms.Label lblAddress;
			internal System.Windows.Forms.TextBox TextBox1;
			internal System.Windows.Forms.Label lblName;
			internal System.Windows.Forms.TextBox txtName;
			internal System.Windows.Forms.Label lblPhoneList;
			internal System.Windows.Forms.TextBox txtRegistrationNo;
			internal System.Windows.Forms.PictureBox Logo;
			internal System.Windows.Forms.Button btnClearPhoto;
			internal System.Windows.Forms.Button btnChangePhoto;
			internal System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.TextBox TextBox2;
			internal System.Windows.Forms.TabPage tabOther;
			internal System.Windows.Forms.TextBox TextBox4;
			internal System.Windows.Forms.TextBox TextBox3;
			internal System.Windows.Forms.Label Label3;
			internal System.Windows.Forms.Label Label2;
		}
	}
	
	
	
}
