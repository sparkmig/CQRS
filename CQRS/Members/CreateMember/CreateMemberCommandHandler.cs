using CQRS.Common.Handlers.Command;

namespace CQRS.Members.CreateMember;

public class CreateMemberCommandHandler: ICommandHandler<CreateMemberCommand>
{
    public Task HandleAsync(CreateMemberCommand command, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}