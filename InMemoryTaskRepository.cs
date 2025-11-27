namespace TaskManagerMinimalApi;

public class InMemoryTaskRepository : ITaskRepository
{
    List<ModelTask> listTask = new List<ModelTask> {};

    public List<ModelTask> GetAll()
    {
        return listTask;
    }

    public ModelTask GetById(int id)
    {
        for (int i = 0; i < listTask.Count; i++)
        {
            if(id == listTask[i].Id)
                return listTask[i];
        }

        return null;
    }

    public ModelTask Add(ModelTask modelTask)
    {
        listTask.Add(modelTask);
        return listTask[^1];
    }

    public bool Update(ModelTask modelTask, int id)
    {
        for (int i = 0; i < listTask.Count; i++)
        {
            if(id == listTask[i].Id)
            {
                listTask[i].Title = modelTask.Title;
                listTask[i].Description = modelTask.Description;
                return true;
            }
        }
        return false;
    }

    public bool Delete(int id)
    {
        for (int i = 0; i < listTask.Count; i++)
        {
            if(id == listTask[i].Id)
            {
                listTask.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
}