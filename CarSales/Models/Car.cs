using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarSales.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Display(Name = "Car Name")]
        public string CarName { get; set; }

        [Display(Name = "Car Model ")]
        public string CarModel { get; set; }


        [Display(Name = "Price ")]
        public string Price { get; set; }


    }
}
