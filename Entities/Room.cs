using System.ComponentModel.DataAnnotations.Schema;

namespace Xarajat.Api.Entities;

public class Room // Xona entitysi
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Key { get; set; }
    public RoomStatus Status { get; set; }
    public int AdminId { get; set; }
    [ForeignKey("AdminId")]    // Forign key shunchaki emas u migrations vqrida database dagi malumotni ishlatadi. 
    public User Admin { get; set; }
    public List<User> Users { get; set; }
    public List<Outlay> Outlays { get; set; }
}