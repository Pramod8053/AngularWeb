using EntityLibrary.BookEntity;
using System.Collections.Generic;

namespace BookAPI.Repositories
{
    public interface IBookRepo
    {
        List<Book> GetBookList();
        int SaveModify(Book _obj);
        int Delete(int ID);
        Book GetByID(int ID);
    }
}
