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

namespace SoftLogik.Win
{
	namespace UI
	{
		public enum SPRecordNavigateDirections
		{
			@None,
			First,
			Previous,
			@Next,
			Last
		}
		
		public enum SPFormRecordModes
		{
			InsertMode,
			EditMode,
			DirtyMode
		}
		
		public enum SPFormDataStates
		{
			@New,
			@Edited,
			@Deleted
		}
		
		public enum SPValidationItemCommands
		{
			@ValidateText,
			@ValidateNumber,
			@Validate,
			@ValidatePhone
		}
	}
	
}
