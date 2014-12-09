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
    public class MovieDb : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public MovieDb() : base("MovieConnString") { }
    }
}