using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMedicineService.Models
{
    public class Category : BaseEntity
    {
        private static int _id;
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Category :{Id}.{Name}";
        }
        public Category()
        {
            Id = ++_id;
        }
    }
}
