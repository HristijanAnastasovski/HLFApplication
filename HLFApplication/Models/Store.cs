using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HLFApplication.Models
{
    public class Store
    {
         
        public List<Protein> Proteins { get; set; }
        
        public List<Multivitamin> Multivitamins { get; set; }
        public List<Accessory> Accessories { get; set; }
      //  public List<TrainingProgram> TrainingPrograms { get; set; }

        public Store()
        {
            Proteins = new List<Protein>();
            
            Multivitamins = new List<Multivitamin>();
            Accessories = new List<Accessory>();
           // TrainingPrograms = new List<TrainingProgram>();
        }
    }
}