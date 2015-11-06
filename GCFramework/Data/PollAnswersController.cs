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
		/// Controller class for PollAnswers
		/// </summary>
		[System.ComponentModel.DataObject()]public partial class PollAnswersController
		{
			
			
			// Preload our schema..
			PollAnswers thisSchemaLoad = new PollAnswers();
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
			[DataObjectMethod(DataObjectMethodType.Select, true)]public PollAnswersCollection FetchAll()
			{
				
				PollAnswersCollection coll = new PollAnswersCollection();
				Query qry = new Query(PollAnswers.Schema);
				coll.LoadAndCloseReader(qry.ExecuteReader());
				return coll;
				
			}
			[DataObjectMethod(DataObjectMethodType.Select, true)]public PollAnswersCollection FetchByID(object PollAnswerId)
			{
				
				PollAnswersCollection coll = new PollAnswersCollection().Where("PollAnswerId", PollAnswerId).Load();
				return coll;
				
			}
			
			[DataObjectMethod(DataObjectMethodType.Select, true)]public PollAnswersCollection FetchByQuery(SubSonic.Query qry)
			{
				
				PollAnswersCollection coll = new PollAnswersCollection();
				coll.LoadAndCloseReader(qry.ExecuteReader());
				return coll;
				
			}
			[DataObjectMethod(DataObjectMethodType.Delete, true)]public bool Delete(object PollAnswerId)
			{
				
				return (PollAnswers.Delete(PollAnswerId) == 1);
				
			}
			[DataObjectMethod(DataObjectMethodType.Delete, false)]public bool Destroy(object PollAnswerId)
			{
				
				return (PollAnswers.Destroy(PollAnswerId) == 1);
				
			}
			
			
			/// <summary>
			/// Inserts a record, can be used with the Object Data Source
			/// </summary>
			[DataObjectMethod(DataObjectMethodType.Insert, true)]public void Insert(Guid PollAnswerId, Guid QuestionId, string Answer, Nullable<int> Rank)
			{
				
				PollAnswers item = new PollAnswers();
				
				item.PollAnswerId = PollAnswerId;
				
				item.QuestionId = QuestionId;
				
				item.Answer = Answer;
				
				item.Rank = Rank;
				
				
				item.Save(UserName);
				
			}
			
			/// <summary>
			/// Updates a record, can be used with the Object Data Source
			/// </summary>
			[DataObjectMethod(DataObjectMethodType.Update, true)]public void Update(Guid PollAnswerId, Guid QuestionId, string Answer, Nullable<int> Rank)
			{
				
				PollAnswers item = new PollAnswers();
				
				item.PollAnswerId = PollAnswerId;
				
				item.QuestionId = QuestionId;
				
				item.Answer = Answer;
				
				item.Rank = Rank;
				
				item.MarkOld();
				item.Save(UserName);
				
			}
		}
	}
	
}
