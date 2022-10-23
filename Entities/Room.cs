using System.ComponentModel.DataAnnotations.Schema;

namespace Xarajat.Api.Entities;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Key { get; set; }
    public RoomStatus Status { get; set; }
    public int AdminId { get; set; }
    [ForeignKey("AdminId")]
    public User Admin { get; set; }
    // Bu malumot databse ga saqlanmaydi chunki bunaqa column bolmaydi databasaga.
    public List<User> Users { get; set; }
    // List lar ham saqlanmaydi.
    public List<Outlay> Outlays { get; set; }
    // List lar ham saqlanmaydi.
}