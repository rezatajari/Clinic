using Clinic.Model;
using Clinic.Repositories.Interface;
using Clinic.View;
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

        public async Task GeneratingPatient()
        {
            GetPatient = new List<Patient>();
            int Id = 0;

            while (true)
            {
                await Task.Run(() =>
                {
                    var patient = new Patient();
                    var gender = patient.GetGender();
                    var fullName = patient.GetFullName(gender);
                    var age = new Random().Next(5, 80);
                    var sickness = patient.GetSickness();
                    var severityOfDisease = patient.GetSeverityOfDisease();

                    patient.Id = ++Id;
                    patient.Gender = gender;
                    patient.FullName = fullName;
                    patient.Age = age;
                    patient.Sickness = sickness;
                    patient.SeverityOfDisease = severityOfDisease;

                    GetPatient.Add(patient);
                });

                Thread.Sleep(1000);
            }
        }

        public async Task Reception()
        {
            int receptionId = 0;
            var listReception = new List<Reception>();

            while (true)
            {
                await Task.Run(() =>
                {
                    foreach (var patient in GetPatient)
                    {
                        listReception.Add(new Reception()
                        {
                            Id = ++receptionId,
                            Date = DateTime.Now,
                            Patients = patient,
                            Score = SetRateScore(patient.Gender, patient.Age,
                                                 patient.Sickness, patient.SeverityOfDisease)
                        });
                    }

                    var acceptPatient = listReception.OrderBy(s => s.Score).FirstOrDefault();
                    var report = new ShowResult();
                    report.Report(acceptPatient);
                    GetPatient.Remove(acceptPatient.Patients);
                    listReception.Remove(acceptPatient);
                });

                Thread.Sleep(2000);
            }
        }

        public int SetRateScore(bool gender, int age, Sickness sickness,
                                SeverityOfDisease severityOfDisease)
        {
            int score = 0;

            // امتیاز دهی بر اساس سن و جنسیت 
            switch (gender)
            {
                case true:
                    if (age > 5 && age < 10) score = 3;
                    else if (age > 10 && age < 20) score = 7;
                    else score = 13;
                    break;
                case false:
                    if (age > 5 && age < 10) score = 5;
                    else if (age > 10 && age < 20) score = 10;
                    else score = 15;
                    break;
            }

            // امتیاز دهی بر اساس نوع مریضی و شدت آن
            switch (severityOfDisease)
            {
                case SeverityOfDisease.Weak:
                    switch (sickness)
                    {
                        case Sickness.HeartAttack:
                            score += 40;
                            break;
                        case Sickness.Thalassemia:
                            score += 10;
                            break;
                        case Sickness.Canser:
                            score += 20;
                            break;
                        case Sickness.Covid19:
                            score += 30;
                            break;
                        case Sickness.Cold:
                            score += 5;
                            break;
                    }
                    break;
                case SeverityOfDisease.Normal:
                    switch (sickness)
                    {
                        case Sickness.HeartAttack:
                            score += 45;
                            break;
                        case Sickness.Thalassemia:
                            score += 15;
                            break;
                        case Sickness.Canser:
                            score += 25;
                            break;
                        case Sickness.Covid19:
                            score += 35;
                            break;
                        case Sickness.Cold:
                            score += 10;
                            break;
                    }
                    break;
                case SeverityOfDisease.Acute:
                    switch (sickness)
                    {
                        case Sickness.HeartAttack:
                            score += 50;
                            break;
                        case Sickness.Thalassemia:
                            score += 20;
                            break;
                        case Sickness.Canser:
                            score += 30;
                            break;
                        case Sickness.Covid19:
                            score += 40;
                            break;
                        case Sickness.Cold:
                            score += 15;
                            break;
                    }
                    break;
            }

            return score;
        }
    }


}

