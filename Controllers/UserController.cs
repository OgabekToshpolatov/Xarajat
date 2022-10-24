using Microsoft.AspNetCore.Mvc;
using Xarajat.Api.Data;
using Xarajat.Api.Entities;
using Xarajat.Api.Models;

namespace Xarajat.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController:ControllerBase
{
    private readonly XarajatDbContext _context;

    public UserController(XarajatDbContext context)
    {
        _context = context ;
    }

    [HttpGet]
    public List<Entities.User> GetUsers()
    {
        var  users = _context.Users?.ToList();
        return users;
    }
    
    [HttpPost]
    public IActionResult AddUser(CreateUserModel createUserModel)
    {
        if (_context.Users.Any(u => u.Phone == createUserModel.Phone))
        {
            return BadRequest();
        }

        var user = new User()
        {
            Name = createUserModel.Name,
            Email = createUserModel.Email,
            Phone = createUserModel.Phone,
            CreatedDate = DateTime.Now
        };

        _context.Users.Add(user);
        _context.SaveChanges();
        return Ok(user);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id ==id); 

        if(user == null)
        {
            return BadRequest();
        }

        return Ok(user);

    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, UpdateUserModel updateUserModel)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        user.Name = updateUserModel.Name;
        user.Email = updateUserModel.Email;
        user.Phone = updateUserModel.Phone;

        _context.SaveChanges();

        return Ok(user);
    }

    [HttpDelete]
    public IActionResult DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        _context.SaveChanges();

        return Ok();
    }
    
    // Xonaga user qoshadigan Action => 
    [HttpPost("join-room/{roomId}")]
    public IActionResult JoinRoom(int roomId, string key, int userId)
    {
       var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);

        if (room == null || room.Key != key)
            return NotFound();

        var user = _context.Users.FirstOrDefault(u => u.Id == userId);

        user.RoomId = roomId;
        _context.SaveChanges();
        return Ok(user);
    }
    

   
}