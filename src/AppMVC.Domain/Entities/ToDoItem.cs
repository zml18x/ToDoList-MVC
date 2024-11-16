namespace AppMVC.Domain.Entities;

public class ToDoItem
{
    public Guid Id { get; protected set; }
    public Guid UserId { get; protected set; }
    public string Content { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public bool IsCompleted { get; protected set; }


    
    protected ToDoItem(){}
    public ToDoItem(Guid id, Guid userId, string content)
    {
        Id = id;
        UserId = userId;
        Content = content;
        CreatedAt = DateTime.UtcNow;
        IsCompleted = false;
    }



    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }

    public void MarkAsIncomplete()
    {
        IsCompleted = false;
    }

    public void Update(string contet)
    {
        Content = contet;
    }
}