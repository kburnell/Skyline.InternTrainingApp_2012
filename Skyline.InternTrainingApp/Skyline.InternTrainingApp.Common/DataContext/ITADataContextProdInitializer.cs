using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Skyline.InternTrainingApp.Common.DataContext
{
    /// <summary>
    /// PRODUCTION Data Context Initializer
    /// </summary>
    public class ITADataContextProdInitializer : CreateDatabaseIfNotExists<ITADataContext> { }
}
