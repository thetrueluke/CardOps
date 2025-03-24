using CardOps.Core.Enums;
using CardOps.Core.Models;

namespace CardOps.Core.Actions.Mil
{
    public abstract class PinStatusDependentAction : ICardAction
    {
        public abstract IEnumerable<CardType> CardTypes { get; }

        public abstract IEnumerable<PinStatusDependantCardStatus> PinDependantCardStatuses { get; }

        public IEnumerable<CardStatus> CardStatuses => PinDependantCardStatuses.Select(card => card.Status);

        public bool IsAllowed(CardDetails card)
        {
            return CardTypes.Contains(card.CardType) && PinDependantCardStatuses.Any(pdcs => pdcs.Status == card.CardStatus && pdcs.PinStatus is null || pdcs.PinStatus == card.IsPinSet);
        }
    }
}