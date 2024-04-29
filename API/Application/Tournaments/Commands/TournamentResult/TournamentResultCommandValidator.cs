using Common.Extensions;
using FluentValidation;
using System.Linq;

namespace Application.Tournaments.Commands.TournamentResult
{
    public class TournamentResultCommandValidator : AbstractValidator<TournamentResultCommand>
    {
        public TournamentResultCommandValidator()
        {
            RuleFor(e => e.GameIds)
                .NotEmpty().WithMessage("Lista de jogos não pode ser vazia!");

            RuleFor(e => e.GameIds)
                .Must(e => e.Count().IsPowerOfTwo() && e.Count() != 1).WithMessage("Lista de jogos não tem uma quantidade suficiente, quantidade necessita ser exponencial de 2, não é possivel criar um torneio balanceado!");
        }
    }
}
