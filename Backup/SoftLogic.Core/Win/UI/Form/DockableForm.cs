using System.Text.RegularExpressions;
using System.Diagnostics;
using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using WeifenLuo.WinFormsUI;
using Microsoft.Win32;
using WeifenLuo;
using ComponentFactory.Krypton.Toolkit;

namespace SoftLogik.Win.UI
{
    public partial class DockableForm : WeifenLuo.WinFormsUI.DockContent
    {
        public DockableForm()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                this.TabText = value;
                base.Text = value;
            }
        }

        protected override void OnLoad(System.EventArgs e)
        {
          
            try
            {
                if (!DesignMode)
                {
                    if (this.MdiParent != null)
                    {
                        this.Show(((DockingMDI)this.MdiParent).DockPanel, WeifenLuo.WinFormsUI.DockState.Document);
                    }
                }
            }
            catch (Exception)
            {
            }

            base.OnLoad(e);
        }

        public void mnuClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        public void ResetErrorNotify()
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl.Controls.Count == 0)
                {
                    try
                    {
                        ErrorNotify.SetError(ctl, string.Empty);
                    }
                    catch (Exception ex) { }
                }
                else
                {
                    Control ctlInner = ctl;
                    ResetErrorNotifyInner(ref ctlInner);
                }
            }
        }

        private void ResetErrorNotifyInner(ref Control ctl)
        {
            if (ctl.Controls.Count == 0)
            {
                try
                {
                    ErrorNotify.SetError(ctl, string.Empty);
                }
                catch (Exception ex) { }
            }
            else
            {
                foreach (Control ctlParent in ctl.Controls)
                {
                    Control ctlInner = ctlParent;
                    ResetErrorNotifyInner(ref ctlInner);
                }
            }
        }

        public virtual void ResetForm()
        {
            ResetForm(this.Controls);
        }

        public virtual void ResetForm(System.Windows.Forms.Control.ControlCollection Controls)
        {
            foreach (Control ctl in Controls) //go thru all controls
            {
                if (ctl.Controls.Count == 0 || (ctl.GetType().Name.StartsWith("Krypton") && !ctl.GetType().Name.StartsWith("KryptonPanel")))
                {
                    Control innerCtl = ctl;
                    ResetFormInner(ref innerCtl);
                }
                else
                {
                    ResetForm(ctl.Controls);
                }
            }
        }

        private void ResetFormInner(ref Control ctl)
        {
            if (ctl.Controls.Count == 0 || (ctl.GetType().Name.StartsWith("Krypton") && !ctl.GetType().Name.StartsWith("KryptonPanel")))
            {
                if (ctl.Tag != null)
                {
                    if (!string.IsNullOrEmpty(ctl.Tag.ToString().Trim()))
                    {
                        if (ctl is ListControl)
                        {
                            try
                            {
                                ((ListControl)ctl).SelectedIndex = -1;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else if ((ctl is KryptonComboBox))
                        {
                            try
                            {
                                ((KryptonComboBox)ctl).SelectedIndex = -1;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else if (ctl is CheckBox)
                        {
                            try
                            {
                                ((CheckBox)ctl).Checked = false;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else if (ctl is KryptonCheckBox)
                        {
                            try
                            {
                                ((KryptonCheckBox)ctl).Checked = false;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else if (ctl is RadioButton)
                        {
                            try
                            {
                                ((KryptonCheckBox)ctl).Checked = false;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else if (ctl is KryptonRadioButton)
                        {
                            try
                            {
                                ((KryptonRadioButton)ctl).Checked = false;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else if (ctl is PictureBox)
                        {
                            try
                            {
                                ((PictureBox)ctl).Image = null;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else if (ctl is TabPage)
                        {
                            //do nothing
                        }
                        else if (ctl is ComponentFactory.Krypton.Toolkit.KryptonTextBox || ctl is ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown)
                        {
                            try
                            {
                                ((KryptonTextBox)ctl).Text = string.Empty;
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                            try
                            {
                                ((TextBox)ctl).Text = string.Empty;
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                }
            }

        }

        private void closeAllButThisToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}