using activity_scheduling.application.Enums;
using activity_scheduling.domain.Repositories.Contracts;
using MediatR;

namespace activity_scheduling.application.Commands.CancelActivity
{
    public class CancelActivityHandler(IActivityRepository activityRepository) : IRequestHandler<CancelActivityCommand, GenericCommandResult>
    {
        private readonly IActivityRepository _ActivityRepository = activityRepository;

        public async Task<GenericCommandResult> Handle(CancelActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = await _ActivityRepository.GetActivityByIdAsync(request.Id);
            if(activity == null)
                return new GenericCommandResult(false, "Atividade não encontrada", null, EStatusCodes.NOTFOUND);
            activity.CancelActivity();
            await _ActivityRepository.UpdateActivityAsync(activity);
            return new GenericCommandResult(true, "Atividade cancelada com sucesso", activity, EStatusCodes.OK);
        }
    }
}