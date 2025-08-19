using CQRS.Common.Handlers.Query;
using CQRS.Members.DTO;

namespace CQRS.Members.GetMember;

public class GetMemberQueryHandler: IQueryHandler<GetMemberQuery, MemberDTO>
{
    public async Task<MemberDTO> HandleAsync(GetMemberQuery query, CancellationToken ct)
    {
        return new MemberDTO(query.Id, "John Doe");
    }
}