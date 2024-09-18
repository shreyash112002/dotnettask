using DotnetTask.Model;


namespace DotnetTask.DAO
{
    public interface IUserDaoImp
    {
        public Task<List<User>> GetUsers(string host);
        public Task<User> AddUser(User u, string host);

        public Task<int> DeleteUserById(int id);

        public Task<int> UpdateUserPhoneNumberById(int id, string phoneNumber);

        public Task<string> SaveImage(IFormFile imageFile);
    }
}
