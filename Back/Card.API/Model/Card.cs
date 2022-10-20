
using System.ComponentModel.DataAnnotations;

namespace Card.API.Model;
public class Card
{
    [Key]
    public int Id { get; set; }
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public int ExpiryMonth { get; set; }
    public int ExpiryYear { get; set; }
    public int CVC { get; set; }
}