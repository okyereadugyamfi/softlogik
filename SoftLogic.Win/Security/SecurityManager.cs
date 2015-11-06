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
using SoftLogik.Win.Data;
using SoftLogik.Win.Security;
using SoftLogik.Win.UI;



namespace SoftLogik.Win
{
	namespace Security
	{
		public class SecurityManager : IDisposable
		{
			
			
			public SecurityManager(DockPanel ActiveDockPanel)
			{
				m_dockPanel = ActiveDockPanel;
			}
			
			private SecureUser m_objUser;
			private List<SecureUser> m_objUserList;
			private SecurityForm m_frmManager;
			private LoginForm m_frmLoginWnd;
			private DockPanel m_dockPanel;
			
			private SecurityForm ManagerWnd
			{
				get
				{
					if (m_frmManager == null)
					{
						m_frmManager = new SecurityForm();
						m_frmManager.DockPanel = m_dockPanel;
					}
					else if (m_frmManager.IsDisposed)
					{
						m_frmManager.Dispose();
						m_frmManager = null;
						m_frmManager = new SecurityForm();
						m_frmManager.DockPanel = m_dockPanel;
					}
					
					return m_frmManager;
				}
			}
			private LoginForm LoginWnd
			{
				get
				{
					if (m_frmLoginWnd == null)
					{
						m_frmLoginWnd = new LoginForm();
					}
					else if (m_frmLoginWnd.IsDisposed)
					{
						m_frmLoginWnd.Dispose();
						m_frmLoginWnd = null;
						m_frmLoginWnd = new LoginForm();
					}
					
					
					return m_frmLoginWnd;
				}
			}
			
			
			public SecureUser MyUser
			{
				get
				{
					return m_objUser;
				}
			}
			
			
			
			/// <summary>
			/// MDI Parent, sets or returns the MDI Parent of this Form
			/// </summary>
			/// <value></value>
			/// <returns></returns>
			/// <remarks></remarks>
			public Form MdiParent
			{
				get
				{
					return ManagerWnd.MdiParent;
				}
				set
				{
					ManagerWnd.MdiParent = value;
				}
			}
			
			public void ShowManager()
			{
				ManagerWnd.Show();
			}
			
			public void ShowLogin()
			{
				LoginWnd.ShowDialog();
			}
			
			public void ShowPassword()
			{
				
			}
			
			public System.Collections.Generic.List<SecureUser> UserList
			{
				get
				{
					return m_objUserList;
				}
			}
			
			private bool disposedValue = false; // To detect redundant calls
			
			// IDisposable
			protected virtual void Dispose(bool disposing)
			{
				if (! this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free unmanaged resources when explicitly called
						m_frmManager.Close();
						m_frmManager.Dispose();
					}
					
					// TODO: free shared unmanaged resources
				}
				this.disposedValue = true;
			}
			
			#region  IDisposable Support
			// This code added by Visual Basic to correctly implement the disposable pattern.
			public void Dispose()
			{
				// Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
				Dispose(true);
				GC.SuppressFinalize(this);
			}
			#endregion
			
		}
		
		public class SecureUser
		{

			
		}
		public class SPCompany : IDisposable
		{
			
			
			private string m_strName;
			private CompanyForm m_frmCompany;
			
			private CompanyForm CompanyWnd
			{
				get
				{
					if (m_frmCompany == null)
					{
						m_frmCompany = new CompanyForm();
					}
					else if (m_frmCompany.IsDisposed)
					{
						m_frmCompany.Dispose();
						m_frmCompany = null;
						m_frmCompany = new CompanyForm();
					}
					
					return m_frmCompany;
				}
			}
			public string Name
			{
				get
				{
					return m_strName;
				}
				set
				{
					m_strName = value;
				}
			}
			
			/// <summary>
			/// MDI Parent, sets or returns the MDI Parent of this Form
			/// </summary>
			/// <value></value>
			/// <returns></returns>
			/// <remarks></remarks>
			public Form MdiParent
			{
				get
				{
					return CompanyWnd.MdiParent;
				}
				set
				{
					CompanyWnd.MdiParent = value;
				}
			}
			
			public void ShowManager()
			{
				CompanyWnd.Show();
			}
			
			private bool disposedValue = false; // To detect redundant calls
			
			// IDisposable
			protected virtual void Dispose(bool disposing)
			{
				if (! this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free unmanaged resources when explicitly called
					}
					
					// TODO: free shared unmanaged resources
				}
				this.disposedValue = true;
			}
			
			#region  IDisposable Support
			// This code added by Visual Basic to correctly implement the disposable pattern.
			public void Dispose()
			{
				// Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
				Dispose(true);
				GC.SuppressFinalize(this);
			}
			#endregion
			
		}
		
		sealed class SecuritySupport
		{
			
			public static void BuildSecurity(TreeView SourceTree, dsUserSecurity SourceData, bool ClearTree)
			{
				
				
				dsUserSecurity.SPApplicationDataTable dvTreeTable;
				TreeNode rootNode;
				TreeNode applicationNode;
				
				dvTreeTable = SourceData.SPApplication;
				
				if (ClearTree == false) //Might be a root node
				{
					rootNode = SourceTree.Nodes[0];
				}
				else
				{
					SourceTree.Nodes.Clear();
					//rootNode = SourceTree.Nodes.Add(TextDictionary("FL_SECURITY"))
					rootNode = SourceTree.Nodes.Add("Security Explorer");
				}
				
				
				SourceTree.BeginUpdate();
				foreach (dsUserSecurity.SPApplicationRow drvRow in dvTreeTable)
				{
					try
					{
						applicationNode = rootNode.Nodes.Add(drvRow("Name").ToString());
						BuildRoleNode(applicationNode, drvRow);
						applicationNode.Expand();
						applicationNode.ImageKey = "ApplicationNode";
						applicationNode.Tag = "A:" + drvRow("ApplicationID").ToString();
					}
					catch (Exception)
					{
					}
				}
				
				rootNode.Expand();
				SourceTree.EndUpdate();
				Cursor.Current = Cursors.Default;
			}
			
			private static void BuildRoleNode(TreeNode currentNode, dsUserSecurity.SPApplicationRow sourceData)
			{
				TreeNode newRoleNode;
				dsUserSecurity.SPUserRoleRow[] userRoleRows = (dsUserSecurity.SPUserRoleRow[]) (sourceData.GetChildRows("SPApplicationUserRole_FK"));
				
				currentNode.TreeView.BeginUpdate();
				
				foreach (dsUserSecurity.SPUserRoleRow drvRow in userRoleRows)
				{
					try
					{
						TreeNode tempNode = currentNode.Nodes[drvRow.SPRoleRow.RoleName];
						
						if (tempNode == null)
						{
							newRoleNode = currentNode.Nodes.Add(drvRow.SPRoleRow.RoleName);
							newRoleNode.Name = drvRow.SPRoleRow.RoleName;
							newRoleNode.ImageKey = "RoleNode";
							newRoleNode.Tag = "R:" + drvRow.RoleID.ToString();
							
							newRoleNode.NodeFont = new Font(currentNode.TreeView.Font, FontStyle.Bold);
							
							BuildUserNode(newRoleNode, drvRow.SPRoleRow);
						}
					}
					catch (Exception)
					{
					}
				}
				
				newRoleNode = null;
				currentNode.TreeView.EndUpdate();
			}
			
			private static void BuildUserNode(TreeNode currentNode, dsUserSecurity.SPRoleRow sourceData)
			{
				dsUserSecurity.SPUserRoleRow[] newUsers = (dsUserSecurity.SPUserRoleRow[]) (sourceData.GetChildRows("SPRoleUserRole_Fk"));
				TreeNode newUserNode;
				
				foreach (dsUserSecurity.SPUserRoleRow drvRow in newUsers)
				{
					try
					{
						TreeNode tempNode = currentNode.Nodes[drvRow.SPUserRow("UserName").ToString()];
						
						if (tempNode == null)
						{
							newUserNode = currentNode.Nodes.Add(drvRow.SPUserRow("UserName").ToString());
							newUserNode.Name = drvRow.SPUserRow("UserName").ToString();
							newUserNode.ImageKey = "UserNode";
							newUserNode.Tag = "U:" + drvRow.SPUserRow("UserID").ToString();
						}
					}
					catch (Exception)
					{
						
					}
				}
				
				newUserNode = null;
			}
			
		}
	}
	
	
	
	
	
	
	
	
	
}
