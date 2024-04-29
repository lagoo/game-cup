using Application.Tournaments.Commands.TournamentResult;
using FluentAssertions;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Application.UnitTests.Tournaments.Commands.TournamentResult
{
    public class TournamentResultCommandValidatorTests
    {
        private readonly TournamentResultCommandValidator _stu;

        public TournamentResultCommandValidatorTests()
        {
            _stu = new TournamentResultCommandValidator();
        }

        [Fact()]
        public void Validate_InvalidQueryEmptyList_ShouldReturnFalseWithValidationErros()
        {
            // Arrange
            TournamentResultCommand query = new(new List<string>());

            // Act
            ValidationResult result = _stu.Validate(query);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(2);
            result.Errors.First(e => e.PropertyName == "GameIds").ErrorMessage.Should().Be("Lista de jogos não pode ser vazia!");
        }

        [Fact()]
        public void Validate_InvalidQueryPoweOfTwo_ShouldReturnFalseWithValidationErros()
        {
            // Arrange
            TournamentResultCommand query = new(new List<string>() { "Game a" });

            // Act
            ValidationResult result = _stu.Validate(query);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
            result.Errors.First(e => e.PropertyName == "GameIds").ErrorMessage.Should().Be("Lista de jogos não tem uma quantidade suficiente, quantidade necessita ser exponencial de 2, não é possivel criar um torneio balanceado!");
        }

        [Fact()]
        public void Validate_ValidQuery_ShouldReturnTrueWithoutValidationErros()
        {
            // Arrange
            TournamentResultCommand query = new(new List<string>() { "Game a", "Game b" });

            // Act
            ValidationResult result = _stu.Validate(query);

            // Assert
            result.IsValid.Should().BeTrue();
            result.Errors.Should().BeEmpty();
        }
    }

}
