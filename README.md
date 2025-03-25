# CardOps

CardOps is a comprehensive solution designed to showcase returning available actions for cards, based on their type, status, and optionally their pin status.
The solution consists of several modules that encapsulate specific functionalities and rules for different types of card actions.

## Overview

Modules

    CardOps.Api
        This module serves as a main entry-point for the solution. It contains an Azure Function, exposing a GET method serving as the API for retrieving available actions for provided card of a user.

    CardOps.Core
        This module contains a sample service provided to return test users and cards, and used models. It has been structured in the directory tree for better readability. No other modifications have been made.

    CardOps.Core.Actions
        The sole purpose of this module is to expose the ICardAction interface.

    CardOps.Core.Actions.Mil
        This module contains implementations of the specific actions.
        This module is not referenced by any of the other modules. Instead, it has post-build event set such that it copies the output assembly file into the `CardOps.Api` output folder.

Key Features

    Modular Design: Each module is developed independently, allowing for clear separation of responsibilities and easy updates or enhancements.
    Extensibility: Developers can easily extend existing classes or create new ones by inheriting from the defined base classes and interfaces.
    Reusable Logic: Common functionalities are abstracted into reusable classes, minimizing code duplication and promoting code quality.
    Flexibility: The solution is designed to adapt to various card management needs, from simple actions to complex business logic involving multiple conditions.

Getting Started

To set up the CardOps solution on your machine, follow these steps:

Clone the repository:
       
```
git clone https://github.com/thetrueluke/CardOps.git
cd CardOps
``` 

Open the solution in Visual Studio or your preferred IDE:

You can open the CardOps.sln file in Visual Studio.
The solution startup project is set to CardOps.Api, which is ready to be debugged locally or deployed as an Azure function in your Azure subscription.

In case you want to run the project on a different environment, please follow the respective environments instruction.
        

## Usage

The `CardOps.Core.Actions.Mil` project is not referenced by any other project. Instead, it has post-build event set such that it copies the output assembly file into the `CardOps.Api` output folder.
This way, the specific implementation is decoupled from the core.

The `CardOps.Api` then 'knows', which assemblies to use as plugins containing the implementations of the specific actions from the environmental variable `ActionPlugins`.
The `ActionPlugins` can be set in Azure Function's settings in the Azure Portal. 

When debugging locally, the `ActionPlugins` variable can be set in `local.settings.json` file:

```
{
  "Values": {
    "ActionPlugins": "CardOps.Core.Actions.Mil.dll"
  }
}
```

The `ActionPlugins` variable should contain the filenames of the plugins to load, separated by "|".

## Contributing

Contributions are welcome! If you would like to contribute to the CardOps solution, please follow these steps:

    Fork the repository.
    Create a new branch for your feature.
    Make your changes and commit them with clear messages.
    Push your branch to your forked repository.
    Open a pull request to the main repository.

License

This project is licensed under the MIT License. Refer to the LICENSE.txt file for more details.

For questions, feedback, or contributions related to the CardOps solution, please reach out via the repository or create an issue. Thank you for using CardOps for your card management needs!