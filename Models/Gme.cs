using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamingPortal.Models
{
    public class Gme
    {

        public int id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = " Image Link")]
        public string picLink { get; set; }

        [Display(Name = " Download Link")]
        public string dLink { get; set; }



    }
}
