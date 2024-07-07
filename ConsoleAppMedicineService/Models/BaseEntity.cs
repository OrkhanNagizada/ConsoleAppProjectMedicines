using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMedicineService
{
    public abstract class BaseEntity
    {
        private static int _id;
        public int Id { get;  set; }
        //public BaseEntity()
        //{
        //    Id = ++_id;
        //}
    }
}
