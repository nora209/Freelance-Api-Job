using App.DataAccessLayer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.Repository.GenericRepo
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        private readonly HospitalContext _context;
        public GenericRepo(HospitalContext context)
        {
            this._context = context;
        }
        public void Add(TEntity Entity)
        {
            _context.Set<TEntity>().Add(Entity);
        }

        public void Delete(int id)
        {
            var idEntity = GetById(id);
            if (idEntity is not null)
            {
                _context.Set<TEntity>().Remove(idEntity);
            }
        }
        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity Entity)
        {
            _context.Set<TEntity>().Add(Entity);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update(TEntity Entity)
        {
            
        }
    }
}
