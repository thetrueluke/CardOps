using CardOps.Core.Enums;

namespace CardOps.Core.Actions.Mil
{
    public sealed class Action1 : ICardAction
    {
        public IEnumerable<CardType> CardTypes => Helpers.AllCardTypes();
        public IEnumerable<CardStatus> CardStatuses => [CardStatus.Active];
    }
}
