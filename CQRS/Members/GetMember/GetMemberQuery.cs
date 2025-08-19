using CQRS.Common.Handlers.Query;
using CQRS.Members.DTO;

namespace CQRS.Members.GetMember;

public class GetMemberQuery(string id) : IQuery<MemberDTO>
{
    public string Id { get; init; } = id;
}