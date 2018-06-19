using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public class UserRepository : IUserRepository
  {
    private DataContext context;

    public UserRepository(DataContext ctx) => context = ctx;

    public IEnumerable<User> Users => context.Users;

    public void AddUser(User user)
    {
      context.Users.Add(user);
      context.SaveChanges();
    }

    public void UpdateUser(User user)
    {
      User p = context.Users.Find(user.Id);
      p.name = user.name;
      context.SaveChanges();
    }
    public void DeleteUser(User user)
    {
      context.Users.Remove(user);
      context.SaveChanges();
    }
  }
}
