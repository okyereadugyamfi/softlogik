using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.ComponentModel;

namespace SoftLogik.Win.UI.Controls
{
    public partial class RadioButtonListEditorUI
    {

        private RadioButtonItemCollection _RadioItems = null;

        internal RadioButtonListEditorUI(RadioButtonItemCollection itemsTarget, IWindowsFormsEditorService editorService)
        {

            InitializeComponent();

        }

        // LightShape is the property for which this control provides
        // a custom user interface in the Properties window.
        public RadioButtonItemCollection RadioItems
        {

            get
            {
                return this._RadioItems;
            }

            set
            {
                if (this._RadioItems != value)
                {
                    this._RadioItems = value;
                }
            }
        }
    }

}