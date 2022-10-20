using Card.API.Data;
using Card.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Card.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CardsController : ControllerBase
{
    private readonly CardsDbContext cardsDbContext;

    // This Controller for Cards 
    public CardsController(CardsDbContext cardsDbContext)
    {
        this.cardsDbContext = cardsDbContext;
    }
    //Get All Cards
    [HttpGet]
    public async Task<IActionResult> GetAllCards()
    {
        var cards = await cardsDbContext.Cards.ToListAsync();
        return Ok(cards);
    }
    [HttpGet] 
    [ActionName("GetCard")]
    public async Task<IActionResult> GetCard(int id)
    {
        var card = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
        if (card != null)
        {
            return Ok(card);
        }
        return NotFound("Card not found");
    }

    //get  card
    [HttpPost]
    public async Task<IActionResult> AddCard(Model.Card card)
    { 
        await cardsDbContext.Cards.AddAsync(card);
        await cardsDbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCard), new { id = card.Id }, card);
    }
    //updating A card
    [HttpPut]
    [Route("{id:guid}")]

    public async Task<IActionResult> UpdatrCard([FromRoute] int id, [FromRoute] Model.Card card)
    {
        var existingCard = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
        if (existingCard != null)
        {
            existingCard.CardHolderName = card.CardHolderName;
            existingCard.CardNumber = card.CardNumber;
            existingCard.ExpiryMonth = card.ExpiryMonth;
            existingCard.ExpiryYear = card.ExpiryYear;
            existingCard.CVC = card.CVC;
            await cardsDbContext.SaveChangesAsync();
            return Ok(existingCard);

        }
        return NotFound("Card not found");
    }

    //delete a card
    [HttpDelete]
    [Route("{id:guid}")]

    public async Task<IActionResult> DeleteCard([FromRoute] int id)
    {
        var existingCard = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
        if (existingCard != null)
        {
            cardsDbContext.Remove(existingCard);
            await cardsDbContext.SaveChangesAsync();
            return Ok(existingCard);

        }
        return NotFound("Card not found");
    }
}