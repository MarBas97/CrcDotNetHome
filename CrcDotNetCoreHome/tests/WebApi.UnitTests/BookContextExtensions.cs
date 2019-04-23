using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.DbContexts;
using WebAPI.Model;

namespace WebApi.UnitTests
{
    public static class BookContextExtensions
    {
        public static void FillDatabase(this BookContext dbContext)
        {
            dbContext.Books.Add
            (
                new Book
                {
                    Id = 1,
                    Title = "Harry Potter",
                    Author = "J.K.Rowlling",
                    ISBN = 1234567899,
                    Date = Convert.ToDateTime("2019/03/25 01:00:00 PM")
                }
            );

            dbContext.Add
            (
                new Book
                {
                    Id = 2,
                    Title = "Władca Pierścieni",
                    Author = "J.R.R.Tolkien",
                    ISBN = 1234390659,
                    Date = Convert.ToDateTime("2019/03/25 02:00:00 PM")
                }
            );

            dbContext.Add
            (
                new Book
                {
                    Id = 3,
                    Title = "Gra o Tron",
                    Author = "R.R.Martin",
                    ISBN = 1234567899,
                    Date = Convert.ToDateTime("2019/03/25 03:00:00 PM")
                }
            );

            dbContext.Add
            (
                new Book
                {
                    Id = 4,
                    Title = "Pan Tadeusz",
                    Author = "A. Mickiewicz",
                    ISBN = 456456789,
                    Date = Convert.ToDateTime("2019/03/25 04:00:00 PM")
                }
            );

            dbContext.Add
            (
                new Book
                {
                    Id = 5,
                    Title = "Dziady",
                    Author = "A. Mickiewicz",
                    ISBN = 777457899,
                    Date = Convert.ToDateTime("2019/03/25 05:00:00 PM")
                }
            );

            dbContext.SaveChanges();
        }
    }
}
