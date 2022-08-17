# ZuoraClient.Api.OAuthApi

All URIs are relative to *https://rest.zuora.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateToken**](OAuthApi.md#createtoken) | **POST** /oauth/token | Create an OAuth token |

<a name="createtoken"></a>
# **CreateToken**
> TokenResponse CreateToken (string clientId, string clientSecret, string grantType, string zuoraTrackId = null)

Create an OAuth token

Creates a bearer token that enables an OAuth client to authenticate with the Zuora REST API. The OAuth client must have been created using the Zuora UI. See [Authentication](https://www.zuora.com/developer/api-reference/#section/Authentication) for more information.  **Note:** When using this operation, do not set any authentication headers such as `Authorization`, `apiAccessKeyId`, or `apiSecretAccessKey`.  You should not use this operation to generate a large number of bearer tokens in a short period of time; each token should be used until it expires. If you receive a 429 Too Many Requests response when using this operation, reduce the frequency of requests. This endpoint is rate limited by IP address. The rate limit is 100 requests per minute. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ZuoraClient.Api;
using ZuoraClient.Client;
using ZuoraClient.Model;

namespace Example
{
    public class CreateTokenExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://rest.zuora.com";
            var apiInstance = new OAuthApi(config);
            var clientId = "clientId_example";  // string | The Client ID of the OAuth client. 
            var clientSecret = "clientSecret_example";  // string | The Client Secret that was displayed when the OAuth client was created. 
            var grantType = "client_credentials";  // string | The OAuth grant type that will be used to generate the token. The value of this parameter must be `client_credentials`. 
            var zuoraTrackId = "zuoraTrackId_example";  // string | A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (`:`), semicolon (`;`), double quote (`\"`), and quote (`'`).  (optional) 

            try
            {
                // Create an OAuth token
                TokenResponse result = apiInstance.CreateToken(clientId, clientSecret, grantType, zuoraTrackId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OAuthApi.CreateToken: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateTokenWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create an OAuth token
    ApiResponse<TokenResponse> response = apiInstance.CreateTokenWithHttpInfo(clientId, clientSecret, grantType, zuoraTrackId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OAuthApi.CreateTokenWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **clientId** | **string** | The Client ID of the OAuth client.  |  |
| **clientSecret** | **string** | The Client Secret that was displayed when the OAuth client was created.  |  |
| **grantType** | **string** | The OAuth grant type that will be used to generate the token. The value of this parameter must be &#x60;client_credentials&#x60;.  |  |
| **zuoraTrackId** | **string** | A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  | [optional]  |

### Return type

[**TokenResponse**](TokenResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/json; charset=utf-8, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  * X-RateLimit-Remaining-minute - The number of requests that you may make in the next minute. See [rate limits](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Policies/Concurrent_Request_Limits#Rate_limits) for more information.  <br>  * Zuora-Request-Id - The Zuora internal identifier of the API call. You cannot control the value of this header.  <br>  * X-RateLimit-Limit-minute - The rate limit of this operation, in requests per minute. See [rate limits](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Policies/Concurrent_Request_Limits#Rate_limits) for more information.  <br>  * Zuora-Track-Id - A custom identifier for tracing the API call. If you specified a tracing identifier in the request headers, Zuora returns the same tracing identifier. Otherwise, Zuora does not set this header.  <br>  |
| **429** | Too Many Requests |  * X-RateLimit-Remaining-minute - The number of requests that you may make in the next minute. See [rate limits](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Policies/Concurrent_Request_Limits#Rate_limits) for more information.  <br>  * Zuora-Request-Id - The Zuora internal identifier of the API call. You cannot control the value of this header.  <br>  * X-RateLimit-Limit-minute - The rate limit of this operation, in requests per minute. See [rate limits](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Policies/Concurrent_Request_Limits#Rate_limits) for more information.  <br>  * Zuora-Track-Id - A custom identifier for tracing the API call. If you specified a tracing identifier in the request headers, Zuora returns the same tracing identifier. Otherwise, Zuora does not set this header.  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

