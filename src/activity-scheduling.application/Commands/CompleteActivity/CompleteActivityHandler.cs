using activity_scheduling.application.Enums;
using activity_scheduling.domain.Enums;
using activity_scheduling.domain.Repositories.Contracts;
using MediatR;

namespace activity_scheduling.application.Commands.CompleteActivity
{
    public class CompleteActivityHandler(IActivityRepository activityRepository) : IRequestHandler<CompleteActivityCommand, GenericCommandResult>
    {
        private readonly IActivityRepository _ActivityRepository = activityRepository;

        public async Task<GenericCommandResult> Handle(CompleteActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = await _ActivityRepository.GetActivityByIdAsync(request.Id);
            if(activity == null)
                return new GenericCommandResult(false, "Atividade não encontrada", null, EStatusCodes.NOTFOUND);
            else if(activity.State == EActivityState.COMPLETED)
                return new GenericCommandResult(false, "Esta atividade já foi concluida", null, EStatusCodes.BADREQUEST);
            activity.CompleteActivity();
            await _ActivityRepository.UpdateActivityAsync(activity);
            return new GenericCommandResult(true, "Atividade concluida com sucesso", activity, EStatusCodes.OK);
        }
    }
}