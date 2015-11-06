namespace SoftLogik.Win.UI.Controls
{
    public partial class DropDownList : System.Windows.Forms.ComboBox
    {

        private string m_strLookupText = "<New...>";
        private int m_intLookupIndex;

        public delegate void PopulateEventHandler(object sender, DropDownListPopulateEventArgs evt);
        public event PopulateEventHandler Populate;
        public delegate void LookupEventHandler(object sender, DropDownListPopulateEventArgs evt);
        public event LookupEventHandler Lookup;


        public string LookupText
        {
            get
            {
                return m_strLookupText;
            }
            set
            {
                m_strLookupText = value;
            }
        }
        public int LookupIndex
        {
            get
            {
                return m_intLookupIndex;
            }
            set
            {
                m_intLookupIndex = value;
            }
        }

        protected override void OnSelectedValueChanged(System.EventArgs e)
        {
            base.OnSelectedValueChanged(e);

            if (this.SelectedIndex == LookupIndex)
            {
                if (Lookup != null)
                    Lookup(this, new DropDownListPopulateEventArgs());
            }
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

