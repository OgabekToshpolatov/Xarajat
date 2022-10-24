using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xarajat.Api.Entities;
using Xarajat.Api.Models;

namespace Xarajat.Api.Controllers;

public partial class RoomController
{
    [HttpPost("{roomId}/outlays")]
    public IActionResult AddOutlay(int roomId, CreateOutlayModel createOutlayModel)
    {
        var outlay = new Outlay
        {
            Description = createOutlayModel.Description,
            Cost = createOutlayModel.Cost,
            UserId = createOutlayModel.UserId,
            RoomId = roomId
        };

        _context.Outlays.Add(outlay);
        _context.SaveChanges();
        return Ok(outlay);
    }

    [HttpGet("{roomId}/outlays")]
    public IActionResult GetRoomOutlaysByRoomId(int roomId)
    {
        var outlays = _context.Outlays.Where(Outlay => Outlay.RoomId == roomId).ToList();

        return Ok(outlays);

    }

    [HttpGet("{roomId}/outlays/calculate")]
    public IActionResult CalculateRoomOutlaysByRoomId(int roomId)
    {
        var room = _context.Rooms
            .Include(r=>r.Users)
            .Include(r=>r.Outlays)
            .FirstOrDefault(r => r.Id == roomId);

        if (room == null)
            return NotFound();

        var calculate = new CalculateRoomModel
        {
            UsersCount = room.Users.Count,
            TotalCost = room.Outlays.Sum(outlay => outlay.Cost)
        };

        return Ok(calculate);
    }


}