using System.Collections.Generic;
using System.Linq;
using ITA.Common.Enumerations;
using Skyline.InternTrainingApp.Common.BaseClasses;
using Skyline.InternTrainingApp.Common.Domain;
using Skyline.InternTrainingApp.Common.Interfaces.Data;

namespace Skyline.InternTrainingApp.Data {

    public class PersonRepository : RepositoryBase, IPersonRepository {

        public IList<Person> All() {
            throw new System.NotImplementedException();
        }

        public Person GetByID(long id) {
            throw new System.NotImplementedException();
        }

        public void Maintain(Person t) {
            throw new System.NotImplementedException();
        }

        public IList<Person> GetByPersonType(PersonType personType) {
            EnsureUnitOfWorkHasBeenSet();
            return Context.People.Where(x => x.PersonTypeId == (int)personType).ToList();
        }
    }

}