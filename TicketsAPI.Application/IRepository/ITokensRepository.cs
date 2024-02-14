using TicketsAPI.Domain;

namespace TicketsAPI.Application.IRepository
{
    public interface ITokensRepository
    {
        Tokens Authenticate(User users);
    }
}
