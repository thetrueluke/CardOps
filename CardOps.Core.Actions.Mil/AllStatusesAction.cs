using CardOps.Core.Enums;

namespace CardOps.Core.Actions.Mil
{
    public abstract class AllStatusesAction : ICardAction
    {
        public virtual IEnumerable<CardType> CardTypes => Helpers.AllCardTypes;
        
        public IEnumerable<CardStatus> CardStatuses =>
        [
            CardStatus.Ordered,
            CardStatus.Inactive,
            CardStatus.Active,
            CardStatus.Restricted,
            CardStatus.Blocked,
            CardStatus.Expired,
            CardStatus.Closed
        ];
    }
}
