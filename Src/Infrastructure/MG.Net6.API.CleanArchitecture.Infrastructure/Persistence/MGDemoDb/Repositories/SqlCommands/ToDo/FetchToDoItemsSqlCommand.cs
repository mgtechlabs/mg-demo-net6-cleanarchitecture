namespace MG.Net6.API.CleanArchitecture.Infrastructure.Persistence.MGDemoDb.Repositories.SqlCommands.ToDo;

public class FetchToDoItemsSqlCommand
{
    private readonly string sqlCommand =
        @"SELECT 1 AS Id, 'Todo-1' AS Title, 1 AS IsCompleted 
          UNION ALL SELECT 2 AS Id, 'Todo-2' AS Title, 1 AS IsCompleted
          UNION ALL SELECT 3 AS Id, 'Todo-3' AS Title, 1 AS IsCompleted
          UNION ALL SELECT 4 AS Id, 'Todo-4' AS Title, 0 AS IsCompleted
          UNION ALL SELECT 5 AS Id, 'Todo-5' AS Title, 0 AS IsCompleted;";

    public FetchToDoItemsSqlCommand() { }

    public override string ToString() => sqlCommand;
}
