using Clinic.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.View
{
    public class ShowResult
    {
        public void Report(Reception reception)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("====== Report Reception ======");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Reception ID is: {reception.Id}\n" +
                              $"Patient ID is: {reception.Patients.Id}\n" +
                              $"Patient FullName is: {reception.Patients.FullName}\n" +
                              $"Patient Age is: {reception.Patients.Age}\n" +
                              $"Patient Entrance is: {reception.Date}\n" +
                              $"Sickness Type is : {reception.Patients.Sickness}\n" +
                              $"Severity is : {reception.Patients.SeverityOfDisease}\n" +
                              $"Patient Sickness Score is: {reception.Score}\n");
        }
    }
}
