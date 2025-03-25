# CardOps.Core.Actions.Mil

CardOps.Core.Actions.Mil is a module within the CardOps solution that provides specific implementations of card actions as defined by the ICardAction interface from the CardOps.Core.Actions project.

## Overview

Each action class in the CardOps.Core.Actions.Mil module implements the CardOps.Core.Actions.ICardAction interface.

## Key Features

* Specific Implementations: Contains various actions, complying with the business rules required in this context.
* Inherits from ICardAction: By implementing the ICardAction interface, each action class must define the valid card types and statuses for that particular action.

## Extensible Base Class: PinStatusDependentAction

This module exposes the abstract class PinStatusDependentAction, which serves as a base for creating actions that have card status dependencies based on whether a PIN is set. This design allows for more flexible and extensible action implementations that can incorporate PIN-related business logic. 

Purpose
* Encapsulation of Logic: The PinStatusDependentAction class encapsulates the logic required to determine if a card action is allowed based on both the card's type and its status in relation to the PIN status. 
* Easier Extensibility: By inheriting from PinStatusDependentAction, developers can easily create new actions that will automatically include the logic necessary to evaluate the PIN status. This reduces the risk of duplicating validation logic across multiple action implementations.
