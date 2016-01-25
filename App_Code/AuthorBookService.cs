using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthorBookService" in code, svc and config file together.
public class AuthorBookService : IAuthorBookService
{
    BookReviewDbEntities1 br = new BookReviewDbEntities1();//it gives me access to all the values
    public List<string> GetAuthors()
    {
        var auths = from a in br.Authors
                    orderby a.AuthorName
                    select new { a.AuthorName };//we are returning only the author

        List<string> authors = new List<string>();
        foreach (var au in auths)
        {
            authors.Add(au.AuthorName.ToString());//it will populate as a loop
        }

        return authors;//it will return all the authors
    }

    public List<BookLite> GetBooks(string author)
    {
        var bks = from b in br.Books
                  from a in b.Authors
                  where a.AuthorName.Equals(author)
                  select new {b.BookTitle, b.BookISBN, b.BookEntryDate };

        List<BookLite> books = new List<BookLite>();

        foreach (var b in bks)
        {
            BookLite blite = new BookLite();
            blite.Title = b.BookTitle;
            blite.ISBN = b.BookISBN;
            blite.EntryDate = b.BookEntryDate.ToShortDateString();

            books.Add(blite);

        }

        return books;

    }
}
