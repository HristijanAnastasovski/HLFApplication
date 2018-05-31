using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HLFApplication.Models
{
    public class Store
    {   
        
        public int StoreId { get; set; }

        public List<Protein> ProteinsList { get; set; }      
        public List<Multivitamin> MultivitaminsList { get; set; }
        public List<Accessory> AccessoriesList { get; set; }
      //  public List<TrainingProgram> TrainingPrograms { get; set; }

        public Store()
        {
            ProteinsList = new List<Protein>();

            MultivitaminsList = new List<Multivitamin>();
            AccessoriesList = new List<Accessory>();
           // TrainingPrograms = new List<TrainingProgram>();
        }
    }
}