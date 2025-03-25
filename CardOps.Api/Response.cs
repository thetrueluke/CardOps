using CardOps.Core.Actions;

namespace CardOps.Api
{
    public record Response(string CardNumber, string UserId, IEnumerable<string> CardActions)
    {
    }
}
