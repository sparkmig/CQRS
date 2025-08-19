using CQRS.Common.Handlers.Command;

namespace CQRS.Members.CreateMember;

public record CreateMemberCommand(string Name) : ICommand;
