namespace Skyline.InternTrainingApp.Common.RequestResponse {

    public class BusinessServiceItemResponse<T> : BusinessServiceResponse {

        /// <summary>
        ///   Item
        /// </summary>
        public T Item { get; set; }
    }
}