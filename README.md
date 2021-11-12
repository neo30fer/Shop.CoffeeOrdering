# Sample Coffee Shop Ordering ASP.NET Core REST WebApi

## Tecnhology Stack

1. .NET Core 3.1 WebApi
2. .NET Standard 2.0 Class Library
3. MongoDB


## Usage via Postman

1. Get Authentication Token:

   POST http://localhost:51062/api/users/authenticate
   ```js
    {
      "firstName": "string",
      "lastName": "string",
      "userName": "admin",
      "password": "123456",
      "token": "string"
    }
   ```

  The response should show the Bearer token ("token" field), which is needed to be added to the following requests.

2. Get all Items:

  GET http://localhost:51062/api/items

3. Create new Item:

  POST http://localhost:51062/api/items
   ```js
    {
      "name": "Apple juice",
      "price": 5.56,
      "tax": 14
    }
   ```

4. Create new Order:

  POST http://localhost:51062/api/orders
   ```js
    {
      "user": {
          "userId": "6158b65e1c1a23e73ee434c4"
      },
      "orderLines": [
          {
              "item": {
                  "itemId": "6157ffffdb64b55174966441"
              },
              "quantity": 2,
              "discount": 3
          },
          {
              "item": {
                  "itemId": "6157ff49db64b5517496643f"
              },
              "quantity": 1
          }      
      ]
    }
   ```
