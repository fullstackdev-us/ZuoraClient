# Zuora Billing API client - C# NetStandard 2.0
Generated using openapi-generater
## Swagger Definition
``https://assets.zuora.com/zuora-documentation/swagger.yaml``

## Usage
### Usings
```
using zuoraclient.Api;
using zuoraclient.Client;
using zuoraclient.Model;
```
### Example
```
var accessToken = "{access token obtained from zuora}";
var productId = "{product id obtained from zuora testdrive}"
var config = new Configuration()
{
    BasePath = "https://rest.apisandbox.zuora.com",
    DefaultHeaders = new Dictionary<string,string>
    {
        {
            "Authorization", $"Bearer {accessToken}"
        }
    }
};

var client = new ProductsApi(config);

var product = await client.ObjectGETProductAsync(productId);
```

## Generate a new client

```
npm i -g @openapitools/openapi-generator-cli
openapi-generator-cli generate -g csharp-netcore -i https://assets.zuora.com/zuora-documentation/swagger.yaml --package-name=ZuoraClient
```
Note: At this time the generated code will contain ~20 errors that need to be resolved.
