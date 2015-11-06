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
using System.Text;
using System.Data.Common;
using System.ComponentModel;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;
using SubSonic.Utilities;

namespace ACSGhana.Web.Framework
{
	namespace Data
	{
		/// <summary>
		/// Controller class for PollVotes
		/// </summary>
		[System.ComponentModel.DataObject()]public partial class PollVotesController
		{
			
			
			// Preload our schema..
			PollVotes thisSchemaLoad = new PollVotes();
			private string strUserName = string.Empty;
			protected string UserName
			{
				get
				{
					if (strUserName.Length == 0)
					{
						
						if (System.Web.HttpContext.Current != null)
						{
							strUserName = System.Web.HttpContext.Current.User.Identity.Name;
						}
						else
						{
							strUserName = System.Threading.Thread.CurrentPrincipal.Identity.Name;
						}
						return strUserName;
					}
					return strUserName;
				}
			}
			[DataObjectMethod(DataObjectMethodType.Select, true)]public PollVotesCollection FetchAll()
			{
				
				PollVotesCollection coll = new PollVotesCollection();
				Query qry = new Query(PollVotes.Schema);
				coll.LoadAndCloseReader(qry.ExecuteReader());
				return coll;
				
			}
			[DataObjectMethod(DataObjectMethodType.Select, true)]public PollVotesCollection FetchByID(object VoteId)
			{
				
				PollVotesCollection coll = new PollVotesCollection().Where("VoteId", VoteId).Load();
				return coll;
				
			}
			
			[DataObjectMethod(DataObjectMethodType.Select, true)]public PollVotesCollection FetchByQuery(SubSonic.Query qry)
			{
				
				PollVotesCollection coll = new PollVotesCollection();
				coll.LoadAndCloseReader(qry.ExecuteReader());
				return coll;
				
			}
			[DataObjectMethod(DataObjectMethodType.Delete, true)]public bool Delete(object VoteId)
			{
				
				return (PollVotes.Delete(VoteId) == 1);
				
			}
			[DataObjectMethod(DataObjectMethodType.Delete, false)]public bool Destroy(object VoteId)
			{
				
				return (PollVotes.Destroy(VoteId) == 1);
				
			}
			
			
			/// <summary>
			/// Inserts a record, can be used with the Object Data Source
			/// </summary>
			[DataObjectMethod(DataObjectMethodType.Insert, true)]public void Insert(Guid VoteId, Guid UserId, Guid PollAnswerId, DateTime CreationDate, Guid PollId)
			{
				
				PollVotes item = new PollVotes();
				
				item.VoteId = VoteId;
				
				item.UserId = UserId;
				
				item.PollAnswerId = PollAnswerId;
				
				item.CreationDate = CreationDate;
				
				item.PollId = PollId;
				
				
				item.Save(UserName);
				
			}
			
			/// <summary>
			/// Updates a record, can be used with the Object Data Source
			/// </summary>
			[DataObjectMethod(DataObjectMethodType.Update, true)]public void Update(Guid VoteId, Guid UserId, Guid PollAnswerId, DateTime CreationDate, Guid PollId)
			{
				
				PollVotes item = new PollVotes();
				
				item.VoteId = VoteId;
				
				item.UserId = UserId;
				
				item.PollAnswerId = PollAnswerId;
				
				item.CreationDate = CreationDate;
				
				item.PollId = PollId;
				
				item.MarkOld();
				item.Save(UserName);
				
			}
		}
	}
	
}
