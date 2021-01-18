using Clinic.Model;
using Clinic.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Repositories
{
    public class HeartAttack : ISicknessScore
    {
        public int GetScoreBySickness(SeverityOfDisease severityOfDisease)
        {
            int score = 0;

            switch (severityOfDisease)
            {
                case SeverityOfDisease.Weak:
                    score = 40;
                    break;
                case SeverityOfDisease.Normal:
                    score = 45;
                    break;
                case SeverityOfDisease.Acute:
                    score = 50;
                    break;
            }

            return score;
        }
    }
}
