using AppMVC.Domain.Entities;

namespace AppMVC.Domain.Specifications;

public class ToDoItemSpec : ISpecification<ToDoItem>
{
    private readonly ValidationResult _result = new(true);
    
    
    
    public ValidationResult IsSatisfiedBy(ToDoItem entity)
    {
        ValidateUserId(entity.UserId);
        ValidateContent(entity.Content);
        ValidateCreatedAt(entity.CreatedAt);

        return _result;
    }
    
    
    
    private void ValidateUserId(Guid userId)
    {
        if (userId == Guid.Empty)
            _result.AddError("User ID is required.");
    }

    private void ValidateContent(string content)
    {
        if(string.IsNullOrWhiteSpace(content))
            _result.AddError("Content is required.");
    }

    private void ValidateCreatedAt(DateTime createdAt)
    {
        if (createdAt > DateTime.UtcNow)
            _result.AddError("Created date cannot be in the future.");
    }
}