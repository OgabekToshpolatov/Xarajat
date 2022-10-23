using Microsoft.AspNetCore.Mvc;
using Xarajat.Api.Data;
using Xarajat.Api.Entities;
using Xarajat.Api.Helpers;
using Xarajat.Api.Models;

namespace Xarajat.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController:ControllerBase
{
    private readonly XarajatDbContext _context;

    public RoomController(XarajatDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetRooms()
    {
        var rooms = _context.Rooms.Select(room => ConvertToRoomModel(room)).ToList();

        return Ok(rooms);
    }

    [HttpPost]
    public IActionResult AddRoom(CreateRoomModel createRoomModel)
    {
        var room = new Room()
        {
            Name = createRoomModel.Name,
            Status = RoomStatus.Created,
            Key = RandomGenerator.GetRandomString(),
            AdminId = 1
        };

        _context.Rooms.Add(room);
        _context.SaveChanges();
        return Ok(ConvertToRoomModel(room));
    }

    [HttpGet("{id}")]
    public IActionResult GetRoomById(int id)
    {
        var room = _context.Rooms.FirstOrDefault(k => k.Id ==id);

        if(room == null) return NotFound();

        var user = _context.Users.FirstOrDefault(u => u.Id == room.AdminId);

        var getRoomModel = ConvertToRoomModel(room);
        getRoomModel.Admin = ConvertToUserModel(user);

        return Ok(getRoomModel);

    }

    [HttpPut]
    public IActionResult UpdateRoom(int id , UpdateRoomModel updateRoomModel)
    {
        var room = _context.Rooms.FirstOrDefault( r => r.Id == id);

        if(room is null )  return NotFound();
        
        room.Name = updateRoomModel.Name;
        room.Status = updateRoomModel.Status;
        

        _context.Rooms.Update(room);
        _context.SaveChanges();
        return Ok(ConvertToRoomModel(room));
    }

    [HttpDelete]
    public IActionResult DeleteRoom(int id)
    {
        var room = _context.Rooms.FirstOrDefault(u => u.Id == id);

        if(room is null) return NotFound();

        _context.Rooms.Remove(room);

        _context.SaveChanges();

        return Ok(room);
    }

    private GetRoomModel ConvertToRoomModel(Room room)
    {
        return new GetRoomModel()
        {
            Id = room.Id,
            Name = room.Name,
            Key = room.Key,
            Status = room.Status,
            Admin = ConvertToUserModel(room.Admin)
        };
    }

    private GetUser ConvertToUserModel(User user)
    {
        if (user == null) return null;

        return new GetUser
        {
            Id = user.Id,
            Name = user.Name
        };
    }
}