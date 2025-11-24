using TaskManagerMinimalApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<ModelTask> listTask = new List<ModelTask> {new ModelTask("Сходить в колледж","Пойти завтра в колледж и закрыть долги"), 
new ModelTask("Настроить режим сна", "лечь спать сегодня в 22:00 будильник поставить на 7:30")};

app.MapGet("/tasks",() => listTask);

app.MapGet("/tasks/{id: int}", (int id) =>
{
    for (int i = 0; i < listTask.Count; i++)
    {
        if(i == listTask[i].id)
            return 
    }
}

);

app.Run();
