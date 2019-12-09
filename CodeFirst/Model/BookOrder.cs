using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class BookOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public List<Book> Books { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateBy { get; set; }
    }
}
