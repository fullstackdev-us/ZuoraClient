# ZuoraClient.Model.OrderItem
Represents an order item. An order item is a sales item within an order in the context of the recurring subscription business model. It can be a unit of products or a service, but defined by both quantity and term (the start and end dates).   For the one time and the recurring charge types, if an order action causes a quantity metric creation (when the delta quantity equals to or is greater than zero), an order item is created.  The following order actions will create an order item for the one time and recurring charges. The other order actions will refer to an existing order item. Also, the Owner Transfer order action always creates an order item whose quantity field is zero.    * Create Subscription   * Terms and Conditions - Extend Term   * Renewal   * Update Product - Increase Quantity   * Add product   * Owner Transfer  For the usage charge type, if the order action causes a usage increase, an order item is created, and the quantity field of the order item is always zero.  The following order actions will create an order item for for the usage charges.    * Create Subscription   * Terms and Conditions - Extend Term   * Renewal   * Add product   * Owner Transfer 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EndDate** | **DateTime** | The order item&#39;s effective end date, aligned with the end date of an increased quantity order metrics. | [optional] 
**Id** | **string** | The ID of the order item. | [optional] 
**OrderActionId** | **string** | Specify the order action that creates this order item. | [optional] 
**Quantity** | **decimal** | The order item quantity. For the usage charge type, the value of this field is always zero. Also, the Owner Transfer order action always creates an order item whose Quantity field is zero. | [optional] 
**ScId** | **string** | The ID of the charge segment that gets newly generated when the order item is created. | [optional] 
**StartDate** | **DateTime** | The order item&#39;s effective start date, aligned with the start date of an increased quantity order metrics. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

