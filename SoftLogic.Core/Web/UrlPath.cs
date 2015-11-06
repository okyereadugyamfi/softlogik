using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;

namespace Newtonsoft.Utilities.Web
{
	public class UrlPath
	{
		// Fields
		internal const char appRelativeCharacter = '~';
		internal const string appRelativeCharacterString = "~";
		private const string dummyProtocolAndServer = "file://foo";
		private static char[] s_slashChars;

		// Methods
		static UrlPath()
		{
			char[] chArray1 = new char[2] { '\\', '/' };
			UrlPath.s_slashChars = chArray1;
		}

		//public static string AppendSlashToPathIfNeeded(string path)
		//{
		//    if (path == null)
		//    {
		//        return null;
		//    }
		//    int num1 = path.Length;
		//    if ((num1 != 0) && (path[num1 - 1] != '/'))
		//    {
		//        path = path + '/';
		//    }
		//    return path;
		//}

		//public static void CheckValidVirtualPath(string path)
		//{
		//    if (UrlPath.IsAbsolutePhysicalPath(path))
		//    {
		//        object[] objArray1 = new object[1] { path };
		//        throw new HttpException(string.Format("'{0}' is a physical path, but a virtual path was expected.", objArray1));
		//    }
		//    if (path.IndexOf(':') >= 0)
		//    {
		//        object[] objArray2 = new object[1] { path };
		//        throw new HttpException(string.Format("'{0}' is not a valid virtual path.", objArray2));
		//    }
		//}

		//public static string Combine(string basepath, string relative)
		//{
		//    return UrlPath.Combine(HttpRuntime.AppDomainAppVirtualPath, basepath, relative);
		//}

		//public static string Combine(string appPath, string basepath, string relative)
		//{
		//    string text1;
		//    if (string.IsNullOrEmpty(relative))
		//    {
		//        throw new ArgumentNullException("relative");
		//    }
		//    if (string.IsNullOrEmpty(basepath))
		//    {
		//        throw new ArgumentNullException("basepath");
		//    }
		//    UrlPath.CheckValidVirtualPath(relative);
		//    if (UrlPath.IsRooted(relative))
		//    {
		//        text1 = relative;
		//    }
		//    else
		//    {
		//        if ((relative.Length == 1) && (relative[0] == '~'))
		//        {
		//            return appPath;
		//        }
		//        if (UrlPath.IsAppRelativePath(relative))
		//        {
		//            if (appPath.Length > 1)
		//            {
		//                text1 = appPath + "/" + relative.Substring(2);
		//            }
		//            else
		//            {
		//                text1 = "/" + relative.Substring(2);
		//            }
		//        }
		//        else
		//        {
		//            text1 = UrlPath.SimpleCombine(basepath, relative);
		//        }
		//    }
		//    return UrlPath.Reduce(text1);
		//}

		//public static string FixVirtualPathSlashes(string virtualPath)
		//{
		//    virtualPath = virtualPath.Replace('\\', '/');
		//    while (true)
		//    {
		//        string text1 = virtualPath.Replace("//", "/");
		//        if (text1.Length == virtualPath.Length)
		//        {
		//            break;
		//        }
		//        virtualPath = text1;
		//    }
		//    return virtualPath;
		//}

		//public static string GetDirectory(string path)
		//{
		//    if (string.IsNullOrEmpty(path))
		//    {
		//        throw new ArgumentException(string.Format("Empty path has no directory."));
		//    }
		//    if ((path[0] != '/') && (path[0] != '~'))
		//    {
		//        object[] objArray1 = new object[1] { path };
		//        throw new ArgumentException(string.Format("The virtual path '{0}' is not rooted.", objArray1));
		//    }
		//    if (path.Length == 1)
		//    {
		//        return path;
		//    }
		//    int num1 = path.LastIndexOf('/');
		//    if (num1 < 0)
		//    {
		//        object[] objArray2 = new object[1] { path };
		//        throw new ArgumentException(string.Format("The virtual path '{0}' is not rooted.", objArray2));
		//    }
		//    string text1 = path.Substring(0, num1);
		//    if (text1.Length == 0)
		//    {
		//        return "/";
		//    }
		//    return text1;
		//}

		//public static string GetDirectoryOrRootName(string path)
		//{
		//    string text1 = Path.GetDirectoryName(path);
		//    if (text1 == null)
		//    {
		//        text1 = Path.GetPathRoot(path);
		//    }
		//    return text1;
		//}

		//public static string GetExtension(string virtualPath)
		//{
		//    return Path.GetExtension(virtualPath);
		//}

		//public static string GetFileName(string virtualPath)
		//{
		//    return Path.GetFileName(virtualPath);
		//}

		//public static string GetFileNameWithoutExtension(string virtualPath)
		//{
		//    return Path.GetFileNameWithoutExtension(virtualPath);
		//}

		//public static string GetParentPath(string path)
		//{
		//    if (((path == null) || (path.Length <= 1)) || (path[0] != '/'))
		//    {
		//        return null;
		//    }
		//    int num1 = path.LastIndexOf('/');
		//    if (num1 < 0)
		//    {
		//        return null;
		//    }
		//    if (num1 == 0)
		//    {
		//        return "/";
		//    }
		//    return path.Substring(0, num1);
		//}

		//public static bool IsAbsolutePhysicalPath(string path)
		//{
		//    if ((path != null) && (path.Length >= 3))
		//    {
		//        if ((path[1] == ':') && UrlPath.IsDirectorySeparatorChar(path[2]))
		//        {
		//            return true;
		//        }
		//        if (UrlPath.IsDirectorySeparatorChar(path[0]) && UrlPath.IsDirectorySeparatorChar(path[1]))
		//        {
		//            return true;
		//        }
		//    }
		//    return false;
		//}

		//public static bool IsAppRelativePath(string path)
		//{
		//    if (path == null)
		//    {
		//        return false;
		//    }
		//    int num1 = path.Length;
		//    if (num1 == 0)
		//    {
		//        return false;
		//    }
		//    if (path[0] != '~')
		//    {
		//        return false;
		//    }
		//    if ((num1 != 1) && (path[1] != '\\'))
		//    {
		//        return (path[1] == '/');
		//    }
		//    return true;
		//}

		//private static bool IsDirectorySeparatorChar(char ch)
		//{
		//    if (ch != '\\')
		//    {
		//        return (ch == '/');
		//    }
		//    return true;
		//}

		//public static bool IsEqualOrSubpath(string path, string subpath)
		//{
		//    if (!string.IsNullOrEmpty(path))
		//    {
		//        if (string.IsNullOrEmpty(subpath))
		//        {
		//            return false;
		//        }
		//        int num1 = path.Length;
		//        if (path[num1 - 1] == '/')
		//        {
		//            num1--;
		//        }
		//        int num2 = subpath.Length;
		//        if (subpath[num2 - 1] == '/')
		//        {
		//            num2--;
		//        }
		//        if (num2 < num1)
		//        {
		//            return false;
		//        }
		//        if (string.Compare(path, 0, subpath, 0, num1, true, CultureInfo.InvariantCulture) != 0)
		//        {
		//            return false;
		//        }
		//        if ((num2 > num1) && (subpath[num1] != '/'))
		//        {
		//            return false;
		//        }
		//    }
		//    return true;
		//}

		//public static bool IsFullPath(string path)
		//{
		//    if (!string.IsNullOrEmpty(path))
		//    {
		//        return (path[0] == '/');
		//    }
		//    return false;
		//}

		//public static bool IsPathOnSameServer(string absUriOrLocalPath, Uri currentRequestUri)
		//{
		//    Uri uri1;
		//    if (Uri.TryCreate(absUriOrLocalPath, UriKind.Absolute, out uri1) && !uri1.IsLoopback)
		//    {
		//        return string.Equals(currentRequestUri.Host, uri1.Host, StringComparison.InvariantCultureIgnoreCase);
		//    }
		//    return true;
		//}

		public static bool IsRelativeUrl(string virtualPath)
		{
			if (virtualPath.IndexOf(":") != -1)
			{
				return false;
			}
			return !UrlPath.IsRooted(virtualPath);
		}

		public static bool IsRooted(string basepath)
		{
			if (!string.IsNullOrEmpty(basepath) && (basepath[0] != '/'))
			{
				return (basepath[0] == '\\');
			}
			return true;
		}

		//public static bool IsValidVirtualPathWithoutProtocol(string path)
		//{
		//    if (path == null)
		//    {
		//        return false;
		//    }
		//    if (path.IndexOf(":") != -1)
		//    {
		//        return false;
		//    }
		//    return true;
		//}

		//public static string MakeRelative(string from, string to)
		//{
		//    string text2;
		//    from = UrlPath.MakeVirtualPathAppAbsolute(from);
		//    to = UrlPath.MakeVirtualPathAppAbsolute(to);
		//    if (!UrlPath.IsRooted(from))
		//    {
		//        object[] objArray1 = new object[1] { from };
		//        throw new ArgumentException(string.Format("The virtual path '{0}' is not rooted.", objArray1));
		//    }
		//    if (!UrlPath.IsRooted(to))
		//    {
		//        object[] objArray2 = new object[1] { to };
		//        throw new ArgumentException(string.Format("The virtual path '{0}' is not rooted.", objArray2));
		//    }
		//    string text1 = null;
		//    if (to != null)
		//    {
		//        int num1 = to.IndexOf('?');
		//        if (num1 >= 0)
		//        {
		//            text1 = to.Substring(num1);
		//            to = to.Substring(0, num1);
		//        }
		//    }
		//    Uri uri1 = new Uri("file://foo" + from);
		//    Uri uri2 = new Uri("file://foo" + to);
		//    if (uri1.Equals(uri2))
		//    {
		//        int num2 = to.LastIndexOfAny(UrlPath.s_slashChars);
		//        if (num2 >= 0)
		//        {
		//            if (num2 == (to.Length - 1))
		//            {
		//                text2 = "./";
		//            }
		//            else
		//            {
		//                text2 = to.Substring(num2 + 1);
		//            }
		//        }
		//        else
		//        {
		//            text2 = to;
		//        }
		//    }
		//    else
		//    {
		//        text2 = uri1.MakeRelative(uri2);
		//    }
		//    return (text2 + text1 + uri2.Fragment);
		//}

		//public static string MakeVirtualPathAppAbsolute(string virtualPath)
		//{
		//    return UrlPath.MakeVirtualPathAppAbsolute(virtualPath, HttpRuntime.AppDomainAppVirtualPath);
		//}

		//public static string MakeVirtualPathAppAbsolute(string virtualPath, string applicationPath)
		//{
		//    if ((virtualPath.Length == 1) && (virtualPath[0] == '~'))
		//    {
		//        return applicationPath;
		//    }
		//    if (((virtualPath.Length >= 2) && (virtualPath[0] == '~')) && ((virtualPath[1] == '/') || (virtualPath[1] == '\\')))
		//    {
		//        if (applicationPath.Length > 1)
		//        {
		//            return (applicationPath + "/" + virtualPath.Substring(2));
		//        }
		//        return ("/" + virtualPath.Substring(2));
		//    }
		//    if (!UrlPath.IsRooted(virtualPath))
		//    {
		//        throw new ArgumentOutOfRangeException("virtualPath");
		//    }
		//    return virtualPath;
		//}

		//public static string MakeVirtualPathAppAbsoluteReduceAndCheck(string virtualPath)
		//{
		//    if (virtualPath == null)
		//    {
		//        throw new ArgumentNullException("virtualPath");
		//    }
		//    string text1 = UrlPath.Reduce(UrlPath.MakeVirtualPathAppAbsolute(virtualPath));
		//    if (!UrlPath.VirtualPathStartsWithAppPath(text1))
		//    {
		//        object[] objArray1 = new object[1] { virtualPath };
		//        throw new ArgumentException(string.Format("The virtual path '{0}' is not a valid absolute virtual path within the current application.", objArray1));
		//    }
		//    return text1;
		//}

		//public static string MakeVirtualPathAppRelative(string virtualPath)
		//{
		//    return UrlPath.MakeVirtualPathAppRelative(virtualPath, HttpRuntime.AppDomainAppVirtualPath);
		//}

		//public static string MakeVirtualPathAppRelative(string virtualPath, string applicationPath)
		//{
		//    if (virtualPath == null)
		//    {
		//        throw new ArgumentNullException("virtualPath");
		//    }
		//    if (!UrlPath.VirtualPathStartsWithVirtualPath(virtualPath, applicationPath))
		//    {
		//        return virtualPath;
		//    }
		//    if (virtualPath.Length == applicationPath.Length)
		//    {
		//        return "~";
		//    }
		//    if (applicationPath.Length == 1)
		//    {
		//        return ('~' + virtualPath);
		//    }
		//    return ('~' + virtualPath.Substring(applicationPath.Length));
		//}

		//public static bool PathEndsWithExtraSlash(string path)
		//{
		//    if (path == null)
		//    {
		//        return false;
		//    }
		//    int num1 = path.Length;
		//    if ((num1 == 0) || (path[num1 - 1] != '\\'))
		//    {
		//        return false;
		//    }
		//    if ((num1 == 3) && (path[1] == ':'))
		//    {
		//        return false;
		//    }
		//    return true;
		//}

		//public static bool PathIsDriveRoot(string path)
		//{
		//    if (((path != null) && (path.Length == 3)) && ((path[1] == ':') && (path[2] == '\\')))
		//    {
		//        return true;
		//    }
		//    return false;
		//}

		//public static string Reduce(string path)
		//{
		//    string text1 = null;
		//    if (path != null)
		//    {
		//        int num1 = path.IndexOf('?');
		//        if (num1 >= 0)
		//        {
		//            text1 = path.Substring(num1);
		//            path = path.Substring(0, num1);
		//        }
		//    }
		//    path = UrlPath.FixVirtualPathSlashes(path);
		//    int num2 = path.Length;
		//    int num3 = 0;
		//    while (true)
		//    {
		//        num3 = path.IndexOf('.', num3);
		//        if (num3 < 0)
		//        {
		//            if (text1 == null)
		//            {
		//                return path;
		//            }
		//            return (path + text1);
		//        }
		//        if (((num3 == 0) || (path[num3 - 1] == '/')) && ((((num3 + 1) == num2) || (path[num3 + 1] == '/')) || ((path[num3 + 1] == '.') && (((num3 + 2) == num2) || (path[num3 + 2] == '/')))))
		//        {
		//            break;
		//        }
		//        num3++;
		//    }
		//    ArrayList list1 = new ArrayList();
		//    StringBuilder builder1 = new StringBuilder();
		//    num3 = 0;
		//    do
		//    {
		//        int num4 = num3;
		//        num3 = path.IndexOf('/', (int) (num4 + 1));
		//        if (num3 < 0)
		//        {
		//            num3 = num2;
		//        }
		//        if ((((num3 - num4) <= 3) && ((num3 < 1) || (path[num3 - 1] == '.'))) && (((num4 + 1) >= num2) || (path[num4 + 1] == '.')))
		//        {
		//            if ((num3 - num4) == 3)
		//            {
		//                if (list1.Count == 0)
		//                {
		//                    throw new HttpException(string.Format("Cannot use a leading .. to exit above the top directory."));
		//                }
		//                if ((list1.Count == 1) && UrlPath.IsAppRelativePath(path))
		//                {
		//                    return UrlPath.Reduce(UrlPath.MakeVirtualPathAppAbsolute(path));
		//                }
		//                builder1.Length = (int) list1[list1.Count - 1];
		//                list1.RemoveRange(list1.Count - 1, 1);
		//            }
		//        }
		//        else
		//        {
		//            list1.Add(builder1.Length);
		//            builder1.Append(path, num4, (int) (num3 - num4));
		//        }
		//    }
		//    while (num3 != num2);
		//    string text2 = builder1.ToString();
		//    if (text2.Length == 0)
		//    {
		//        if ((num2 > 0) && (path[0] == '/'))
		//        {
		//            text2 = "/";
		//        }
		//        else
		//        {
		//            text2 = ".";
		//        }
		//    }
		//    return (text2 + text1);
		//}

		//public static string RemoveSlashFromPathIfNeeded(string path)
		//{
		//    if (string.IsNullOrEmpty(path))
		//    {
		//        return null;
		//    }
		//    int num1 = path.Length;
		//    if ((num1 > 1) && (path[num1 - 1] == '/'))
		//    {
		//        return path.Substring(0, num1 - 1);
		//    }
		//    return path;
		//}

		//public static string SimpleCombine(string basepath, string relative)
		//{
		//    if ((basepath == null) || ((basepath.Length == 1) && (basepath[0] == '/')))
		//    {
		//        basepath = string.Empty;
		//    }
		//    return (basepath + "/" + relative);
		//}

		//public static bool VirtualPathStartsWithAppPath(string virtualPath)
		//{
		//    return UrlPath.VirtualPathStartsWithVirtualPath(virtualPath, HttpRuntime.AppDomainAppVirtualPath);
		//}

		//public static bool VirtualPathStartsWithVirtualPath(string virtualPath1, string virtualPath2)
		//{
		//    if (virtualPath1 == null)
		//    {
		//        throw new ArgumentNullException("virtualPath1");
		//    }
		//    if (virtualPath2 == null)
		//    {
		//        throw new ArgumentNullException("virtualPath2");
		//    }
		//    if (!StringStartsWithIgnoreCase(virtualPath1, virtualPath2))
		//    {
		//        return false;
		//    }
		//    if (virtualPath1.Length != virtualPath2.Length)
		//    {
		//        if (virtualPath2.Length == 1)
		//        {
		//            return true;
		//        }
		//        if (virtualPath1[virtualPath2.Length] != '/')
		//        {
		//            return false;
		//        }
		//    }
		//    return true;
		//}

		//public static bool StringStartsWithIgnoreCase(string s1, string s2)
		//{
		//    if (s2.Length > s1.Length)
		//    {
		//        return false;
		//    }
		//    return (0 == string.Compare(s1, 0, s2, 0, s2.Length, true, CultureInfo.InvariantCulture));
		//}

		//public static bool VPathEndsWithExtraSlash(string path)
		//{
		//    if ((path == null) || (path == "/"))
		//    {
		//        return false;
		//    }
		//    int num1 = path.Length;
		//    if (num1 <= 0)
		//    {
		//        return false;
		//    }
		//    if (path[num1 - 1] != '/')
		//    {
		//        return (path[num1 - 1] == '\\');
		//    }
		//    return true;
		//}
	}
}

//using System;
//using System.Collections;
//using System.Globalization;
//using System.IO;
//using System.Text;
//using System.Web;

//namespace Newtonsoft.Utilities.Web
//{
//    public class UrlPath
//    {
//        // Fields
//        internal const char appRelativeCharacter = '~';
//        internal const string appRelativeCharacterString = "~";
//        private const string dummyProtocolAndServer = "file://foo";
//        private static char[] s_slashChars;

//        // Methods
//        static UrlPath()
//        {
//            char[] chArray1 = new char[2] { '\\', '/' };
//            UrlPath.s_slashChars = chArray1;
//        }

//        public static string AppendSlashToPathIfNeeded(string path)
//        {
//            if (path == null)
//            {
//                return null;
//            }
//            int num1 = path.Length;
//            if ((num1 != 0) && (path[num1 - 1] != '/'))
//            {
//                path = path + '/';
//            }
//            return path;
//        }

//        public static void CheckValidVirtualPath(string path)
//        {
//            if (UrlPath.IsAbsolutePhysicalPath(path))
//            {
//                object[] objArray1 = new object[1] { path };
//                throw new HttpException(string.Format("'{0}' is a physical path, but a virtual path was expected.", objArray1));
//            }
//            if (path.IndexOf(':') >= 0)
//            {
//                object[] objArray2 = new object[1] { path };
//                throw new HttpException(string.Format("'{0}' is not a valid virtual path.", objArray2));
//            }
//        }

//        public static string Combine(string basepath, string relative)
//        {
//            return UrlPath.Combine(HttpRuntime.AppDomainAppVirtualPath, basepath, relative);
//        }

//        public static string Combine(string appPath, string basepath, string relative)
//        {
//            string text1;
//            if (string.IsNullOrEmpty(relative))
//            {
//                throw new ArgumentNullException("relative");
//            }
//            if (string.IsNullOrEmpty(basepath))
//            {
//                throw new ArgumentNullException("basepath");
//            }
//            UrlPath.CheckValidVirtualPath(relative);
//            if (UrlPath.IsRooted(relative))
//            {
//                text1 = relative;
//            }
//            else
//            {
//                if ((relative.Length == 1) && (relative[0] == '~'))
//                {
//                    return appPath;
//                }
//                if (UrlPath.IsAppRelativePath(relative))
//                {
//                    if (appPath.Length > 1)
//                    {
//                        text1 = appPath + "/" + relative.Substring(2);
//                    }
//                    else
//                    {
//                        text1 = "/" + relative.Substring(2);
//                    }
//                }
//                else
//                {
//                    text1 = UrlPath.SimpleCombine(basepath, relative);
//                }
//            }
//            return UrlPath.Reduce(text1);
//        }

//        public static string FixVirtualPathSlashes(string virtualPath)
//        {
//            virtualPath = virtualPath.Replace('\\', '/');
//            while (true)
//            {
//                string text1 = virtualPath.Replace("//", "/");
//                if (text1.Length == virtualPath.Length)
//                {
//                    break;
//                }
//                virtualPath = text1;
//            }
//            return virtualPath;
//        }

//        public static string GetDirectory(string path)
//        {
//            if (string.IsNullOrEmpty(path))
//            {
//                throw new ArgumentException(string.Format("Empty path has no directory."));
//            }
//            if ((path[0] != '/') && (path[0] != '~'))
//            {
//                object[] objArray1 = new object[1] { path };
//                throw new ArgumentException(string.Format("The virtual path '{0}' is not rooted.", objArray1));
//            }
//            if (path.Length == 1)
//            {
//                return path;
//            }
//            int num1 = path.LastIndexOf('/');
//            if (num1 < 0)
//            {
//                object[] objArray2 = new object[1] { path };
//                throw new ArgumentException(string.Format("The virtual path '{0}' is not rooted.", objArray2));
//            }
//            string text1 = path.Substring(0, num1);
//            if (text1.Length == 0)
//            {
//                return "/";
//            }
//            return text1;
//        }

//        public static string GetDirectoryOrRootName(string path)
//        {
//            string text1 = Path.GetDirectoryName(path);
//            if (text1 == null)
//            {
//                text1 = Path.GetPathRoot(path);
//            }
//            return text1;
//        }

//        public static string GetExtension(string virtualPath)
//        {
//            return Path.GetExtension(virtualPath);
//        }

//        public static string GetFileName(string virtualPath)
//        {
//            return Path.GetFileName(virtualPath);
//        }

//        public static string GetFileNameWithoutExtension(string virtualPath)
//        {
//            return Path.GetFileNameWithoutExtension(virtualPath);
//        }

//        public static string GetParentPath(string path)
//        {
//            if (((path == null) || (path.Length <= 1)) || (path[0] != '/'))
//            {
//                return null;
//            }
//            int num1 = path.LastIndexOf('/');
//            if (num1 < 0)
//            {
//                return null;
//            }
//            if (num1 == 0)
//            {
//                return "/";
//            }
//            return path.Substring(0, num1);
//        }

//        public static bool IsAbsolutePhysicalPath(string path)
//        {
//            if ((path != null) && (path.Length >= 3))
//            {
//                if ((path[1] == ':') && UrlPath.IsDirectorySeparatorChar(path[2]))
//                {
//                    return true;
//                }
//                if (UrlPath.IsDirectorySeparatorChar(path[0]) && UrlPath.IsDirectorySeparatorChar(path[1]))
//                {
//                    return true;
//                }
//            }
//            return false;
//        }

//        public static bool IsAppRelativePath(string path)
//        {
//            if (path == null)
//            {
//                return false;
//            }
//            int num1 = path.Length;
//            if (num1 == 0)
//            {
//                return false;
//            }
//            if (path[0] != '~')
//            {
//                return false;
//            }
//            if ((num1 != 1) && (path[1] != '\\'))
//            {
//                return (path[1] == '/');
//            }
//            return true;
//        }

//        private static bool IsDirectorySeparatorChar(char ch)
//        {
//            if (ch != '\\')
//            {
//                return (ch == '/');
//            }
//            return true;
//        }

//        public static bool IsEqualOrSubpath(string path, string subpath)
//        {
//            if (!string.IsNullOrEmpty(path))
//            {
//                if (string.IsNullOrEmpty(subpath))
//                {
//                    return false;
//                }
//                int num1 = path.Length;
//                if (path[num1 - 1] == '/')
//                {
//                    num1--;
//                }
//                int num2 = subpath.Length;
//                if (subpath[num2 - 1] == '/')
//                {
//                    num2--;
//                }
//                if (num2 < num1)
//                {
//                    return false;
//                }
//                if (string.Compare(path, 0, subpath, 0, num1, true, CultureInfo.InvariantCulture) != 0)
//                {
//                    return false;
//                }
//                if ((num2 > num1) && (subpath[num1] != '/'))
//                {
//                    return false;
//                }
//            }
//            return true;
//        }

//        public static bool IsFullPath(string path)
//        {
//            if (!string.IsNullOrEmpty(path))
//            {
//                return (path[0] == '/');
//            }
//            return false;
//        }

//        public static bool IsPathOnSameServer(string absUriOrLocalPath, Uri currentRequestUri)
//        {
//            Uri uri1;
//            if (Uri.TryCreate(absUriOrLocalPath, UriKind.Absolute, out uri1) && !uri1.IsLoopback)
//            {
//                return string.Equals(currentRequestUri.Host, uri1.Host, StringComparison.InvariantCultureIgnoreCase);
//            }
//            return true;
//        }

//        public static bool IsRelativeUrl(string virtualPath)
//        {
//            if (virtualPath.IndexOf(":") != -1)
//            {
//                return false;
//            }
//            return !UrlPath.IsRooted(virtualPath);
//        }

//        public static bool IsRooted(string basepath)
//        {
//            if (!string.IsNullOrEmpty(basepath) && (basepath[0] != '/'))
//            {
//                return (basepath[0] == '\\');
//            }
//            return true;
//        }

//        public static bool IsValidVirtualPathWithoutProtocol(string path)
//        {
//            if (path == null)
//            {
//                return false;
//            }
//            if (path.IndexOf(":") != -1)
//            {
//                return false;
//            }
//            return true;
//        }

//        public static string MakeRelative(string from, string to)
//        {
//            string text2;
//            from = UrlPath.MakeVirtualPathAppAbsolute(from);
//            to = UrlPath.MakeVirtualPathAppAbsolute(to);
//            if (!UrlPath.IsRooted(from))
//            {
//                object[] objArray1 = new object[1] { from };
//                throw new ArgumentException(string.Format("The virtual path '{0}' is not rooted.", objArray1));
//            }
//            if (!UrlPath.IsRooted(to))
//            {
//                object[] objArray2 = new object[1] { to };
//                throw new ArgumentException(string.Format("The virtual path '{0}' is not rooted.", objArray2));
//            }
//            string text1 = null;
//            if (to != null)
//            {
//                int num1 = to.IndexOf('?');
//                if (num1 >= 0)
//                {
//                    text1 = to.Substring(num1);
//                    to = to.Substring(0, num1);
//                }
//            }
//            Uri uri1 = new Uri("file://foo" + from);
//            Uri uri2 = new Uri("file://foo" + to);
//            if (uri1.Equals(uri2))
//            {
//                int num2 = to.LastIndexOfAny(UrlPath.s_slashChars);
//                if (num2 >= 0)
//                {
//                    if (num2 == (to.Length - 1))
//                    {
//                        text2 = "./";
//                    }
//                    else
//                    {
//                        text2 = to.Substring(num2 + 1);
//                    }
//                }
//                else
//                {
//                    text2 = to;
//                }
//            }
//            else
//            {
//                text2 = uri1.MakeRelative(uri2);
//            }
//            return (text2 + text1 + uri2.Fragment);
//        }

//        public static string MakeVirtualPathAppAbsolute(string virtualPath)
//        {
//            return UrlPath.MakeVirtualPathAppAbsolute(virtualPath, HttpRuntime.AppDomainAppVirtualPath);
//        }

//        public static string MakeVirtualPathAppAbsolute(string virtualPath, string applicationPath)
//        {
//            if ((virtualPath.Length == 1) && (virtualPath[0] == '~'))
//            {
//                return applicationPath;
//            }
//            if (((virtualPath.Length >= 2) && (virtualPath[0] == '~')) && ((virtualPath[1] == '/') || (virtualPath[1] == '\\')))
//            {
//                if (applicationPath.Length > 1)
//                {
//                    return (applicationPath + "/" + virtualPath.Substring(2));
//                }
//                return ("/" + virtualPath.Substring(2));
//            }
//            if (!UrlPath.IsRooted(virtualPath))
//            {
//                throw new ArgumentOutOfRangeException("virtualPath");
//            }
//            return virtualPath;
//        }

//        public static string MakeVirtualPathAppAbsoluteReduceAndCheck(string virtualPath)
//        {
//            if (virtualPath == null)
//            {
//                throw new ArgumentNullException("virtualPath");
//            }
//            string text1 = UrlPath.Reduce(UrlPath.MakeVirtualPathAppAbsolute(virtualPath));
//            if (!UrlPath.VirtualPathStartsWithAppPath(text1))
//            {
//                object[] objArray1 = new object[1] { virtualPath };
//                throw new ArgumentException(string.Format("The virtual path '{0}' is not a valid absolute virtual path within the current application.", objArray1));
//            }
//            return text1;
//        }

//        public static string MakeVirtualPathAppRelative(string virtualPath)
//        {
//            return UrlPath.MakeVirtualPathAppRelative(virtualPath, HttpRuntime.AppDomainAppVirtualPath);
//        }

//        public static string MakeVirtualPathAppRelative(string virtualPath, string applicationPath)
//        {
//            if (virtualPath == null)
//            {
//                throw new ArgumentNullException("virtualPath");
//            }
//            if (!UrlPath.VirtualPathStartsWithVirtualPath(virtualPath, applicationPath))
//            {
//                return virtualPath;
//            }
//            if (virtualPath.Length == applicationPath.Length)
//            {
//                return "~";
//            }
//            if (applicationPath.Length == 1)
//            {
//                return ('~' + virtualPath);
//            }
//            return ('~' + virtualPath.Substring(applicationPath.Length));
//        }

//        public static bool PathEndsWithExtraSlash(string path)
//        {
//            if (path == null)
//            {
//                return false;
//            }
//            int num1 = path.Length;
//            if ((num1 == 0) || (path[num1 - 1] != '\\'))
//            {
//                return false;
//            }
//            if ((num1 == 3) && (path[1] == ':'))
//            {
//                return false;
//            }
//            return true;
//        }

//        public static bool PathIsDriveRoot(string path)
//        {
//            if (((path != null) && (path.Length == 3)) && ((path[1] == ':') && (path[2] == '\\')))
//            {
//                return true;
//            }
//            return false;
//        }

//        public static string Reduce(string path)
//        {
//            string text1 = null;
//            if (path != null)
//            {
//                int num1 = path.IndexOf('?');
//                if (num1 >= 0)
//                {
//                    text1 = path.Substring(num1);
//                    path = path.Substring(0, num1);
//                }
//            }
//            path = UrlPath.FixVirtualPathSlashes(path);
//            int num2 = path.Length;
//            int num3 = 0;
//            while (true)
//            {
//                num3 = path.IndexOf('.', num3);
//                if (num3 < 0)
//                {
//                    if (text1 == null)
//                    {
//                        return path;
//                    }
//                    return (path + text1);
//                }
//                if (((num3 == 0) || (path[num3 - 1] == '/')) && ((((num3 + 1) == num2) || (path[num3 + 1] == '/')) || ((path[num3 + 1] == '.') && (((num3 + 2) == num2) || (path[num3 + 2] == '/')))))
//                {
//                    break;
//                }
//                num3++;
//            }
//            ArrayList list1 = new ArrayList();
//            StringBuilder builder1 = new StringBuilder();
//            num3 = 0;
//            do
//            {
//                int num4 = num3;
//                num3 = path.IndexOf('/', (int) (num4 + 1));
//                if (num3 < 0)
//                {
//                    num3 = num2;
//                }
//                if ((((num3 - num4) <= 3) && ((num3 < 1) || (path[num3 - 1] == '.'))) && (((num4 + 1) >= num2) || (path[num4 + 1] == '.')))
//                {
//                    if ((num3 - num4) == 3)
//                    {
//                        if (list1.Count == 0)
//                        {
//                            throw new HttpException(string.Format("Cannot use a leading .. to exit above the top directory."));
//                        }
//                        if ((list1.Count == 1) && UrlPath.IsAppRelativePath(path))
//                        {
//                            return UrlPath.Reduce(UrlPath.MakeVirtualPathAppAbsolute(path));
//                        }
//                        builder1.Length = (int) list1[list1.Count - 1];
//                        list1.RemoveRange(list1.Count - 1, 1);
//                    }
//                }
//                else
//                {
//                    list1.Add(builder1.Length);
//                    builder1.Append(path, num4, (int) (num3 - num4));
//                }
//            }
//            while (num3 != num2);
//            string text2 = builder1.ToString();
//            if (text2.Length == 0)
//            {
//                if ((num2 > 0) && (path[0] == '/'))
//                {
//                    text2 = "/";
//                }
//                else
//                {
//                    text2 = ".";
//                }
//            }
//            return (text2 + text1);
//        }

//        public static string RemoveSlashFromPathIfNeeded(string path)
//        {
//            if (string.IsNullOrEmpty(path))
//            {
//                return null;
//            }
//            int num1 = path.Length;
//            if ((num1 > 1) && (path[num1 - 1] == '/'))
//            {
//                return path.Substring(0, num1 - 1);
//            }
//            return path;
//        }

//        public static string SimpleCombine(string basepath, string relative)
//        {
//            if ((basepath == null) || ((basepath.Length == 1) && (basepath[0] == '/')))
//            {
//                basepath = string.Empty;
//            }
//            return (basepath + "/" + relative);
//        }

//        public static bool VirtualPathStartsWithAppPath(string virtualPath)
//        {
//            return UrlPath.VirtualPathStartsWithVirtualPath(virtualPath, HttpRuntime.AppDomainAppVirtualPath);
//        }

//        public static bool VirtualPathStartsWithVirtualPath(string virtualPath1, string virtualPath2)
//        {
//            if (virtualPath1 == null)
//            {
//                throw new ArgumentNullException("virtualPath1");
//            }
//            if (virtualPath2 == null)
//            {
//                throw new ArgumentNullException("virtualPath2");
//            }
//            if (!StringStartsWithIgnoreCase(virtualPath1, virtualPath2))
//            {
//                return false;
//            }
//            if (virtualPath1.Length != virtualPath2.Length)
//            {
//                if (virtualPath2.Length == 1)
//                {
//                    return true;
//                }
//                if (virtualPath1[virtualPath2.Length] != '/')
//                {
//                    return false;
//                }
//            }
//            return true;
//        }

//        public static bool StringStartsWithIgnoreCase(string s1, string s2)
//        {
//            if (s2.Length > s1.Length)
//            {
//                return false;
//            }
//            return (0 == string.Compare(s1, 0, s2, 0, s2.Length, true, CultureInfo.InvariantCulture));
//        }

//        public static bool VPathEndsWithExtraSlash(string path)
//        {
//            if ((path == null) || (path == "/"))
//            {
//                return false;
//            }
//            int num1 = path.Length;
//            if (num1 <= 0)
//            {
//                return false;
//            }
//            if (path[num1 - 1] != '/')
//            {
//                return (path[num1 - 1] == '\\');
//            }
//            return true;
//        }
//    }
//}