using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Person
    {
        [Key]
        public string ID { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string FName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LName { get; set; }
        
        public List<Game> FavouriteGames { get; set; }

        private Person()
        {
        }
        
        public Person(string fname, string lname)
        {
            FName = fname;
            LName = lname;
            ID = Guid.NewGuid().ToString();
        }
        public Person(string id, string fname, string lname)
        {
            FName = fname;
            LName = lname;
            ID = id;
        }
        public override string ToString()
        {
            return "ID: " + ID + " FName: " + FName + " LName: " + LName;
        }

    }
}
