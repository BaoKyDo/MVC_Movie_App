using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP235MVCDemo.Models
{
    public class Movies  // this class holds a list of Movies
    {
        public Movies() { }
        public List<Movie> Items { get; set; }
        public int EditIndex { get; set; }
    }
}