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
		/// Controller class for PollQuestions
		/// </summary>
		[System.ComponentModel.DataObject()]public partial class PollQuestionsController
		{
			
			
			// Preload our schema..
			PollQuestions thisSchemaLoad = new PollQuestions();
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
			[DataObjectMethod(DataObjectMethodType.Select, true)]public PollQuestionsCollection FetchAll()
			{
				
				PollQuestionsCollection coll = new PollQuestionsCollection();
				Query qry = new Query(PollQuestions.Schema);
				coll.LoadAndCloseReader(qry.ExecuteReader());
				return coll;
				
			}
			[DataObjectMethod(DataObjectMethodType.Select, true)]public PollQuestionsCollection FetchByID(object PollId)
			{
				
				PollQuestionsCollection coll = new PollQuestionsCollection().Where("PollId", PollId).Load();
				return coll;
				
			}
			
			[DataObjectMethod(DataObjectMethodType.Select, true)]public PollQuestionsCollection FetchByQuery(SubSonic.Query qry)
			{
				
				PollQuestionsCollection coll = new PollQuestionsCollection();
				coll.LoadAndCloseReader(qry.ExecuteReader());
				return coll;
				
			}
			[DataObjectMethod(DataObjectMethodType.Delete, true)]public bool Delete(object PollId)
			{
				
				return (PollQuestions.Delete(PollId) == 1);
				
			}
			[DataObjectMethod(DataObjectMethodType.Delete, false)]public bool Destroy(object PollId)
			{
				
				return (PollQuestions.Destroy(PollId) == 1);
				
			}
			
			
			/// <summary>
			/// Inserts a record, can be used with the Object Data Source
			/// </summary>
			[DataObjectMethod(DataObjectMethodType.Insert, true)]public void Insert(Guid PollId, string Question, DateTime CreationDate, Nullable<Guid> Memberid)
			{
				
				PollQuestions item = new PollQuestions();
				
				item.PollId = PollId;
				
				item.Question = Question;
				
				item.CreationDate = CreationDate;
				
				item.Memberid = Memberid;
				
				
				item.Save(UserName);
				
			}
			
			/// <summary>
			/// Updates a record, can be used with the Object Data Source
			/// </summary>
			[DataObjectMethod(DataObjectMethodType.Update, true)]public void Update(Guid PollId, string Question, DateTime CreationDate, Nullable<Guid> Memberid)
			{
				
				PollQuestions item = new PollQuestions();
				
				item.PollId = PollId;
				
				item.Question = Question;
				
				item.CreationDate = CreationDate;
				
				item.Memberid = Memberid;
				
				item.MarkOld();
				item.Save(UserName);
				
			}
		}
	}
	
}
