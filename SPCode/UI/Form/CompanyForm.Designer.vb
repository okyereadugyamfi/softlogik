
Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CompanyForm
        Inherits SetupForm
        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CompanyForm))
            Me.lblAddress = New System.Windows.Forms.Label
            Me.TextBox1 = New System.Windows.Forms.TextBox
            Me.lblName = New System.Windows.Forms.Label
            Me.txtName = New System.Windows.Forms.TextBox
            Me.lblPhoneList = New System.Windows.Forms.Label
            Me.txtRegistrationNo = New System.Windows.Forms.TextBox
            Me.Logo = New System.Windows.Forms.PictureBox
            Me.tabContacts = New System.Windows.Forms.TabPage
            Me.gbxPrimaryContact = New System.Windows.Forms.GroupBox
            Me.lblPhone2 = New System.Windows.Forms.Label
            Me.lblPhone1 = New System.Windows.Forms.Label
            Me.txtCPhone2 = New System.Windows.Forms.TextBox
            Me.txtCPhone1 = New System.Windows.Forms.TextBox
            Me.txtCFirstName = New System.Windows.Forms.TextBox
            Me.txtCLastName = New System.Windows.Forms.TextBox
            Me.lblCLastName = New System.Windows.Forms.Label
            Me.lblCFirstName = New System.Windows.Forms.Label
            Me.btnChangePhoto = New System.Windows.Forms.Button
            Me.btnClearPhoto = New System.Windows.Forms.Button
            Me.TextBox2 = New System.Windows.Forms.TextBox
            Me.Label1 = New System.Windows.Forms.Label
            Me.tabOther = New System.Windows.Forms.TabPage
            Me.Label3 = New System.Windows.Forms.Label
            Me.Label2 = New System.Windows.Forms.Label
            Me.TextBox4 = New System.Windows.Forms.TextBox
            Me.TextBox3 = New System.Windows.Forms.TextBox
            Me.tbcMain.SuspendLayout()
            Me.tabGeneral.SuspendLayout()
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tabContacts.SuspendLayout()
            Me.gbxPrimaryContact.SuspendLayout()
            Me.tabOther.SuspendLayout()
            Me.SuspendLayout()
            '
            'tvwName
            '
            Me.tvwName.LineColor = System.Drawing.Color.Black
            Me.tvwName.Size = New System.Drawing.Size(215, 381)
            Me.tvwName.TabIndex = 3
            '
            'tbcMain
            '
            Me.tbcMain.Controls.Add(Me.tabContacts)
            Me.tbcMain.Controls.Add(Me.tabOther)
            Me.tbcMain.Size = New System.Drawing.Size(434, 381)
            Me.tbcMain.TabIndex = 5
            Me.tbcMain.Controls.SetChildIndex(Me.tabOther, 0)
            Me.tbcMain.Controls.SetChildIndex(Me.tabGeneral, 0)
            Me.tbcMain.Controls.SetChildIndex(Me.tabContacts, 0)
            '
            'tabGeneral
            '
            Me.tabGeneral.Controls.Add(Me.Label1)
            Me.tabGeneral.Controls.Add(Me.TextBox2)
            Me.tabGeneral.Controls.Add(Me.btnClearPhoto)
            Me.tabGeneral.Controls.Add(Me.btnChangePhoto)
            Me.tabGeneral.Controls.Add(Me.lblAddress)
            Me.tabGeneral.Controls.Add(Me.TextBox1)
            Me.tabGeneral.Controls.Add(Me.lblName)
            Me.tabGeneral.Controls.Add(Me.txtName)
            Me.tabGeneral.Controls.Add(Me.lblPhoneList)
            Me.tabGeneral.Controls.Add(Me.txtRegistrationNo)
            Me.tabGeneral.Controls.Add(Me.Logo)
            Me.tabGeneral.Size = New System.Drawing.Size(426, 358)
            Me.tabGeneral.TabIndex = 6
            '
            'IconSource
            '
            Me.IconSource.ImageStream = CType(resources.GetObject("IconSource.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.IconSource.Images.SetKeyName(0, "wi0111-48.gif")
            '
            'lblAddress
            '
            Me.lblAddress.AutoSize = True
            Me.lblAddress.Location = New System.Drawing.Point(7, 85)
            Me.lblAddress.Name = "lblAddress"
            Me.lblAddress.Size = New System.Drawing.Size(57, 13)
            Me.lblAddress.TabIndex = 21
            Me.lblAddress.Text = "Address 1:"
            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(89, 82)
            Me.TextBox1.Multiline = True
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBox1.Size = New System.Drawing.Size(172, 69)
            Me.TextBox1.TabIndex = 20
            Me.TextBox1.Tag = "Address1"
            '
            'lblName
            '
            Me.lblName.AutoSize = True
            Me.lblName.Location = New System.Drawing.Point(7, 33)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(38, 13)
            Me.lblName.TabIndex = 19
            Me.lblName.Text = "&Name:"
            '
            'txtName
            '
            Me.txtName.Location = New System.Drawing.Point(89, 30)
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(172, 20)
            Me.txtName.TabIndex = 18
            Me.txtName.Tag = "Name"
            '
            'lblPhoneList
            '
            Me.lblPhoneList.AutoSize = True
            Me.lblPhoneList.Location = New System.Drawing.Point(7, 59)
            Me.lblPhoneList.Name = "lblPhoneList"
            Me.lblPhoneList.Size = New System.Drawing.Size(52, 13)
            Me.lblPhoneList.TabIndex = 17
            Me.lblPhoneList.Text = "Phone(s):"
            '
            'txtRegistrationNo
            '
            Me.txtRegistrationNo.Location = New System.Drawing.Point(89, 56)
            Me.txtRegistrationNo.Name = "txtRegistrationNo"
            Me.txtRegistrationNo.Size = New System.Drawing.Size(172, 20)
            Me.txtRegistrationNo.TabIndex = 16
            Me.txtRegistrationNo.Tag = "PhoneList"
            '
            'Logo
            '
            Me.Logo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Logo.Location = New System.Drawing.Point(283, 30)
            Me.Logo.Name = "Logo"
            Me.Logo.Size = New System.Drawing.Size(136, 120)
            Me.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.Logo.TabIndex = 15
            Me.Logo.TabStop = False
            Me.Logo.Tag = "Logo"
            '
            'tabContacts
            '
            Me.tabContacts.Controls.Add(Me.gbxPrimaryContact)
            Me.tabContacts.Location = New System.Drawing.Point(4, 19)
            Me.tabContacts.Name = "tabContacts"
            Me.tabContacts.Padding = New System.Windows.Forms.Padding(3)
            Me.tabContacts.Size = New System.Drawing.Size(426, 358)
            Me.tabContacts.TabIndex = 2
            Me.tabContacts.Text = "Contacts"
            Me.tabContacts.UseVisualStyleBackColor = True
            '
            'gbxPrimaryContact
            '
            Me.gbxPrimaryContact.Controls.Add(Me.lblPhone2)
            Me.gbxPrimaryContact.Controls.Add(Me.lblPhone1)
            Me.gbxPrimaryContact.Controls.Add(Me.txtCPhone2)
            Me.gbxPrimaryContact.Controls.Add(Me.txtCPhone1)
            Me.gbxPrimaryContact.Controls.Add(Me.txtCFirstName)
            Me.gbxPrimaryContact.Controls.Add(Me.txtCLastName)
            Me.gbxPrimaryContact.Controls.Add(Me.lblCLastName)
            Me.gbxPrimaryContact.Controls.Add(Me.lblCFirstName)
            Me.gbxPrimaryContact.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gbxPrimaryContact.Location = New System.Drawing.Point(3, 3)
            Me.gbxPrimaryContact.Name = "gbxPrimaryContact"
            Me.gbxPrimaryContact.Size = New System.Drawing.Size(420, 352)
            Me.gbxPrimaryContact.TabIndex = 15
            Me.gbxPrimaryContact.TabStop = False
            Me.gbxPrimaryContact.Text = "Primary Contact"
            '
            'lblPhone2
            '
            Me.lblPhone2.AutoSize = True
            Me.lblPhone2.Location = New System.Drawing.Point(19, 108)
            Me.lblPhone2.Name = "lblPhone2"
            Me.lblPhone2.Size = New System.Drawing.Size(72, 13)
            Me.lblPhone2.TabIndex = 7
            Me.lblPhone2.Text = "2nd Phone #:"
            '
            'lblPhone1
            '
            Me.lblPhone1.AutoSize = True
            Me.lblPhone1.Location = New System.Drawing.Point(19, 82)
            Me.lblPhone1.Name = "lblPhone1"
            Me.lblPhone1.Size = New System.Drawing.Size(68, 13)
            Me.lblPhone1.TabIndex = 6
            Me.lblPhone1.Text = "1st Phone #:"
            '
            'txtCPhone2
            '
            Me.txtCPhone2.Location = New System.Drawing.Point(93, 105)
            Me.txtCPhone2.Name = "txtCPhone2"
            Me.txtCPhone2.Size = New System.Drawing.Size(215, 20)
            Me.txtCPhone2.TabIndex = 5
            '
            'txtCPhone1
            '
            Me.txtCPhone1.Location = New System.Drawing.Point(93, 79)
            Me.txtCPhone1.Name = "txtCPhone1"
            Me.txtCPhone1.Size = New System.Drawing.Size(215, 20)
            Me.txtCPhone1.TabIndex = 4
            '
            'txtCFirstName
            '
            Me.txtCFirstName.Location = New System.Drawing.Point(93, 31)
            Me.txtCFirstName.Name = "txtCFirstName"
            Me.txtCFirstName.Size = New System.Drawing.Size(215, 20)
            Me.txtCFirstName.TabIndex = 3
            '
            'txtCLastName
            '
            Me.txtCLastName.Location = New System.Drawing.Point(93, 53)
            Me.txtCLastName.Name = "txtCLastName"
            Me.txtCLastName.Size = New System.Drawing.Size(215, 20)
            Me.txtCLastName.TabIndex = 2
            '
            'lblCLastName
            '
            Me.lblCLastName.AutoSize = True
            Me.lblCLastName.Location = New System.Drawing.Point(19, 56)
            Me.lblCLastName.Name = "lblCLastName"
            Me.lblCLastName.Size = New System.Drawing.Size(61, 13)
            Me.lblCLastName.TabIndex = 1
            Me.lblCLastName.Text = "&Last Name:"
            '
            'lblCFirstName
            '
            Me.lblCFirstName.AutoSize = True
            Me.lblCFirstName.Location = New System.Drawing.Point(19, 34)
            Me.lblCFirstName.Name = "lblCFirstName"
            Me.lblCFirstName.Size = New System.Drawing.Size(60, 13)
            Me.lblCFirstName.TabIndex = 0
            Me.lblCFirstName.Text = "&First Name:"
            '
            'btnChangePhoto
            '
            Me.btnChangePhoto.Location = New System.Drawing.Point(283, 156)
            Me.btnChangePhoto.Name = "btnChangePhoto"
            Me.btnChangePhoto.Size = New System.Drawing.Size(75, 23)
            Me.btnChangePhoto.TabIndex = 22
            Me.btnChangePhoto.Text = "&Change"
            Me.btnChangePhoto.UseVisualStyleBackColor = True
            '
            'btnClearPhoto
            '
            Me.btnClearPhoto.Location = New System.Drawing.Point(364, 156)
            Me.btnClearPhoto.Name = "btnClearPhoto"
            Me.btnClearPhoto.Size = New System.Drawing.Size(50, 23)
            Me.btnClearPhoto.TabIndex = 23
            Me.btnClearPhoto.Text = "Clear"
            Me.btnClearPhoto.UseVisualStyleBackColor = True
            '
            'TextBox2
            '
            Me.TextBox2.Location = New System.Drawing.Point(89, 158)
            Me.TextBox2.Multiline = True
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBox2.Size = New System.Drawing.Size(172, 69)
            Me.TextBox2.TabIndex = 24
            Me.TextBox2.Tag = "Address2"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(7, 161)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(57, 13)
            Me.Label1.TabIndex = 25
            Me.Label1.Text = "Address 2:"
            '
            'tabOther
            '
            Me.tabOther.Controls.Add(Me.Label3)
            Me.tabOther.Controls.Add(Me.Label2)
            Me.tabOther.Controls.Add(Me.TextBox4)
            Me.tabOther.Controls.Add(Me.TextBox3)
            Me.tabOther.Location = New System.Drawing.Point(4, 19)
            Me.tabOther.Name = "tabOther"
            Me.tabOther.Padding = New System.Windows.Forms.Padding(3)
            Me.tabOther.Size = New System.Drawing.Size(426, 358)
            Me.tabOther.TabIndex = 7
            Me.tabOther.Text = "Other"
            Me.tabOther.UseVisualStyleBackColor = True
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(7, 103)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(76, 13)
            Me.Label3.TabIndex = 30
            Me.Label3.Text = "Note(Reports):"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(7, 32)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(37, 13)
            Me.Label2.TabIndex = 29
            Me.Label2.Text = "Motto:"
            '
            'TextBox4
            '
            Me.TextBox4.Location = New System.Drawing.Point(91, 100)
            Me.TextBox4.Multiline = True
            Me.TextBox4.Name = "TextBox4"
            Me.TextBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBox4.Size = New System.Drawing.Size(311, 190)
            Me.TextBox4.TabIndex = 28
            Me.TextBox4.Tag = "CustomNote"
            '
            'TextBox3
            '
            Me.TextBox3.Location = New System.Drawing.Point(91, 32)
            Me.TextBox3.Multiline = True
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.TextBox3.Size = New System.Drawing.Size(311, 51)
            Me.TextBox3.TabIndex = 27
            Me.TextBox3.Tag = "Motto"
            '
            'CompanyForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(653, 406)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CompanyForm"
            Me.Text = "Company"
            Me.tbcMain.ResumeLayout(False)
            Me.tabGeneral.ResumeLayout(False)
            Me.tabGeneral.PerformLayout()
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tabContacts.ResumeLayout(False)
            Me.gbxPrimaryContact.ResumeLayout(False)
            Me.gbxPrimaryContact.PerformLayout()
            Me.tabOther.ResumeLayout(False)
            Me.tabOther.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents tabContacts As System.Windows.Forms.TabPage
        Friend WithEvents gbxPrimaryContact As System.Windows.Forms.GroupBox
        Friend WithEvents lblPhone2 As System.Windows.Forms.Label
        Friend WithEvents lblPhone1 As System.Windows.Forms.Label
        Friend WithEvents txtCPhone2 As System.Windows.Forms.TextBox
        Friend WithEvents txtCPhone1 As System.Windows.Forms.TextBox
        Friend WithEvents txtCFirstName As System.Windows.Forms.TextBox
        Friend WithEvents txtCLastName As System.Windows.Forms.TextBox
        Friend WithEvents lblCLastName As System.Windows.Forms.Label
        Friend WithEvents lblCFirstName As System.Windows.Forms.Label
        Friend WithEvents lblAddress As System.Windows.Forms.Label
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblPhoneList As System.Windows.Forms.Label
        Friend WithEvents txtRegistrationNo As System.Windows.Forms.TextBox
        Friend WithEvents Logo As System.Windows.Forms.PictureBox
        Friend WithEvents btnClearPhoto As System.Windows.Forms.Button
        Friend WithEvents btnChangePhoto As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
        Friend WithEvents tabOther As System.Windows.Forms.TabPage
        Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
    End Class
End Namespace


