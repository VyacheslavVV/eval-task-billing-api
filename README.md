# Billing-API
This repository contains implementation of programming task "Billing API"

## Solution details

This project was built on **.NET 6.0**.
To run a project either launch it in IDE or build it and execute 

`dotnet Billing-API.dll`

in build folder

## Using API

This API consumes HTTP requests.
It containes a single method /Order which expects POST requests with JSON in the body:

```
{
    "AmountInCents"
    "UserId"
    "OrderNumber"
    "Description"
    "GatewayCode"
}
```

where:
- **AmountInCents** - integer, is the transaction’s amount
- **UserId** - integer, user identifier
- **Description** - optional transaction’s description
- **GatewayCode** - payment gateway identifier, currently: 0 - Working Gateway; 1 - Non Working Gateway

---

**example of successful request:**

```
curl --location --request POST 'https://localhost:5001/Order' \
--header 'Content-Type: application/json' \
--data-raw '{
    "AmountInCents": 100,
    "UserId": 1,
    "OrderNumber": 2,
    "Description": "is optional",
    "GatewayCode": 0
}'
```

an expected response example is (payment receipt):

```
{
    "merchantName": "Working merchant",
    "transactionId": "c3d9bde3-114e-4674-b875-90ad6897c026",
    "processedAt": "2022-10-13T23:06:59.397933+03:00",
    "amountInCents": 100
}
```

**example of error request:**

```
curl --location --request POST 'https://localhost:5001/Order' \
--header 'Content-Type: application/json' \
--data-raw '{
    "AmountInCents": 100,
    "UserId": 1,
    "OrderNumber": 2,
    "Description": "is optional",
    "GatewayCode": 1
}'
```

an expected response example is:

```
Something went wrong
```
