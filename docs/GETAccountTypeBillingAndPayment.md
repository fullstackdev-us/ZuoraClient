# ZuoraClient.Model.GETAccountTypeBillingAndPayment
Container for billing and payment information for the account. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AdditionalEmailAddresses** | **List&lt;string&gt;** | A list of additional email addresses to receive email notifications.  | [optional] 
**BillCycleDay** | **string** | Billing cycle day (BCD), the day of the month when a bill run generates invoices for the account.  | [optional] 
**Currency** | **string** | A currency defined in the web-based UI administrative settings.  | [optional] 
**DefaultPaymentMethodId** | **string** | ID of the default payment method for the account.  | [optional] 
**InvoiceDeliveryPrefsEmail** | **bool** | Whether the customer wants to receive invoices through email.   | [optional] 
**InvoiceDeliveryPrefsPrint** | **bool** | Whether the customer wants to receive printed invoices, such as through postal mail.  | [optional] 
**PaymentGateway** | **string** | The name of the payment gateway instance. If null or left unassigned, the Account will use the Default Gateway.  | [optional] 
**PaymentTerm** | **string** | A payment-terms indicator defined in the web-based UI administrative settings, e.g., \&quot;Net 30\&quot;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

