using Skyline.InternTrainingApp.Common.RequestResponse;

namespace Skyline.InternTrainingApp.Common.Interfaces.Business {

    /// <summary>
    /// Interface for *ALL* Business Service Classes
    /// </summary>
    /// <typeparam name="T">Type Param</typeparam>
    public interface IBusinessService<T> {
        BusinessServiceListResponse<T> All();
        BusinessServiceItemResponse<T> GetByID(long id);
        BusinessServiceResponse Maintain(T t);
    }
}