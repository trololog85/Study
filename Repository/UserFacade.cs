using Repository.Repository;

namespace Repository
{
    public class UserFacade
    {
        private readonly IUserRepository _userRepository;

        public UserFacade(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool UserNameExists(string userName)
        {
            var user = _userRepository.GetByUserName(userName);

            if (user != null)
                return true;

            return false;
        }
    }
}