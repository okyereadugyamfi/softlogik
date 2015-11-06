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

namespace ACSGhana.Web.Framework
{
	namespace Data
	{
		#region Tables Struct
		public partial struct Tables
		{
			public int x;
			
			public static string Albums = "Albums";
			
			public static string Announcements = "Announcements";
			
			public static string AspnetApplications = "aspnet_Applications";
			
			public static string AspnetMembership = "aspnet_Membership";
			
			public static string AspnetPaths = "aspnet_Paths";
			
			public static string AspnetPersonalizationAllUsers = "aspnet_PersonalizationAllUsers";
			
			public static string AspnetPersonalizationPerUser = "aspnet_PersonalizationPerUser";
			
			public static string AspnetProfile = "aspnet_Profile";
			
			public static string AspnetRoles = "aspnet_Roles";
			
			public static string AspnetSchemaVersions = "aspnet_SchemaVersions";
			
			public static string AspnetUsers = "aspnet_Users";
			
			public static string AspnetUsersInRoles = "aspnet_UsersInRoles";
			
			public static string AspnetWebEventEvents = "aspnet_WebEvent_Events";
			
			public static string Attendance = "Attendance";
			
			public static string BlogComments = "BlogComments";
			
			public static string BlogPosts = "BlogPosts";
			
			public static string ClubEvent = "ClubEvent";
			
			public static string Downloads = "Downloads";
			
			public static string DownloadsInEvents = "DownloadsInEvents";
			
			public static string DownloadsInNews = "DownloadsInNews";
			
			public static string Games = "Games";
			
			public static string HitCounter = "HitCounter";
			
			public static string Image = "image";
			
			public static string Images = "images";
			
			public static string Links = "Links";
			
			public static string Locations = "Locations";
			
			public static string MemberInfo = "MemberInfo";
			
			public static string MemberProfile = "MemberProfile";
			
			public static string MembersThreads = "MembersThreads";
			
			public static string Messages = "Messages";
			
			public static string Players = "Players";
			
			public static string PlayersInStats = "PlayersInStats";
			
			public static string PlayersInTeams = "PlayersInTeams";
			
			public static string PollAnswers = "PollAnswers";
			
			public static string PollQuestions = "PollQuestions";
			
			public static string PollReactions = "PollReactions";
			
			public static string PollVotes = "PollVotes";
			
			public static string Seasons = "Seasons";
			
			public static string SpamFlag = "SpamFlag";
			
			public static string Teams = "Teams";
			
			public static string TempImagesDB = "TempImagesDB";
			
			public static string TempImagesFile = "TempImagesFile";
			
			public static string Threads = "Threads";
			
			public static string Topics = "Topics";
			
			public static string WebContent = "WebContent";
			
			public static string WebSettings = "WebSettings";
			
		}
		#endregion
		#region View Struct
		public partial struct Views
		{
			public int x;
			
			public static string VwAspnetApplications = "vw_aspnet_Applications";
			
			public static string VwAspnetMembershipUsers = "vw_aspnet_MembershipUsers";
			
			public static string VwAspnetProfiles = "vw_aspnet_Profiles";
			
			public static string VwAspnetRoles = "vw_aspnet_Roles";
			
			public static string VwAspnetUsers = "vw_aspnet_Users";
			
			public static string VwAspnetUsersInRoles = "vw_aspnet_UsersInRoles";
			
			public static string VwAspnetWebPartStatePaths = "vw_aspnet_WebPartState_Paths";
			
			public static string VwAspnetWebPartStateShared = "vw_aspnet_WebPartState_Shared";
			
			public static string VwAspnetWebPartStateUser = "vw_aspnet_WebPartState_User";
			
		}
		#endregion
	}
}
