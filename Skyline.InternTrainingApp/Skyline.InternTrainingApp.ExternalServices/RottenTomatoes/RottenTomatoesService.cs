using System.Net;
using System.Web;
using Skyline.InternTrainingApp.Common.Interfaces.ExternalServices;

namespace Skyline.InternTrainingApp.ExternalServices.RottenTomatoes {

    public class RottenTomatoesService : IRottenTomatoesService {

        #region << Private Fields and Constants >>
        

        private const string BaseUrl = "http://api.rottentomatoes.com/api/public/v1.0/movies.json?apikey=4zmfvqnwud73a4mcxa6cqztg";
        private const string FindByTitleParam = "&q={0}&page_limit=1";

        #endregion

        #region << Public Methods >>

        public void GetByTitle(string movieTitle) {
            string url = string.Format((BaseUrl + FindByTitleParam),HttpUtility.UrlEncode(movieTitle));
            var json = new WebClient().DownloadString(url);
        } 


        #endregion

        #region << Private Methods >>

         

        #endregion
    }
}