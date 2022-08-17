# ZuoraClient.Model.GETPaymentMethodType

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CardHolderInfo** | [**GETPaymentMethodTypeCardHolderInfo**](GETPaymentMethodTypeCardHolderInfo.md) |  | [optional] 
**CardNumber** | **string** | Credit or debit card number, 16 characters or less, masked for security purposes.  | [optional] 
**CardType** | **string** | The type of the credit card.      Possible values  include &#x60;Visa&#x60;, &#x60;MasterCard&#x60;, &#x60;AmericanExpress&#x60;, &#x60;Discover&#x60;, &#x60;JCB&#x60;, and &#x60;Diners&#x60;. For more information about credit card types supported by different payment gateways, see [Supported Payment Gateways](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways).  | [optional] 
**DefaultPaymentMethod** | **bool** | Contains true if this is the default payment method for this customer, otherwise false.  | [optional] 
**ExpirationMonth** | **int** | One or two digit(s) expiration month (1-12).  | [optional] 
**ExpirationYear** | **int** | Four-digit expiration year.  | [optional] 
**Id** | **string** | Unique ID generated by Zuora when this payment method was created.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
