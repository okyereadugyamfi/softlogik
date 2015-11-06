#region License
// Copyright (c) 2007 James Newton-King
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SoftLogik.Web.UI.Controls
{
  public class BaseRegularExpressionValidator : BaseValidator
  {
    internal string ValidationExpression
    {
      get
      {
        return (string)ViewState["ValidationExpression"] ?? string.Empty;
      }
      set
      {
        try
        {
          Regex.IsMatch(string.Empty, value);
        }
        catch (Exception exception)
        {
          throw new HttpException(string.Format("{0} is not a valid regular expression.", value), exception);
        }

        ViewState["ValidationExpression"] = value;
      }
    }

    internal static void AddExpandoAttribute(Page page, HtmlTextWriter writer, string controlId, string attributeName, string attributeValue, bool encode)
    {
      if (writer != null)
        writer.AddAttribute(attributeName, attributeValue, encode);
      else
        page.ClientScript.RegisterExpandoAttribute(controlId, attributeName, attributeValue, encode);
    }

    protected override void AddAttributesToRender(HtmlTextWriter writer)
    {
      base.AddAttributesToRender(writer);
      if (RenderUplevel)
      {
        string controlId = ClientID;
        HtmlTextWriter writer2 = ControlUtils.EnableLegacyRendering ? writer : null;
        AddExpandoAttribute(Page, writer2, controlId, "evaluationfunction", "RegularExpressionValidatorEvaluateIsValid", false);

        if (ValidationExpression.Length > 0)
          AddExpandoAttribute(Page, writer2, controlId, "validationexpression", this.ValidationExpression, true);
      }
    }

    protected override bool EvaluateIsValid()
    {
      string input = GetControlValidationValue(ControlToValidate);

      if (input == null || input.Trim().Length == 0)
        return true;

      try
      {
        Match match = Regex.Match(input, ValidationExpression);
        return (match.Success && match.Index == 0 && match.Length == input.Length);
      }
      catch
      {
        return true;
      }
    }
  }
}