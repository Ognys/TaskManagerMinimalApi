using System.Collections.Immutable;
using TaskManagerMinimalApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<ModelTask> listTask = new List<ModelTask> {new ModelTask("Сходить в колледж","Пойти завтра в колледж и закрыть долги"), 
new ModelTask("Настроить режим сна", "лечь спать сегодня в 22:00 будильник поставить на 7:30")};

app.MapGet("/tasks",() => listTask);

app.MapGet("/tasks/{id:int}", (int id) =>
{
    for (int i = 0; i < listTask.Count; i++)
    {
        if(id == listTask[i].id)
            return Results.Ok(listTask[i]);
    }
    return Results.NotFound();
}
);

app.MapPost("/tasks", (ModelTask modelTask) =>
{
    listTask.Add(modelTask);
    return Results.Created($"/tasks/{listTask[^1].id}", listTask[^1]);
});

app.MapPut("/tasks/{id:int}", (int id, ModelTask modelTask) =>
{
    for (int i = 0; i < listTask.Count; i++)
    {
        if(id == listTask[i].id)
        {
            listTask[i].Title = modelTask.Title;
            listTask[i].Description = modelTask.Description;
            return Results.Ok(listTask[i].id);
        }
    }
    return Results.NotFound();
});

app.Run();
