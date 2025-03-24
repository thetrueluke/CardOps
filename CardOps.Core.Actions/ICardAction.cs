using CardOps.Core.Enums;
using CardOps.Core.Models;

namespace CardOps.Core.Actions
{
    public interface ICardAction
    {
        IEnumerable<CardType> CardTypes { get; }
        IEnumerable<CardStatus> CardStatuses { get; }
        string Name => GetType().Name;

        bool IsAllowed(CardDetails card)
        {
            return CardTypes.Contains(card.CardType) && CardStatuses.Contains(card.CardStatus);
        }
    }
}
