Namespace UI
    Public Enum SPRecordNavigateDirections
        [None]
        First
        Previous
        [Next]
        Last
    End Enum

    Public Enum SPFormRecordModes
        InsertMode
        EditMode
        DirtyMode
    End Enum

    Public Enum SPFormDataStates
        [New]
        [Edited]
        [Deleted]
    End Enum

    Public Enum SPValidationItemCommands
        [ValidateText]
        [ValidateNumber]
        [Validate]
        [ValidatePhone]
    End Enum
End Namespace
