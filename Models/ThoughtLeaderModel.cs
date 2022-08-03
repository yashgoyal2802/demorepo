using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Octavius_Business_Rules.Models
{
    public class ThoughtLeaderModel
    {
        [Key]
        public int ThoughtLeaderID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Initial { get; set; }
        public string ProjectID { get; set; }
        public string IsCommercial { get; set; }
        public string IsMedical { get; set; }
    }
}
