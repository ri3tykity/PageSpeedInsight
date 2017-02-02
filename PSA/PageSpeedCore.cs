using System;
using PSA.DataModel;
using PSA.DataRepository;

namespace PSA
{
    public class PageSpeedCore
    {
        // TODO: get these variables name from appsetting.
        private readonly string GooglePageSpeedAPIBaseURL = "https://www.googleapis.com/pagespeedonline/v2/runPagespeed?url=";
        private readonly string GooglePageSpeedAPIAuthToken = "AIzaSyA8419Hk-EeD4FRiD5UHD0W2w7Brgm5hiM";
        private readonly string QueryKey = "&key=";

        // Entry method for page speed api. Pass url and get result.
        // Every successfull operation store result in database.
        public string FetchURL(string v)
        {
            string result = string.Empty;
            if (IsValidURL(v))
            {
                // create data object to save
                PageSpeedData pData = new PageSpeedData();
                // get repository base
                IDatabaseRepo repository = DataRepositoryFactory.FactoryMethod("SqlLite");
                // common operation
                string domainURL = ExtractDomainFromURL(v);
                string fullFormatedURL = GooglePageSpeedAPIBaseURL + domainURL + QueryKey + GooglePageSpeedAPIAuthToken;
                result = HttpGet(fullFormatedURL);
                // set object
                pData.SiteName = domainURL;
                pData.Result = result;
                // save object
                repository.SaveResult(pData);
            }
            else
            {
                result = "URL is not valid.";
            }
            return result;
        }

        public bool IsValidURL(string URL)
        {
            Uri uriResult;
            return Uri.TryCreate(URL, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        public string ExtractDomainFromURL(string rawURL)
        {
            Uri uri = new Uri(rawURL);
            string result = string.Empty;
            //var host = new System.Uri(rawURL).Host;
            if (uri.PathAndQuery.Length > 1)
                result = uri.OriginalString.Replace(uri.PathAndQuery, "");
            else result = uri.OriginalString;
            return result;
        }

        public static string HttpGet(string URI)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            req.Proxy = new System.Net.WebProxy(); //true means no proxy
            try
            {
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                return sr.ReadToEnd().Trim();
            }
            catch (Exception)
            {
                return "Couldn't fetch result.";
            }
        }
    }
}
