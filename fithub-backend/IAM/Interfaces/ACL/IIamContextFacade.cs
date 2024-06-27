namespace fithub_backend.IAM.Interfaces.ACL;


public interface IIamContextFacade
{
    Task<int> CreateUser(string username, string password, string email, string birthdate, string objective);
    Task<int> FetchUserIdByUsername(string username);
    Task<string> FetchUsernameByUserId(int userId);
}