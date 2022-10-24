using Microsoft.AspNetCore.Mvc;
using Xarajat.Api.Entities;

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

}