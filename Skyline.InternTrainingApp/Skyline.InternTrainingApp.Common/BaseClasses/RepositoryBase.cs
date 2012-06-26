using System;
using Skyline.InternTrainingApp.Common.DataContext;

namespace Skyline.InternTrainingApp.Common.BaseClasses {

    public abstract class RepositoryBase {

        protected ITADataContextBase Context { get; set; }

        public void SetUnitOfWork(UnitOfWork.UnitOfWork u) {
            Context = u.Context;
        }

        public void EnsureUnitOfWorkHasBeenSet() {
            if (Context == null) throw new InvalidOperationException("Unit of Work must be set prior to invoking any Repository methods!");
        }
    }
}