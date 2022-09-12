using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UniteOfWork_Demo.DataAccess;
using UniteOfWork_Demo.Models;

namespace UniteOfWork_Demo.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var model = _unitOfWork.BookRepository.GetAll();
            return Ok(model);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBookbyID(int bookId)
        {
            var model = _unitOfWork.BookRepository.GetById(bookId);
            return Ok(model);
        }
        [HttpPost]
        public ActionResult<IEnumerable<Book>> AddBook(Book bookObj)
        {
            try
            {
                _unitOfWork.BookRepository.Insert(bookObj);
                _unitOfWork.Save();
                return Ok("The Record was inserted");
            }
            catch (Exception)
            {

                return BadRequest("The Model was Invalid"); ;
            }

        }

        [HttpPatch]
        public ActionResult<IEnumerable<Book>> UpdateBook(Book bookObj)
        {
            try
            {
                _unitOfWork.BookRepository.Update(bookObj);
                _unitOfWork.Save();
                return Ok("The Record was updated");
            }
            catch (Exception)
            {

                return BadRequest("Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }

        }
        [HttpDelete]
        public ActionResult<IEnumerable<Book>> DeleteBook(int bookId)
        {
            try
            {
                _unitOfWork.BookRepository.Delete(bookId);
                _unitOfWork.Save();
                return Ok("The Record was deleted");
            }
            catch (Exception)
            {

                return BadRequest("Unable to Delete the record. Try again, and if the problem persists contact your system administrator.");
            }

        }

        //protected virtual void Dispose(bool disposing) 
        //{
        //    _unitOfWork.Dispose();
        //}

    }
}
