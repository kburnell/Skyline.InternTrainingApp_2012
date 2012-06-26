using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ITA.Common.Enumerations;

namespace Skyline.InternTrainingApp.Common.RequestResponse {

    /// <summary>
    /// Base Information from a service call
    /// </summary>
    public class BusinessServiceResponse {

        /// <summary>
        ///   Error
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        ///   Warnings
        /// </summary>
        public IList<ValidationResult> ValidationInformation { get; set; }

        /// <summary>
        ///   Application Errors
        /// </summary>
        public IList<string> ApplicationErrors { get; set; }

        /// <summary>
        ///   Service Response Type
        /// </summary>
        public BusinessServiceResponseStatusType Status {
            get {
                if (Exception != null) return BusinessServiceResponseStatusType.Failure;
                if (ApplicationErrors != null && ApplicationErrors.Count != 0) return BusinessServiceResponseStatusType.ApplicationError;
                if (ValidationInformation != null && ValidationInformation.Count != 0) return BusinessServiceResponseStatusType.Invalid;
                return BusinessServiceResponseStatusType.Success;
            }
        }
    }
}