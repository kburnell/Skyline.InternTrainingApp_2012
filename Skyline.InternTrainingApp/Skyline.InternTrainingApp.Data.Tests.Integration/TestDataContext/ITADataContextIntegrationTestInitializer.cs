using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;
using Skyline.InternTrainingApp.Common.DataContext;

namespace Skyline.InternTrainingApp.Data.Tests.Integration.TestDataContext {

    /// <summary>
    /// Data Context Initializer for running Integration Tests
    /// </summary>
    public class ITADataContextIntegrationTestInitializer : DropCreateDatabaseIfModelChanges<ITADataContext> {

        #region << Private Fields >>

        private const string CreatedBy = "Test - SeededData";
        private readonly DateTime _createdOn = DateTime.Now;

        #endregion

        #region << Public/Protected Methods >>

        protected override void Seed(ITADataContext context)
        {
            base.Seed(context);
            try {
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx) {
                //Entity validation exception, so something didn't validate
                //Do Microsoft's job and make clear what actually happened so we can fix it!
                StringBuilder errMsg = new StringBuilder();
                foreach (DbEntityValidationResult validationErrors in dbEx.EntityValidationErrors) {
                    foreach (DbValidationError validationError in validationErrors.ValidationErrors) {
                        errMsg.AppendLine(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
                throw new InvalidOperationException(errMsg.ToString(), dbEx.InnerException);
            }
        }

        #endregion

    }
}