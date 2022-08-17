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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = ZuoraClient.Client.OpenAPIDateConverter;

namespace ZuoraClient.Model
{
    /// <summary>
    /// GETCreditMemoType
    /// </summary>
    [DataContract(Name = "GETCreditMemoType")]
    public partial class GETCreditMemoType : IEquatable<GETCreditMemoType>, IValidatableObject
    {
        /// <summary>
        /// The type of the credit memo source. 
        /// </summary>
        /// <value>The type of the credit memo source. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SourceTypeEnum
        {
            /// <summary>
            /// Enum Subscription for value: Subscription
            /// </summary>
            [EnumMember(Value = "Subscription")]
            Subscription = 1,

            /// <summary>
            /// Enum Standalone for value: Standalone
            /// </summary>
            [EnumMember(Value = "Standalone")]
            Standalone = 2,

            /// <summary>
            /// Enum Invoice for value: Invoice
            /// </summary>
            [EnumMember(Value = "Invoice")]
            Invoice = 3

        }


        /// <summary>
        /// The type of the credit memo source. 
        /// </summary>
        /// <value>The type of the credit memo source. </value>
        [DataMember(Name = "sourceType", EmitDefaultValue = false)]
        public SourceTypeEnum? SourceType { get; set; }
        /// <summary>
        /// The status of the credit memo. 
        /// </summary>
        /// <value>The status of the credit memo. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum Draft for value: Draft
            /// </summary>
            [EnumMember(Value = "Draft")]
            Draft = 1,

            /// <summary>
            /// Enum Posted for value: Posted
            /// </summary>
            [EnumMember(Value = "Posted")]
            Posted = 2,

            /// <summary>
            /// Enum Canceled for value: Canceled
            /// </summary>
            [EnumMember(Value = "Canceled")]
            Canceled = 3,

            /// <summary>
            /// Enum Error for value: Error
            /// </summary>
            [EnumMember(Value = "Error")]
            Error = 4,

            /// <summary>
            /// Enum PendingForTax for value: PendingForTax
            /// </summary>
            [EnumMember(Value = "PendingForTax")]
            PendingForTax = 5,

            /// <summary>
            /// Enum Generating for value: Generating
            /// </summary>
            [EnumMember(Value = "Generating")]
            Generating = 6,

            /// <summary>
            /// Enum CancelInProgress for value: CancelInProgress
            /// </summary>
            [EnumMember(Value = "CancelInProgress")]
            CancelInProgress = 7

        }


        /// <summary>
        /// The status of the credit memo. 
        /// </summary>
        /// <value>The status of the credit memo. </value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public StatusEnum? Status { get; set; }
        /// <summary>
        /// The status of tax calculation related to the credit memo.  **Note**: This field is only applicable to tax calculation by third-party tax engines. 
        /// </summary>
        /// <value>The status of tax calculation related to the credit memo.  **Note**: This field is only applicable to tax calculation by third-party tax engines. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TaxStatusEnum
        {
            /// <summary>
            /// Enum Complete for value: Complete
            /// </summary>
            [EnumMember(Value = "Complete")]
            Complete = 1,

            /// <summary>
            /// Enum Error for value: Error
            /// </summary>
            [EnumMember(Value = "Error")]
            Error = 2

        }


        /// <summary>
        /// The status of tax calculation related to the credit memo.  **Note**: This field is only applicable to tax calculation by third-party tax engines. 
        /// </summary>
        /// <value>The status of tax calculation related to the credit memo.  **Note**: This field is only applicable to tax calculation by third-party tax engines. </value>
        [DataMember(Name = "taxStatus", EmitDefaultValue = false)]
        public TaxStatusEnum? TaxStatus { get; set; }
        /// <summary>
        /// Whether the credit memo was transferred to an external accounting system. Use this field for integration with accounting systems, such as NetSuite. 
        /// </summary>
        /// <value>Whether the credit memo was transferred to an external accounting system. Use this field for integration with accounting systems, such as NetSuite. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TransferredToAccountingEnum
        {
            /// <summary>
            /// Enum Processing for value: Processing
            /// </summary>
            [EnumMember(Value = "Processing")]
            Processing = 1,

            /// <summary>
            /// Enum Yes for value: Yes
            /// </summary>
            [EnumMember(Value = "Yes")]
            Yes = 2,

            /// <summary>
            /// Enum No for value: No
            /// </summary>
            [EnumMember(Value = "No")]
            No = 3,

            /// <summary>
            /// Enum Error for value: Error
            /// </summary>
            [EnumMember(Value = "Error")]
            Error = 4,

            /// <summary>
            /// Enum Ignore for value: Ignore
            /// </summary>
            [EnumMember(Value = "Ignore")]
            Ignore = 5

        }


        /// <summary>
        /// Whether the credit memo was transferred to an external accounting system. Use this field for integration with accounting systems, such as NetSuite. 
        /// </summary>
        /// <value>Whether the credit memo was transferred to an external accounting system. Use this field for integration with accounting systems, such as NetSuite. </value>
        [DataMember(Name = "transferredToAccounting", EmitDefaultValue = false)]
        public TransferredToAccountingEnum? TransferredToAccounting { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GETCreditMemoType" /> class.
        /// </summary>
        /// <param name="accountId">The ID of the customer account associated with the credit memo. .</param>
        /// <param name="amount">The total amount of the credit memo. .</param>
        /// <param name="appliedAmount">The applied amount of the credit memo. .</param>
        /// <param name="autoApplyUponPosting">Whether the credit memo automatically applies to the invoice upon posting. .</param>
        /// <param name="billToContactId">The ID of the bill-to contact associated with the credit memo.  The value of this field is &#x60;null&#x60; if you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled. .</param>
        /// <param name="cancelledById">The ID of the Zuora user who cancelled the credit memo. .</param>
        /// <param name="cancelledOn">The date and time when the credit memo was cancelled, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. .</param>
        /// <param name="comment">Comments about the credit memo. .</param>
        /// <param name="createdById">The ID of the Zuora user who created the credit memo. .</param>
        /// <param name="createdDate">The date and time when the credit memo was created, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-01 15:31:10. .</param>
        /// <param name="creditMemoDate">The date when the credit memo takes effect, in &#x60;yyyy-mm-dd&#x60; format. For example, 2017-05-20. .</param>
        /// <param name="currency">A currency defined in the web-based UI administrative settings. .</param>
        /// <param name="excludeFromAutoApplyRules">Whether the credit memo is excluded from the rule of automatically applying credit memos to invoices. .</param>
        /// <param name="excludeItemBillingFromRevenueAccounting">The flag to exclude the credit memo item from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  .</param>
        /// <param name="id">The unique ID of the credit memo. .</param>
        /// <param name="latestPDFFileId">The ID of the latest PDF file generated for the credit memo. .</param>
        /// <param name="number">The unique identification number of the credit memo. .</param>
        /// <param name="postedById">The ID of the Zuora user who posted the credit memo. .</param>
        /// <param name="postedOn">The date and time when the credit memo was posted, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. .</param>
        /// <param name="reasonCode">A code identifying the reason for the transaction. The value must be an existing reason code or empty. .</param>
        /// <param name="referredInvoiceId">The ID of a referred invoice. .</param>
        /// <param name="refundAmount">The amount of the refund on the credit memo. .</param>
        /// <param name="reversed">Whether the credit memo is reversed. .</param>
        /// <param name="source">The source of the credit memo.  Possible values: - &#x60;BillRun&#x60;: The credit memo is generated by a bill run. - &#x60;API&#x60;: The credit memo is created by calling the [Invoice and collect](https://www.zuora.com/developer/api-reference/#operation/POST_TransactionInvoicePayment) operation. - &#x60;ApiSubscribe&#x60;: The credit memo is created by calling the [Create subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription) and [Create account](https://www.zuora.com/developer/api-reference/#operation/POST_Account) operation. - &#x60;ApiAmend&#x60;: The credit memo is created by calling the [Update subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription) operation. - &#x60;AdhocFromPrpc&#x60;: The credit memo is created from a product rate plan charge through the Zuora UI or by calling the [Create a credit memo from a charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc) operation. - &#x60;AdhocFromInvoice&#x60;: The credit memo is created from an invoice or created by reversing an invoice. You can create a credit memo from an invoice through the Zuora UI or by calling the [Create credit memo from invoice](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromInvoice) operation. You can create a credit memo by reversing an invoice through the Zuora UI or by calling the [Reverse invoice](https://www.zuora.com/developer/api-reference/#operation/PUT_ReverseInvoice) operation. .</param>
        /// <param name="sourceId">The ID of the credit memo source.  If a credit memo is generated from a bill run, the value is the number of the corresponding bill run. Otherwise, the value is &#x60;null&#x60;. .</param>
        /// <param name="sourceType">The type of the credit memo source. .</param>
        /// <param name="status">The status of the credit memo. .</param>
        /// <param name="success">Returns &#x60;true&#x60; if the request was processed successfully..</param>
        /// <param name="targetDate">The target date for the credit memo, in &#x60;yyyy-mm-dd&#x60; format. For example, 2017-07-20. .</param>
        /// <param name="taxAmount">The amount of taxation. .</param>
        /// <param name="taxMessage">The message about the status of tax calculation related to the credit memo. If tax calculation fails in one credit memo, this field displays the reason for the failure. .</param>
        /// <param name="taxStatus">The status of tax calculation related to the credit memo.  **Note**: This field is only applicable to tax calculation by third-party tax engines. .</param>
        /// <param name="totalTaxExemptAmount">The calculated tax amount excluded due to the exemption. .</param>
        /// <param name="transferredToAccounting">Whether the credit memo was transferred to an external accounting system. Use this field for integration with accounting systems, such as NetSuite. .</param>
        /// <param name="unappliedAmount">The unapplied amount of the credit memo. .</param>
        /// <param name="updatedById">The ID of the Zuora user who last updated the credit memo. .</param>
        /// <param name="updatedDate">The date and time when the credit memo was last updated, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-01 15:36:10. .</param>
        /// <param name="integrationIdNS">ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="integrationStatusNS">Status of the credit memo&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="originNS">Origin of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="syncDateNS">Date when the credit memo was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="transactionNS">Related transaction in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        public GETCreditMemoType(string accountId = default(string), double amount = default(double), double appliedAmount = default(double), bool autoApplyUponPosting = default(bool), string billToContactId = default(string), string cancelledById = default(string), DateTime cancelledOn = default(DateTime), string comment = default(string), string createdById = default(string), DateTime createdDate = default(DateTime), DateTime creditMemoDate = default(DateTime), string currency = default(string), bool excludeFromAutoApplyRules = default(bool), bool excludeItemBillingFromRevenueAccounting = default(bool), string id = default(string), string latestPDFFileId = default(string), string number = default(string), string postedById = default(string), DateTime postedOn = default(DateTime), string reasonCode = default(string), string referredInvoiceId = default(string), double refundAmount = default(double), bool reversed = default(bool), string source = default(string), string sourceId = default(string), SourceTypeEnum? sourceType = default(SourceTypeEnum?), StatusEnum? status = default(StatusEnum?), bool success = default(bool), DateTime targetDate = default(DateTime), double taxAmount = default(double), string taxMessage = default(string), TaxStatusEnum? taxStatus = default(TaxStatusEnum?), double totalTaxExemptAmount = default(double), TransferredToAccountingEnum? transferredToAccounting = default(TransferredToAccountingEnum?), double unappliedAmount = default(double), string updatedById = default(string), DateTime updatedDate = default(DateTime), string integrationIdNS = default(string), string integrationStatusNS = default(string), string originNS = default(string), string syncDateNS = default(string), string transactionNS = default(string))
        {
            this.AccountId = accountId;
            this.Amount = amount;
            this.AppliedAmount = appliedAmount;
            this.AutoApplyUponPosting = autoApplyUponPosting;
            this.BillToContactId = billToContactId;
            this.CancelledById = cancelledById;
            this.CancelledOn = cancelledOn;
            this.Comment = comment;
            this.CreatedById = createdById;
            this.CreatedDate = createdDate;
            this.CreditMemoDate = creditMemoDate;
            this.Currency = currency;
            this.ExcludeFromAutoApplyRules = excludeFromAutoApplyRules;
            this.ExcludeItemBillingFromRevenueAccounting = excludeItemBillingFromRevenueAccounting;
            this.Id = id;
            this.LatestPDFFileId = latestPDFFileId;
            this.Number = number;
            this.PostedById = postedById;
            this.PostedOn = postedOn;
            this.ReasonCode = reasonCode;
            this.ReferredInvoiceId = referredInvoiceId;
            this.RefundAmount = refundAmount;
            this.Reversed = reversed;
            this.Source = source;
            this.SourceId = sourceId;
            this.SourceType = sourceType;
            this.Status = status;
            this.Success = success;
            this.TargetDate = targetDate;
            this.TaxAmount = taxAmount;
            this.TaxMessage = taxMessage;
            this.TaxStatus = taxStatus;
            this.TotalTaxExemptAmount = totalTaxExemptAmount;
            this.TransferredToAccounting = transferredToAccounting;
            this.UnappliedAmount = unappliedAmount;
            this.UpdatedById = updatedById;
            this.UpdatedDate = updatedDate;
            this.IntegrationIdNS = integrationIdNS;
            this.IntegrationStatusNS = integrationStatusNS;
            this.OriginNS = originNS;
            this.SyncDateNS = syncDateNS;
            this.TransactionNS = transactionNS;
        }

        /// <summary>
        /// The ID of the customer account associated with the credit memo. 
        /// </summary>
        /// <value>The ID of the customer account associated with the credit memo. </value>
        [DataMember(Name = "accountId", EmitDefaultValue = false)]
        public string AccountId { get; set; }

        /// <summary>
        /// The total amount of the credit memo. 
        /// </summary>
        /// <value>The total amount of the credit memo. </value>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public double Amount { get; set; }

        /// <summary>
        /// The applied amount of the credit memo. 
        /// </summary>
        /// <value>The applied amount of the credit memo. </value>
        [DataMember(Name = "appliedAmount", EmitDefaultValue = false)]
        public double AppliedAmount { get; set; }

        /// <summary>
        /// Whether the credit memo automatically applies to the invoice upon posting. 
        /// </summary>
        /// <value>Whether the credit memo automatically applies to the invoice upon posting. </value>
        [DataMember(Name = "autoApplyUponPosting", EmitDefaultValue = true)]
        public bool AutoApplyUponPosting { get; set; }

        /// <summary>
        /// The ID of the bill-to contact associated with the credit memo.  The value of this field is &#x60;null&#x60; if you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled. 
        /// </summary>
        /// <value>The ID of the bill-to contact associated with the credit memo.  The value of this field is &#x60;null&#x60; if you have the [Flexible Billing](https://knowledgecenter.zuora.com/Billing/Subscriptions/Flexible_Billing) feature disabled. </value>
        [DataMember(Name = "billToContactId", EmitDefaultValue = false)]
        public string BillToContactId { get; set; }

        /// <summary>
        /// The ID of the Zuora user who cancelled the credit memo. 
        /// </summary>
        /// <value>The ID of the Zuora user who cancelled the credit memo. </value>
        [DataMember(Name = "cancelledById", EmitDefaultValue = false)]
        public string CancelledById { get; set; }

        /// <summary>
        /// The date and time when the credit memo was cancelled, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. 
        /// </summary>
        /// <value>The date and time when the credit memo was cancelled, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. </value>
        [DataMember(Name = "cancelledOn", EmitDefaultValue = false)]
        public DateTime CancelledOn { get; set; }

        /// <summary>
        /// Comments about the credit memo. 
        /// </summary>
        /// <value>Comments about the credit memo. </value>
        [DataMember(Name = "comment", EmitDefaultValue = false)]
        public string Comment { get; set; }

        /// <summary>
        /// The ID of the Zuora user who created the credit memo. 
        /// </summary>
        /// <value>The ID of the Zuora user who created the credit memo. </value>
        [DataMember(Name = "createdById", EmitDefaultValue = false)]
        public string CreatedById { get; set; }

        /// <summary>
        /// The date and time when the credit memo was created, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-01 15:31:10. 
        /// </summary>
        /// <value>The date and time when the credit memo was created, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-01 15:31:10. </value>
        [DataMember(Name = "createdDate", EmitDefaultValue = false)]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The date when the credit memo takes effect, in &#x60;yyyy-mm-dd&#x60; format. For example, 2017-05-20. 
        /// </summary>
        /// <value>The date when the credit memo takes effect, in &#x60;yyyy-mm-dd&#x60; format. For example, 2017-05-20. </value>
        [DataMember(Name = "creditMemoDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime CreditMemoDate { get; set; }

        /// <summary>
        /// A currency defined in the web-based UI administrative settings. 
        /// </summary>
        /// <value>A currency defined in the web-based UI administrative settings. </value>
        [DataMember(Name = "currency", EmitDefaultValue = false)]
        public string Currency { get; set; }

        /// <summary>
        /// Whether the credit memo is excluded from the rule of automatically applying credit memos to invoices. 
        /// </summary>
        /// <value>Whether the credit memo is excluded from the rule of automatically applying credit memos to invoices. </value>
        [DataMember(Name = "excludeFromAutoApplyRules", EmitDefaultValue = true)]
        public bool ExcludeFromAutoApplyRules { get; set; }

        /// <summary>
        /// The flag to exclude the credit memo item from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  
        /// </summary>
        /// <value>The flag to exclude the credit memo item from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  </value>
        [DataMember(Name = "excludeItemBillingFromRevenueAccounting", EmitDefaultValue = true)]
        public bool ExcludeItemBillingFromRevenueAccounting { get; set; }

        /// <summary>
        /// The unique ID of the credit memo. 
        /// </summary>
        /// <value>The unique ID of the credit memo. </value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// The ID of the latest PDF file generated for the credit memo. 
        /// </summary>
        /// <value>The ID of the latest PDF file generated for the credit memo. </value>
        [DataMember(Name = "latestPDFFileId", EmitDefaultValue = false)]
        public string LatestPDFFileId { get; set; }

        /// <summary>
        /// The unique identification number of the credit memo. 
        /// </summary>
        /// <value>The unique identification number of the credit memo. </value>
        [DataMember(Name = "number", EmitDefaultValue = false)]
        public string Number { get; set; }

        /// <summary>
        /// The ID of the Zuora user who posted the credit memo. 
        /// </summary>
        /// <value>The ID of the Zuora user who posted the credit memo. </value>
        [DataMember(Name = "postedById", EmitDefaultValue = false)]
        public string PostedById { get; set; }

        /// <summary>
        /// The date and time when the credit memo was posted, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. 
        /// </summary>
        /// <value>The date and time when the credit memo was posted, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. </value>
        [DataMember(Name = "postedOn", EmitDefaultValue = false)]
        public DateTime PostedOn { get; set; }

        /// <summary>
        /// A code identifying the reason for the transaction. The value must be an existing reason code or empty. 
        /// </summary>
        /// <value>A code identifying the reason for the transaction. The value must be an existing reason code or empty. </value>
        [DataMember(Name = "reasonCode", EmitDefaultValue = false)]
        public string ReasonCode { get; set; }

        /// <summary>
        /// The ID of a referred invoice. 
        /// </summary>
        /// <value>The ID of a referred invoice. </value>
        [DataMember(Name = "referredInvoiceId", EmitDefaultValue = false)]
        public string ReferredInvoiceId { get; set; }

        /// <summary>
        /// The amount of the refund on the credit memo. 
        /// </summary>
        /// <value>The amount of the refund on the credit memo. </value>
        [DataMember(Name = "refundAmount", EmitDefaultValue = false)]
        public double RefundAmount { get; set; }

        /// <summary>
        /// Whether the credit memo is reversed. 
        /// </summary>
        /// <value>Whether the credit memo is reversed. </value>
        [DataMember(Name = "reversed", EmitDefaultValue = true)]
        public bool Reversed { get; set; }

        /// <summary>
        /// The source of the credit memo.  Possible values: - &#x60;BillRun&#x60;: The credit memo is generated by a bill run. - &#x60;API&#x60;: The credit memo is created by calling the [Invoice and collect](https://www.zuora.com/developer/api-reference/#operation/POST_TransactionInvoicePayment) operation. - &#x60;ApiSubscribe&#x60;: The credit memo is created by calling the [Create subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription) and [Create account](https://www.zuora.com/developer/api-reference/#operation/POST_Account) operation. - &#x60;ApiAmend&#x60;: The credit memo is created by calling the [Update subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription) operation. - &#x60;AdhocFromPrpc&#x60;: The credit memo is created from a product rate plan charge through the Zuora UI or by calling the [Create a credit memo from a charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc) operation. - &#x60;AdhocFromInvoice&#x60;: The credit memo is created from an invoice or created by reversing an invoice. You can create a credit memo from an invoice through the Zuora UI or by calling the [Create credit memo from invoice](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromInvoice) operation. You can create a credit memo by reversing an invoice through the Zuora UI or by calling the [Reverse invoice](https://www.zuora.com/developer/api-reference/#operation/PUT_ReverseInvoice) operation. 
        /// </summary>
        /// <value>The source of the credit memo.  Possible values: - &#x60;BillRun&#x60;: The credit memo is generated by a bill run. - &#x60;API&#x60;: The credit memo is created by calling the [Invoice and collect](https://www.zuora.com/developer/api-reference/#operation/POST_TransactionInvoicePayment) operation. - &#x60;ApiSubscribe&#x60;: The credit memo is created by calling the [Create subscription](https://www.zuora.com/developer/api-reference/#operation/POST_Subscription) and [Create account](https://www.zuora.com/developer/api-reference/#operation/POST_Account) operation. - &#x60;ApiAmend&#x60;: The credit memo is created by calling the [Update subscription](https://www.zuora.com/developer/api-reference/#operation/PUT_Subscription) operation. - &#x60;AdhocFromPrpc&#x60;: The credit memo is created from a product rate plan charge through the Zuora UI or by calling the [Create a credit memo from a charge](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromPrpc) operation. - &#x60;AdhocFromInvoice&#x60;: The credit memo is created from an invoice or created by reversing an invoice. You can create a credit memo from an invoice through the Zuora UI or by calling the [Create credit memo from invoice](https://www.zuora.com/developer/api-reference/#operation/POST_CreditMemoFromInvoice) operation. You can create a credit memo by reversing an invoice through the Zuora UI or by calling the [Reverse invoice](https://www.zuora.com/developer/api-reference/#operation/PUT_ReverseInvoice) operation. </value>
        [DataMember(Name = "source", EmitDefaultValue = false)]
        public string Source { get; set; }

        /// <summary>
        /// The ID of the credit memo source.  If a credit memo is generated from a bill run, the value is the number of the corresponding bill run. Otherwise, the value is &#x60;null&#x60;. 
        /// </summary>
        /// <value>The ID of the credit memo source.  If a credit memo is generated from a bill run, the value is the number of the corresponding bill run. Otherwise, the value is &#x60;null&#x60;. </value>
        [DataMember(Name = "sourceId", EmitDefaultValue = false)]
        public string SourceId { get; set; }

        /// <summary>
        /// Returns &#x60;true&#x60; if the request was processed successfully.
        /// </summary>
        /// <value>Returns &#x60;true&#x60; if the request was processed successfully.</value>
        [DataMember(Name = "success", EmitDefaultValue = true)]
        public bool Success { get; set; }

        /// <summary>
        /// The target date for the credit memo, in &#x60;yyyy-mm-dd&#x60; format. For example, 2017-07-20. 
        /// </summary>
        /// <value>The target date for the credit memo, in &#x60;yyyy-mm-dd&#x60; format. For example, 2017-07-20. </value>
        [DataMember(Name = "targetDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime TargetDate { get; set; }

        /// <summary>
        /// The amount of taxation. 
        /// </summary>
        /// <value>The amount of taxation. </value>
        [DataMember(Name = "taxAmount", EmitDefaultValue = false)]
        public double TaxAmount { get; set; }

        /// <summary>
        /// The message about the status of tax calculation related to the credit memo. If tax calculation fails in one credit memo, this field displays the reason for the failure. 
        /// </summary>
        /// <value>The message about the status of tax calculation related to the credit memo. If tax calculation fails in one credit memo, this field displays the reason for the failure. </value>
        [DataMember(Name = "taxMessage", EmitDefaultValue = false)]
        public string TaxMessage { get; set; }

        /// <summary>
        /// The calculated tax amount excluded due to the exemption. 
        /// </summary>
        /// <value>The calculated tax amount excluded due to the exemption. </value>
        [DataMember(Name = "totalTaxExemptAmount", EmitDefaultValue = false)]
        public double TotalTaxExemptAmount { get; set; }

        /// <summary>
        /// The unapplied amount of the credit memo. 
        /// </summary>
        /// <value>The unapplied amount of the credit memo. </value>
        [DataMember(Name = "unappliedAmount", EmitDefaultValue = false)]
        public double UnappliedAmount { get; set; }

        /// <summary>
        /// The ID of the Zuora user who last updated the credit memo. 
        /// </summary>
        /// <value>The ID of the Zuora user who last updated the credit memo. </value>
        [DataMember(Name = "updatedById", EmitDefaultValue = false)]
        public string UpdatedById { get; set; }

        /// <summary>
        /// The date and time when the credit memo was last updated, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-01 15:36:10. 
        /// </summary>
        /// <value>The date and time when the credit memo was last updated, in &#x60;yyyy-mm-dd hh:mm:ss&#x60; format. For example, 2017-03-01 15:36:10. </value>
        [DataMember(Name = "updatedDate", EmitDefaultValue = false)]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "IntegrationId__NS", EmitDefaultValue = false)]
        public string IntegrationIdNS { get; set; }

        /// <summary>
        /// Status of the credit memo&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Status of the credit memo&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "IntegrationStatus__NS", EmitDefaultValue = false)]
        public string IntegrationStatusNS { get; set; }

        /// <summary>
        /// Origin of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Origin of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "Origin__NS", EmitDefaultValue = false)]
        public string OriginNS { get; set; }

        /// <summary>
        /// Date when the credit memo was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Date when the credit memo was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "SyncDate__NS", EmitDefaultValue = false)]
        public string SyncDateNS { get; set; }

        /// <summary>
        /// Related transaction in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Related transaction in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "Transaction__NS", EmitDefaultValue = false)]
        public string TransactionNS { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GETCreditMemoType {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  AppliedAmount: ").Append(AppliedAmount).Append("\n");
            sb.Append("  AutoApplyUponPosting: ").Append(AutoApplyUponPosting).Append("\n");
            sb.Append("  BillToContactId: ").Append(BillToContactId).Append("\n");
            sb.Append("  CancelledById: ").Append(CancelledById).Append("\n");
            sb.Append("  CancelledOn: ").Append(CancelledOn).Append("\n");
            sb.Append("  Comment: ").Append(Comment).Append("\n");
            sb.Append("  CreatedById: ").Append(CreatedById).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  CreditMemoDate: ").Append(CreditMemoDate).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  ExcludeFromAutoApplyRules: ").Append(ExcludeFromAutoApplyRules).Append("\n");
            sb.Append("  ExcludeItemBillingFromRevenueAccounting: ").Append(ExcludeItemBillingFromRevenueAccounting).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LatestPDFFileId: ").Append(LatestPDFFileId).Append("\n");
            sb.Append("  Number: ").Append(Number).Append("\n");
            sb.Append("  PostedById: ").Append(PostedById).Append("\n");
            sb.Append("  PostedOn: ").Append(PostedOn).Append("\n");
            sb.Append("  ReasonCode: ").Append(ReasonCode).Append("\n");
            sb.Append("  ReferredInvoiceId: ").Append(ReferredInvoiceId).Append("\n");
            sb.Append("  RefundAmount: ").Append(RefundAmount).Append("\n");
            sb.Append("  Reversed: ").Append(Reversed).Append("\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
            sb.Append("  SourceId: ").Append(SourceId).Append("\n");
            sb.Append("  SourceType: ").Append(SourceType).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Success: ").Append(Success).Append("\n");
            sb.Append("  TargetDate: ").Append(TargetDate).Append("\n");
            sb.Append("  TaxAmount: ").Append(TaxAmount).Append("\n");
            sb.Append("  TaxMessage: ").Append(TaxMessage).Append("\n");
            sb.Append("  TaxStatus: ").Append(TaxStatus).Append("\n");
            sb.Append("  TotalTaxExemptAmount: ").Append(TotalTaxExemptAmount).Append("\n");
            sb.Append("  TransferredToAccounting: ").Append(TransferredToAccounting).Append("\n");
            sb.Append("  UnappliedAmount: ").Append(UnappliedAmount).Append("\n");
            sb.Append("  UpdatedById: ").Append(UpdatedById).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  IntegrationIdNS: ").Append(IntegrationIdNS).Append("\n");
            sb.Append("  IntegrationStatusNS: ").Append(IntegrationStatusNS).Append("\n");
            sb.Append("  OriginNS: ").Append(OriginNS).Append("\n");
            sb.Append("  SyncDateNS: ").Append(SyncDateNS).Append("\n");
            sb.Append("  TransactionNS: ").Append(TransactionNS).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as GETCreditMemoType);
        }

        /// <summary>
        /// Returns true if GETCreditMemoType instances are equal
        /// </summary>
        /// <param name="input">Instance of GETCreditMemoType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GETCreditMemoType input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AccountId == input.AccountId ||
                    (this.AccountId != null &&
                    this.AccountId.Equals(input.AccountId))
                ) && 
                (
                    this.Amount == input.Amount ||
                    this.Amount.Equals(input.Amount)
                ) && 
                (
                    this.AppliedAmount == input.AppliedAmount ||
                    this.AppliedAmount.Equals(input.AppliedAmount)
                ) && 
                (
                    this.AutoApplyUponPosting == input.AutoApplyUponPosting ||
                    this.AutoApplyUponPosting.Equals(input.AutoApplyUponPosting)
                ) && 
                (
                    this.BillToContactId == input.BillToContactId ||
                    (this.BillToContactId != null &&
                    this.BillToContactId.Equals(input.BillToContactId))
                ) && 
                (
                    this.CancelledById == input.CancelledById ||
                    (this.CancelledById != null &&
                    this.CancelledById.Equals(input.CancelledById))
                ) && 
                (
                    this.CancelledOn == input.CancelledOn ||
                    (this.CancelledOn != null &&
                    this.CancelledOn.Equals(input.CancelledOn))
                ) && 
                (
                    this.Comment == input.Comment ||
                    (this.Comment != null &&
                    this.Comment.Equals(input.Comment))
                ) && 
                (
                    this.CreatedById == input.CreatedById ||
                    (this.CreatedById != null &&
                    this.CreatedById.Equals(input.CreatedById))
                ) && 
                (
                    this.CreatedDate == input.CreatedDate ||
                    (this.CreatedDate != null &&
                    this.CreatedDate.Equals(input.CreatedDate))
                ) && 
                (
                    this.CreditMemoDate == input.CreditMemoDate ||
                    (this.CreditMemoDate != null &&
                    this.CreditMemoDate.Equals(input.CreditMemoDate))
                ) && 
                (
                    this.Currency == input.Currency ||
                    (this.Currency != null &&
                    this.Currency.Equals(input.Currency))
                ) && 
                (
                    this.ExcludeFromAutoApplyRules == input.ExcludeFromAutoApplyRules ||
                    this.ExcludeFromAutoApplyRules.Equals(input.ExcludeFromAutoApplyRules)
                ) && 
                (
                    this.ExcludeItemBillingFromRevenueAccounting == input.ExcludeItemBillingFromRevenueAccounting ||
                    this.ExcludeItemBillingFromRevenueAccounting.Equals(input.ExcludeItemBillingFromRevenueAccounting)
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.LatestPDFFileId == input.LatestPDFFileId ||
                    (this.LatestPDFFileId != null &&
                    this.LatestPDFFileId.Equals(input.LatestPDFFileId))
                ) && 
                (
                    this.Number == input.Number ||
                    (this.Number != null &&
                    this.Number.Equals(input.Number))
                ) && 
                (
                    this.PostedById == input.PostedById ||
                    (this.PostedById != null &&
                    this.PostedById.Equals(input.PostedById))
                ) && 
                (
                    this.PostedOn == input.PostedOn ||
                    (this.PostedOn != null &&
                    this.PostedOn.Equals(input.PostedOn))
                ) && 
                (
                    this.ReasonCode == input.ReasonCode ||
                    (this.ReasonCode != null &&
                    this.ReasonCode.Equals(input.ReasonCode))
                ) && 
                (
                    this.ReferredInvoiceId == input.ReferredInvoiceId ||
                    (this.ReferredInvoiceId != null &&
                    this.ReferredInvoiceId.Equals(input.ReferredInvoiceId))
                ) && 
                (
                    this.RefundAmount == input.RefundAmount ||
                    this.RefundAmount.Equals(input.RefundAmount)
                ) && 
                (
                    this.Reversed == input.Reversed ||
                    this.Reversed.Equals(input.Reversed)
                ) && 
                (
                    this.Source == input.Source ||
                    (this.Source != null &&
                    this.Source.Equals(input.Source))
                ) && 
                (
                    this.SourceId == input.SourceId ||
                    (this.SourceId != null &&
                    this.SourceId.Equals(input.SourceId))
                ) && 
                (
                    this.SourceType == input.SourceType ||
                    this.SourceType.Equals(input.SourceType)
                ) && 
                (
                    this.Status == input.Status ||
                    this.Status.Equals(input.Status)
                ) && 
                (
                    this.Success == input.Success ||
                    this.Success.Equals(input.Success)
                ) && 
                (
                    this.TargetDate == input.TargetDate ||
                    (this.TargetDate != null &&
                    this.TargetDate.Equals(input.TargetDate))
                ) && 
                (
                    this.TaxAmount == input.TaxAmount ||
                    this.TaxAmount.Equals(input.TaxAmount)
                ) && 
                (
                    this.TaxMessage == input.TaxMessage ||
                    (this.TaxMessage != null &&
                    this.TaxMessage.Equals(input.TaxMessage))
                ) && 
                (
                    this.TaxStatus == input.TaxStatus ||
                    this.TaxStatus.Equals(input.TaxStatus)
                ) && 
                (
                    this.TotalTaxExemptAmount == input.TotalTaxExemptAmount ||
                    this.TotalTaxExemptAmount.Equals(input.TotalTaxExemptAmount)
                ) && 
                (
                    this.TransferredToAccounting == input.TransferredToAccounting ||
                    this.TransferredToAccounting.Equals(input.TransferredToAccounting)
                ) && 
                (
                    this.UnappliedAmount == input.UnappliedAmount ||
                    this.UnappliedAmount.Equals(input.UnappliedAmount)
                ) && 
                (
                    this.UpdatedById == input.UpdatedById ||
                    (this.UpdatedById != null &&
                    this.UpdatedById.Equals(input.UpdatedById))
                ) && 
                (
                    this.UpdatedDate == input.UpdatedDate ||
                    (this.UpdatedDate != null &&
                    this.UpdatedDate.Equals(input.UpdatedDate))
                ) && 
                (
                    this.IntegrationIdNS == input.IntegrationIdNS ||
                    (this.IntegrationIdNS != null &&
                    this.IntegrationIdNS.Equals(input.IntegrationIdNS))
                ) && 
                (
                    this.IntegrationStatusNS == input.IntegrationStatusNS ||
                    (this.IntegrationStatusNS != null &&
                    this.IntegrationStatusNS.Equals(input.IntegrationStatusNS))
                ) && 
                (
                    this.OriginNS == input.OriginNS ||
                    (this.OriginNS != null &&
                    this.OriginNS.Equals(input.OriginNS))
                ) && 
                (
                    this.SyncDateNS == input.SyncDateNS ||
                    (this.SyncDateNS != null &&
                    this.SyncDateNS.Equals(input.SyncDateNS))
                ) && 
                (
                    this.TransactionNS == input.TransactionNS ||
                    (this.TransactionNS != null &&
                    this.TransactionNS.Equals(input.TransactionNS))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.AccountId != null)
                {
                    hashCode = (hashCode * 59) + this.AccountId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Amount.GetHashCode();
                hashCode = (hashCode * 59) + this.AppliedAmount.GetHashCode();
                hashCode = (hashCode * 59) + this.AutoApplyUponPosting.GetHashCode();
                if (this.BillToContactId != null)
                {
                    hashCode = (hashCode * 59) + this.BillToContactId.GetHashCode();
                }
                if (this.CancelledById != null)
                {
                    hashCode = (hashCode * 59) + this.CancelledById.GetHashCode();
                }
                if (this.CancelledOn != null)
                {
                    hashCode = (hashCode * 59) + this.CancelledOn.GetHashCode();
                }
                if (this.Comment != null)
                {
                    hashCode = (hashCode * 59) + this.Comment.GetHashCode();
                }
                if (this.CreatedById != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedById.GetHashCode();
                }
                if (this.CreatedDate != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedDate.GetHashCode();
                }
                if (this.CreditMemoDate != null)
                {
                    hashCode = (hashCode * 59) + this.CreditMemoDate.GetHashCode();
                }
                if (this.Currency != null)
                {
                    hashCode = (hashCode * 59) + this.Currency.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ExcludeFromAutoApplyRules.GetHashCode();
                hashCode = (hashCode * 59) + this.ExcludeItemBillingFromRevenueAccounting.GetHashCode();
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.LatestPDFFileId != null)
                {
                    hashCode = (hashCode * 59) + this.LatestPDFFileId.GetHashCode();
                }
                if (this.Number != null)
                {
                    hashCode = (hashCode * 59) + this.Number.GetHashCode();
                }
                if (this.PostedById != null)
                {
                    hashCode = (hashCode * 59) + this.PostedById.GetHashCode();
                }
                if (this.PostedOn != null)
                {
                    hashCode = (hashCode * 59) + this.PostedOn.GetHashCode();
                }
                if (this.ReasonCode != null)
                {
                    hashCode = (hashCode * 59) + this.ReasonCode.GetHashCode();
                }
                if (this.ReferredInvoiceId != null)
                {
                    hashCode = (hashCode * 59) + this.ReferredInvoiceId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.RefundAmount.GetHashCode();
                hashCode = (hashCode * 59) + this.Reversed.GetHashCode();
                if (this.Source != null)
                {
                    hashCode = (hashCode * 59) + this.Source.GetHashCode();
                }
                if (this.SourceId != null)
                {
                    hashCode = (hashCode * 59) + this.SourceId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.SourceType.GetHashCode();
                hashCode = (hashCode * 59) + this.Status.GetHashCode();
                hashCode = (hashCode * 59) + this.Success.GetHashCode();
                if (this.TargetDate != null)
                {
                    hashCode = (hashCode * 59) + this.TargetDate.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.TaxAmount.GetHashCode();
                if (this.TaxMessage != null)
                {
                    hashCode = (hashCode * 59) + this.TaxMessage.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.TaxStatus.GetHashCode();
                hashCode = (hashCode * 59) + this.TotalTaxExemptAmount.GetHashCode();
                hashCode = (hashCode * 59) + this.TransferredToAccounting.GetHashCode();
                hashCode = (hashCode * 59) + this.UnappliedAmount.GetHashCode();
                if (this.UpdatedById != null)
                {
                    hashCode = (hashCode * 59) + this.UpdatedById.GetHashCode();
                }
                if (this.UpdatedDate != null)
                {
                    hashCode = (hashCode * 59) + this.UpdatedDate.GetHashCode();
                }
                if (this.IntegrationIdNS != null)
                {
                    hashCode = (hashCode * 59) + this.IntegrationIdNS.GetHashCode();
                }
                if (this.IntegrationStatusNS != null)
                {
                    hashCode = (hashCode * 59) + this.IntegrationStatusNS.GetHashCode();
                }
                if (this.OriginNS != null)
                {
                    hashCode = (hashCode * 59) + this.OriginNS.GetHashCode();
                }
                if (this.SyncDateNS != null)
                {
                    hashCode = (hashCode * 59) + this.SyncDateNS.GetHashCode();
                }
                if (this.TransactionNS != null)
                {
                    hashCode = (hashCode * 59) + this.TransactionNS.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        public IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> Validate(ValidationContext validationContext)
        {
            // IntegrationIdNS (string) maxLength
            if (this.IntegrationIdNS != null && this.IntegrationIdNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for IntegrationIdNS, length must be less than 255.", new [] { "IntegrationIdNS" });
            }

            // IntegrationStatusNS (string) maxLength
            if (this.IntegrationStatusNS != null && this.IntegrationStatusNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for IntegrationStatusNS, length must be less than 255.", new [] { "IntegrationStatusNS" });
            }

            // OriginNS (string) maxLength
            if (this.OriginNS != null && this.OriginNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for OriginNS, length must be less than 255.", new [] { "OriginNS" });
            }

            // SyncDateNS (string) maxLength
            if (this.SyncDateNS != null && this.SyncDateNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SyncDateNS, length must be less than 255.", new [] { "SyncDateNS" });
            }

            // TransactionNS (string) maxLength
            if (this.TransactionNS != null && this.TransactionNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for TransactionNS, length must be less than 255.", new [] { "TransactionNS" });
            }

            yield break;
        }
    }

}
