using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Midly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name of movie is Required.")]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [Required(ErrorMessage ="Release Date is Required")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [Range(1,20,ErrorMessage ="Range of this movie is between 1,20.")]
        public int NumInStock { get; set; } 
        public byte NumberAvailble { get; set; }
       
    }
}