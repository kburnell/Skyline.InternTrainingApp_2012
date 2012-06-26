using System;
using System.Data.Entity;

namespace Skyline.InternTrainingApp.Common.DataContext {

    /// <summary>
    ///   DEVELOPMENT Data Context Initializer
    /// </summary>
    public class ITADataContextDevInitializer : DropCreateDatabaseIfModelChanges<ITADataContext> {

        #region << Private Fields >>

        private const string CreatedBy = "SeededData";
        private readonly DateTime _createdOn = DateTime.Now;

        #endregion

        #region << Public/Protected Methods >>

        protected override void Seed(ITADataContext context) {
            base.Seed(context);
        }

        #endregion
    }
}