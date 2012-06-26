using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Skyline.InternTrainingApp.Common.Domain.Interfaces;

namespace Skyline.InternTrainingApp.Common.Domain.BaseClasses {

    /// <summary>
    ///   Base class for all Domain entities
    /// </summary>
    public class DomainBase : IValidatableDomain {

        #region << Public Properties >>

        public bool IsActive { get; set; }

        [StringLength(60)]
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        [StringLength(60)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsValid { get { return Validate().Count == 0; } } 

        #endregion

        #region << Public Methods >>

        public IList<ValidationResult> Validate() {
            List<ValidationResult> results = new List<ValidationResult>();
            Validator.TryValidateProperty(CreatedBy, new ValidationContext(this, null, null) {MemberName = "CreatedBy"}, results);
            Validator.TryValidateProperty(ModifiedBy, new ValidationContext(this, null, null) {MemberName = "ModifiedBy"}, results);
            return results;
        } 

        #endregion

    }
}