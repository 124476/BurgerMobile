using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BurgerMobile.Models
{
    public class Burger
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        [JsonIgnore]
        public string BPhoto { get; set; }
    }
}
