using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccessLayer.Repository.GenericRepo
{
    public interface IGenericRepo<TEnitity> where TEnitity : class
    {
        List<TEnitity> GetAll();
        TEnitity GetById(int id);
        void Update(TEnitity Entity);
        void Add(TEnitity Entity);
        void Delete(int id);
        void Insert(TEnitity Entity);
        bool SaveChanges();
    }
}
