using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DatabaseConnectionCustom.Data
{
    public class Users : ResponseBase
    {
        [Key]
        public int? idUser { get; set; }
        public string? Usuario { get; set; }
        public string? pass { get; set; }
        public string? email { get; set; }
        public int? Administrator { get; set; }
        public int? Manager { get; set; }
        public int? idnegocio { get; set; }
        public int? validated { get; set; }

       // [JsonIgnore]
       // public ValidacionUser? ValidacionUser { get; set; } 


    }
}
