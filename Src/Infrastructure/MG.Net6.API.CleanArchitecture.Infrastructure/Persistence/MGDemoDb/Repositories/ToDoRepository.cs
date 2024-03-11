using Dapper;
using MG.Net6.API.CleanArchitecture.Infrastructure.Persistence.MGDemoDb.Repositories.SqlCommands.ToDo;
using System.Data;

namespace MG.Net6.API.CleanArchitecture.Infrastructure.Persistence.MGDemoDb.Repositories;

public class ToDoRepository : IToDoRepository
{
    private readonly MGDemoDbContext dbContext;
    private readonly ApplicationConfig applicationConfig;

    public ToDoRepository(MGDemoDbContext dbContext, ApplicationConfig applicationConfig)
    {
        this.dbContext = dbContext;
        this.applicationConfig = applicationConfig;
    }

    public async Task<IEnumerable<ToDoEntity>> FetchAsync()
    {
        IEnumerable<ToDoEntity> entities = Enumerable.Empty<ToDoEntity>();

        using var conn = dbContext.CreateConnection();
        var sqlCommand = new FetchToDoItemsSqlCommand();

        await conn.QueryAsync(sql: sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: applicationConfig.SqlCommandTimeOutInSeconds);

        return entities;
    }

    public async Task<ToDoEntity> SaveAsync(ToDoEntity entityToDo)
    {
        if(entityToDo.Id > 0)
            return await UpdateAsync(entityToDo);
        else
            return await CreateAsync(entityToDo);
    }

    private async Task<ToDoEntity> CreateAsync(ToDoEntity entityToDo)
    {
        using var conn = dbContext.CreateConnection();
        var sqlCommand = new CreateToDoSqlCommand();

        var dynamicParams = new DynamicParameters(new
        {
            p_Title = entityToDo.Title,
            p_IsComplete = entityToDo.IsComplete
        });

        dynamicParams.Add("@out_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

        await conn.ExecuteAsync(sql: sqlCommand.ToString(), 
            commandType: CommandType.Text, 
            commandTimeout: applicationConfig.SqlCommandTimeOutInSeconds, 
            param: dynamicParams);

        entityToDo.Id = dynamicParams.Get<Int32>("out_id");

        return entityToDo;
    }

    private async Task<ToDoEntity> UpdateAsync(ToDoEntity entityToDo)
    {
        using var conn = dbContext.CreateConnection();
        var sqlCommand = new UpdateToDoSqlCommand();

        var dynamicParams = new DynamicParameters(new
        {
            p_Id = entityToDo.Id,
            p_Title = entityToDo.Title,
            p_IsComplete = entityToDo.IsComplete
        });

        await conn.ExecuteAsync(sql: sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: applicationConfig.SqlCommandTimeOutInSeconds,
            param: dynamicParams);

        return entityToDo;
    }

    public async Task DeleteAsync(ToDoEntity entityToDo)
    {
        using var conn = dbContext.CreateConnection();
        var sqlCommand = new DeleteToDoSqlCommand();

        var dynamicParams = new DynamicParameters(new
        {
            p_Id = entityToDo.Id,
        });

        await conn.ExecuteAsync(sql: sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: applicationConfig.SqlCommandTimeOutInSeconds,
            param: dynamicParams);
    }
}
