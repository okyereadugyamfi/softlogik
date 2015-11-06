using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;

namespace SoftLogik.Win.Data{
    public partial class SPs{
        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Setup_RestorePermissions Procedure
        /// </summary>
        public static StoredProcedure AspnetSetupRestorePermissions(string name)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Setup_RestorePermissions" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@name", name,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Setup_RemoveAllRoleMembers Procedure
        /// </summary>
        public static StoredProcedure AspnetSetupRemoveAllRoleMembers(string name)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Setup_RemoveAllRoleMembers" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@name", name,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_RegisterSchemaVersion Procedure
        /// </summary>
        public static StoredProcedure AspnetRegisterSchemaVersion(string Feature, string CompatibleSchemaVersion, bool? IsCurrentVersion, bool? RemoveIncompatibleSchema)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_RegisterSchemaVersion" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@Feature", Feature,DbType.String);
        	    
            sp.Command.AddParameter("@CompatibleSchemaVersion", CompatibleSchemaVersion,DbType.String);
        	    
            sp.Command.AddParameter("@IsCurrentVersion", IsCurrentVersion,DbType.Boolean);
        	    
            sp.Command.AddParameter("@RemoveIncompatibleSchema", RemoveIncompatibleSchema,DbType.Boolean);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_CheckSchemaVersion Procedure
        /// </summary>
        public static StoredProcedure AspnetCheckSchemaVersion(string Feature, string CompatibleSchemaVersion)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_CheckSchemaVersion" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@Feature", Feature,DbType.String);
        	    
            sp.Command.AddParameter("@CompatibleSchemaVersion", CompatibleSchemaVersion,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Applications_CreateApplication Procedure
        /// </summary>
        public static StoredProcedure AspnetApplicationsCreateApplication(string ApplicationName, Guid? ApplicationId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Applications_CreateApplication" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddOutputParameter("@ApplicationId",DbType.Guid);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_UnRegisterSchemaVersion Procedure
        /// </summary>
        public static StoredProcedure AspnetUnRegisterSchemaVersion(string Feature, string CompatibleSchemaVersion)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_UnRegisterSchemaVersion" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@Feature", Feature,DbType.String);
        	    
            sp.Command.AddParameter("@CompatibleSchemaVersion", CompatibleSchemaVersion,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Users_CreateUser Procedure
        /// </summary>
        public static StoredProcedure AspnetUsersCreateUser(Guid? ApplicationId, string UserName, bool? IsUserAnonymous, DateTime? LastActivityDate, Guid? UserId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Users_CreateUser" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationId", ApplicationId,DbType.Guid);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@IsUserAnonymous", IsUserAnonymous,DbType.Boolean);
        	    
            sp.Command.AddParameter("@LastActivityDate", LastActivityDate,DbType.DateTime);
        	    
            sp.Command.AddOutputParameter("@UserId",DbType.Guid);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Users_DeleteUser Procedure
        /// </summary>
        public static StoredProcedure AspnetUsersDeleteUser(string ApplicationName, string UserName, int? TablesToDeleteFrom, int? NumTablesDeletedFrom)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Users_DeleteUser" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@TablesToDeleteFrom", TablesToDeleteFrom,DbType.Int32);
        	    
            sp.Command.AddOutputParameter("@NumTablesDeletedFrom",DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_AnyDataInTables Procedure
        /// </summary>
        public static StoredProcedure AspnetAnyDataInTables(int? TablesToCheck)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_AnyDataInTables" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@TablesToCheck", TablesToCheck,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_CreateUser Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipCreateUser(string ApplicationName, string UserName, string Password, string PasswordSalt, string Email, string PasswordQuestion, string PasswordAnswer, bool? IsApproved, DateTime? CurrentTimeUtc, DateTime? CreateDate, int? UniqueEmail, int? PasswordFormat, Guid? UserId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_CreateUser" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@Password", Password,DbType.String);
        	    
            sp.Command.AddParameter("@PasswordSalt", PasswordSalt,DbType.String);
        	    
            sp.Command.AddParameter("@Email", Email,DbType.String);
        	    
            sp.Command.AddParameter("@PasswordQuestion", PasswordQuestion,DbType.String);
        	    
            sp.Command.AddParameter("@PasswordAnswer", PasswordAnswer,DbType.String);
        	    
            sp.Command.AddParameter("@IsApproved", IsApproved,DbType.Boolean);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            sp.Command.AddParameter("@CreateDate", CreateDate,DbType.DateTime);
        	    
            sp.Command.AddParameter("@UniqueEmail", UniqueEmail,DbType.Int32);
        	    
            sp.Command.AddParameter("@PasswordFormat", PasswordFormat,DbType.Int32);
        	    
            sp.Command.AddOutputParameter("@UserId",DbType.Guid);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_GetUserByName Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipGetUserByName(string ApplicationName, string UserName, DateTime? CurrentTimeUtc, bool? UpdateLastActivity)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_GetUserByName" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            sp.Command.AddParameter("@UpdateLastActivity", UpdateLastActivity,DbType.Boolean);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_GetUserByUserId Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipGetUserByUserId(Guid? UserId, DateTime? CurrentTimeUtc, bool? UpdateLastActivity)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_GetUserByUserId" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@UserId", UserId,DbType.Guid);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            sp.Command.AddParameter("@UpdateLastActivity", UpdateLastActivity,DbType.Boolean);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_GetUserByEmail Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipGetUserByEmail(string ApplicationName, string Email)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_GetUserByEmail" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@Email", Email,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_GetPasswordWithFormat Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipGetPasswordWithFormat(string ApplicationName, string UserName, bool? UpdateLastLoginActivityDate, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_GetPasswordWithFormat" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@UpdateLastLoginActivityDate", UpdateLastLoginActivityDate,DbType.Boolean);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_UpdateUserInfo Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipUpdateUserInfo(string ApplicationName, string UserName, bool? IsPasswordCorrect, bool? UpdateLastLoginActivityDate, int? MaxInvalidPasswordAttempts, int? PasswordAttemptWindow, DateTime? CurrentTimeUtc, DateTime? LastLoginDate, DateTime? LastActivityDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_UpdateUserInfo" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@IsPasswordCorrect", IsPasswordCorrect,DbType.Boolean);
        	    
            sp.Command.AddParameter("@UpdateLastLoginActivityDate", UpdateLastLoginActivityDate,DbType.Boolean);
        	    
            sp.Command.AddParameter("@MaxInvalidPasswordAttempts", MaxInvalidPasswordAttempts,DbType.Int32);
        	    
            sp.Command.AddParameter("@PasswordAttemptWindow", PasswordAttemptWindow,DbType.Int32);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            sp.Command.AddParameter("@LastLoginDate", LastLoginDate,DbType.DateTime);
        	    
            sp.Command.AddParameter("@LastActivityDate", LastActivityDate,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_GetPassword Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipGetPassword(string ApplicationName, string UserName, int? MaxInvalidPasswordAttempts, int? PasswordAttemptWindow, DateTime? CurrentTimeUtc, string PasswordAnswer)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_GetPassword" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@MaxInvalidPasswordAttempts", MaxInvalidPasswordAttempts,DbType.Int32);
        	    
            sp.Command.AddParameter("@PasswordAttemptWindow", PasswordAttemptWindow,DbType.Int32);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            sp.Command.AddParameter("@PasswordAnswer", PasswordAnswer,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_SetPassword Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipSetPassword(string ApplicationName, string UserName, string NewPassword, string PasswordSalt, DateTime? CurrentTimeUtc, int? PasswordFormat)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_SetPassword" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@NewPassword", NewPassword,DbType.String);
        	    
            sp.Command.AddParameter("@PasswordSalt", PasswordSalt,DbType.String);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            sp.Command.AddParameter("@PasswordFormat", PasswordFormat,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_ResetPassword Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipResetPassword(string ApplicationName, string UserName, string NewPassword, int? MaxInvalidPasswordAttempts, int? PasswordAttemptWindow, string PasswordSalt, DateTime? CurrentTimeUtc, int? PasswordFormat, string PasswordAnswer)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_ResetPassword" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@NewPassword", NewPassword,DbType.String);
        	    
            sp.Command.AddParameter("@MaxInvalidPasswordAttempts", MaxInvalidPasswordAttempts,DbType.Int32);
        	    
            sp.Command.AddParameter("@PasswordAttemptWindow", PasswordAttemptWindow,DbType.Int32);
        	    
            sp.Command.AddParameter("@PasswordSalt", PasswordSalt,DbType.String);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            sp.Command.AddParameter("@PasswordFormat", PasswordFormat,DbType.Int32);
        	    
            sp.Command.AddParameter("@PasswordAnswer", PasswordAnswer,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_UnlockUser Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipUnlockUser(string ApplicationName, string UserName)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_UnlockUser" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_UpdateUser Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipUpdateUser(string ApplicationName, string UserName, string Email, string Comment, bool? IsApproved, DateTime? LastLoginDate, DateTime? LastActivityDate, int? UniqueEmail, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_UpdateUser" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@Email", Email,DbType.String);
        	    
            sp.Command.AddParameter("@Comment", Comment,DbType.String);
        	    
            sp.Command.AddParameter("@IsApproved", IsApproved,DbType.Boolean);
        	    
            sp.Command.AddParameter("@LastLoginDate", LastLoginDate,DbType.DateTime);
        	    
            sp.Command.AddParameter("@LastActivityDate", LastActivityDate,DbType.DateTime);
        	    
            sp.Command.AddParameter("@UniqueEmail", UniqueEmail,DbType.Int32);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_ChangePasswordQuestionAndAnswer Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipChangePasswordQuestionAndAnswer(string ApplicationName, string UserName, string NewPasswordQuestion, string NewPasswordAnswer)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_ChangePasswordQuestionAndAnswer" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@NewPasswordQuestion", NewPasswordQuestion,DbType.String);
        	    
            sp.Command.AddParameter("@NewPasswordAnswer", NewPasswordAnswer,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_GetAllUsers Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipGetAllUsers(string ApplicationName, int? PageIndex, int? PageSize)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_GetAllUsers" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@PageIndex", PageIndex,DbType.Int32);
        	    
            sp.Command.AddParameter("@PageSize", PageSize,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_GetNumberOfUsersOnline Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipGetNumberOfUsersOnline(string ApplicationName, int? MinutesSinceLastInActive, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_GetNumberOfUsersOnline" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@MinutesSinceLastInActive", MinutesSinceLastInActive,DbType.Int32);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_FindUsersByName Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipFindUsersByName(string ApplicationName, string UserNameToMatch, int? PageIndex, int? PageSize)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_FindUsersByName" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserNameToMatch", UserNameToMatch,DbType.String);
        	    
            sp.Command.AddParameter("@PageIndex", PageIndex,DbType.Int32);
        	    
            sp.Command.AddParameter("@PageSize", PageSize,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Membership_FindUsersByEmail Procedure
        /// </summary>
        public static StoredProcedure AspnetMembershipFindUsersByEmail(string ApplicationName, string EmailToMatch, int? PageIndex, int? PageSize)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Membership_FindUsersByEmail" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@EmailToMatch", EmailToMatch,DbType.String);
        	    
            sp.Command.AddParameter("@PageIndex", PageIndex,DbType.Int32);
        	    
            sp.Command.AddParameter("@PageSize", PageSize,DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Profile_GetProperties Procedure
        /// </summary>
        public static StoredProcedure AspnetProfileGetProperties(string ApplicationName, string UserName, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Profile_GetProperties" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Profile_SetProperties Procedure
        /// </summary>
        public static StoredProcedure AspnetProfileSetProperties(string ApplicationName, string PropertyNames, string PropertyValuesString, byte[] PropertyValuesBinary, string UserName, bool? IsUserAnonymous, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Profile_SetProperties" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@PropertyNames", PropertyNames,DbType.String);
        	    
            sp.Command.AddParameter("@PropertyValuesString", PropertyValuesString,DbType.String);
        	    
            sp.Command.AddParameter("@PropertyValuesBinary", PropertyValuesBinary,DbType.Binary);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@IsUserAnonymous", IsUserAnonymous,DbType.Boolean);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Profile_DeleteProfiles Procedure
        /// </summary>
        public static StoredProcedure AspnetProfileDeleteProfiles(string ApplicationName, string UserNames)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Profile_DeleteProfiles" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserNames", UserNames,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Profile_DeleteInactiveProfiles Procedure
        /// </summary>
        public static StoredProcedure AspnetProfileDeleteInactiveProfiles(string ApplicationName, int? ProfileAuthOptions, DateTime? InactiveSinceDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Profile_DeleteInactiveProfiles" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@ProfileAuthOptions", ProfileAuthOptions,DbType.Int32);
        	    
            sp.Command.AddParameter("@InactiveSinceDate", InactiveSinceDate,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Profile_GetNumberOfInactiveProfiles Procedure
        /// </summary>
        public static StoredProcedure AspnetProfileGetNumberOfInactiveProfiles(string ApplicationName, int? ProfileAuthOptions, DateTime? InactiveSinceDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Profile_GetNumberOfInactiveProfiles" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@ProfileAuthOptions", ProfileAuthOptions,DbType.Int32);
        	    
            sp.Command.AddParameter("@InactiveSinceDate", InactiveSinceDate,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Profile_GetProfiles Procedure
        /// </summary>
        public static StoredProcedure AspnetProfileGetProfiles(string ApplicationName, int? ProfileAuthOptions, int? PageIndex, int? PageSize, string UserNameToMatch, DateTime? InactiveSinceDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Profile_GetProfiles" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@ProfileAuthOptions", ProfileAuthOptions,DbType.Int32);
        	    
            sp.Command.AddParameter("@PageIndex", PageIndex,DbType.Int32);
        	    
            sp.Command.AddParameter("@PageSize", PageSize,DbType.Int32);
        	    
            sp.Command.AddParameter("@UserNameToMatch", UserNameToMatch,DbType.String);
        	    
            sp.Command.AddParameter("@InactiveSinceDate", InactiveSinceDate,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_UsersInRoles_IsUserInRole Procedure
        /// </summary>
        public static StoredProcedure AspnetUsersInRolesIsUserInRole(string ApplicationName, string UserName, string RoleName)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_UsersInRoles_IsUserInRole" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@RoleName", RoleName,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_UsersInRoles_GetRolesForUser Procedure
        /// </summary>
        public static StoredProcedure AspnetUsersInRolesGetRolesForUser(string ApplicationName, string UserName)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_UsersInRoles_GetRolesForUser" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Roles_CreateRole Procedure
        /// </summary>
        public static StoredProcedure AspnetRolesCreateRole(string ApplicationName, string RoleName)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Roles_CreateRole" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@RoleName", RoleName,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Roles_DeleteRole Procedure
        /// </summary>
        public static StoredProcedure AspnetRolesDeleteRole(string ApplicationName, string RoleName, bool? DeleteOnlyIfRoleIsEmpty)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Roles_DeleteRole" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@RoleName", RoleName,DbType.String);
        	    
            sp.Command.AddParameter("@DeleteOnlyIfRoleIsEmpty", DeleteOnlyIfRoleIsEmpty,DbType.Boolean);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Roles_RoleExists Procedure
        /// </summary>
        public static StoredProcedure AspnetRolesRoleExists(string ApplicationName, string RoleName)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Roles_RoleExists" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@RoleName", RoleName,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_UsersInRoles_AddUsersToRoles Procedure
        /// </summary>
        public static StoredProcedure AspnetUsersInRolesAddUsersToRoles(string ApplicationName, string UserNames, string RoleNames, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_UsersInRoles_AddUsersToRoles" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserNames", UserNames,DbType.String);
        	    
            sp.Command.AddParameter("@RoleNames", RoleNames,DbType.String);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_UsersInRoles_RemoveUsersFromRoles Procedure
        /// </summary>
        public static StoredProcedure AspnetUsersInRolesRemoveUsersFromRoles(string ApplicationName, string UserNames, string RoleNames)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_UsersInRoles_RemoveUsersFromRoles" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserNames", UserNames,DbType.String);
        	    
            sp.Command.AddParameter("@RoleNames", RoleNames,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_UsersInRoles_GetUsersInRoles Procedure
        /// </summary>
        public static StoredProcedure AspnetUsersInRolesGetUsersInRoles(string ApplicationName, string RoleName)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_UsersInRoles_GetUsersInRoles" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@RoleName", RoleName,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_UsersInRoles_FindUsersInRole Procedure
        /// </summary>
        public static StoredProcedure AspnetUsersInRolesFindUsersInRole(string ApplicationName, string RoleName, string UserNameToMatch)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_UsersInRoles_FindUsersInRole" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@RoleName", RoleName,DbType.String);
        	    
            sp.Command.AddParameter("@UserNameToMatch", UserNameToMatch,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Roles_GetAllRoles Procedure
        /// </summary>
        public static StoredProcedure AspnetRolesGetAllRoles(string ApplicationName)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Roles_GetAllRoles" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Personalization_GetApplicationId Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationGetApplicationId(string ApplicationName, Guid? ApplicationId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Personalization_GetApplicationId" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddOutputParameter("@ApplicationId",DbType.Guid);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_Paths_CreatePath Procedure
        /// </summary>
        public static StoredProcedure AspnetPathsCreatePath(Guid? ApplicationId, string Path, Guid? PathId)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_Paths_CreatePath" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationId", ApplicationId,DbType.Guid);
        	    
            sp.Command.AddParameter("@Path", Path,DbType.String);
        	    
            sp.Command.AddOutputParameter("@PathId",DbType.Guid);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationAllUsers_GetPageSettings Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationAllUsersGetPageSettings(string ApplicationName, string Path)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationAllUsers_GetPageSettings" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@Path", Path,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationAllUsers_ResetPageSettings Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationAllUsersResetPageSettings(string ApplicationName, string Path)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationAllUsers_ResetPageSettings" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@Path", Path,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationAllUsers_SetPageSettings Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationAllUsersSetPageSettings(string ApplicationName, string Path, byte[] PageSettings, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationAllUsers_SetPageSettings" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@Path", Path,DbType.String);
        	    
            sp.Command.AddParameter("@PageSettings", PageSettings,DbType.Binary);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationPerUser_GetPageSettings Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationPerUserGetPageSettings(string ApplicationName, string UserName, string Path, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationPerUser_GetPageSettings" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@Path", Path,DbType.String);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationPerUser_ResetPageSettings Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationPerUserResetPageSettings(string ApplicationName, string UserName, string Path, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationPerUser_ResetPageSettings" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@Path", Path,DbType.String);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationPerUser_SetPageSettings Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationPerUserSetPageSettings(string ApplicationName, string UserName, string Path, byte[] PageSettings, DateTime? CurrentTimeUtc)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationPerUser_SetPageSettings" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@Path", Path,DbType.String);
        	    
            sp.Command.AddParameter("@PageSettings", PageSettings,DbType.Binary);
        	    
            sp.Command.AddParameter("@CurrentTimeUtc", CurrentTimeUtc,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationAdministration_DeleteAllState Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationAdministrationDeleteAllState(bool? AllUsersScope, string ApplicationName, int? Count)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationAdministration_DeleteAllState" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@AllUsersScope", AllUsersScope,DbType.Boolean);
        	    
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddOutputParameter("@Count",DbType.Int32);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationAdministration_ResetSharedState Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationAdministrationResetSharedState(int? Count, string ApplicationName, string Path)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationAdministration_ResetSharedState" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddOutputParameter("@Count",DbType.Int32);
        	    
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@Path", Path,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationAdministration_ResetUserState Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationAdministrationResetUserState(int? Count, string ApplicationName, DateTime? InactiveSinceDate, string UserName, string Path)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationAdministration_ResetUserState" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddOutputParameter("@Count",DbType.Int32);
        	    
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@InactiveSinceDate", InactiveSinceDate,DbType.DateTime);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@Path", Path,DbType.String);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationAdministration_FindState Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationAdministrationFindState(bool? AllUsersScope, string ApplicationName, int? PageIndex, int? PageSize, string Path, string UserName, DateTime? InactiveSinceDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationAdministration_FindState" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@AllUsersScope", AllUsersScope,DbType.Boolean);
        	    
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@PageIndex", PageIndex,DbType.Int32);
        	    
            sp.Command.AddParameter("@PageSize", PageSize,DbType.Int32);
        	    
            sp.Command.AddParameter("@Path", Path,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@InactiveSinceDate", InactiveSinceDate,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_PersonalizationAdministration_GetCountOfState Procedure
        /// </summary>
        public static StoredProcedure AspnetPersonalizationAdministrationGetCountOfState(int? Count, bool? AllUsersScope, string ApplicationName, string Path, string UserName, DateTime? InactiveSinceDate)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_PersonalizationAdministration_GetCountOfState" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddOutputParameter("@Count",DbType.Int32);
        	    
            sp.Command.AddParameter("@AllUsersScope", AllUsersScope,DbType.Boolean);
        	    
            sp.Command.AddParameter("@ApplicationName", ApplicationName,DbType.String);
        	    
            sp.Command.AddParameter("@Path", Path,DbType.String);
        	    
            sp.Command.AddParameter("@UserName", UserName,DbType.String);
        	    
            sp.Command.AddParameter("@InactiveSinceDate", InactiveSinceDate,DbType.DateTime);
        	    
            return sp;
        }

        
        /// <summary>
        /// Creates an object wrapper for the aspnet_WebEvent_LogEvent Procedure
        /// </summary>
        public static StoredProcedure AspnetWebEventLogEvent(string EventId, DateTime? EventTimeUtc, DateTime? EventTime, string EventType, decimal? EventSequence, decimal? EventOccurrence, int? EventCode, int? EventDetailCode, string Message, string ApplicationPath, string ApplicationVirtualPath, string MachineName, string RequestUrl, string ExceptionType, string Details)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("aspnet_WebEvent_LogEvent" , DataService.GetInstance("WinSubSonicProvider"));
        	
            sp.Command.AddParameter("@EventId", EventId,DbType.AnsiStringFixedLength);
        	    
            sp.Command.AddParameter("@EventTimeUtc", EventTimeUtc,DbType.DateTime);
        	    
            sp.Command.AddParameter("@EventTime", EventTime,DbType.DateTime);
        	    
            sp.Command.AddParameter("@EventType", EventType,DbType.String);
        	    
            sp.Command.AddParameter("@EventSequence", EventSequence,DbType.Decimal);
        	    
            sp.Command.AddParameter("@EventOccurrence", EventOccurrence,DbType.Decimal);
        	    
            sp.Command.AddParameter("@EventCode", EventCode,DbType.Int32);
        	    
            sp.Command.AddParameter("@EventDetailCode", EventDetailCode,DbType.Int32);
        	    
            sp.Command.AddParameter("@Message", Message,DbType.String);
        	    
            sp.Command.AddParameter("@ApplicationPath", ApplicationPath,DbType.String);
        	    
            sp.Command.AddParameter("@ApplicationVirtualPath", ApplicationVirtualPath,DbType.String);
        	    
            sp.Command.AddParameter("@MachineName", MachineName,DbType.String);
        	    
            sp.Command.AddParameter("@RequestUrl", RequestUrl,DbType.String);
        	    
            sp.Command.AddParameter("@ExceptionType", ExceptionType,DbType.String);
        	    
            sp.Command.AddParameter("@Details", Details,DbType.String);
        	    
            return sp;
        }

        
    }

    
}

