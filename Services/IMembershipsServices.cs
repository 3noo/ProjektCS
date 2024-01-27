using ProjecktC.Data.DTOs;
using ProjecktC.Data.Models;

namespace ProjecktC.Services;

public interface IMembershipsServices
{
    Task<List<Memberships>> GetMembershipsAsync();
    Task<Memberships> GetMembershipByIdAsync(int id);
    Task PostMembershipAsync(PostMembershipDto membership);
    Task<Memberships> UpdateMembershipAsync(int id, PutMembershipDto membership);
    Task DeleteMembershipByIdAsync(int id);
}