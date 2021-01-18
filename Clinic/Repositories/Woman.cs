using Clinic.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Repositories
{
    public class Woman : IGenderScore
    {
        public int GetScoreByGenderAndAge(int age)
        {
            int score = 0;

            if (age > 5 && age < 10) score = 5;
            else if (age > 10 && age < 20) score = 10;
            else score = 15;

            return score;
        }
    }
}
