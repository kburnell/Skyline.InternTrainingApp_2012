using System.Collections.Generic;
using ITA.Common.Enumerations;
using Skyline.InternTrainingApp.Common.Domain;

namespace Skyline.InternTrainingApp.Common.Interfaces.Data {

    public interface IPersonRepository : IRepository<Person> {

        IList<Person> GetByPersonType(PersonType personType);

    }

}