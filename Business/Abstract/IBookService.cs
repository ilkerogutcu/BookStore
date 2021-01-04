using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBookService
    {
        List<Book> GetAll();
        Book GetById(int id);
        List<Book> GetByAuthorId(int id);
        void Add(Book book);
        void Delete(Book book);
        void Update(Book book);
    }
}