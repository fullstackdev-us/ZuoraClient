# ZuoraClient.Model.ProxyGetInvoiceAdjustmentAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountId** | **string** |  The ID of the account that owns the invoice. **Character limit**: 32 **Values**: inherited from Account.ID for the invoice owner  | [optional] 
**AccountingCode** | **string** | The accounting code for the invoice adjustment.  | [optional] 
**AdjustmentDate** | **DateTime** |  The date when the invoice adjustment is applied. This date must be the same as the invoice&#39;s date or later. **Character limit**: 29 **Values**: Leave null to automatically generate the current date  | [optional] 
**AdjustmentNumber** | **string** |  A unique string to identify an individual invoice adjustment. **Character limit**: 255 **Values**: automatically generated  | [optional] 
**Amount** | **double** |  The amount of the invoice adjustment. **Character limit**: 16 **Values**: a valid currency amount  | [optional] 
**CancelledById** | **string** |  The ID of the Zuora user who canceled the invoice adjustment. Zuora generates this read-only field only if the adjustment is canceled. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**CancelledOn** | **DateTime** |  The date when the invoice adjustment is canceled. Zuora generates this read-only field if this adjustment is canceled. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**Comments** | **string** |  Use this field to record comments about the invoice adjustment. **Character limit**: 255 **Values**: a string of 255 characters or fewer  | [optional] 
**CreatedById** | **string** |  The user ID of the person who created the invoice adjustment. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**CreatedDate** | **DateTime** |  The date the invoice adjustment was created. **Character limit**: 29 **Values**: automatically generated  | [optional] 
**CustomerName** | **string** |  The name of the account that owns the associated invoice.  **Character limit**: 50  **Values**: inherited from &#x60;Account.Name&#x60;  **Note**: This value changes if &#x60;Account.Name&#x60; is updated. The values of &#x60;UpdatedById&#x60; and &#x60;UpdatedDate&#x60; for the &#x60;InvoiceAdjustment&#x60; do not change when &#x60;Account.Name&#x60; is updated.  | [optional] 
**CustomerNumber** | **string** |  The unique account number of the customer&#39;s account.  **Character limit**: 70  **Values**: inherited from &#x60;Account.AccountNumber&#x60;  **Note**: This value changes if &#x60;Account.AccountNumber&#x60; is updated. The values of &#x60;UpdatedById&#x60; and &#x60;UpdatedDate&#x60; for the &#x60;InvoiceAdjustment&#x60; do not change when &#x60;Account.AccountNumber&#x60; is updated.  | [optional] 
**Id** | **string** | Object identifier. | [optional] 
**ImpactAmount** | **double** |  The amount that changes the balance of the associated invoice. **Character limit**: 16 **Values**: automatically calculated  | [optional] 
**InvoiceId** | **string** |  The ID of the invoice associated with the adjustment. This field is required if you don&#39;t specify a value for the &#x60;InvoiceNumber&#x60; field. **Character limit**: 32 **Values**: a valid invoice ID  | [optional] 
**InvoiceNumber** | **string** |  The unique identification number for the associated invoice. This field is required if you don&#39;t specify a value for the &#x60;InvoiceId&#x60; field. **Character limit**: 32 **Values**: a valid invoice number  | [optional] 
**ReasonCode** | **string** |  A code identifying the reason for the transaction. Must be an existing reason code or empty. If you do not specify a value, Zuora uses the default reason code. **Character limit**: 32 **V****alues**: a valid reason code  | [optional] 
**ReferenceId** | **string** |  A code to reference an object external to Zuora. For example, you can use this field to reference a case number in an external system. **Character limit**: 60 **Values**: a string of 60 characters or fewer  | [optional] 
**Status** | **string** |  The status of the invoice adjustment. This field is required in the Query call, but is automatically generated in other calls. **Character limit**: 9 **Values**: &#x60;Canceled&#x60;, &#x60;Processed&#x60;  | [optional] 
**TransferredToAccounting** | **string** | Indicates the status of the adjustment&#39;s transfer to an external accounting system, such as NetSuite.  | [optional] 
**Type** | **string** |  Indicates whether the adjustment credits or debits the invoice amount. **Character limit**: 6 **Values**: &#x60;Credit&#x60;, &#x60;Charge&#x60;  | [optional] 
**UpdatedById** | **string** |  The ID of the user who last updated the invoice. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**UpdatedDate** | **DateTime** |  The date when the invoice was last updated. **Character limit**: 29 **Values**: automatically generated  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

