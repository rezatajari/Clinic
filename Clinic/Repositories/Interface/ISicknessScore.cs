using Clinic.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Repositories.Interface
{
    interface ISicknessScore
    {
        int GetScoreBySickness(SeverityOfDisease severityOfDisease);
    }
}
