namespace Xarajat.Api.Entities;

public class Outlay  // Xarajatlarni xisoblovshi entity 
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    public int UserId { get; set; }
    public int RoomId { get; set; }
}