using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Model
{
    public class Reception
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Patient Patients { get; set; }
        public int Score { get; set; }
    }
}