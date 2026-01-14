using activity_scheduling.application.Commands.Shared;
using activity_scheduling.application.Commands.Validators;
using activity_scheduling.application.Enums;
using activity_scheduling.domain.Entities;
using activity_scheduling.domain.Enums;
using activity_scheduling.domain.Repositories.Contracts;
using MediatR;

namespace activity_scheduling.application.Commands.CreateActivity
{
    public class CreateActivityHandler(IActivityRepository activityRepository) : IRequestHandler<CreateActivityCommand, GenericCommandResult>
    {
        private readonly IActivityRepository _ActivityRepository = activityRepository;
        private readonly CreateActivityCommandValidator _Validator = new();

        public async Task<GenericCommandResult> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _Validator.Validate(request);

            if (validationResult.IsValid == false)
                return new GenericCommandResult(false, validationResult.Errors.Select(e => e.ErrorMessage).ToList().First(), null, EStatusCodes.BADREQUEST);

            var activity = new Activity(request.Name!, request.StartTime, request.EndTime, request.Description);

            var getAllActivities = await _ActivityRepository.GetAllActivitiesAsync();

            var filterActivityByState = getAllActivities.Where(a => a.State == EActivityState.SCHEDULED ||a.State == EActivityState.PENDING);

            var conflictingActivity = await SharedFunctions.CheckTimeConflict(filterActivityByState, activity);

            if(conflictingActivity.Any())
                return new GenericCommandResult(false, $"Esta atividade conlita com outra(s) {conflictingActivity.Count()} atividade(s)",null, EStatusCodes.BADREQUEST);
                
            var creationResult = await _ActivityRepository.CreateActivityAsync(activity);

            return new GenericCommandResult(true, "Atividade criada com sucesso", creationResult, EStatusCodes.CREATED);
        }
    }
}