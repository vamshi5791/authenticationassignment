using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetCoreDemo.Models.DB
{
    public partial class Book
    {
        public int? BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Edition { get; set; }
        public int? NoOfBooks { get; set; }
        public string Shelf { get; set; }
    }
}
