using Patient_Models.DbContexts;
using Patient_Models.Repository.Interfaces;
using Patient_Models.Repository.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Models.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PatientDbContext _db;
        public UnitOfWork(PatientDbContext db)
        {
            this._db = db;
        }
        public async Task CompleteAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._db.Dispose();
        }

        public IGenericRepo<T> GetRepo<T>() where T : class
        {
            return new GenericRepo<T>(this._db);
        }
    }
}
