using Skyline.InternTrainingApp.Common.Domain;
using Skyline.InternTrainingApp.Common.RequestResponse;

namespace Skyline.InternTrainingApp.Common.Interfaces.ExternalServices {

    public interface IRottenTomatoesService {
        BusinessServiceItemResponse<Movie> GetByTitle(string title);
    }
}