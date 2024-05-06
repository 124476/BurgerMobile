using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerMobile.Models
{
    public partial class BCombo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Sum { get; set; }
        public string Title { get; set; }
    }
}
