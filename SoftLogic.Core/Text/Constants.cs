using System;

namespace SoftLogik
{
    public class TemplateName
    {
        public const string CLASS = "ClassTemplate";

        public const string DYNAMIC_SCAFFOLD = "DynamicScaffold";
        public const string GENERATED_SCAFFOLD_CODE_BEHIND = "GeneratedScaffoldCodeBehind";
        public const string GENERATED_SCAFFOLD_MARKUP = "GeneratedScaffoldMarkup";
        public const string ODS_CONTROLLER = "ODSController";
        public const string STORED_PROCEDURE = "Template";
        public const string STRUCTS = "StructsTemplate";
        public const string VIEW = "ViewTemplate";
    }

    public class TemplateVariable
    {
        public const string ARGUMENT_LIST = "#ARGLIST#";
        public const string BIND_LIST = "#BINDLIST#";
        public const string CLASS_NAME = "#CLASSNAME#";
        public const string CLASS_NAME_COLLECTION = "#CLASSNAMECOLLECTION#";
        public const string COLUMNS_STRUCT = "#COLUMNSSTRUCT#";
        public const string CONTROL_PROPERTY = "#CONTROLPROPERTY#";
        public const string DROP_LIST = "#DROPLIST#";
        public const string EDITOR_ROWS = "#EDITORROWS#";
        public const string FK_VAR = "#FKVAR#";
        public const string FOREIGN_CLASS = "#FOREIGNCLASS#";
        public const string FOREIGN_PK = "#FOREIGNPK#";
        public const string FOREIGN_TABLE = "#FOREIGNTABLE#";
        public const string GETTER = "#GETTER#";
        public const string GRID_ROWS = "#GRIDROWS#";
        public const string INSERT = "#INSERT#";
        public const string JAVASCRIPT_BLOCK = "#JAVASCRIPTBLOCK#";
        public const string LANGUAGE = "#LANGUAGE#";
        public const string LANGUAGE_EXTENSION = "#LANGEXTENSION#";
        public const string MANY_METHODS = "#MANYMETHODS#";
        public const string MAP_TABLE = "#MAPTABLE#";
        public const string MASTER_PAGE = "#MASTERPAGE#";
        public const string METHOD_BODY = "#METHODBODY#";
        public const string METHOD_LIST = "#METHODLIST#";
        public const string METHOD_NAME = "#METHODNAME#";
        public const string METHOD_TYPE = "#METHODTYPE#";
        public const string NAMEACE_USING = "#NAMEACE_USING#";
        public const string PAGE_BIND_LIST = "#PAGEBINDLIST#";
        public const string PAGE_CLASS = "#PAGECLASS#";
        public const string PAGE_CODE = "#PAGECODE#";
        public const string PAGE_FILE = "#PAGEFILE#";
        public const string PARAMETERS = "#PARAMS#";
        public const string PK = "#PK#";
        public const string PK_PROP = "#PKPROP#";
        public const string PK_VAR = "#PKVAR#";
        public const string PROPERTY_LIST = "#PROPLIST#";
        public const string PROPERTY_NAME = "#PROPNAME#";
        public const string PROPERTY_TYPE = "#PROPTYPE#";
        public const string PROVIDER = "#PROVIDER#";
        public const string SET_LIST = "#SETLIST#";
        public const string SETTER = "#SETTER#";
        public const string STORED_PROCEDURE_NAME = "#NAME#";
        public const string STRUCT_ASSIGNMENTS = "#STRUCTASSIGNMENTS#";
        public const string STRUCT_LIST = "#STRUCTLIST#";
        public const string SUMMARY = "#SUMMARY#";
        public const string TABLE_NAME = "#TABLENAME#";
        public const string TABLE_SCHEMA = "#TABLESCHEMA#";
        public const string UPDATE = "#UPDATE#";
    }

    public class ReservedColumnName
    {
        public const string CREATED_BY = "CreatedBy";
        public const string CREATED_ON = "CreatedOn";
        public const string DELETED = "Deleted";
        public const string IS_ACTIVE = "IsActive";
        public const string IS_DELETED = "IsDeleted";
        public const string MODIFIED_BY = "ModifiedBy";
        public const string MODIFIED_ON = "ModifiedOn";
    }

    public class ConfigurationSectionName
    {
        public const string PROVIDERS = "providers";
        public const string SUB_SONIC_SERVICE = "SubSonicService";
    }

    public class ConfigurationPropertyName
    {
        public const string APPEND_WITH = "appendWith";
        public const string ADDITIONAL_NAMEACES = "additionalNamespaces";
        public const string CONNECTION_STRING_NAME = "connectionStringName";
        public const string DEFAULT_PROVIDER = "defaultProvider";
        public const string ENABLE_TRACE = "enableTrace";
        public const string EXCLUDE_PROCEDURE_LIST = "excludeProcedureList";
        public const string EXCLUDE_TABLE_LIST = "excludeTableList";
        public const string EXTRACT_CLASS_NAME_FROM__NAME = "extractClassNameFromName";
        public const string FIX_DATABASE_OBJECT_CASING = "fixDatabaseObjectCasing";
        public const string FIX_PLURAL_CLASS_NAMES = "fixPluralClassNames";
        public const string GENERATE_LAZY_LOADS = "generateLazyLoads";
        public const string GENERATE_NULLABLE_PROPERTIES = "generateNullableProperties";
        public const string GENERATE_ODS_CONTROLLERS = "generateODSControllers";
        public const string GENERATE_RELATED_TABLES_AS_PROPERTIES = "generateRelatedTablesAsProperties";
        public const string GENERATED_NAMEACE = "generatedNamespace";
        public const string INCLUDE_PROCEDURE_LIST = "includeProcedureList";
        public const string INCLUDE_TABLE_LIST = "includeTableList";
        public const string MANY_TO_MANY_SUFFIX = "manyToManySuffix";
        public const string PROVIDER_TO_USE = "provider";
        public const string REGEX_DICTIONARY_REPLACE = "regexDictionaryReplace";
        public const string REGEX_IGNORE_CASE = "regexIgnoreCase";
        public const string REGEX_MATCH_EXPRESSION = "regexMatchExpression";
        public const string REGEX_REPLACE_EXPRESSION = "regexReplaceExpression";
        public const string RELATED_TABLE_LOAD_PREFIX = "relatedTableLoadPrefix";
        public const string REMOVE_UNDERSCORES = "removeUnderscores";
        public const string SET_PROPERTY_DEFAULTS_FROM_DATABASE = "setPropertyDefaultsFromDatabase";
        public const string _STARTS_WITH = "spStartsWith";
        public const string STORED_PROCEDURE_CLASS_NAME = "spClassName";
        public const string STRIP_COLUMN_TEXT = "stripColumnText";
        public const string STRIP_PARAM_TEXT = "stripParamText";
        public const string STRIP_STORED_PROCEDURE_TEXT = "stripText";
        public const string STRIP_TABLE_TEXT = "stripTableText";
        public const string STRIP_VIEW_TEXT = "stripViewText";
        public const string TEMPLATE_DIRECTORY = "templateDirectory";
        public const string USE_EXTENDED_PROPERTIES = "useExtendedProperties"; //SQL 2000/2005 Only
        public const string USE_STORED_PROCEDURES = "uses";
        public const string VIEW_STARTS_WITH = "viewStartsWith";
    }

    public class DataProviderTypeName
    {
        public const string ENTERPRISE_LIBRARY = "ELib3DataProvider";
        public const string MY_SQL = "MySqlDataProvider";
        public const string ORACLE = "OracleDataProvider";
        public const string SQL_SERVER = "SqlDataProvider";
    }

    public class ClassName
    {
        public const string STORED_PROCEDURES = "s";
        public const string TABLES = "Tables";
        public const string VIEWS = "Views";
    }

    public class CodeBlock
    {
        public static readonly string JS_BEGIN_SCRIPT = "<script language=\"javascript\" type=\"text/javascript\">" + Environment.NewLine;
        public static readonly string JS_END_SCRIPT = "</script>" + Environment.NewLine;
    }

    public class ControlValueProperty
    {
        public const string CALENDAR = "SelectedDate";
        public const string CHECK_BOX = "Checked";
        public const string DROP_DOWN_LIST = "SelectedValue";
        public const string LABEL = "Text";
        public const string TEXT_BOX = "Text";
    }

    public class AggregateFunctionName
    {
        public const string AVERAGE = "AVG";
        public const string COUNT = "COUNT";
        public const string MAX = "MAX";
        public const string MIN = "MIN";
        public const string SUM = "SUM";
    }

    public class SqlFragment
    {
        public const string AND = " AND ";
        public const string AS = " AS ";
        public const string ASC = " ASC";
        public const string BETWEEN = " BETWEEN ";
        public const string DELETE_FROM = "DELETE FROM ";
        public const string DESC = " DESC";
        public const string DISTINCT = "DISTINCT ";
        public const string EQUAL_TO = " = ";
        public const string FROM = " FROM ";
        public const string IN = " IN ";
        public const string INNER_JOIN = " INNER JOIN ";
        public const string INSERT_INTO = "INSERT INTO ";
        public const string JOIN_PREFIX = "J";
        public const string LEFT_JOIN = " LEFT JOIN ";
        public const string ON = " ON ";
        public const string OR = " OR ";
        public const string ORDER_BY = " ORDER BY ";
        public const string SELECT = "SELECT ";
        public const string SET = " SET ";
        public const string ACE = " ";
        public const string TOP = "TOP ";
        public const string UPDATE = "UPDATE ";
        public const string WHERE = " WHERE ";
    }

    public class SqlSchemaVariable
    {
        public const string COLUMN_DEFAULT = "DefaultSetting";
        public const string COLUMN_NAME = "ColumnName";
        public const string CONSTRAINT_TYPE = "constraintType";
        public const string DATA_TYPE = "DataType";
        public const string DEFAULT = "DEFAULT";
        public const string FOREIGN_KEY = "FOREIGN KEY";
        public const string IS_COMPUTED = "IsComputed";
        public const string IS_IDENTITY = "IsIdentity";
        public const string IS_NULLABLE = "IsNullable";
        public const string MAX_LENGTH = "MaxLength";
        public const string MODE = "mode";
        public const string MODE_INOUT = "INOUT";
        public const string NAME = "Name";
        public const string PARAMETER_PREFIX = "@";
        public const string PRIMARY_KEY = "PRIMARY KEY";
        public const string TABLE_NAME = "TableName";
    }

    public class OracleSchemaVariable
    {
        public const string COLUMN_NAME = "COLUMN_NAME";
        public const string CONSTRAINT_TYPE = "CONSTRAINT_TYPE";
        public const string DATA_TYPE = "DATA_TYPE";
        public const string IS_NULLABLE = "NULLABLE";
        public const string MAX_LENGTH = "CHAR_LENGTH";
        public const string MODE = "IN_OUT";
        public const string MODE_INOUT = "IN/OUT";
        public const string NAME = "ARGUMENT_NAME";
        public const string NUMBER_PRECISION = "DATA_PRECISION";
        public const string NUMBER_SCALE = "DATA_SCALE";
        public const string PARAMETER_PREFIX = ":";
        public const string TABLE_NAME = "TABLE_NAME";
    }

    public class MySqlSchemaVariable
    {
        public const string PARAMETER_PREFIX = "?";
    }

    public class ServerVariable
    {
        public const string SERVER_NAME = "SERVER_NAME";
        public const string SERVER_PORT = "SERVER_PORT";
        public const string SERVER_PORT_SECURE = "SERVER_PORT_SECURE";
    }

    public class Ports
    {
        public const string HTTP = "80";
        public const string HTTPS = "443";
    }

    public class ProtocolPrefix
    {
        public const string HTTP = "http://";
        public const string HTTPS = "https://";
    }

    public class CodeFragment
    {
        public const string NULLABLE_VARIABLE = "?";
        public const string NULLABLE_VARIABLE_VB = "Nullable(Of {0})";
    }

    public class ScaffoldCSS
    {
        public const string BUTTON = "scaffoldButton";
        public const string EDIT_ITEM = "scaffoldEditItem";
        public const string EDIT_ITEM_CAPTION = "scaffoldEditItemCaption";
        public const string EDIT_TABLE = "scaffoldEditTable";
        public const string EDIT_TABLE_LABEL = "scaffoldEditTableLabel";
        public const string TEXT_BOX = "scaffoldTextBox";
        public const string WRAPPER = "scaffoldWrapper";
    }

    public class RegexPattern
    {
        public const string ALPHA = "[^a-zA-Z]";
        public const string ALPHA_NUMERIC = "[^a-zA-Z0-9]";
        public const string CREDIT_CARD_AMERICAN_EXPRESS = @"^(?:(?:[3][4|7])(?:\d{13}))$";
        public const string CREDIT_CARD_CARTE_BLANCHE = @"^(?:(?:[3](?:[0][0-5]|[6|8]))(?:\d{11,12}))$";
        public const string CREDIT_CARD_DINERS_CLUB = @"^(?:(?:[3](?:[0][0-5]|[6|8]))(?:\d{11,12}))$";
        public const string CREDIT_CARD_DISCOVER = @"^(?:(?:6011)(?:\d{12}))$";
        public const string CREDIT_CARD_EN_ROUTE = @"^(?:(?:[2](?:014|149))(?:\d{11}))$";
        public const string CREDIT_CARD_JCB = @"^(?:(?:(?:2131|1800)(?:\d{11}))$|^(?:(?:3)(?:\d{15})))$";
        public const string CREDIT_CARD_MASTER_CARD = @"^(?:(?:[5][1-5])(?:\d{14}))$";
        public const string CREDIT_CARD_STRIP_NON_NUMERIC = @"(\-|\s|\D)*";
        public const string CREDIT_CARD_VISA = @"^(?:(?:[4])(?:\d{12}|\d{15}))$";
        public const string EMAIL = @"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";
        public const string EMBEDDED_CLASS_NAME_MATCH = "(?<=^_).*?(?=_)";
        public const string EMBEDDED_CLASS_NAME_REPLACE = "^_.*?_";
        public const string EMBEDDED_CLASS_NAME_UNDERSCORE_MATCH = "(?<=^UNDERSCORE).*?(?=UNDERSCORE)";
        public const string EMBEDDED_CLASS_NAME_UNDERSCORE_REPLACE = "^UNDERSCORE.*?UNDERSCORE";
        public const string GUID = "[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}";
        public const string IP_ADDRESS = @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
        public const string LOWER_CASE = @"^[a-z]+$";
        public const string SOCIAL_SECURITY = @"^\d{3}[-]?\d{2}[-]?\d{4}$";
        public const string STRONG_PASSWORD = @"(?=^.{8,255}$)((?=.*\d)(?=.*[A-Z])(?=.*[a-z])|(?=.*\d)(?=.*[^A-Za-z0-9])(?=.*[a-z])|(?=.*[^A-Za-z0-9])(?=.*[A-Z])(?=.*[a-z])|(?=.*\d)(?=.*[A-Z])(?=.*[^A-Za-z0-9]))^.*";
        public const string UPPER_CASE = @"^[A-Z]+$";
        public const string URL = @"^^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_=]*)?$";
        public const string US_CURRENCY = @"^\$(([1-9]\d*|([1-9]\d{0,2}(\,\d{3})*))(\.\d{1,2})?|(\.\d{1,2}))$|^\$[0](.00)?$";
        public const string US_TELEPHONE = @"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$";
        public const string US_ZIPCODE = @"^\d{5}$";
        public const string US_ZIPCODE_PLUS_FOUR = @"^\d{5}((-|\s)?\d{4})$";
        public const string US_ZIPCODE_PLUS_FOUR_OPTIONAL = @"^\d{5}((-|\s)?\d{4})?$";
    }

    public class ExtendedPropertyName
    {
        public const string SSX_COLUMN_BINARY_FILE_EXTENSION = "SSX_COLUMN_BINARY_FILE_EXTENSION";
        public const string SSX_COLUMN_DILAY_NAME = "SSX_COLUMN_DILAY_NAME";
        public const string SSX_COLUMN_PROPERTY_NAME = "SSX_COLUMN_PROPERTY_NAME";
        public const string SSX_TABLE_CLASS_NAME_PLURAL = "SSX_TABLE_CLASS_NAME_PLURAL";
        public const string SSX_TABLE_CLASS_NAME_SINGULAR = "SSX_TABLE_CLASS_NAME_SINGULAR";
        public const string SSX_TABLE_DILAY_NAME = "SSX_TABLE_DILAY_NAME";
    }
}