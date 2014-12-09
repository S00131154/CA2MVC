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

    internal class MovieActorSeed:DropCreateDatabaseAlways<MovieDb>
    {
        protected Movie CreateMovie(string title, string director, string writer,string ageCert, int runtime,double rating, DateTime releaseDate,string genre)
        {
            Movie m = new Movie();
            m.Title = title;
            m.Director = director;
            m.Writer = writer;
            m.AgeCertificate = ageCert;
            m.Runtime = runtime;
            m.Rating = rating;
            m.ReleaseDate = releaseDate;
            m.Genre = genre;

            m.MovieActors = new List<MovieActor>();
            return m;
        }

        protected MovieActor CreateActor(string name, string fullname, string birthplace, double height, string nationality, string spouse, string University,  DateTime Dob, DateTime deathdate)
        {
            MovieActor ma = new MovieActor();
            
            ma.Actor = new Actor();
            ma.Actor.Name = name;
            ma.Actor.Fullname = fullname;
            ma.Actor.Birthplace = birthplace;
            ma.Actor.DoB = Dob;
            ma.Actor.Height = height;
            ma.Actor.Nationality = nationality;
            ma.Actor.Spouse = spouse;
            ma.Actor.University = University;
            ma.Actor.DeathDate = deathdate;

            return ma;
        }

        protected MovieActor CreateActor(string name, string fullname, string birthplace, double height, string nationality, string spouse, string University, DateTime Dob)
        {
            MovieActor ma = new MovieActor();

            ma.Actor = new Actor();
            ma.Actor.Name = name;
            ma.Actor.Fullname = fullname;
            ma.Actor.Birthplace = birthplace;
            ma.Actor.DoB = Dob;
            ma.Actor.Height = height;
            ma.Actor.Nationality = nationality;
            ma.Actor.Spouse = spouse;
            ma.Actor.University = University;
            
            return ma;
        }

        protected MovieActor CreateActor(string name, string fullname, string birthplace, double height, string nationality, string University, DateTime Dob)
        {
            MovieActor ma = new MovieActor();

            ma.Actor = new Actor();
            ma.Actor.Name = name;
            ma.Actor.Fullname = fullname;
            ma.Actor.Birthplace = birthplace;
            ma.Actor.DoB = Dob;
            ma.Actor.Height = height;
            ma.Actor.Nationality = nationality;
            ma.Actor.University = University;            

            return ma;
        }

        protected override void Seed(MovieDb context)
        {
            List<Movie> movies = new List<Movie>();            
            //movies.Add(CreateMovie("The Shawshank Redemption","Frank Darabont", "Stephen King","15",142, 9.3, new DateTime(1994,09,23),"Thriller"));
            var Shawshank = CreateMovie("The Shawshank Redemption", "Frank Darabont", "Stephen King", "15", 142, 9.3, new DateTime(1994, 09, 23), "Thriller");
            var PulpFiction = CreateMovie("Pulp Ficiton", "Quentin Tarantino", "Roger Avary", "18", 154, 9.0, new DateTime(1994, 09, 10), "Crime, Thriller");
            var CoachCarter = CreateMovie("Coach Carter","Thomas Carter","Mark Schwan","12",136,7.2,new DateTime(2005,01,13),"Drama, Sport");
            var InglouriousBastards = CreateMovie("Inglourious Bastards","Quentin Tarantino","Eli Roth","18",153,8.3,new DateTime(2009,08,21),"War Drama");
            var IronMan = CreateMovie("Iron Man", "Jon Favreau", "Mark Fergus, Hawk Ostby", "PG13", 126, 7.9, new DateTime(2008, 04, 14), "Sci-Fi");
            var TheDarkNight = CreateMovie("The Dark Knight","Christoper Nolan","Johnathan Nolan","PG13",152,9,new DateTime(2008,07,14),"Action");
            var Godfather = CreateMovie("The Godfather", "Francis Ford Coppola", "Mario Puzo", "18", 175, 9.2, new DateTime(1972, 03, 15),"Crime, Drama");

            var TimRobbins = CreateActor("Tim Robbins", "Timothy Francis Robbins", "West Covina, California, USA", 1.96, "American", "University of California", new DateTime(1958, 10, 16));
            var BobGunton = CreateActor("Bob Gunton", "Robert Patrick Gunron Jr.", "Santa Monica, California, USA", 1.87, "American", "N/A", new DateTime(1945, 11, 15));
            var JamesWhitmore = CreateActor("James Whitmore,", "James David Whitmore", "Malibu, California, USA", 1.73, "American", "N/A", new DateTime(1921, 10, 01));
            var MorganFreeman = CreateActor("Morgan Freeman", "Morgan Freeman", "Memphis, Tennessee, USA", 1.88, "American", "Los Angeles City College", DateTime.Parse("01/06/1937"));
            var BruceWillis = CreateActor("Bruce Willis", "Walter Bruce Willis", "Idar-Oberstein, West Germany", 1.83, "American", "Montclair State University, New Jersey", new DateTime(1955, 03, 19));
            var JohnTravolta = CreateActor("John Travolta", "John Joseph Travolta", "Englewood, New Jersey, USA", 1.88, "American", "N/A", new DateTime(1954, 02, 18));
            var SamuelLJackson = CreateActor("Samuel L. Jackson", "Samuel Leroy Jackson", "Washington, District of Columbia, USA", 1.89, "American", "Morehouse College", new DateTime(1948, 12, 21));
            var BradPitt = CreateActor("Brad Pitt", "William Bradley Pitt", "Shawnee, Oklahoma, USA", 1.8, "American", "University of Missouri", new DateTime(1963, 12, 18));
            var RobertDowneyJr = CreateActor("Robert Downey Jr.","Robert John Downey Jr.","New York, USA",1.74,"American","N/A",new DateTime(1965,04,04));

            Shawshank.MovieActors.Add(MorganFreeman);
            Shawshank.MovieActors.Add(BobGunton);
            Shawshank.MovieActors.Add(JamesWhitmore);
            Shawshank.MovieActors.Add(TimRobbins);
            PulpFiction.MovieActors.Add(SamuelLJackson);
            PulpFiction.MovieActors.Add(BruceWillis);
            PulpFiction.MovieActors.Add(JohnTravolta);
            CoachCarter.MovieActors.Add(SamuelLJackson);
            InglouriousBastards.MovieActors.Add(BradPitt);
            IronMan.MovieActors.Add(RobertDowneyJr);
                       
            movies.Add(PulpFiction);
            movies.Add(Shawshank);
            movies.Add(InglouriousBastards);
            movies.Add(IronMan);
            movies.Add(TheDarkNight);
            movies.Add(Godfather);
            //movies.Add(CoachCarter);

            movies.ForEach(moovee => context.Movies.Add(moovee));
            context.SaveChanges();
            base.Seed(context);
            
        }
    }
    
    
        

    

    

   

}