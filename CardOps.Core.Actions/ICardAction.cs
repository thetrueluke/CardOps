using CardOps.Core.Enums;
using CardOps.Core.Models;

namespace CardOps.Core.Actions
{
    /// <summary>
    /// Defines a card action.
    /// </summary>
    public interface ICardAction
    {
        /// <summary>
        /// Gets the collection of card types that the action applies to.
        /// </summary>
        IEnumerable<CardType> CardTypes { get; }

        /// <summary>
        /// Gets the collection of card statuses that are valid for this action.
        /// </summary>
        IEnumerable<CardStatus> CardStatuses { get; }

        /// <summary>
        /// Gets the name of the action.
        /// </summary>
        /// <remarks>
        /// This property is implemented by default to return the name of the type of the implementing class.
        /// </remarks>
        string Name => GetType().Name;

        /// <summary>
        /// Determines whether the specified card is allowed to perform this action.
        /// </summary>
        /// <param name="card">The details of the card to check.</param>
        /// <returns>Returns true, if the action is applicable for the provided card; otherwise, false.</returns>
        /// <remarks>
        /// This method has a default implementation that checks if the card's type and status are contained in the respective properties.
        /// Implementing classes may override this method to provide custom logic if needed.
        /// </remarks>
        bool IsAllowed(CardDetails card)
        {
            return CardTypes.Contains(card.CardType) && CardStatuses.Contains(card.CardStatus);
        }
    }
}
