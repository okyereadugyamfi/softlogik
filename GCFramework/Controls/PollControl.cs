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
using ACSGhana.Web.Framework.UI.Controls;
using ACSGhana.Web.Framework.Data;



namespace ACSGhana.Web.Framework
{
	namespace UI
	{
		namespace Controls
		{
			
			public class PollControl : WebControl, INamingContainer
			{
				
				private PollQuestion _question;
				public PollQuestion Question
				{
					get
					{
						if (_question == null)
						{
							_question = (PollQuestion) (ViewState["Question"]);
						}
						return _question;
					}
					set
					{
						ViewState["Question"] = value;
					}
				}
				
				public PollAnswersCollection AnswerTable
				{
					get
					{
						return LoadAnswers();
					}
				}
				public bool IsUserAllowedToVote
				{
					get
					{
						if (! Page.User.Identity.IsAuthenticated)
						{
							return false;
						}
						if (Poll.CheckUserAlreadyVoted(Question.PollId, new Guid(Membership.GetUser().ProviderUserKey.ToString())))
						{
							return false;
						}
						return true;
					}
				}
				
				private Guid _selectedPollId;
				
				public Guid SelectedPollId
				{
					get
					{
						return _selectedPollId;
					}
					set
					{
						_selectedPollId = value;
					}
				}
				
				
				private void LoadQuestion()
				{
					if (_selectedPollId == Guid.Empty)
					{
						Question = Poll.GetLatestQuestion();
					}
					else
					{
						Question = Poll.LoadQuestion(_selectedPollId);
					}
				}
				
				private PollAnswersCollection LoadAnswers()
				{
					return Poll.GetAnswersForPollQuestion(Question.PollId);
				}
				
				private bool HasUserAlreadyVoted()
				{
					return Poll.CheckUserAlreadyVoted(Question.PollId, new Guid(Membership.GetUser().ProviderUserKey.ToString()));
				}
				
				protected override void OnLoad(EventArgs e)
				{
					if (! Page.IsPostBack)
					{
						LoadQuestion();
					}
				}
				
				protected override void CreateChildControls()
				{
					base.CreateChildControls();
					CreateControls();
				}
				
				private void CreateControls()
				{
					if (Question == null)
					{
						Label noPollAvailableLabel = new Label();
						noPollAvailableLabel.Text = "No poll available";
						this.Controls.Add(new LiteralControl("<i>"));
						this.Controls.Add(noPollAvailableLabel);
						this.Controls.Add(new LiteralControl("</i>"));
					}
					else
					{
						
					}
					//Hyperlink
					HyperLink hyp = new HyperLink();
					hyp.NavigateUrl = "~/portal/evaluation/poll/List.aspx";
					hyp.Text = "All polls";
					
					this.Controls.Add(hyp);
					this.Controls.Add(new LiteralControl("<br/>"));
					this.Controls.Add(new LiteralControl("<br/>"));
					
					//Question
					Label questionLabel = new Label();
					questionLabel.Text = Question.Question;
					questionLabel.Style.Add(HtmlTextWriterStyle.FontWeight, "bold");
					this.Controls.Add(questionLabel);
					
					this.Controls.Add(new LiteralControl("<br/>"));
					
					//Me.Controls.Add(New LiteralControl("<ul>"))
					
					if (IsUserAllowedToVote)
					{
						
						RadioButtonList rbl = new RadioButtonList();
						//The LinkButton Answers
						
						foreach (PollAnswers answer in AnswerTable)
						{
							rbl.Items.Add(new ListItem(answer.Answer, answer.PollAnswerId.ToString()));
						}
						
						this.Controls.Add(rbl);
						this.Controls.Add(new LiteralControl("<br />"));
						
						//only render the SubmitButton when there are answers
						if (AnswerTable.Count > 0)
						{
							System.Web.UI.WebControls.Button rlb = new System.Web.UI.WebControls.Button();
							rlb.Text = "Submit";
							rlb.Click += new System.EventHandler(SubmitButton_Click);
							
							this.Controls.Add(rlb);
						}
						
						this.Controls.Add(new LiteralControl("<br />"));
						
						
					}
					else
					{
						this.Controls.Add(new LiteralControl("<ul>"));
						//The Label answers
						
						foreach (PollAnswers row in AnswerTable)
						{
							decimal percentage = ComputePercentage(Poll.NumberOfVotesByAnswer(row.PollAnswerId));
							
							this.Controls.Add(new LiteralControl("<li>"));
							
							Label answerLabel = new Label();
							answerLabel.Text = string.Format("{0}:", row.Answer);
							this.Controls.Add(answerLabel);
							
							this.Controls.Add(new LiteralControl("<br/>"));
							
							System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
							img.ImageUrl = "~/images/pixel.png";
							img.Height = new Unit(7);
							img.Width = new Unit(percentage.ToString());
							this.Controls.Add(img);
							
							Label percentageLabel = new Label();
							percentageLabel.Text = string.Format(" ({0}%)", percentage.ToString());
							this.Controls.Add(percentageLabel);
							
							this.Controls.Add(new LiteralControl("</li>"));
						}
						this.Controls.Add(new LiteralControl("</ul>"));
						
						
						//The summary
						HyperLink summaryLink = new HyperLink();
						string ttlvotes = Poll.CountTotalVotes(Question.PollId).ToString();
						if (ttlvotes == "1")
						{
							summaryLink.Text = string.Format("{0} vote", ttlvotes);
						}
						else
						{
							summaryLink.Text = string.Format("{0} votes", ttlvotes);
						}
						
						summaryLink.NavigateUrl = "~/portal/evaluation/poll/View.aspx?PollId=" + Question.PollId.ToString();
						this.Controls.Add(summaryLink);
						
						this.Controls.Add(new LiteralControl("<br/>"));
						
						HyperLink totalReactionsLink = new HyperLink();
						string ttlrxns = Poll.CountTotalReactions(Question.PollId).ToString();
						if (ttlrxns == "1")
						{
							totalReactionsLink.Text = string.Format("{0} reactie", ttlrxns);
						}
						else
						{
							totalReactionsLink.Text = string.Format("{0} reacties", ttlrxns);
						}
						
						totalReactionsLink.NavigateUrl = "~/portal/evaluation/poll/View.aspx?PollId=" + Question.PollId.ToString();
						this.Controls.Add(totalReactionsLink);
					}
					
					//Administrator section
					if (Page.User.IsInRole("Administrators"))
					{
						this.Controls.Add(new LiteralControl("<br/>"));
						this.Controls.Add(new LiteralControl("<br/>"));
						System.Web.UI.WebControls.Button adminLinkButton = new System.Web.UI.WebControls.Button();
						adminLinkButton.PostBackUrl = "~/portal/evaluation/poll/Manage.aspx";
						adminLinkButton.Text = "Manage Polls";
						this.Controls.Add(adminLinkButton);
					}
				}
				protected void SubmitButton_Click(object sender, EventArgs e)
				{
					if (!(((RadioButtonList) (this.Controls[5])) ).SelectedValue == null)
					{
						Poll.Vote(Question.PollId, new Guid((((RadioButtonList) (this.Controls[5])) ).SelectedValue), new Guid(Membership.GetUser().ProviderUserKey.ToString()));
						
						this.Controls.Clear();
						LoadAnswers();
						CreateControls();
					}
				}
				
				
				private decimal ComputePercentage(decimal numberOfVotes)
				{
					decimal percentage = 0;
					int totalVotes = Poll.CountTotalVotes(_question.PollId);
					if (totalVotes > 0)
					{
						percentage = System.Math.Round((numberOfVotes / totalVotes) * 100, 0);
					}
					return percentage;
				}
				
			}
		}
	}
	
}
