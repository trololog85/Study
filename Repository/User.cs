using Repository.Repository;

namespace Repository
{
    public class User:IInt32Id
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}