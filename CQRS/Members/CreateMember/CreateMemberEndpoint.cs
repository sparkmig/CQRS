using CQRS.Common.Endpoints;
using CQRS.Common.Handlers;
using CQRS.Members.DTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CQRS.Members.CreateMember;

public class CreateMemberEndpoint(ApplicationDispatcher dispatcher): IEndpoint<CreateMemberCommand>
{
    public async Task<Results<Ok, NotFound>> Handle(CreateMemberCommand command, CancellationToken cancellation)
    {
        await dispatcher.Dispatch(command);
        return TypedResults.Ok();
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/Members", Handle);
    }
}