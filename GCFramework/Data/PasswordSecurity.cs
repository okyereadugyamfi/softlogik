using System.Diagnostics;
using System;
using System.Management;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Web.UI.Design;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Configuration;
using System.Security.Principal;
using System.Security.Permissions;
using System.Globalization;
using System.Runtime.Serialization;
using System.Collections.Specialized;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration.Provider;
using System.Configuration;
using System.Web.Management;
using System.Web.Util;



namespace ACSGhana.Web.Framework
{
	public class PasswordSecurity : MembershipProvider
	{
		
		
		public bool ChangePassword(string sqlConnectionString, string ApplicationName, string username, string oldPassword, string newPassword)
		{
			string salt = null;
			int passwordFormat;
			int status;
			
			if (! CheckPassword(sqlConnectionString, ApplicationName, username, oldPassword, false, false, ref salt, ref passwordFormat))
			{
				return false;
			}
			
			int count = 0;
			
			int i = 0;
			while (i < newPassword.Length)
			{
				if (! char.IsLetterOrDigit(newPassword, i))
				{
					count++;
				}
				i++;
			}
			
			string pass = EncodePassword(newPassword, passwordFormat, salt);
			try
			{
				SqlConnectionHolder holder = null;
				try
				{
					holder = SqlConnectionHelper.GetConnection(sqlConnectionString, true);
					SqlCommand cmd = new SqlCommand("dbo.aspnet_Membership_SetPassword", holder.Connection);
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(CreateInputParam("@ApplicationName", SqlDbType.NVarChar, ApplicationName));
					cmd.Parameters.Add(CreateInputParam("@UserName", SqlDbType.NVarChar, username));
					cmd.Parameters.Add(CreateInputParam("@NewPassword", SqlDbType.NVarChar, pass));
					cmd.Parameters.Add(CreateInputParam("@PasswordSalt", SqlDbType.NVarChar, salt));
					cmd.Parameters.Add(CreateInputParam("@PasswordFormat", SqlDbType.Int, passwordFormat));
					cmd.Parameters.Add(CreateInputParam("@CurrentTimeUtc", SqlDbType.DateTime, DateTime.UtcNow));
					
					SqlParameter p = new SqlParameter("@ReturnValue", SqlDbType.Int);
					p.Direction = ParameterDirection.ReturnValue;
					cmd.Parameters.Add(p);
					
					cmd.ExecuteNonQuery();
					
					if (p.Value != null)
					{
						status = System.Convert.ToInt32(Conversion.Fix(p.Value));
					}
					else
					{
						status = - 1;
					}
					
					return true;
				}
				finally
				{
					if (holder != null)
					{
						holder.Close();
						holder = null;
					}
					
				}
			}
			catch (System.Exception)
			{
				throw;
			}
		}
		
		private SqlParameter CreateInputParam(string paramName, SqlDbType dbType, object objValue)
		{
			
			SqlParameter param = new SqlParameter(paramName, dbType);
			
			if (objValue == null)
			{
				param.IsNullable = true;
				param.Value = DBNull.Value;
			}
			else
			{
				param.Value = objValue;
			}
			
			return param;
		}
		
		private bool CheckPassword(string sqlConnectionString, string ApplicationName, string username, string password, bool updateLastLoginActivityDate, bool failIfNotApproved)
		{
			string salt = string.Empty;
			int passwordFormat;
			return CheckPassword(sqlConnectionString, ApplicationName, username, password, updateLastLoginActivityDate, failIfNotApproved, ref salt, ref passwordFormat);
		}
		private bool CheckPassword(string sqlConnectionString, string ApplicationName, string username, string password, bool updateLastLoginActivityDate, bool failIfNotApproved, ref string salt, ref int passwordFormat)
		{
			SqlConnectionHolder holder = null;
			string passwdFromDB = string.Empty;
			int status;
			int failedPasswordAttemptCount;
			int failedPasswordAnswerAttemptCount;
			bool isApproved;
			DateTime lastLoginDate;
			DateTime lastActivityDate;
			
			GetPasswordWithFormat(sqlConnectionString, ApplicationName, username, updateLastLoginActivityDate, ref status, ref passwdFromDB, ref passwordFormat, ref salt, ref failedPasswordAttemptCount, ref failedPasswordAnswerAttemptCount, ref isApproved, ref lastLoginDate, ref lastActivityDate);
			return true;
		}
		
		private void GetPasswordWithFormat(string sqlConnectionString, string ApplicationName, string username, bool updateLastLoginActivityDate, [System.Runtime.InteropServices.Out()]ref int status, [System.Runtime.InteropServices.Out()]ref string password, [System.Runtime.InteropServices.Out()]ref int passwordFormat, [System.Runtime.InteropServices.Out()]ref string passwordSalt, [System.Runtime.InteropServices.Out()]ref int failedPasswordAttemptCount, [System.Runtime.InteropServices.Out()]ref int failedPasswordAnswerAttemptCount, [System.Runtime.InteropServices.Out()]ref bool isApproved, [System.Runtime.InteropServices.Out()]ref DateTime lastLoginDate, [System.Runtime.InteropServices.Out()]ref DateTime lastActivityDate)
		{
			try
			{
				SqlConnectionHolder holder = null;
				SqlDataReader reader = null;
				SqlParameter p = null;
				
				try
				{
					holder = SqlConnectionHelper.GetConnection(sqlConnectionString, true);
					
					SqlCommand cmd = new SqlCommand("dbo.aspnet_Membership_GetPasswordWithFormat", holder.Connection);
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(CreateInputParam("@ApplicationName", SqlDbType.NVarChar, ApplicationName));
					cmd.Parameters.Add(CreateInputParam("@UserName", SqlDbType.NVarChar, username));
					cmd.Parameters.Add(CreateInputParam("@UpdateLastLoginActivityDate", SqlDbType.Bit, updateLastLoginActivityDate));
					cmd.Parameters.Add(CreateInputParam("@CurrentTimeUtc", SqlDbType.DateTime, DateTime.UtcNow));
					
					p = new SqlParameter("@ReturnValue", SqlDbType.Int);
					p.Direction = ParameterDirection.ReturnValue;
					cmd.Parameters.Add(p);
					
					reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
					
					status = - 1;
					
					if (reader.Read())
					{
						password = reader.GetString(0);
						passwordFormat = reader.GetInt32(1);
						passwordSalt = reader.GetString(2);
						failedPasswordAttemptCount = reader.GetInt32(3);
						failedPasswordAnswerAttemptCount = reader.GetInt32(4);
						isApproved = reader.GetBoolean(5);
						lastLoginDate = reader.GetDateTime(6);
						lastActivityDate = reader.GetDateTime(7);
					}
					else
					{
						password = null;
						passwordFormat = 0;
						passwordSalt = null;
						failedPasswordAttemptCount = 0;
						failedPasswordAnswerAttemptCount = 0;
						isApproved = false;
						lastLoginDate = DateTime.UtcNow;
						lastActivityDate = DateTime.UtcNow;
					}
				}
				finally
				{
					if (reader != null)
					{
						reader.Close();
						reader = null;
						
						if (p.Value != null)
						{
							status = System.Convert.ToInt32(Conversion.Fix(p.Value));
						}
						else
						{
							status = - 1;
						}
					}
					
					if (holder != null)
					{
						holder.Close();
						holder = null;
					}
				}
			}
			catch
			{
				throw;
			}
			
		}
		
		internal string EncodePassword(string pass, int passwordFormat, string salt)
		{
			if (passwordFormat == 0) // MembershipPasswordFormat.Clear
			{
				return pass;
			}
			
			byte[] bIn = Encoding.Unicode.GetBytes(pass);
			byte[] bSalt = Convert.FromBase64String(salt);
			byte[] bAll = new byte[bSalt.Length + bIn.Length - 1+ 1];
			byte[] bRet = null;
			
			Buffer.BlockCopy(bSalt, 0, bAll, 0, bSalt.Length);
			Buffer.BlockCopy(bIn, 0, bAll, bSalt.Length, bIn.Length);
			if (passwordFormat == 1)
			{
				HashAlgorithm s = HashAlgorithm.Create(Membership.HashAlgorithmType);
				bRet = s.ComputeHash(bAll);
			}
			else
			{
				bRet = EncryptPassword(bAll);
			}
			
			return Convert.ToBase64String(bRet);
		}
		
		public override string ApplicationName
		{
			get
			{
				throw (new NotImplementedException);
				
			}
			set
			{
				
			}
		}
		
		public override bool ChangePassword(string username, string oldPassword, string newPassword)
		{
			throw (new NotImplementedException);
			
		}
		
		public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
		{
			throw (new NotImplementedException);
			
		}
		
		public override System.Web.Security.MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, System.Web.Security.MembershipCreateStatus status)
		{
			
			throw (new NotImplementedException);
		}
		
		public override bool DeleteUser(string username, bool deleteAllRelatedData)
		{
			throw (new NotImplementedException);
			
		}
		
		public override bool EnablePasswordReset
		{
			get
			{
				throw (new NotImplementedException);
				
			}
		}
		
		public override bool EnablePasswordRetrieval
		{
			get
			{
				throw (new NotImplementedException);
				
			}
		}
		
		public override System.Web.Security.MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, int totalRecords)
		{
			throw (new NotImplementedException);
			
		}
		
		public override System.Web.Security.MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, int totalRecords)
		{
			throw (new NotImplementedException);
			
		}
		
		public override System.Web.Security.MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, int totalRecords)
		{
			throw (new NotImplementedException);
			
		}
		
		public override int GetNumberOfUsersOnline()
		{
			throw (new NotImplementedException);
			
		}
		
		public override string GetPassword(string username, string answer)
		{
			throw (new NotImplementedException);
			
		}
		
		public override System.Web.Security.MembershipUser GetUser(object providerUserKey, bool userIsOnline)
		{
			throw (new NotImplementedException);
			
		}
		
		public override System.Web.Security.MembershipUser GetUser(string username, bool userIsOnline)
		{
			throw (new NotImplementedException);
			
		}
		
		public override string GetUserNameByEmail(string email)
		{
			throw (new NotImplementedException);
			
		}
		
		public override int MaxInvalidPasswordAttempts
		{
			get
			{
				throw (new NotImplementedException);
				
			}
		}
		
		public override int MinRequiredNonAlphanumericCharacters
		{
			get
			{
				throw (new NotImplementedException);
				
			}
		}
		
		public override int MinRequiredPasswordLength
		{
			get
			{
				throw (new NotImplementedException);
				
			}
		}
		
		public override int PasswordAttemptWindow
		{
			get
			{
				throw (new NotImplementedException);
				
			}
		}
		
		public override System.Web.Security.MembershipPasswordFormat PasswordFormat
		{
			get
			{
				throw (new NotImplementedException);
				
			}
		}
		
		public override string PasswordStrengthRegularExpression
		{
			get
			{
				throw (new NotImplementedException);
				
			}
		}
		
		public override bool RequiresQuestionAndAnswer
		{
			get
			{
				throw (new NotImplementedException);
				
			}
		}
		
		public override bool RequiresUniqueEmail
		{
			get
			{
				throw (new NotImplementedException);
				
			}
		}
		
		public override string ResetPassword(string username, string answer)
		{
			throw (new NotImplementedException);
		}
		
		public override bool UnlockUser(string userName)
		{
			throw (new NotImplementedException);
			
		}
		
		public override void UpdateUser(System.Web.Security.MembershipUser user)
		{
			throw (new NotImplementedException);
			
		}
		
		public override bool ValidateUser(string username, string password)
		{
			throw (new NotImplementedException);
			
		}
	}
	
}
