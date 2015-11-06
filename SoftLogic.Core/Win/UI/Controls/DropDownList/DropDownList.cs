
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System;
namespace SoftLogik.Win.UI.Controls
{
    [ToolboxBitmap(typeof(ComboBox))]
    public partial class DropDownList
    {

        private string m_strLookupText = "<More...>";
        private int m_intLookupIndex = 0;

        public delegate void PopulateEventHandler(object sender, DropDownListPopulateEventArgs evt);
        public event PopulateEventHandler Populate;
        public delegate void LookupEventHandler(object sender, DropDownListPopulateEventArgs evt);
        public event LookupEventHandler Lookup;

        public DropDownList()
        {

            // This call is required by the Windows Form Designer.
            InitializeComponent();

            //Add an Entry for the Lookup Field
            AddLookupText(LookupText);
        }

        #region Properties

        public string LookupText
        {
            get
            {
                return m_strLookupText;
            }
            set
            {
                AddLookupText(value);
                m_strLookupText = value;
            }
        }

        private void AddLookupText(string LookupText)
        {

            try
            {
                if (Convert.ToString(this.Items[0]) != LookupText)
                {
                    this.Items.RemoveAt(0);
                    this.Items.Insert(0, LookupText);
                }
            }
            catch { }
            
        }
        #endregion

        private bool _DataSourceChanged = false;
        protected override void OnSelectedValueChanged(System.EventArgs e)
        {
            //if (this.SelectedIndex == m_intLookupIndex && _DataSourceChanged)
            //{
            //    OnLookup();
            //}
            //else
            //{
            //    _DataSourceChanged = true;
                base.OnSelectedValueChanged(e);
            //}
        }

        protected override void OnDataSourceChanged(EventArgs e)
        {
            _DataSourceChanged = false;
            base.OnDataSourceChanged(e);
        }
        private void OnLookup()
        {
            DropDownListPopulateEventArgs lookupParams = new DropDownListPopulateEventArgs();
             if (Lookup != null)
                 Lookup(this, lookupParams);

             try
             {
                 if (lookupParams.Data == null)
                 {
                     object _reloadedData = this.DataSource;
                     this.DataSource = null;
                     this.DataSource = _reloadedData;
                 }
                 else
                 {
                     this.Items.Add(lookupParams);   
                 }
             }
             catch { }
        }

    }

    public class DropDownListPopulateEventArgs : System.EventArgs
    {

        private object m_objData;

        public object Data
        {
            get
            {
                return m_objData;
            }
            set
            {
                m_objData = value;
            }
        }
    }
}

