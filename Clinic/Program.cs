using Clinic.Model;
using Clinic.Repositories;
using System;

namespace Clinic
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new Repository();

            _ = repo.GeneratingPatient();

            repo.Reception().Wait();
        }
    }
}
