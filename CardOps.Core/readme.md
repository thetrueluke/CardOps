# CardOps.Core

CardOps.Core is the core component of the CardOps solution, providing the main service for retrieving card actions.

This service is a sample implementation provided to demonstrate how card data can be managed and accessed within an application, organized in a structured directory layout.
Overview

The CardService class implements functionality to retrieve details of a user's card based on a provided userId and cardNumber. This sample service utilizes generated data for demonstration purposes, simulating typical interactions with a database or external service.

Features

* Retrieves card details for a user based on their ID and card number.
* Sample data generation for easy testing without a live data source.
* Robust against erroneous inputs, allowing for flexibility in usage. The service only disallows null strings as inputs for userId and cardNumber.
* Additionally organized in a directory structure for readability.
