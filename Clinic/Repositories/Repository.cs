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
                    var age = new Random().Next(5, 80);  // بازه سن هر فرد بین 5 سال تا 80 سال
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
                            Score = GetScore(patient)
                        });
                    }

                    // کل لیست جدید که ساخته شده رو از لیست مرجع پاک می کنیم
                    var clearGetPatient = listReception.Select(l => l.Patients.Id).ToList();
                    GetPatient = GetPatient.Where(l => !clearGetPatient.Contains(l.Id)).ToList();

                    // بیماری مورد قبول می باشد که از لحاظ امتیاز حاد بودن شرایطش و سپس بر اساس
                    // زمان ورود زودتر وارد مطب شود
                    var acceptPatient = listReception.OrderByDescending(s => s.Score)
                                                     .ThenBy(d => d.Date).FirstOrDefault();

                    new ShowResult().Report(acceptPatient);

                    // حذف بیمار از لیست باگانی پذیرش
                    listReception.Remove(acceptPatient);
                });

                Thread.Sleep(2000);
            }
        }

        public int GetScore(Patient patient)
        {
            // امتیاز دهی براساس جنسیت و سن
            IGenderScore gender;
            if (patient.Gender)
                gender = new Man();                  // polymorphism
            else
                gender = new Woman();                // polymorphism

            int getGenderScore = gender.GetScoreByGenderAndAge(patient.Age);


            // امتیازدهی براساس نوع مریضی و شدت آن
            ISicknessScore sickness;
            switch (patient.Sickness)
            {
                case Sickness.HeartAttack:
                    sickness = new HeartAttack();   // polymorphism  
                    break;
                case Sickness.Thalassemia:
                    sickness = new Thalassemia();   // polymorphism
                    break;
                case Sickness.Canser:
                    sickness = new Canser();        // polymorphism
                    break;
                case Sickness.Covid19:
                    sickness = new Covid19();       // polymorphism
                    break;
                case Sickness.Cold:
                    sickness = new Cold();          // polymorphism
                    break;
                default:
                    sickness = new Cold();          // polymorphism
                    break;
            }

            int getSicknessScore = sickness.GetScoreBySickness(patient.SeverityOfDisease);

            return getGenderScore + getSicknessScore;
        }
    }
}

