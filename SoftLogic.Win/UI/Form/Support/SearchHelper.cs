using SubSonic;
using System.Data;
using SoftLogik.Win.Data;


namespace SoftLogik.Win.UI.Support
{
	public class SPSearchHelper
	{


        public static SimpleSearchCollection GetSearchResults(string SearchType, string SubType, string SearchFor, string SearchItem)
        {
            return GetSearchResults(SearchType, SubType, SearchFor, SearchItem, null);
        }

        public static SimpleSearchCollection GetSearchResults(string SearchType, string SubType, string SearchFor, string SearchItem, string ConnectionString)
        {
            StoredProcedure sp = new StoredProcedure("SLLookupSearch");
            sp.Command.AddParameter("@SearchType", SearchType);
            sp.Command.AddParameter("@SubType", SubType);
            sp.Command.AddParameter("@SearchFor", SearchFor);
            sp.Command.AddParameter("@SearchItem", SearchItem);

            IDataReader results = sp.GetReader();

            SimpleSearchCollection sCol = new SimpleSearchCollection();
            while (results.Read())
            {
                SimpleSearch ss = new SimpleSearch();
                ss.ID = (string)results["ID"];
                ss.Name = (string)results["Name"];
                sCol.Add(ss);
            }

            return sCol;
        }
	}
}
