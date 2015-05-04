using System.Linq;
using Repository.Repository;

namespace Repository.Mocks
{
    public class InMemoryUserRepository:RepositoryMock<User>,
        IUserRepository
    {
        public InMemoryUserRepository()
        {

        }

        public User GetByUserName(string userName)
        {
            if (userName == null)
                return null;

            return Items.FirstOrDefault(i => i.UserName == userName);
        }
    }
}