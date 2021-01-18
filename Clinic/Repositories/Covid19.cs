using Clinic.Model;
using Clinic.Repositories.Interface;

namespace Clinic.Repositories
{
    public class Covid19 : ISicknessScore
    {
        public int GetScoreBySickness(SeverityOfDisease severityOfDisease)
        {
            int score = 0;

            switch (severityOfDisease)
            {
                case SeverityOfDisease.Weak:
                    score = 30;
                    break;
                case SeverityOfDisease.Normal:
                    score = 35;
                    break;
                case SeverityOfDisease.Acute:
                    score = 45;
                    break;
            }

            return score;
        }
    }
}
