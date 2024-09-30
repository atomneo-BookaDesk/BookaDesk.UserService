namespace BookaDesk.UserService.Application.Validators.CommandValidators;

/// <summary>
/// General interface for commands validators
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ICommandValidator<in T>
{
    void Validate(T command);
}