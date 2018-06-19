using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace compare.Models
{
  public interface IUserRepository
  {
    IEnumerable<User> Users { get; }
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(User user);
  }
}
