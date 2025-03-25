using CardOps.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace CardOps.Api
{
    public class CardActions(ILogger<CardActions> logger, CardService cardService)
    {
        [Function(nameof(CardActions))]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "users/{userId}/cards/{cardNumber}/actions")] HttpRequest req, string userId, string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                logger.LogInformation("C# HTTP trigger function processed a request with invalid userId");
                return new BadRequestObjectResult($"'{nameof(userId)}' cannot be null or whitespace.");
            }
            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                logger.LogInformation("C# HTTP trigger function processed a request with invalid cardNumber");
                return new BadRequestObjectResult($"'{nameof(cardNumber)}' cannot be null or whitespace.");
            }

            logger.LogInformation("C# HTTP trigger function processed a request for userId: {UserId}, cardNumber: {CardNumber}", userId, cardNumber);
            
            var cardDetails = await cardService.GetCardDetails(userId, cardNumber);

            return cardDetails == null
                ? new NotFoundObjectResult($"Card {cardNumber} not found for user {userId}.")
                : new OkObjectResult(new Response(cardNumber, userId, ActionDiscoveryService.GetAllowedActions(cardDetails).Select(a => a.Name)));
        }
    }
}
