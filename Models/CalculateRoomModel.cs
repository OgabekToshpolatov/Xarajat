namespace Xarajat.Api.Models;

public class CalculateRoomModel
{
    public int UsersCount { get; set; }
    public int TotalCost { get; set; }
    public int CostPerUser => TotalCost / UsersCount;
}