using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ITA.Common.Enumerations;
using Skyline.InternTrainingApp.Common.Domain.BaseClasses;

namespace Skyline.InternTrainingApp.Common.Domain {

    public class Person : DomainBase  {

        public long Id { get; set; }

        [Required, StringLength(250)]
        public string FullName { get; set; }

        public int PersonTypeId { get; set; }

        public PersonType PersonType {
            get { return (PersonType) PersonTypeId; }
            set { PersonTypeId = (int)value; }
        }

        public IList<Movie> Movies { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            List<ValidationResult> results = new List<ValidationResult>();
            Validator.TryValidateProperty(FullName, new ValidationContext(this, null, null) {MemberName = "FullName" }, results);
            results.AddRange(Validate());
            return results;
        }
    }
}