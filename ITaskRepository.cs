namespace TaskManagerMinimalApi;

public interface ITaskRepository
{
    List<ModelTask> GetAll();
    ModelTask GetById(int id);
    ModelTask Add(ModelTask modelTask);
    bool Update(ModelTask modelTask, int id);
    bool Delete(int id);
}