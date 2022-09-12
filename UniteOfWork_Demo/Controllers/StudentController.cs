using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniteOfWork_Demo.DataAccess;
using UniteOfWork_Demo.Models;

namespace UniteOfWork_Demo.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            var model = _unitOfWork.StudentRepository.GetAll();
            return Ok(model);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetBookbyID(int studentId)
        {
            var model = _unitOfWork.StudentRepository.GetById(studentId);
            return Ok(model);
        }
        [HttpPost]
        public ActionResult<IEnumerable<Student>> AddBook(Student student)
        {
            try
            {
                _unitOfWork.StudentRepository.Insert(student);
                _unitOfWork.Save();
                return Ok("The Record was inserted");
            }
            catch (Exception)
            {

                return BadRequest("The Model was Invalid"); ;
            }

        }

        [HttpPatch]
        public ActionResult<IEnumerable<Student>> UpdateBook(Student student)
        {
            try
            {
                _unitOfWork.StudentRepository.Update(student);
                _unitOfWork.Save();
                return Ok("The Record was updated");
            }
            catch (Exception)
            {

                return BadRequest("Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }

        }
        [HttpDelete]
        public ActionResult<IEnumerable<Student>> DeleteBook(int studentId)
        {
            try
            {
                _unitOfWork.StudentRepository.Delete(studentId);
                _unitOfWork.Save();
                return Ok("The Record was deleted");
            }
            catch (Exception)
            {

                return BadRequest("Unable to Delete the record. Try again, and if the problem persists contact your system administrator.");
            }

        }
    }
}
