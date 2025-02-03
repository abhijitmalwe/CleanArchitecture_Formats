using FluentValidation;

namespace PdsCleanAppCore.Platform.Example.Commands.PostStudent
{
    public class PostStudentCmdValidator : AbstractValidator<PostStudentCmd>
    {
        public PostStudentCmdValidator()
        {
            RuleFor(x => x.StudentDto!.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .When(x => x.StudentDto != null)
                .WithMessage("Email is required.");
        }
    }
}
