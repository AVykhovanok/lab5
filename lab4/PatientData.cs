using System.Collections.Generic;
using System.Linq;
using lab4.Models;

namespace lab4
{
    class PatientData : DataSupertype
    {
        public List<Patient> GetAll()
        {
            return this.Context.Patients.ToList();
        }

        public List<Patient> FindByFirstName(string firstName)
        {
            return this.Context.Patients.Where(p => p.PatientFirstName == firstName).ToList();
        }

        public List<Patient> FindBySecondName(string secondName)
        {
            return this.Context.Patients.Where(p => p.PatientSecondName == secondName).ToList();
        }

        public List<Patient> FindByAge(int age)
        {
            return this.Context.Patients.Where(p => p.PatientAge == age).ToList();
        }

        public void AddUser(Patient patientToAdd)
        {
            this.Context.Patients.Add(patientToAdd);
            this.SaveChanges();
        }

        public void RemoveUser(Patient patientToRemove)
        {
            this.Context.Patients.Remove(patientToRemove);
            this.SaveChanges();
        }
    }
}

