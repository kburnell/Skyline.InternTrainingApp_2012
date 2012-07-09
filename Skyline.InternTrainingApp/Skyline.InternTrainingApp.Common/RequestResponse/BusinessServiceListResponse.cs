using System.Collections.Generic;

namespace Skyline.InternTrainingApp.Common.RequestResponse {

    public class BusinessServiceListResponse<T> : BusinessServiceResponse {

        /// <summary>
        ///   List
        /// </summary>
        public IList<T> List { get; set; }

        public bool HasData { get { return List != null && List.Count != 0; } }
    }
}