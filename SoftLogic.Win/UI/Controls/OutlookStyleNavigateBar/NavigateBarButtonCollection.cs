/*
 * Project	    : Outlook 2003 Style Navigation Pane
 *
 * Author       : Muhammed ŞAHİN
 * eMail        : muhammed.sahin@gmail.com
 *
 * Description  : NavigateBarButton collection
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace SoftLogik.Win.UI.Controls.OutlookStyleNavigateBar
{
    /// <summary>
    /// NavigateBarButton collection
    /// </summary>
    public sealed class NavigateBarButtonCollection : IList<NavigateBarButton>, IDisposable
    {

        List<NavigateBarButton> navigateBarButtonList = new List<NavigateBarButton>();

        #region Delegate Tanımları

        internal delegate void OnItemAddedEventHandler(NavigateBarButtonEventArgs e);
        /// <summary>
        /// Remove button in collection
        /// </summary>
        internal event OnItemAddedEventHandler OnNavigateBarButtonAdded;

        internal delegate void OnItemRemovedEventHandler(NavigateBarButtonEventArgs e);
        /// <summary>
        /// Add new button in collection
        /// </summary>
        internal event OnItemRemovedEventHandler OnNavigateBarButtonRemoved;

        #endregion

        #region IList<NavigateBarButton>

        public int IndexOf(NavigateBarButton item)
        {
            return navigateBarButtonList.IndexOf(item);
        }

        public void Insert(int index, NavigateBarButton item)
        {
            navigateBarButtonList.Insert(index, item);

            if (OnNavigateBarButtonAdded != null)
                OnNavigateBarButtonAdded(new NavigateBarButtonEventArgs(item));

        }

        public void RemoveAt(int index)
        {

            navigateBarButtonList.RemoveAt(index);

            if (OnNavigateBarButtonRemoved != null)
                OnNavigateBarButtonRemoved(new NavigateBarButtonEventArgs(navigateBarButtonList[index]));

        }

        public NavigateBarButton this[int index]
        {
            get
            {
                return navigateBarButtonList[index];
            }
            set
            {
                navigateBarButtonList[index] = value;
            }
        }

        #endregion

        #region ICollection<NavigateBarButton>

        public void Add(NavigateBarButton item)
        {
            navigateBarButtonList.Add(item);

            if (OnNavigateBarButtonAdded != null)
                OnNavigateBarButtonAdded(new NavigateBarButtonEventArgs(item));
        }

        public void Clear()
        {
            navigateBarButtonList.Clear();
        }

        public bool Contains(NavigateBarButton item)
        {
            return navigateBarButtonList.Contains(item);
        }

        public void CopyTo(NavigateBarButton[] array, int arrayIndex)
        {
            navigateBarButtonList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return navigateBarButtonList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(NavigateBarButton item)
        {

            bool isRemoved = navigateBarButtonList.Remove(item);

            if (OnNavigateBarButtonRemoved != null)
                OnNavigateBarButtonRemoved(new NavigateBarButtonEventArgs(item));

            return isRemoved;
        }

        #endregion

        #region IEnumerable<NavigateBarButton>

        public IEnumerator<NavigateBarButton> GetEnumerator()
        {
            IEnumerator<NavigateBarButton> enumator = navigateBarButtonList.GetEnumerator();
            return enumator;
        }

        #endregion

        #region IEnumerable

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (System.Collections.IEnumerator)navigateBarButtonList;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            navigateBarButtonList = null;
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Custom Methods
        /// <summary>
        /// Get displayed button count in panel
        /// </summary>
        /// <returns></returns>
        public int GetDisplayedItemCount()
        {
            int count = 0;
            foreach (NavigateBarButton nvb in navigateBarButtonList)
                if (nvb.IsDisplayed && nvb.Visible)
                    count++;

            return count;
        }

        /// <summary>
        /// Search button using key value
        /// </summary>
        /// <param name="tKey"></param>
        /// <returns></returns>
        public NavigateBarButton FindByKey(string tKey)
        {
            NavigateBarButton retButton = null;

            if (string.IsNullOrEmpty(tKey))
                return retButton;

            foreach (NavigateBarButton nvb in navigateBarButtonList)
            {
                if (!string.IsNullOrEmpty(nvb.Key) && nvb.Key.Equals(tKey))
                {
                    retButton = nvb;
                    break;
                }
            }

            return retButton;
        }

        #endregion
    }

}
