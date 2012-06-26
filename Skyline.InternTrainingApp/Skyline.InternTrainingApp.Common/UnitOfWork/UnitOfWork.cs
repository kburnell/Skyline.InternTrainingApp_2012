using System;
using System.Data.Entity.Validation;
using System.Text;
using Skyline.InternTrainingApp.Common.DataContext;
using Skyline.InternTrainingApp.Common.Utility;

namespace Skyline.InternTrainingApp.Common.UnitOfWork {
    public class UnitOfWork {
        #region << Private Fields >>

        private ITADataContextBase _context;

        #endregion

        #region << Constructors >>

        public UnitOfWork() {
            _context = DependencyResolver.GetConcreteInstanceOf<ITADataContextBase>();
        }

        #endregion

        #region << Public Properties >>

        public ITADataContextBase Context { get { return _context; } }

        #endregion

        #region << Public Methods >>

        public void Commit() {
            try {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx) {
                StringBuilder errMsg = new StringBuilder();
                foreach (DbEntityValidationResult validationErrors in dbEx.EntityValidationErrors) {
                    foreach (DbValidationError validationError in validationErrors.ValidationErrors) {
                        errMsg.AppendLine(string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
                throw new InvalidOperationException(errMsg.ToString(), dbEx.InnerException);
            }
        }

        public void Rollback() {
            _context.Dispose();
            _context = DependencyResolver.GetConcreteInstanceOf<ITADataContextBase>();
        }

        #endregion
    }
}