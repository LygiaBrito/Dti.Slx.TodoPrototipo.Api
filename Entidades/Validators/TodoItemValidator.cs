using FluentValidation;
using Spx.Adm.Todo.Items;

namespace TodoApi.Validators
{
    public class TodoItemValidator : AbstractValidator<TodoItem>
    {
        public TodoItemValidator()
        {
            RuleFor(m => m.Id)
                .NotEmpty()
                    .WithMessage("O campo Id, nao pode ser vazio.");

            RuleFor(m => m.Name)
                .NotEmpty()
                    .WithMessage("O campo Name, nao pode ser vazio.")
                .MinimumLength(5)
                    .WithMessage("O campo Name deve conter o minimo de 5 caracteres");

            RuleFor(m => m.Description)
                .NotEmpty()
                    .WithMessage("O campo Description, nao pode ser vazio.")
                .MinimumLength(5)
                    .WithMessage("O campo Description deve conter o minimo de 5 caracteres");                    
        }
    }
}

