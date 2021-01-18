using Clinic.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Repositories.Interface
{
    public interface IRepository
    {
        Task GeneratingPatient();
        Task Reception();

    }
}
