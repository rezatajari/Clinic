using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Model
{
    public class Reception
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<Patient> Patients { get; set; }
    }
}