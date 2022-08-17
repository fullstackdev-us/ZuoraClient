# ZuoraClient.Model.CreateSubscriptionNewSubscriptionOwnerAccount
Information about a new account that will own the subscription. Only available if you have enabled the Owner Transfer feature.  **Note:** The Owner Transfer feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  If you do not set this field or the `subscriptionOwnerAccountNumber` field, the account that owns the order will also own the subscription. Zuora will return an error if you set this field and the `subscriptionOwnerAccountNumber` field. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountNumber** | **string** | Account number. For example, A00000001.  | [optional] 
**AutoPay** | **bool** | Specifies whether future payments are automatically billed when they are due.  | [optional] 
**Batch** | **string** | Name of the billing batch that the account belongs to. For example, Batch1.  | [optional] 
**BillCycleDay** | **int** | Day of the month that the account prefers billing periods to begin on. If set to 0, the bill cycle day will be set as \&quot;AutoSet\&quot;.  | 
**BillToContact** | [**BillToContact**](BillToContact.md) |  | 
**CommunicationProfileId** | **string** | Internal identifier of the communication profile that Zuora uses when sending notifications to the account&#39;s contacts.  | [optional] 
**CreditCard** | [**CreditCard**](CreditCard.md) |  | [optional] 
**CrmId** | **string** | External identifier of the account in a CRM system.  | [optional] 
**Currency** | **string** | ISO 3-letter currency code (uppercase). For example, USD.  | 
**CustomFields** | **Dictionary&lt;string, Object&gt;** | Container for custom fields of an Account object.  | [optional] 
**HpmCreditCardPaymentMethodId** | **string** | The ID of the payment method associated with this account. The payment method specified for this field will be set as the default payment method of the account.  If the &#x60;autoPay&#x60; field is set to &#x60;true&#x60;, you must provide the credit card payment method ID for either this field or the &#x60;creditCard&#x60; field, but not both.  For the Credit Card Reference Transaction payment method, you can specify the payment method ID in this field or use the &#x60;paymentMethod&#x60; field to create a CC Reference Transaction payment method for an account.  For a specified credit card payment method, it is recommended that [the support for stored credential transactions](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Stored_credential_transactions) for this payment method is already enabled.  | [optional] 
**InvoiceDeliveryPrefsEmail** | **bool** | Specifies whether to turn on the invoice delivery method &#39;Email&#39; for the new account.  Values are:   * &#x60;true&#x60; (default). Turn on the invoice delivery method &#39;Email&#39; for the new account. * &#x60;false&#x60;. Turn off the invoice delivery method &#39;Email&#39; for the new account.           | [optional] 
**InvoiceDeliveryPrefsPrint** | **bool** | Specifies whether to turn on the invoice delivery method &#39;Print&#39; for the new account. Values are:   * &#x60;true&#x60;. Turn on the invoice delivery method &#39;Print&#39; for the new account. * &#x60;false&#x60; (default). Turn off the invoice delivery method &#39;Print&#39; for the new account.  | [optional] 
**InvoiceTemplateId** | **string** | Internal identifier of the invoice template that Zuora uses when generating invoices for the account.  | [optional] 
**Name** | **string** | Account name.  | 
**Notes** | **string** | Notes about the account. These notes are only visible to Zuora users.  | [optional] 
**ParentId** | **string** | Identifier of the parent customer account for this Account object. Use this field if you have customer hierarchy enabled. | [optional] 
**PaymentGateway** | **string** | The payment gateway that Zuora uses when processing electronic payments and refunds for the account. If you do not specify this field or if the value of this field is null, Zuora uses your default payment gateway.  | [optional] 
**PaymentMethod** | [**PaymentMethod**](PaymentMethod.md) |  | [optional] 
**PaymentTerm** | **string** | Name of the payment term associated with the account. For example, \&quot;Net 30\&quot;. The payment term determines the due dates of invoices.  | [optional] 
**SoldToContact** | [**SoldToContact**](SoldToContact.md) |  | [optional] 
**TaxInfo** | [**TaxInfo**](TaxInfo.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

