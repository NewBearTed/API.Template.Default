using API.Template.Default.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace API.Template.Default.Business.Interfaces
{
    public interface IDbRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        Task<int> SaveChanges();
    }
}
