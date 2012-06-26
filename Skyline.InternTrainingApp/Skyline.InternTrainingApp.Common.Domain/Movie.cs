using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ITA.Common.Enumerations;
using Skyline.InternTrainingApp.Common.Domain.BaseClasses;

namespace Skyline.InternTrainingApp.Common.Domain {

    public class Movie : DomainBase {

        public long Id { get; set; }

        [Required, StringLength(150)]
        public string Title { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required, StringLength(6)]
        public string MpaaRating { get; set; }

        [StringLength(250)]
        public string ImageUrl { get; set; }

        [StringLength(1500)]
        public string Synopsis { get; set; }

        [StringLength(250)]
        public string ClipsUrl { get; set; }

        public long AudienceRating { get; set; }

        public IList<Person> People { get; set; }

        public IList<Person> Actors {
            get { return People.Where(x => x.PersonType == PersonType.Actor).ToList(); }
        }

        public IList<Person> Directors {
            get { return People.Where(x => x.PersonType == PersonType.Director).ToList(); }
        } 

        public IList<Genre> Genres { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            List<ValidationResult> results = new List<ValidationResult>();
            Validator.TryValidateProperty(Title, new ValidationContext(this, null, null) { MemberName = "Title" }, results);
            Validator.TryValidateProperty(ReleaseDate, new ValidationContext(this, null, null) { MemberName = "ReleaseDate" }, results);
            Validator.TryValidateProperty(MpaaRating, new ValidationContext(this, null, null) { MemberName = "MpaaRating" }, results);
            Validator.TryValidateProperty(ImageUrl, new ValidationContext(this, null, null) { MemberName = "ImageUrl" }, results);
            Validator.TryValidateProperty(Synopsis, new ValidationContext(this, null, null) { MemberName = "Synopsis" }, results);
            Validator.TryValidateProperty(ClipsUrl, new ValidationContext(this, null, null) { MemberName = "ClipsUrl" }, results);
            results.AddRange(Validate());
            return results;
        }

    }
}