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
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ACSGhana.Web.Framework
{
	public sealed class TextSupport
	{
		
		public static void EmptyTextBoxes(System.Web.UI.Control parent, TextBox tb)
		{
			//Loop through all controls
			foreach (System.Web.UI.Control ctrControl in parent.Controls)
			{
				//Check to see if it's a textbox
				if (ctrControl.GetType() == typeof(TextBox))
				{
					//If it is then set the text to String.Empty (empty textbox)
					((TextBox) ctrControl).Text = string.Empty;
					//Set the focus to the textbox you set in the call of the sub
					tb.Focus();
				}
				else if (ctrControl.GetType() == typeof(DropDownList)) //Next check if it's a dropdown list
				{
					//If it is then set its SelectedIndex to 0
					((DropDownList) ctrControl).SelectedIndex = 0;
				}
				if (ctrControl.HasControls())
				{
					//Call itself to get all other controls in other containers
					//Note: Remove the argument tb if you have removed the ByVal tb As TextBox argument in the signature.
					EmptyTextBoxes(ctrControl, tb);
				}
			}
		}
		
		
		const int TRUNCATE_COUNT = 50;
		
		public static string Truncate(string originalInput)
		{
			return Truncate(originalInput, TRUNCATE_COUNT);
		}
		
		public static string Truncate(string originalInput, int wordsLimit)
		{
			if (originalInput != null&& originalInput != "")
			{
				System.Text.StringBuilder output = new System.Text.StringBuilder(originalInput.Length);
				System.Text.StringBuilder input = new System.Text.StringBuilder(originalInput);
				int words = 0;
				bool lastwasWS = true;
				int count = 0;
				
				do
				{
					if (char.IsWhiteSpace(input[count]))
					{
						lastwasWS = true;
					}
					else
					{
						if (lastwasWS)
						{
							words++;
						}
						lastwasWS = false;
					}
					output.Append(input[count]);
					count++;
				} while ((words < wordsLimit || lastwasWS == false) && count < (originalInput.Length));
				
				return output.ToString();
			}
			else
			{
				return "";
			}
		}
		
		
	}
	
}
