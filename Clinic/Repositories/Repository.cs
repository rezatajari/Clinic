using Clinic.Model;
using Clinic.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clinic.Repositories
{
    public class Repository : IRepository
    {
        public static Patient GetPatient;
        public Task GeneratingPatient()
        {
            GetPatient = new Patient();
            int Id = 0;

            while (true)
            {
                GetPatient.Id = ++Id;

                var gender = GetPatient.GetGender();
                GetPatient.Gender = gender;

                var fullName = GetPatient.GetFullName(gender);
                GetPatient.FullName = fullName;

                var sickness = GetPatient.GetSickness();
                GetPatient.Sickness = sickness;

                Thread.Sleep(1000);
            }

        }
    }
}
