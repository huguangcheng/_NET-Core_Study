using Microsoft.EntityFrameworkCore;
using System;

namespace Model
{
    public class BookContext:DbContext
    {
        public BookContext()
        {
             
        }
        public BookContext(DbContextOptions<BookContext> optinos):base(optinos)
        {

        }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookOrder> BookOrder { get; set; }
        //protected  override void On
    }
}
