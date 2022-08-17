# ZuoraClient.Model.ProxyGetInvoiceItemAdjustmentAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** |  The ID of the account that owns the invoice. **Values**: inherited from &#x60;Account.ID&#x60; for the invoice owner  | [optional] 
**AccountingCode** | **string** |  The accounting code for the invoice item. Accounting codes group transactions that contain similar accounting attributes. **Character limit**: 100 **Values**: inherited from &#x60;InvoiceItem.AccountingCode&#x60;  | [optional] 
**AdjustmentDate** | **DateTime** |  The date when the invoice item adjustment is applied, in &#x60;yyyy-mm-dd&#x60; format. This date must be the same as the invoice&#39;s date or later. **Character limit**: 29  | [optional] 
**AdjustmentNumber** | **string** |  A unique string to identify an individual invoice item adjustment. **Character limit**: 255 **Values**: automatically generated  | [optional] 
**Amount** | **double** |  The amount of the invoice item adjustment. The value of Amount must be positive. Use the required parameter Type to either credit or charge (debit) this amount on the invoice. **Character limit**: 16 **Values**: a valid currency amount  | [optional] 
**CancelledById** | **string** |  The ID of the Zuora user who canceled the invoice item adjustment. Zuora generates this read-only field only if the adjustment is canceled. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**CancelledDate** | **DateTime** |  The date when the invoice item adjustment is canceled. Zuora generates this read-only field if this adjustment is canceled. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**Comment** | **string** |  Use this field to record comments about the invoice item adjustment. **Character limit**: 255 **Values**: a string of 255 characters or fewer  | [optional] 
**CreatedById** | **string** |  The user ID of the person who created the invoice item. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**CreatedDate** | **DateTime** |  The date the invoice item was created. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**CustomerName** | **string** |  The name of the account that owns the associated invoice.  **Character limit**: 50  **Values**: inherited from &#x60;Account.Name&#x60;  **Note**: This value changes if &#x60;Account.Name&#x60; is updated. The values of &#x60;UpdatedById&#x60; and &#x60;UpdatedDate&#x60; for the &#x60;InvoiceItemAdjustment&#x60; do not change when &#x60;Account.Name&#x60; is updated.  | [optional] 
**CustomerNumber** | **string** |  The unique account number of the customer&#39;s account.  **Character limit**: 50  **Values**: inherited from &#x60;Account.AccountNumber&#x60;  **Note**: This value changes if &#x60;Account.AccountNumber&#x60; is updated. The values of &#x60;UpdatedById&#x60; and &#x60;UpdatedDate&#x60; for the &#x60;InvoiceItemAdjustment&#x60; do not change when &#x60;Account.AccountNumber&#x60; is updated.  | [optional] 
**DeferredRevenueAccount** | **string** |  Records the deferred accounting code in the finance system. This field is in Limited Availability. If you want to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/). **Character limit**: 100  **Version notes**: WSDL 63.0+  **Values**: If this field is not passed in, a value from InvoiceItem will be used. | [optional] 
**ExcludeItemBillingFromRevenueAccounting** | **bool** | The flag to exclude Order Line Item related invoice items, invoice item adjustments, credit memo items, and debit memo items that are generate for the rate plan charge from revenue accounting.  **Version notes**: WSDL 117.0+  **Values**: boolean value  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  | [optional] [default to false]
**Id** | **string** | Object identifier. | [optional] 
**InvoiceId** | **string** |  The ID of the invoice associated with the adjustment. The adjustment invoice item is in this invoice. This field is optional if you specify a value for the &#x60;InvoiceNumber&#x60; field. **Character limit**: 3 **Values**: a valid invoice ID  | [optional] 
**InvoiceItemName** | **string** |  The name of the invoice item&#39;s charge. This field is required in the Query call, but is inherited in other calls. **Character limit**: 255 **Values**: inherited from &#x60;InvoiceItem.ChargeName&#x60;  | [optional] 
**InvoiceNumber** | **string** |  The unique identification number for the invoice that contains the invoice item. This field is optional if you specify a value for the &#x60;InvoiceId&#x60; field. **Character limit**: 32 **Values**: a valid invoice number  | [optional] 
**ReasonCode** | **string** |  A code identifying the reason for the transaction. Must be an existing reason code or empty. If you do not specify a value, Zuora uses the default reason code. **Character limit**: 32 **Values**: a valid reason code  | [optional] 
**RecognizedRevenueAccount** | **string** |  Records the recognized accounting code in the finance system. This field is in Limited Availability. If you want to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/). **Character limit**: 100  **Version notes**: WSDL 63.0+  **Values**: If this field is not passed in, a value from InvoiceItem will be used. | [optional] 
**ReferenceId** | **string** |  A code to reference an object external to Zuora. For example, you can use this field to reference a case number in an external system. **Character limit**: 60 **Values**: a string of 60 characters or fewer  | [optional] 
**ServiceEndDate** | **DateTime** |  The end date of the service period associated with the invoice item. Service ends one second before the date in this value.  **Character limit**: 29  | [optional] 
**ServiceStartDate** | **DateTime** |  The start date of the service period associated with the invoice item. Service ends one second before the date in this value.  **Character limit**: 29  | [optional] 
**SourceId** | **string** |  The ID of the item specified in the SourceType field. **Character limit**: 32 **Values**: a valid invoice item ID or taxation item ID  | [optional] 
**SourceType** | **string** |  The type of adjustment. **Character limit**: 13 **Values**: InvoiceDetail, Tax  | [optional] 
**Status** | **string** |  The status of the invoice item adjustment. This field is required in the Query call, but is automatically generated in other calls. **Character limit**: 9 **Values**: Canceled, Processed  | [optional] 
**TransferredToAccounting** | **string** | Indicates the status of the adjustment&#39;s transfer to an external accounting system, such as NetSuite.  | [optional] 
**Type** | **string** | Indicates whether the adjustment credits or debits the invoice item amount. | [optional] 
**UpdatedById** | **string** |  The ID of the user who last updated the invoice item. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**UpdatedDate** | **DateTime** |  The date when the invoice item was last updated. **Character limit**: 29 **Values**: automatically generated  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

