using Microsoft.AspNetCore.Http.HttpResults;

namespace CQRS.Common.Endpoints;

public interface IEndpoint<in TRequest, TResponse>: IEndpoint
{
    Task<Results<Ok<TResponse>, NotFound>> Handle(TRequest request, CancellationToken cancellation);
}


public interface IEndpoint<in TRequest>: IEndpoint
{
    Task<Results<Ok, NotFound>> Handle(TRequest request, CancellationToken cancellation);
}


public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}