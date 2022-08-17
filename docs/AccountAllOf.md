# ZuoraClient.Model.AccountAllOf
The information of the new account to be created with the order. Note that this actually specifies the invoice owner account of the subscriptions included in this order. To create the new account, either a **creditCard** structure or the **hpmCreditCardPaymentMethodId** field (but not both) should be provided. The one provided becomes the default payment method for this account. If the credit card information is declined or can't be verified, then the account is not created. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountNumber** | **string** |  | [optional] 
**AdditionalEmailAddresses** | **string** | List of additional email addresses to receive emailed invoices. Values should be a comma-separated list of email addresses.  | [optional] 
**AllowInvoiceEdit** | **bool** | Indicates if associated invoices can be edited. Values are:   * &#x60;true&#x60; * &#x60;false&#x60; (default)  | [optional] 
**AutoPay** | **bool** | Specifies whether future payments are to be automatically billed when they are due. Possible values are &#x60;true&#x60;, &#x60;false&#x60;. | [optional] 
**Batch** | **string** |  | [optional] 
**BillCycleDay** | **int** | Day of the month that the account prefers billing periods to begin on. If set to 0, the bill cycle day will be set as \&quot;AutoSet\&quot;. | 
**BillToContact** | [**BillToContactPostOrder**](BillToContactPostOrder.md) |  | 
**CommunicationProfileId** | **string** |  | [optional] 
**CreditCard** | [**CreditCard**](CreditCard.md) |  | [optional] 
**CreditMemoTemplateId** | **string** | **Note:** This field is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  The unique ID of the credit memo template, configured in **Billing Settings** &gt; **Manage Billing Document Configuration** through the Zuora UI. For example, 2c92c08a6246fdf101626b1b3fe0144b.  | [optional] 
**CrmId** | **string** |  | [optional] 
**Currency** | **string** | 3 uppercase character currency code.  For payment method authorization, if the &#x60;paymentMethod&#x60; &gt; &#x60;currencyCode&#x60; field is specified, &#x60;currencyCode&#x60; is used. Otherwise, this &#x60;currency&#x60; field is used for payment method authorization. If no currency is specified for the account, the default currency of the account is then used.  | 
**CustomFields** | **Dictionary&lt;string, Object&gt;** | Container for custom fields of an Account object.  | [optional] 
**CustomerServiceRepName** | **string** | Name of the account&#39;s customer service representative, if applicable.  | [optional] 
**DebitMemoTemplateId** | **string** | **Note:** This field is only available if you have [Invoice Settlement](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement) enabled. The Invoice Settlement feature is generally available as of Zuora Billing Release 296 (March 2021). This feature includes Unapplied Payments, Credit and Debit Memo, and Invoice Item Settlement. If you want to enable Invoice Settlement, see [Invoice Settlement Enablement and Checklist Guide](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/Invoice_Settlement/Invoice_Settlement_Migration_Checklist_and_Guide) for more information.  The unique ID of the debit memo template, configured in **Billing Settings** &gt; **Manage Billing Document Configuration** through the Zuora UI. For example, 2c92c08d62470a8501626b19d24f19e2.  | [optional] 
**HpmCreditCardPaymentMethodId** | **string** | The ID of the payment method associated with this account. The payment method specified for this field will be set as the default payment method of the account.  If the &#x60;autoPay&#x60; field is set to &#x60;true&#x60;, you must provide the credit card payment method ID for either this field or the &#x60;creditCard&#x60; field, but not both.  For the Credit Card Reference Transaction payment method, you can specify the payment method ID in this field or use the &#x60;paymentMethod&#x60; field to create a CC Reference Transaction payment method for an account.  For a specified credit card payment method, it is recommended that [the support for stored credential transactions](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/L_Payment_Methods/Stored_credential_transactions) for this payment method is already enabled.  | [optional] 
**InvoiceDeliveryPrefsEmail** | **bool** | Specifies whether to turn on the invoice delivery method &#39;Email&#39; for the new account.  Values are:   * &#x60;true&#x60; (default). Turn on the invoice delivery method &#39;Email&#39; for the new account. * &#x60;false&#x60;. Turn off the invoice delivery method &#39;Email&#39; for the new account.  | [optional] 
**InvoiceDeliveryPrefsPrint** | **bool** | Specifies whether to turn on the invoice delivery method &#39;Print&#39; for the new account. Values are:   * &#x60;true&#x60;. Turn on the invoice delivery method &#39;Print&#39; for the new account. * &#x60;false&#x60; (default). Turn off the invoice delivery method &#39;Print&#39; for the new account.  | [optional] 
**InvoiceTemplateId** | **string** |  | [optional] 
**Name** | **string** |  | 
**Notes** | **string** |  | [optional] 
**ParentId** | **string** | Identifier of the parent customer account for this Account object. Use this field if you have customer hierarchy enabled. | [optional] 
**PaymentGateway** | **string** |  | [optional] 
**PaymentMethod** | [**PaymentMethod**](PaymentMethod.md) |  | [optional] 
**PaymentTerm** | **string** |  | [optional] 
**PurchaseOrderNumber** | **string** | The number of the purchase order associated with this account. Purchase order information generally comes from customers.  | [optional] 
**SalesRep** | **string** | The name of the sales representative associated with this account, if applicable.  | [optional] 
**SequenceSetId** | **string** | The ID of the billing document sequence set to assign to the customer account.   The billing documents to generate for this account will adopt the prefix and starting document number configured in the sequence set.  | [optional] 
**SoldToContact** | [**SoldToContactPostOrder**](SoldToContactPostOrder.md) |  | [optional] 
**SoldToSameAsBillTo** | **bool** | Whether the sold-to contact and bill-to contact are the same entity.   The created account has the same bill-to contact and sold-to contact entity only when all the following conditions are met in the request body:  - This field is set to &#x60;true&#x60;.  - A bill-to contact is specified. - No sold-to contact is specified.  | [optional] 
**TaxInfo** | [**TaxInfo**](TaxInfo.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

