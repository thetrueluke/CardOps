using CardOps.Core.Enums;
using CardOps.Core.Models;

namespace CardOps.Core.Actions.Mil
{
    public sealed class Action6 : PinStatusDependentAction
    {
        public override IEnumerable<CardType> CardTypes => Helpers.AllCardTypes();

        public override IEnumerable<PinStatusDependantCardStatus> PinDependantCardStatuses =>
        [
            new PinStatusDependantCardStatus(CardStatus.Ordered, pinStatus: true),
            new PinStatusDependantCardStatus(CardStatus.Inactive, pinStatus: true),
            new PinStatusDependantCardStatus(CardStatus.Active, pinStatus: true),
            new PinStatusDependantCardStatus(CardStatus.Blocked, pinStatus: true)
        ];
    }
}
