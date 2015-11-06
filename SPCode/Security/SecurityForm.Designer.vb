Namespace Security
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SecurityForm
        Inherits UI.DockableForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SecurityForm))
            Me.SplitContainer = New System.Windows.Forms.SplitContainer
            Me.tvwSecurity = New System.Windows.Forms.TreeView
            Me.splSecurity = New System.Windows.Forms.SplitContainer
            Me.pnlApplication = New System.Windows.Forms.Panel
            Me.lblNote = New System.Windows.Forms.Label
            Me.lblAppName = New System.Windows.Forms.Label
            Me.txtAppNote = New System.Windows.Forms.TextBox
            Me.txtAppName = New System.Windows.Forms.TextBox
            Me.pnlRole = New System.Windows.Forms.Panel
            Me.gbxRoleCreated = New System.Windows.Forms.GroupBox
            Me.Label7 = New System.Windows.Forms.Label
            Me.Label8 = New System.Windows.Forms.Label
            Me.Label9 = New System.Windows.Forms.Label
            Me.Label10 = New System.Windows.Forms.Label
            Me.txtRoleNote = New System.Windows.Forms.TextBox
            Me.lblRoleNote = New System.Windows.Forms.Label
            Me.txtRoleName = New System.Windows.Forms.TextBox
            Me.lblRoleName = New System.Windows.Forms.Label
            Me.pnlUser = New System.Windows.Forms.Panel
            Me.gbxUserCreated = New System.Windows.Forms.GroupBox
            Me.lblModifiedDate = New System.Windows.Forms.Label
            Me.lblUserCreateDate = New System.Windows.Forms.Label
            Me.lblUserModified = New System.Windows.Forms.Label
            Me.Label2 = New System.Windows.Forms.Label
            Me.txtUserCreated = New System.Windows.Forms.Label
            Me.lblUserCreated = New System.Windows.Forms.Label
            Me.txtUserNote = New System.Windows.Forms.TextBox
            Me.lblUserNote = New System.Windows.Forms.Label
            Me.txtLName = New System.Windows.Forms.TextBox
            Me.txtFName = New System.Windows.Forms.TextBox
            Me.lblLName = New System.Windows.Forms.Label
            Me.lblFName = New System.Windows.Forms.Label
            Me.txtUserName = New System.Windows.Forms.TextBox
            Me.lblUserName = New System.Windows.Forms.Label
            Me.tvwPolicy = New System.Windows.Forms.TreeView
            Me.SPApplicationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.SPUserBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.m_dsUserSecurity = New SoftLogik.Win.dsUserSecurity
            Me.TreeNodeImageList = New System.Windows.Forms.ImageList(Me.components)
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer.Panel1.SuspendLayout()
            Me.SplitContainer.Panel2.SuspendLayout()
            Me.SplitContainer.SuspendLayout()
            Me.splSecurity.Panel1.SuspendLayout()
            Me.splSecurity.Panel2.SuspendLayout()
            Me.splSecurity.SuspendLayout()
            Me.pnlApplication.SuspendLayout()
            Me.pnlRole.SuspendLayout()
            Me.gbxRoleCreated.SuspendLayout()
            Me.pnlUser.SuspendLayout()
            Me.gbxUserCreated.SuspendLayout()
            CType(Me.SPApplicationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SPUserBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.m_dsUserSecurity, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'SplitContainer
            '
            Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
            Me.SplitContainer.Name = "SplitContainer"
            '
            'SplitContainer.Panel1
            '
            Me.SplitContainer.Panel1.Controls.Add(Me.tvwSecurity)
            '
            'SplitContainer.Panel2
            '
            Me.SplitContainer.Panel2.Controls.Add(Me.splSecurity)
            Me.SplitContainer.Size = New System.Drawing.Size(858, 449)
            Me.SplitContainer.SplitterDistance = 193
            Me.SplitContainer.TabIndex = 1
            Me.SplitContainer.Text = "SplitContainer1"
            '
            'tvwSecurity
            '
            Me.tvwSecurity.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tvwSecurity.HotTracking = True
            Me.tvwSecurity.Location = New System.Drawing.Point(0, 0)
            Me.tvwSecurity.Name = "tvwSecurity"
            Me.tvwSecurity.ShowLines = False
            Me.tvwSecurity.Size = New System.Drawing.Size(193, 449)
            Me.tvwSecurity.TabIndex = 0
            '
            'splSecurity
            '
            Me.splSecurity.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splSecurity.Location = New System.Drawing.Point(0, 0)
            Me.splSecurity.Name = "splSecurity"
            Me.splSecurity.Orientation = System.Windows.Forms.Orientation.Horizontal
            '
            'splSecurity.Panel1
            '
            Me.splSecurity.Panel1.Controls.Add(Me.pnlApplication)
            Me.splSecurity.Panel1.Controls.Add(Me.pnlRole)
            Me.splSecurity.Panel1.Controls.Add(Me.pnlUser)
            '
            'splSecurity.Panel2
            '
            Me.splSecurity.Panel2.Controls.Add(Me.tvwPolicy)
            Me.splSecurity.Size = New System.Drawing.Size(661, 449)
            Me.splSecurity.SplitterDistance = 241
            Me.splSecurity.TabIndex = 3
            '
            'pnlApplication
            '
            Me.pnlApplication.Controls.Add(Me.lblNote)
            Me.pnlApplication.Controls.Add(Me.lblAppName)
            Me.pnlApplication.Controls.Add(Me.txtAppNote)
            Me.pnlApplication.Controls.Add(Me.txtAppName)
            Me.pnlApplication.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlApplication.Location = New System.Drawing.Point(0, 0)
            Me.pnlApplication.Name = "pnlApplication"
            Me.pnlApplication.Size = New System.Drawing.Size(661, 241)
            Me.pnlApplication.TabIndex = 10
            '
            'lblNote
            '
            Me.lblNote.AutoSize = True
            Me.lblNote.Location = New System.Drawing.Point(37, 86)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(33, 13)
            Me.lblNote.TabIndex = 15
            Me.lblNote.Text = "&Note:"
            '
            'lblAppName
            '
            Me.lblAppName.AutoSize = True
            Me.lblAppName.Location = New System.Drawing.Point(36, 60)
            Me.lblAppName.Name = "lblAppName"
            Me.lblAppName.Size = New System.Drawing.Size(38, 13)
            Me.lblAppName.TabIndex = 14
            Me.lblAppName.Text = "Name:"
            '
            'txtAppNote
            '
            Me.txtAppNote.BackColor = System.Drawing.SystemColors.Control
            Me.txtAppNote.ForeColor = System.Drawing.SystemColors.Highlight
            Me.txtAppNote.Location = New System.Drawing.Point(76, 83)
            Me.txtAppNote.Multiline = True
            Me.txtAppNote.Name = "txtAppNote"
            Me.txtAppNote.ReadOnly = True
            Me.txtAppNote.Size = New System.Drawing.Size(353, 88)
            Me.txtAppNote.TabIndex = 13
            '
            'txtAppName
            '
            Me.txtAppName.BackColor = System.Drawing.SystemColors.Control
            Me.txtAppName.ForeColor = System.Drawing.SystemColors.Highlight
            Me.txtAppName.Location = New System.Drawing.Point(76, 57)
            Me.txtAppName.Name = "txtAppName"
            Me.txtAppName.ReadOnly = True
            Me.txtAppName.Size = New System.Drawing.Size(318, 20)
            Me.txtAppName.TabIndex = 12
            '
            'pnlRole
            '
            Me.pnlRole.Controls.Add(Me.gbxRoleCreated)
            Me.pnlRole.Controls.Add(Me.txtRoleNote)
            Me.pnlRole.Controls.Add(Me.lblRoleNote)
            Me.pnlRole.Controls.Add(Me.txtRoleName)
            Me.pnlRole.Controls.Add(Me.lblRoleName)
            Me.pnlRole.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlRole.Location = New System.Drawing.Point(0, 0)
            Me.pnlRole.Name = "pnlRole"
            Me.pnlRole.Size = New System.Drawing.Size(661, 241)
            Me.pnlRole.TabIndex = 8
            '
            'gbxRoleCreated
            '
            Me.gbxRoleCreated.Controls.Add(Me.Label7)
            Me.gbxRoleCreated.Controls.Add(Me.Label8)
            Me.gbxRoleCreated.Controls.Add(Me.Label9)
            Me.gbxRoleCreated.Controls.Add(Me.Label10)
            Me.gbxRoleCreated.Location = New System.Drawing.Point(405, 7)
            Me.gbxRoleCreated.Name = "gbxRoleCreated"
            Me.gbxRoleCreated.Size = New System.Drawing.Size(189, 180)
            Me.gbxRoleCreated.TabIndex = 22
            Me.gbxRoleCreated.TabStop = False
            Me.gbxRoleCreated.Text = "More Information"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(104, 41)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(0, 13)
            Me.Label7.TabIndex = 13
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(8, 41)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(90, 13)
            Me.Label8.TabIndex = 12
            Me.Label8.Text = "Last Modified On:"
            '
            'Label9
            '
            Me.Label9.AutoSize = True
            Me.Label9.Location = New System.Drawing.Point(79, 16)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(0, 13)
            Me.Label9.TabIndex = 11
            '
            'Label10
            '
            Me.Label10.AutoSize = True
            Me.Label10.Location = New System.Drawing.Point(6, 16)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(67, 13)
            Me.Label10.TabIndex = 10
            Me.Label10.Text = "Created On: "
            '
            'txtRoleNote
            '
            Me.txtRoleNote.Location = New System.Drawing.Point(67, 45)
            Me.txtRoleNote.Multiline = True
            Me.txtRoleNote.Name = "txtRoleNote"
            Me.txtRoleNote.Size = New System.Drawing.Size(327, 99)
            Me.txtRoleNote.TabIndex = 21
            '
            'lblRoleNote
            '
            Me.lblRoleNote.AutoSize = True
            Me.lblRoleNote.Location = New System.Drawing.Point(11, 48)
            Me.lblRoleNote.Name = "lblRoleNote"
            Me.lblRoleNote.Size = New System.Drawing.Size(33, 13)
            Me.lblRoleNote.TabIndex = 20
            Me.lblRoleNote.Text = "&Note:"
            '
            'txtRoleName
            '
            Me.txtRoleName.Location = New System.Drawing.Point(67, 19)
            Me.txtRoleName.Name = "txtRoleName"
            Me.txtRoleName.Size = New System.Drawing.Size(291, 20)
            Me.txtRoleName.TabIndex = 19
            '
            'lblRoleName
            '
            Me.lblRoleName.AutoSize = True
            Me.lblRoleName.Location = New System.Drawing.Point(11, 22)
            Me.lblRoleName.Name = "lblRoleName"
            Me.lblRoleName.Size = New System.Drawing.Size(38, 13)
            Me.lblRoleName.TabIndex = 18
            Me.lblRoleName.Text = "Name:"
            '
            'pnlUser
            '
            Me.pnlUser.Controls.Add(Me.gbxUserCreated)
            Me.pnlUser.Controls.Add(Me.txtUserNote)
            Me.pnlUser.Controls.Add(Me.lblUserNote)
            Me.pnlUser.Controls.Add(Me.txtLName)
            Me.pnlUser.Controls.Add(Me.txtFName)
            Me.pnlUser.Controls.Add(Me.lblLName)
            Me.pnlUser.Controls.Add(Me.lblFName)
            Me.pnlUser.Controls.Add(Me.txtUserName)
            Me.pnlUser.Controls.Add(Me.lblUserName)
            Me.pnlUser.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlUser.Location = New System.Drawing.Point(0, 0)
            Me.pnlUser.Name = "pnlUser"
            Me.pnlUser.Size = New System.Drawing.Size(661, 241)
            Me.pnlUser.TabIndex = 9
            '
            'gbxUserCreated
            '
            Me.gbxUserCreated.Controls.Add(Me.lblModifiedDate)
            Me.gbxUserCreated.Controls.Add(Me.lblUserCreateDate)
            Me.gbxUserCreated.Controls.Add(Me.lblUserModified)
            Me.gbxUserCreated.Controls.Add(Me.Label2)
            Me.gbxUserCreated.Controls.Add(Me.txtUserCreated)
            Me.gbxUserCreated.Controls.Add(Me.lblUserCreated)
            Me.gbxUserCreated.Location = New System.Drawing.Point(401, 3)
            Me.gbxUserCreated.Name = "gbxUserCreated"
            Me.gbxUserCreated.Size = New System.Drawing.Size(188, 180)
            Me.gbxUserCreated.TabIndex = 21
            Me.gbxUserCreated.TabStop = False
            Me.gbxUserCreated.Text = "More Information"
            '
            'lblModifiedDate
            '
            Me.lblModifiedDate.AutoSize = True
            Me.lblModifiedDate.Location = New System.Drawing.Point(94, 41)
            Me.lblModifiedDate.Name = "lblModifiedDate"
            Me.lblModifiedDate.Size = New System.Drawing.Size(42, 13)
            Me.lblModifiedDate.TabIndex = 15
            Me.lblModifiedDate.Text = "<Date>"
            '
            'lblUserCreateDate
            '
            Me.lblUserCreateDate.AutoSize = True
            Me.lblUserCreateDate.Location = New System.Drawing.Point(80, 16)
            Me.lblUserCreateDate.Name = "lblUserCreateDate"
            Me.lblUserCreateDate.Size = New System.Drawing.Size(42, 13)
            Me.lblUserCreateDate.TabIndex = 14
            Me.lblUserCreateDate.Text = "<Date>"
            '
            'lblUserModified
            '
            Me.lblUserModified.AutoSize = True
            Me.lblUserModified.Location = New System.Drawing.Point(104, 41)
            Me.lblUserModified.Name = "lblUserModified"
            Me.lblUserModified.Size = New System.Drawing.Size(0, 13)
            Me.lblUserModified.TabIndex = 13
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(8, 41)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(90, 13)
            Me.Label2.TabIndex = 12
            Me.Label2.Text = "Last Modified On:"
            '
            'txtUserCreated
            '
            Me.txtUserCreated.AutoSize = True
            Me.txtUserCreated.Location = New System.Drawing.Point(79, 16)
            Me.txtUserCreated.Name = "txtUserCreated"
            Me.txtUserCreated.Size = New System.Drawing.Size(0, 13)
            Me.txtUserCreated.TabIndex = 11
            '
            'lblUserCreated
            '
            Me.lblUserCreated.AutoSize = True
            Me.lblUserCreated.Location = New System.Drawing.Point(6, 16)
            Me.lblUserCreated.Name = "lblUserCreated"
            Me.lblUserCreated.Size = New System.Drawing.Size(67, 13)
            Me.lblUserCreated.TabIndex = 10
            Me.lblUserCreated.Text = "Created On: "
            '
            'txtUserNote
            '
            Me.txtUserNote.Location = New System.Drawing.Point(76, 84)
            Me.txtUserNote.Multiline = True
            Me.txtUserNote.Name = "txtUserNote"
            Me.txtUserNote.Size = New System.Drawing.Size(319, 99)
            Me.txtUserNote.TabIndex = 20
            '
            'lblUserNote
            '
            Me.lblUserNote.AutoSize = True
            Me.lblUserNote.Location = New System.Drawing.Point(9, 84)
            Me.lblUserNote.Name = "lblUserNote"
            Me.lblUserNote.Size = New System.Drawing.Size(33, 13)
            Me.lblUserNote.TabIndex = 19
            Me.lblUserNote.Text = "&Note:"
            '
            'txtLName
            '
            Me.txtLName.Location = New System.Drawing.Point(76, 60)
            Me.txtLName.Name = "txtLName"
            Me.txtLName.Size = New System.Drawing.Size(319, 20)
            Me.txtLName.TabIndex = 18
            '
            'txtFName
            '
            Me.txtFName.Location = New System.Drawing.Point(76, 35)
            Me.txtFName.Name = "txtFName"
            Me.txtFName.Size = New System.Drawing.Size(319, 20)
            Me.txtFName.TabIndex = 17
            '
            'lblLName
            '
            Me.lblLName.AutoSize = True
            Me.lblLName.Location = New System.Drawing.Point(9, 60)
            Me.lblLName.Name = "lblLName"
            Me.lblLName.Size = New System.Drawing.Size(61, 13)
            Me.lblLName.TabIndex = 16
            Me.lblLName.Text = "Last Name:"
            '
            'lblFName
            '
            Me.lblFName.AutoSize = True
            Me.lblFName.Location = New System.Drawing.Point(7, 35)
            Me.lblFName.Name = "lblFName"
            Me.lblFName.Size = New System.Drawing.Size(60, 13)
            Me.lblFName.TabIndex = 15
            Me.lblFName.Text = "First Name:"
            '
            'txtUserName
            '
            Me.txtUserName.Location = New System.Drawing.Point(76, 11)
            Me.txtUserName.Name = "txtUserName"
            Me.txtUserName.Size = New System.Drawing.Size(319, 20)
            Me.txtUserName.TabIndex = 14
            '
            'lblUserName
            '
            Me.lblUserName.AutoSize = True
            Me.lblUserName.Location = New System.Drawing.Point(7, 14)
            Me.lblUserName.Name = "lblUserName"
            Me.lblUserName.Size = New System.Drawing.Size(63, 13)
            Me.lblUserName.TabIndex = 13
            Me.lblUserName.Text = "User Name:"
            '
            'tvwPolicy
            '
            Me.tvwPolicy.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tvwPolicy.Location = New System.Drawing.Point(0, 0)
            Me.tvwPolicy.Name = "tvwPolicy"
            Me.tvwPolicy.Size = New System.Drawing.Size(661, 204)
            Me.tvwPolicy.TabIndex = 0
            '
            'SPApplicationBindingSource
            '
            Me.SPApplicationBindingSource.DataMember = "SPApplication"
            '
            'SPUserBindingSource
            '
            Me.SPUserBindingSource.DataMember = "SPUser"
            '
            'm_dsUserSecurity
            '
            Me.m_dsUserSecurity.DataSetName = "dsUserSecurity"
            Me.m_dsUserSecurity.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'TreeNodeImageList
            '
            Me.TreeNodeImageList.ImageStream = CType(resources.GetObject("TreeNodeImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.TreeNodeImageList.TransparentColor = System.Drawing.Color.Transparent
            Me.TreeNodeImageList.Images.SetKeyName(0, "ApplicationNode")
            Me.TreeNodeImageList.Images.SetKeyName(1, "UserNode")
            Me.TreeNodeImageList.Images.SetKeyName(2, "RoleNode")
            Me.TreeNodeImageList.Images.SetKeyName(3, "RootNode")
            Me.TreeNodeImageList.Images.SetKeyName(4, "EditNode")
            '
            'SecurityManager
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(858, 449)
            Me.Controls.Add(Me.SplitContainer)
            Me.Name = "SecurityManager"
            Me.Text = "SecurityManager"
            CType(Me.ErrorNotify, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer.Panel1.ResumeLayout(False)
            Me.SplitContainer.Panel2.ResumeLayout(False)
            Me.SplitContainer.ResumeLayout(False)
            Me.splSecurity.Panel1.ResumeLayout(False)
            Me.splSecurity.Panel2.ResumeLayout(False)
            Me.splSecurity.ResumeLayout(False)
            Me.pnlApplication.ResumeLayout(False)
            Me.pnlApplication.PerformLayout()
            Me.pnlRole.ResumeLayout(False)
            Me.pnlRole.PerformLayout()
            Me.gbxRoleCreated.ResumeLayout(False)
            Me.gbxRoleCreated.PerformLayout()
            Me.pnlUser.ResumeLayout(False)
            Me.pnlUser.PerformLayout()
            Me.gbxUserCreated.ResumeLayout(False)
            Me.gbxUserCreated.PerformLayout()
            CType(Me.SPApplicationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SPUserBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.m_dsUserSecurity, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
        Friend WithEvents tvwSecurity As System.Windows.Forms.TreeView
        Friend WithEvents splSecurity As System.Windows.Forms.SplitContainer
        Friend WithEvents pnlApplication As System.Windows.Forms.Panel
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents lblAppName As System.Windows.Forms.Label
        Friend WithEvents txtAppNote As System.Windows.Forms.TextBox
        Friend WithEvents txtAppName As System.Windows.Forms.TextBox
        Friend WithEvents pnlRole As System.Windows.Forms.Panel
        Friend WithEvents gbxRoleCreated As System.Windows.Forms.GroupBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents txtRoleNote As System.Windows.Forms.TextBox
        Friend WithEvents lblRoleNote As System.Windows.Forms.Label
        Friend WithEvents txtRoleName As System.Windows.Forms.TextBox
        Friend WithEvents lblRoleName As System.Windows.Forms.Label
        Friend WithEvents pnlUser As System.Windows.Forms.Panel
        Friend WithEvents gbxUserCreated As System.Windows.Forms.GroupBox
        Friend WithEvents lblModifiedDate As System.Windows.Forms.Label
        Friend WithEvents lblUserCreateDate As System.Windows.Forms.Label
        Friend WithEvents lblUserModified As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtUserCreated As System.Windows.Forms.Label
        Friend WithEvents lblUserCreated As System.Windows.Forms.Label
        Friend WithEvents txtUserNote As System.Windows.Forms.TextBox
        Friend WithEvents lblUserNote As System.Windows.Forms.Label
        Friend WithEvents txtLName As System.Windows.Forms.TextBox
        Friend WithEvents txtFName As System.Windows.Forms.TextBox
        Friend WithEvents lblLName As System.Windows.Forms.Label
        Friend WithEvents lblFName As System.Windows.Forms.Label
        Friend WithEvents txtUserName As System.Windows.Forms.TextBox
        Friend WithEvents lblUserName As System.Windows.Forms.Label
        Friend WithEvents tvwPolicy As System.Windows.Forms.TreeView
        Friend WithEvents SPApplicationBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents SPUserBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents m_dsUserSecurity As SoftLogik.Win.dsUserSecurity
        Friend WithEvents TreeNodeImageList As System.Windows.Forms.ImageList
    End Class
End Namespace

