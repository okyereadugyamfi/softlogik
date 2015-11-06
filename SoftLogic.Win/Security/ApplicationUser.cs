using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftLogic.Win.Security
{
    public sealed class ApplicationUser
    {
        			
			
			#region Private Variables
            private string m_strId;

 			private string m_strName;
			private string m_strPassword;
            private string m_strCard;
            private string m_strRole;
            private Image m_imgIcon;
			private List<string> m_lstPermisssions;
			#endregion

            #region ctor
            public ApplicationUser()
            {
 
            }
            public ApplicationUser(string Id, string Name, string Password, string Card, string Role)
			{
                m_strId = Id;
                m_strName = Name;
                m_strPassword = Password;
                m_strCard = Card;
				m_lstPermisssions = null;
            }
            #endregion

            #region Properties
            public string Id
            {
                get { return m_strId; }
                set { m_strId = value; }
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
			public string Password
			{
				get
				{
					return m_strPassword;
				}
				set
				{
					m_strPassword = value;
				}
			}
            public string Role
            {
                get { return m_strRole; }
                set { m_strRole = value; }
            }

            public string Card
            {
                get { return m_strCard; }
                set { m_strCard = value; }
            }

			public System.Collections.Generic.List<string> Permisssions
			{
				get
				{
					return m_lstPermisssions;
				}
            }
            #endregion

        #region methods
            public bool authenticate()
            {
                return string.IsNullOrEmpty( m_strPassword) || m_strPassword.StartsWith("empty:");
            }
            public boolean authenticate(String Password)
            {
                return Hashcypher.authenticate(Password, m_strPassword);
            }
        #endregion
    }
}
