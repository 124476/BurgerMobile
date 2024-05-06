using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerMobile.Models
{
    public partial class ComboAndBurger
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int BurgerId { get; set; }
        public int ComboId { get; set; }
    }
}
