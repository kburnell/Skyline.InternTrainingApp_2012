using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skyline.InternTrainingApp.Common.Domain.Interfaces {

    /// <summary>
    /// Interface for a Validatable Domain entity
    /// </summary>
    public interface IValidatableDomain {
        bool IsValid { get; }
        IList<ValidationResult> Validate();
    }
}