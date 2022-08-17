# ZuoraClient.Model.GETAccountingPeriodTypeAllOfFileIds
File IDs of the reports available for the accounting period. You can retrieve the reports by specifying the file ID in a [Get Files](https://www.zuora.com/developer/api-reference/#operation/GET_Files) REST API call. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountsReceivableAccountAgingDetailExportFileId** | **string** | File ID of the Accounts Receivable Aging Account Detail report.  | [optional] 
**AccountsReceivableInvoiceAgingDetailExportFileId** | **string** | File ID of the Accounts Receivable Aging Invoice Detail report.  | [optional] 
**ArRollForwardDetailExportFileId** | **string** | File ID of the Accounts Receivable Detail report.  | [optional] 
**FxRealizedGainAndLossDetailExportFileId** | **string** | File ID of the Realized Gain and Loss Detail report.  Returned only if you have Foreign Currency Conversion enabled.  | [optional] 
**FxUnrealizedGainAndLossDetailExportFileId** | **string** | File ID of the Unrealized Gain and Loss Detail report.  Returned only if you have Foreign Currency Conversion enabled  | [optional] 
**RevenueDetailCsvFileId** | **string** | File ID of the Revenue Detail report in CSV format.  | [optional] 
**RevenueDetailExcelFileId** | **string** | File ID of the Revenue Detail report in XLSX format.  | [optional] 
**UnprocessedChargesFileId** | **string** | File ID of a report containing all unprocessed charges for the accounting period.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

