using CQRS.Common.Endpoints;
using CQRS.Common.Handlers;
using CQRS.Members.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Members.GetMember;

public class GetMemberEndpoint(ApplicationDispatcher dispatcher) : IEndpoint<string, MemberDTO>
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Members/{id}", Handle);
    }

    public async Task<Results<Ok<MemberDTO>, NotFound>> Handle(string id, CancellationToken cancellationToken)
    {
        var query = new GetMemberQuery(id);
        var member = await dispatcher.Dispatch<GetMemberQuery, MemberDTO>(query);
        return TypedResults.Ok(member);
    }
}