using CQRS.Common.Handlers.Command;
using CQRS.Common.Handlers.Query;

namespace CQRS.Common.Handlers;

public class ApplicationDispatcher(IServiceProvider provider)
{
    public Task<TResult> Dispatch<TQuery, TResult>(TQuery query, CancellationToken? cancellationToken = null) where TQuery : IQuery<TResult>
    {
        cancellationToken ??= CancellationToken.None;
        var service = provider.GetService(typeof(IQueryHandler<TQuery, TResult>));
        if (service == null)
        {
            throw new ArgumentException("Service not found");
        }
        
        var task = (Task<TResult>?)service.GetType()?
            .GetMethod("HandleAsync")?
            .Invoke(service, new object[] { query, cancellationToken });
        
        return task ?? throw new NullReferenceException();
    }
    
    public Task Dispatch<TCommand>(TCommand command, CancellationToken? cancellationToken = null) where TCommand : ICommand
    {
        cancellationToken ??= CancellationToken.None;
        var service = provider.GetService(typeof(ICommandHandler<TCommand>));
        if (service == null)
        {
            throw new NotImplementedException();
        }
        
        var task = (Task?)service.GetType()?
            .GetMethod("HandleAsync")?
            .Invoke(service, new object[] { command, cancellationToken });
        
        return task ?? throw new NullReferenceException();
    }
}