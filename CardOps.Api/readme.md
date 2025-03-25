# CardOps.Api

CardOps.Api is an Azure Function that provides a RESTful API to return available actions associated with a user's card.

It is the main entry-point for the CardOps solution.

## Overview

This API allows clients to retrieve a list of action names available for a card identified by its `cardNumber` for a given `userId`.

## API Endpoint

To retrieve available actions for a user's card, use the following endpoint:
   
```
GET users/{userId}/cards/{cardNumber}/actions
```
    

Parameters

    userId (string): The unique identifier for the user.
    cardNumber (string): The unique card number for which actions are requested.

## Request Structure
Example Request
      
```
GET https://<your-function-app>.azurewebsites.net/api/users/{userId}/cards/{cardNumber}/actions
``` 


Response Structure

The API will respond with a JSON object structured as follows:

Example Response
      
```
{
  "cardNumber": "Card11",
  "userId": "user1",
  "cardActions": [
    "Action1",
    "Action2",
    "Action3",
    "Action4"
  ]
}
```

Response Codes

    200 OK: Successfully retrieved the actions.
    400 Bad Request: Invalid input parameters.
    404 Not Found: User or card does not exist.
    500 Internal Server Error: An unexpected error occurred.

## Remarks

* Due to the fact that the parameters are taken from the path, the 400 Bad Request response will likely not occur, even if provided an empty value. Instead, the Azure Function framework will return 404 Not Found response.
