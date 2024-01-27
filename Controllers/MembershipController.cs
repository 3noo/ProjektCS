using Microsoft.AspNetCore.Mvc;
using ProjecktC.Data;
using ProjecktC.Data.DTOs;
using ProjecktC.Data.Models;
using ProjecktC.Services;

namespace ProjecktC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MembershipController:ControllerBase
    {
        private IMembershipsServices _membershipsService;
        public MembershipController(IMembershipsServices membershipsService)
        {
            _membershipsService = membershipsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMemberships()
        {
            var membershipDb = await _membershipsService.GetMembershipsAsync();
            
            return Ok(membershipDb);
        }
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMembershipsById(int id)
        {
            var membershipsDb =await _membershipsService.GetMembershipByIdAsync(id);

            if(membershipsDb == null)
            {
                return NotFound($"Membership with id = {id} not found");
            } else
            {
                return Ok(membershipsDb);
            }
        }
        
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteMembershipById(int id)
        {
           await _membershipsService.DeleteMembershipByIdAsync(id);

                return Ok($"Membership with id = {id} was removed");
            }
        
        [HttpPost]
        public async Task<IActionResult> PostMembership([FromBody]PostMembershipDto payload)
        {
            await _membershipsService.PostMembershipAsync(payload);
            
            return Ok("New Membership created");
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMembershipById(int id, [FromBody]PutMembershipDto payload)
        {
           await _membershipsService.UpdateMembershipAsync(id,payload);


                return Ok($"Membership with id = {id} was updated");
            }
        }
    }
