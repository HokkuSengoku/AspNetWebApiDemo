using TodoApi.Models;

namespace TodoApi.DataAccess;

public interface ISuperLearningRepository
{
    void AddUser(SuperLearningUser user);
    void DeleteUser(SuperLearningUser user);
    void UpdateUser(SuperLearningUser user);
    IEnumerable<SuperLearningUser> GetSuperLearningUsers();
    SuperLearningUser GetUser(int id);
}