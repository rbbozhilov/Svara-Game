using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Svara_Game.Data.Entities
{
    public class User
    {

        public User()
        {
           
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int Wins { get; set; }

        public DateTime OnDate { get; set; }




    }
}
