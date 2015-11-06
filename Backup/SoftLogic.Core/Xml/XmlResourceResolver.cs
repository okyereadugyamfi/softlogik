using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using SoftLogik.Miscellaneous;
using SoftLogik.Resources;

namespace SoftLogik.Xml
{
  public class XmlResourceResolver : XmlUrlResolver
  {
    private readonly Assembly _resourceAssembly;

    public Assembly ResourceAssembly
    {
      get { return _resourceAssembly; }
    }

    public XmlResourceResolver(Assembly resourceAssembly)
    {
      ValidationUtils.ArgumentNotNull(resourceAssembly, "resourceAssembly");

      _resourceAssembly = resourceAssembly;
    }

    //It creates Stream or XmlReader
    public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
    {
      Stream stream;

      IResourceGetter resourceLoader = new ResourceLoader(_resourceAssembly);

      //if is file compiled with assembly
      if (absoluteUri.Scheme == "resource")
      {
        string xslText = (string)resourceLoader.GetObject(absoluteUri.AbsolutePath);

        stream = new MemoryStream(Encoding.UTF8.GetBytes(xslText));
      }
      //in other cases read file from specified absolute Uri
      else
      {
        stream = (Stream)base.GetEntity(absoluteUri, role, typeof(Stream));
      }

      //what type to return
      if (ofObjectToReturn == typeof(XmlReader))
        return XmlReader.Create(stream);
      else
        return stream;
    }

    // It returns absolute Uri according to base and relative Uri
    public override Uri ResolveUri(Uri baseUri, string relativeUri)
    {
      if (relativeUri.StartsWith("res:"))
        return new Uri(relativeUri);
      else
        return base.ResolveUri(baseUri, relativeUri);
    }
  }
}