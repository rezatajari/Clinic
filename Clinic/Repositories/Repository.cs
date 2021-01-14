using Clinic.Model;
using Clinic.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clinic.Repositories
{
    public class Repository : IRepository
    {
        public static List<Patient> GetPatient;

        public Task GeneratingPatient()
        {
            GetPatient = new List<Patient>();
            int Id = 0;

            while (true)
            {
                var patient = new Patient();
                var gender = patient.GetGender();
                var fullName = patient.GetFullName(gender);
                var sickness = patient.GetSickness();
                var severityOfDisease = patient.GetSeverityOfDisease();

                patient.Id = ++Id;
                patient.Gender = gender;
                patient.FullName = fullName;
                patient.Sickness = sickness;
                patient.SeverityOfDisease = severityOfDisease;

                GetPatient.Add(patient);

                Thread.Sleep(1000);
            }
        }

        public async Task Reception(int receptionId)
        {
            while (true)
            {
                





                var reception = new Reception()
                {
                    Id = receptionId,
                    Patients = ,
                    Date = DateTime.Today
                };

                Thread.Sleep(2000);
            }
        }
    }
}
