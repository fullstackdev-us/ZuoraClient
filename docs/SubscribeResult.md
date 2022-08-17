# ZuoraClient.Model.SubscribeResult

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** |  | [optional] 
**AccountNumber** | **string** |  | [optional] 
**ChargeMetricsData** | [**SubscribeResultChargeMetricsData**](SubscribeResultChargeMetricsData.md) |  | [optional] 
**CreditMemoData** | [**List&lt;ActionSubscribeCreditMemoData&gt;**](ActionSubscribeCreditMemoData.md) | Container for credit memo data.  **Note**: This field is only available if you have the Invoice Settlement feature enabled and set the &#x60;X-Zuora-WSDL-Version&#x60; request header to &#x60;107&#x60; or later.  | [optional] 
**CreditMemoId** | **string** | The ID of the credit memo.  **Note**: This field is only available if you have the Invoice Settlement feature enabled and set the &#x60;X-Zuora-WSDL-Version&#x60; request header to &#x60;107&#x60; or later.  | [optional] 
**CreditMemoNumber** | **string** | The number of the credit memo.  **Note**: This field is only available if you have the Invoice Settlement feature enabled and set the &#x60;X-Zuora-WSDL-Version&#x60; request header to &#x60;107&#x60; or later.  | [optional] 
**CreditMemoResult** | [**CreditMemoResult**](CreditMemoResult.md) |  | [optional] 
**Errors** | [**List&lt;ActionsErrorResponse&gt;**](ActionsErrorResponse.md) |  | [optional] 
**GatewayResponse** | **string** |  | [optional] 
**GatewayResponseCode** | **string** |  | [optional] 
**InvoiceData** | [**List&lt;ActionSubscribeInvoiceData&gt;**](ActionSubscribeInvoiceData.md) |  | [optional] 
**InvoiceId** | **string** |  | [optional] 
**InvoiceNumber** | **string** |  | [optional] 
**InvoiceResult** | [**SubscribeResultInvoiceResult**](SubscribeResultInvoiceResult.md) |  | [optional] 
**PaymentId** | **string** |  | [optional] 
**PaymentTransactionNumber** | **string** |  | [optional] 
**SubscriptionId** | **string** |  | [optional] 
**SubscriptionNumber** | **string** |  | [optional] 
**Success** | **bool** |  | [optional] 
**TotalMrr** | **double** |  | [optional] 
**TotalTcv** | **double** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

