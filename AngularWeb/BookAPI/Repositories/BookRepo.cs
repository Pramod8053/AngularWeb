using BookAPI.Model;
using EntityLibrary.BookEntity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace BookAPI.Repositories
{
    public class BookRepo : DBConnection, IBookRepo
    {
        string SPName = "SP_Book";
        DynamicParameters Para;
        public BookRepo(IConfiguration Config) : base(Config)
        {
            Para = new DynamicParameters();
        }
        public int Delete(int ID)
        {
            var Result = 0;
            try
            {
                var con = BookCon();
                Para.Add("@Action", "d");
                Para.Add("@ID", ID);
                Result = con.Execute(SPName, Para, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                Result=-1;
                throw ex;
            }
           return Result;

        }

        public List<Book> GetBookList()
        {
            List<Book> _boklst = new List<Book>();
            try
            {
                var con = BookCon();
                Para.Add("@Action", "c");
                _boklst = con.Query<Book>(SPName, Para, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return _boklst;

        }

        public Book GetByID(int ID)
        {
            Book _bok = new Book();
            try
            {
                var con = BookCon();
                Para.Add("@Action","a");
                Para.Add("@ID", ID);
                _bok = con.Query<Book>(SPName, Para, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            }catch(Exception ex) {
                throw ex;
            }
            return _bok;
        }

        public int SaveModify(Book _obj)
        {
            int Result = 0;
            try
            {
                var con = BookCon();
                Para.Add("@Action", "b");
                Para.Add("@BookName", _obj.Name);
                Para.Add("@Author", _obj.Author);
                Para.Add("@Price", _obj.Price);
                Para.Add("@ID", _obj.ID);
                Result = con.Execute(SPName, Para, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Result;
            
        }
    }
}
