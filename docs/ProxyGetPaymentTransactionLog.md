# ZuoraClient.Model.ProxyGetPaymentTransactionLog

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AVSResponseCode** | **string** | The response code returned by the payment gateway referring to the AVS international response of the payment transaction.  | [optional] 
**BatchId** | **string** | The ID of the batch used to send the transaction if the request was sent in a batch.  | [optional] 
**CVVResponseCode** | **string** | The response code returned by the payment gateway referring to the CVV international response of the payment transaction.  | [optional] 
**Gateway** | **string** | The name of the payment gateway used to transact the current payment transaction log.  | [optional] 
**GatewayReasonCode** | **string** | The code returned by the payment gateway for the payment. This code is gateway-dependent.  | [optional] 
**GatewayReasonCodeDescription** | **string** | The message returned by the payment gateway for the payment. This message is gateway-dependent.   | [optional] 
**GatewayState** | **string** | The state of the transaction at the payment gateway.  | [optional] 
**GatewayTransactionType** | **string** | The type of the transaction, either making a payment, or canceling a payment.   | [optional] 
**Id** | **string** | The ID of the payment transaction log.  | [optional] 
**PaymentId** | **string** | The ID of the payment wherein the payment transaction log was recorded.   | [optional] 
**RequestString** | **string** | The payment transaction request string sent to the payment gateway.   | [optional] 
**ResponseString** | **string** | The payment transaction response string returned by the payment gateway.   | [optional] 
**TransactionDate** | **DateTime** | The transaction date when the payment was performed.   | [optional] 
**TransactionId** | **string** | The transaction ID returned by the payment gateway. This field is used to reconcile payment transactions between the payment gateway and records in Zuora.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

