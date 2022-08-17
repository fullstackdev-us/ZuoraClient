# ZuoraClient.Model.ProxyCreateProductRatePlanAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ActiveCurrencies** | **List&lt;string&gt;** | A list of 3-letter currency codes representing active currencies for the product rate plan. Use a comma to separate each currency code.  When creating a product rate plan, you can use this field to specify at most four active currencies.   | [optional] 
**Description** | **string** | A description of the product rate plan. **Character limit**: 500 **Values**: a string of 500 characters or fewer  | [optional] 
**EffectiveEndDate** | **DateTime** |  The date when the product rate plan expires and can&#39;t be subscribed to, in &#x60;yyyy-mm-dd&#x60; format. **Character limit**: 29  | [optional] 
**EffectiveStartDate** | **DateTime** |  The date when the product rate plan becomes available and can be subscribed to, in &#x60;yyyy-mm-dd&#x60; format. **Character limit**: 29  | [optional] 
**Grade** | **decimal** | The grade that is assigned for the product rate plan. The value of this field must be a positive integer. The greater the value, the higher the grade.  A product rate plan to be added to a Grading catalog group must have one grade. You can specify a grade for a product rate plan in this request or update the product rate plan indvidually.  **Note**: To use this field, you must set the &#x60;X-Zuora-WSDL-Version&#x60; request header to &#x60;116&#x60; or later. Otherwise, an error occurs.  **Note**: This field is in the **Early Adopter** phase. We are actively soliciting feedback from a small set of early adopters before releasing it as generally available. If you want to join this early adopter program, submit a request at [Zuora Global Support](http://support.zuora.com/).  | [optional] 
**Name** | **string** | The name of the product rate plan. The name doesn&#39;t have to be unique in a Product Catalog, but the name has to be unique within a product. **Character limit**: 100 **Values**: a string of 100 characters or fewer  | 
**ProductId** | **string** | The ID of the product that contains the product rate plan. **Character limit**: 32 **Values**: a string of 32 characters or fewer  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

