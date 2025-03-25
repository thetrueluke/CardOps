# CardOps.Core.Actions

CardOps.Core.Actions is a component of the CardOps solution designed to standardize the actions associated with card operations.

The primary role of this component is to provide the `ICardAction` interface, which defines the contract for actions that can be performed on cards based on their types, statuses, and whether or not the pin has been set.
Overview

The `ICardAction` interface includes properties and a method that specify which card types and statuses are permissible for a particular action.

 ## ICardAction Interface

The ICardAction interface exposes the following members:

Properties

    IEnumerable<CardType> CardTypes: A collection representing the types of cards that this action applies to.
    IEnumerable<CardStatus> CardStatuses: A collection representing the statuses of cards that this action applies to.
    string Name: A read-only property that returns the name of the implementing action class, leveraging the GetType().Name method.

Methods

    bool IsAllowed(CardDetails card)

      Parameters:
      
          card (CardDetails): The card object to evaluate against the allowed types and statuses.
          
      Returns: true if the card's type and status are in the allowed collections for this action; otherwise, false.
      Description: This method includes a default implementation in the ICardAction interface.
                   It checks whether the provided card meets the criteria specified by CardTypes and CardStatuses.
                   This allows implementers of the interface to inherit this behavior without needing to reimplement the method unless specialized logic is required.
