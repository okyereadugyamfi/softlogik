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
		/// Controller class for PollReactions
		/// </summary>
		[System.ComponentModel.DataObject()]public partial class PollReactionsController
		{
			
			
			// Preload our schema..
			PollReactions thisSchemaLoad = new PollReactions();
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
			[DataObjectMethod(DataObjectMethodType.Select, true)]public PollReactionsCollection FetchAll()
			{
				
				PollReactionsCollection coll = new PollReactionsCollection();
				Query qry = new Query(PollReactions.Schema);
				coll.LoadAndCloseReader(qry.ExecuteReader());
				return coll;
				
			}
			[DataObjectMethod(DataObjectMethodType.Select, true)]public PollReactionsCollection FetchByID(object ReactionId)
			{
				
				PollReactionsCollection coll = new PollReactionsCollection().Where("ReactionId", ReactionId).Load();
				return coll;
				
			}
			
			[DataObjectMethod(DataObjectMethodType.Select, true)]public PollReactionsCollection FetchByQuery(SubSonic.Query qry)
			{
				
				PollReactionsCollection coll = new PollReactionsCollection();
				coll.LoadAndCloseReader(qry.ExecuteReader());
				return coll;
				
			}
			[DataObjectMethod(DataObjectMethodType.Delete, true)]public bool Delete(object ReactionId)
			{
				
				return (PollReactions.Delete(ReactionId) == 1);
				
			}
			[DataObjectMethod(DataObjectMethodType.Delete, false)]public bool Destroy(object ReactionId)
			{
				
				return (PollReactions.Destroy(ReactionId) == 1);
				
			}
			
			
			/// <summary>
			/// Inserts a record, can be used with the Object Data Source
			/// </summary>
			[DataObjectMethod(DataObjectMethodType.Insert, true)]public void Insert(Guid ReactionId, Guid UserId, DateTime CreationDate, string Reaction, Guid PollId)
			{
				
				PollReactions item = new PollReactions();
				
				item.ReactionId = ReactionId;
				
				item.UserId = UserId;
				
				item.CreationDate = CreationDate;
				
				item.Reaction = Reaction;
				
				item.PollId = PollId;
				
				
				item.Save(UserName);
				
			}
			
			/// <summary>
			/// Updates a record, can be used with the Object Data Source
			/// </summary>
			[DataObjectMethod(DataObjectMethodType.Update, true)]public void Update(Guid ReactionId, Guid UserId, DateTime CreationDate, string Reaction, Guid PollId)
			{
				
				PollReactions item = new PollReactions();
				
				item.ReactionId = ReactionId;
				
				item.UserId = UserId;
				
				item.CreationDate = CreationDate;
				
				item.Reaction = Reaction;
				
				item.PollId = PollId;
				
				item.MarkOld();
				item.Save(UserName);
				
			}
		}
	}
	
}
