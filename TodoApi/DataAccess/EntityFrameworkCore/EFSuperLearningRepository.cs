using TodoApi.Models;

namespace TodoApi.DataAccess.EntityFrameworkCore;

public class EFSuperLearningRepository : ISuperLearningRepository
{
    private readonly EfSuperLearningContext _context;

    public EFSuperLearningRepository(EfSuperLearningContext context)
    {
        _context = context;
    }
    public void AddUser(SuperLearningUser user)
    {
        _context.SuperLearningUsers.Add(user);
        _context.SaveChanges();
    }

    public void DeleteUser(SuperLearningUser user)
    {
        _context.SuperLearningUsers.Remove(user);
        _context.SaveChanges();
    }

    public void UpdateUser(SuperLearningUser updateUser)
    {
        var currentUser = GetUser(updateUser.Id);
        currentUser.Name = updateUser.Name;
        currentUser.Role = updateUser.Role;

        _context.SuperLearningUsers.Update(currentUser);
        _context.SaveChanges();
    }

    public IEnumerable<SuperLearningUser> GetSuperLearningUsers()
    {
        return _context.SuperLearningUsers;
    }

    public SuperLearningUser GetUser(int Id)
    {
        return _context.SuperLearningUsers.Find(Id);
    }
}