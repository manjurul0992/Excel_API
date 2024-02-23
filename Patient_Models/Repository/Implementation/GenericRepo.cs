using Microsoft.EntityFrameworkCore;
using Patient_Models.DbContexts;
using Patient_Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Models.Repository.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly PatientDbContext _db;
        private readonly DbSet<T> _dbset;
        public GenericRepo(PatientDbContext db)
        {
            this._db = db;
            _dbset = this._db.Set<T>();
        }
        public async Task DeletePatient(T data)
        {
            var result = this._db.Remove(data);
            await Task.FromResult(result);
        }

        public async Task DeletePatient(IEnumerable<T> data)
        {
            _db.RemoveRange(data);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAllPatientById(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.AsQueryable().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllPatients()
        {
            return await _dbset.ToListAsync();
        }

        //public IQueryable<T> GetAllData()
        //{
        //    return dbset.AsQueryable();
        //}


        //public async Task<T> GetDataById(Expression<Func<T, bool>> predicate)
        //{
        //    return await dbset.AsQueryable().FirstAsync(predicate);
        //}
        public async Task<T> GetPatientById(Expression<Func<T, bool>> predicate)
        {
            return await _dbset.AsQueryable().FirstOrDefaultAsync(predicate);
        }

        public async Task InsertPatient(T data)
        {
            await _dbset.AddAsync(data);
        }

        //public Task UpdatePatient(T data)
        //{
        //    this._db.Entry(data).State = EntityState.Modified;
        //    return Task.CompletedTask;
        //}
        public async Task UpdatePatient(T data)
        {
            _db.Entry(data).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
