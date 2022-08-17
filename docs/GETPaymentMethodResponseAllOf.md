# ZuoraClient.Model.GETPaymentMethodResponseAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountHolderInfo** | [**GETPMAccountHolderInfo**](GETPMAccountHolderInfo.md) |  | [optional] 
**BankIdentificationNumber** | **string** | The first six or eight digits of the payment method&#39;s number, such as the credit card number or account number. Banks use this number to identify a payment method.  | [optional] 
**CreatedBy** | **string** | ID of the user who created this payment method. | [optional] 
**CreatedOn** | **DateTime** | The date and time when the payment method was created, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**CreditCardMaskNumber** | **string** | The masked credit card number, such as: &#x60;&#x60;&#x60; *********1112 &#x60;&#x60;&#x60; **Note:** This field is only returned for Credit Card Reference Transaction payment type.  | [optional] 
**CreditCardType** | **string** | The type of the credit card or debit card.  Possible values include &#x60;Visa&#x60;, &#x60;MasterCard&#x60;, &#x60;AmericanExpress&#x60;, &#x60;Discover&#x60;, &#x60;JCB&#x60;, and &#x60;Diners&#x60;. For more information about credit card types supported by different payment gateways, see [Supported Payment Gateways](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways).  **Note:** This field is only returned for the Credit Card and Debit Card payment types.  | [optional] 
**DeviceSessionId** | **string** | The session ID of the user when the &#x60;PaymentMethod&#x60; was created or updated.  | [optional] 
**ExistingMandate** | **string** | Indicates whether the mandate is an existing mandate.  | [optional] 
**Id** | **string** | The payment method ID.  | [optional] 
**IpAddress** | **string** | The IP address of the user when the payment method was created or updated.  | [optional] 
**IsDefault** | **bool** | Indicates whether this payment method is the default payment method for the account.  | [optional] 
**LastFailedSaleTransactionDate** | **DateTime** | The date of the last failed attempt to collect payment with this payment method.  | [optional] 
**LastTransaction** | **string** | ID of the last transaction of this payment method. | [optional] 
**LastTransactionTime** | **DateTime** | The time when the last transaction of this payment method happened. | [optional] 
**MandateInfo** | [**POSTPMMandateInfo**](POSTPMMandateInfo.md) |  | [optional] 
**MaxConsecutivePaymentFailures** | **int** | The number of allowable consecutive failures Zuora attempts with the payment method before stopping.  | [optional] 
**NumConsecutiveFailures** | **int** | The number of consecutive failed payments for this payment method. It is reset to &#x60;0&#x60; upon successful payment.   | [optional] 
**PaymentRetryWindow** | **int** | The retry interval setting, which prevents making a payment attempt if the last failed attempt was within the last specified number of hours.  | [optional] 
**SecondTokenId** | **string** | A gateway unique identifier that replaces sensitive payment method data.  **Note:** This field is only returned for the Credit Card Reference Transaction payment type.  | [optional] 
**Status** | **string** | The status of the payment method.  | [optional] 
**TokenId** | **string** | A gateway unique identifier that replaces sensitive payment method data or represents a gateway&#39;s unique customer profile.  **Note:** This field is only returned for the Credit Card Reference Transaction payment type.  | [optional] 
**TotalNumberOfErrorPayments** | **int** | The number of error payments that used this payment method.  | [optional] 
**TotalNumberOfProcessedPayments** | **int** | The number of successful payments that used this payment method.  | [optional] 
**Type** | **string** | The type of the payment method. For example, &#x60;CreditCard&#x60;.  | [optional] 
**UpdatedBy** | **string** | ID of the user who made the last update to this payment method. | [optional] 
**UpdatedOn** | **DateTime** | The last date and time when the payment method was updated, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format.  | [optional] 
**UseDefaultRetryRule** | **bool** | Indicates whether this payment method uses the default retry rules configured in the Zuora Payments settings.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

