using Clinic.Model;
using Clinic.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Repositories
{
    public class Cold : ISicknessScore
    {
        public int GetScoreBySickness(SeverityOfDisease severityOfDisease)
        {
            int score = 0;

            switch (severityOfDisease)
            {
                case SeverityOfDisease.Weak:
                    score = 5;
                    break;
                case SeverityOfDisease.Normal:
                    score = 15;
                    break;
                case SeverityOfDisease.Acute:
                    score = 20;
                    break;
            }

            return score;
        }
    }
}
