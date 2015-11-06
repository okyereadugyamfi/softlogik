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
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SubSonic;
using ACSGhana.Web.Framework.Data;



namespace ACSGhana.Web.Framework
{
	[Serializable()]public class PollQuestion
	{
		
		private Guid _pollId;
		private string _question;
		private DateTime _creationDate;
		
		public Guid PollId
		{
			get
			{
				return _pollId;
			}
			set
			{
				_pollId = value;
			}
		}
		
		public string Question
		{
			get
			{
				return _question;
			}
			set
			{
				_question = value;
			}
		}
		
		public DateTime CreationDate
		{
			get
			{
				return _creationDate;
			}
			set
			{
				_creationDate = value;
			}
		}
	}
	
	public class Poll
	{
		
		
		public static PollQuestion LoadQuestion(Guid pollId)
		{
			if (pollId == Guid.Empty)
			{
				return null;
			}
			
			PollQuestions quest = new PollQuestions(PollQuestions.Columns.PollId, pollId);
			PollQuestion q = new PollQuestion();
			q.PollId = pollId;
			q.Question = quest.Question;
			q.CreationDate = quest.CreationDate;
			return q;
		}
		
		public static PollQuestion GetLatestQuestion()
		{
			
			Query qry = new Query(ACSGhana.Web.Framework.Data.Tables.PollQuestions);
			qry.Top = "1";
			qry.OrderBy = OrderBy.Desc(PollQuestions.Columns.CreationDate);
			qry.SelectList = PollQuestions.Columns.PollId + "," + PollQuestions.Columns.Question + "," + PollQuestions.Columns.CreationDate;
			
			IDataReader rdr = qry.ExecuteReader();
			PollQuestion q = new PollQuestion();
			while (rdr.Read())
			{
				q.PollId = rdr.GetGuid(0);
				q.Question = rdr.GetString(1);
				q.CreationDate = rdr.GetDateTime(2);
			}
			rdr.Close();
			return q;
		}
		
		public static PollQuestionsCollection LoadQuestions()
		{
			IDataReader rdr = PollQuestions.FetchAll();
			PollQuestionsCollection col = new PollQuestionsCollection();
			col.LoadAndCloseReader(rdr);
			return col;
		}
		
		public static bool CheckUserAlreadyVoted(Guid pollId, Guid userId)
		{
			Query qry = new Query(ACSGhana.Web.Framework.Data.Tables.PollVotes);
			qry.AddWhere(PollVotes.Columns.PollId, pollId);
			qry.AddWhere(PollVotes.Columns.UserId, userId);
			if (qry.GetRecordCount() > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		public static int CountTotalVotes(Guid pollId)
		{
			Query qry = new Query(ACSGhana.Web.Framework.Data.Tables.PollVotes);
			qry.AddWhere(PollVotes.Columns.PollId, pollId);
			return qry.GetRecordCount();
		}
		
		public static int CountTotalReactions(Guid pollId)
		{
			Query qry = new Query(ACSGhana.Web.Framework.Data.Tables.PollReactions);
			qry.AddWhere(PollReactions.Columns.PollId, pollId);
			return qry.GetRecordCount();
		}
		
		public static void Vote(Guid pollId, Guid answerId, Guid userId)
		{
			PollVotes.Insert(Guid.NewGuid(), userId, answerId, DateTime.Now, pollId);
		}
		
		public static void AddPollReaction(string reaction, Guid pollId, Guid userId)
		{
			PollReactions.Insert(Guid.NewGuid(), userId, DateTime.Now, reaction, pollId);
		}
		
		public static void DeleteReaction(Guid reactionId)
		{
			PollReactions.Delete(PollReactions.Columns.ReactionId, reactionId);
		}
		
		public static PollAnswersCollection GetAnswersForPollQuestion(Guid pollQuestionId)
		{
			if (pollQuestionId == Guid.Empty)
			{
				return null;
			}
			
			IDataReader rdr = PollAnswers.FetchByParameter(PollAnswers.Columns.QuestionId, pollQuestionId);
			PollAnswersCollection col = new PollAnswersCollection();
			col.LoadAndCloseReader(rdr);
			return col;
		}
		
		public static PollReactionsCollection GetReactionsForPollQuestion(Guid pollQuestionId)
		{
			if (pollQuestionId == Guid.Empty)
			{
				return null;
			}
			
			IDataReader rdr = PollReactions.FetchByParameter(PollReactions.Columns.PollId, pollQuestionId);
			PollReactionsCollection col = new PollReactionsCollection();
			col.LoadAndCloseReader(rdr);
			return col;
		}
		
		public static int NumberOfVotesByAnswer(System.Guid answerid)
		{
			Query qry = new Query(ACSGhana.Web.Framework.Data.Tables.PollVotes);
			qry.AddWhere(PollVotes.Columns.PollAnswerId, answerid);
			return qry.GetRecordCount();
		}
		
		[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]public static IDataReader SelectAllQuestions()
		{
			return Data.PollQuestions.FetchAll();
		}
		
		[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, false)]public static void InsertQuestion(System.Guid PollId, string Question, DateTime CreationDate, System.Guid Memberid)
		{
			Data.PollQuestions.Insert(PollId, Question, CreationDate, Memberid);
		}
		
		[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, false)]public static void UpdateQuestion(System.Guid PollId, string Question, DateTime CreationDate, System.Guid Memberid)
		{
			Data.PollQuestions.Update(PollId, Question, CreationDate, Memberid);
		}
		
		[System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, false)]public static void DeleteQuestion(System.Guid PollId)
		{
			Data.PollQuestions.Delete(PollQuestions.Columns.PollId, PollId);
		}
	}
	
}
