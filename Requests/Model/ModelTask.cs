namespace TaskManagerMinimalApi;

public class ModelTask
{
    public string Title { get; set; }
    public string Description { get; set; }
    static private int StaticId = 1;
    public int Id { get; }
    public DateTime CreateDate { get; set; }

    public ModelTask(string title, string description)
    {
        Title = title;
        Description = description;
        Id = StaticId++;
        CreateDate = DateTime.Now;
    }
}