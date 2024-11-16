using AppMVC.Domain.Entities;
using AppMVC.Domain.Exceptions;
using AppMVC.Domain.Specifications;

namespace AppMVC.Domain.Builders;

public class ToDoItemBuilder(ISpecification<ToDoItem> specification) : IBuilder<ToDoItem>
{
    private Guid _id = Guid.Empty;
    private Guid _userId;
#nullable disable    
    private string _content;
#nullable enable
    
    public ToDoItem Build()
    {
        var toDoItem = new ToDoItem(_id, _userId, _content);

        var validationResult = specification.IsSatisfiedBy(toDoItem);

        if (!validationResult.IsValid)
            throw new DomainValidationException(
                $"ToDoItem creation failed: {string.Join(", ", validationResult.Errors)}");

        return toDoItem;
    }

    public ToDoItemBuilder WithUserId(Guid userId)
    {
        _userId = userId;
        return this;
    }
    
    public ToDoItemBuilder WithContent(string content)
    {
        _content = content;
        return this;
    }
}