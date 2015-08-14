using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLApplication.Data.Models
{
    public class Specialization
    {
        [Key]
        public int SpecializtionId { get; set; }
        public int SpecializtionName { get; set; }
        public int Description { get; set; }
    }
}
