# ZuoraClient.Model.DebitMemosFromInvoices

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**SourceType** | **string** | The type of the source where debit memos are created.   This enum field has the following values: - &#x60;Invoice&#x60;: By setting this field to &#x60;Invoice&#x60;, you can create multiple debit memos from invoices. - &#x60;Standalone&#x60;: By setting this field to &#x60;Standalone&#x60;, you can create multiple debit memos from product rate plan charges.  The specific schema of the &#x60;memos&#x60; object field in the request body depends on the value of the &#x60;sourceType&#x60; field. - To view the &#x60;memos&#x60; schema if you set the &#x60;sourceType&#x60; field to &#x60;Invoice&#x60;, select &#x60;DebitMemosFromInvoices&#x60; from the following drop-down list. - To view the &#x60;memos&#x60; schema if you set the &#x60;sourceType&#x60; field to &#x60;Standalone&#x60;, select &#x60;DebitMemosFromCharges&#x60; from the following drop-down list.  | 
**Memos** | [**List&lt;POSTBulkDebitMemoFromInvoiceType&gt;**](POSTBulkDebitMemoFromInvoiceType.md) | The container for a list of debit memos. The maximum number of debit memos is 50.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

