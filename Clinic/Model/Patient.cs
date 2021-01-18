using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public Sickness Sickness { get; set; }
        public SeverityOfDisease SeverityOfDisease { get; set; }



        public bool GetGender()
        {
            const bool MAN = true;
            const bool WOMAN = false;

            var random = new Random().Next(1, 2);

            return (random == 1) ? MAN : WOMAN;
        }


        public string GetFullName(bool genderType)
        {
            var mans = new List<string>() { "HASAN", "ALI", "MOHAMMAD", "REZA", "JAMAL" };
            var womans = new List<string>() { "SARA", "MARYAM", "NASTARAN", "SOMAYE", "TINA" };

            var random = new Random().Next(1, 5);

            return (genderType) ? mans[random] : womans[random];
        }


        public Sickness GetSickness()
        {
            var random = new Random().Next(1, 5);
            var sickness = new Sickness();

            switch (random)
            {
                case 1:
                    sickness = Sickness.HeartAttack;
                    break;
                case 2:
                    sickness = Sickness.Thalassemia;
                    break;
                case 3:
                    sickness = Sickness.Canser;
                    break;
                case 4:
                    sickness = Sickness.Covid19;
                    break;
                case 5:
                    sickness = Sickness.Cold;
                    break;
            }

            return sickness;
        }


        public SeverityOfDisease GetSeverityOfDisease()
        {
            var random = new Random().Next(1, 3);
            var severityOfDisease = new SeverityOfDisease();

            switch (random)
            {
                case 1:
                    severityOfDisease = SeverityOfDisease.Weak;
                    break;
                case 2:
                    severityOfDisease = SeverityOfDisease.Normal;
                    break;
                case 3:
                    severityOfDisease = SeverityOfDisease.Acute;
                    break;
            }

            return severityOfDisease;
        }
    }


    public enum Sickness
    {
        HeartAttack = 1,
        Thalassemia,
        Canser,
        Covid19,
        Cold
    }


    public enum SeverityOfDisease
    {
        Weak = 1,
        Normal,
        Acute
    }
}
