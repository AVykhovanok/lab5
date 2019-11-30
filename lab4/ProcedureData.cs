using System.Collections.Generic;
using System.Linq;
using lab4.Models;

namespace lab4
{
    class ProcedureData : DataSupertype
    {
        public List<Procedure> GetAll()
        {
            return this.Context.Procedures.ToList();
        }

        public List<Procedure> FindByProcedureName(string procedureName)
        {
            return this.Context.Procedures.Where(p => p.ProcedureName == procedureName).ToList();
        }

        public void AddRole(Procedure procedureToAdd)
        {
            this.Context.Procedures.Add(procedureToAdd);
            this.SaveChanges();
        }

        public void RemoveRole(Procedure procedureToRemove)
        {
            this.Context.Procedures.Remove(procedureToRemove);
            this.SaveChanges();
        }
    }
}
