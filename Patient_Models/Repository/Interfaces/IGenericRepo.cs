using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Models.Repository.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<IEnumerable<T>> GetAllPatients();
        //Task<IQueryable<T>> GetAllPatients();
        Task<T> GetPatientById(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllPatientById(Expression<Func<T, bool>> predicate);
        Task InsertPatient(T data);
        Task UpdatePatient(T data);
        Task DeletePatient(T data);
        Task DeletePatient(IEnumerable<T> data);
    }
}
