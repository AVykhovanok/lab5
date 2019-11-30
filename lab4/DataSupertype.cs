using System;
using System.IO;
using System.Text;

namespace lab4
{
    public class DataSupertype
    {
        private Models.Model1 context = null;
        public Models.Model1 Context
        {
            get
            {
                return this.context = context ?? new Models.Model1();
            }

            set
            {
                this.context = value;
            }
        }

        public void SaveChanges()
        {
            try
            {
                this.Context.SaveChanges();
                this.Context = null;
            }
            catch (Exception ex)
            {
                FileInfo fi = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "Log.txt");
                StreamWriter sr = new StreamWriter(fi.OpenWrite());
                foreach (var validationError in this.Context.GetValidationErrors())
                {
                    StringBuilder errorString = new StringBuilder();
                    errorString.AppendLine("====//=//====");
                    foreach (var error in validationError.ValidationErrors)
                    {
                        errorString.AppendLine(string.Format("{0} - {1}", error.PropertyName, error.ErrorMessage));
                    }

                    sr.WriteLine(errorString.ToString());
                }

                sr.Close();
                this.Context = null;
            }
        }
    }

}
