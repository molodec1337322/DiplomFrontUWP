using DiplomFrontUWP.Utils.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomFrontUWP.Utils.Interfaces
{
    internal interface IAPIWorker
    {
        Task<string> GetTest();
    }
}
