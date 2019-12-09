using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BookType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Book { get; set; }
    }
}
