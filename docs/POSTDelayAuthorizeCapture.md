# ZuoraClient.Model.POSTDelayAuthorizeCapture

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** | The ID of the customer account. Either &#x60;accountId&#x60; or &#x60;accountNumber&#x60; is required. | [optional] 
**AccountNumber** | **string** | The number of the customer account. Either &#x60;accountNumber&#x60; or &#x60;accountId&#x60; is required. | [optional] 
**Amount** | **decimal** | The amount of the trasaction. | 
**GatewayOptions** | [**CreatePaymentMethodCommonGatewayOptions**](CreatePaymentMethodCommonGatewayOptions.md) |  | [optional] 
**GatewayOrderId** | **string** | The order ID for the specific gateway.  The specified order ID will be used in transaction authorization. If you specify an empty value for this field, Zuora will generate an ID and you will have to associate this ID with your order ID by yourself if needed. It is recommended to specify an ID for this field.  | 
**MitTransactionSource** | **string** | Payment transaction source used to differentiate the transaction source in Stored Credential Transaction framework.   - &#x60;C_Unscheduled&#x60;: Cardholder-initiated transaction (CIT) that does not occur on scheduled or regularly occurring dates.   - &#x60;M_Recurring&#x60;: Merchant-initiated transaction (MIT) that occurs at regular intervals.   - &#x60;M_Unscheduled&#x60;: Merchant-initiated transaction (MIT) that does not occur on scheduled or regularly occurring dates.  | [optional] 
**PaymentGatewayId** | **string** | The ID of the payment gateway instance. | [optional] 
**SoftDescriptor** | **string** | A text, rendered on a cardholder’s statement, describing a particular product or service purchased by the cardholder. | [optional] 
**SoftDescriptorPhone** | **string** | The phone number that relates to the soft descriptor, usually the phone number of customer service. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

