# ZuoraClient.Model.ProxyGetInvoiceSplitItem

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedById** | **string** |  The ID of the Zuora user who created the InvoiceSplitItem object. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**CreatedDate** | **DateTime** |  The date when the InvoiceSplitItem was created. **Values**: automatically generated  | [optional] 
**Id** | **string** | Object identifier. | [optional] 
**InvoiceDate** | **DateTime** |  The generation date of the new split invoice, in &#x60;yyyy-mm-dd&#x60; format. **Character limit**: 29  | [optional] 
**InvoiceId** | **string** |  The new invoice after the split. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**InvoiceSplitId** | **string** |  The ID of the invoice split associated with the individual invoice split item. **Character limit**: 32 **Values**: a valid invoice split ID  | [optional] 
**PaymentTerm** | **string** |  Indicates when the customer pays the split invoice. **Values**: a valid, active payment term  | [optional] 
**SplitPercentage** | **double** |  Specifies the percentage of the original invoice that you want to be the balance of the split invoice. The total of the SplitPercentage field values for all of the InvoiceSplitItem objects in an InvoiceSplit object must equal 100. **Values**:  | [optional] 
**UpdatedById** | **string** |  The ID of the Zuora user who last updated the invoice split. **Character limit**: 32 **Values**: automatically generated  | [optional] 
**UpdatedDate** | **DateTime** |  The date when the invoice split was last updated. **Values**: automatically generated  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

