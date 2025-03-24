using CardOps.Core.Actions;

namespace CardOps.Api
{
    public record Response(IEnumerable<string> CardActions)
    {
    }
}
