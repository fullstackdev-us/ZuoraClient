# ZuoraClient.Model.GETPaymentGatewayTransactionLogElementResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreateTime** | **string** | The timestamp of the logs created in ISO-8601 format.  | [optional] 
**CreatedBy** | **string** | The ID of the user who created the transaction.  | [optional] 
**Currency** | **string** | The type of currenty, in which the transaction was made.  | [optional] 
**GatewayId** | **string** | The ID of the gateway, through which the transaction was processed.  | [optional] 
**GatewayName** | **string** | The name of the gateway, through which the transaction was processed.  | [optional] 
**GatewayType** | **string** | The type of the valid gateway, through which the transactioin was processed.  | [optional] 
**GatewayVersion** | **string** | The version of the gateway, through which the transaction was processed.  | [optional] 
**Id** | **string** | The unique ID of the transaction log.  | [optional] 
**OperationId** | **string** | The ID of the transaction operation.  | [optional] 
**OperationType** | **string** | The type of transaction operation, such as &#x60;Payment&#x60;, &#x60;Refund&#x60;, &#x60;Validation&#x60;.  | [optional] 
**PaymentMethodType** | **string** | The type of the payment method used for the transaction, such as &#x60;Credit Card&#x60;, &#x60;ACH&#x60;, etc.  | [optional] 
**ReceiveTime** | **string** | The time when Zuora received the response.  | [optional] 
**Request** | **string** | The request parameters when sending the request.  | [optional] 
**Response** | **string** | The response body of the received response.  | [optional] 
**ResponseCode** | **string** | The code associated with the response. The value can be &#x60;Success&#x60;, &#x60;Failure&#x60;, or &#x60;Error&#x60;.  | [optional] 
**SendTime** | **string** | The time when Zuora sent the request.  | [optional] 
**TenantId** | **string** | The tenant ID of the user requesting the logs.  | [optional] 
**UpdatedBy** | **string** | The ID of the user who last updated the transaction.  | [optional] 
**UpdatedTime** | **string** | The timestamp of logs updated in ISO-8601 format.  | [optional] 
**ZReferenceId** | **string** | The payment or refund Id.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

