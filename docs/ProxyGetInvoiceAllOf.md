# ZuoraClient.Model.ProxyGetInvoiceAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** |  | [optional] 
**AdjustmentAmount** | **double** |  The amount of the invoice adjustments associated with the invoice. **Character limi**t: 16 **Values**: a valid currency amount  | [optional] 
**Amount** | **double** |  The sum of all charges and taxes associated with the invoice. **Character limit**: 16 **Values**: automatically generated  | [optional] 
**AmountWithoutTax** | **double** |  The sum of all charges associated with the invoice. Taxes are excluded from this value. **Character limit**: 16 **Values**: automatically generated  | [optional] 
**Balance** | **double** |  The remaining balance of the invoice after all payments, adjustments, and refunds are applied. **Character limit**: 16 **Values**: automatically generated  | [optional] 
**BillToContactId** | **string** | The ID of bill-to contact associated with the invoice.   **Note**: This field is available only if you set the &#x60;X-Zuora-WSDL-Version&#x60; request header to &#x60;118&#x60; or later. The value of this field is &#x60;null&#x60; if you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled.  | [optional] 
**Body** | **string** |  Required  | [optional] 
**Comments** | **string** |  Additional information related to the invoice that a Zuora user added to the invoice. **Character limit**: 255 **Values:** a string of 255 characters or fewer  | [optional] 
**CreatedById** | **string** |  The user ID of the person who created the invoice. If a bill run generated the invoice, then the value is the user ID of person who created the bill run. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**CreatedDate** | **DateTime** |  The date when the invoice was generated. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**CreditBalanceAdjustmentAmount** | **double** |  The currency amount of the adjustment applied to the customer&#39;s credit balance. **Character limit**: 16 **Values**: a valid currency amount This field is only available if the [Zuora Global Support](http://support.zuora.com/) to enable this feature.    | [optional] 
**DueDate** | **DateTime** |  The date by which the payment for this invoice is due. **Character limit**: 29 **Version notes**: - -  | [optional] 
**Id** | **string** | Object identifier. | [optional] 
**IncludesOneTime** | **bool** | Whether the bill run picks up all one-time charges for processing. You can use this field only with the Generate call for the Invoice object.  | [optional] [default to true]
**IncludesRecurring** | **bool** | Whether the bill run picks up all recurring charges for processing. You can use this field only with the Generate call for the Invoice object.  | [optional] [default to true]
**IncludesUsage** | **bool** | Whether the bill run picks up all usage charges for processing. You can use this field only with the Generate call for the Invoice object.  | [optional] [default to true]
**InvoiceDate** | **DateTime** |  Specifies the date on which to generate the invoice. **Character limit**: 29 **Version notes**: - -  | [optional] 
**InvoiceNumber** | **string** |  The unique identification number for the invoice. This number is returned as a string. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**LastEmailSentDate** | **DateTime** |  The date when the invoice was last emailed. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**PaymentAmount** | **double** |  The amount of payments applied to the invoice. **Character limit**: 16 **Value**s: automatically generated  | [optional] 
**PaymentTerm** | **string** | The name of payment term associated with the invoice.  **Note**: This field is available only if you set the &#x60;X-Zuora-WSDL-Version&#x60; request header to &#x60;118&#x60; or later. The value of this field is &#x60;null&#x60; if you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled.  | [optional] 
**PostedBy** | **string** |  The user ID of the person who moved the invoice to Posted status. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**PostedDate** | **DateTime** |  The date when the invoice was posted. **Character limit:** 29 **Values**: automatically generated  | [optional] 
**RefundAmount** | **double** |  Specifies the amount of a refund that was applied against an earlier payment on the invoice. **Character limit**: 16 **Values**: automatically generated  | [optional] 
**SourceType** | **string** |  The type of the invoice source. **Note**: To use this field, you must set the &#x60;X-Zuora-WSDL-Version&#x60; request header to &#x60;118&#x60; or later. Otherwise, an error occurs. **Character limit**: 16 **Values**: one of the following enum values:  -  Subscription  -  Standalone  -  Order  -  Consolidation  | [optional] 
**Status** | **string** |  The status of the invoice in the system. This status is not the status of the payment of the invoice, just the status of the invoice itself. **Character limit**: 8 **Values**: one of the following:  -  Draft (default, automatically set upon invoice creation)  -  Posted  -  Canceled   | [optional] 
**TargetDate** | **DateTime** |  This date is used to determine which charges are to be billed. All charges that are to be billed on this date or prior will be included in this bill run. **Character limit**: 29 **Version notes**: - -  | [optional] 
**TaxAmount** | **double** |  The total amount of the taxes applied to the invoice. **Character limit**: 16 **Values**: automatically generated  | [optional] 
**TaxExemptAmount** | **double** |  The total amount of the invoice that is exempt from taxation. **Character limit**: 16 **Values**: automatically generated  | [optional] 
**TransferredToAccounting** | **string** |  Specifies whether or not the invoice was transferred to an external accounting system, such as NetSuite. **Character limit**: 10 **Values**: Processing, Yes, Error, Ignore  | [optional] 
**UpdatedById** | **string** |  | [optional] 
**UpdatedDate** | **DateTime** |  The date when the invoice was last updated. **Character limit**: 29 **Values**: automatically generated  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

