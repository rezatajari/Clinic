using Clinic.Model;
using Clinic.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Repositories
{
    public class Canser : ISicknessScore
    {
        public int GetScoreBySickness(SeverityOfDisease severityOfDisease)
        {
            int score = 0;

            switch (severityOfDisease)
            {
                case SeverityOfDisease.Weak:
                    score = 20;
                    break;
                case SeverityOfDisease.Normal:
                    score = 25;
                    break;
                case SeverityOfDisease.Acute:
                    score = 30;
                    break;
            }

            return score;
        }
    }
}
