using Microsoft.AspNetCore.Mvc;
using ProjecktC.Data;
using ProjecktC.Data.DTOs;
using ProjecktC.Data.Models;

namespace ProjecktC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MembershipController:ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllMemberships()
        {
            var MembershipDb = FDB.MembershipsDb.ToList();
            
            return Ok(MembershipDb);
        }
        
        
        [HttpGet("{id}")]
        public IActionResult GetMembershipsById(int id)
        {
            var MermbershipsDb = FDB.MembershipsDb.FirstOrDefault(x => x.Id == id);

            if(MermbershipsDb == null)
            {
                return NotFound($"Membership with id = {id} not found");
            } else
            {
                return Ok(MermbershipsDb);
            }
        }
        
        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteMembershipById(int id)
        {
            var MembershipsDb = FDB.MembershipsDb.FirstOrDefault(x => x.Id == id);
            
            if(MembershipsDb == null)
            {
                return NotFound($"Membership with id = {id} not found");
            } 
            else
            {
                FDB.MembershipsDb.Remove(MembershipsDb);
                return Ok($"Membership with id = {id} was removed");
            }
        }        
        
        [HttpPost]
        public IActionResult PostMembership([FromBody]PostMembershipDto payload)
        {
            var newMembership = new Memberships()
            {
                Id = new Random().Next(10, 100),
                FirstName = payload.FirstName,
                LastName = payload.LastName,
                Address = payload.Address,
                Status = payload.Status
            };

            FDB.MembershipsDb.Add(newMembership);
            
            return Ok("New Membership created");
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateMembershipById(int id, [FromBody]PutMembershipDto payload)
        {
            var MembershipsDb = FDB.MembershipsDb.FirstOrDefault(x => x.Id == id);

            if(MembershipsDb == null)
            {
                return NotFound($"Membership with id = {id} not found");
            } else
            {
                MembershipsDb.FirstName = payload.FirstName;
                MembershipsDb.LastName = payload.LastName;
                MembershipsDb.Address = payload.Address;
                MembershipsDb.Status = payload.Status;
                

                return Ok($"Membership with id = {id} was updated");
            }
        }
    }
}