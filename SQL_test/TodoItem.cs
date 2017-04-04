using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SQL_test
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }

        /*public string ISBN
        {
            get { return "978" + ISBN; }
            set { ISBN = value;  }
        }*/

        public override string ToString()
        {
            return  Name + " - " + Author + "  " + ISBN;
        }
    }
}
