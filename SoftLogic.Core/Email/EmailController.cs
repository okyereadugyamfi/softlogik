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
using System.Collections.Generic;
using System.Net.Mail;
using System.Xml;
using System.Xml.Xsl;
using SoftLogik.Miscellaneous;
using SoftLogik.Collections;
using SoftLogik.Xml;
using System.IO;
using System.Xml.XPath;

namespace SoftLogik.Email
{
  public class EmailController
  {
    private IEmailSender _emailSender;

    private readonly MailAddress _fromEmailAddress;
    private readonly IList<MailAddress> _overrideEmailAddresses;
    private readonly IList<MailAddress> _bccEmailAddresses;
    private readonly string _emailTemplateDirectoryPath;
    private readonly bool _emailSendingEnabled;

    public IEmailSender EmailSender
    {
      get { return _emailSender; }
      set { _emailSender = value; }
    }

    public EmailController(IList<MailAddress> overrideEmailAddresses,
            MailAddress fromEmailAddress,
            IList<MailAddress> bccEmailAddresses,
            string emailTemplateDirectoryPath,
            bool emailSendingEnabled)
    {
      _overrideEmailAddresses = overrideEmailAddresses;
      _fromEmailAddress = fromEmailAddress;
      _bccEmailAddresses = bccEmailAddresses;
      _emailTemplateDirectoryPath = emailTemplateDirectoryPath;
      _emailSendingEnabled = emailSendingEnabled;
    }

    /// <summary>
    /// Transforms the XSL template and extracts the subject and body from the result.
    /// </summary>
    /// <param name="xslTemplatePath">The XSL template path.</param>
    /// <param name="arguments">The arguments passed to the XSL transformation.</param>
    /// <param name="subject">The extracted subject.</param>
    /// <param name="messageBody">The extracted message body.</param>
    public void ExtractEmailDetailsFromTemplate(string xslTemplatePath, XsltArgumentList arguments, out string subject, out string messageBody)
    {
      XmlDocument initialDoc = new XmlDocument();
      XmlElement rootEmailElement = initialDoc.CreateElement("Email");
      initialDoc.AppendChild(rootEmailElement);
      rootEmailElement.AppendChild(initialDoc.CreateElement("MessageSubject"));
      rootEmailElement.AppendChild(initialDoc.CreateElement("MessageBody"));

      XmlResourceResolver resourceResolver = new XmlResourceResolver(GetType().Assembly);

      XPathDocument resultDoc;

      using (XmlReader templateXmlReader = XmlReader.Create(xslTemplatePath))
      using (XmlReader initialXmlReader = new XmlNodeReader(initialDoc))
      using (XmlReader resultXmlReader = XslUtils.TransformXml(initialXmlReader, templateXmlReader, arguments, resourceResolver))
      {
        resultDoc = new XPathDocument(resultXmlReader);
      }

      XPathNavigator navigator = resultDoc.CreateNavigator();

      subject = XPathUtils.SelectNodeText(navigator, "Email/MessageSubject/text()");
      subject = subject.Trim();

      messageBody = XPathUtils.SelectNodeXml(navigator, "Email/MessageBody");
    }

    /// <summary>
    /// Sends an email message sychronously (blocks until complete) from the given address
    /// to the given address, with the specified subject and message body.
    /// </summary>
    /// <param name="fromEmailAddress">The sender's return email address.</param>
    /// <param name="toEmailAddresses">The receipients email addresses.</param>
    /// <param name="xslTemplateFileName">File name of the desired XSL template file.</param>
    /// <param name="parameters">Parameters passed to the XSL transformation.</param>
    /// <param name="attachments">A collection of attachments to send.</param>
    public void SendEmail(MailAddress fromEmailAddress, IList<MailAddress> toEmailAddresses, string xslTemplateFileName, IDictionary<string, object> parameters, IList<Attachment> attachments)
    {
      XsltArgumentList args = null;

      if (parameters != null)
        args = XslUtils.ToXsltArgumentList(parameters);

      SendEmail(fromEmailAddress, toEmailAddresses, xslTemplateFileName, args, attachments);
    }

    public void SendEmail(IList<MailAddress> toEmailAddresses, string xslTemplateFileName, IDictionary<string, object> parameters, IList<Attachment> attachments)
    {
      SendEmail(null, toEmailAddresses, xslTemplateFileName, parameters, attachments);
    }

    public void SendEmail(MailAddress fromEmailAddress, MailAddressCollection toEmailAddresses, string xslTemplateFileName, IList<Attachment> attachments)
    {
      SendEmail(fromEmailAddress, toEmailAddresses, xslTemplateFileName, (XsltArgumentList)null, attachments);
    }

    /// <summary>
    /// Sends an email message sychronously (blocks until complete) from the given address
    /// to the given address, with the specified subject and message body.
    /// </summary>
    /// <param name="fromEmailAddress">The sender's return email address.</param>
    /// <param name="toEmailAddresses">The receipients email addresses.</param>
    /// <param name="xslTemplateFileName">File name of the desired XSL template file.</param>
    /// <param name="attachments">A collection of attachments to send.</param>
    public void SendEmail(MailAddress fromEmailAddress, IList<MailAddress> toEmailAddresses, string xslTemplateFileName, XsltArgumentList arguments, IList<Attachment> attachments)
    {
      string subject;
      string messageBody;

      string xslTemplatePath;
      if (!string.IsNullOrEmpty(_emailTemplateDirectoryPath))
        xslTemplatePath = Path.Combine(_emailTemplateDirectoryPath, xslTemplateFileName);
      else 
        xslTemplatePath = xslTemplateFileName;

      ExtractEmailDetailsFromTemplate(xslTemplatePath, arguments, out subject, out messageBody);

      SendEmail(fromEmailAddress, toEmailAddresses, subject, messageBody, true, attachments);
    }

    /// <summary>
    /// Sends an email message sychronously (blocks until complete) from the given address
    /// to the given address, with the specified subject and message body.
    /// </summary>
    /// <param name="fromEmailAddress">The sender's return email address.</param>
    /// <param name="toEmailAddresses">The receipients email addresses.</param>
    /// <param name="subject">The email message subject.</param>
    /// <param name="messageBody">The email message body.</param>
    /// <param name="attachments">A collection of attachments to send.</param>
    public void SendEmail(MailAddress fromEmailAddress, IList<MailAddress> toEmailAddresses, string subject, string messageBody, bool isBodyHtml, IList<Attachment> attachments)
    {
      if (_emailSender == null)
        throw new InvalidOperationException("No email sender set on controller.");

      MailMessage mailMessage = BuildMailMessage(fromEmailAddress, toEmailAddresses, subject, messageBody, isBodyHtml, attachments);

      if (_emailSendingEnabled)
        _emailSender.SendMail(mailMessage);
    }

    private MailMessage BuildMailMessage(MailAddress fromEmailAddress, IList<MailAddress> toEmailAddresses, string subject, string messageBody, bool isBodyHtml, IList<Attachment> attachments)
    {
      ValidationUtils.ArgumentNotNullOrEmpty<MailAddress>(toEmailAddresses, "toEmailAddresses", "No to email address(es) provided.");

      MailAddress resolvedFromEmailAddress = ResolveFromEmailAddress(fromEmailAddress);

      IList<MailAddress> resolvedToEmailAddresses;

      // override email address if specified in web config
      if (!CollectionUtils.IsNullOrEmpty(_overrideEmailAddresses))
      {
        resolvedToEmailAddresses = new List<MailAddress>();
        subject = subject + " (Message intended for: " + toEmailAddresses + ")";
        CollectionUtils.AddRange<MailAddress>(resolvedToEmailAddresses, _overrideEmailAddresses);
      }
      else
      {
        resolvedToEmailAddresses = toEmailAddresses;
      }

      MailMessage mailMessage = new MailMessage();
      mailMessage.From = resolvedFromEmailAddress;
      CollectionUtils.AddRange<MailAddress>(mailMessage.To, resolvedToEmailAddresses);
      CollectionUtils.AddRange<MailAddress>(mailMessage.Bcc, _bccEmailAddresses);
      mailMessage.Subject = subject;
      mailMessage.Body = messageBody;
      mailMessage.IsBodyHtml = isBodyHtml;

      CollectionUtils.AddRange<Attachment>(mailMessage.Attachments, attachments);

      return mailMessage;
    }

    private MailAddress ResolveFromEmailAddress(MailAddress fromEmailAddress)
    {
      // if we have no from address, then use the default from address in the config file
      if (fromEmailAddress == null)
      {
        if (_fromEmailAddress == null)
          throw new ArgumentNullException("fromEmailAddress", "No fromEmailAddress specified and no default from email address was given to the EmailController.");

        fromEmailAddress = _fromEmailAddress;
      }

      return fromEmailAddress;
    }
  }
}