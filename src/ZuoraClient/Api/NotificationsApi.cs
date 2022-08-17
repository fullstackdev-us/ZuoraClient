/*
 * API Reference: Billing
 *
 *   # Introduction  Welcome to the reference for the Zuora Billing REST API!  To learn about the common use cases of Zuora Billing REST APIs, check out the [API Guides](https://www.zuora.com/developer/api-guides/).  In addition to Zuora API Reference; Billing, we also provide API references for other Zuora products:    * [API Reference: Collections](https://www.zuora.com/developer/collect-api/)   * [API Reference: Revenue](https://www.zuora.com/developer/revpro-api/)      The Zuora REST API provides a broad set of operations and resources that:    * Enable Web Storefront integration from your website.   * Support self-service subscriber sign-ups and account management.   * Process revenue schedules through custom revenue rule models.   * Enable manipulation of most objects in the Zuora Billing Object Model.  Want to share your opinion on how our API works for you? <a href=\"https://community.zuora.com/t5/Developers/API-Feedback-Form/gpm-p/21399\" target=\"_blank\">Tell us how you feel </a>about using our API and what we can do to make it better.  ## Access to the API  If you have a Zuora tenant, you can access the Zuora REST API via one of the following endpoints:  | Tenant              | Base URL for REST Endpoints | |- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- --| |US Cloud 1 Production | https://rest.na.zuora.com  | |US Cloud 1 API Sandbox |  https://rest.sandbox.na.zuora.com | |US Cloud 2 Production | https://rest.zuora.com | |US Cloud 2 API Sandbox | https://rest.apisandbox.zuora.com| |US Central Sandbox | https://rest.test.zuora.com |   |US Performance Test | https://rest.pt1.zuora.com | |US Production Copy | Submit a request at <a href=\"http://support.zuora.com/\" target=\"_blank\">Zuora Global Support</a> to enable the Zuora REST API in your tenant and obtain the base URL for REST endpoints. See [REST endpoint base URL of Production Copy (Service) Environment for existing and new customers](https://community.zuora.com/t5/API/REST-endpoint-base-URL-of-Production-Copy-Service-Environment/td-p/29611) for more information. | |EU Production | https://rest.eu.zuora.com | |EU API Sandbox | https://rest.sandbox.eu.zuora.com | |EU Central Sandbox | https://rest.test.eu.zuora.com |  The Production endpoint provides access to your live user data. Sandbox tenants are a good place to test code without affecting real-world data. If you would like Zuora to provision a Sandbox tenant for you, contact your Zuora representative for assistance.   If you do not have a Zuora tenant, go to <a href=\"https://www.zuora.com/resource/zuora-test-drive\" target=\"_blank\">https://www.zuora.com/resource/zuora-test-drive</a> and sign up for a Production Test Drive tenant. The tenant comes with seed data, including a sample product catalog.  # API Changelog You can find the <a href=\"https://bit.ly/3JGqyR3\" target=\"_blank\">Changelog</a> of the API Reference: Billing in the Zuora Community.  # Authentication  ## OAuth v2.0  Zuora recommends that you use OAuth v2.0 to authenticate to the Zuora REST API. Currently, OAuth is not available in every environment. See [Zuora Testing Environments](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Zuora_Environments) for more information.  Zuora recommends you to create a dedicated API user with API write access on a tenant when authenticating via OAuth, and then create an OAuth client for this user. See <a href=\"https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/Manage_Users/Create_an_API_User\" target=\"_blank\">Create an API User</a> for how to do this. By creating a dedicated API user, you can control permissions of the API user without affecting other non-API users.  If a user is deactivated, all of the user's OAuth clients will be automatically deactivated.  Authenticating via OAuth requires the following steps: 1. Create a Client 2. Generate a Token 3. Make Authenticated Requests  ### Create a Client  You must first [create an OAuth client](https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/Manage_Users#Create_an_OAuth_Client_for_a_User) in the Zuora UI. To do this, you must be an administrator of your Zuora tenant. This is a one-time operation. You will be provided with a Client ID and a Client Secret. Please note this information down, as it will be required for the next step.  **Note:** The OAuth client will be owned by a Zuora user account. If you want to perform PUT, POST, or DELETE operations using the OAuth client, the owner of the OAuth client must have a Platform role that includes the \"API Write Access\" permission.  ### Generate a Token  After creating a client, you must make a call to obtain a bearer token using the [Generate an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken) operation. This operation requires the following parameters: - `client_id` - the Client ID displayed when you created the OAuth client in the previous step - `client_secret` - the Client Secret displayed when you created the OAuth client in the previous step - `grant_type` - must be set to `client_credentials`  **Note**: The Client ID and Client Secret mentioned above were displayed when you created the OAuth Client in the prior step. The [Generate an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken) response specifies how long the bearer token is valid for. You should reuse the bearer token until it is expired. When the token is expired, call [Generate an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken) again to generate a new one.  ### Make Authenticated Requests  To authenticate subsequent API requests, you must provide a valid bearer token in an HTTP header:  `Authorization: Bearer {bearer_token}`  If you have [Zuora Multi-entity](https://www.zuora.com/developer/api-reference/#tag/Entities) enabled, you need to set an additional header to specify the ID of the entity that you want to access. You can use the `scope` field in the [Generate an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken) response to determine whether you need to specify an entity ID.  If the `scope` field contains more than one entity ID, you must specify the ID of the entity that you want to access. For example, if the `scope` field contains `entity.1a2b7a37-3e7d-4cb3-b0e2-883de9e766cc` and `entity.c92ed977-510c-4c48-9b51-8d5e848671e9`, specify one of the following headers: - `Zuora-Entity-Ids: 1a2b7a37-3e7d-4cb3-b0e2-883de9e766cc` - `Zuora-Entity-Ids: c92ed977-510c-4c48-9b51-8d5e848671e9`  **Note**: For a limited period of time, Zuora will accept the `entityId` header as an alternative to the `Zuora-Entity-Ids` header. If you choose to set the `entityId` header, you must remove all \"-\" characters from the entity ID in the `scope` field.  If the `scope` field contains a single entity ID, you do not need to specify an entity ID.  ## Other Supported Authentication Schemes  Zuora continues to support the following additional legacy means of authentication:    * Use username and password. Include authentication with each request in the header:         * `apiAccessKeyId`      * `apiSecretAccessKey`          Zuora recommends that you create an API user specifically for making API calls. See <a href=\"https://knowledgecenter.zuora.com/CF_Users_and_Administrators/A_Administrator_Settings/Manage_Users/Create_an_API_User\" target=\"_blank\">Create an API User</a> for more information.      * Use an authorization cookie. The cookie authorizes the user to make calls to the REST API for the duration specified in  **Administration > Security Policies > Session timeout**. The cookie expiration time is reset with this duration after every call to the REST API. To obtain a cookie, call the [Connections](https://www.zuora.com/developer/api-reference/#tag/Connections) resource with the following API user information:         *   ID         *   Password        * For CORS-enabled APIs only: Include a 'single-use' token in the request header, which re-authenticates the user with each request. See below for more details.  ### Entity Id and Entity Name  The `entityId` and `entityName` parameters are only used for [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity \"Zuora Multi-entity\"). These are the legacy parameters that Zuora will only continue to support for a period of time. Zuora recommends you to use the `Zuora-Entity-Ids` parameter instead.   The  `entityId` and `entityName` parameters specify the Id and the [name of the entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity/B_Introduction_to_Entity_and_Entity_Hierarchy#Name_and_Display_Name \"Introduction to Entity and Entity Hierarchy\") that you want to access, respectively. Note that you must have permission to access the entity.   You can specify either the `entityId` or `entityName` parameter in the authentication to access and view an entity.    * If both `entityId` and `entityName` are specified in the authentication, an error occurs.    * If neither `entityId` nor `entityName` is specified in the authentication, you will log in to the entity in which your user account is created.      To get the entity Id and entity name, you can use the GET Entities REST call. For more information, see [API User Authentication](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity/A_Overview_of_Multi-entity#API_User_Authentication \"API User Authentication\").      ### Token Authentication for CORS-Enabled APIs      The CORS mechanism enables REST API calls to Zuora to be made directly from your customer's browser, with all credit card and security information transmitted directly to Zuora. This minimizes your PCI compliance burden, allows you to implement advanced validation on your payment forms, and  makes your payment forms look just like any other part of your website.    For security reasons, instead of using cookies, an API request via CORS uses **tokens** for authentication.  The token method of authentication is only designed for use with requests that must originate from your customer's browser; **it should  not be considered a replacement to the existing cookie authentication** mechanism.  See [Zuora CORS REST](https://knowledgecenter.zuora.com/DC_Developers/C_REST_API/Zuora_CORS_REST \"Zuora CORS REST\") for details on how CORS works and how you can begin to implement customer calls to the Zuora REST APIs. See  [HMAC Signatures](https://www.zuora.com/developer/api-reference/#operation/POSTHMACSignature \"HMAC Signatures\") for details on the HMAC method that returns the authentication token.  # Requests and Responses  ## Request IDs  As a general rule, when asked to supply a \"key\" for an account or subscription (accountKey, account-key, subscriptionKey, subscription-key), you can provide either the actual ID or  the number of the entity.  ## HTTP Request Body  Most of the parameters and data accompanying your requests will be contained in the body of the HTTP request.   The Zuora REST API accepts JSON in the HTTP request body. No other data format (e.g., XML) is supported.  ### Data Type  ([Actions](https://www.zuora.com/developer/api-reference/#tag/Actions) and CRUD operations only) We recommend that you do not specify the decimal values with quotation marks, commas, and spaces. Use characters of `+-0-9.eE`, for example, `5`, `1.9`, `-8.469`, and `7.7e2`. Also, Zuora does not convert currencies for decimal values.   ## Making asynchronous requests  Most Zuora REST API endpoints documented in this API Reference process requests synchronously. In high-throughput scenarios, your requests to these endpoints are usually rate limited.   One strategy for avoiding rate limits is to make asynchronous requests, and Zuora provides this option to you.  Making asynchronous requests allows you to scale your applications more efficiently by leveraging Zuora's infrastructure to enqueue and execute requests for you without blocking. These requests also use built-in retry semantics, which makes them much less likely to fail for non-deterministic reasons, even in extreme high-throughput scenarios.  Meanwhile, when you send a request to one of these endpoints, you can receive a response in less than 150 milliseconds and these calls are unlikely to trigger rate limit errors.   You can make asynchronous requests to the POST, PUT, or DELETE operations, except [Actions](https://www.zuora.com/developer/api-reference/#tag/Actions), for all resources documented in this API Reference.  Take the following steps to take advantage of the asynchronous API:    1. Set up callout notification   2. Make asynchronous requests  The following sections describes the high-level steps for you to get the most of the asynchronous API. For detailed instructions, see [Make asynchronous requests](https://knowledgecenter.zuora.com/Central_Platform/API/AA_REST_API/Make_asynchronous_requests) in the Knowledge Center.   ### Set up notifications  You can create callout notification definitions based on the following custom events through the Zuora UI or the [Create a notification definition](https://www.zuora.com/developer/api-reference/#operation/POST_Create_Notification_Definition) API operation:   * Async Request Succeeded   * Async Request Failed  This step ensures that your system receives a callout when an asynchronous request succeeds or fails.   ### Make asynchronous requests  By design, asynchronous requests differ from their synchronous counterparts in endpoints, and the HTTP status response code and response body they return. ​​The header parameters and request body schema for asynchronous operations are the same as their synchronous counterparts.   * The endpoints for asynchronous API operations contain `/async` in the path after `/v1`. See the following table for examples:  | Operation               | Synchronous endpoint  | Asynchronous endpoint      | |:- -- -- -- - |:- -- -- -- - |:- -- -- -- - | | Create an account       | `/v1/accounts`        | `/v1/async/accounts`       | | CRUD: Create an account | `/v1/object/account`  | `/v1/async/object/account` |  * Unlike the 200 OK response for synchronous requests, Zuora returns a 202 Accepted response for all asynchronous requests, and the response body contains only a request ID.   **Note**: These asynchronous API endpoints are in addition to the previously introduced endpoints that support asynchronous processing. You should continue to use them:   * [Perform a mass action](https://www.zuora.com/developer/api-reference/#operation/POST_MassUpdater)   * [Create an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_CreateOrderAsynchronously)   * [Preview an order asynchronously](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrderAsynchronously)   * [Create a job to hard delete billing document files](https://www.zuora.com/developer/api-reference/#operation/POST_BillingDocumentFilesDeletionJob)   * [CRUD: Post or cancel a bill run](https://www.zuora.com/developer/api-reference/#operation/Object_PUTBillRun)   * [Cancel a journal run](https://www.zuora.com/developer/api-reference/#operation/PUT_JournalRun)   * [Run trial balance](https://www.zuora.com/developer/api-reference/#operation/PUT_RunTrialBalance)  For more information, see [Make asynchronous requests](https://knowledgecenter.zuora.com/Central_Platform/API/AA_REST_API/Make_asynchronous_requests).  ## Testing a Request  Use a third party client, such as [curl](https://curl.haxx.se \"curl\"), [Postman](https://www.getpostman.com \"Postman\"), or [Advanced REST Client](https://advancedrestclient.com \"Advanced REST Client\"), to test the Zuora REST API.  You can test the Zuora REST API from the Zuora API Sandbox or Production tenants. If connecting to Production, bear in mind that you are working with your live production data, not sample data or test data.  ## Testing with Credit Cards  Sooner or later it will probably be necessary to test some transactions that involve credit cards. For suggestions on how to handle this, see [Going Live With Your Payment Gateway](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/C_Managing_Payment_Gateways/B_Going_Live_Payment_Gateways#Testing_with_Credit_Cards \"C_Zuora_User_Guides/A_Billing_and_Payments/M_Payment_Gateways/C_Managing_Payment_Gateways/B_Going_Live_Payment_Gateways#Testing_with_Credit_Cards\" ).  ## Concurrent Request Limits  Zuora enforces tenant-level concurrent request limits. See <a href=\"https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Policies/Concurrent_Request_Limits\" target=\"_blank\">Concurrent Request Limits</a> for more information.  ## Timeout Limit  If a request does not complete within 120 seconds, the request times out and Zuora returns a Gateway Timeout error.   # Error Handling  If a request to Zuora Billing REST API with an endpoint starting with `/v1` (except [Actions](https://www.zuora.com/developer/api-reference/#tag/Actions) and CRUD operations) fails, the response will contain an eight-digit error code with a corresponding error message to indicate the details of the error.  The following code snippet is a sample error response that contains an error code and message pair:  ```  {    \"success\": false,    \"processId\": \"CBCFED6580B4E076\",    \"reasons\":  [      {       \"code\": 53100320,       \"message\": \"'termType' value should be one of: TERMED, EVERGREEN\"      }     ]  } ``` The `success` field indicates whether the API request has succeeded. The `processId` field is a Zuora internal ID that you can provide to Zuora Global Support for troubleshooting purposes.  The `reasons` field contains the actual error code and message pair. The error code begins with `5` or `6` means that you encountered a certain issue that is specific to a REST API resource in Zuora Billing. For example, `53100320` indicates that an invalid value is specified for the `termType` field of the `subscription` object.  The error code beginning with `9` usually indicates that an authentication-related issue occurred, and it can also indicate other unexpected errors depending on different cases. For example, `90000011` indicates that an invalid credential is provided in the request header.   When troubleshooting the error, you can divide the error code into two components: REST API resource code and error category code. See the following Zuora error code sample:  <a href=\"https://assets.zuora.com/zuora-documentation/ZuoraErrorCode.jpeg\" target=\"_blank\"><img src=\"https://assets.zuora.com/zuora-documentation/ZuoraErrorCode.jpeg\" alt=\"Zuora Error Code Sample\"></a>   **Note:** Zuora determines resource codes based on the request payload. Therefore, if GET and DELETE requests that do not contain payloads fail, you will get `500000` as the resource code, which indicates an unknown object and an unknown field.  The error category code of these requests is valid and follows the rules described in the [Error Category Code](https://www.zuora.com/developer/api-reference/#section/Error-Handling/Error-Category-Code) section.  In such case, you can refer to the returned error message to troubleshoot.   ## REST API Resource Codes  The 6-digit resource code indicates the REST API resource, typically a field of a Zuora object, on which the issue occurs. In the preceding example, `531003` refers to the `termType` field of the `subscription` object.   The value range for all REST API resource codes is from `500000` to `679999`. See [Resource Codes](https://knowledgecenter.zuora.com/Central_Platform/API/AA_REST_API/Resource_Codes) in the Knowledge Center for a full list of resource codes.  ## Error Category Codes  The 2-digit error category code identifies the type of error, for example, resource not found or missing required field.   The following table describes all error categories and the corresponding resolution:  | Code    | Error category              | Description    | Resolution    | |:- -- -- -- -|:- -- -- -- -|:- -- -- -- -|:- -- -- -- -| | 10      | Permission or access denied | The request cannot be processed because a certain tenant or user permission is missing. | Check the missing tenant or user permission in the response message and contact [Zuora Global Support](https://support.zuora.com) for enablement. | | 11      | Authentication failed       | Authentication fails due to invalid API authentication credentials. | Ensure that a valid API credential is specified. | | 20      | Invalid format or value     | The request cannot be processed due to an invalid field format or value. | Check the invalid field in the error message, and ensure that the format and value of all fields you passed in are valid. | | 21      | Unknown field in request    | The request cannot be processed because an unknown field exists in the request body. | Check the unknown field name in the response message, and ensure that you do not include any unknown field in the request body. | | 22      | Missing required field      | The request cannot be processed because a required field in the request body is missing. | Check the missing field name in the response message, and ensure that you include all required fields in the request body. | | 23      | Missing required parameter  | The request cannot be processed because a required query parameter is missing. | Check the missing parameter name in the response message, and ensure that you include the parameter in the query. | | 30      | Rule restriction            | The request cannot be processed due to the violation of a Zuora business rule. | Check the response message and ensure that the API request meets the specified business rules. | | 40      | Not found                   | The specified resource cannot be found. | Check the response message and ensure that the specified resource exists in your Zuora tenant. | | 45      | Unsupported request         | The requested endpoint does not support the specified HTTP method. | Check your request and ensure that the endpoint and method matches. | | 50      | Locking contention          | This request cannot be processed because the objects this request is trying to modify are being modified by another API request, UI operation, or batch job process. | <p>Resubmit the request first to have another try.</p> <p>If this error still occurs, contact [Zuora Global Support](https://support.zuora.com) with the returned `Zuora-Request-Id` value in the response header for assistance.</p> | | 60      | Internal error              | The server encounters an internal error. | Contact [Zuora Global Support](https://support.zuora.com) with the returned `Zuora-Request-Id` value in the response header for assistance. | | 61      | Temporary error             | A temporary error occurs during request processing, for example, a database communication error. | <p>Resubmit the request first to have another try.</p> <p>If this error still occurs, contact [Zuora Global Support](https://support.zuora.com) with the returned `Zuora-Request-Id` value in the response header for assistance. </p>| | 70      | Request exceeded limit      | The total number of concurrent requests exceeds the limit allowed by the system. | <p>Resubmit the request after the number of seconds specified by the `Retry-After` value in the response header.</p> <p>Check [Concurrent request limits](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Policies/Concurrent_Request_Limits) for details about Zuora’s concurrent request limit policy.</p> | | 90      | Malformed request           | The request cannot be processed due to JSON syntax errors. | Check the syntax error in the JSON request body and ensure that the request is in the correct JSON format. | | 99      | Integration error           | The server encounters an error when communicating with an external system, for example, payment gateway, tax engine provider. | Check the response message and take action accordingly. |   # Pagination  When retrieving information (using GET methods), the optional `pageSize` query parameter sets the maximum number of rows to return in a response. The maximum is `40`; larger values are treated as `40`. If this value is empty or invalid, `pageSize` typically defaults to `10`.  The default value for the maximum number of rows retrieved can be overridden at the method level.  If more rows are available, the response will include a `nextPage` element, which contains a URL for requesting the next page.  If this value is not provided, no more rows are available. No \"previous page\" element is explicitly provided; to support backward paging, use the previous call.  ## Array Size  For data items that are not paginated, the REST API supports arrays of up to 300 rows.  Thus, for instance, repeated pagination can retrieve thousands of customer accounts, but within any account an array of no more than 300 rate plans is returned.  # API Versions  The Zuora REST API are version controlled. Versioning ensures that Zuora REST API changes are backward compatible. Zuora uses a major and minor version nomenclature to manage changes. By specifying a version in a REST request, you can get expected responses regardless of future changes to the API.  ## Major Version  The major version number of the REST API appears in the REST URL. Currently, Zuora only supports the **v1** major version. For example, `POST https://rest.zuora.com/v1/subscriptions`.  ## Minor Version  Zuora uses minor versions for the REST API to control small changes. For example, a field in a REST method is deprecated and a new field is used to replace it.   Some fields in the REST methods are supported as of minor versions. If a field is not noted with a minor version, this field is available for all minor versions. If a field is noted with a minor version, this field is in version control. You must specify the supported minor version in the request header to process without an error.   If a field is in version control, it is either with a minimum minor version or a maximum minor version, or both of them. You can only use this field with the minor version between the minimum and the maximum minor versions. For example, the `invoiceCollect` field in the POST Subscription method is in version control and its maximum minor version is 189.0. You can only use this field with the minor version 189.0 or earlier.  If you specify a version number in the request header that is not supported, Zuora will use the minimum minor version of the REST API. In our REST API documentation, if a field or feature requires a minor version number, we note that in the field description.  You only need to specify the version number when you use the fields require a minor version. To specify the minor version, set the `zuora-version` parameter to the minor version number in the request header for the request call. For example, the `collect` field is in 196.0 minor version. If you want to use this field for the POST Subscription method, set the  `zuora-version` parameter to `196.0` in the request header. The `zuora-version` parameter is case sensitive.  For all the REST API fields, by default, if the minor version is not specified in the request header, Zuora will use the minimum minor version of the REST API to avoid breaking your integration.   ### Minor Version History  The supported minor versions are not serial. This section documents the changes made to each Zuora REST API minor version.  The following table lists the supported versions and the fields that have a Zuora REST API minor version.  | Fields         | Minor Version      | REST Methods    | Description | |:- -- -- -- -|:- -- -- -- -|:- -- -- -- -|:- -- -- -- -| | invoiceCollect | 189.0 and earlier  | [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Generates an invoice and collects a payment for a subscription. | | collect        | 196.0 and later    | [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Collects an automatic payment for a subscription. | | invoice | 196.0 and 207.0| [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Generates an invoice for a subscription. | | invoiceTargetDate | 196.0 and earlier  | [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\") |Date through which charges are calculated on the invoice, as `yyyy-mm-dd`. | | invoiceTargetDate | 207.0 and earlier  | [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Date through which charges are calculated on the invoice, as `yyyy-mm-dd`. | | targetDate | 207.0 and later | [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\") |Date through which charges are calculated on the invoice, as `yyyy-mm-dd`. | | targetDate | 211.0 and later | [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Date through which charges are calculated on the invoice, as `yyyy-mm-dd`. | | includeExisting DraftInvoiceItems | 196.0 and earlier| [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\") | Specifies whether to include draft invoice items in subscription previews. Specify it to be `true` (default) to include draft invoice items in the preview result. Specify it to be `false` to excludes draft invoice items in the preview result. | | includeExisting DraftDocItems | 207.0 and later  | [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\") | Specifies whether to include draft invoice items in subscription previews. Specify it to be `true` (default) to include draft invoice items in the preview result. Specify it to be `false` to excludes draft invoice items in the preview result. | | previewType | 196.0 and earlier| [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\") | The type of preview you will receive. The possible values are `InvoiceItem`(default), `ChargeMetrics`, and `InvoiceItemChargeMetrics`. | | previewType | 207.0 and later  | [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\") | The type of preview you will receive. The possible values are `LegalDoc`(default), `ChargeMetrics`, and `LegalDocChargeMetrics`. | | runBilling  | 211.0 and later  | [Create Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription \"Create Subscription\"); [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\"); [Renew Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_RenewSubscription \"Renew Subscription\"); [Cancel Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_CancelSubscription \"Cancel Subscription\"); [Suspend Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_SuspendSubscription \"Suspend Subscription\"); [Resume Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_ResumeSubscription \"Resume Subscription\"); [Create Account](https://www.zuora.com/developer/api-reference/#operation/POST_Account \"Create Account\")|Generates an invoice or credit memo for a subscription. **Note:** Credit memos are only available if you have the Invoice Settlement feature enabled. | | invoiceDate | 214.0 and earlier  | [Invoice and Collect](https://www.zuora.com/developer/api-reference/#operation/POST_TransactionInvoicePayment \"Invoice and Collect\") |Date that should appear on the invoice being generated, as `yyyy-mm-dd`. | | invoiceTargetDate | 214.0 and earlier  | [Invoice and Collect](https://www.zuora.com/developer/api-reference/#operation/POST_TransactionInvoicePayment \"Invoice and Collect\") |Date through which to calculate charges on this account if an invoice is generated, as `yyyy-mm-dd`. | | documentDate | 215.0 and later | [Invoice and Collect](https://www.zuora.com/developer/api-reference/#operation/POST_TransactionInvoicePayment \"Invoice and Collect\") |Date that should appear on the invoice and credit memo being generated, as `yyyy-mm-dd`. | | targetDate | 215.0 and later | [Invoice and Collect](https://www.zuora.com/developer/api-reference/#operation/POST_TransactionInvoicePayment \"Invoice and Collect\") |Date through which to calculate charges on this account if an invoice or a credit memo is generated, as `yyyy-mm-dd`. | | memoItemAmount | 223.0 and earlier | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\") | Amount of the memo item. | | amount | 224.0 and later | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\") | Amount of the memo item. | | subscriptionNumbers | 222.4 and earlier | [Create order](https://www.zuora.com/developer/api-reference/#operation/POST_Order \"Create order\") | Container for the subscription numbers of the subscriptions in an order. | | subscriptions | 223.0 and later | [Create order](https://www.zuora.com/developer/api-reference/#operation/POST_Order \"Create order\") | Container for the subscription numbers and statuses in an order. | | creditTaxItems | 238.0 and earlier | [Get credit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItems \"Get credit memo items\"); [Get credit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItem \"Get credit memo item\") | Container for the taxation items of the credit memo item. | | taxItems | 238.0 and earlier | [Get debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems \"Get debit memo items\"); [Get debit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItem \"Get debit memo item\") | Container for the taxation items of the debit memo item. | | taxationItems | 239.0 and later | [Get credit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItems \"Get credit memo items\"); [Get credit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItem \"Get credit memo item\"); [Get debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems \"Get debit memo items\"); [Get debit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItem \"Get debit memo item\") | Container for the taxation items of the memo item. | | chargeId | 256.0 and earlier | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\") | ID of the product rate plan charge that the memo is created from. | | productRatePlanChargeId | 257.0 and later | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\") | ID of the product rate plan charge that the memo is created from. | | comment | 256.0 and earlier | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\"); [Create credit memo from invoice](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromInvoice \"Create credit memo from invoice\"); [Create debit memo from invoice](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromInvoice \"Create debit memo from invoice\"); [Get credit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItems \"Get credit memo items\"); [Get credit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItem \"Get credit memo item\"); [Get debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems \"Get debit memo items\"); [Get debit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItem \"Get debit memo item\") | Comments about the product rate plan charge, invoice item, or memo item. | | description | 257.0 and later | [Create credit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc \"Create credit memo from charge\"); [Create debit memo from charge](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromPrpc \"Create debit memo from charge\"); [Create credit memo from invoice](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromInvoice \"Create credit memo from invoice\"); [Create debit memo from invoice](https://www.zuora.com/developer/api-reference/#operation/POST_DebitMemoFromInvoice \"Create debit memo from invoice\"); [Get credit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItems \"Get credit memo items\"); [Get credit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_CreditMemoItem \"Get credit memo item\"); [Get debit memo items](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItems \"Get debit memo items\"); [Get debit memo item](https://www.zuora.com/developer/api-reference/#operation/GET_DebitMemoItem \"Get debit memo item\") | Description of the the product rate plan charge, invoice item, or memo item. | | taxationItems | 309.0 and later | [Preview an order](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewOrder \"Preview an order\") | List of taxation items for an invoice item or a credit memo item. | | batch | 309.0 and earlier | [Create a billing preview run](https://www.zuora.com/developer/api-reference/#operation/POST_BillingPreviewRun \"Create a billing preview run\") | The customer batches to include in the billing preview run. |       | batches | 314.0 and later | [Create a billing preview run](https://www.zuora.com/developer/api-reference/#operation/POST_BillingPreviewRun \"Create a billing preview run\") | The customer batches to include in the billing preview run. | | taxationItems | 315.0 and later | [Preview a subscription](https://www.zuora.com/developer/api-reference/#operation/POST_PreviewSubscription \"Preview a subscription\"); [Update a subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update a subscription\")| List of taxation items for an invoice item or a credit memo item. |    #### Version 207.0 and Later  The response structure of the [Preview Subscription](https://www.zuora.com/developer/api-reference/#operation/POST_SubscriptionPreview \"Preview Subscription\") and [Update Subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription \"Update Subscription\") methods are changed. The following invoice related response fields are moved to the invoice container:    * amount   * amountWithoutTax   * taxAmount   * invoiceItems   * targetDate   * chargeMetrics  # Zuora Billing Object Model  The following diagram is a high-level view of how key business objects are related to one another within Zuora Billing.  Click the diagram to open it in a new tab and zoom in. For more information about the different sections of the diagram, see <a href=\"https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/A_Zuora_Billing_business_object_model\" target=\"_blank\">Zuora Billing business object model</a>.  <a href=\"https://assets.zuora.com/zuora-documentation/Zuora_Billing_object_model_Sep2020.png\" target=\"_blank\"><img src=\"https://assets.zuora.com/zuora-documentation/Zuora_Billing_object_model_Sep2020.png\" alt=\"Zuora Billing object model diagram\"></a>  This diagram is intended to provide a conceptual understanding; it does not illustrate a specific way to integrate with Zuora.  The diagram includes the Orders feature and the Invoice Settlement feature. If your organization does not use either of these features, see <a href=\"https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/B_Zuora_Billing_business_object_model_prior_to_Orders_and_Invoice_Settlement\" target=\"_blank\">Zuora Billing business object model prior to Orders and Invoice Settlement</a> for an alternative diagram.  ## API Names  You can use the [Describe object](https://www.zuora.com/developer/api-reference/#operation/GET_Describe) operation to list the fields of each Zuora object that is available in your tenant. When you call the operation, you must specify the API name of the Zuora object.  The following table provides the API name of each Zuora object:  | Object                                        | API Name                                   | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -| | Account                                       | `Account`                                  | | Accounting Code                               | `AccountingCode`                           | | Accounting Period                             | `AccountingPeriod`                         | | Amendment                                     | `Amendment`                                | | Application Group                             | `ApplicationGroup`                         | | Billing Run                                   | <p>`BillingRun` - API name used  in the [Describe object](https://www.zuora.com/developer/api-reference/#operation/GET_Describe) operation, Export ZOQL queries, and Data Query.</p> <p>`BillRun` - API name used in the [Actions](https://www.zuora.com/developer/api-reference/#tag/Actions). See the CRUD oprations of [Bill Run](https://www.zuora.com/developer/api-reference/#tag/Bill-Run) for more information about the `BillRun` object. `BillingRun` and `BillRun` have different fields. |                      | Contact                                       | `Contact`                                  | | Contact Snapshot                              | `ContactSnapshot`                          | | Credit Balance Adjustment                     | `CreditBalanceAdjustment`                  | | Credit Memo                                   | `CreditMemo`                               | | Credit Memo Application                       | `CreditMemoApplication`                    | | Credit Memo Application Item                  | `CreditMemoApplicationItem`                | | Credit Memo Item                              | `CreditMemoItem`                           | | Credit Memo Part                              | `CreditMemoPart`                           | | Credit Memo Part Item                         | `CreditMemoPartItem`                       | | Credit Taxation Item                          | `CreditTaxationItem`                       | | Custom Exchange Rate                          | `FXCustomRate`                             | | Debit Memo                                    | `DebitMemo`                                | | Debit Memo Item                               | `DebitMemoItem`                            | | Debit Taxation Item                           | `DebitTaxationItem`                        | | Discount Applied Metrics                      | `DiscountAppliedMetrics`                   | | Entity                                        | `Tenant`                                   | | Feature                                       | `Feature`                                  | | Gateway Reconciliation Event                  | `PaymentGatewayReconciliationEventLog`     | | Gateway Reconciliation Job                    | `PaymentReconciliationJob`                 | | Gateway Reconciliation Log                    | `PaymentReconciliationLog`                 | | Invoice                                       | `Invoice`                                  | | Invoice Adjustment                            | `InvoiceAdjustment`                        | | Invoice Item                                  | `InvoiceItem`                              | | Invoice Item Adjustment                       | `InvoiceItemAdjustment`                    | | Invoice Payment                               | `InvoicePayment`                           | | Journal Entry                                 | `JournalEntry`                             | | Journal Entry Item                            | `JournalEntryItem`                         | | Journal Run                                   | `JournalRun`                               | | Notification History - Callout                | `CalloutHistory`                           | | Notification History - Email                  | `EmailHistory`                             | | Order                                         | `Order`                                    | | Order Action                                  | `OrderAction`                              | | Order ELP                                     | `OrderElp`                                 | | Order Line Items                              | `OrderLineItems`                           |     | Order Item                                    | `OrderItem`                                | | Order MRR                                     | `OrderMrr`                                 | | Order Quantity                                | `OrderQuantity`                            | | Order TCB                                     | `OrderTcb`                                 | | Order TCV                                     | `OrderTcv`                                 | | Payment                                       | `Payment`                                  | | Payment Application                           | `PaymentApplication`                       | | Payment Application Item                      | `PaymentApplicationItem`                   | | Payment Method                                | `PaymentMethod`                            | | Payment Method Snapshot                       | `PaymentMethodSnapshot`                    | | Payment Method Transaction Log                | `PaymentMethodTransactionLog`              | | Payment Method Update                         | `UpdaterDetail`                            | | Payment Part                                  | `PaymentPart`                              | | Payment Part Item                             | `PaymentPartItem`                          | | Payment Run                                   | `PaymentRun`                               | | Payment Transaction Log                       | `PaymentTransactionLog`                    | | Processed Usage                               | `ProcessedUsage`                           | | Product                                       | `Product`                                  | | Product Feature                               | `ProductFeature`                           | | Product Rate Plan                             | `ProductRatePlan`                          | | Product Rate Plan Charge                      | `ProductRatePlanCharge`                    | | Product Rate Plan Charge Tier                 | `ProductRatePlanChargeTier`                | | Rate Plan                                     | `RatePlan`                                 | | Rate Plan Charge                              | `RatePlanCharge`                           | | Rate Plan Charge Tier                         | `RatePlanChargeTier`                       | | Refund                                        | `Refund`                                   | | Refund Application                            | `RefundApplication`                        | | Refund Application Item                       | `RefundApplicationItem`                    | | Refund Invoice Payment                        | `RefundInvoicePayment`                     | | Refund Part                                   | `RefundPart`                               | | Refund Part Item                              | `RefundPartItem`                           | | Refund Transaction Log                        | `RefundTransactionLog`                     | | Revenue Charge Summary                        | `RevenueChargeSummary`                     | | Revenue Charge Summary Item                   | `RevenueChargeSummaryItem`                 | | Revenue Event                                 | `RevenueEvent`                             | | Revenue Event Credit Memo Item                | `RevenueEventCreditMemoItem`               | | Revenue Event Debit Memo Item                 | `RevenueEventDebitMemoItem`                | | Revenue Event Invoice Item                    | `RevenueEventInvoiceItem`                  | | Revenue Event Invoice Item Adjustment         | `RevenueEventInvoiceItemAdjustment`        | | Revenue Event Item                            | `RevenueEventItem`                         | | Revenue Event Item Credit Memo Item           | `RevenueEventItemCreditMemoItem`           | | Revenue Event Item Debit Memo Item            | `RevenueEventItemDebitMemoItem`            | | Revenue Event Item Invoice Item               | `RevenueEventItemInvoiceItem`              | | Revenue Event Item Invoice Item Adjustment    | `RevenueEventItemInvoiceItemAdjustment`    | | Revenue Event Type                            | `RevenueEventType`                         | | Revenue Schedule                              | `RevenueSchedule`                          | | Revenue Schedule Credit Memo Item             | `RevenueScheduleCreditMemoItem`            | | Revenue Schedule Debit Memo Item              | `RevenueScheduleDebitMemoItem`             | | Revenue Schedule Invoice Item                 | `RevenueScheduleInvoiceItem`               | | Revenue Schedule Invoice Item Adjustment      | `RevenueScheduleInvoiceItemAdjustment`     | | Revenue Schedule Item                         | `RevenueScheduleItem`                      | | Revenue Schedule Item Credit Memo Item        | `RevenueScheduleItemCreditMemoItem`        | | Revenue Schedule Item Debit Memo Item         | `RevenueScheduleItemDebitMemoItem`         | | Revenue Schedule Item Invoice Item            | `RevenueScheduleItemInvoiceItem`           | | Revenue Schedule Item Invoice Item Adjustment | `RevenueScheduleItemInvoiceItemAdjustment` | | Subscription                                  | `Subscription`                             | | Subscription Product Feature                  | `SubscriptionProductFeature`               | | Taxable Item Snapshot                         | `TaxableItemSnapshot`                      | | Taxation Item                                 | `TaxationItem`                             | | Updater Batch                                 | `UpdaterBatch`                             | | Usage                                         | `Usage`                                    | 
 *
 * The version of the OpenAPI document: 2022-08-12
 * Contact: docs@zuora.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using ZuoraClient.Client;
using ZuoraClient.Model;

namespace ZuoraClient.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface INotificationsApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete an email template
        /// </summary>
        /// <remarks>
        /// Deletes an email template. This operation supports deleting an email template for all event types. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void DELETEDeleteEmailTemplate(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Delete an email template
        /// </summary>
        /// <remarks>
        /// Deletes an email template. This operation supports deleting an email template for all event types. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DELETEDeleteEmailTemplateWithHttpInfo(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Delete a notification definition
        /// </summary>
        /// <remarks>
        /// Deletes a notification definition.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        void DELETEDeleteNotificationDefinition(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Delete a notification definition
        /// </summary>
        /// <remarks>
        /// Deletes a notification definition.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DELETEDeleteNotificationDefinitionWithHttpInfo(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Delete notification histories for an account
        /// </summary>
        /// <remarks>
        /// Delete all notification histories for the given account. All email and callout notifications for this account will be deleted upon successful operation. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="accountId">The ID of the account whose notification histories are to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>NotificationsHistoryDeletionTaskResponse</returns>
        NotificationsHistoryDeletionTaskResponse DELETEDeleteNotificationHistoryForAccount(string authorization, Guid accountId, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Delete notification histories for an account
        /// </summary>
        /// <remarks>
        /// Delete all notification histories for the given account. All email and callout notifications for this account will be deleted upon successful operation. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="accountId">The ID of the account whose notification histories are to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of NotificationsHistoryDeletionTaskResponse</returns>
        ApiResponse<NotificationsHistoryDeletionTaskResponse> DELETEDeleteNotificationHistoryForAccountWithHttpInfo(string authorization, Guid accountId, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// List callout notification histories
        /// </summary>
        /// <remarks>
        /// Describes how to get a notification history for callouts. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="endTime">The final date and time of records to be returned. Defaults to now. Use format yyyy-MM-ddTHH:mm:ss. (optional)</param>
        /// <param name="startTime">The initial date and time of records to be returned. Defaults to (end time - 1 day). Use format yyyy-MM-ddTHH:mm:ss. (optional)</param>
        /// <param name="objectId">The ID of an object that triggered a callout notification.   (optional)</param>
        /// <param name="failedOnly">If &#x60;true&#x60;, only return failed records. If &#x60;false&#x60;, return all records in the given date range. The default value is &#x60;true&#x60;.  (optional)</param>
        /// <param name="eventCategory">Category of records to be returned by event category.  The following formats are supported: * &#x60;{Event Type Namespace}:{Event Type Name}&#x60; if the Custom Events feature is enabled in your tenant. For example: &#x60;user.notification:NewSubscriptionCreated&#x60;. * Numeric code of the event category if the Custom Events feature is not enabled in your tenant. For example, &#x60;1210&#x60;. See [Event Category Code](https://knowledgecenter.zuora.com/DC_Developers/AA_REST_API/Event_Categories_for_Notification_Histories) for more information.  (optional)</param>
        /// <param name="includeResponseContent"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETCalloutHistoryVOsType</returns>
        GETCalloutHistoryVOsType GETCalloutHistory(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), DateTime? endTime = default(DateTime?), DateTime? startTime = default(DateTime?), string objectId = default(string), bool? failedOnly = default(bool?), string eventCategory = default(string), bool? includeResponseContent = default(bool?), int operationIndex = 0);

        /// <summary>
        /// List callout notification histories
        /// </summary>
        /// <remarks>
        /// Describes how to get a notification history for callouts. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="endTime">The final date and time of records to be returned. Defaults to now. Use format yyyy-MM-ddTHH:mm:ss. (optional)</param>
        /// <param name="startTime">The initial date and time of records to be returned. Defaults to (end time - 1 day). Use format yyyy-MM-ddTHH:mm:ss. (optional)</param>
        /// <param name="objectId">The ID of an object that triggered a callout notification.   (optional)</param>
        /// <param name="failedOnly">If &#x60;true&#x60;, only return failed records. If &#x60;false&#x60;, return all records in the given date range. The default value is &#x60;true&#x60;.  (optional)</param>
        /// <param name="eventCategory">Category of records to be returned by event category.  The following formats are supported: * &#x60;{Event Type Namespace}:{Event Type Name}&#x60; if the Custom Events feature is enabled in your tenant. For example: &#x60;user.notification:NewSubscriptionCreated&#x60;. * Numeric code of the event category if the Custom Events feature is not enabled in your tenant. For example, &#x60;1210&#x60;. See [Event Category Code](https://knowledgecenter.zuora.com/DC_Developers/AA_REST_API/Event_Categories_for_Notification_Histories) for more information.  (optional)</param>
        /// <param name="includeResponseContent"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETCalloutHistoryVOsType</returns>
        ApiResponse<GETCalloutHistoryVOsType> GETCalloutHistoryWithHttpInfo(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), DateTime? endTime = default(DateTime?), DateTime? startTime = default(DateTime?), string objectId = default(string), bool? failedOnly = default(bool?), string eventCategory = default(string), bool? includeResponseContent = default(bool?), int operationIndex = 0);
        /// <summary>
        /// List email notification histories
        /// </summary>
        /// <remarks>
        /// Describes how to get a notification history for notification emails.   ## Notes Request parameters and their values may be appended with a \&quot;?\&quot; following the HTTPS GET request.  Additional request parameter are separated by \&quot;&amp;\&quot;.   For example:  &#x60;GET https://rest.zuora.com/v1/notification-history/email?startTime&#x3D;2015-01-12T00:00:00&amp;endTime&#x3D;2015-01-15T00:00:00&amp;failedOnly&#x3D;false&amp;eventCategory&#x3D;1000&amp;pageSize&#x3D;1&#x60; 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="accountId">ID of an account. By specifying this query parameter, you can filter email notification histories by account. (optional)</param>
        /// <param name="endTime">The end date and time of records to be returned. Defaults to now. Use format yyyy-MM-ddTHH:mm:ss. The maximum date range (endTime - startTime) is three days. (optional)</param>
        /// <param name="startTime">The initial date and time of records to be returned. Defaults to (end time - 1 day). Use format yyyy-MM-ddTHH:mm:ss. The maximum date range (endTime - startTime) is three days. (optional)</param>
        /// <param name="objectId">The Id of an object that triggered an email notification.  (optional)</param>
        /// <param name="failedOnly">If &#x60;true&#x60;, only returns failed records. When &#x60;false&#x60;, returns all records in the given date range. Defaults to &#x60;true&#x60; when not specified.  (optional)</param>
        /// <param name="eventCategory">Category of records to be returned by event category.  The following formats are supported: * &#x60;{Event Type Namespace}:{Event Type Name}&#x60; if the Custom Events feature is enabled in your tenant. For example: &#x60;user.notification:NewSubscriptionCreated&#x60;. * Numeric code of the event category if the Custom Events feature is not enabled in your tenant. For example, &#x60;1210&#x60;. See [Event Category Code](https://knowledgecenter.zuora.com/DC_Developers/AA_REST_API/Event_Categories_for_Notification_Histories) for more information.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETEmailHistoryVOsType</returns>
        GETEmailHistoryVOsType GETEmailHistory(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string accountId = default(string), DateTime? endTime = default(DateTime?), DateTime? startTime = default(DateTime?), string objectId = default(string), bool? failedOnly = default(bool?), decimal? eventCategory = default(decimal?), int operationIndex = 0);

        /// <summary>
        /// List email notification histories
        /// </summary>
        /// <remarks>
        /// Describes how to get a notification history for notification emails.   ## Notes Request parameters and their values may be appended with a \&quot;?\&quot; following the HTTPS GET request.  Additional request parameter are separated by \&quot;&amp;\&quot;.   For example:  &#x60;GET https://rest.zuora.com/v1/notification-history/email?startTime&#x3D;2015-01-12T00:00:00&amp;endTime&#x3D;2015-01-15T00:00:00&amp;failedOnly&#x3D;false&amp;eventCategory&#x3D;1000&amp;pageSize&#x3D;1&#x60; 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="accountId">ID of an account. By specifying this query parameter, you can filter email notification histories by account. (optional)</param>
        /// <param name="endTime">The end date and time of records to be returned. Defaults to now. Use format yyyy-MM-ddTHH:mm:ss. The maximum date range (endTime - startTime) is three days. (optional)</param>
        /// <param name="startTime">The initial date and time of records to be returned. Defaults to (end time - 1 day). Use format yyyy-MM-ddTHH:mm:ss. The maximum date range (endTime - startTime) is three days. (optional)</param>
        /// <param name="objectId">The Id of an object that triggered an email notification.  (optional)</param>
        /// <param name="failedOnly">If &#x60;true&#x60;, only returns failed records. When &#x60;false&#x60;, returns all records in the given date range. Defaults to &#x60;true&#x60; when not specified.  (optional)</param>
        /// <param name="eventCategory">Category of records to be returned by event category.  The following formats are supported: * &#x60;{Event Type Namespace}:{Event Type Name}&#x60; if the Custom Events feature is enabled in your tenant. For example: &#x60;user.notification:NewSubscriptionCreated&#x60;. * Numeric code of the event category if the Custom Events feature is not enabled in your tenant. For example, &#x60;1210&#x60;. See [Event Category Code](https://knowledgecenter.zuora.com/DC_Developers/AA_REST_API/Event_Categories_for_Notification_Histories) for more information.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETEmailHistoryVOsType</returns>
        ApiResponse<GETEmailHistoryVOsType> GETEmailHistoryWithHttpInfo(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string accountId = default(string), DateTime? endTime = default(DateTime?), DateTime? startTime = default(DateTime?), string objectId = default(string), bool? failedOnly = default(bool?), decimal? eventCategory = default(decimal?), int operationIndex = 0);
        /// <summary>
        /// Retrieve an email template
        /// </summary>
        /// <remarks>
        /// Queries the email template based on the specified ID. This operation supports retrieving the email template for all event types. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETPublicEmailTemplateResponse</returns>
        GETPublicEmailTemplateResponse GETGetEmailTemplate(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Retrieve an email template
        /// </summary>
        /// <remarks>
        /// Queries the email template based on the specified ID. This operation supports retrieving the email template for all event types. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETPublicEmailTemplateResponse</returns>
        ApiResponse<GETPublicEmailTemplateResponse> GETGetEmailTemplateWithHttpInfo(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Retrieve a notification definition
        /// </summary>
        /// <remarks>
        /// Queries the notification definition of the given ID.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETPublicNotificationDefinitionResponse</returns>
        GETPublicNotificationDefinitionResponse GETGetNotificationDefinition(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Retrieve a notification definition
        /// </summary>
        /// <remarks>
        /// Queries the notification definition of the given ID.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETPublicNotificationDefinitionResponse</returns>
        ApiResponse<GETPublicNotificationDefinitionResponse> GETGetNotificationDefinitionWithHttpInfo(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Retrieve a notification history deletion task
        /// </summary>
        /// <remarks>
        /// Get the notification history deletion task by ID. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification history deletion task. You can get the deletion task ID from the 202 response body of the [Delete notification histories for an account](https://www.zuora.com/developer/api-reference/#operation/DELETE_Delete_Notification_History_For_Account) operation. </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>NotificationsHistoryDeletionTaskResponse</returns>
        NotificationsHistoryDeletionTaskResponse GETGetNotificationHistoryDeletionTask(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Retrieve a notification history deletion task
        /// </summary>
        /// <remarks>
        /// Get the notification history deletion task by ID. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification history deletion task. You can get the deletion task ID from the 202 response body of the [Delete notification histories for an account](https://www.zuora.com/developer/api-reference/#operation/DELETE_Delete_Notification_History_For_Account) operation. </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of NotificationsHistoryDeletionTaskResponse</returns>
        ApiResponse<NotificationsHistoryDeletionTaskResponse> GETGetNotificationHistoryDeletionTaskWithHttpInfo(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// List email templates
        /// </summary>
        /// <remarks>
        /// Queries email templates. This operation supports querying email templates for all event types. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="start">The first index of the query result. (optional, default to 1)</param>
        /// <param name="limit">The maximum number of results the query should return. (optional, default to 20)</param>
        /// <param name="eventCategory">The event category code for standard events. (optional)</param>
        /// <param name="eventTypeName">The name of the custom event or custom scheduled event. (optional)</param>
        /// <param name="name">The name of the email template. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETQueryEmailTemplates200Response</returns>
        GETQueryEmailTemplates200Response GETQueryEmailTemplates(string authorization, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? start = default(int?), int? limit = default(int?), decimal? eventCategory = default(decimal?), string eventTypeName = default(string), string name = default(string), int operationIndex = 0);

        /// <summary>
        /// List email templates
        /// </summary>
        /// <remarks>
        /// Queries email templates. This operation supports querying email templates for all event types. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="start">The first index of the query result. (optional, default to 1)</param>
        /// <param name="limit">The maximum number of results the query should return. (optional, default to 20)</param>
        /// <param name="eventCategory">The event category code for standard events. (optional)</param>
        /// <param name="eventTypeName">The name of the custom event or custom scheduled event. (optional)</param>
        /// <param name="name">The name of the email template. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETQueryEmailTemplates200Response</returns>
        ApiResponse<GETQueryEmailTemplates200Response> GETQueryEmailTemplatesWithHttpInfo(string authorization, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? start = default(int?), int? limit = default(int?), decimal? eventCategory = default(decimal?), string eventTypeName = default(string), string name = default(string), int operationIndex = 0);
        /// <summary>
        /// List notification definitions
        /// </summary>
        /// <remarks>
        /// Queries notification definitions with the specified filters.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="start">The first index of the query result. (optional, default to 1)</param>
        /// <param name="limit">The maximum number of results the query should return. (optional, default to 20)</param>
        /// <param name="profileId">Id of the profile. (optional)</param>
        /// <param name="eventTypeName">The name of the event. (optional)</param>
        /// <param name="emailTemplateId">The ID of the email template. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETQueryNotificationDefinitions200Response</returns>
        GETQueryNotificationDefinitions200Response GETQueryNotificationDefinitions(string authorization, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? start = default(int?), int? limit = default(int?), Guid? profileId = default(Guid?), string eventTypeName = default(string), Guid? emailTemplateId = default(Guid?), int operationIndex = 0);

        /// <summary>
        /// List notification definitions
        /// </summary>
        /// <remarks>
        /// Queries notification definitions with the specified filters.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="start">The first index of the query result. (optional, default to 1)</param>
        /// <param name="limit">The maximum number of results the query should return. (optional, default to 20)</param>
        /// <param name="profileId">Id of the profile. (optional)</param>
        /// <param name="eventTypeName">The name of the event. (optional)</param>
        /// <param name="emailTemplateId">The ID of the email template. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETQueryNotificationDefinitions200Response</returns>
        ApiResponse<GETQueryNotificationDefinitions200Response> GETQueryNotificationDefinitionsWithHttpInfo(string authorization, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? start = default(int?), int? limit = default(int?), Guid? profileId = default(Guid?), string eventTypeName = default(string), Guid? emailTemplateId = default(Guid?), int operationIndex = 0);
        /// <summary>
        /// Create an email template
        /// </summary>
        /// <remarks>
        /// Creates an email template.   This operation supports creating the email template for all event types.  - If you specify the &#x60;eventCategory&#x60; field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes. - If you specify the &#x60;eventTypeName&#x60; field, the email template is created based on the corresponding custom event or custom scheduled event. See [Event triggers](https://www.zuora.com/developer/api-reference/#tag/Event-Triggers) for more information about custom events, and [Scheduled events](https://www.zuora.com/developer/api-reference/#tag/Scheduled-Events) for more information about custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTPublicEmailTemplateRequest">The request body to create an email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETPublicEmailTemplateResponse</returns>
        GETPublicEmailTemplateResponse POSTCreateEmailTemplate(string authorization, POSTPublicEmailTemplateRequest pOSTPublicEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Create an email template
        /// </summary>
        /// <remarks>
        /// Creates an email template.   This operation supports creating the email template for all event types.  - If you specify the &#x60;eventCategory&#x60; field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes. - If you specify the &#x60;eventTypeName&#x60; field, the email template is created based on the corresponding custom event or custom scheduled event. See [Event triggers](https://www.zuora.com/developer/api-reference/#tag/Event-Triggers) for more information about custom events, and [Scheduled events](https://www.zuora.com/developer/api-reference/#tag/Scheduled-Events) for more information about custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTPublicEmailTemplateRequest">The request body to create an email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETPublicEmailTemplateResponse</returns>
        ApiResponse<GETPublicEmailTemplateResponse> POSTCreateEmailTemplateWithHttpInfo(string authorization, POSTPublicEmailTemplateRequest pOSTPublicEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Create a notification definition
        /// </summary>
        /// <remarks>
        /// Creates a notification definition. If a filter rule is specified, it will be evaluated to see if the notification definition is qualified to handle the incoming events  during runtime. If the notification is qualified, it will send the email and invoke the callout if it has an email template or a callout. See a step-by-step guide for [creating a custom notification](https://www.zuora.com/developer/api-guides/#Callout-to-external-system-for-provisioning-or-entitlements) in [Zuora API Guides](https://www.zuora.com/developer/api-guides/).  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="entity">The request body used to create the notification definition.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETPublicNotificationDefinitionResponse</returns>
        GETPublicNotificationDefinitionResponse POSTCreateNotificationDefinition(string authorization, POSTPublicNotificationDefinitionRequest entity, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Create a notification definition
        /// </summary>
        /// <remarks>
        /// Creates a notification definition. If a filter rule is specified, it will be evaluated to see if the notification definition is qualified to handle the incoming events  during runtime. If the notification is qualified, it will send the email and invoke the callout if it has an email template or a callout. See a step-by-step guide for [creating a custom notification](https://www.zuora.com/developer/api-guides/#Callout-to-external-system-for-provisioning-or-entitlements) in [Zuora API Guides](https://www.zuora.com/developer/api-guides/).  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="entity">The request body used to create the notification definition.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETPublicNotificationDefinitionResponse</returns>
        ApiResponse<GETPublicNotificationDefinitionResponse> POSTCreateNotificationDefinitionWithHttpInfo(string authorization, POSTPublicNotificationDefinitionRequest entity, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Create or update email templates
        /// </summary>
        /// <remarks>
        /// Creates email templates for standard or custom events if you do not specify email template IDs, or updates existing email templates if you specify valid email template IDs.  For each email template when you are creating email templates, whether the template is created for a standard event, a custom event, or a custom scheduled event is dependent on whether you specify the &#x60;eventCategory&#x60; or &#x60;eventTypeName&#x60; field.  - If you specify the &#x60;eventCategory&#x60; field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes. - If you specify the &#x60;eventTypeName&#x60; field, the email template is created based on the corresponding custom event or custom scheduled event. See [Event triggers](https://www.zuora.com/developer/api-reference/#tag/Event-Triggers) for more information about custom events, and [Scheduled events](https://www.zuora.com/developer/api-reference/#tag/Scheduled-Events) for more information about custom scheduled events.  The maximum number of email templates that you can create or update by one call is 1,000. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTCreateOrUpdateEmailTemplateRequest">The request body to import or update email templates.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CreateOrUpdateEmailTemplatesResponse</returns>
        CreateOrUpdateEmailTemplatesResponse POSTCreateOrUpdateEmailTemplates(string authorization, POSTCreateOrUpdateEmailTemplateRequest pOSTCreateOrUpdateEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Create or update email templates
        /// </summary>
        /// <remarks>
        /// Creates email templates for standard or custom events if you do not specify email template IDs, or updates existing email templates if you specify valid email template IDs.  For each email template when you are creating email templates, whether the template is created for a standard event, a custom event, or a custom scheduled event is dependent on whether you specify the &#x60;eventCategory&#x60; or &#x60;eventTypeName&#x60; field.  - If you specify the &#x60;eventCategory&#x60; field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes. - If you specify the &#x60;eventTypeName&#x60; field, the email template is created based on the corresponding custom event or custom scheduled event. See [Event triggers](https://www.zuora.com/developer/api-reference/#tag/Event-Triggers) for more information about custom events, and [Scheduled events](https://www.zuora.com/developer/api-reference/#tag/Scheduled-Events) for more information about custom scheduled events.  The maximum number of email templates that you can create or update by one call is 1,000. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTCreateOrUpdateEmailTemplateRequest">The request body to import or update email templates.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CreateOrUpdateEmailTemplatesResponse</returns>
        ApiResponse<CreateOrUpdateEmailTemplatesResponse> POSTCreateOrUpdateEmailTemplatesWithHttpInfo(string authorization, POSTCreateOrUpdateEmailTemplateRequest pOSTCreateOrUpdateEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Resend callout notifications
        /// </summary>
        /// <remarks>
        /// Resends callout notifications if your customers did not receive previous callout notifications.  Details about the status codes and response contents of this operation are as follows:  | Scenario                               | Status code     | Response content                                            | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Success for all notifications          | 202 Accepted    | (blank)                                                     | | Success for at least one notification  | 202 Accepted    | Error code and error message of each failed notification    | | Failure for all notifications          | 400 Bad Request | Error code and error message of each failed notification    | 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTResendCalloutNotifications">The request body to resend callout notifications.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Dictionary&lt;string, ResendCalloutNotificationsFailedResponseValue&gt;</returns>
        Dictionary<string, ResendCalloutNotificationsFailedResponseValue> POSTResendCalloutNotifications(string authorization, List<string> pOSTResendCalloutNotifications, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Resend callout notifications
        /// </summary>
        /// <remarks>
        /// Resends callout notifications if your customers did not receive previous callout notifications.  Details about the status codes and response contents of this operation are as follows:  | Scenario                               | Status code     | Response content                                            | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Success for all notifications          | 202 Accepted    | (blank)                                                     | | Success for at least one notification  | 202 Accepted    | Error code and error message of each failed notification    | | Failure for all notifications          | 400 Bad Request | Error code and error message of each failed notification    | 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTResendCalloutNotifications">The request body to resend callout notifications.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Dictionary&lt;string, ResendCalloutNotificationsFailedResponseValue&gt;</returns>
        ApiResponse<Dictionary<string, ResendCalloutNotificationsFailedResponseValue>> POSTResendCalloutNotificationsWithHttpInfo(string authorization, List<string> pOSTResendCalloutNotifications, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Resend email notifications
        /// </summary>
        /// <remarks>
        /// Resends email notifications if your customers did not receive previous email notifications.  Details about the status codes and response contents of this operation are as follows:  | Scenario                               | Status code     | Response content                                            | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Success for all notifications          | 202 Accepted    | (blank)                                                     | | Success for at least one notification  | 202 Accepted    | Error code and error message of each failed notification    | | Failure for all notifications          | 400 Bad Request | Error code and error message of each failed notification    | 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTResendEmailNotifications">The request body to resend email notifications.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Dictionary&lt;string, ResendEmailNotificationsFailedResponseValue&gt;</returns>
        Dictionary<string, ResendEmailNotificationsFailedResponseValue> POSTResendEmailNotifications(string authorization, List<string> pOSTResendEmailNotifications, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Resend email notifications
        /// </summary>
        /// <remarks>
        /// Resends email notifications if your customers did not receive previous email notifications.  Details about the status codes and response contents of this operation are as follows:  | Scenario                               | Status code     | Response content                                            | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Success for all notifications          | 202 Accepted    | (blank)                                                     | | Success for at least one notification  | 202 Accepted    | Error code and error message of each failed notification    | | Failure for all notifications          | 400 Bad Request | Error code and error message of each failed notification    | 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTResendEmailNotifications">The request body to resend email notifications.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Dictionary&lt;string, ResendEmailNotificationsFailedResponseValue&gt;</returns>
        ApiResponse<Dictionary<string, ResendEmailNotificationsFailedResponseValue>> POSTResendEmailNotificationsWithHttpInfo(string authorization, List<string> pOSTResendEmailNotifications, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Update an email template
        /// </summary>
        /// <remarks>
        /// Updates an email template. This operation supports updating the email template for all event types. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template to be updated.</param>
        /// <param name="pUTPublicEmailTemplateRequest">The request body to update an email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETPublicEmailTemplateResponse</returns>
        GETPublicEmailTemplateResponse PUTUpdateEmailTemplate(string authorization, Guid id, PUTPublicEmailTemplateRequest pUTPublicEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Update an email template
        /// </summary>
        /// <remarks>
        /// Updates an email template. This operation supports updating the email template for all event types. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template to be updated.</param>
        /// <param name="pUTPublicEmailTemplateRequest">The request body to update an email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETPublicEmailTemplateResponse</returns>
        ApiResponse<GETPublicEmailTemplateResponse> PUTUpdateEmailTemplateWithHttpInfo(string authorization, Guid id, PUTPublicEmailTemplateRequest pUTPublicEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        /// <summary>
        /// Update a notification definition
        /// </summary>
        /// <remarks>
        /// Updates a notification definition.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition to be updated.</param>
        /// <param name="pUTPublicNotificationDefinitionRequest">The request body of the notification definition to be updated.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETPublicNotificationDefinitionResponse</returns>
        GETPublicNotificationDefinitionResponse PUTUpdateNotificationDefinition(string authorization, Guid id, PUTPublicNotificationDefinitionRequest pUTPublicNotificationDefinitionRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);

        /// <summary>
        /// Update a notification definition
        /// </summary>
        /// <remarks>
        /// Updates a notification definition.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition to be updated.</param>
        /// <param name="pUTPublicNotificationDefinitionRequest">The request body of the notification definition to be updated.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETPublicNotificationDefinitionResponse</returns>
        ApiResponse<GETPublicNotificationDefinitionResponse> PUTUpdateNotificationDefinitionWithHttpInfo(string authorization, Guid id, PUTPublicNotificationDefinitionRequest pUTPublicNotificationDefinitionRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface INotificationsApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Delete an email template
        /// </summary>
        /// <remarks>
        /// Deletes an email template. This operation supports deleting an email template for all event types. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DELETEDeleteEmailTemplateAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete an email template
        /// </summary>
        /// <remarks>
        /// Deletes an email template. This operation supports deleting an email template for all event types. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DELETEDeleteEmailTemplateWithHttpInfoAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete a notification definition
        /// </summary>
        /// <remarks>
        /// Deletes a notification definition.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DELETEDeleteNotificationDefinitionAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete a notification definition
        /// </summary>
        /// <remarks>
        /// Deletes a notification definition.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DELETEDeleteNotificationDefinitionWithHttpInfoAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Delete notification histories for an account
        /// </summary>
        /// <remarks>
        /// Delete all notification histories for the given account. All email and callout notifications for this account will be deleted upon successful operation. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="accountId">The ID of the account whose notification histories are to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of NotificationsHistoryDeletionTaskResponse</returns>
        System.Threading.Tasks.Task<NotificationsHistoryDeletionTaskResponse> DELETEDeleteNotificationHistoryForAccountAsync(string authorization, Guid accountId, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete notification histories for an account
        /// </summary>
        /// <remarks>
        /// Delete all notification histories for the given account. All email and callout notifications for this account will be deleted upon successful operation. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="accountId">The ID of the account whose notification histories are to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (NotificationsHistoryDeletionTaskResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<NotificationsHistoryDeletionTaskResponse>> DELETEDeleteNotificationHistoryForAccountWithHttpInfoAsync(string authorization, Guid accountId, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List callout notification histories
        /// </summary>
        /// <remarks>
        /// Describes how to get a notification history for callouts. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="endTime">The final date and time of records to be returned. Defaults to now. Use format yyyy-MM-ddTHH:mm:ss. (optional)</param>
        /// <param name="startTime">The initial date and time of records to be returned. Defaults to (end time - 1 day). Use format yyyy-MM-ddTHH:mm:ss. (optional)</param>
        /// <param name="objectId">The ID of an object that triggered a callout notification.   (optional)</param>
        /// <param name="failedOnly">If &#x60;true&#x60;, only return failed records. If &#x60;false&#x60;, return all records in the given date range. The default value is &#x60;true&#x60;.  (optional)</param>
        /// <param name="eventCategory">Category of records to be returned by event category.  The following formats are supported: * &#x60;{Event Type Namespace}:{Event Type Name}&#x60; if the Custom Events feature is enabled in your tenant. For example: &#x60;user.notification:NewSubscriptionCreated&#x60;. * Numeric code of the event category if the Custom Events feature is not enabled in your tenant. For example, &#x60;1210&#x60;. See [Event Category Code](https://knowledgecenter.zuora.com/DC_Developers/AA_REST_API/Event_Categories_for_Notification_Histories) for more information.  (optional)</param>
        /// <param name="includeResponseContent"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETCalloutHistoryVOsType</returns>
        System.Threading.Tasks.Task<GETCalloutHistoryVOsType> GETCalloutHistoryAsync(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), DateTime? endTime = default(DateTime?), DateTime? startTime = default(DateTime?), string objectId = default(string), bool? failedOnly = default(bool?), string eventCategory = default(string), bool? includeResponseContent = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List callout notification histories
        /// </summary>
        /// <remarks>
        /// Describes how to get a notification history for callouts. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="endTime">The final date and time of records to be returned. Defaults to now. Use format yyyy-MM-ddTHH:mm:ss. (optional)</param>
        /// <param name="startTime">The initial date and time of records to be returned. Defaults to (end time - 1 day). Use format yyyy-MM-ddTHH:mm:ss. (optional)</param>
        /// <param name="objectId">The ID of an object that triggered a callout notification.   (optional)</param>
        /// <param name="failedOnly">If &#x60;true&#x60;, only return failed records. If &#x60;false&#x60;, return all records in the given date range. The default value is &#x60;true&#x60;.  (optional)</param>
        /// <param name="eventCategory">Category of records to be returned by event category.  The following formats are supported: * &#x60;{Event Type Namespace}:{Event Type Name}&#x60; if the Custom Events feature is enabled in your tenant. For example: &#x60;user.notification:NewSubscriptionCreated&#x60;. * Numeric code of the event category if the Custom Events feature is not enabled in your tenant. For example, &#x60;1210&#x60;. See [Event Category Code](https://knowledgecenter.zuora.com/DC_Developers/AA_REST_API/Event_Categories_for_Notification_Histories) for more information.  (optional)</param>
        /// <param name="includeResponseContent"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETCalloutHistoryVOsType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETCalloutHistoryVOsType>> GETCalloutHistoryWithHttpInfoAsync(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), DateTime? endTime = default(DateTime?), DateTime? startTime = default(DateTime?), string objectId = default(string), bool? failedOnly = default(bool?), string eventCategory = default(string), bool? includeResponseContent = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List email notification histories
        /// </summary>
        /// <remarks>
        /// Describes how to get a notification history for notification emails.   ## Notes Request parameters and their values may be appended with a \&quot;?\&quot; following the HTTPS GET request.  Additional request parameter are separated by \&quot;&amp;\&quot;.   For example:  &#x60;GET https://rest.zuora.com/v1/notification-history/email?startTime&#x3D;2015-01-12T00:00:00&amp;endTime&#x3D;2015-01-15T00:00:00&amp;failedOnly&#x3D;false&amp;eventCategory&#x3D;1000&amp;pageSize&#x3D;1&#x60; 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="accountId">ID of an account. By specifying this query parameter, you can filter email notification histories by account. (optional)</param>
        /// <param name="endTime">The end date and time of records to be returned. Defaults to now. Use format yyyy-MM-ddTHH:mm:ss. The maximum date range (endTime - startTime) is three days. (optional)</param>
        /// <param name="startTime">The initial date and time of records to be returned. Defaults to (end time - 1 day). Use format yyyy-MM-ddTHH:mm:ss. The maximum date range (endTime - startTime) is three days. (optional)</param>
        /// <param name="objectId">The Id of an object that triggered an email notification.  (optional)</param>
        /// <param name="failedOnly">If &#x60;true&#x60;, only returns failed records. When &#x60;false&#x60;, returns all records in the given date range. Defaults to &#x60;true&#x60; when not specified.  (optional)</param>
        /// <param name="eventCategory">Category of records to be returned by event category.  The following formats are supported: * &#x60;{Event Type Namespace}:{Event Type Name}&#x60; if the Custom Events feature is enabled in your tenant. For example: &#x60;user.notification:NewSubscriptionCreated&#x60;. * Numeric code of the event category if the Custom Events feature is not enabled in your tenant. For example, &#x60;1210&#x60;. See [Event Category Code](https://knowledgecenter.zuora.com/DC_Developers/AA_REST_API/Event_Categories_for_Notification_Histories) for more information.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETEmailHistoryVOsType</returns>
        System.Threading.Tasks.Task<GETEmailHistoryVOsType> GETEmailHistoryAsync(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string accountId = default(string), DateTime? endTime = default(DateTime?), DateTime? startTime = default(DateTime?), string objectId = default(string), bool? failedOnly = default(bool?), decimal? eventCategory = default(decimal?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List email notification histories
        /// </summary>
        /// <remarks>
        /// Describes how to get a notification history for notification emails.   ## Notes Request parameters and their values may be appended with a \&quot;?\&quot; following the HTTPS GET request.  Additional request parameter are separated by \&quot;&amp;\&quot;.   For example:  &#x60;GET https://rest.zuora.com/v1/notification-history/email?startTime&#x3D;2015-01-12T00:00:00&amp;endTime&#x3D;2015-01-15T00:00:00&amp;failedOnly&#x3D;false&amp;eventCategory&#x3D;1000&amp;pageSize&#x3D;1&#x60; 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="accountId">ID of an account. By specifying this query parameter, you can filter email notification histories by account. (optional)</param>
        /// <param name="endTime">The end date and time of records to be returned. Defaults to now. Use format yyyy-MM-ddTHH:mm:ss. The maximum date range (endTime - startTime) is three days. (optional)</param>
        /// <param name="startTime">The initial date and time of records to be returned. Defaults to (end time - 1 day). Use format yyyy-MM-ddTHH:mm:ss. The maximum date range (endTime - startTime) is three days. (optional)</param>
        /// <param name="objectId">The Id of an object that triggered an email notification.  (optional)</param>
        /// <param name="failedOnly">If &#x60;true&#x60;, only returns failed records. When &#x60;false&#x60;, returns all records in the given date range. Defaults to &#x60;true&#x60; when not specified.  (optional)</param>
        /// <param name="eventCategory">Category of records to be returned by event category.  The following formats are supported: * &#x60;{Event Type Namespace}:{Event Type Name}&#x60; if the Custom Events feature is enabled in your tenant. For example: &#x60;user.notification:NewSubscriptionCreated&#x60;. * Numeric code of the event category if the Custom Events feature is not enabled in your tenant. For example, &#x60;1210&#x60;. See [Event Category Code](https://knowledgecenter.zuora.com/DC_Developers/AA_REST_API/Event_Categories_for_Notification_Histories) for more information.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETEmailHistoryVOsType)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETEmailHistoryVOsType>> GETEmailHistoryWithHttpInfoAsync(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string accountId = default(string), DateTime? endTime = default(DateTime?), DateTime? startTime = default(DateTime?), string objectId = default(string), bool? failedOnly = default(bool?), decimal? eventCategory = default(decimal?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Retrieve an email template
        /// </summary>
        /// <remarks>
        /// Queries the email template based on the specified ID. This operation supports retrieving the email template for all event types. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETPublicEmailTemplateResponse</returns>
        System.Threading.Tasks.Task<GETPublicEmailTemplateResponse> GETGetEmailTemplateAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Retrieve an email template
        /// </summary>
        /// <remarks>
        /// Queries the email template based on the specified ID. This operation supports retrieving the email template for all event types. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETPublicEmailTemplateResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETPublicEmailTemplateResponse>> GETGetEmailTemplateWithHttpInfoAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Retrieve a notification definition
        /// </summary>
        /// <remarks>
        /// Queries the notification definition of the given ID.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETPublicNotificationDefinitionResponse</returns>
        System.Threading.Tasks.Task<GETPublicNotificationDefinitionResponse> GETGetNotificationDefinitionAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Retrieve a notification definition
        /// </summary>
        /// <remarks>
        /// Queries the notification definition of the given ID.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETPublicNotificationDefinitionResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETPublicNotificationDefinitionResponse>> GETGetNotificationDefinitionWithHttpInfoAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Retrieve a notification history deletion task
        /// </summary>
        /// <remarks>
        /// Get the notification history deletion task by ID. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification history deletion task. You can get the deletion task ID from the 202 response body of the [Delete notification histories for an account](https://www.zuora.com/developer/api-reference/#operation/DELETE_Delete_Notification_History_For_Account) operation. </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of NotificationsHistoryDeletionTaskResponse</returns>
        System.Threading.Tasks.Task<NotificationsHistoryDeletionTaskResponse> GETGetNotificationHistoryDeletionTaskAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Retrieve a notification history deletion task
        /// </summary>
        /// <remarks>
        /// Get the notification history deletion task by ID. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification history deletion task. You can get the deletion task ID from the 202 response body of the [Delete notification histories for an account](https://www.zuora.com/developer/api-reference/#operation/DELETE_Delete_Notification_History_For_Account) operation. </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (NotificationsHistoryDeletionTaskResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<NotificationsHistoryDeletionTaskResponse>> GETGetNotificationHistoryDeletionTaskWithHttpInfoAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List email templates
        /// </summary>
        /// <remarks>
        /// Queries email templates. This operation supports querying email templates for all event types. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="start">The first index of the query result. (optional, default to 1)</param>
        /// <param name="limit">The maximum number of results the query should return. (optional, default to 20)</param>
        /// <param name="eventCategory">The event category code for standard events. (optional)</param>
        /// <param name="eventTypeName">The name of the custom event or custom scheduled event. (optional)</param>
        /// <param name="name">The name of the email template. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETQueryEmailTemplates200Response</returns>
        System.Threading.Tasks.Task<GETQueryEmailTemplates200Response> GETQueryEmailTemplatesAsync(string authorization, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? start = default(int?), int? limit = default(int?), decimal? eventCategory = default(decimal?), string eventTypeName = default(string), string name = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List email templates
        /// </summary>
        /// <remarks>
        /// Queries email templates. This operation supports querying email templates for all event types. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="start">The first index of the query result. (optional, default to 1)</param>
        /// <param name="limit">The maximum number of results the query should return. (optional, default to 20)</param>
        /// <param name="eventCategory">The event category code for standard events. (optional)</param>
        /// <param name="eventTypeName">The name of the custom event or custom scheduled event. (optional)</param>
        /// <param name="name">The name of the email template. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETQueryEmailTemplates200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETQueryEmailTemplates200Response>> GETQueryEmailTemplatesWithHttpInfoAsync(string authorization, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? start = default(int?), int? limit = default(int?), decimal? eventCategory = default(decimal?), string eventTypeName = default(string), string name = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// List notification definitions
        /// </summary>
        /// <remarks>
        /// Queries notification definitions with the specified filters.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="start">The first index of the query result. (optional, default to 1)</param>
        /// <param name="limit">The maximum number of results the query should return. (optional, default to 20)</param>
        /// <param name="profileId">Id of the profile. (optional)</param>
        /// <param name="eventTypeName">The name of the event. (optional)</param>
        /// <param name="emailTemplateId">The ID of the email template. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETQueryNotificationDefinitions200Response</returns>
        System.Threading.Tasks.Task<GETQueryNotificationDefinitions200Response> GETQueryNotificationDefinitionsAsync(string authorization, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? start = default(int?), int? limit = default(int?), Guid? profileId = default(Guid?), string eventTypeName = default(string), Guid? emailTemplateId = default(Guid?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// List notification definitions
        /// </summary>
        /// <remarks>
        /// Queries notification definitions with the specified filters.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="start">The first index of the query result. (optional, default to 1)</param>
        /// <param name="limit">The maximum number of results the query should return. (optional, default to 20)</param>
        /// <param name="profileId">Id of the profile. (optional)</param>
        /// <param name="eventTypeName">The name of the event. (optional)</param>
        /// <param name="emailTemplateId">The ID of the email template. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETQueryNotificationDefinitions200Response)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETQueryNotificationDefinitions200Response>> GETQueryNotificationDefinitionsWithHttpInfoAsync(string authorization, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? start = default(int?), int? limit = default(int?), Guid? profileId = default(Guid?), string eventTypeName = default(string), Guid? emailTemplateId = default(Guid?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create an email template
        /// </summary>
        /// <remarks>
        /// Creates an email template.   This operation supports creating the email template for all event types.  - If you specify the &#x60;eventCategory&#x60; field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes. - If you specify the &#x60;eventTypeName&#x60; field, the email template is created based on the corresponding custom event or custom scheduled event. See [Event triggers](https://www.zuora.com/developer/api-reference/#tag/Event-Triggers) for more information about custom events, and [Scheduled events](https://www.zuora.com/developer/api-reference/#tag/Scheduled-Events) for more information about custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTPublicEmailTemplateRequest">The request body to create an email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETPublicEmailTemplateResponse</returns>
        System.Threading.Tasks.Task<GETPublicEmailTemplateResponse> POSTCreateEmailTemplateAsync(string authorization, POSTPublicEmailTemplateRequest pOSTPublicEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create an email template
        /// </summary>
        /// <remarks>
        /// Creates an email template.   This operation supports creating the email template for all event types.  - If you specify the &#x60;eventCategory&#x60; field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes. - If you specify the &#x60;eventTypeName&#x60; field, the email template is created based on the corresponding custom event or custom scheduled event. See [Event triggers](https://www.zuora.com/developer/api-reference/#tag/Event-Triggers) for more information about custom events, and [Scheduled events](https://www.zuora.com/developer/api-reference/#tag/Scheduled-Events) for more information about custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTPublicEmailTemplateRequest">The request body to create an email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETPublicEmailTemplateResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETPublicEmailTemplateResponse>> POSTCreateEmailTemplateWithHttpInfoAsync(string authorization, POSTPublicEmailTemplateRequest pOSTPublicEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create a notification definition
        /// </summary>
        /// <remarks>
        /// Creates a notification definition. If a filter rule is specified, it will be evaluated to see if the notification definition is qualified to handle the incoming events  during runtime. If the notification is qualified, it will send the email and invoke the callout if it has an email template or a callout. See a step-by-step guide for [creating a custom notification](https://www.zuora.com/developer/api-guides/#Callout-to-external-system-for-provisioning-or-entitlements) in [Zuora API Guides](https://www.zuora.com/developer/api-guides/).  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="entity">The request body used to create the notification definition.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETPublicNotificationDefinitionResponse</returns>
        System.Threading.Tasks.Task<GETPublicNotificationDefinitionResponse> POSTCreateNotificationDefinitionAsync(string authorization, POSTPublicNotificationDefinitionRequest entity, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create a notification definition
        /// </summary>
        /// <remarks>
        /// Creates a notification definition. If a filter rule is specified, it will be evaluated to see if the notification definition is qualified to handle the incoming events  during runtime. If the notification is qualified, it will send the email and invoke the callout if it has an email template or a callout. See a step-by-step guide for [creating a custom notification](https://www.zuora.com/developer/api-guides/#Callout-to-external-system-for-provisioning-or-entitlements) in [Zuora API Guides](https://www.zuora.com/developer/api-guides/).  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="entity">The request body used to create the notification definition.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETPublicNotificationDefinitionResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETPublicNotificationDefinitionResponse>> POSTCreateNotificationDefinitionWithHttpInfoAsync(string authorization, POSTPublicNotificationDefinitionRequest entity, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create or update email templates
        /// </summary>
        /// <remarks>
        /// Creates email templates for standard or custom events if you do not specify email template IDs, or updates existing email templates if you specify valid email template IDs.  For each email template when you are creating email templates, whether the template is created for a standard event, a custom event, or a custom scheduled event is dependent on whether you specify the &#x60;eventCategory&#x60; or &#x60;eventTypeName&#x60; field.  - If you specify the &#x60;eventCategory&#x60; field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes. - If you specify the &#x60;eventTypeName&#x60; field, the email template is created based on the corresponding custom event or custom scheduled event. See [Event triggers](https://www.zuora.com/developer/api-reference/#tag/Event-Triggers) for more information about custom events, and [Scheduled events](https://www.zuora.com/developer/api-reference/#tag/Scheduled-Events) for more information about custom scheduled events.  The maximum number of email templates that you can create or update by one call is 1,000. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTCreateOrUpdateEmailTemplateRequest">The request body to import or update email templates.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CreateOrUpdateEmailTemplatesResponse</returns>
        System.Threading.Tasks.Task<CreateOrUpdateEmailTemplatesResponse> POSTCreateOrUpdateEmailTemplatesAsync(string authorization, POSTCreateOrUpdateEmailTemplateRequest pOSTCreateOrUpdateEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create or update email templates
        /// </summary>
        /// <remarks>
        /// Creates email templates for standard or custom events if you do not specify email template IDs, or updates existing email templates if you specify valid email template IDs.  For each email template when you are creating email templates, whether the template is created for a standard event, a custom event, or a custom scheduled event is dependent on whether you specify the &#x60;eventCategory&#x60; or &#x60;eventTypeName&#x60; field.  - If you specify the &#x60;eventCategory&#x60; field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes. - If you specify the &#x60;eventTypeName&#x60; field, the email template is created based on the corresponding custom event or custom scheduled event. See [Event triggers](https://www.zuora.com/developer/api-reference/#tag/Event-Triggers) for more information about custom events, and [Scheduled events](https://www.zuora.com/developer/api-reference/#tag/Scheduled-Events) for more information about custom scheduled events.  The maximum number of email templates that you can create or update by one call is 1,000. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTCreateOrUpdateEmailTemplateRequest">The request body to import or update email templates.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CreateOrUpdateEmailTemplatesResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<CreateOrUpdateEmailTemplatesResponse>> POSTCreateOrUpdateEmailTemplatesWithHttpInfoAsync(string authorization, POSTCreateOrUpdateEmailTemplateRequest pOSTCreateOrUpdateEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Resend callout notifications
        /// </summary>
        /// <remarks>
        /// Resends callout notifications if your customers did not receive previous callout notifications.  Details about the status codes and response contents of this operation are as follows:  | Scenario                               | Status code     | Response content                                            | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Success for all notifications          | 202 Accepted    | (blank)                                                     | | Success for at least one notification  | 202 Accepted    | Error code and error message of each failed notification    | | Failure for all notifications          | 400 Bad Request | Error code and error message of each failed notification    | 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTResendCalloutNotifications">The request body to resend callout notifications.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Dictionary&lt;string, ResendCalloutNotificationsFailedResponseValue&gt;</returns>
        System.Threading.Tasks.Task<Dictionary<string, ResendCalloutNotificationsFailedResponseValue>> POSTResendCalloutNotificationsAsync(string authorization, List<string> pOSTResendCalloutNotifications, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Resend callout notifications
        /// </summary>
        /// <remarks>
        /// Resends callout notifications if your customers did not receive previous callout notifications.  Details about the status codes and response contents of this operation are as follows:  | Scenario                               | Status code     | Response content                                            | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Success for all notifications          | 202 Accepted    | (blank)                                                     | | Success for at least one notification  | 202 Accepted    | Error code and error message of each failed notification    | | Failure for all notifications          | 400 Bad Request | Error code and error message of each failed notification    | 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTResendCalloutNotifications">The request body to resend callout notifications.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, ResendCalloutNotificationsFailedResponseValue&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<Dictionary<string, ResendCalloutNotificationsFailedResponseValue>>> POSTResendCalloutNotificationsWithHttpInfoAsync(string authorization, List<string> pOSTResendCalloutNotifications, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Resend email notifications
        /// </summary>
        /// <remarks>
        /// Resends email notifications if your customers did not receive previous email notifications.  Details about the status codes and response contents of this operation are as follows:  | Scenario                               | Status code     | Response content                                            | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Success for all notifications          | 202 Accepted    | (blank)                                                     | | Success for at least one notification  | 202 Accepted    | Error code and error message of each failed notification    | | Failure for all notifications          | 400 Bad Request | Error code and error message of each failed notification    | 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTResendEmailNotifications">The request body to resend email notifications.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Dictionary&lt;string, ResendEmailNotificationsFailedResponseValue&gt;</returns>
        System.Threading.Tasks.Task<Dictionary<string, ResendEmailNotificationsFailedResponseValue>> POSTResendEmailNotificationsAsync(string authorization, List<string> pOSTResendEmailNotifications, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Resend email notifications
        /// </summary>
        /// <remarks>
        /// Resends email notifications if your customers did not receive previous email notifications.  Details about the status codes and response contents of this operation are as follows:  | Scenario                               | Status code     | Response content                                            | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Success for all notifications          | 202 Accepted    | (blank)                                                     | | Success for at least one notification  | 202 Accepted    | Error code and error message of each failed notification    | | Failure for all notifications          | 400 Bad Request | Error code and error message of each failed notification    | 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTResendEmailNotifications">The request body to resend email notifications.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, ResendEmailNotificationsFailedResponseValue&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<Dictionary<string, ResendEmailNotificationsFailedResponseValue>>> POSTResendEmailNotificationsWithHttpInfoAsync(string authorization, List<string> pOSTResendEmailNotifications, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update an email template
        /// </summary>
        /// <remarks>
        /// Updates an email template. This operation supports updating the email template for all event types. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template to be updated.</param>
        /// <param name="pUTPublicEmailTemplateRequest">The request body to update an email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETPublicEmailTemplateResponse</returns>
        System.Threading.Tasks.Task<GETPublicEmailTemplateResponse> PUTUpdateEmailTemplateAsync(string authorization, Guid id, PUTPublicEmailTemplateRequest pUTPublicEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update an email template
        /// </summary>
        /// <remarks>
        /// Updates an email template. This operation supports updating the email template for all event types. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template to be updated.</param>
        /// <param name="pUTPublicEmailTemplateRequest">The request body to update an email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETPublicEmailTemplateResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETPublicEmailTemplateResponse>> PUTUpdateEmailTemplateWithHttpInfoAsync(string authorization, Guid id, PUTPublicEmailTemplateRequest pUTPublicEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Update a notification definition
        /// </summary>
        /// <remarks>
        /// Updates a notification definition.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition to be updated.</param>
        /// <param name="pUTPublicNotificationDefinitionRequest">The request body of the notification definition to be updated.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETPublicNotificationDefinitionResponse</returns>
        System.Threading.Tasks.Task<GETPublicNotificationDefinitionResponse> PUTUpdateNotificationDefinitionAsync(string authorization, Guid id, PUTPublicNotificationDefinitionRequest pUTPublicNotificationDefinitionRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Update a notification definition
        /// </summary>
        /// <remarks>
        /// Updates a notification definition.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </remarks>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition to be updated.</param>
        /// <param name="pUTPublicNotificationDefinitionRequest">The request body of the notification definition to be updated.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETPublicNotificationDefinitionResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GETPublicNotificationDefinitionResponse>> PUTUpdateNotificationDefinitionWithHttpInfoAsync(string authorization, Guid id, PUTPublicNotificationDefinitionRequest pUTPublicNotificationDefinitionRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface INotificationsApi : INotificationsApiSync, INotificationsApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class NotificationsApi : INotificationsApi
    {
        private ZuoraClient.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public NotificationsApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public NotificationsApi(string basePath)
        {
            this.Configuration = ZuoraClient.Client.Configuration.MergeConfigurations(
                ZuoraClient.Client.GlobalConfiguration.Instance,
                new ZuoraClient.Client.Configuration { BasePath = basePath }
            );
            this.Client = new ZuoraClient.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new ZuoraClient.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = ZuoraClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationsApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public NotificationsApi(ZuoraClient.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = ZuoraClient.Client.Configuration.MergeConfigurations(
                ZuoraClient.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new ZuoraClient.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new ZuoraClient.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = ZuoraClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationsApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public NotificationsApi(ZuoraClient.Client.ISynchronousClient client, ZuoraClient.Client.IAsynchronousClient asyncClient, ZuoraClient.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = ZuoraClient.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public ZuoraClient.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public ZuoraClient.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public ZuoraClient.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ZuoraClient.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Delete an email template Deletes an email template. This operation supports deleting an email template for all event types. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void DELETEDeleteEmailTemplate(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            DELETEDeleteEmailTemplateWithHttpInfo(authorization, id, zuoraTrackId, zuoraEntityIds);
        }

        /// <summary>
        /// Delete an email template Deletes an email template. This operation supports deleting an email template for all event types. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ZuoraClient.Client.ApiResponse<Object> DELETEDeleteEmailTemplateWithHttpInfo(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->DELETEDeleteEmailTemplate");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", ZuoraClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.DELETEDeleteEmailTemplate";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/notifications/email-templates/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DELETEDeleteEmailTemplate", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete an email template Deletes an email template. This operation supports deleting an email template for all event types. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DELETEDeleteEmailTemplateAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await DELETEDeleteEmailTemplateWithHttpInfoAsync(authorization, id, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete an email template Deletes an email template. This operation supports deleting an email template for all event types. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<Object>> DELETEDeleteEmailTemplateWithHttpInfoAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->DELETEDeleteEmailTemplate");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", ZuoraClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.DELETEDeleteEmailTemplate";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/notifications/email-templates/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DELETEDeleteEmailTemplate", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a notification definition Deletes a notification definition.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns></returns>
        public void DELETEDeleteNotificationDefinition(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            DELETEDeleteNotificationDefinitionWithHttpInfo(authorization, id, zuoraTrackId, zuoraEntityIds);
        }

        /// <summary>
        /// Delete a notification definition Deletes a notification definition.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Object(void)</returns>
        public ZuoraClient.Client.ApiResponse<Object> DELETEDeleteNotificationDefinitionWithHttpInfo(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->DELETEDeleteNotificationDefinition");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", ZuoraClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.DELETEDeleteNotificationDefinition";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Object>("/notifications/notification-definitions/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DELETEDeleteNotificationDefinition", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete a notification definition Deletes a notification definition.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DELETEDeleteNotificationDefinitionAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await DELETEDeleteNotificationDefinitionWithHttpInfoAsync(authorization, id, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Delete a notification definition Deletes a notification definition.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<Object>> DELETEDeleteNotificationDefinitionWithHttpInfoAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->DELETEDeleteNotificationDefinition");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", ZuoraClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.DELETEDeleteNotificationDefinition";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Object>("/notifications/notification-definitions/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DELETEDeleteNotificationDefinition", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete notification histories for an account Delete all notification histories for the given account. All email and callout notifications for this account will be deleted upon successful operation. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="accountId">The ID of the account whose notification histories are to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>NotificationsHistoryDeletionTaskResponse</returns>
        public NotificationsHistoryDeletionTaskResponse DELETEDeleteNotificationHistoryForAccount(string authorization, Guid accountId, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<NotificationsHistoryDeletionTaskResponse> localVarResponse = DELETEDeleteNotificationHistoryForAccountWithHttpInfo(authorization, accountId, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Delete notification histories for an account Delete all notification histories for the given account. All email and callout notifications for this account will be deleted upon successful operation. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="accountId">The ID of the account whose notification histories are to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of NotificationsHistoryDeletionTaskResponse</returns>
        public ZuoraClient.Client.ApiResponse<NotificationsHistoryDeletionTaskResponse> DELETEDeleteNotificationHistoryForAccountWithHttpInfo(string authorization, Guid accountId, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->DELETEDeleteNotificationHistoryForAccount");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.DELETEDeleteNotificationHistoryForAccount";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Delete<NotificationsHistoryDeletionTaskResponse>("/notifications/history", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DELETEDeleteNotificationHistoryForAccount", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete notification histories for an account Delete all notification histories for the given account. All email and callout notifications for this account will be deleted upon successful operation. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="accountId">The ID of the account whose notification histories are to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of NotificationsHistoryDeletionTaskResponse</returns>
        public async System.Threading.Tasks.Task<NotificationsHistoryDeletionTaskResponse> DELETEDeleteNotificationHistoryForAccountAsync(string authorization, Guid accountId, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<NotificationsHistoryDeletionTaskResponse> localVarResponse = await DELETEDeleteNotificationHistoryForAccountWithHttpInfoAsync(authorization, accountId, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Delete notification histories for an account Delete all notification histories for the given account. All email and callout notifications for this account will be deleted upon successful operation. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="accountId">The ID of the account whose notification histories are to be deleted.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (NotificationsHistoryDeletionTaskResponse)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<NotificationsHistoryDeletionTaskResponse>> DELETEDeleteNotificationHistoryForAccountWithHttpInfoAsync(string authorization, Guid accountId, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->DELETEDeleteNotificationHistoryForAccount");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.DELETEDeleteNotificationHistoryForAccount";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<NotificationsHistoryDeletionTaskResponse>("/notifications/history", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DELETEDeleteNotificationHistoryForAccount", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List callout notification histories Describes how to get a notification history for callouts. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="endTime">The final date and time of records to be returned. Defaults to now. Use format yyyy-MM-ddTHH:mm:ss. (optional)</param>
        /// <param name="startTime">The initial date and time of records to be returned. Defaults to (end time - 1 day). Use format yyyy-MM-ddTHH:mm:ss. (optional)</param>
        /// <param name="objectId">The ID of an object that triggered a callout notification.   (optional)</param>
        /// <param name="failedOnly">If &#x60;true&#x60;, only return failed records. If &#x60;false&#x60;, return all records in the given date range. The default value is &#x60;true&#x60;.  (optional)</param>
        /// <param name="eventCategory">Category of records to be returned by event category.  The following formats are supported: * &#x60;{Event Type Namespace}:{Event Type Name}&#x60; if the Custom Events feature is enabled in your tenant. For example: &#x60;user.notification:NewSubscriptionCreated&#x60;. * Numeric code of the event category if the Custom Events feature is not enabled in your tenant. For example, &#x60;1210&#x60;. See [Event Category Code](https://knowledgecenter.zuora.com/DC_Developers/AA_REST_API/Event_Categories_for_Notification_Histories) for more information.  (optional)</param>
        /// <param name="includeResponseContent"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETCalloutHistoryVOsType</returns>
        public GETCalloutHistoryVOsType GETCalloutHistory(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), DateTime? endTime = default(DateTime?), DateTime? startTime = default(DateTime?), string objectId = default(string), bool? failedOnly = default(bool?), string eventCategory = default(string), bool? includeResponseContent = default(bool?), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETCalloutHistoryVOsType> localVarResponse = GETCalloutHistoryWithHttpInfo(authorization, zuoraTrackId, zuoraEntityIds, page, pageSize, endTime, startTime, objectId, failedOnly, eventCategory, includeResponseContent);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List callout notification histories Describes how to get a notification history for callouts. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="endTime">The final date and time of records to be returned. Defaults to now. Use format yyyy-MM-ddTHH:mm:ss. (optional)</param>
        /// <param name="startTime">The initial date and time of records to be returned. Defaults to (end time - 1 day). Use format yyyy-MM-ddTHH:mm:ss. (optional)</param>
        /// <param name="objectId">The ID of an object that triggered a callout notification.   (optional)</param>
        /// <param name="failedOnly">If &#x60;true&#x60;, only return failed records. If &#x60;false&#x60;, return all records in the given date range. The default value is &#x60;true&#x60;.  (optional)</param>
        /// <param name="eventCategory">Category of records to be returned by event category.  The following formats are supported: * &#x60;{Event Type Namespace}:{Event Type Name}&#x60; if the Custom Events feature is enabled in your tenant. For example: &#x60;user.notification:NewSubscriptionCreated&#x60;. * Numeric code of the event category if the Custom Events feature is not enabled in your tenant. For example, &#x60;1210&#x60;. See [Event Category Code](https://knowledgecenter.zuora.com/DC_Developers/AA_REST_API/Event_Categories_for_Notification_Histories) for more information.  (optional)</param>
        /// <param name="includeResponseContent"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETCalloutHistoryVOsType</returns>
        public ZuoraClient.Client.ApiResponse<GETCalloutHistoryVOsType> GETCalloutHistoryWithHttpInfo(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), DateTime? endTime = default(DateTime?), DateTime? startTime = default(DateTime?), string objectId = default(string), bool? failedOnly = default(bool?), string eventCategory = default(string), bool? includeResponseContent = default(bool?), int operationIndex = 0)
        {
            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
            }
            if (endTime != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "endTime", endTime));
            }
            if (startTime != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "startTime", startTime));
            }
            if (objectId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "objectId", objectId));
            }
            if (failedOnly != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "failedOnly", failedOnly));
            }
            if (eventCategory != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "eventCategory", eventCategory));
            }
            if (includeResponseContent != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "includeResponseContent", includeResponseContent));
            }
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.GETCalloutHistory";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GETCalloutHistoryVOsType>("/v1/notification-history/callout", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETCalloutHistory", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List callout notification histories Describes how to get a notification history for callouts. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="endTime">The final date and time of records to be returned. Defaults to now. Use format yyyy-MM-ddTHH:mm:ss. (optional)</param>
        /// <param name="startTime">The initial date and time of records to be returned. Defaults to (end time - 1 day). Use format yyyy-MM-ddTHH:mm:ss. (optional)</param>
        /// <param name="objectId">The ID of an object that triggered a callout notification.   (optional)</param>
        /// <param name="failedOnly">If &#x60;true&#x60;, only return failed records. If &#x60;false&#x60;, return all records in the given date range. The default value is &#x60;true&#x60;.  (optional)</param>
        /// <param name="eventCategory">Category of records to be returned by event category.  The following formats are supported: * &#x60;{Event Type Namespace}:{Event Type Name}&#x60; if the Custom Events feature is enabled in your tenant. For example: &#x60;user.notification:NewSubscriptionCreated&#x60;. * Numeric code of the event category if the Custom Events feature is not enabled in your tenant. For example, &#x60;1210&#x60;. See [Event Category Code](https://knowledgecenter.zuora.com/DC_Developers/AA_REST_API/Event_Categories_for_Notification_Histories) for more information.  (optional)</param>
        /// <param name="includeResponseContent"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETCalloutHistoryVOsType</returns>
        public async System.Threading.Tasks.Task<GETCalloutHistoryVOsType> GETCalloutHistoryAsync(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), DateTime? endTime = default(DateTime?), DateTime? startTime = default(DateTime?), string objectId = default(string), bool? failedOnly = default(bool?), string eventCategory = default(string), bool? includeResponseContent = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETCalloutHistoryVOsType> localVarResponse = await GETCalloutHistoryWithHttpInfoAsync(authorization, zuoraTrackId, zuoraEntityIds, page, pageSize, endTime, startTime, objectId, failedOnly, eventCategory, includeResponseContent, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List callout notification histories Describes how to get a notification history for callouts. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="endTime">The final date and time of records to be returned. Defaults to now. Use format yyyy-MM-ddTHH:mm:ss. (optional)</param>
        /// <param name="startTime">The initial date and time of records to be returned. Defaults to (end time - 1 day). Use format yyyy-MM-ddTHH:mm:ss. (optional)</param>
        /// <param name="objectId">The ID of an object that triggered a callout notification.   (optional)</param>
        /// <param name="failedOnly">If &#x60;true&#x60;, only return failed records. If &#x60;false&#x60;, return all records in the given date range. The default value is &#x60;true&#x60;.  (optional)</param>
        /// <param name="eventCategory">Category of records to be returned by event category.  The following formats are supported: * &#x60;{Event Type Namespace}:{Event Type Name}&#x60; if the Custom Events feature is enabled in your tenant. For example: &#x60;user.notification:NewSubscriptionCreated&#x60;. * Numeric code of the event category if the Custom Events feature is not enabled in your tenant. For example, &#x60;1210&#x60;. See [Event Category Code](https://knowledgecenter.zuora.com/DC_Developers/AA_REST_API/Event_Categories_for_Notification_Histories) for more information.  (optional)</param>
        /// <param name="includeResponseContent"> (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETCalloutHistoryVOsType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETCalloutHistoryVOsType>> GETCalloutHistoryWithHttpInfoAsync(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), DateTime? endTime = default(DateTime?), DateTime? startTime = default(DateTime?), string objectId = default(string), bool? failedOnly = default(bool?), string eventCategory = default(string), bool? includeResponseContent = default(bool?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
            }
            if (endTime != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "endTime", endTime));
            }
            if (startTime != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "startTime", startTime));
            }
            if (objectId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "objectId", objectId));
            }
            if (failedOnly != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "failedOnly", failedOnly));
            }
            if (eventCategory != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "eventCategory", eventCategory));
            }
            if (includeResponseContent != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "includeResponseContent", includeResponseContent));
            }
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.GETCalloutHistory";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GETCalloutHistoryVOsType>("/v1/notification-history/callout", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETCalloutHistory", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List email notification histories Describes how to get a notification history for notification emails.   ## Notes Request parameters and their values may be appended with a \&quot;?\&quot; following the HTTPS GET request.  Additional request parameter are separated by \&quot;&amp;\&quot;.   For example:  &#x60;GET https://rest.zuora.com/v1/notification-history/email?startTime&#x3D;2015-01-12T00:00:00&amp;endTime&#x3D;2015-01-15T00:00:00&amp;failedOnly&#x3D;false&amp;eventCategory&#x3D;1000&amp;pageSize&#x3D;1&#x60; 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="accountId">ID of an account. By specifying this query parameter, you can filter email notification histories by account. (optional)</param>
        /// <param name="endTime">The end date and time of records to be returned. Defaults to now. Use format yyyy-MM-ddTHH:mm:ss. The maximum date range (endTime - startTime) is three days. (optional)</param>
        /// <param name="startTime">The initial date and time of records to be returned. Defaults to (end time - 1 day). Use format yyyy-MM-ddTHH:mm:ss. The maximum date range (endTime - startTime) is three days. (optional)</param>
        /// <param name="objectId">The Id of an object that triggered an email notification.  (optional)</param>
        /// <param name="failedOnly">If &#x60;true&#x60;, only returns failed records. When &#x60;false&#x60;, returns all records in the given date range. Defaults to &#x60;true&#x60; when not specified.  (optional)</param>
        /// <param name="eventCategory">Category of records to be returned by event category.  The following formats are supported: * &#x60;{Event Type Namespace}:{Event Type Name}&#x60; if the Custom Events feature is enabled in your tenant. For example: &#x60;user.notification:NewSubscriptionCreated&#x60;. * Numeric code of the event category if the Custom Events feature is not enabled in your tenant. For example, &#x60;1210&#x60;. See [Event Category Code](https://knowledgecenter.zuora.com/DC_Developers/AA_REST_API/Event_Categories_for_Notification_Histories) for more information.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETEmailHistoryVOsType</returns>
        public GETEmailHistoryVOsType GETEmailHistory(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string accountId = default(string), DateTime? endTime = default(DateTime?), DateTime? startTime = default(DateTime?), string objectId = default(string), bool? failedOnly = default(bool?), decimal? eventCategory = default(decimal?), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETEmailHistoryVOsType> localVarResponse = GETEmailHistoryWithHttpInfo(authorization, zuoraTrackId, zuoraEntityIds, page, pageSize, accountId, endTime, startTime, objectId, failedOnly, eventCategory);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List email notification histories Describes how to get a notification history for notification emails.   ## Notes Request parameters and their values may be appended with a \&quot;?\&quot; following the HTTPS GET request.  Additional request parameter are separated by \&quot;&amp;\&quot;.   For example:  &#x60;GET https://rest.zuora.com/v1/notification-history/email?startTime&#x3D;2015-01-12T00:00:00&amp;endTime&#x3D;2015-01-15T00:00:00&amp;failedOnly&#x3D;false&amp;eventCategory&#x3D;1000&amp;pageSize&#x3D;1&#x60; 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="accountId">ID of an account. By specifying this query parameter, you can filter email notification histories by account. (optional)</param>
        /// <param name="endTime">The end date and time of records to be returned. Defaults to now. Use format yyyy-MM-ddTHH:mm:ss. The maximum date range (endTime - startTime) is three days. (optional)</param>
        /// <param name="startTime">The initial date and time of records to be returned. Defaults to (end time - 1 day). Use format yyyy-MM-ddTHH:mm:ss. The maximum date range (endTime - startTime) is three days. (optional)</param>
        /// <param name="objectId">The Id of an object that triggered an email notification.  (optional)</param>
        /// <param name="failedOnly">If &#x60;true&#x60;, only returns failed records. When &#x60;false&#x60;, returns all records in the given date range. Defaults to &#x60;true&#x60; when not specified.  (optional)</param>
        /// <param name="eventCategory">Category of records to be returned by event category.  The following formats are supported: * &#x60;{Event Type Namespace}:{Event Type Name}&#x60; if the Custom Events feature is enabled in your tenant. For example: &#x60;user.notification:NewSubscriptionCreated&#x60;. * Numeric code of the event category if the Custom Events feature is not enabled in your tenant. For example, &#x60;1210&#x60;. See [Event Category Code](https://knowledgecenter.zuora.com/DC_Developers/AA_REST_API/Event_Categories_for_Notification_Histories) for more information.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETEmailHistoryVOsType</returns>
        public ZuoraClient.Client.ApiResponse<GETEmailHistoryVOsType> GETEmailHistoryWithHttpInfo(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string accountId = default(string), DateTime? endTime = default(DateTime?), DateTime? startTime = default(DateTime?), string objectId = default(string), bool? failedOnly = default(bool?), decimal? eventCategory = default(decimal?), int operationIndex = 0)
        {
            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
            }
            if (accountId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            }
            if (endTime != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "endTime", endTime));
            }
            if (startTime != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "startTime", startTime));
            }
            if (objectId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "objectId", objectId));
            }
            if (failedOnly != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "failedOnly", failedOnly));
            }
            if (eventCategory != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "eventCategory", eventCategory));
            }
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.GETEmailHistory";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GETEmailHistoryVOsType>("/v1/notification-history/email", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETEmailHistory", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List email notification histories Describes how to get a notification history for notification emails.   ## Notes Request parameters and their values may be appended with a \&quot;?\&quot; following the HTTPS GET request.  Additional request parameter are separated by \&quot;&amp;\&quot;.   For example:  &#x60;GET https://rest.zuora.com/v1/notification-history/email?startTime&#x3D;2015-01-12T00:00:00&amp;endTime&#x3D;2015-01-15T00:00:00&amp;failedOnly&#x3D;false&amp;eventCategory&#x3D;1000&amp;pageSize&#x3D;1&#x60; 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="accountId">ID of an account. By specifying this query parameter, you can filter email notification histories by account. (optional)</param>
        /// <param name="endTime">The end date and time of records to be returned. Defaults to now. Use format yyyy-MM-ddTHH:mm:ss. The maximum date range (endTime - startTime) is three days. (optional)</param>
        /// <param name="startTime">The initial date and time of records to be returned. Defaults to (end time - 1 day). Use format yyyy-MM-ddTHH:mm:ss. The maximum date range (endTime - startTime) is three days. (optional)</param>
        /// <param name="objectId">The Id of an object that triggered an email notification.  (optional)</param>
        /// <param name="failedOnly">If &#x60;true&#x60;, only returns failed records. When &#x60;false&#x60;, returns all records in the given date range. Defaults to &#x60;true&#x60; when not specified.  (optional)</param>
        /// <param name="eventCategory">Category of records to be returned by event category.  The following formats are supported: * &#x60;{Event Type Namespace}:{Event Type Name}&#x60; if the Custom Events feature is enabled in your tenant. For example: &#x60;user.notification:NewSubscriptionCreated&#x60;. * Numeric code of the event category if the Custom Events feature is not enabled in your tenant. For example, &#x60;1210&#x60;. See [Event Category Code](https://knowledgecenter.zuora.com/DC_Developers/AA_REST_API/Event_Categories_for_Notification_Histories) for more information.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETEmailHistoryVOsType</returns>
        public async System.Threading.Tasks.Task<GETEmailHistoryVOsType> GETEmailHistoryAsync(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string accountId = default(string), DateTime? endTime = default(DateTime?), DateTime? startTime = default(DateTime?), string objectId = default(string), bool? failedOnly = default(bool?), decimal? eventCategory = default(decimal?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETEmailHistoryVOsType> localVarResponse = await GETEmailHistoryWithHttpInfoAsync(authorization, zuoraTrackId, zuoraEntityIds, page, pageSize, accountId, endTime, startTime, objectId, failedOnly, eventCategory, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List email notification histories Describes how to get a notification history for notification emails.   ## Notes Request parameters and their values may be appended with a \&quot;?\&quot; following the HTTPS GET request.  Additional request parameter are separated by \&quot;&amp;\&quot;.   For example:  &#x60;GET https://rest.zuora.com/v1/notification-history/email?startTime&#x3D;2015-01-12T00:00:00&amp;endTime&#x3D;2015-01-15T00:00:00&amp;failedOnly&#x3D;false&amp;eventCategory&#x3D;1000&amp;pageSize&#x3D;1&#x60; 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken).  (optional)</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="page">The index number of the page that you want to retrieve. This parameter is dependent on &#x60;pageSize&#x60;. You must set &#x60;pageSize&#x60; before specifying &#x60;page&#x60;. For example, if you set &#x60;pageSize&#x60; to &#x60;20&#x60; and &#x60;page&#x60; to &#x60;2&#x60;, the 21st to 40th records are returned in the response.  (optional, default to 1)</param>
        /// <param name="pageSize">The number of records returned per page in the response.  (optional, default to 20)</param>
        /// <param name="accountId">ID of an account. By specifying this query parameter, you can filter email notification histories by account. (optional)</param>
        /// <param name="endTime">The end date and time of records to be returned. Defaults to now. Use format yyyy-MM-ddTHH:mm:ss. The maximum date range (endTime - startTime) is three days. (optional)</param>
        /// <param name="startTime">The initial date and time of records to be returned. Defaults to (end time - 1 day). Use format yyyy-MM-ddTHH:mm:ss. The maximum date range (endTime - startTime) is three days. (optional)</param>
        /// <param name="objectId">The Id of an object that triggered an email notification.  (optional)</param>
        /// <param name="failedOnly">If &#x60;true&#x60;, only returns failed records. When &#x60;false&#x60;, returns all records in the given date range. Defaults to &#x60;true&#x60; when not specified.  (optional)</param>
        /// <param name="eventCategory">Category of records to be returned by event category.  The following formats are supported: * &#x60;{Event Type Namespace}:{Event Type Name}&#x60; if the Custom Events feature is enabled in your tenant. For example: &#x60;user.notification:NewSubscriptionCreated&#x60;. * Numeric code of the event category if the Custom Events feature is not enabled in your tenant. For example, &#x60;1210&#x60;. See [Event Category Code](https://knowledgecenter.zuora.com/DC_Developers/AA_REST_API/Event_Categories_for_Notification_Histories) for more information.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETEmailHistoryVOsType)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETEmailHistoryVOsType>> GETEmailHistoryWithHttpInfoAsync(string authorization = default(string), string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? page = default(int?), int? pageSize = default(int?), string accountId = default(string), DateTime? endTime = default(DateTime?), DateTime? startTime = default(DateTime?), string objectId = default(string), bool? failedOnly = default(bool?), decimal? eventCategory = default(decimal?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (page != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "page", page));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "pageSize", pageSize));
            }
            if (accountId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "accountId", accountId));
            }
            if (endTime != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "endTime", endTime));
            }
            if (startTime != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "startTime", startTime));
            }
            if (objectId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "objectId", objectId));
            }
            if (failedOnly != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "failedOnly", failedOnly));
            }
            if (eventCategory != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "eventCategory", eventCategory));
            }
            if (authorization != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            }
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.GETEmailHistory";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GETEmailHistoryVOsType>("/v1/notification-history/email", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETEmailHistory", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve an email template Queries the email template based on the specified ID. This operation supports retrieving the email template for all event types. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETPublicEmailTemplateResponse</returns>
        public GETPublicEmailTemplateResponse GETGetEmailTemplate(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETPublicEmailTemplateResponse> localVarResponse = GETGetEmailTemplateWithHttpInfo(authorization, id, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve an email template Queries the email template based on the specified ID. This operation supports retrieving the email template for all event types. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETPublicEmailTemplateResponse</returns>
        public ZuoraClient.Client.ApiResponse<GETPublicEmailTemplateResponse> GETGetEmailTemplateWithHttpInfo(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->GETGetEmailTemplate");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", ZuoraClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.GETGetEmailTemplate";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GETPublicEmailTemplateResponse>("/notifications/email-templates/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETGetEmailTemplate", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve an email template Queries the email template based on the specified ID. This operation supports retrieving the email template for all event types. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETPublicEmailTemplateResponse</returns>
        public async System.Threading.Tasks.Task<GETPublicEmailTemplateResponse> GETGetEmailTemplateAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETPublicEmailTemplateResponse> localVarResponse = await GETGetEmailTemplateWithHttpInfoAsync(authorization, id, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve an email template Queries the email template based on the specified ID. This operation supports retrieving the email template for all event types. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETPublicEmailTemplateResponse)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETPublicEmailTemplateResponse>> GETGetEmailTemplateWithHttpInfoAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->GETGetEmailTemplate");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", ZuoraClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.GETGetEmailTemplate";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GETPublicEmailTemplateResponse>("/notifications/email-templates/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETGetEmailTemplate", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve a notification definition Queries the notification definition of the given ID.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETPublicNotificationDefinitionResponse</returns>
        public GETPublicNotificationDefinitionResponse GETGetNotificationDefinition(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETPublicNotificationDefinitionResponse> localVarResponse = GETGetNotificationDefinitionWithHttpInfo(authorization, id, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve a notification definition Queries the notification definition of the given ID.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETPublicNotificationDefinitionResponse</returns>
        public ZuoraClient.Client.ApiResponse<GETPublicNotificationDefinitionResponse> GETGetNotificationDefinitionWithHttpInfo(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->GETGetNotificationDefinition");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", ZuoraClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.GETGetNotificationDefinition";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GETPublicNotificationDefinitionResponse>("/notifications/notification-definitions/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETGetNotificationDefinition", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve a notification definition Queries the notification definition of the given ID.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETPublicNotificationDefinitionResponse</returns>
        public async System.Threading.Tasks.Task<GETPublicNotificationDefinitionResponse> GETGetNotificationDefinitionAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETPublicNotificationDefinitionResponse> localVarResponse = await GETGetNotificationDefinitionWithHttpInfoAsync(authorization, id, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve a notification definition Queries the notification definition of the given ID.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETPublicNotificationDefinitionResponse)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETPublicNotificationDefinitionResponse>> GETGetNotificationDefinitionWithHttpInfoAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->GETGetNotificationDefinition");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", ZuoraClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.GETGetNotificationDefinition";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GETPublicNotificationDefinitionResponse>("/notifications/notification-definitions/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETGetNotificationDefinition", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve a notification history deletion task Get the notification history deletion task by ID. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification history deletion task. You can get the deletion task ID from the 202 response body of the [Delete notification histories for an account](https://www.zuora.com/developer/api-reference/#operation/DELETE_Delete_Notification_History_For_Account) operation. </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>NotificationsHistoryDeletionTaskResponse</returns>
        public NotificationsHistoryDeletionTaskResponse GETGetNotificationHistoryDeletionTask(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<NotificationsHistoryDeletionTaskResponse> localVarResponse = GETGetNotificationHistoryDeletionTaskWithHttpInfo(authorization, id, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve a notification history deletion task Get the notification history deletion task by ID. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification history deletion task. You can get the deletion task ID from the 202 response body of the [Delete notification histories for an account](https://www.zuora.com/developer/api-reference/#operation/DELETE_Delete_Notification_History_For_Account) operation. </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of NotificationsHistoryDeletionTaskResponse</returns>
        public ZuoraClient.Client.ApiResponse<NotificationsHistoryDeletionTaskResponse> GETGetNotificationHistoryDeletionTaskWithHttpInfo(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->GETGetNotificationHistoryDeletionTask");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", ZuoraClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.GETGetNotificationHistoryDeletionTask";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<NotificationsHistoryDeletionTaskResponse>("/notifications/history/tasks/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETGetNotificationHistoryDeletionTask", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Retrieve a notification history deletion task Get the notification history deletion task by ID. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification history deletion task. You can get the deletion task ID from the 202 response body of the [Delete notification histories for an account](https://www.zuora.com/developer/api-reference/#operation/DELETE_Delete_Notification_History_For_Account) operation. </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of NotificationsHistoryDeletionTaskResponse</returns>
        public async System.Threading.Tasks.Task<NotificationsHistoryDeletionTaskResponse> GETGetNotificationHistoryDeletionTaskAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<NotificationsHistoryDeletionTaskResponse> localVarResponse = await GETGetNotificationHistoryDeletionTaskWithHttpInfoAsync(authorization, id, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Retrieve a notification history deletion task Get the notification history deletion task by ID. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification history deletion task. You can get the deletion task ID from the 202 response body of the [Delete notification histories for an account](https://www.zuora.com/developer/api-reference/#operation/DELETE_Delete_Notification_History_For_Account) operation. </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (NotificationsHistoryDeletionTaskResponse)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<NotificationsHistoryDeletionTaskResponse>> GETGetNotificationHistoryDeletionTaskWithHttpInfoAsync(string authorization, Guid id, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->GETGetNotificationHistoryDeletionTask");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", ZuoraClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.GETGetNotificationHistoryDeletionTask";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<NotificationsHistoryDeletionTaskResponse>("/notifications/history/tasks/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETGetNotificationHistoryDeletionTask", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List email templates Queries email templates. This operation supports querying email templates for all event types. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="start">The first index of the query result. (optional, default to 1)</param>
        /// <param name="limit">The maximum number of results the query should return. (optional, default to 20)</param>
        /// <param name="eventCategory">The event category code for standard events. (optional)</param>
        /// <param name="eventTypeName">The name of the custom event or custom scheduled event. (optional)</param>
        /// <param name="name">The name of the email template. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETQueryEmailTemplates200Response</returns>
        public GETQueryEmailTemplates200Response GETQueryEmailTemplates(string authorization, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? start = default(int?), int? limit = default(int?), decimal? eventCategory = default(decimal?), string eventTypeName = default(string), string name = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETQueryEmailTemplates200Response> localVarResponse = GETQueryEmailTemplatesWithHttpInfo(authorization, zuoraTrackId, zuoraEntityIds, start, limit, eventCategory, eventTypeName, name);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List email templates Queries email templates. This operation supports querying email templates for all event types. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="start">The first index of the query result. (optional, default to 1)</param>
        /// <param name="limit">The maximum number of results the query should return. (optional, default to 20)</param>
        /// <param name="eventCategory">The event category code for standard events. (optional)</param>
        /// <param name="eventTypeName">The name of the custom event or custom scheduled event. (optional)</param>
        /// <param name="name">The name of the email template. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETQueryEmailTemplates200Response</returns>
        public ZuoraClient.Client.ApiResponse<GETQueryEmailTemplates200Response> GETQueryEmailTemplatesWithHttpInfo(string authorization, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? start = default(int?), int? limit = default(int?), decimal? eventCategory = default(decimal?), string eventTypeName = default(string), string name = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->GETQueryEmailTemplates");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (eventCategory != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "eventCategory", eventCategory));
            }
            if (eventTypeName != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "eventTypeName", eventTypeName));
            }
            if (name != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "name", name));
            }
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.GETQueryEmailTemplates";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GETQueryEmailTemplates200Response>("/notifications/email-templates", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETQueryEmailTemplates", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List email templates Queries email templates. This operation supports querying email templates for all event types. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="start">The first index of the query result. (optional, default to 1)</param>
        /// <param name="limit">The maximum number of results the query should return. (optional, default to 20)</param>
        /// <param name="eventCategory">The event category code for standard events. (optional)</param>
        /// <param name="eventTypeName">The name of the custom event or custom scheduled event. (optional)</param>
        /// <param name="name">The name of the email template. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETQueryEmailTemplates200Response</returns>
        public async System.Threading.Tasks.Task<GETQueryEmailTemplates200Response> GETQueryEmailTemplatesAsync(string authorization, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? start = default(int?), int? limit = default(int?), decimal? eventCategory = default(decimal?), string eventTypeName = default(string), string name = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETQueryEmailTemplates200Response> localVarResponse = await GETQueryEmailTemplatesWithHttpInfoAsync(authorization, zuoraTrackId, zuoraEntityIds, start, limit, eventCategory, eventTypeName, name, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List email templates Queries email templates. This operation supports querying email templates for all event types. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="start">The first index of the query result. (optional, default to 1)</param>
        /// <param name="limit">The maximum number of results the query should return. (optional, default to 20)</param>
        /// <param name="eventCategory">The event category code for standard events. (optional)</param>
        /// <param name="eventTypeName">The name of the custom event or custom scheduled event. (optional)</param>
        /// <param name="name">The name of the email template. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETQueryEmailTemplates200Response)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETQueryEmailTemplates200Response>> GETQueryEmailTemplatesWithHttpInfoAsync(string authorization, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? start = default(int?), int? limit = default(int?), decimal? eventCategory = default(decimal?), string eventTypeName = default(string), string name = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->GETQueryEmailTemplates");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (eventCategory != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "eventCategory", eventCategory));
            }
            if (eventTypeName != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "eventTypeName", eventTypeName));
            }
            if (name != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "name", name));
            }
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.GETQueryEmailTemplates";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GETQueryEmailTemplates200Response>("/notifications/email-templates", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETQueryEmailTemplates", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List notification definitions Queries notification definitions with the specified filters.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="start">The first index of the query result. (optional, default to 1)</param>
        /// <param name="limit">The maximum number of results the query should return. (optional, default to 20)</param>
        /// <param name="profileId">Id of the profile. (optional)</param>
        /// <param name="eventTypeName">The name of the event. (optional)</param>
        /// <param name="emailTemplateId">The ID of the email template. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETQueryNotificationDefinitions200Response</returns>
        public GETQueryNotificationDefinitions200Response GETQueryNotificationDefinitions(string authorization, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? start = default(int?), int? limit = default(int?), Guid? profileId = default(Guid?), string eventTypeName = default(string), Guid? emailTemplateId = default(Guid?), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETQueryNotificationDefinitions200Response> localVarResponse = GETQueryNotificationDefinitionsWithHttpInfo(authorization, zuoraTrackId, zuoraEntityIds, start, limit, profileId, eventTypeName, emailTemplateId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List notification definitions Queries notification definitions with the specified filters.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="start">The first index of the query result. (optional, default to 1)</param>
        /// <param name="limit">The maximum number of results the query should return. (optional, default to 20)</param>
        /// <param name="profileId">Id of the profile. (optional)</param>
        /// <param name="eventTypeName">The name of the event. (optional)</param>
        /// <param name="emailTemplateId">The ID of the email template. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETQueryNotificationDefinitions200Response</returns>
        public ZuoraClient.Client.ApiResponse<GETQueryNotificationDefinitions200Response> GETQueryNotificationDefinitionsWithHttpInfo(string authorization, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? start = default(int?), int? limit = default(int?), Guid? profileId = default(Guid?), string eventTypeName = default(string), Guid? emailTemplateId = default(Guid?), int operationIndex = 0)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->GETQueryNotificationDefinitions");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (profileId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "profileId", profileId));
            }
            if (eventTypeName != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "eventTypeName", eventTypeName));
            }
            if (emailTemplateId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "emailTemplateId", emailTemplateId));
            }
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.GETQueryNotificationDefinitions";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<GETQueryNotificationDefinitions200Response>("/notifications/notification-definitions", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETQueryNotificationDefinitions", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// List notification definitions Queries notification definitions with the specified filters.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="start">The first index of the query result. (optional, default to 1)</param>
        /// <param name="limit">The maximum number of results the query should return. (optional, default to 20)</param>
        /// <param name="profileId">Id of the profile. (optional)</param>
        /// <param name="eventTypeName">The name of the event. (optional)</param>
        /// <param name="emailTemplateId">The ID of the email template. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETQueryNotificationDefinitions200Response</returns>
        public async System.Threading.Tasks.Task<GETQueryNotificationDefinitions200Response> GETQueryNotificationDefinitionsAsync(string authorization, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? start = default(int?), int? limit = default(int?), Guid? profileId = default(Guid?), string eventTypeName = default(string), Guid? emailTemplateId = default(Guid?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETQueryNotificationDefinitions200Response> localVarResponse = await GETQueryNotificationDefinitionsWithHttpInfoAsync(authorization, zuoraTrackId, zuoraEntityIds, start, limit, profileId, eventTypeName, emailTemplateId, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// List notification definitions Queries notification definitions with the specified filters.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="start">The first index of the query result. (optional, default to 1)</param>
        /// <param name="limit">The maximum number of results the query should return. (optional, default to 20)</param>
        /// <param name="profileId">Id of the profile. (optional)</param>
        /// <param name="eventTypeName">The name of the event. (optional)</param>
        /// <param name="emailTemplateId">The ID of the email template. (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETQueryNotificationDefinitions200Response)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETQueryNotificationDefinitions200Response>> GETQueryNotificationDefinitionsWithHttpInfoAsync(string authorization, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int? start = default(int?), int? limit = default(int?), Guid? profileId = default(Guid?), string eventTypeName = default(string), Guid? emailTemplateId = default(Guid?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->GETQueryNotificationDefinitions");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (start != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "start", start));
            }
            if (limit != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "limit", limit));
            }
            if (profileId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "profileId", profileId));
            }
            if (eventTypeName != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "eventTypeName", eventTypeName));
            }
            if (emailTemplateId != null)
            {
                localVarRequestOptions.QueryParameters.Add(ZuoraClient.Client.ClientUtils.ParameterToMultiMap("", "emailTemplateId", emailTemplateId));
            }
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }

            localVarRequestOptions.Operation = "NotificationsApi.GETQueryNotificationDefinitions";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<GETQueryNotificationDefinitions200Response>("/notifications/notification-definitions", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GETQueryNotificationDefinitions", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create an email template Creates an email template.   This operation supports creating the email template for all event types.  - If you specify the &#x60;eventCategory&#x60; field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes. - If you specify the &#x60;eventTypeName&#x60; field, the email template is created based on the corresponding custom event or custom scheduled event. See [Event triggers](https://www.zuora.com/developer/api-reference/#tag/Event-Triggers) for more information about custom events, and [Scheduled events](https://www.zuora.com/developer/api-reference/#tag/Scheduled-Events) for more information about custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTPublicEmailTemplateRequest">The request body to create an email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETPublicEmailTemplateResponse</returns>
        public GETPublicEmailTemplateResponse POSTCreateEmailTemplate(string authorization, POSTPublicEmailTemplateRequest pOSTPublicEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETPublicEmailTemplateResponse> localVarResponse = POSTCreateEmailTemplateWithHttpInfo(authorization, pOSTPublicEmailTemplateRequest, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create an email template Creates an email template.   This operation supports creating the email template for all event types.  - If you specify the &#x60;eventCategory&#x60; field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes. - If you specify the &#x60;eventTypeName&#x60; field, the email template is created based on the corresponding custom event or custom scheduled event. See [Event triggers](https://www.zuora.com/developer/api-reference/#tag/Event-Triggers) for more information about custom events, and [Scheduled events](https://www.zuora.com/developer/api-reference/#tag/Scheduled-Events) for more information about custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTPublicEmailTemplateRequest">The request body to create an email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETPublicEmailTemplateResponse</returns>
        public ZuoraClient.Client.ApiResponse<GETPublicEmailTemplateResponse> POSTCreateEmailTemplateWithHttpInfo(string authorization, POSTPublicEmailTemplateRequest pOSTPublicEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->POSTCreateEmailTemplate");
            }

            // verify the required parameter 'pOSTPublicEmailTemplateRequest' is set
            if (pOSTPublicEmailTemplateRequest == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'pOSTPublicEmailTemplateRequest' when calling NotificationsApi->POSTCreateEmailTemplate");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = pOSTPublicEmailTemplateRequest;

            localVarRequestOptions.Operation = "NotificationsApi.POSTCreateEmailTemplate";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<GETPublicEmailTemplateResponse>("/notifications/email-templates", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTCreateEmailTemplate", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create an email template Creates an email template.   This operation supports creating the email template for all event types.  - If you specify the &#x60;eventCategory&#x60; field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes. - If you specify the &#x60;eventTypeName&#x60; field, the email template is created based on the corresponding custom event or custom scheduled event. See [Event triggers](https://www.zuora.com/developer/api-reference/#tag/Event-Triggers) for more information about custom events, and [Scheduled events](https://www.zuora.com/developer/api-reference/#tag/Scheduled-Events) for more information about custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTPublicEmailTemplateRequest">The request body to create an email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETPublicEmailTemplateResponse</returns>
        public async System.Threading.Tasks.Task<GETPublicEmailTemplateResponse> POSTCreateEmailTemplateAsync(string authorization, POSTPublicEmailTemplateRequest pOSTPublicEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETPublicEmailTemplateResponse> localVarResponse = await POSTCreateEmailTemplateWithHttpInfoAsync(authorization, pOSTPublicEmailTemplateRequest, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create an email template Creates an email template.   This operation supports creating the email template for all event types.  - If you specify the &#x60;eventCategory&#x60; field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes. - If you specify the &#x60;eventTypeName&#x60; field, the email template is created based on the corresponding custom event or custom scheduled event. See [Event triggers](https://www.zuora.com/developer/api-reference/#tag/Event-Triggers) for more information about custom events, and [Scheduled events](https://www.zuora.com/developer/api-reference/#tag/Scheduled-Events) for more information about custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTPublicEmailTemplateRequest">The request body to create an email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETPublicEmailTemplateResponse)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETPublicEmailTemplateResponse>> POSTCreateEmailTemplateWithHttpInfoAsync(string authorization, POSTPublicEmailTemplateRequest pOSTPublicEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->POSTCreateEmailTemplate");
            }

            // verify the required parameter 'pOSTPublicEmailTemplateRequest' is set
            if (pOSTPublicEmailTemplateRequest == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'pOSTPublicEmailTemplateRequest' when calling NotificationsApi->POSTCreateEmailTemplate");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = pOSTPublicEmailTemplateRequest;

            localVarRequestOptions.Operation = "NotificationsApi.POSTCreateEmailTemplate";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<GETPublicEmailTemplateResponse>("/notifications/email-templates", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTCreateEmailTemplate", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a notification definition Creates a notification definition. If a filter rule is specified, it will be evaluated to see if the notification definition is qualified to handle the incoming events  during runtime. If the notification is qualified, it will send the email and invoke the callout if it has an email template or a callout. See a step-by-step guide for [creating a custom notification](https://www.zuora.com/developer/api-guides/#Callout-to-external-system-for-provisioning-or-entitlements) in [Zuora API Guides](https://www.zuora.com/developer/api-guides/).  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="entity">The request body used to create the notification definition.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETPublicNotificationDefinitionResponse</returns>
        public GETPublicNotificationDefinitionResponse POSTCreateNotificationDefinition(string authorization, POSTPublicNotificationDefinitionRequest entity, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETPublicNotificationDefinitionResponse> localVarResponse = POSTCreateNotificationDefinitionWithHttpInfo(authorization, entity, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a notification definition Creates a notification definition. If a filter rule is specified, it will be evaluated to see if the notification definition is qualified to handle the incoming events  during runtime. If the notification is qualified, it will send the email and invoke the callout if it has an email template or a callout. See a step-by-step guide for [creating a custom notification](https://www.zuora.com/developer/api-guides/#Callout-to-external-system-for-provisioning-or-entitlements) in [Zuora API Guides](https://www.zuora.com/developer/api-guides/).  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="entity">The request body used to create the notification definition.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETPublicNotificationDefinitionResponse</returns>
        public ZuoraClient.Client.ApiResponse<GETPublicNotificationDefinitionResponse> POSTCreateNotificationDefinitionWithHttpInfo(string authorization, POSTPublicNotificationDefinitionRequest entity, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->POSTCreateNotificationDefinition");
            }

            // verify the required parameter 'entity' is set
            if (entity == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'entity' when calling NotificationsApi->POSTCreateNotificationDefinition");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = entity;

            localVarRequestOptions.Operation = "NotificationsApi.POSTCreateNotificationDefinition";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<GETPublicNotificationDefinitionResponse>("/notifications/notification-definitions", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTCreateNotificationDefinition", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create a notification definition Creates a notification definition. If a filter rule is specified, it will be evaluated to see if the notification definition is qualified to handle the incoming events  during runtime. If the notification is qualified, it will send the email and invoke the callout if it has an email template or a callout. See a step-by-step guide for [creating a custom notification](https://www.zuora.com/developer/api-guides/#Callout-to-external-system-for-provisioning-or-entitlements) in [Zuora API Guides](https://www.zuora.com/developer/api-guides/).  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="entity">The request body used to create the notification definition.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETPublicNotificationDefinitionResponse</returns>
        public async System.Threading.Tasks.Task<GETPublicNotificationDefinitionResponse> POSTCreateNotificationDefinitionAsync(string authorization, POSTPublicNotificationDefinitionRequest entity, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETPublicNotificationDefinitionResponse> localVarResponse = await POSTCreateNotificationDefinitionWithHttpInfoAsync(authorization, entity, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create a notification definition Creates a notification definition. If a filter rule is specified, it will be evaluated to see if the notification definition is qualified to handle the incoming events  during runtime. If the notification is qualified, it will send the email and invoke the callout if it has an email template or a callout. See a step-by-step guide for [creating a custom notification](https://www.zuora.com/developer/api-guides/#Callout-to-external-system-for-provisioning-or-entitlements) in [Zuora API Guides](https://www.zuora.com/developer/api-guides/).  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="entity">The request body used to create the notification definition.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETPublicNotificationDefinitionResponse)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETPublicNotificationDefinitionResponse>> POSTCreateNotificationDefinitionWithHttpInfoAsync(string authorization, POSTPublicNotificationDefinitionRequest entity, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->POSTCreateNotificationDefinition");
            }

            // verify the required parameter 'entity' is set
            if (entity == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'entity' when calling NotificationsApi->POSTCreateNotificationDefinition");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = entity;

            localVarRequestOptions.Operation = "NotificationsApi.POSTCreateNotificationDefinition";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<GETPublicNotificationDefinitionResponse>("/notifications/notification-definitions", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTCreateNotificationDefinition", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create or update email templates Creates email templates for standard or custom events if you do not specify email template IDs, or updates existing email templates if you specify valid email template IDs.  For each email template when you are creating email templates, whether the template is created for a standard event, a custom event, or a custom scheduled event is dependent on whether you specify the &#x60;eventCategory&#x60; or &#x60;eventTypeName&#x60; field.  - If you specify the &#x60;eventCategory&#x60; field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes. - If you specify the &#x60;eventTypeName&#x60; field, the email template is created based on the corresponding custom event or custom scheduled event. See [Event triggers](https://www.zuora.com/developer/api-reference/#tag/Event-Triggers) for more information about custom events, and [Scheduled events](https://www.zuora.com/developer/api-reference/#tag/Scheduled-Events) for more information about custom scheduled events.  The maximum number of email templates that you can create or update by one call is 1,000. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTCreateOrUpdateEmailTemplateRequest">The request body to import or update email templates.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>CreateOrUpdateEmailTemplatesResponse</returns>
        public CreateOrUpdateEmailTemplatesResponse POSTCreateOrUpdateEmailTemplates(string authorization, POSTCreateOrUpdateEmailTemplateRequest pOSTCreateOrUpdateEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<CreateOrUpdateEmailTemplatesResponse> localVarResponse = POSTCreateOrUpdateEmailTemplatesWithHttpInfo(authorization, pOSTCreateOrUpdateEmailTemplateRequest, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create or update email templates Creates email templates for standard or custom events if you do not specify email template IDs, or updates existing email templates if you specify valid email template IDs.  For each email template when you are creating email templates, whether the template is created for a standard event, a custom event, or a custom scheduled event is dependent on whether you specify the &#x60;eventCategory&#x60; or &#x60;eventTypeName&#x60; field.  - If you specify the &#x60;eventCategory&#x60; field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes. - If you specify the &#x60;eventTypeName&#x60; field, the email template is created based on the corresponding custom event or custom scheduled event. See [Event triggers](https://www.zuora.com/developer/api-reference/#tag/Event-Triggers) for more information about custom events, and [Scheduled events](https://www.zuora.com/developer/api-reference/#tag/Scheduled-Events) for more information about custom scheduled events.  The maximum number of email templates that you can create or update by one call is 1,000. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTCreateOrUpdateEmailTemplateRequest">The request body to import or update email templates.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of CreateOrUpdateEmailTemplatesResponse</returns>
        public ZuoraClient.Client.ApiResponse<CreateOrUpdateEmailTemplatesResponse> POSTCreateOrUpdateEmailTemplatesWithHttpInfo(string authorization, POSTCreateOrUpdateEmailTemplateRequest pOSTCreateOrUpdateEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->POSTCreateOrUpdateEmailTemplates");
            }

            // verify the required parameter 'pOSTCreateOrUpdateEmailTemplateRequest' is set
            if (pOSTCreateOrUpdateEmailTemplateRequest == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'pOSTCreateOrUpdateEmailTemplateRequest' when calling NotificationsApi->POSTCreateOrUpdateEmailTemplates");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = pOSTCreateOrUpdateEmailTemplateRequest;

            localVarRequestOptions.Operation = "NotificationsApi.POSTCreateOrUpdateEmailTemplates";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<CreateOrUpdateEmailTemplatesResponse>("/notifications/email-templates/import", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTCreateOrUpdateEmailTemplates", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create or update email templates Creates email templates for standard or custom events if you do not specify email template IDs, or updates existing email templates if you specify valid email template IDs.  For each email template when you are creating email templates, whether the template is created for a standard event, a custom event, or a custom scheduled event is dependent on whether you specify the &#x60;eventCategory&#x60; or &#x60;eventTypeName&#x60; field.  - If you specify the &#x60;eventCategory&#x60; field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes. - If you specify the &#x60;eventTypeName&#x60; field, the email template is created based on the corresponding custom event or custom scheduled event. See [Event triggers](https://www.zuora.com/developer/api-reference/#tag/Event-Triggers) for more information about custom events, and [Scheduled events](https://www.zuora.com/developer/api-reference/#tag/Scheduled-Events) for more information about custom scheduled events.  The maximum number of email templates that you can create or update by one call is 1,000. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTCreateOrUpdateEmailTemplateRequest">The request body to import or update email templates.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of CreateOrUpdateEmailTemplatesResponse</returns>
        public async System.Threading.Tasks.Task<CreateOrUpdateEmailTemplatesResponse> POSTCreateOrUpdateEmailTemplatesAsync(string authorization, POSTCreateOrUpdateEmailTemplateRequest pOSTCreateOrUpdateEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<CreateOrUpdateEmailTemplatesResponse> localVarResponse = await POSTCreateOrUpdateEmailTemplatesWithHttpInfoAsync(authorization, pOSTCreateOrUpdateEmailTemplateRequest, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create or update email templates Creates email templates for standard or custom events if you do not specify email template IDs, or updates existing email templates if you specify valid email template IDs.  For each email template when you are creating email templates, whether the template is created for a standard event, a custom event, or a custom scheduled event is dependent on whether you specify the &#x60;eventCategory&#x60; or &#x60;eventTypeName&#x60; field.  - If you specify the &#x60;eventCategory&#x60; field, the email template is created based on a standard event. See [Standard Event Categories](https://knowledgecenter.zuora.com/Central_Platform/Notifications/A_Standard_Events/Standard_Event_Category_Code_for_Notification_Histories_API) for all standard event category codes. - If you specify the &#x60;eventTypeName&#x60; field, the email template is created based on the corresponding custom event or custom scheduled event. See [Event triggers](https://www.zuora.com/developer/api-reference/#tag/Event-Triggers) for more information about custom events, and [Scheduled events](https://www.zuora.com/developer/api-reference/#tag/Scheduled-Events) for more information about custom scheduled events.  The maximum number of email templates that you can create or update by one call is 1,000. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTCreateOrUpdateEmailTemplateRequest">The request body to import or update email templates.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (CreateOrUpdateEmailTemplatesResponse)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<CreateOrUpdateEmailTemplatesResponse>> POSTCreateOrUpdateEmailTemplatesWithHttpInfoAsync(string authorization, POSTCreateOrUpdateEmailTemplateRequest pOSTCreateOrUpdateEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->POSTCreateOrUpdateEmailTemplates");
            }

            // verify the required parameter 'pOSTCreateOrUpdateEmailTemplateRequest' is set
            if (pOSTCreateOrUpdateEmailTemplateRequest == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'pOSTCreateOrUpdateEmailTemplateRequest' when calling NotificationsApi->POSTCreateOrUpdateEmailTemplates");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = pOSTCreateOrUpdateEmailTemplateRequest;

            localVarRequestOptions.Operation = "NotificationsApi.POSTCreateOrUpdateEmailTemplates";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<CreateOrUpdateEmailTemplatesResponse>("/notifications/email-templates/import", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTCreateOrUpdateEmailTemplates", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Resend callout notifications Resends callout notifications if your customers did not receive previous callout notifications.  Details about the status codes and response contents of this operation are as follows:  | Scenario                               | Status code     | Response content                                            | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Success for all notifications          | 202 Accepted    | (blank)                                                     | | Success for at least one notification  | 202 Accepted    | Error code and error message of each failed notification    | | Failure for all notifications          | 400 Bad Request | Error code and error message of each failed notification    | 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTResendCalloutNotifications">The request body to resend callout notifications.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Dictionary&lt;string, ResendCalloutNotificationsFailedResponseValue&gt;</returns>
        public Dictionary<string, ResendCalloutNotificationsFailedResponseValue> POSTResendCalloutNotifications(string authorization, List<string> pOSTResendCalloutNotifications, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<Dictionary<string, ResendCalloutNotificationsFailedResponseValue>> localVarResponse = POSTResendCalloutNotificationsWithHttpInfo(authorization, pOSTResendCalloutNotifications, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Resend callout notifications Resends callout notifications if your customers did not receive previous callout notifications.  Details about the status codes and response contents of this operation are as follows:  | Scenario                               | Status code     | Response content                                            | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Success for all notifications          | 202 Accepted    | (blank)                                                     | | Success for at least one notification  | 202 Accepted    | Error code and error message of each failed notification    | | Failure for all notifications          | 400 Bad Request | Error code and error message of each failed notification    | 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTResendCalloutNotifications">The request body to resend callout notifications.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Dictionary&lt;string, ResendCalloutNotificationsFailedResponseValue&gt;</returns>
        public ZuoraClient.Client.ApiResponse<Dictionary<string, ResendCalloutNotificationsFailedResponseValue>> POSTResendCalloutNotificationsWithHttpInfo(string authorization, List<string> pOSTResendCalloutNotifications, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->POSTResendCalloutNotifications");
            }

            // verify the required parameter 'pOSTResendCalloutNotifications' is set
            if (pOSTResendCalloutNotifications == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'pOSTResendCalloutNotifications' when calling NotificationsApi->POSTResendCalloutNotifications");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = pOSTResendCalloutNotifications;

            localVarRequestOptions.Operation = "NotificationsApi.POSTResendCalloutNotifications";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<Dictionary<string, ResendCalloutNotificationsFailedResponseValue>>("/notifications/callout-histories/resend", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTResendCalloutNotifications", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Resend callout notifications Resends callout notifications if your customers did not receive previous callout notifications.  Details about the status codes and response contents of this operation are as follows:  | Scenario                               | Status code     | Response content                                            | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Success for all notifications          | 202 Accepted    | (blank)                                                     | | Success for at least one notification  | 202 Accepted    | Error code and error message of each failed notification    | | Failure for all notifications          | 400 Bad Request | Error code and error message of each failed notification    | 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTResendCalloutNotifications">The request body to resend callout notifications.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Dictionary&lt;string, ResendCalloutNotificationsFailedResponseValue&gt;</returns>
        public async System.Threading.Tasks.Task<Dictionary<string, ResendCalloutNotificationsFailedResponseValue>> POSTResendCalloutNotificationsAsync(string authorization, List<string> pOSTResendCalloutNotifications, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<Dictionary<string, ResendCalloutNotificationsFailedResponseValue>> localVarResponse = await POSTResendCalloutNotificationsWithHttpInfoAsync(authorization, pOSTResendCalloutNotifications, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Resend callout notifications Resends callout notifications if your customers did not receive previous callout notifications.  Details about the status codes and response contents of this operation are as follows:  | Scenario                               | Status code     | Response content                                            | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Success for all notifications          | 202 Accepted    | (blank)                                                     | | Success for at least one notification  | 202 Accepted    | Error code and error message of each failed notification    | | Failure for all notifications          | 400 Bad Request | Error code and error message of each failed notification    | 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTResendCalloutNotifications">The request body to resend callout notifications.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, ResendCalloutNotificationsFailedResponseValue&gt;)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<Dictionary<string, ResendCalloutNotificationsFailedResponseValue>>> POSTResendCalloutNotificationsWithHttpInfoAsync(string authorization, List<string> pOSTResendCalloutNotifications, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->POSTResendCalloutNotifications");
            }

            // verify the required parameter 'pOSTResendCalloutNotifications' is set
            if (pOSTResendCalloutNotifications == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'pOSTResendCalloutNotifications' when calling NotificationsApi->POSTResendCalloutNotifications");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = pOSTResendCalloutNotifications;

            localVarRequestOptions.Operation = "NotificationsApi.POSTResendCalloutNotifications";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<Dictionary<string, ResendCalloutNotificationsFailedResponseValue>>("/notifications/callout-histories/resend", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTResendCalloutNotifications", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Resend email notifications Resends email notifications if your customers did not receive previous email notifications.  Details about the status codes and response contents of this operation are as follows:  | Scenario                               | Status code     | Response content                                            | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Success for all notifications          | 202 Accepted    | (blank)                                                     | | Success for at least one notification  | 202 Accepted    | Error code and error message of each failed notification    | | Failure for all notifications          | 400 Bad Request | Error code and error message of each failed notification    | 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTResendEmailNotifications">The request body to resend email notifications.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Dictionary&lt;string, ResendEmailNotificationsFailedResponseValue&gt;</returns>
        public Dictionary<string, ResendEmailNotificationsFailedResponseValue> POSTResendEmailNotifications(string authorization, List<string> pOSTResendEmailNotifications, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<Dictionary<string, ResendEmailNotificationsFailedResponseValue>> localVarResponse = POSTResendEmailNotificationsWithHttpInfo(authorization, pOSTResendEmailNotifications, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Resend email notifications Resends email notifications if your customers did not receive previous email notifications.  Details about the status codes and response contents of this operation are as follows:  | Scenario                               | Status code     | Response content                                            | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Success for all notifications          | 202 Accepted    | (blank)                                                     | | Success for at least one notification  | 202 Accepted    | Error code and error message of each failed notification    | | Failure for all notifications          | 400 Bad Request | Error code and error message of each failed notification    | 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTResendEmailNotifications">The request body to resend email notifications.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Dictionary&lt;string, ResendEmailNotificationsFailedResponseValue&gt;</returns>
        public ZuoraClient.Client.ApiResponse<Dictionary<string, ResendEmailNotificationsFailedResponseValue>> POSTResendEmailNotificationsWithHttpInfo(string authorization, List<string> pOSTResendEmailNotifications, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->POSTResendEmailNotifications");
            }

            // verify the required parameter 'pOSTResendEmailNotifications' is set
            if (pOSTResendEmailNotifications == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'pOSTResendEmailNotifications' when calling NotificationsApi->POSTResendEmailNotifications");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = pOSTResendEmailNotifications;

            localVarRequestOptions.Operation = "NotificationsApi.POSTResendEmailNotifications";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<Dictionary<string, ResendEmailNotificationsFailedResponseValue>>("/notifications/email-histories/resend", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTResendEmailNotifications", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Resend email notifications Resends email notifications if your customers did not receive previous email notifications.  Details about the status codes and response contents of this operation are as follows:  | Scenario                               | Status code     | Response content                                            | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Success for all notifications          | 202 Accepted    | (blank)                                                     | | Success for at least one notification  | 202 Accepted    | Error code and error message of each failed notification    | | Failure for all notifications          | 400 Bad Request | Error code and error message of each failed notification    | 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTResendEmailNotifications">The request body to resend email notifications.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Dictionary&lt;string, ResendEmailNotificationsFailedResponseValue&gt;</returns>
        public async System.Threading.Tasks.Task<Dictionary<string, ResendEmailNotificationsFailedResponseValue>> POSTResendEmailNotificationsAsync(string authorization, List<string> pOSTResendEmailNotifications, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<Dictionary<string, ResendEmailNotificationsFailedResponseValue>> localVarResponse = await POSTResendEmailNotificationsWithHttpInfoAsync(authorization, pOSTResendEmailNotifications, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Resend email notifications Resends email notifications if your customers did not receive previous email notifications.  Details about the status codes and response contents of this operation are as follows:  | Scenario                               | Status code     | Response content                                            | |- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -|- -- -- -- -- -- -- -- --|- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- --| | Success for all notifications          | 202 Accepted    | (blank)                                                     | | Success for at least one notification  | 202 Accepted    | Error code and error message of each failed notification    | | Failure for all notifications          | 400 Bad Request | Error code and error message of each failed notification    | 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="pOSTResendEmailNotifications">The request body to resend email notifications.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Dictionary&lt;string, ResendEmailNotificationsFailedResponseValue&gt;)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<Dictionary<string, ResendEmailNotificationsFailedResponseValue>>> POSTResendEmailNotificationsWithHttpInfoAsync(string authorization, List<string> pOSTResendEmailNotifications, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->POSTResendEmailNotifications");
            }

            // verify the required parameter 'pOSTResendEmailNotifications' is set
            if (pOSTResendEmailNotifications == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'pOSTResendEmailNotifications' when calling NotificationsApi->POSTResendEmailNotifications");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = pOSTResendEmailNotifications;

            localVarRequestOptions.Operation = "NotificationsApi.POSTResendEmailNotifications";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<Dictionary<string, ResendEmailNotificationsFailedResponseValue>>("/notifications/email-histories/resend", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("POSTResendEmailNotifications", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update an email template Updates an email template. This operation supports updating the email template for all event types. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template to be updated.</param>
        /// <param name="pUTPublicEmailTemplateRequest">The request body to update an email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETPublicEmailTemplateResponse</returns>
        public GETPublicEmailTemplateResponse PUTUpdateEmailTemplate(string authorization, Guid id, PUTPublicEmailTemplateRequest pUTPublicEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETPublicEmailTemplateResponse> localVarResponse = PUTUpdateEmailTemplateWithHttpInfo(authorization, id, pUTPublicEmailTemplateRequest, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update an email template Updates an email template. This operation supports updating the email template for all event types. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template to be updated.</param>
        /// <param name="pUTPublicEmailTemplateRequest">The request body to update an email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETPublicEmailTemplateResponse</returns>
        public ZuoraClient.Client.ApiResponse<GETPublicEmailTemplateResponse> PUTUpdateEmailTemplateWithHttpInfo(string authorization, Guid id, PUTPublicEmailTemplateRequest pUTPublicEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->PUTUpdateEmailTemplate");
            }

            // verify the required parameter 'pUTPublicEmailTemplateRequest' is set
            if (pUTPublicEmailTemplateRequest == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'pUTPublicEmailTemplateRequest' when calling NotificationsApi->PUTUpdateEmailTemplate");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", ZuoraClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = pUTPublicEmailTemplateRequest;

            localVarRequestOptions.Operation = "NotificationsApi.PUTUpdateEmailTemplate";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Put<GETPublicEmailTemplateResponse>("/notifications/email-templates/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTUpdateEmailTemplate", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update an email template Updates an email template. This operation supports updating the email template for all event types. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template to be updated.</param>
        /// <param name="pUTPublicEmailTemplateRequest">The request body to update an email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETPublicEmailTemplateResponse</returns>
        public async System.Threading.Tasks.Task<GETPublicEmailTemplateResponse> PUTUpdateEmailTemplateAsync(string authorization, Guid id, PUTPublicEmailTemplateRequest pUTPublicEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETPublicEmailTemplateResponse> localVarResponse = await PUTUpdateEmailTemplateWithHttpInfoAsync(authorization, id, pUTPublicEmailTemplateRequest, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update an email template Updates an email template. This operation supports updating the email template for all event types. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the email template to be updated.</param>
        /// <param name="pUTPublicEmailTemplateRequest">The request body to update an email template.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETPublicEmailTemplateResponse)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETPublicEmailTemplateResponse>> PUTUpdateEmailTemplateWithHttpInfoAsync(string authorization, Guid id, PUTPublicEmailTemplateRequest pUTPublicEmailTemplateRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->PUTUpdateEmailTemplate");
            }

            // verify the required parameter 'pUTPublicEmailTemplateRequest' is set
            if (pUTPublicEmailTemplateRequest == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'pUTPublicEmailTemplateRequest' when calling NotificationsApi->PUTUpdateEmailTemplate");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", ZuoraClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = pUTPublicEmailTemplateRequest;

            localVarRequestOptions.Operation = "NotificationsApi.PUTUpdateEmailTemplate";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<GETPublicEmailTemplateResponse>("/notifications/email-templates/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTUpdateEmailTemplate", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a notification definition Updates a notification definition.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition to be updated.</param>
        /// <param name="pUTPublicNotificationDefinitionRequest">The request body of the notification definition to be updated.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>GETPublicNotificationDefinitionResponse</returns>
        public GETPublicNotificationDefinitionResponse PUTUpdateNotificationDefinition(string authorization, Guid id, PUTPublicNotificationDefinitionRequest pUTPublicNotificationDefinitionRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            ZuoraClient.Client.ApiResponse<GETPublicNotificationDefinitionResponse> localVarResponse = PUTUpdateNotificationDefinitionWithHttpInfo(authorization, id, pUTPublicNotificationDefinitionRequest, zuoraTrackId, zuoraEntityIds);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update a notification definition Updates a notification definition.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition to be updated.</param>
        /// <param name="pUTPublicNotificationDefinitionRequest">The request body of the notification definition to be updated.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of GETPublicNotificationDefinitionResponse</returns>
        public ZuoraClient.Client.ApiResponse<GETPublicNotificationDefinitionResponse> PUTUpdateNotificationDefinitionWithHttpInfo(string authorization, Guid id, PUTPublicNotificationDefinitionRequest pUTPublicNotificationDefinitionRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0)
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->PUTUpdateNotificationDefinition");
            }

            // verify the required parameter 'pUTPublicNotificationDefinitionRequest' is set
            if (pUTPublicNotificationDefinitionRequest == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'pUTPublicNotificationDefinitionRequest' when calling NotificationsApi->PUTUpdateNotificationDefinition");
            }

            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", ZuoraClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = pUTPublicNotificationDefinitionRequest;

            localVarRequestOptions.Operation = "NotificationsApi.PUTUpdateNotificationDefinition";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Put<GETPublicNotificationDefinitionResponse>("/notifications/notification-definitions/{id}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTUpdateNotificationDefinition", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Update a notification definition Updates a notification definition.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition to be updated.</param>
        /// <param name="pUTPublicNotificationDefinitionRequest">The request body of the notification definition to be updated.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of GETPublicNotificationDefinitionResponse</returns>
        public async System.Threading.Tasks.Task<GETPublicNotificationDefinitionResponse> PUTUpdateNotificationDefinitionAsync(string authorization, Guid id, PUTPublicNotificationDefinitionRequest pUTPublicNotificationDefinitionRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            ZuoraClient.Client.ApiResponse<GETPublicNotificationDefinitionResponse> localVarResponse = await PUTUpdateNotificationDefinitionWithHttpInfoAsync(authorization, id, pUTPublicNotificationDefinitionRequest, zuoraTrackId, zuoraEntityIds, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Update a notification definition Updates a notification definition.  **Note**: This operation is only applicable to notifications for custom events and custom scheduled events. 
        /// </summary>
        /// <exception cref="ZuoraClient.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="authorization">The value is in the &#x60;Bearer {token}&#x60; format where {token} is a valid OAuth token generated by calling [Create an OAuth token](https://www.zuora.com/developer/api-reference/#operation/createToken). </param>
        /// <param name="id">The ID of the notification definition to be updated.</param>
        /// <param name="pUTPublicNotificationDefinitionRequest">The request body of the notification definition to be updated.</param>
        /// <param name="zuoraTrackId">A custom identifier for tracing the API call. If you set a value for this header, Zuora returns the same value in the response headers. This header enables you to associate your system process identifiers with Zuora API calls, to assist with troubleshooting in the event of an issue.  The value of this field must use the US-ASCII character set and must not include any of the following characters: colon (&#x60;:&#x60;), semicolon (&#x60;;&#x60;), double quote (&#x60;\&quot;&#x60;), and quote (&#x60;&#39;&#x60;).  (optional)</param>
        /// <param name="zuoraEntityIds">An entity ID. If you have [Zuora Multi-entity](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/Multi-entity) enabled and the OAuth token is valid for more than one entity, you must use this header to specify which entity to perform the operation in. If the OAuth token is only valid for a single entity, or you do not have Zuora Multi-entity enabled, you do not need to set this header.  (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (GETPublicNotificationDefinitionResponse)</returns>
        public async System.Threading.Tasks.Task<ZuoraClient.Client.ApiResponse<GETPublicNotificationDefinitionResponse>> PUTUpdateNotificationDefinitionWithHttpInfoAsync(string authorization, Guid id, PUTPublicNotificationDefinitionRequest pUTPublicNotificationDefinitionRequest, string zuoraTrackId = default(string), string zuoraEntityIds = default(string), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'authorization' is set
            if (authorization == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'authorization' when calling NotificationsApi->PUTUpdateNotificationDefinition");
            }

            // verify the required parameter 'pUTPublicNotificationDefinitionRequest' is set
            if (pUTPublicNotificationDefinitionRequest == null)
            {
                throw new ZuoraClient.Client.ApiException(400, "Missing required parameter 'pUTPublicNotificationDefinitionRequest' when calling NotificationsApi->PUTUpdateNotificationDefinition");
            }


            ZuoraClient.Client.RequestOptions localVarRequestOptions = new ZuoraClient.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json; charset=utf-8"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json; charset=utf-8",
                "application/json"
            };

            var localVarContentType = ZuoraClient.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ZuoraClient.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("id", ZuoraClient.Client.ClientUtils.ParameterToString(id)); // path parameter
            localVarRequestOptions.HeaderParameters.Add("Authorization", ZuoraClient.Client.ClientUtils.ParameterToString(authorization)); // header parameter
            if (zuoraTrackId != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Track-Id", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraTrackId)); // header parameter
            }
            if (zuoraEntityIds != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Zuora-Entity-Ids", ZuoraClient.Client.ClientUtils.ParameterToString(zuoraEntityIds)); // header parameter
            }
            localVarRequestOptions.Data = pUTPublicNotificationDefinitionRequest;

            localVarRequestOptions.Operation = "NotificationsApi.PUTUpdateNotificationDefinition";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PutAsync<GETPublicNotificationDefinitionResponse>("/notifications/notification-definitions/{id}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PUTUpdateNotificationDefinition", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
