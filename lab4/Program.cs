using lab4.Models;
using System;
using System.Linq;

namespace lab4
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (Model1 model = new Model1())
            {
                //     TASK 1

                                // Table Equipments
                                /*Equipment equipment = new Equipment();
                               
                                equipment.EquipmentName = "Blood pressure";
                                model.Equipments.Add(equipment);
                                model.SaveChanges();
                               
                                equipment.EquipmentName = "Cardiorespiratory";
                                model.Equipments.Add(equipment);
                                model.SaveChanges();

                                equipment.EquipmentName = "Otoscopes";
                                model.Equipments.Add(equipment);
                                model.SaveChanges();
                                

                                // Table Patients
                                Patient patient = new Patient();
                                patient.PatientFirstName = "Vitalyi";
                                patient.PatientSecondName = "Mazur";
                                patient.PatientAge = 99;
                                model.Patients.Add(patient);
                                model.SaveChanges();


                                patient.PatientFirstName = "Andryi";
                                patient.PatientSecondName = "Shevchenko";
                                patient.PatientAge = 54;
                                model.Patients.Add(patient);
                                model.SaveChanges();

                                patient.PatientFirstName = "Petro";
                                patient.PatientSecondName = "Bubela";
                                patient.PatientAge = 75;
                                model.Patients.Add(patient);
                                model.SaveChanges();

                                // Table Procedures
                                Procedure procedure = new Procedure();
                                procedure.ProcedureName = "Cataract surgery";
                                model.Procedures.Add(procedure);
                                model.SaveChanges();

                                procedure.ProcedureName = "Mastectomy";
                                model.Procedures.Add(procedure);
                                model.SaveChanges();

                                procedure.ProcedureName = "Tonsillectomy";
                                model.Procedures.Add(procedure);
                                model.SaveChanges();

                                 */




               

                                //     TASK 2 - Validation
                              
                                var userr = new Equipment() { EquipmentName = string.Empty };
                                model.Equipments.Add(userr);

                                var validationErrors = model.GetValidationErrors()
                                    .Where(vr => !vr.IsValid)
                                    .SelectMany(vr => vr.ValidationErrors);

                                foreach (var error in validationErrors)
                                {
                                    Console.WriteLine(error.ErrorMessage);
                                }

                                Console.ReadKey();
             

                               //     TASK 3 - Audit

                               var patient = model.Patients.Find(1);
                               using (var contextDB = new Model1())
                               {
                                   contextDB.Database.ExecuteSqlCommand(
                                       "UPDATE Patients SET PatientFirstName = 'Vitalik' WHERE PatientId = 1");
                               }
                               patient.PatientFirstName = patient.PatientFirstName + "_Memory";

                               string value = model.Entry(patient).Property(m => m.PatientFirstName).OriginalValue;
                               Console.WriteLine(string.Format("Original Value : {0}", value));

                               value = model.Entry(patient).Property(m => m.PatientFirstName).CurrentValue;
                               Console.WriteLine(string.Format("Current Value : {0}", value));

                               value = model.Entry(patient).GetDatabaseValues().GetValue<string>("PatientFirstName");
                               Console.WriteLine(string.Format("DB Value : {0}", value));
                               Console.ReadKey();

            }
        }
    }
}
