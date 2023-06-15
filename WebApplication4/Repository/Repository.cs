using Microsoft.EntityFrameworkCore;
using WebApplication4.DB;
using System.Linq.Expressions;

namespace WebApplication4.Repository;

public class Repository<TModel> : IRepository<TModel> where TModel : class, IEntity<int>
{
    protected readonly ApplicationDbContext _repository;
    protected readonly DbSet<TModel> _set;

    public Repository(ApplicationDbContext context)
    {
        _repository = context;
        _set = context.Set<TModel>();
    }

    public virtual async Task<TModel> Create(TModel model)
    {
        await _set.AddAsync(model);
        await Save();
        return model;
    }

    public virtual async Task Delete(TModel model)
    {
        _set.Remove(model);
        await Save();
    }

    public virtual async Task<IQueryable<TModel>> FindBy(Expression<Func<TModel, bool>> predicate)
    {
        IQueryable<TModel> result = _set.Where(predicate);
        return result;
    }

    public virtual async Task<IQueryable<TModel>> GetAll()
    {
        return _set;
    }
    public virtual async Task<TModel> GetSingle(int id)
    {
        return await _set.FirstOrDefaultAsync(x => x.Id == id);
    }

    public virtual async Task<TModel> Update(TModel model)
    {
        _repository.Entry(model).State = EntityState.Modified;
        await Save();
        return model;
    }
    public virtual async Task Save()
    {
        await _repository.SaveChangesAsync();
    }
}
