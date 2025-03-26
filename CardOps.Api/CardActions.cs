using CardOps.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;

namespace CardOps.Api
{
    public class CardActions(ILogger<CardActions> logger, CardService cardService)
    {
        [Function(nameof(CardActions))]
        [OpenApiOperation(operationId: nameof(RunAsync))]
        [OpenApiParameter(nameof(userId))]
        [OpenApiParameter(nameof(cardNumber))]
        public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = $"users/{{{nameof(userId)}}}/cards/{{{nameof(cardNumber)}}}/actions")] HttpRequest req, string userId, string cardNumber)
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
