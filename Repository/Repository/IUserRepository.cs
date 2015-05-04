namespace Repository.Repository
{
    public interface IUserRepository:IRepository<User>
    {
        User GetByUserName(string userName);
    }
}