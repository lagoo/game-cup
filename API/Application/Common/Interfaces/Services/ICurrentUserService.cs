namespace Application.Common.Interfaces.Services
{
    public interface ICurrentUserService
    {
        int UserId { get; }

        string UserName { get; }
    }
}
