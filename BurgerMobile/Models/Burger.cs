﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BurgerMobile.Models
{
    public partial class Burger
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Sum { get; set; }
        //public string Photo { get; set; }

        //[JsonIgnore]
        //public ImageSource BPhoto { get; set; }
    }
}
