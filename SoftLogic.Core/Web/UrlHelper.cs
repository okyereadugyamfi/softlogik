using System;
using System.Web;
using System.Collections.Specialized;
using System.Text;

namespace Newtonsoft.Utilities.Web
{
	public class UrlHelper
	{
		private string _url;
		private string _target;
		private NameValueCollection _queryStrings;

		public NameValueCollection QueryStrings
		{
			get { return _queryStrings; }
		}

		public string Target
		{
			get { return _target; }
			set { _target = value; }
		}

		public UrlHelper()
		{
			_queryStrings = new NameValueCollection(StringComparer.InvariantCulture);
		}

		public UrlHelper(string url) : this()
		{
			url = HttpUtility.UrlDecode(url);

			int targetStartPosition = url.IndexOf('#');

			// question mark found
			if (targetStartPosition != -1)
			{
				_target = url.Substring(targetStartPosition + 1, url.Length - targetStartPosition - 1);
			}

			int queryStartPosition = url.IndexOf('?');
			string queryString = string.Empty;

			// question mark found
			if (queryStartPosition != -1)
			{
				// get querystring and url without querystring
				queryString = url.Substring(queryStartPosition + 1, url.Length - queryStartPosition - 1);
				url = url.Substring(0, queryStartPosition);

				// split querystring up into fragments
				string[] array = queryString.Split(new char[] { '&', '=' });

				// add to namevaluecollection
				for (int i = 0; i < array.Length - 1; i += 2)
				{
					_queryStrings.Add(array[i], array[i + 1]);
				}
			}

			_url = url;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append(_url);

			if (_queryStrings.AllKeys.Length > 0)
				sb.Append("?");

			foreach (string variableKey in _queryStrings.AllKeys)
			{
				string value = _queryStrings[variableKey];

				if (value != null)
				{
					sb.Append(variableKey);
					sb.Append("=");
					sb.Append(_queryStrings[variableKey]);
					sb.Append("&");
				}
			}

			if (_queryStrings.AllKeys.Length > 0)
				sb.Length = sb.Length - 1;

			if (_target != null)
			{
				sb.Append("#");
				sb.Append(_target);
			}

			return sb.ToString();
		}

		public static string ModifyQueryString(string url, string name, string value, bool addIfNotFound)
		{
			UrlHelper urlHelper = new UrlHelper(url);

			if (urlHelper.QueryStrings[name] != null || addIfNotFound)
				urlHelper.QueryStrings[name] = value;

			return urlHelper.ToString();
		}
	}
}