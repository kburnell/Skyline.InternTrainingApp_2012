using System.Collections.Generic;

namespace Skyline.InternTrainingApp.Common.Interfaces.Data {

    /// <summary>
    /// Interface for *ALL* Repository Classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> {

        void SetUnitOfWork(UnitOfWork.UnitOfWork u);
        IList<T> All();
        T GetByID(long id);
        void Maintain(T t);
    }
}