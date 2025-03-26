using CardOps.Core.Enums;

namespace CardOps.Core.Actions.Mil
{
    public sealed class Action5 : AllStatusesAction
    {
        public override IEnumerable<CardType> CardTypes => [CardType.Credit];
    }
}
