using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ProjectX.Server.Database;

public abstract class AbstractRepository<T>(PostgreSqlContext context, ILoggerFactory loggerFactory) where T : AbstractModel
{
    protected readonly DbSet<T> DbModel = context.Set<T>();

    protected readonly ILogger<T> Logger = loggerFactory.CreateLogger<T>();

    protected readonly PostgreSqlContext Context = context;


    async protected Task<T?> CreateModelAsync(T model)
    {
        await Context.AddAsync(model);

        var result = await Context.SaveChangesAsync();
        if (result == 0)
        {
            throw new Exception("Db error. Model is not created");
        }
        
        return model;
    }

    
    async protected Task<int> UpdateModelAsync(T model)
    {
        Context.Update(model);
        return await Context.SaveChangesAsync();
    }


    async protected Task<T> FindOne(int id)
    {
        var model = await DbModel.FindAsync(id);
        return model;
    }
}