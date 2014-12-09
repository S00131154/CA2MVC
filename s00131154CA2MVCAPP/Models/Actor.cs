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
    public class Actor : IEquatable<Actor>
    {
        [Key]
        public int ActorID { get; set; }
        [Required]
        [StringLength(35, ErrorMessage = "Must be between {2} and {1} characters long. ", MinimumLength = 5)]
        public string Name { get; set; }
        [DisplayName("Filmography")]
        public virtual List<MovieActor> ActorMovies { get; set; }
        //[NotMapped]
        //public virtual List<Movie> Movies
        //{
        //    get { return (ActorMovies == null) ? null : ActorMovies.Select(amov => amov.Movie).ToList(); }
        //}
        [DisplayName("Birth Name")]
        public string Fullname { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DoB { get; set; }
        //public int Age
        //{
        //    get
        //    {
        //        return this.Age;   
        //    }
        //    set
        //    {
        //        DateTime now = DateTime.UtcNow; // I decided on UTC as we won't be too concerned with timezones or daylight savings for this assignment 
        //        int age = now.Year - DoB.Year; //^ Got to try to be innovative somewhere
        //        if (now < DoB.AddYears(age)) age--; 
        //        Age = age;
        //    }

        //}
        public string Birthplace { get; set; }
        public double Height { get; set; } 
        public string Nationality { get; set; }        
        public string Spouse { get; set; }
        [DisplayName("Alma Mater")]
        public string University { get; set; }
        public string MiniBio { get; set; }
        [Column(TypeName = "datetime2")]
        [DisplayName("Death Date")]
        public DateTime DeathDate { get; set; }                      

        public bool Equals(Actor a) //tells distinct how to filter out duplicated IDs
        {
            throw new NotImplementedException();
        }
    }
}