using System;
using System.Threading.Tasks;

namespace ProjectX.Server.Database.User;

public interface IUserRepository
{ 
    Task<UserModel?> CreateModel(string? firstName, string? lastName, string? phone, string? avatarUrl, DateTime createdAt);
    Task<UserModel?> FindByUid(string uid);
}