using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        
        public string Author { get; set; }

        [Required]
        [Column(TypeName = "integer(13)")]
        public int ISBN { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
