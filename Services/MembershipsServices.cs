using Microsoft.EntityFrameworkCore;
using ProjecktC.Data;
using ProjecktC.Data.DTOs;
using ProjecktC.Data.Models;

namespace ProjecktC.Services;

public class MembershipsServices:IMembershipsServices
{
    private AppDbContext _dbContext;
    public MembershipsServices(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Memberships>> GetMembershipsAsync()
    {
        var allMemberships = await _dbContext.Memberships.ToListAsync();
        return allMemberships;
        
    }

    public async Task<Memberships> GetMembershipByIdAsync(int id)
    {
        var membershipFromDb = await _dbContext.Memberships.FirstOrDefaultAsync(x => x.Id == id);
        return membershipFromDb;

    }

    public async Task PostMembershipAsync(PostMembershipDto membership)
    {
        
        var newMembership = new Memberships()
        {
            FirstName = membership.FirstName,
            LastName  = membership.LastName,
            Status = membership.Status,
            Address = membership.Address
        };

        await _dbContext.Memberships.AddAsync(newMembership);
        await _dbContext.SaveChangesAsync();

    }

    public async Task<Memberships> UpdateMembershipAsync(int id, PutMembershipDto membership)
    {
        var membershipFromDb = await _dbContext.Memberships.FirstOrDefaultAsync(x => x.Id == id);

        if(membershipFromDb != null)
        {
            membershipFromDb.FirstName = membership.FirstName;
            membershipFromDb.LastName = membership.LastName;
            membershipFromDb.Status = membership.Status;
            membershipFromDb.Address = membership.Address;

            await _dbContext.SaveChangesAsync();
        }

        return membershipFromDb;    }

    public async Task DeleteMembershipByIdAsync(int id)
    {
        var membershipFromDb = await _dbContext.Memberships.FirstOrDefaultAsync(x => x.Id == id);

        if (membershipFromDb != null)
        {
            _dbContext.Memberships.Remove(membershipFromDb);
            await _dbContext.SaveChangesAsync();
        }
    }
}