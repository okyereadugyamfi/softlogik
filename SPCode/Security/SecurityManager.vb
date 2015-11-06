Imports SoftLogik.Win.Data
Imports SoftLogik.Win.Security
Imports SoftLogik.Win.UI


Namespace Security
    Public Class SecurityManager
        Implements IDisposable

        Public Sub New(ByVal ActiveDockPanel As DockPanel)
            m_dockPanel = ActiveDockPanel
        End Sub

        Private m_objUser As SecureUser
        Private m_objUserList As List(Of SecureUser)
        Private m_frmManager As SecurityForm
        Private m_frmLoginWnd As LoginForm
        Private m_dockPanel As DockPanel


        Private ReadOnly Property ManagerWnd() As SecurityForm
            Get
                If IsNothing(m_frmManager) Then
                    m_frmManager = New SecurityForm
                    m_frmManager.DockPanel = m_dockPanel
                ElseIf m_frmManager.IsDisposed Then
                    m_frmManager.Dispose()
                    m_frmManager = Nothing
                    m_frmManager = New SecurityForm
                    m_frmManager.DockPanel = m_dockPanel
                End If

                Return m_frmManager
            End Get
        End Property
        Private ReadOnly Property LoginWnd() As LoginForm
            Get
                If IsNothing(m_frmLoginWnd) Then
                    m_frmLoginWnd = New LoginForm
                ElseIf m_frmLoginWnd.IsDisposed Then
                    m_frmLoginWnd.Dispose()
                    m_frmLoginWnd = Nothing
                    m_frmLoginWnd = New LoginForm
                End If


                Return m_frmLoginWnd
            End Get
        End Property


        Public ReadOnly Property MyUser() As SecureUser
            Get
                Return m_objUser
            End Get
        End Property



        ''' <summary>
        ''' MDI Parent, sets or returns the MDI Parent of this Form
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MdiParent() As Form
            Get
                Return ManagerWnd.MdiParent
            End Get
            Set(ByVal value As Form)
                ManagerWnd.MdiParent = value
            End Set
        End Property

        Public Sub ShowManager()
            ManagerWnd.Show()
        End Sub

        Public Sub ShowLogin()
            LoginWnd.ShowDialog()
        End Sub

        Public Sub ShowPassword()

        End Sub

        Public ReadOnly Property UserList() As Collections.Generic.List(Of SecureUser)
            Get
                Return m_objUserList
            End Get
        End Property

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free unmanaged resources when explicitly called
                    m_frmManager.Close()
                    m_frmManager.Dispose()
                End If

                ' TODO: free shared unmanaged resources
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Public Class SecureUser

#Region "Private Variables"
        Private m_strName As String
        Private m_strPassword As String
        Private m_objPolicies As List(Of SPPolicy)
#End Region

        Public Sub New(ByVal Name As String)
            m_strName = Name
        End Sub
        Public Sub New(ByVal Name As String, ByVal Password As String)
            m_strName = Name
            m_strPassword = Password
        End Sub
        Public Sub New(ByVal Name As String, ByVal Password As String, ByVal Policies As List(Of SPPolicy))
            m_strName = Name
            m_strPassword = Password
            m_objPolicies = Policies
        End Sub
        Public Sub New(ByVal Policies As List(Of SPPolicy))

            m_objPolicies = Policies
        End Sub

        Public Property Name() As String
            Get
                Return m_strName
            End Get
            Set(ByVal value As String)
                m_strName = value
            End Set
        End Property
        Public Property Password() As String
            Get
                Return m_strPassword
            End Get
            Set(ByVal value As String)
                m_strPassword = value
            End Set
        End Property
        Public ReadOnly Property Policies() As System.Collections.Generic.List(Of SPPolicy)
            Get
                Return m_objPolicies
            End Get
        End Property

    End Class
    Public Class SPCompany
        Implements IDisposable

        Private m_strName As String
        Private m_frmCompany As CompanyForm

        Private ReadOnly Property CompanyWnd() As CompanyForm
            Get
                If IsNothing(m_frmCompany) Then
                    m_frmCompany = New CompanyForm
                ElseIf m_frmCompany.IsDisposed Then
                    m_frmCompany.Dispose()
                    m_frmCompany = Nothing
                    m_frmCompany = New CompanyForm
                End If

                Return m_frmCompany
            End Get
        End Property
        Public Property Name() As String
            Get
                Return m_strName
            End Get
            Set(ByVal value As String)
                m_strName = value
            End Set
        End Property

        ''' <summary>
        ''' MDI Parent, sets or returns the MDI Parent of this Form
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property MdiParent() As Form
            Get
                Return CompanyWnd.MdiParent
            End Get
            Set(ByVal value As Form)
                CompanyWnd.MdiParent = value
            End Set
        End Property

        Public Sub ShowManager()
            CompanyWnd.Show()
        End Sub

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free unmanaged resources when explicitly called
                End If

                ' TODO: free shared unmanaged resources
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

    Module SecuritySupport

        Public Sub BuildSecurity(ByVal SourceTree As TreeView, ByVal SourceData As dsUserSecurity, Optional ByVal ClearTree As Boolean = True)


            Dim dvTreeTable As dsUserSecurity.SPApplicationDataTable, rootNode As TreeNode, _
            applicationNode As TreeNode

            dvTreeTable = SourceData.SPApplication

            If ClearTree = False Then 'Might be a root node
                rootNode = SourceTree.Nodes(0)
            Else
                SourceTree.Nodes.Clear()
                'rootNode = SourceTree.Nodes.Add(TextDictionary("FL_SECURITY"))
                rootNode = SourceTree.Nodes.Add("Security Explorer")
            End If


            SourceTree.BeginUpdate()
            For Each drvRow As dsUserSecurity.SPApplicationRow In dvTreeTable
                Try
                    applicationNode = rootNode.Nodes.Add(drvRow("Name").ToString)
                    Call BuildRoleNode(applicationNode, drvRow)
                    applicationNode.Expand()
                    applicationNode.ImageKey = "ApplicationNode"
                    applicationNode.Tag = "A:" & drvRow("ApplicationID").ToString
                Catch ex As Exception
                End Try
            Next

            rootNode.Expand()
            SourceTree.EndUpdate()
            Cursor.Current = Cursors.Default
        End Sub

        Private Sub BuildRoleNode(ByRef currentNode As TreeNode, ByRef sourceData As dsUserSecurity.SPApplicationRow)
            Dim newRoleNode As TreeNode
            Dim userRoleRows() As dsUserSecurity.SPUserRoleRow = _
            CType(sourceData.GetChildRows("SPApplicationUserRole_FK"),  _
            dsUserSecurity.SPUserRoleRow())

            currentNode.TreeView.BeginUpdate()

            For Each drvRow As dsUserSecurity.SPUserRoleRow In userRoleRows
                Try
                    Dim tempNode As TreeNode = currentNode.Nodes(drvRow.SPRoleRow.RoleName)

                    If IsNothing(tempNode) Then
                        newRoleNode = currentNode.Nodes.Add(drvRow.SPRoleRow.RoleName)
                        newRoleNode.Name = drvRow.SPRoleRow.RoleName
                        newRoleNode.ImageKey = "RoleNode"
                        newRoleNode.Tag = "R:" & drvRow.RoleID.ToString

                        newRoleNode.NodeFont = New Font(currentNode.TreeView.Font, FontStyle.Bold)

                        Call BuildUserNode(newRoleNode, drvRow.SPRoleRow)
                    End If
                Catch ex As Exception
                End Try
            Next

            newRoleNode = Nothing
            currentNode.TreeView.EndUpdate()
        End Sub

        Private Sub BuildUserNode(ByRef currentNode As TreeNode, ByRef sourceData As dsUserSecurity.SPRoleRow)
            Dim newUsers() As dsUserSecurity.SPUserRoleRow = _
            CType(sourceData.GetChildRows("SPRoleUserRole_Fk"), dsUserSecurity.SPUserRoleRow())
            Dim newUserNode As TreeNode

            For Each drvRow As dsUserSecurity.SPUserRoleRow In newUsers
                Try
                    Dim tempNode As TreeNode = currentNode.Nodes(drvRow.SPUserRow("UserName").ToString)

                    If IsNothing(tempNode) Then
                        newUserNode = currentNode.Nodes.Add(drvRow.SPUserRow("UserName").ToString)
                        newUserNode.Name = drvRow.SPUserRow("UserName").ToString
                        newUserNode.ImageKey = "UserNode"
                        newUserNode.Tag = "U:" & drvRow.SPUserRow("UserID").ToString
                    End If
                Catch ex As Exception

                End Try
            Next

            newUserNode = Nothing
        End Sub

    End Module
End Namespace








