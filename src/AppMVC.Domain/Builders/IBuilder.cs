namespace AppMVC.Domain.Builders;

public interface IBuilder<out T> where T : class
{
    public T Build();
}