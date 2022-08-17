# ZuoraClient.Model.SubmitDataQueryRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ColumnSeparator** | **string** | The column separator. Only applicable if the &#x60;outputFormat&#x60; is &#x60;DSV&#x60;.  | [optional] 
**Compression** | **string** | Specifies whether Zuora compresses the query results.  | 
**EncryptionKey** | **byte[]** | Base-64 encoded public key of an RSA key-pair.   Note that Data Query only supports 1024-bit RSA keys.  If you set this field, Zuora encrypts the query results using the provided public key. You must use the corresponding private key to decrypt the query results.  | [optional] 
**Output** | [**SubmitDataQueryRequestOutput**](SubmitDataQueryRequestOutput.md) |  | 
**OutputFormat** | **string** | Specifies the format of the query results.  * &#x60;JSON&#x60; - Each row in the query results will be a JSON object. The format of the query result file is [JSON Lines](http://jsonlines.org/). * &#x60;CSV&#x60; - Each row in the query results will be a comma-separated list of values. * &#x60;TSV&#x60; - Each row in the query results will be a tab-separated list of values. * &#x60;DSV&#x60; - Pass any character as your custom delimiter into the &#x60;columnSeparator&#x60; field.  | 
**Query** | **string** | The query to perform. See [SQL Queries in Data Query](https://knowledgecenter.zuora.com/DC_Developers/BA_Data_Query/BA_SQL_Queries_in_Data_Query) for more information.  | 
**ReadDeleted** | **bool** | Indicates whether the query will retrieve only the deleted record. If &#x60;readDeleted&#x60; is set to &#x60;false&#x60; or it is not included in the request body, the query will retrieve only the non-deleted records. If it is set to &#x60;true&#x60;, only the deleted records will be retrieved.  Note that Data Query is subject to Zuora Data Retention Policy. The retention period of deleted data is 30 days. You can only retrieve deleted data for 30 days through Data Query.  | [optional] [default to false]
**SourceData** | **string** | Specifiy that data queries run against the live transactional databases at Zuora (Data Query Live), or run against the optimized, replicated database at 12 hours freshness for high volume extraction (Data Query Unlimited).  **Note**: Data Query Unlimited is an Early Adopter feature.  If you want to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).   * &#x60;DATAHUB&#x60; - Data queries run against the optimized, replicated database at 12 hours freshness for high volume extraction (Data Query Unlimited). Data Query Unlimited is an Early Adopter feature.  If you want to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  * &#x60;LIVE&#x60; - Data queries run against the live transactional databases at Zuora (Data Query Live).  The default value is &#x60;LIVE&#x60;.  | [optional] 
**UseIndexJoin** | **bool** | Indicates whether to use Index Join. Index join is useful when you have a specific reference value in your WHERE clause to index another large table by. See [Use Index Join](https://knowledgecenter.zuora.com/DC_Developers/BA_Data_Query/Best_practices_of_Data_Query#Use_Index_Join) for more information. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

