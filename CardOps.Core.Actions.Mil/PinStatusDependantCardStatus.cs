using CardOps.Core.Enums;

namespace CardOps.Core.Actions.Mil
{
    public sealed class PinStatusDependantCardStatus(CardStatus status, bool? pinStatus)
    {
        public CardStatus Status { get; } = status;

        public bool? PinStatus { get; } = pinStatus;

        public static implicit operator PinStatusDependantCardStatus(CardStatus status)
        {
            return new PinStatusDependantCardStatus(status, null);
        }
    }
}
