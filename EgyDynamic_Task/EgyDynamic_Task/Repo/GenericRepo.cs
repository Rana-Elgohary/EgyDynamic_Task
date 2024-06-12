using EgyDynamic_Task.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EgyDynamic_Task.Repo
{
    public class GenericRepo<Type> where Type : class
    {
        EgyDynamic_TaskContext DB;

        public GenericRepo(EgyDynamic_TaskContext db)
        {
            this.DB = db;
        }

        public Type SelectByIDInclude(int id, string IdName, params Expression<Func<Type, object>>[] includes)
        {
            IQueryable<Type> query = DB.Set<Type>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.FirstOrDefault(e => EF.Property<int>(e, IdName) == id);
        }

        public List<Type> SelectAllInclude(int pageNumber, int pageSize, params Expression<Func<Type, object>>[] includes)
        {
            IQueryable<Type> query = DB.Set<Type>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
        }

        public int CountAll()
        {
            return DB.Set<Type>().Count();
        }

        public Type FirstOrDefault(Expression<Func<Type, bool>> predicate)
        {
            return DB.Set<Type>().FirstOrDefault(predicate);
        }

        public void add(Type entity)
        {
            DB.Set<Type>().Add(entity);
        }

        public void update(Type entity)
        {
            DB.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void delete(int id)
        {
            Type obj = DB.Set<Type>().Find(id);
            DB.Set<Type>().Remove(obj);
        }

        public void DeleteEntities(List<Type> entities)
        {
            DB.Set<Type>().RemoveRange(entities);
        }

        public List<Type> FindBy(Expression<Func<Type, bool>> predicate)
        {
            return DB.Set<Type>().Where(predicate).ToList();
        }
    }
}
