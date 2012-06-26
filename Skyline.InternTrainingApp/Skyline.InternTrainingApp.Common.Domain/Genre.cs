using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Skyline.InternTrainingApp.Common.Domain.BaseClasses;

namespace Skyline.InternTrainingApp.Common.Domain {

    public class Genre : DomainBase {

        public long Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        public IList<Movie> Movies { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            List<ValidationResult> results = new List<ValidationResult>();
            Validator.TryValidateProperty(Title, new ValidationContext(this, null, null) { MemberName = "Title" }, results);
            results.AddRange(Validate());
            return results;
        }

    }
}