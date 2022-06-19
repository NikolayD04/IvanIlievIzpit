using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Company
    {
        [Key]
        public string ID { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        public Person CEO { get; set; }

        private Company()
        {
        }

        public Company(string name, string address)
        {
            Name = name;
            Address = address;
            ID = Guid.NewGuid().ToString();
        }
        public Company(string id, string name, string address)
        {
            Name = name;
            Address = address;
            ID = id;
        }

        public override string ToString()
        {
            return "ID: " + ID + " Name: " + Name + " Address: " + Address;
        }
    }
}
