namespace Skyline.InternTrainingApp.Common.RequestResponse {

    public class BusinessServiceItemResponse<T> : BusinessServiceResponse {

        /// <summary>
        ///   Item
        /// </summary>
        public T Item { get; set; }

        public bool HasData { get { return Item != null; } }
    }
}