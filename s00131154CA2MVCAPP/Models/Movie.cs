using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using WebGrease.Css.Extensions;

namespace s00131154CA2MVCAPP.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        [Required]
        [StringLength(168, ErrorMessage = "Must be between {2} and {1} characters long. ", MinimumLength = 2)] //shortest: "Up", longest: "http://goo.gl/1jAup5"
        public string Title { get; set; }
        public virtual List<MovieActor> MovieActors { get; set; }
        //public virtual List<Actor> Actors
        //{
        //    get { return (MovieActors == null) ? null : MovieActors.Select(ma => ma.Actor).ToList(); }
        //    set { }
        //}
        public string Director { get; set; }
        public string Writer { get; set; }
        [DisplayName("Cast")]
        public string Producer { get; set; }                        
        public string Genre { get; set; } 
        [DisplayName("Release Date"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Column(TypeName = "datetime2")] //without this I was getting a 'MinTicks' and 'MaxTicks' error
        public DateTime ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public string AgeCertificate { get; set; }
        public Double Rating { get; set; }
        
    }
}
