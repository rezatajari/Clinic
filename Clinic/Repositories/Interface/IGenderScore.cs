using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Repositories.Interface
{
    public interface IGenderScore
    {
        int GetScoreByGenderAndAge(int age);
    }
}
