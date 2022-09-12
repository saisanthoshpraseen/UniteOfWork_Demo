using UniteOfWork_Demo.GenericRepository;
using UniteOfWork_Demo.Models;

namespace UniteOfWork_Demo.DataAccess
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<Book> BookRepository { get; }
        IGenericRepository<Student> StudentRepository { get; }
        void Save();
    }
}
