using CardOps.Core.Enums;

namespace CardOps.Core.Actions.Mil
{
    public sealed class Action11 : ICardAction
    {
        public IEnumerable<CardType> CardTypes => Helpers.AllCardTypes;
        
        public IEnumerable<CardStatus> CardStatuses =>
        [
            CardStatus.Inactive,
            CardStatus.Active
        ];
    }
}
