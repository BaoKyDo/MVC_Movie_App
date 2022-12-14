using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP235MVCDemo.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public bool IsEditable { get; set; }
        public Movie(int id, string title, string director)
        {
            Id = id;
            Title = title;
            Director = director;
        }

        public Movie(int id, string title, string director, string description)
        {
            Id = id;
            Title = title;
            Director = director;
            Description = description;
        }

        public Movie(int id)
        {
            Id = id;
        }

        //since addMovie action is trying to create the addMovie view with an empty Movie object is looking for parameterless constructor to do it
        public Movie() { }
    }
}