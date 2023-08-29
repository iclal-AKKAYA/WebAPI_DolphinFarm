using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{

    public class DolphinData
    {
        public int DolphinId {  get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BornDate { get; set; }
        public bool IsItForRent { get; set; }
        public int RentalPrice { get; set; }

        public DolphinData(int dolphinId,string name, int age, DateTime bornDate, bool isItForRent, int rentalPrice)
        {
            this.DolphinId = dolphinId;
            this.Name = name;
            this.Age = age;
            this.BornDate = bornDate;
            this.IsItForRent = isItForRent;
            this.RentalPrice = rentalPrice;
        }

    }
}
