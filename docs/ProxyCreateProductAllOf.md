# ZuoraClient.Model.ProxyCreateProductAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AllowFeatureChanges** | **bool** |  Controls whether to allow your users to add or remove features while creating or amending a subscription. **Character** **limit**: n/a **Values**: true, false (default)  | [optional] 
**Category** | **string** |  Category of the product. Used by Zuora Quotes Guided Product Selector. **Character** **limit**: 100 **Values**: One of the following:  - Base Products - Add On Services - Miscellaneous Products  | [optional] 
**Description** | **string** |  A descriptionof the product. **Character limit**: 500 **Values**: a string of 500 characters or fewer  | [optional] 
**EffectiveEndDate** | **DateTime** | The date when the product expires and can&#39;t be subscribed to anymore, in &#x60;yyyy-mm-dd&#x60; format.  | 
**EffectiveStartDate** | **DateTime** | The date when the product becomes available and can be subscribed to, in &#x60;yyyy-mm-dd&#x60; format.  | 
**Name** | **string** | The name of the product. This information is displayed in the product catalog pages in the web-based UI. **Character limit**: 100 **Values**: a string of 100 characters or fewer  | 
**SKU** | **string** | The unique SKU for the product. **Character limit**: 50 **Values**: one of the following:  - leave null for automatic generated - an alphanumeric string of 50 characters or fewer  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

