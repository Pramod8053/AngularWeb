using BookAPI.Repositories;
using EntityLibrary.BookEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookApiController : ControllerBase
    {
        private readonly IBookRepo repo;
        public BookApiController(IBookRepo _repo)
        {
            repo = _repo;
        }
        [HttpGet]
        public List<Book> BookList()
        {
            List<Book> _bok = new List<Book>();
            try
            {
                _bok = repo.GetBookList();

            }
            catch (Exception ex)
            {
                throw ex;

            }
            return _bok;
        }
        [HttpGet("{ID}")]
        public Book BookByID(int ID)
        {
            Book _bo = new Book();
            try
            {
                _bo = repo.GetByID(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _bo;
        }
        [HttpPost("{ID}")]
        public int BookDelete(int ID)
        {
            int Result = 0;
            try
            {
                Result = repo.Delete(ID);
            }catch(Exception ex)
            {
                throw ex;
            }
            return Result;
        }
        [HttpPost]
        public int SaveModify(Book _obj)
        {
            int Result = 0;
            try
            {
                Result = repo.SaveModify(_obj);

            }catch(Exception ex)
            {
                throw ex;
            }
            return Result;

        }
        
    }
}
