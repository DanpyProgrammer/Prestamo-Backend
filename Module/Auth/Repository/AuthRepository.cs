using Prestamos_Backend.DATA;
using Prestamos_Backend.Module.Auth.Entities;

namespace Prestamos_Backend.Module.Auth.Repository;

public class AuthRepository(DataContext dataContext)
{
    private readonly DataContext _dataContext = dataContext;

    public void Register(User user)
    {
        _dataContext.Users.Add(user);
        _dataContext.SaveChanges();
    }

    public bool ConfirmEmail(string email)
    {
        return _dataContext.Users.Any(u => u.Email == email);
    }

    public User? FindOneByEmail(string email)
    {
        User? user = _dataContext.Users.FirstOrDefault(u => u.Email == email);

        return user;
    }
}