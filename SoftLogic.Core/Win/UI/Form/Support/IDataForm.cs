using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftLogik.Win.UI.Form.Support
{
    public interface IDataForm<T> 
    {
        public T GetDefault();
    }
}
