# ZuoraClient.Api.BillingPreviewRunApi

All URIs are relative to *https://rest.zuora.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GETBillingPreviewRun**](BillingPreviewRunApi.md#getbillingpreviewrun) | **GET** /v1/billing-preview-runs/{billingPreviewRunId} | Retrieve a billing preview run |
| [**POSTBillingPreviewRun**](BillingPreviewRunApi.md#postbillingpreviewrun) | **POST** /v1/billing-preview-runs | Create a billing preview run |

<a name="getbillingpreviewrun"></a>
# **GETBillingPreviewRun**
> GetBillingPreviewRunResponse GETBillingPreviewRun (string billingPreviewRunId, string authorization = null, string zuoraTrackId = null, string zuoraEntityIds = null, string zuoraVersion = null)

Retrieve a billing preview run

Retrieves a preview of future invoice items for multiple customer accounts through a billing preview run. If you have the Invoice Settlement feature enabled,  you can also retrieve a preview of future credit memo items. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.   A billing preview run asynchronously generates a downloadable CSV file containing a preview of invoice item data and credit memo item data for a batch of customer accounts. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ZuoraClient.Api;
using ZuoraClient.Client;
using ZuoraClient.Model;

namespace Example
{
    public class GETBillingPreviewRunExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://rest.zuora.com";
            var apiInstance = new BillingPreviewRunApi(config);
            var billingPreviewRunId = "billingPreviewRunId_example";  // string | Id of the billing preview run. 
            var authorization = "authorization_example";  // string | The value is in the `Bearer {token}` format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional) 
            var zuoraTrackId = "zuoraTrackId_example";  // string | A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (`:`), semicolon (`;`), double quote (`\"`), and quote (`'`).  (optional) 
            var zuoraEntityIds = "zuoraEntityIds_example";  // string | An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional) 
            var zuoraVersion = "zuoraVersion_example";  // string |  The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * `batch` * `batches`  (optional) 

            try
            {
                // Retrieve a billing preview run
                GetBillingPreviewRunResponse result = apiInstance.GETBillingPreviewRun(billingPreviewRunId, authorization, zuoraTrackId, zuoraEntityIds, zuoraVersion);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BillingPreviewRunApi.GETBillingPreviewRun: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GETBillingPreviewRunWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Retrieve a billing preview run
    ApiResponse<GetBillingPreviewRunResponse> response = apiInstance.GETBillingPreviewRunWithHttpInfo(billingPreviewRunId, authorization, zuoraTrackId, zuoraEntityIds, zuoraVersion);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BillingPreviewRunApi.GETBillingPreviewRunWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **billingPreviewRunId** | **string** | Id of the billing preview run.  |  |
| **authorization** | **string** | The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  | [optional]  |
| **zuoraTrackId** | **string** | A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  | [optional]  |
| **zuoraEntityIds** | **string** | An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  | [optional]  |
| **zuoraVersion** | **string** |  The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;batch&#x60; * &#x60;batches&#x60;  | [optional]  |

### Return type

[**GetBillingPreviewRunResponse**](GetBillingPreviewRunResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json; charset=utf-8, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  * RateLimit-Remaining - The number of requests remaining in the time window closest to quota exhaustion. See [rate limits](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Policies/Concurrent_Request_Limits#Rate_limits) for more information.  <br>  * RateLimit-Reset - The number of seconds until the quota resets for the time window closest to quota exhaustion. See [rate limits](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Policies/Concurrent_Request_Limits#Rate_limits) for more information.  <br>  * RateLimit-Limit - The request limit quota for the time window closest to exhaustion. See [rate limits](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Policies/Concurrent_Request_Limits#Rate_limits) for more information.  <br>  * Zuora-Request-Id - The Zuora internal identifier of the API call. You cannot control the value of this header.  <br>  * Zuora-Track-Id - A custom identifier for tracing the API call. If you specified a tracing identifier in the request headers, Zuora returns the same tracing identifier. Otherwise, Zuora does not set this header.  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="postbillingpreviewrun"></a>
# **POSTBillingPreviewRun**
> POSTBillingPreviewRun200Response POSTBillingPreviewRun (PostBillingPreviewRunParam request, string authorization = null, string zuoraTrackId = null, string zuoraEntityIds = null, string zuoraVersion = null)

Create a billing preview run

Creates a billing preview run for multiple customer accounts.  You can run up to 20 billing preview runs in batches concurrently. A single batch of customer accounts can only have one billing preview run at a time. So you can have up to 20 batches running at the same time. If you create a billing preview run for all customer batches, you cannot create another billing preview run until this preview run is completed. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ZuoraClient.Api;
using ZuoraClient.Client;
using ZuoraClient.Model;

namespace Example
{
    public class POSTBillingPreviewRunExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://rest.zuora.com";
            var apiInstance = new BillingPreviewRunApi(config);
            var request = new PostBillingPreviewRunParam(); // PostBillingPreviewRunParam | 
            var authorization = "authorization_example";  // string | The value is in the `Bearer {token}` format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional) 
            var zuoraTrackId = "zuoraTrackId_example";  // string | A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (`:`), semicolon (`;`), double quote (`\"`), and quote (`'`).  (optional) 
            var zuoraEntityIds = "zuoraEntityIds_example";  // string | An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional) 
            var zuoraVersion = "zuoraVersion_example";  // string |  The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * `batch` * `batches`          (optional) 

            try
            {
                // Create a billing preview run
                POSTBillingPreviewRun200Response result = apiInstance.POSTBillingPreviewRun(request, authorization, zuoraTrackId, zuoraEntityIds, zuoraVersion);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling BillingPreviewRunApi.POSTBillingPreviewRun: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the POSTBillingPreviewRunWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create a billing preview run
    ApiResponse<POSTBillingPreviewRun200Response> response = apiInstance.POSTBillingPreviewRunWithHttpInfo(request, authorization, zuoraTrackId, zuoraEntityIds, zuoraVersion);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling BillingPreviewRunApi.POSTBillingPreviewRunWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **request** | [**PostBillingPreviewRunParam**](PostBillingPreviewRunParam.md) |  |  |
| **authorization** | **string** | The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  | [optional]  |
| **zuoraTrackId** | **string** | A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  | [optional]  |
| **zuoraEntityIds** | **string** | An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  | [optional]  |
| **zuoraVersion** | **string** |  The minor version of the Zuora REST API. See [Minor Version](https://www.zuora.com/developer/api-reference/#section/API-Versions/Minor-Version) for information about REST API version control.   This header affects the availability of the following request fields: * &#x60;batch&#x60; * &#x60;batches&#x60;          | [optional]  |

### Return type

[**POSTBillingPreviewRun200Response**](POSTBillingPreviewRun200Response.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json; charset=utf-8
 - **Accept**: application/json; charset=utf-8, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  * RateLimit-Remaining - The number of requests remaining in the time window closest to quota exhaustion. See [rate limits](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Policies/Concurrent_Request_Limits#Rate_limits) for more information.  <br>  * RateLimit-Reset - The number of seconds until the quota resets for the time window closest to quota exhaustion. See [rate limits](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Policies/Concurrent_Request_Limits#Rate_limits) for more information.  <br>  * RateLimit-Limit - The request limit quota for the time window closest to exhaustion. See [rate limits](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Policies/Concurrent_Request_Limits#Rate_limits) for more information.  <br>  * Zuora-Request-Id - The Zuora internal identifier of the API call. You cannot control the value of this header.  <br>  * Zuora-Track-Id - A custom identifier for tracing the API call. If you specified a tracing identifier in the request headers, Zuora returns the same tracing identifier. Otherwise, Zuora does not set this header.  <br>  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

