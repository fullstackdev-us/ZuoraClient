# ZuoraClient.Model.SubscribeRequestPreviewOptions
Only used if you want to call this operation in preview mode. After a call in preview mode is completed, Zuora will roll back the subscription and return only the temporary invoice data. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EnablePreviewMode** | **bool** | Specifies whether the call should create a subscription/amendment, or whether it should return a preview of the order. Used with either NumberOfPeriods or PreviewThroughTermEnd.   If the preview mode is enabled, Zuora recommends that you set the &#x60;subscribes&#x60; &gt; &#x60;SubscribeOptions&#x60; &gt; &#x60;ProcessPayments&#x60; field to &#x60;false&#x60; and skip setting the &#x60;subscribes&#x60; &gt; &#x60;PaymentMethod&#x60; field in your request so that no charge occurs for payment method validation in a preview.  | [optional] 
**NumberOfPeriods** | **int** | The number of invoice periods to show in a preview.  | [optional] 
**PreviewThroughTermEnd** | **bool** | Specifies whether to preview the charge through the end of the subscription term. Applicable to termed subscriptions only.  | [optional] 
**PreviewType** | **string** | The type of preview to return:   * &#x60;InvoiceItem&#x60; - Return an invoice item preview  * &#x60;ChargeMetrics&#x60; - Return a charge metrics preview  * &#x60;InvoiceItemChargeMetrics&#x60; - Return an invoice item and charge metrics of that item  | [optional] [default to PreviewTypeEnum.InvoiceItem]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

