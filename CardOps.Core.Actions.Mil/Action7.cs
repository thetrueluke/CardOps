using CardOps.Core.Enums;
using CardOps.Core.Models;

namespace CardOps.Core.Actions.Mil
{
    public sealed class Action7 : PinStatusDependentAction
    {
        public override IEnumerable<CardType> CardTypes => Helpers.AllCardTypes;

        public override IEnumerable<PinStatusDependantCardStatus> PinDependantCardStatuses =>
        [
            new PinStatusDependantCardStatus(CardStatus.Ordered, pinStatus: false),
            new PinStatusDependantCardStatus(CardStatus.Inactive, pinStatus: false),
            new PinStatusDependantCardStatus(CardStatus.Active, pinStatus: false),
            new PinStatusDependantCardStatus(CardStatus.Blocked, pinStatus: true)
        ];
    }
}
