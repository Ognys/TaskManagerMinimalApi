using System.Collections.Immutable;
using TaskManagerMinimalApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITaskRepository, InMemoryTaskRepository>();

var app = builder.Build();

app.MapGet("/tasks", (ITaskRepository repo) => repo.GetAll());

app.MapGet("/tasks/{id:int}", (int id, ITaskRepository repo) =>
{
    if (repo.GetById(id) is null)
        return Results.NotFound();

    return Results.Ok(repo.GetById(id));
}
);

app.MapPost("/tasks", (ModelTask modelTask, ITaskRepository repo) =>
{
    repo.Add(modelTask);
    return Results.Created($"/tasks/{repo.GetAll()[^1].Id}", repo.GetAll()[^1]);
});

app.MapPut("/tasks/{id:int}", (int id, ModelTask modelTask, ITaskRepository repo) =>
{
    if (repo.GetById(id) is null)
        return Results.NotFound();


    repo.Update(modelTask, id);
    return Results.Ok(repo.GetById(id));
});

app.MapDelete("/tasks/{id:int}", (int id, ITaskRepository repo) =>
{
    if (repo.Delete(id))
        return Results.NoContent();
    else
        return Results.NotFound();
});

app.Run();
