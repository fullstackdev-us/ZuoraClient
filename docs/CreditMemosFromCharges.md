# ZuoraClient.Model.CreditMemosFromCharges

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**SourceType** | **string** | The type of the source where credit memos are created.   This enum field has the following values: - &#x60;Invoice&#x60;: By setting this field to &#x60;Invoice&#x60;, you can create multiple credit memos from invoices. - &#x60;Standalone&#x60;: By setting this field to &#x60;Standalone&#x60;, you can create multiple credit memos from product rate plan charges.  The specific schema of the &#x60;memos&#x60; object field in the request body depends on the value of the &#x60;sourceType&#x60; field. - To view the &#x60;memos&#x60; schema if you set the &#x60;sourceType&#x60; field to &#x60;Invoice&#x60;, select &#x60;CreditMemosFromInvoices&#x60; from the following drop-down list. - To view the &#x60;memos&#x60; schema if you set the &#x60;sourceType&#x60; field to &#x60;Standalone&#x60;, select &#x60;CreditMemosFromCharges&#x60; from the following drop-down list.  | 
**Memos** | [**List&lt;CreditMemoFromChargeType&gt;**](CreditMemoFromChargeType.md) | The container for a list of credit memos. The maximum number of credit memos is 50.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

