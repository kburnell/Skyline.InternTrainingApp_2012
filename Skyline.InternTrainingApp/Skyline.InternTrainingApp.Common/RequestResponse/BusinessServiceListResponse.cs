using System.Collections.Generic;

namespace Skyline.InternTrainingApp.Common.RequestResponse {

    public class BusinessServiceListResponse<T> : BusinessServiceResponse {

        /// <summary>
        ///   List
        /// </summary>
        public IList<T> List { get; set; }
    }
}