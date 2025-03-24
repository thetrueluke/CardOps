using CardOps.Core.Enums;

namespace CardOps.Core.Models
{
    public record CardDetails(string CardNumber, CardType CardType, CardStatus CardStatus, bool IsPinSet);
}
