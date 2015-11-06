using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SoftLogik.Win.UI.Support;


namespace SoftLogik.Win.UI.Form.Support
{
    public class DataFormManager : IDataForm<T>, IDisposable
    {
        protected object _DataSource = null;
        protected RecordBindingSettings _BindingSettings;
        protected System.Windows.Forms.Form _dataForm;
        protected object NewRecordData;
        protected System.Windows.Forms.BindingSource _dataFormBinding;


        public DataFormManager(RecordForm DataForm)
        {
            _dataFormBinding = new System.Windows.Forms.BindingSource(DataForm.components);
            _dataFormBinding.BindingComplete += new System.Windows.Forms.BindingCompleteEventHandler(this.DetailBinding_BindingComplete);
            _dataFormBinding.DataSourceChanged += new System.EventHandler(this.DetailBinding_DataSourceChanged);
            _dataFormBinding.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.DetailBinding_ListChanged);

            FormRecordBindingEventArgs dataBindSettings = new FormRecordBindingEventArgs();
            OnRecordBinding(dataBindSettings);
            this.CurrentState = FormRecordModes.EditMode; //By Default Form is in Edit Mode
            this.BindingData = true;
            _DataSource = dataBindSettings.DataSource;
            _BindingSettings = dataBindSettings.BindingSettings;
            //_NewRecordProc = _BindingSettings.NewRecordProc;

            this.BindingData = true;
            SPFormSupport.BindControls(DataForm.Controls, ref _dataFormBinding, new System.EventHandler(OnFieldChanged));
            this.BindingData = false;

        }

        #region Properties
            [Description("Gets or Sets the Current Form Record Operation Mode")]
            public FormRecordModes CurrentState;
            [Description("Gets or Sets the Showing Data Flag")]
            public bool ShowingData;
            [Description("Gets or Sets the Form Binding Flag.")]
            public bool BindingData;
            [Description("Gets or Sets the Duplication Data Flag.")]
            public bool DuplicatingData;
        #endregion

            #region Data Change Events
            protected virtual void OnFieldChanged(System.Object sender, System.EventArgs e)
            {
                if (this.ShowingData == false)
                {
                    if (this.CurrentState == FormRecordModes.EditMode && this.CurrentState != FormRecordModes.DirtyMode && (!this.BindingData))
                    {
                        this.CurrentState = FormRecordModes.DirtyMode;
                        UpdateFormCaption(false);
                        ToolbarSupport.ToolbarToggleSave(_dataForm.tbrMain, null);
                    }
                }
                this.BindingData = false;
            }
            protected virtual void UpdateFormCaption(bool Clear)
            {
                string strText = _dataForm.Text;

                if (!Clear)
                {
                    strText += ((strText.EndsWith("*")) ? string.Empty : "*").ToString();
                    _dataForm.Text = strText;
                }
                else
                {
                    this.Text = strText.Replace("*", string.Empty);
                }
            }
            #endregion

        #region Record Management
            protected virtual void OnNewRecord()
            {
                try
                {
                    this._dataFormBinding.AddNew();
                    this._dataFormBinding.MoveFirst();
                    this.CurrentState = FormRecordModes.InsertMode;
                    ToolbarSupport.ToolbarToggleSave(tbrMain, null);
                    FirstFieldFocus();
                }
                catch (Exception)
                {
                }
            }
            protected virtual void OnRefreshRecord()
            {
                try
                {
                    this.CurrentState = FormRecordModes.EditMode;
                    FirstFieldFocus();
                }
                catch (Exception)
                {
                }
            }
            protected virtual void OnSortRecord()
            {
                try
                {
                    this.CurrentState = FormRecordModes.EditMode;
                    //this._dataFormBinding.ApplySort(); 
                    FirstFieldFocus();
                }
                catch (Exception)
                {
                }
            }
            protected virtual void OnSaveRecord()
            {
                this._dataForm.Validate();
                try
                {
                    this.ShowingData = true;
                    this._dataFormBinding.EndEdit();
                    this.ShowingData = false;
                }
                catch (Exception)
                {
                    return;
                }

                if (this._dataFormBinding.Current != null)
                {
                    if (this.CurrentState == FormRecordModes.InsertMode)
                    {
                        OnRecordChanged(new FormRecordUpdateEventArgs(this.NewRecordData, FormDataStates.New));
                        this.NewRecordData = null;
                    }
                    else
                    {
                        OnRecordChanged(new FormRecordUpdateEventArgs(this._dataFormBinding.Current, FormDataStates.Edited));
                    }


                    this.CurrentState = FormRecordModes.EditMode;
                    UpdateFormCaption(true);
                }
            }
            protected virtual void OnUndoRecord()
            {
                if (this._dataFormBinding.Current != null)
                {
                    if (((DataRowView)this._dataFormBinding.Current).IsNew)
                    {
                        this._dataFormBinding.RemoveCurrent();
                    }
                    else
                    {
                        this._dataFormBinding.CancelEdit();
                    }


                }
                this.CurrentState = FormRecordModes.EditMode;
                UpdateFormCaption(true);
            }
            protected virtual void OnDeleteRecord()
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to Delete \'" + ((DataRowView)this._dataFormBinding.Current).Row[_BindingSettings.DisplayMember].ToString() + "\' ?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        OnRecordChanged(new FormRecordUpdateEventArgs(((DataRowView)this._dataFormBinding.Current).Row, FormDataStates.Deleted));
                        this.ShowingData = true;
                        this._dataFormBinding.RemoveCurrent();
                        this.ShowingData = false;
                    }
                }
                catch (Exception)
                {
                }
            }
            protected virtual void OnSearchRecord()
            {
                if (_LookupForm != null)
                {
                    _LookupForm.ShowDialog(this);
                    //.SearchResults()
                }
            }
            protected virtual void OnCopyRecord()
            {
                if (this._dataFormBinding.Current != null)
                {
                    //this.ShowingData = True
                    DataRowView clonedDataRow = (DataRowView)this._dataFormBinding.Current;
                    DataRowView newDataRow = (DataRowView)(this._dataFormBinding.AddNew());
                    DuplicateRecord(clonedDataRow, ref newDataRow);
                    this._dataFormBinding.ResetBindings(false);
                    this.CurrentState = FormRecordModes.InsertMode;
                    //this.ShowingData = False
                }
            }
            protected virtual void OnNavigate(RecordNavigateDirections direction)
            {
                T lastRecord;
                T currentRecord;

                this.ShowingData = true;
                lastRecord = ((DataRowView)this._dataFormBinding.Current).Row;
                switch (direction)
                {
                    case RecordNavigateDirections.First:
                        SelectNameInList(0);
                        break;
                    case RecordNavigateDirections.Last:
                        SelectNameInList(this._dataFormBinding.Count - 1);
                        break;
                    case RecordNavigateDirections.Next:
                        SelectNameInList(this._dataFormBinding.Position + 1);
                        break;
                    case RecordNavigateDirections.Previous:
                        SelectNameInList(this._dataFormBinding.Position - 1);
                        break;
                }

                this.ShowingData = false;
                currentRecord = ((DataRowView)this._dataFormBinding.Current).Row;
                if (NavigationChangedEvent != null)
                    NavigationChangedEvent(tbrMain, new FormNavigateEventArgs(direction, ref lastRecord, ref currentRecord));
            }
            protected virtual void FirstFieldFocus()
            {
                int lastTabIndex;
                try
                {
                    Control firstControl = this.GetNextControl(this, true);
                    if (firstControl != null)
                    {
                        lastTabIndex = firstControl.TabIndex;
                        FindFirstField(firstControl, ref lastTabIndex);
                    }
                }
                catch (Exception)
                {
                    return;
                }

            }
            private void FindFirstField(Control OuterControl, ref int lastTabIndex)
            {
                Control ctl = OuterControl;
                while (ctl != null)
                {
                    if ((!ctl.HasChildren) && (ctl.CanFocus && ctl.CanSelect))
                    {
                        ctl.Focus();
                        return;
                    }
                    else
                    {
                        ctl = ctl.GetNextControl(ctl, true);
                        FindFirstField(ctl, ref lastTabIndex);
                    }
                }
            }
            private void DuplicateRecord(DataRowView SourceRow, ref DataRowView TargetRow)
            {
                formManager.DuplicatingData = true;
                TargetRow.Row.ItemArray = SourceRow.Row.ItemArray;

                foreach (DataColumn itm in TargetRow.Row.Table.Columns)
                {
                    if (itm.ReadOnly)
                    {
                        if (itm.AutoIncrement)
                        {
                            TargetRow[itm.ColumnName] = 0;
                        }
                    }
                }
                formManager.DuplicatingData = false;
            }

        protected virtual void OnRecordBinding(FormRecordBindingEventArgs e)
        {
            if (RecordBindingEvent != null) //let client respond
                RecordBindingEvent(this, e);
        }


        protected virtual void OnRecordChanged(FormRecordUpdateEventArgs e)
        {
            if (RecordChangedEvent != null)
                RecordChangedEvent(this, e);
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDataForm<T> Members

        T IDataForm<T>.GetDefault()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Databinding Events
        public void DetailBinding_BindingComplete(object sender, System.Windows.Forms.BindingCompleteEventArgs e)
        {
            this.BindingData = false;
        }

        public void DetailBinding_DataSourceChanged(object sender, System.EventArgs e)
        {
            this.BindingData = true;
        }

        public void DetailBinding_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (e.ListChangedType == System.ComponentModel.ListChangedType.ItemAdded)
            {
                if ((_NewRecordProc != null) && _RecordState.DuplicatingData == false && _RecordState.ShowingData == false)
                {
                    DetailBinding[e.NewIndex] = _NewRecordProc.Invoke();

                    //((DataRowView) (DetailBinding[e.NewIndex])).Row.ItemArray = .Row.ItemArray;
                    _RecordState.NewRecordData = ((DataRowView)(DetailBinding[e.NewIndex])).Row;
                }
            }
        }
        #endregion
    }
}
