# ZuoraClient.Api.PaymentGatewayTransactionLogsApi

All URIs are relative to *https://rest.zuora.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GETPaymentGatewayTransactionLog**](PaymentGatewayTransactionLogsApi.md#getpaymentgatewaytransactionlog) | **GET** /v1/payment-gateway-transaction-log/{paymentOrRefundOrPaymentMethod-id} | Retrieve a payment gateway transaction log |

<a name="getpaymentgatewaytransactionlog"></a>
# **GETPaymentGatewayTransactionLog**
> GETPaymentGatewayTransactionLogResponse GETPaymentGatewayTransactionLog (string paymentOrRefundOrPaymentMethodId, string authorization = null, string zuoraTrackId = null, string zuoraEntityIds = null)

Retrieve a payment gateway transaction log

Retrieves transaction log information passed through your [custom payment gateway](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/MB_Set_up_custom_payment_gateways_and_payment_methods). 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using ZuoraClient.Api;
using ZuoraClient.Client;
using ZuoraClient.Model;

namespace Example
{
    public class GETPaymentGatewayTransactionLogExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://rest.zuora.com";
            var apiInstance = new PaymentGatewayTransactionLogsApi(config);
            var paymentOrRefundOrPaymentMethodId = "paymentOrRefundOrPaymentMethodId_example";  // string | The ID of a payment, a refund, or a payment method wherein the gateway transaction log was recorded. 
            var authorization = "authorization_example";  // string | The value is in the `Bearer {token}` format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional) 
            var zuoraTrackId = "zuoraTrackId_example";  // string | A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (`:`), semicolon (`;`), double quote (`\"`), and quote (`'`).  (optional) 
            var zuoraEntityIds = "zuoraEntityIds_example";  // string | An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional) 

            try
            {
                // Retrieve a payment gateway transaction log
                GETPaymentGatewayTransactionLogResponse result = apiInstance.GETPaymentGatewayTransactionLog(paymentOrRefundOrPaymentMethodId, authorization, zuoraTrackId, zuoraEntityIds);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling PaymentGatewayTransactionLogsApi.GETPaymentGatewayTransactionLog: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GETPaymentGatewayTransactionLogWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Retrieve a payment gateway transaction log
    ApiResponse<GETPaymentGatewayTransactionLogResponse> response = apiInstance.GETPaymentGatewayTransactionLogWithHttpInfo(paymentOrRefundOrPaymentMethodId, authorization, zuoraTrackId, zuoraEntityIds);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling PaymentGatewayTransactionLogsApi.GETPaymentGatewayTransactionLogWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **paymentOrRefundOrPaymentMethodId** | **string** | The ID of a payment, a refund, or a payment method wherein the gateway transaction log was recorded.  |  |
| **authorization** | **string** | The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  | [optional]  |
| **zuoraTrackId** | **string** | A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  | [optional]  |
| **zuoraEntityIds** | **string** | An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  | [optional]  |

### Return type

[**GETPaymentGatewayTransactionLogResponse**](GETPaymentGatewayTransactionLogResponse.md)

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

