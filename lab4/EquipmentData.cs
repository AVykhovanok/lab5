using System.Collections.Generic;
using System.Linq;
using lab4.Models;

namespace lab4
{
    class EquipmentData : DataSupertype
    {
        public List<Equipment> GetAll()
        {
            return this.Context.Equipments.ToList();
        }

        public List<Equipment> FindByEquipmenName(string equipmnetName)
        {
            return this.Context.Equipments.Where(p => p.EquipmentName == equipmnetName).ToList();
        }

        public void AddRole(Equipment equipmentToAdd)
        {
            this.Context.Equipments.Add(equipmentToAdd);
            this.SaveChanges();
        }

        public void RemoveRole(Equipment equipmentToRemove)
        {
            this.Context.Equipments.Remove(equipmentToRemove);
            this.SaveChanges();
        }
    }
}

