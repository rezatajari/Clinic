using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public bool Gender { get; set; }
        public Sickness Sickness { get; set; }


        public bool GetGender()
        {
            const bool MAN = true;
            const bool WOMAN = false;

            bool getGender;
            var random = new Random().Next(1, 2);

            if (random == 1)
                getGender = MAN;
            else
                getGender = WOMAN;

            return getGender;
        }
        public string GetFullName(bool genderType)
        {
            const string HASAN = "HASAN";
            const string ALI = "ALI";
            const string MOHAMMAD = "MOHAMMAD";
            const string REZA = "REZA";
            const string JAMAL = "JAMAL";
            var mans = new List<string>() { HASAN, ALI, MOHAMMAD, REZA, JAMAL };

            const string SARA = "SARA";
            const string MARYAM = "MARYAM";
            const string NASTARAN = "NASTARAN";
            const string SOMAYE = "SOMAYE";
            const string TINA = "TINA";
            var womans = new List<string>() { SARA, MARYAM, NASTARAN, SOMAYE, TINA };

            var random = new Random().Next(1, 5);
            string fullName;
            if (genderType)
                fullName = mans[random];
            else
                fullName = womans[random];

            return fullName;
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

    }

    public enum Sickness
    {
        HeartAttack = 1,
        Thalassemia,
        Canser,
        Covid19,
        Cold
    }
}
