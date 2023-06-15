using System.Linq.Expressions;

namespace WebApplication4.Repository;

public interface IRepository<TModel>  where TModel:IEntity<int>
{
    Task<TModel> Create(TModel model);
    Task<TModel> Update(TModel model);
    Task Delete(TModel model);
    Task<TModel> GetSingle(int id);
    Task<IQueryable<TModel>> GetAll();
    Task<IQueryable<TModel>> FindBy(Expression<Func<TModel, bool>> predicate);
}
