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
    /// GETSubscriptionRatePlanChargesType
    /// </summary>
    [DataContract(Name = "GETSubscriptionRatePlanChargesType")]
    public partial class GETSubscriptionRatePlanChargesType : IEquatable<GETSubscriptionRatePlanChargesType>, IValidatableObject
    {
        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  To use this field, you must set the &#x60;X-Zuora-WSDL-Version&#x60; request header to 114 or higher. Otherwise, an error occurs.  The way to calculate credit. See [Credit Option](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge#Credit_Option) for more information. 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  To use this field, you must set the &#x60;X-Zuora-WSDL-Version&#x60; request header to 114 or higher. Otherwise, an error occurs.  The way to calculate credit. See [Credit Option](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge#Credit_Option) for more information. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum CreditOptionEnum
        {
            /// <summary>
            /// Enum TimeBased for value: TimeBased
            /// </summary>
            [EnumMember(Value = "TimeBased")]
            TimeBased = 1,

            /// <summary>
            /// Enum ConsumptionBased for value: ConsumptionBased
            /// </summary>
            [EnumMember(Value = "ConsumptionBased")]
            ConsumptionBased = 2,

            /// <summary>
            /// Enum FullCreditBack for value: FullCreditBack
            /// </summary>
            [EnumMember(Value = "FullCreditBack")]
            FullCreditBack = 3

        }


        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  To use this field, you must set the &#x60;X-Zuora-WSDL-Version&#x60; request header to 114 or higher. Otherwise, an error occurs.  The way to calculate credit. See [Credit Option](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge#Credit_Option) for more information. 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  To use this field, you must set the &#x60;X-Zuora-WSDL-Version&#x60; request header to 114 or higher. Otherwise, an error occurs.  The way to calculate credit. See [Credit Option](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge#Credit_Option) for more information. </value>
        [DataMember(Name = "creditOption", EmitDefaultValue = false)]
        public CreditOptionEnum? CreditOption { get; set; }
        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The type of this charge. It is either a prepayment (topup) charge or a drawdown charge.  
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The type of this charge. It is either a prepayment (topup) charge or a drawdown charge.  </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PrepaidOperationTypeEnum
        {
            /// <summary>
            /// Enum Topup for value: topup
            /// </summary>
            [EnumMember(Value = "topup")]
            Topup = 1,

            /// <summary>
            /// Enum Drawdown for value: drawdown
            /// </summary>
            [EnumMember(Value = "drawdown")]
            Drawdown = 2

        }


        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The type of this charge. It is either a prepayment (topup) charge or a drawdown charge.  
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The type of this charge. It is either a prepayment (topup) charge or a drawdown charge.  </value>
        [DataMember(Name = "prepaidOperationType", EmitDefaultValue = false)]
        public PrepaidOperationTypeEnum? PrepaidOperationType { get; set; }
        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The period in which the prepayment units are valid to use as defined in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The period in which the prepayment units are valid to use as defined in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ValidityPeriodTypeEnum
        {
            /// <summary>
            /// Enum SUBSCRIPTIONTERM for value: SUBSCRIPTION_TERM
            /// </summary>
            [EnumMember(Value = "SUBSCRIPTION_TERM")]
            SUBSCRIPTIONTERM = 1,

            /// <summary>
            /// Enum ANNUAL for value: ANNUAL
            /// </summary>
            [EnumMember(Value = "ANNUAL")]
            ANNUAL = 2,

            /// <summary>
            /// Enum SEMIANNUAL for value: SEMI_ANNUAL
            /// </summary>
            [EnumMember(Value = "SEMI_ANNUAL")]
            SEMIANNUAL = 3,

            /// <summary>
            /// Enum QUARTER for value: QUARTER
            /// </summary>
            [EnumMember(Value = "QUARTER")]
            QUARTER = 4,

            /// <summary>
            /// Enum MONTH for value: MONTH
            /// </summary>
            [EnumMember(Value = "MONTH")]
            MONTH = 5

        }


        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The period in which the prepayment units are valid to use as defined in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The period in which the prepayment units are valid to use as defined in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). </value>
        [DataMember(Name = "validityPeriodType", EmitDefaultValue = false)]
        public ValidityPeriodTypeEnum? ValidityPeriodType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GETSubscriptionRatePlanChargesType" /> class.
        /// </summary>
        /// <param name="amendedByOrderOn">The date when the rate plan charge is amended through an order or amendment. This field is to standardize the booking date information to increase audit ability and traceability of data between Zuora Billing and Zuora Revenue. It is mapped as the booking date for a sale order line in Zuora Revenue. .</param>
        /// <param name="applyDiscountTo">Specifies the type of charges a specific discount applies to.   This field is only used when applied to a discount charge model. If you are not using a discount charge model, the value is null.  Possible values:  * &#x60;RECURRING&#x60; * &#x60;USAGE&#x60; * &#x60;ONETIMERECURRING&#x60; * &#x60;ONETIMEUSAGE&#x60; * &#x60;RECURRINGUSAGE&#x60; * &#x60;ONETIMERECURRINGUSAGE&#x60; .</param>
        /// <param name="billingDay">Billing cycle day (BCD), which is when bill runs generate invoices for charges associated with the product rate plan charge or the account.    Values:  * &#x60;DefaultFromCustomer&#x60; * &#x60;SpecificDayofMonth(#)&#x60; * &#x60;SubscriptionStartDay&#x60; * &#x60;ChargeTriggerDay&#x60; * &#x60;SpecificDayofWeek/dayofweek&#x60;: in which dayofweek is the day in the week you define your billing periods to start.  In the response data, a day-of-the-month value (&#x60;1&#x60;-&#x60;31&#x60;) appears in place of the hash sign above (\&quot;#\&quot;). If this value exceeds the number of days in a particular month, the last day of the month is used as the BCD. .</param>
        /// <param name="billingPeriod">Allows billing period to be overridden on the rate plan charge. .</param>
        /// <param name="billingPeriodAlignment">Possible values:  * &#x60;AlignToCharge&#x60; * &#x60;AlignToSubscriptionStart&#x60; * &#x60;AlignToTermStart&#x60; .</param>
        /// <param name="billingTiming">The billing timing for the charge. This field is only used if the &#x60;ratePlanChargeType&#x60; value is &#x60;Recurring&#x60;.  Possible values are:  * &#x60;In Advance&#x60; * &#x60;In Arrears&#x60;  **Note:** This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/). .</param>
        /// <param name="chargeModelConfiguration">chargeModelConfiguration.</param>
        /// <param name="chargedThroughDate">The date through which a customer has been billed for the charge. .</param>
        /// <param name="creditOption">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  To use this field, you must set the &#x60;X-Zuora-WSDL-Version&#x60; request header to 114 or higher. Otherwise, an error occurs.  The way to calculate credit. See [Credit Option](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge#Credit_Option) for more information. .</param>
        /// <param name="currency">Currency used by the account. For example, &#x60;USD&#x60; or &#x60;EUR&#x60;. .</param>
        /// <param name="description">Description of the rate plan charge. .</param>
        /// <param name="discountAmount">The amount of the discount. .</param>
        /// <param name="discountApplyDetails">Container for the application details about a discount rate plan charge.   Only discount rate plan charges have values in this field. .</param>
        /// <param name="discountClass">The class that the discount belongs to. The discount class defines the order in which discount rate plan charges are applied.  For more information, see [Manage Discount Classes](https://knowledgecenter.zuora.com/BC_Subscription_Management/Product_Catalog/B_Charge_Models/Manage_Discount_Classes). .</param>
        /// <param name="discountLevel">The level of the discount. Values: &#x60;RatePlan&#x60;, &#x60;Subscription&#x60;, &#x60;Account&#x60;. .</param>
        /// <param name="discountPercentage">The amount of the discount as a percentage. .</param>
        /// <param name="dmrc">The change (delta) of monthly recurring charge exists when the change in monthly recurring revenue caused by an amendment or a new subscription. .</param>
        /// <param name="done">A value of &#x60;true&#x60; indicates that an invoice for a charge segment has been completed. A value of &#x60;false&#x60; indicates that an invoice has not been completed for the charge segment. .</param>
        /// <param name="drawdownRate">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The [conversion rate](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge#UOM_Conversion) between Usage UOM and Drawdown UOM for a [drawdown charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge). Must be a positive number (&gt;0). .</param>
        /// <param name="drawdownUom">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Unit of measurement for a [drawdown charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge). .</param>
        /// <param name="dtcv">After an amendment or an AutomatedPriceChange event, &#x60;dtcv&#x60; displays the change (delta) for the total contract value (TCV) amount for this charge, compared with its previous value with recurring charge types. .</param>
        /// <param name="effectiveEndDate">The effective end date of the rate plan charge. .</param>
        /// <param name="effectiveStartDate">The effective start date of the rate plan charge. .</param>
        /// <param name="endDateCondition">Defines when the charge ends after the charge trigger date.  If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date.  Values:  * &#x60;Subscription_End&#x60; * &#x60;Fixed_Period&#x60; * &#x60;Specific_End_Date&#x60; * &#x60;One_Time&#x60; .</param>
        /// <param name="excludeItemBillingFromRevenueAccounting">The flag to exclude rate plan charge related invoice items, invoice item adjustments, credit memo items, and debit memo items from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  .</param>
        /// <param name="excludeItemBookingFromRevenueAccounting">The flag to exclude rate plan charges from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  .</param>
        /// <param name="id">Rate plan charge ID. .</param>
        /// <param name="includedUnits">Specifies the number of units in the base set of units. .</param>
        /// <param name="isPrepaid">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Indicates whether this charge is a prepayment (topup) charge or a drawdown charge. Values: &#x60;true&#x60; or &#x60;false&#x60;. .</param>
        /// <param name="listPriceBase">List price base; possible values are:  * &#x60;Per_Billing_Period&#x60; * &#x60;Per_Month&#x60; * &#x60;Per_Week&#x60; .</param>
        /// <param name="model">Charge model; possible values are:  * &#x60;FlatFee&#x60; * &#x60;PerUnit&#x60; * &#x60;Overage&#x60; * &#x60;Volume&#x60; * &#x60;Tiered&#x60; * &#x60;TieredWithOverage&#x60; * &#x60;DiscountFixedAmount&#x60; * &#x60;DiscountPercentage&#x60; * &#x60;MultiAttributePricing&#x60; * &#x60;PreratedPerUnit&#x60; * &#x60;PreratedPricing&#x60; * &#x60;HighWatermarkVolumePricing&#x60; * &#x60;HighWatermarkTieredPricing&#x60; .</param>
        /// <param name="mrr">Monthly recurring revenue of the rate plan charge. .</param>
        /// <param name="name">Charge name. .</param>
        /// <param name="number">Charge number. .</param>
        /// <param name="numberOfPeriods">Specifies the number of periods to use when calculating charges in an overage smoothing charge model. .</param>
        /// <param name="originalChargeId">The original ID of the rate plan charge. .</param>
        /// <param name="originalOrderDate">The date when the rate plan charge is created through an order or amendment. This field is to standardize the booking date information to increase audit ability and traceability of data between Zuora Billing and Zuora Revenue. It is mapped as the booking date for a sale order line in Zuora Revenue. .</param>
        /// <param name="overageCalculationOption">Determines when to calculate overage charges. .</param>
        /// <param name="overagePrice">The price for units over the allowed amount. .</param>
        /// <param name="overageUnusedUnitsCreditOption">Determines whether to credit the customer with unused units of usage. .</param>
        /// <param name="prepaidOperationType">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The type of this charge. It is either a prepayment (topup) charge or a drawdown charge.  .</param>
        /// <param name="prepaidQuantity">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The number of units included in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). Must be a positive number (&gt;0). .</param>
        /// <param name="prepaidTotalQuantity">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The total amount of units that end customers can use during a validity period when they subscribe to a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). .</param>
        /// <param name="prepaidUom">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Unit of measurement for a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). .</param>
        /// <param name="price">The price associated with the rate plan charge expressed as a decimal. .</param>
        /// <param name="priceChangeOption">When the following is true:  1. AutomatedPriceChange setting is on  2. Charge type is not one-time  3. Charge model is not discount percentage  Then an automatic price change can have a value for when a termed subscription is renewed.   Values (one of the following):  * &#x60;NoChange&#x60; (default) * &#x60;SpecificPercentageValue&#x60; * &#x60;UseLatestProductCatalogPricing&#x60; .</param>
        /// <param name="priceIncreasePercentage">A planned future price increase amount as a percentage. .</param>
        /// <param name="pricingSummary">Concise description of rate plan charge model. .</param>
        /// <param name="processedThroughDate">The date until when charges have been processed. When billing in arrears, such as usage, this field value is the the same as the &#x60;ChargedThroughDate&#x60; value. This date is the earliest date when a charge can be amended. .</param>
        /// <param name="productRatePlanChargeId">productRatePlanChargeId.</param>
        /// <param name="quantity">The quantity of units, such as the number of authors in a hosted wiki service. Valid for all charge models except for Flat Fee pricing. .</param>
        /// <param name="ratingGroup">Specifies a rating group based on which usage records are rated.  Possible values:  - &#x60;ByBillingPeriod&#x60; (default): The rating is based on all the usages in a billing period. - &#x60;ByUsageStartDate&#x60;: The rating is based on all the usages on the same usage start date.  - &#x60;ByUsageRecord&#x60;: The rating is based on each usage record. - &#x60;ByUsageUpload&#x60;: The rating is based on all the  usages in a uploaded usage file (&#x60;.xls&#x60; or &#x60;.csv&#x60;). - &#x60;ByGroupId&#x60;: The rating is based on all the usages in a custom group.  **Note:**  - The &#x60;ByBillingPeriod&#x60; value can be applied for all charge models.  - The &#x60;ByUsageStartDate&#x60;, &#x60;ByUsageRecord&#x60;, and &#x60;ByUsageUpload&#x60; values can only be applied for per unit, volume pricing, and tiered pricing charge models.  - The &#x60;ByGroupId&#x60; value is only available if you have the Active Rating feature enabled. - Use this field only for Usage charges. One-Time Charges and Recurring Charges return &#x60;NULL&#x60;. .</param>
        /// <param name="segment">The identifying number of the subscription rate plan segment. Segments are numbered sequentially, starting with 1. .</param>
        /// <param name="smoothingModel">Specifies when revenue recognition begins. When charge model is &#x60;Overage&#x60; or &#x60;TieredWithOverage&#x60;, &#x60;smoothingModel&#x60; will be one of the following values:  * &#x60;ContractEffectiveDate&#x60; * &#x60;ServiceActivationDate&#x60; * &#x60;CustomerAcceptanceDate&#x60; .</param>
        /// <param name="specificBillingPeriod">Customizes the number of month or week for the charges billing period. This field is required if you set the value of the &#x60;BillingPeriod&#x60; field to &#x60;Specific_Months&#x60; or &#x60;Specific_Weeks&#x60;. .</param>
        /// <param name="specificEndDate">The specific date on which the charge ends. If the subscription ends before the specific end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the specific end date. .</param>
        /// <param name="tcv">The total contract value. .</param>
        /// <param name="tiers">One or many defined ranges with distinct pricing. .</param>
        /// <param name="triggerDate">The date that the rate plan charge will be triggered. .</param>
        /// <param name="triggerEvent">The event that will cause the rate plan charge to be triggered.  Possible values:   * &#x60;ContractEffective&#x60; * &#x60;ServiceActivation&#x60; * &#x60;CustomerAcceptance&#x60; * &#x60;SpecificDate&#x60; .</param>
        /// <param name="type">Charge type. Possible values are: &#x60;OneTime&#x60;, &#x60;Recurring&#x60;, &#x60;Usage&#x60;. .</param>
        /// <param name="unusedUnitsCreditRates">Specifies the rate to credit a customer for unused units of usage. This field is applicable only for overage charge models when the  &#x60;OverageUnusedUnitsCreditOption&#x60; field value is &#x60;CreditBySpecificRate&#x60;. .</param>
        /// <param name="uom">Specifies the units to measure usage.  .</param>
        /// <param name="upToPeriods">Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends.  If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. .</param>
        /// <param name="upToPeriodsType">The period type used to define when the charge ends.   Values:  * &#x60;Billing_Periods&#x60; * &#x60;Days&#x60; * &#x60;Weeks&#x60; * &#x60;Months&#x60; * &#x60;Years&#x60; .</param>
        /// <param name="usageRecordRatingOption">Determines how Zuora processes usage records for per-unit usage charges.  .</param>
        /// <param name="validityPeriodType">**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The period in which the prepayment units are valid to use as defined in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). .</param>
        /// <param name="version">Rate plan charge revision number. .</param>
        public GETSubscriptionRatePlanChargesType(string amendedByOrderOn = default(string), string applyDiscountTo = default(string), string billingDay = default(string), string billingPeriod = default(string), string billingPeriodAlignment = default(string), string billingTiming = default(string), ChargeModelConfigurationType chargeModelConfiguration = default(ChargeModelConfigurationType), DateTime chargedThroughDate = default(DateTime), CreditOptionEnum? creditOption = default(CreditOptionEnum?), string currency = default(string), string description = default(string), decimal discountAmount = default(decimal), List<GETDiscountApplyDetailsType> discountApplyDetails = default(List<GETDiscountApplyDetailsType>), string discountClass = default(string), string discountLevel = default(string), decimal discountPercentage = default(decimal), decimal dmrc = default(decimal), bool done = default(bool), decimal drawdownRate = default(decimal), string drawdownUom = default(string), decimal dtcv = default(decimal), DateTime effectiveEndDate = default(DateTime), DateTime effectiveStartDate = default(DateTime), string endDateCondition = default(string), bool excludeItemBillingFromRevenueAccounting = default(bool), bool excludeItemBookingFromRevenueAccounting = default(bool), string id = default(string), decimal includedUnits = default(decimal), bool isPrepaid = default(bool), string listPriceBase = default(string), string model = default(string), decimal mrr = default(decimal), string name = default(string), string number = default(string), long numberOfPeriods = default(long), string originalChargeId = default(string), DateTime originalOrderDate = default(DateTime), string overageCalculationOption = default(string), decimal overagePrice = default(decimal), string overageUnusedUnitsCreditOption = default(string), PrepaidOperationTypeEnum? prepaidOperationType = default(PrepaidOperationTypeEnum?), decimal prepaidQuantity = default(decimal), decimal prepaidTotalQuantity = default(decimal), string prepaidUom = default(string), decimal price = default(decimal), string priceChangeOption = default(string), decimal priceIncreasePercentage = default(decimal), string pricingSummary = default(string), DateTime processedThroughDate = default(DateTime), string productRatePlanChargeId = default(string), decimal quantity = default(decimal), string ratingGroup = default(string), long segment = default(long), string smoothingModel = default(string), long specificBillingPeriod = default(long), DateTime specificEndDate = default(DateTime), decimal tcv = default(decimal), List<GETTierType> tiers = default(List<GETTierType>), DateTime triggerDate = default(DateTime), string triggerEvent = default(string), string type = default(string), decimal unusedUnitsCreditRates = default(decimal), string uom = default(string), string upToPeriods = default(string), string upToPeriodsType = default(string), string usageRecordRatingOption = default(string), ValidityPeriodTypeEnum? validityPeriodType = default(ValidityPeriodTypeEnum?), long version = default(long))
        {
            this.AmendedByOrderOn = amendedByOrderOn;
            this.ApplyDiscountTo = applyDiscountTo;
            this.BillingDay = billingDay;
            this.BillingPeriod = billingPeriod;
            this.BillingPeriodAlignment = billingPeriodAlignment;
            this.BillingTiming = billingTiming;
            this.ChargeModelConfiguration = chargeModelConfiguration;
            this.ChargedThroughDate = chargedThroughDate;
            this.CreditOption = creditOption;
            this.Currency = currency;
            this.Description = description;
            this.DiscountAmount = discountAmount;
            this.DiscountApplyDetails = discountApplyDetails;
            this.DiscountClass = discountClass;
            this.DiscountLevel = discountLevel;
            this.DiscountPercentage = discountPercentage;
            this.Dmrc = dmrc;
            this.Done = done;
            this.DrawdownRate = drawdownRate;
            this.DrawdownUom = drawdownUom;
            this.Dtcv = dtcv;
            this.EffectiveEndDate = effectiveEndDate;
            this.EffectiveStartDate = effectiveStartDate;
            this.EndDateCondition = endDateCondition;
            this.ExcludeItemBillingFromRevenueAccounting = excludeItemBillingFromRevenueAccounting;
            this.ExcludeItemBookingFromRevenueAccounting = excludeItemBookingFromRevenueAccounting;
            this.Id = id;
            this.IncludedUnits = includedUnits;
            this.IsPrepaid = isPrepaid;
            this.ListPriceBase = listPriceBase;
            this.Model = model;
            this.Mrr = mrr;
            this.Name = name;
            this.Number = number;
            this.NumberOfPeriods = numberOfPeriods;
            this.OriginalChargeId = originalChargeId;
            this.OriginalOrderDate = originalOrderDate;
            this.OverageCalculationOption = overageCalculationOption;
            this.OveragePrice = overagePrice;
            this.OverageUnusedUnitsCreditOption = overageUnusedUnitsCreditOption;
            this.PrepaidOperationType = prepaidOperationType;
            this.PrepaidQuantity = prepaidQuantity;
            this.PrepaidTotalQuantity = prepaidTotalQuantity;
            this.PrepaidUom = prepaidUom;
            this.Price = price;
            this.PriceChangeOption = priceChangeOption;
            this.PriceIncreasePercentage = priceIncreasePercentage;
            this.PricingSummary = pricingSummary;
            this.ProcessedThroughDate = processedThroughDate;
            this.ProductRatePlanChargeId = productRatePlanChargeId;
            this.Quantity = quantity;
            this.RatingGroup = ratingGroup;
            this.Segment = segment;
            this.SmoothingModel = smoothingModel;
            this.SpecificBillingPeriod = specificBillingPeriod;
            this.SpecificEndDate = specificEndDate;
            this.Tcv = tcv;
            this.Tiers = tiers;
            this.TriggerDate = triggerDate;
            this.TriggerEvent = triggerEvent;
            this.Type = type;
            this.UnusedUnitsCreditRates = unusedUnitsCreditRates;
            this.Uom = uom;
            this.UpToPeriods = upToPeriods;
            this.UpToPeriodsType = upToPeriodsType;
            this.UsageRecordRatingOption = usageRecordRatingOption;
            this.ValidityPeriodType = validityPeriodType;
            this._Version = version;
        }

        /// <summary>
        /// The date when the rate plan charge is amended through an order or amendment. This field is to standardize the booking date information to increase audit ability and traceability of data between Zuora Billing and Zuora Revenue. It is mapped as the booking date for a sale order line in Zuora Revenue. 
        /// </summary>
        /// <value>The date when the rate plan charge is amended through an order or amendment. This field is to standardize the booking date information to increase audit ability and traceability of data between Zuora Billing and Zuora Revenue. It is mapped as the booking date for a sale order line in Zuora Revenue. </value>
        [DataMember(Name = "amendedByOrderOn", EmitDefaultValue = false)]
        public string AmendedByOrderOn { get; set; }

        /// <summary>
        /// Specifies the type of charges a specific discount applies to.   This field is only used when applied to a discount charge model. If you are not using a discount charge model, the value is null.  Possible values:  * &#x60;RECURRING&#x60; * &#x60;USAGE&#x60; * &#x60;ONETIMERECURRING&#x60; * &#x60;ONETIMEUSAGE&#x60; * &#x60;RECURRINGUSAGE&#x60; * &#x60;ONETIMERECURRINGUSAGE&#x60; 
        /// </summary>
        /// <value>Specifies the type of charges a specific discount applies to.   This field is only used when applied to a discount charge model. If you are not using a discount charge model, the value is null.  Possible values:  * &#x60;RECURRING&#x60; * &#x60;USAGE&#x60; * &#x60;ONETIMERECURRING&#x60; * &#x60;ONETIMEUSAGE&#x60; * &#x60;RECURRINGUSAGE&#x60; * &#x60;ONETIMERECURRINGUSAGE&#x60; </value>
        [DataMember(Name = "applyDiscountTo", EmitDefaultValue = false)]
        public string ApplyDiscountTo { get; set; }

        /// <summary>
        /// Billing cycle day (BCD), which is when bill runs generate invoices for charges associated with the product rate plan charge or the account.    Values:  * &#x60;DefaultFromCustomer&#x60; * &#x60;SpecificDayofMonth(#)&#x60; * &#x60;SubscriptionStartDay&#x60; * &#x60;ChargeTriggerDay&#x60; * &#x60;SpecificDayofWeek/dayofweek&#x60;: in which dayofweek is the day in the week you define your billing periods to start.  In the response data, a day-of-the-month value (&#x60;1&#x60;-&#x60;31&#x60;) appears in place of the hash sign above (\&quot;#\&quot;). If this value exceeds the number of days in a particular month, the last day of the month is used as the BCD. 
        /// </summary>
        /// <value>Billing cycle day (BCD), which is when bill runs generate invoices for charges associated with the product rate plan charge or the account.    Values:  * &#x60;DefaultFromCustomer&#x60; * &#x60;SpecificDayofMonth(#)&#x60; * &#x60;SubscriptionStartDay&#x60; * &#x60;ChargeTriggerDay&#x60; * &#x60;SpecificDayofWeek/dayofweek&#x60;: in which dayofweek is the day in the week you define your billing periods to start.  In the response data, a day-of-the-month value (&#x60;1&#x60;-&#x60;31&#x60;) appears in place of the hash sign above (\&quot;#\&quot;). If this value exceeds the number of days in a particular month, the last day of the month is used as the BCD. </value>
        [DataMember(Name = "billingDay", EmitDefaultValue = false)]
        public string BillingDay { get; set; }

        /// <summary>
        /// Allows billing period to be overridden on the rate plan charge. 
        /// </summary>
        /// <value>Allows billing period to be overridden on the rate plan charge. </value>
        [DataMember(Name = "billingPeriod", EmitDefaultValue = false)]
        public string BillingPeriod { get; set; }

        /// <summary>
        /// Possible values:  * &#x60;AlignToCharge&#x60; * &#x60;AlignToSubscriptionStart&#x60; * &#x60;AlignToTermStart&#x60; 
        /// </summary>
        /// <value>Possible values:  * &#x60;AlignToCharge&#x60; * &#x60;AlignToSubscriptionStart&#x60; * &#x60;AlignToTermStart&#x60; </value>
        [DataMember(Name = "billingPeriodAlignment", EmitDefaultValue = false)]
        public string BillingPeriodAlignment { get; set; }

        /// <summary>
        /// The billing timing for the charge. This field is only used if the &#x60;ratePlanChargeType&#x60; value is &#x60;Recurring&#x60;.  Possible values are:  * &#x60;In Advance&#x60; * &#x60;In Arrears&#x60;  **Note:** This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/). 
        /// </summary>
        /// <value>The billing timing for the charge. This field is only used if the &#x60;ratePlanChargeType&#x60; value is &#x60;Recurring&#x60;.  Possible values are:  * &#x60;In Advance&#x60; * &#x60;In Arrears&#x60;  **Note:** This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/). </value>
        [DataMember(Name = "billingTiming", EmitDefaultValue = false)]
        public string BillingTiming { get; set; }

        /// <summary>
        /// Gets or Sets ChargeModelConfiguration
        /// </summary>
        [DataMember(Name = "chargeModelConfiguration", EmitDefaultValue = false)]
        public ChargeModelConfigurationType ChargeModelConfiguration { get; set; }

        /// <summary>
        /// The date through which a customer has been billed for the charge. 
        /// </summary>
        /// <value>The date through which a customer has been billed for the charge. </value>
        [DataMember(Name = "chargedThroughDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime ChargedThroughDate { get; set; }

        /// <summary>
        /// Currency used by the account. For example, &#x60;USD&#x60; or &#x60;EUR&#x60;. 
        /// </summary>
        /// <value>Currency used by the account. For example, &#x60;USD&#x60; or &#x60;EUR&#x60;. </value>
        [DataMember(Name = "currency", EmitDefaultValue = false)]
        public string Currency { get; set; }

        /// <summary>
        /// Description of the rate plan charge. 
        /// </summary>
        /// <value>Description of the rate plan charge. </value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The amount of the discount. 
        /// </summary>
        /// <value>The amount of the discount. </value>
        [DataMember(Name = "discountAmount", EmitDefaultValue = false)]
        public decimal DiscountAmount { get; set; }

        /// <summary>
        /// Container for the application details about a discount rate plan charge.   Only discount rate plan charges have values in this field. 
        /// </summary>
        /// <value>Container for the application details about a discount rate plan charge.   Only discount rate plan charges have values in this field. </value>
        [DataMember(Name = "discountApplyDetails", EmitDefaultValue = false)]
        public List<GETDiscountApplyDetailsType> DiscountApplyDetails { get; set; }

        /// <summary>
        /// The class that the discount belongs to. The discount class defines the order in which discount rate plan charges are applied.  For more information, see [Manage Discount Classes](https://knowledgecenter.zuora.com/BC_Subscription_Management/Product_Catalog/B_Charge_Models/Manage_Discount_Classes). 
        /// </summary>
        /// <value>The class that the discount belongs to. The discount class defines the order in which discount rate plan charges are applied.  For more information, see [Manage Discount Classes](https://knowledgecenter.zuora.com/BC_Subscription_Management/Product_Catalog/B_Charge_Models/Manage_Discount_Classes). </value>
        [DataMember(Name = "discountClass", EmitDefaultValue = false)]
        public string DiscountClass { get; set; }

        /// <summary>
        /// The level of the discount. Values: &#x60;RatePlan&#x60;, &#x60;Subscription&#x60;, &#x60;Account&#x60;. 
        /// </summary>
        /// <value>The level of the discount. Values: &#x60;RatePlan&#x60;, &#x60;Subscription&#x60;, &#x60;Account&#x60;. </value>
        [DataMember(Name = "discountLevel", EmitDefaultValue = false)]
        public string DiscountLevel { get; set; }

        /// <summary>
        /// The amount of the discount as a percentage. 
        /// </summary>
        /// <value>The amount of the discount as a percentage. </value>
        [DataMember(Name = "discountPercentage", EmitDefaultValue = false)]
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// The change (delta) of monthly recurring charge exists when the change in monthly recurring revenue caused by an amendment or a new subscription. 
        /// </summary>
        /// <value>The change (delta) of monthly recurring charge exists when the change in monthly recurring revenue caused by an amendment or a new subscription. </value>
        [DataMember(Name = "dmrc", EmitDefaultValue = false)]
        public decimal Dmrc { get; set; }

        /// <summary>
        /// A value of &#x60;true&#x60; indicates that an invoice for a charge segment has been completed. A value of &#x60;false&#x60; indicates that an invoice has not been completed for the charge segment. 
        /// </summary>
        /// <value>A value of &#x60;true&#x60; indicates that an invoice for a charge segment has been completed. A value of &#x60;false&#x60; indicates that an invoice has not been completed for the charge segment. </value>
        [DataMember(Name = "done", EmitDefaultValue = true)]
        public bool Done { get; set; }

        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The [conversion rate](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge#UOM_Conversion) between Usage UOM and Drawdown UOM for a [drawdown charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge). Must be a positive number (&gt;0). 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The [conversion rate](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge#UOM_Conversion) between Usage UOM and Drawdown UOM for a [drawdown charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge). Must be a positive number (&gt;0). </value>
        [DataMember(Name = "drawdownRate", EmitDefaultValue = false)]
        public decimal DrawdownRate { get; set; }

        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Unit of measurement for a [drawdown charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge). 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Unit of measurement for a [drawdown charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_drawdown_charge). </value>
        [DataMember(Name = "drawdownUom", EmitDefaultValue = false)]
        public string DrawdownUom { get; set; }

        /// <summary>
        /// After an amendment or an AutomatedPriceChange event, &#x60;dtcv&#x60; displays the change (delta) for the total contract value (TCV) amount for this charge, compared with its previous value with recurring charge types. 
        /// </summary>
        /// <value>After an amendment or an AutomatedPriceChange event, &#x60;dtcv&#x60; displays the change (delta) for the total contract value (TCV) amount for this charge, compared with its previous value with recurring charge types. </value>
        [DataMember(Name = "dtcv", EmitDefaultValue = false)]
        public decimal Dtcv { get; set; }

        /// <summary>
        /// The effective end date of the rate plan charge. 
        /// </summary>
        /// <value>The effective end date of the rate plan charge. </value>
        [DataMember(Name = "effectiveEndDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime EffectiveEndDate { get; set; }

        /// <summary>
        /// The effective start date of the rate plan charge. 
        /// </summary>
        /// <value>The effective start date of the rate plan charge. </value>
        [DataMember(Name = "effectiveStartDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime EffectiveStartDate { get; set; }

        /// <summary>
        /// Defines when the charge ends after the charge trigger date.  If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date.  Values:  * &#x60;Subscription_End&#x60; * &#x60;Fixed_Period&#x60; * &#x60;Specific_End_Date&#x60; * &#x60;One_Time&#x60; 
        /// </summary>
        /// <value>Defines when the charge ends after the charge trigger date.  If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date.  Values:  * &#x60;Subscription_End&#x60; * &#x60;Fixed_Period&#x60; * &#x60;Specific_End_Date&#x60; * &#x60;One_Time&#x60; </value>
        [DataMember(Name = "endDateCondition", EmitDefaultValue = false)]
        public string EndDateCondition { get; set; }

        /// <summary>
        /// The flag to exclude rate plan charge related invoice items, invoice item adjustments, credit memo items, and debit memo items from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  
        /// </summary>
        /// <value>The flag to exclude rate plan charge related invoice items, invoice item adjustments, credit memo items, and debit memo items from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  </value>
        [DataMember(Name = "excludeItemBillingFromRevenueAccounting", EmitDefaultValue = true)]
        public bool ExcludeItemBillingFromRevenueAccounting { get; set; }

        /// <summary>
        /// The flag to exclude rate plan charges from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  
        /// </summary>
        /// <value>The flag to exclude rate plan charges from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  </value>
        [DataMember(Name = "excludeItemBookingFromRevenueAccounting", EmitDefaultValue = true)]
        public bool ExcludeItemBookingFromRevenueAccounting { get; set; }

        /// <summary>
        /// Rate plan charge ID. 
        /// </summary>
        /// <value>Rate plan charge ID. </value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Specifies the number of units in the base set of units. 
        /// </summary>
        /// <value>Specifies the number of units in the base set of units. </value>
        [DataMember(Name = "includedUnits", EmitDefaultValue = false)]
        public decimal IncludedUnits { get; set; }

        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Indicates whether this charge is a prepayment (topup) charge or a drawdown charge. Values: &#x60;true&#x60; or &#x60;false&#x60;. 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Indicates whether this charge is a prepayment (topup) charge or a drawdown charge. Values: &#x60;true&#x60; or &#x60;false&#x60;. </value>
        [DataMember(Name = "isPrepaid", EmitDefaultValue = true)]
        public bool IsPrepaid { get; set; }

        /// <summary>
        /// List price base; possible values are:  * &#x60;Per_Billing_Period&#x60; * &#x60;Per_Month&#x60; * &#x60;Per_Week&#x60; 
        /// </summary>
        /// <value>List price base; possible values are:  * &#x60;Per_Billing_Period&#x60; * &#x60;Per_Month&#x60; * &#x60;Per_Week&#x60; </value>
        [DataMember(Name = "listPriceBase", EmitDefaultValue = false)]
        public string ListPriceBase { get; set; }

        /// <summary>
        /// Charge model; possible values are:  * &#x60;FlatFee&#x60; * &#x60;PerUnit&#x60; * &#x60;Overage&#x60; * &#x60;Volume&#x60; * &#x60;Tiered&#x60; * &#x60;TieredWithOverage&#x60; * &#x60;DiscountFixedAmount&#x60; * &#x60;DiscountPercentage&#x60; * &#x60;MultiAttributePricing&#x60; * &#x60;PreratedPerUnit&#x60; * &#x60;PreratedPricing&#x60; * &#x60;HighWatermarkVolumePricing&#x60; * &#x60;HighWatermarkTieredPricing&#x60; 
        /// </summary>
        /// <value>Charge model; possible values are:  * &#x60;FlatFee&#x60; * &#x60;PerUnit&#x60; * &#x60;Overage&#x60; * &#x60;Volume&#x60; * &#x60;Tiered&#x60; * &#x60;TieredWithOverage&#x60; * &#x60;DiscountFixedAmount&#x60; * &#x60;DiscountPercentage&#x60; * &#x60;MultiAttributePricing&#x60; * &#x60;PreratedPerUnit&#x60; * &#x60;PreratedPricing&#x60; * &#x60;HighWatermarkVolumePricing&#x60; * &#x60;HighWatermarkTieredPricing&#x60; </value>
        [DataMember(Name = "model", EmitDefaultValue = false)]
        public string Model { get; set; }

        /// <summary>
        /// Monthly recurring revenue of the rate plan charge. 
        /// </summary>
        /// <value>Monthly recurring revenue of the rate plan charge. </value>
        [DataMember(Name = "mrr", EmitDefaultValue = false)]
        public decimal Mrr { get; set; }

        /// <summary>
        /// Charge name. 
        /// </summary>
        /// <value>Charge name. </value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Charge number. 
        /// </summary>
        /// <value>Charge number. </value>
        [DataMember(Name = "number", EmitDefaultValue = false)]
        public string Number { get; set; }

        /// <summary>
        /// Specifies the number of periods to use when calculating charges in an overage smoothing charge model. 
        /// </summary>
        /// <value>Specifies the number of periods to use when calculating charges in an overage smoothing charge model. </value>
        [DataMember(Name = "numberOfPeriods", EmitDefaultValue = false)]
        public long NumberOfPeriods { get; set; }

        /// <summary>
        /// The original ID of the rate plan charge. 
        /// </summary>
        /// <value>The original ID of the rate plan charge. </value>
        [DataMember(Name = "originalChargeId", EmitDefaultValue = false)]
        public string OriginalChargeId { get; set; }

        /// <summary>
        /// The date when the rate plan charge is created through an order or amendment. This field is to standardize the booking date information to increase audit ability and traceability of data between Zuora Billing and Zuora Revenue. It is mapped as the booking date for a sale order line in Zuora Revenue. 
        /// </summary>
        /// <value>The date when the rate plan charge is created through an order or amendment. This field is to standardize the booking date information to increase audit ability and traceability of data between Zuora Billing and Zuora Revenue. It is mapped as the booking date for a sale order line in Zuora Revenue. </value>
        [DataMember(Name = "originalOrderDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime OriginalOrderDate { get; set; }

        /// <summary>
        /// Determines when to calculate overage charges. 
        /// </summary>
        /// <value>Determines when to calculate overage charges. </value>
        [DataMember(Name = "overageCalculationOption", EmitDefaultValue = false)]
        public string OverageCalculationOption { get; set; }

        /// <summary>
        /// The price for units over the allowed amount. 
        /// </summary>
        /// <value>The price for units over the allowed amount. </value>
        [DataMember(Name = "overagePrice", EmitDefaultValue = false)]
        public decimal OveragePrice { get; set; }

        /// <summary>
        /// Determines whether to credit the customer with unused units of usage. 
        /// </summary>
        /// <value>Determines whether to credit the customer with unused units of usage. </value>
        [DataMember(Name = "overageUnusedUnitsCreditOption", EmitDefaultValue = false)]
        public string OverageUnusedUnitsCreditOption { get; set; }

        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The number of units included in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). Must be a positive number (&gt;0). 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The number of units included in a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). Must be a positive number (&gt;0). </value>
        [DataMember(Name = "prepaidQuantity", EmitDefaultValue = false)]
        public decimal PrepaidQuantity { get; set; }

        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The total amount of units that end customers can use during a validity period when they subscribe to a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  The total amount of units that end customers can use during a validity period when they subscribe to a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). </value>
        [DataMember(Name = "prepaidTotalQuantity", EmitDefaultValue = false)]
        public decimal PrepaidTotalQuantity { get; set; }

        /// <summary>
        /// **Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Unit of measurement for a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). 
        /// </summary>
        /// <value>**Note**: This field is only available if you have the [Prepaid with Drawdown](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown) feature enabled.  Unit of measurement for a [prepayment charge](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Prepaid_with_Drawdown/Create_prepayment_charge). </value>
        [DataMember(Name = "prepaidUom", EmitDefaultValue = false)]
        public string PrepaidUom { get; set; }

        /// <summary>
        /// The price associated with the rate plan charge expressed as a decimal. 
        /// </summary>
        /// <value>The price associated with the rate plan charge expressed as a decimal. </value>
        [DataMember(Name = "price", EmitDefaultValue = false)]
        public decimal Price { get; set; }

        /// <summary>
        /// When the following is true:  1. AutomatedPriceChange setting is on  2. Charge type is not one-time  3. Charge model is not discount percentage  Then an automatic price change can have a value for when a termed subscription is renewed.   Values (one of the following):  * &#x60;NoChange&#x60; (default) * &#x60;SpecificPercentageValue&#x60; * &#x60;UseLatestProductCatalogPricing&#x60; 
        /// </summary>
        /// <value>When the following is true:  1. AutomatedPriceChange setting is on  2. Charge type is not one-time  3. Charge model is not discount percentage  Then an automatic price change can have a value for when a termed subscription is renewed.   Values (one of the following):  * &#x60;NoChange&#x60; (default) * &#x60;SpecificPercentageValue&#x60; * &#x60;UseLatestProductCatalogPricing&#x60; </value>
        [DataMember(Name = "priceChangeOption", EmitDefaultValue = false)]
        public string PriceChangeOption { get; set; }

        /// <summary>
        /// A planned future price increase amount as a percentage. 
        /// </summary>
        /// <value>A planned future price increase amount as a percentage. </value>
        [DataMember(Name = "priceIncreasePercentage", EmitDefaultValue = false)]
        public decimal PriceIncreasePercentage { get; set; }

        /// <summary>
        /// Concise description of rate plan charge model. 
        /// </summary>
        /// <value>Concise description of rate plan charge model. </value>
        [DataMember(Name = "pricingSummary", EmitDefaultValue = false)]
        public string PricingSummary { get; set; }

        /// <summary>
        /// The date until when charges have been processed. When billing in arrears, such as usage, this field value is the the same as the &#x60;ChargedThroughDate&#x60; value. This date is the earliest date when a charge can be amended. 
        /// </summary>
        /// <value>The date until when charges have been processed. When billing in arrears, such as usage, this field value is the the same as the &#x60;ChargedThroughDate&#x60; value. This date is the earliest date when a charge can be amended. </value>
        [DataMember(Name = "processedThroughDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime ProcessedThroughDate { get; set; }

        /// <summary>
        /// Gets or Sets ProductRatePlanChargeId
        /// </summary>
        [DataMember(Name = "productRatePlanChargeId", EmitDefaultValue = false)]
        public string ProductRatePlanChargeId { get; set; }

        /// <summary>
        /// The quantity of units, such as the number of authors in a hosted wiki service. Valid for all charge models except for Flat Fee pricing. 
        /// </summary>
        /// <value>The quantity of units, such as the number of authors in a hosted wiki service. Valid for all charge models except for Flat Fee pricing. </value>
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Specifies a rating group based on which usage records are rated.  Possible values:  - &#x60;ByBillingPeriod&#x60; (default): The rating is based on all the usages in a billing period. - &#x60;ByUsageStartDate&#x60;: The rating is based on all the usages on the same usage start date.  - &#x60;ByUsageRecord&#x60;: The rating is based on each usage record. - &#x60;ByUsageUpload&#x60;: The rating is based on all the  usages in a uploaded usage file (&#x60;.xls&#x60; or &#x60;.csv&#x60;). - &#x60;ByGroupId&#x60;: The rating is based on all the usages in a custom group.  **Note:**  - The &#x60;ByBillingPeriod&#x60; value can be applied for all charge models.  - The &#x60;ByUsageStartDate&#x60;, &#x60;ByUsageRecord&#x60;, and &#x60;ByUsageUpload&#x60; values can only be applied for per unit, volume pricing, and tiered pricing charge models.  - The &#x60;ByGroupId&#x60; value is only available if you have the Active Rating feature enabled. - Use this field only for Usage charges. One-Time Charges and Recurring Charges return &#x60;NULL&#x60;. 
        /// </summary>
        /// <value>Specifies a rating group based on which usage records are rated.  Possible values:  - &#x60;ByBillingPeriod&#x60; (default): The rating is based on all the usages in a billing period. - &#x60;ByUsageStartDate&#x60;: The rating is based on all the usages on the same usage start date.  - &#x60;ByUsageRecord&#x60;: The rating is based on each usage record. - &#x60;ByUsageUpload&#x60;: The rating is based on all the  usages in a uploaded usage file (&#x60;.xls&#x60; or &#x60;.csv&#x60;). - &#x60;ByGroupId&#x60;: The rating is based on all the usages in a custom group.  **Note:**  - The &#x60;ByBillingPeriod&#x60; value can be applied for all charge models.  - The &#x60;ByUsageStartDate&#x60;, &#x60;ByUsageRecord&#x60;, and &#x60;ByUsageUpload&#x60; values can only be applied for per unit, volume pricing, and tiered pricing charge models.  - The &#x60;ByGroupId&#x60; value is only available if you have the Active Rating feature enabled. - Use this field only for Usage charges. One-Time Charges and Recurring Charges return &#x60;NULL&#x60;. </value>
        [DataMember(Name = "ratingGroup", EmitDefaultValue = false)]
        public string RatingGroup { get; set; }

        /// <summary>
        /// The identifying number of the subscription rate plan segment. Segments are numbered sequentially, starting with 1. 
        /// </summary>
        /// <value>The identifying number of the subscription rate plan segment. Segments are numbered sequentially, starting with 1. </value>
        [DataMember(Name = "segment", EmitDefaultValue = false)]
        public long Segment { get; set; }

        /// <summary>
        /// Specifies when revenue recognition begins. When charge model is &#x60;Overage&#x60; or &#x60;TieredWithOverage&#x60;, &#x60;smoothingModel&#x60; will be one of the following values:  * &#x60;ContractEffectiveDate&#x60; * &#x60;ServiceActivationDate&#x60; * &#x60;CustomerAcceptanceDate&#x60; 
        /// </summary>
        /// <value>Specifies when revenue recognition begins. When charge model is &#x60;Overage&#x60; or &#x60;TieredWithOverage&#x60;, &#x60;smoothingModel&#x60; will be one of the following values:  * &#x60;ContractEffectiveDate&#x60; * &#x60;ServiceActivationDate&#x60; * &#x60;CustomerAcceptanceDate&#x60; </value>
        [DataMember(Name = "smoothingModel", EmitDefaultValue = false)]
        public string SmoothingModel { get; set; }

        /// <summary>
        /// Customizes the number of month or week for the charges billing period. This field is required if you set the value of the &#x60;BillingPeriod&#x60; field to &#x60;Specific_Months&#x60; or &#x60;Specific_Weeks&#x60;. 
        /// </summary>
        /// <value>Customizes the number of month or week for the charges billing period. This field is required if you set the value of the &#x60;BillingPeriod&#x60; field to &#x60;Specific_Months&#x60; or &#x60;Specific_Weeks&#x60;. </value>
        [DataMember(Name = "specificBillingPeriod", EmitDefaultValue = false)]
        public long SpecificBillingPeriod { get; set; }

        /// <summary>
        /// The specific date on which the charge ends. If the subscription ends before the specific end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the specific end date. 
        /// </summary>
        /// <value>The specific date on which the charge ends. If the subscription ends before the specific end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the specific end date. </value>
        [DataMember(Name = "specificEndDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime SpecificEndDate { get; set; }

        /// <summary>
        /// The total contract value. 
        /// </summary>
        /// <value>The total contract value. </value>
        [DataMember(Name = "tcv", EmitDefaultValue = false)]
        public decimal Tcv { get; set; }

        /// <summary>
        /// One or many defined ranges with distinct pricing. 
        /// </summary>
        /// <value>One or many defined ranges with distinct pricing. </value>
        [DataMember(Name = "tiers", EmitDefaultValue = false)]
        public List<GETTierType> Tiers { get; set; }

        /// <summary>
        /// The date that the rate plan charge will be triggered. 
        /// </summary>
        /// <value>The date that the rate plan charge will be triggered. </value>
        [DataMember(Name = "triggerDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime TriggerDate { get; set; }

        /// <summary>
        /// The event that will cause the rate plan charge to be triggered.  Possible values:   * &#x60;ContractEffective&#x60; * &#x60;ServiceActivation&#x60; * &#x60;CustomerAcceptance&#x60; * &#x60;SpecificDate&#x60; 
        /// </summary>
        /// <value>The event that will cause the rate plan charge to be triggered.  Possible values:   * &#x60;ContractEffective&#x60; * &#x60;ServiceActivation&#x60; * &#x60;CustomerAcceptance&#x60; * &#x60;SpecificDate&#x60; </value>
        [DataMember(Name = "triggerEvent", EmitDefaultValue = false)]
        public string TriggerEvent { get; set; }

        /// <summary>
        /// Charge type. Possible values are: &#x60;OneTime&#x60;, &#x60;Recurring&#x60;, &#x60;Usage&#x60;. 
        /// </summary>
        /// <value>Charge type. Possible values are: &#x60;OneTime&#x60;, &#x60;Recurring&#x60;, &#x60;Usage&#x60;. </value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Specifies the rate to credit a customer for unused units of usage. This field is applicable only for overage charge models when the  &#x60;OverageUnusedUnitsCreditOption&#x60; field value is &#x60;CreditBySpecificRate&#x60;. 
        /// </summary>
        /// <value>Specifies the rate to credit a customer for unused units of usage. This field is applicable only for overage charge models when the  &#x60;OverageUnusedUnitsCreditOption&#x60; field value is &#x60;CreditBySpecificRate&#x60;. </value>
        [DataMember(Name = "unusedUnitsCreditRates", EmitDefaultValue = false)]
        public decimal UnusedUnitsCreditRates { get; set; }

        /// <summary>
        /// Specifies the units to measure usage.  
        /// </summary>
        /// <value>Specifies the units to measure usage.  </value>
        [DataMember(Name = "uom", EmitDefaultValue = false)]
        public string Uom { get; set; }

        /// <summary>
        /// Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends.  If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. 
        /// </summary>
        /// <value>Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends.  If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. </value>
        [DataMember(Name = "upToPeriods", EmitDefaultValue = false)]
        public string UpToPeriods { get; set; }

        /// <summary>
        /// The period type used to define when the charge ends.   Values:  * &#x60;Billing_Periods&#x60; * &#x60;Days&#x60; * &#x60;Weeks&#x60; * &#x60;Months&#x60; * &#x60;Years&#x60; 
        /// </summary>
        /// <value>The period type used to define when the charge ends.   Values:  * &#x60;Billing_Periods&#x60; * &#x60;Days&#x60; * &#x60;Weeks&#x60; * &#x60;Months&#x60; * &#x60;Years&#x60; </value>
        [DataMember(Name = "upToPeriodsType", EmitDefaultValue = false)]
        public string UpToPeriodsType { get; set; }

        /// <summary>
        /// Determines how Zuora processes usage records for per-unit usage charges.  
        /// </summary>
        /// <value>Determines how Zuora processes usage records for per-unit usage charges.  </value>
        [DataMember(Name = "usageRecordRatingOption", EmitDefaultValue = false)]
        public string UsageRecordRatingOption { get; set; }

        /// <summary>
        /// Rate plan charge revision number. 
        /// </summary>
        /// <value>Rate plan charge revision number. </value>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public long _Version { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class GETSubscriptionRatePlanChargesType {\n");
            sb.Append("  AmendedByOrderOn: ").Append(AmendedByOrderOn).Append("\n");
            sb.Append("  ApplyDiscountTo: ").Append(ApplyDiscountTo).Append("\n");
            sb.Append("  BillingDay: ").Append(BillingDay).Append("\n");
            sb.Append("  BillingPeriod: ").Append(BillingPeriod).Append("\n");
            sb.Append("  BillingPeriodAlignment: ").Append(BillingPeriodAlignment).Append("\n");
            sb.Append("  BillingTiming: ").Append(BillingTiming).Append("\n");
            sb.Append("  ChargeModelConfiguration: ").Append(ChargeModelConfiguration).Append("\n");
            sb.Append("  ChargedThroughDate: ").Append(ChargedThroughDate).Append("\n");
            sb.Append("  CreditOption: ").Append(CreditOption).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DiscountAmount: ").Append(DiscountAmount).Append("\n");
            sb.Append("  DiscountApplyDetails: ").Append(DiscountApplyDetails).Append("\n");
            sb.Append("  DiscountClass: ").Append(DiscountClass).Append("\n");
            sb.Append("  DiscountLevel: ").Append(DiscountLevel).Append("\n");
            sb.Append("  DiscountPercentage: ").Append(DiscountPercentage).Append("\n");
            sb.Append("  Dmrc: ").Append(Dmrc).Append("\n");
            sb.Append("  Done: ").Append(Done).Append("\n");
            sb.Append("  DrawdownRate: ").Append(DrawdownRate).Append("\n");
            sb.Append("  DrawdownUom: ").Append(DrawdownUom).Append("\n");
            sb.Append("  Dtcv: ").Append(Dtcv).Append("\n");
            sb.Append("  EffectiveEndDate: ").Append(EffectiveEndDate).Append("\n");
            sb.Append("  EffectiveStartDate: ").Append(EffectiveStartDate).Append("\n");
            sb.Append("  EndDateCondition: ").Append(EndDateCondition).Append("\n");
            sb.Append("  ExcludeItemBillingFromRevenueAccounting: ").Append(ExcludeItemBillingFromRevenueAccounting).Append("\n");
            sb.Append("  ExcludeItemBookingFromRevenueAccounting: ").Append(ExcludeItemBookingFromRevenueAccounting).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IncludedUnits: ").Append(IncludedUnits).Append("\n");
            sb.Append("  IsPrepaid: ").Append(IsPrepaid).Append("\n");
            sb.Append("  ListPriceBase: ").Append(ListPriceBase).Append("\n");
            sb.Append("  Model: ").Append(Model).Append("\n");
            sb.Append("  Mrr: ").Append(Mrr).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Number: ").Append(Number).Append("\n");
            sb.Append("  NumberOfPeriods: ").Append(NumberOfPeriods).Append("\n");
            sb.Append("  OriginalChargeId: ").Append(OriginalChargeId).Append("\n");
            sb.Append("  OriginalOrderDate: ").Append(OriginalOrderDate).Append("\n");
            sb.Append("  OverageCalculationOption: ").Append(OverageCalculationOption).Append("\n");
            sb.Append("  OveragePrice: ").Append(OveragePrice).Append("\n");
            sb.Append("  OverageUnusedUnitsCreditOption: ").Append(OverageUnusedUnitsCreditOption).Append("\n");
            sb.Append("  PrepaidOperationType: ").Append(PrepaidOperationType).Append("\n");
            sb.Append("  PrepaidQuantity: ").Append(PrepaidQuantity).Append("\n");
            sb.Append("  PrepaidTotalQuantity: ").Append(PrepaidTotalQuantity).Append("\n");
            sb.Append("  PrepaidUom: ").Append(PrepaidUom).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  PriceChangeOption: ").Append(PriceChangeOption).Append("\n");
            sb.Append("  PriceIncreasePercentage: ").Append(PriceIncreasePercentage).Append("\n");
            sb.Append("  PricingSummary: ").Append(PricingSummary).Append("\n");
            sb.Append("  ProcessedThroughDate: ").Append(ProcessedThroughDate).Append("\n");
            sb.Append("  ProductRatePlanChargeId: ").Append(ProductRatePlanChargeId).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  RatingGroup: ").Append(RatingGroup).Append("\n");
            sb.Append("  Segment: ").Append(Segment).Append("\n");
            sb.Append("  SmoothingModel: ").Append(SmoothingModel).Append("\n");
            sb.Append("  SpecificBillingPeriod: ").Append(SpecificBillingPeriod).Append("\n");
            sb.Append("  SpecificEndDate: ").Append(SpecificEndDate).Append("\n");
            sb.Append("  Tcv: ").Append(Tcv).Append("\n");
            sb.Append("  Tiers: ").Append(Tiers).Append("\n");
            sb.Append("  TriggerDate: ").Append(TriggerDate).Append("\n");
            sb.Append("  TriggerEvent: ").Append(TriggerEvent).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  UnusedUnitsCreditRates: ").Append(UnusedUnitsCreditRates).Append("\n");
            sb.Append("  Uom: ").Append(Uom).Append("\n");
            sb.Append("  UpToPeriods: ").Append(UpToPeriods).Append("\n");
            sb.Append("  UpToPeriodsType: ").Append(UpToPeriodsType).Append("\n");
            sb.Append("  UsageRecordRatingOption: ").Append(UsageRecordRatingOption).Append("\n");
            sb.Append("  ValidityPeriodType: ").Append(ValidityPeriodType).Append("\n");
            sb.Append("  _Version: ").Append(_Version).Append("\n");
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
            return this.Equals(input as GETSubscriptionRatePlanChargesType);
        }

        /// <summary>
        /// Returns true if GETSubscriptionRatePlanChargesType instances are equal
        /// </summary>
        /// <param name="input">Instance of GETSubscriptionRatePlanChargesType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GETSubscriptionRatePlanChargesType input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AmendedByOrderOn == input.AmendedByOrderOn ||
                    (this.AmendedByOrderOn != null &&
                    this.AmendedByOrderOn.Equals(input.AmendedByOrderOn))
                ) && 
                (
                    this.ApplyDiscountTo == input.ApplyDiscountTo ||
                    (this.ApplyDiscountTo != null &&
                    this.ApplyDiscountTo.Equals(input.ApplyDiscountTo))
                ) && 
                (
                    this.BillingDay == input.BillingDay ||
                    (this.BillingDay != null &&
                    this.BillingDay.Equals(input.BillingDay))
                ) && 
                (
                    this.BillingPeriod == input.BillingPeriod ||
                    (this.BillingPeriod != null &&
                    this.BillingPeriod.Equals(input.BillingPeriod))
                ) && 
                (
                    this.BillingPeriodAlignment == input.BillingPeriodAlignment ||
                    (this.BillingPeriodAlignment != null &&
                    this.BillingPeriodAlignment.Equals(input.BillingPeriodAlignment))
                ) && 
                (
                    this.BillingTiming == input.BillingTiming ||
                    (this.BillingTiming != null &&
                    this.BillingTiming.Equals(input.BillingTiming))
                ) && 
                (
                    this.ChargeModelConfiguration == input.ChargeModelConfiguration ||
                    (this.ChargeModelConfiguration != null &&
                    this.ChargeModelConfiguration.Equals(input.ChargeModelConfiguration))
                ) && 
                (
                    this.ChargedThroughDate == input.ChargedThroughDate ||
                    (this.ChargedThroughDate != null &&
                    this.ChargedThroughDate.Equals(input.ChargedThroughDate))
                ) && 
                (
                    this.CreditOption == input.CreditOption ||
                    this.CreditOption.Equals(input.CreditOption)
                ) && 
                (
                    this.Currency == input.Currency ||
                    (this.Currency != null &&
                    this.Currency.Equals(input.Currency))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.DiscountAmount == input.DiscountAmount ||
                    this.DiscountAmount.Equals(input.DiscountAmount)
                ) && 
                (
                    this.DiscountApplyDetails == input.DiscountApplyDetails ||
                    this.DiscountApplyDetails != null &&
                    input.DiscountApplyDetails != null &&
                    this.DiscountApplyDetails.SequenceEqual(input.DiscountApplyDetails)
                ) && 
                (
                    this.DiscountClass == input.DiscountClass ||
                    (this.DiscountClass != null &&
                    this.DiscountClass.Equals(input.DiscountClass))
                ) && 
                (
                    this.DiscountLevel == input.DiscountLevel ||
                    (this.DiscountLevel != null &&
                    this.DiscountLevel.Equals(input.DiscountLevel))
                ) && 
                (
                    this.DiscountPercentage == input.DiscountPercentage ||
                    this.DiscountPercentage.Equals(input.DiscountPercentage)
                ) && 
                (
                    this.Dmrc == input.Dmrc ||
                    this.Dmrc.Equals(input.Dmrc)
                ) && 
                (
                    this.Done == input.Done ||
                    this.Done.Equals(input.Done)
                ) && 
                (
                    this.DrawdownRate == input.DrawdownRate ||
                    this.DrawdownRate.Equals(input.DrawdownRate)
                ) && 
                (
                    this.DrawdownUom == input.DrawdownUom ||
                    (this.DrawdownUom != null &&
                    this.DrawdownUom.Equals(input.DrawdownUom))
                ) && 
                (
                    this.Dtcv == input.Dtcv ||
                    this.Dtcv.Equals(input.Dtcv)
                ) && 
                (
                    this.EffectiveEndDate == input.EffectiveEndDate ||
                    (this.EffectiveEndDate != null &&
                    this.EffectiveEndDate.Equals(input.EffectiveEndDate))
                ) && 
                (
                    this.EffectiveStartDate == input.EffectiveStartDate ||
                    (this.EffectiveStartDate != null &&
                    this.EffectiveStartDate.Equals(input.EffectiveStartDate))
                ) && 
                (
                    this.EndDateCondition == input.EndDateCondition ||
                    (this.EndDateCondition != null &&
                    this.EndDateCondition.Equals(input.EndDateCondition))
                ) && 
                (
                    this.ExcludeItemBillingFromRevenueAccounting == input.ExcludeItemBillingFromRevenueAccounting ||
                    this.ExcludeItemBillingFromRevenueAccounting.Equals(input.ExcludeItemBillingFromRevenueAccounting)
                ) && 
                (
                    this.ExcludeItemBookingFromRevenueAccounting == input.ExcludeItemBookingFromRevenueAccounting ||
                    this.ExcludeItemBookingFromRevenueAccounting.Equals(input.ExcludeItemBookingFromRevenueAccounting)
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.IncludedUnits == input.IncludedUnits ||
                    this.IncludedUnits.Equals(input.IncludedUnits)
                ) && 
                (
                    this.IsPrepaid == input.IsPrepaid ||
                    this.IsPrepaid.Equals(input.IsPrepaid)
                ) && 
                (
                    this.ListPriceBase == input.ListPriceBase ||
                    (this.ListPriceBase != null &&
                    this.ListPriceBase.Equals(input.ListPriceBase))
                ) && 
                (
                    this.Model == input.Model ||
                    (this.Model != null &&
                    this.Model.Equals(input.Model))
                ) && 
                (
                    this.Mrr == input.Mrr ||
                    this.Mrr.Equals(input.Mrr)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Number == input.Number ||
                    (this.Number != null &&
                    this.Number.Equals(input.Number))
                ) && 
                (
                    this.NumberOfPeriods == input.NumberOfPeriods ||
                    this.NumberOfPeriods.Equals(input.NumberOfPeriods)
                ) && 
                (
                    this.OriginalChargeId == input.OriginalChargeId ||
                    (this.OriginalChargeId != null &&
                    this.OriginalChargeId.Equals(input.OriginalChargeId))
                ) && 
                (
                    this.OriginalOrderDate == input.OriginalOrderDate ||
                    (this.OriginalOrderDate != null &&
                    this.OriginalOrderDate.Equals(input.OriginalOrderDate))
                ) && 
                (
                    this.OverageCalculationOption == input.OverageCalculationOption ||
                    (this.OverageCalculationOption != null &&
                    this.OverageCalculationOption.Equals(input.OverageCalculationOption))
                ) && 
                (
                    this.OveragePrice == input.OveragePrice ||
                    this.OveragePrice.Equals(input.OveragePrice)
                ) && 
                (
                    this.OverageUnusedUnitsCreditOption == input.OverageUnusedUnitsCreditOption ||
                    (this.OverageUnusedUnitsCreditOption != null &&
                    this.OverageUnusedUnitsCreditOption.Equals(input.OverageUnusedUnitsCreditOption))
                ) && 
                (
                    this.PrepaidOperationType == input.PrepaidOperationType ||
                    this.PrepaidOperationType.Equals(input.PrepaidOperationType)
                ) && 
                (
                    this.PrepaidQuantity == input.PrepaidQuantity ||
                    this.PrepaidQuantity.Equals(input.PrepaidQuantity)
                ) && 
                (
                    this.PrepaidTotalQuantity == input.PrepaidTotalQuantity ||
                    this.PrepaidTotalQuantity.Equals(input.PrepaidTotalQuantity)
                ) && 
                (
                    this.PrepaidUom == input.PrepaidUom ||
                    (this.PrepaidUom != null &&
                    this.PrepaidUom.Equals(input.PrepaidUom))
                ) && 
                (
                    this.Price == input.Price ||
                    this.Price.Equals(input.Price)
                ) && 
                (
                    this.PriceChangeOption == input.PriceChangeOption ||
                    (this.PriceChangeOption != null &&
                    this.PriceChangeOption.Equals(input.PriceChangeOption))
                ) && 
                (
                    this.PriceIncreasePercentage == input.PriceIncreasePercentage ||
                    this.PriceIncreasePercentage.Equals(input.PriceIncreasePercentage)
                ) && 
                (
                    this.PricingSummary == input.PricingSummary ||
                    (this.PricingSummary != null &&
                    this.PricingSummary.Equals(input.PricingSummary))
                ) && 
                (
                    this.ProcessedThroughDate == input.ProcessedThroughDate ||
                    (this.ProcessedThroughDate != null &&
                    this.ProcessedThroughDate.Equals(input.ProcessedThroughDate))
                ) && 
                (
                    this.ProductRatePlanChargeId == input.ProductRatePlanChargeId ||
                    (this.ProductRatePlanChargeId != null &&
                    this.ProductRatePlanChargeId.Equals(input.ProductRatePlanChargeId))
                ) && 
                (
                    this.Quantity == input.Quantity ||
                    this.Quantity.Equals(input.Quantity)
                ) && 
                (
                    this.RatingGroup == input.RatingGroup ||
                    (this.RatingGroup != null &&
                    this.RatingGroup.Equals(input.RatingGroup))
                ) && 
                (
                    this.Segment == input.Segment ||
                    this.Segment.Equals(input.Segment)
                ) && 
                (
                    this.SmoothingModel == input.SmoothingModel ||
                    (this.SmoothingModel != null &&
                    this.SmoothingModel.Equals(input.SmoothingModel))
                ) && 
                (
                    this.SpecificBillingPeriod == input.SpecificBillingPeriod ||
                    this.SpecificBillingPeriod.Equals(input.SpecificBillingPeriod)
                ) && 
                (
                    this.SpecificEndDate == input.SpecificEndDate ||
                    (this.SpecificEndDate != null &&
                    this.SpecificEndDate.Equals(input.SpecificEndDate))
                ) && 
                (
                    this.Tcv == input.Tcv ||
                    this.Tcv.Equals(input.Tcv)
                ) && 
                (
                    this.Tiers == input.Tiers ||
                    this.Tiers != null &&
                    input.Tiers != null &&
                    this.Tiers.SequenceEqual(input.Tiers)
                ) && 
                (
                    this.TriggerDate == input.TriggerDate ||
                    (this.TriggerDate != null &&
                    this.TriggerDate.Equals(input.TriggerDate))
                ) && 
                (
                    this.TriggerEvent == input.TriggerEvent ||
                    (this.TriggerEvent != null &&
                    this.TriggerEvent.Equals(input.TriggerEvent))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.UnusedUnitsCreditRates == input.UnusedUnitsCreditRates ||
                    this.UnusedUnitsCreditRates.Equals(input.UnusedUnitsCreditRates)
                ) && 
                (
                    this.Uom == input.Uom ||
                    (this.Uom != null &&
                    this.Uom.Equals(input.Uom))
                ) && 
                (
                    this.UpToPeriods == input.UpToPeriods ||
                    (this.UpToPeriods != null &&
                    this.UpToPeriods.Equals(input.UpToPeriods))
                ) && 
                (
                    this.UpToPeriodsType == input.UpToPeriodsType ||
                    (this.UpToPeriodsType != null &&
                    this.UpToPeriodsType.Equals(input.UpToPeriodsType))
                ) && 
                (
                    this.UsageRecordRatingOption == input.UsageRecordRatingOption ||
                    (this.UsageRecordRatingOption != null &&
                    this.UsageRecordRatingOption.Equals(input.UsageRecordRatingOption))
                ) && 
                (
                    this.ValidityPeriodType == input.ValidityPeriodType ||
                    this.ValidityPeriodType.Equals(input.ValidityPeriodType)
                ) && 
                (
                    this._Version == input._Version ||
                    this._Version.Equals(input._Version)
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
                if (this.AmendedByOrderOn != null)
                {
                    hashCode = (hashCode * 59) + this.AmendedByOrderOn.GetHashCode();
                }
                if (this.ApplyDiscountTo != null)
                {
                    hashCode = (hashCode * 59) + this.ApplyDiscountTo.GetHashCode();
                }
                if (this.BillingDay != null)
                {
                    hashCode = (hashCode * 59) + this.BillingDay.GetHashCode();
                }
                if (this.BillingPeriod != null)
                {
                    hashCode = (hashCode * 59) + this.BillingPeriod.GetHashCode();
                }
                if (this.BillingPeriodAlignment != null)
                {
                    hashCode = (hashCode * 59) + this.BillingPeriodAlignment.GetHashCode();
                }
                if (this.BillingTiming != null)
                {
                    hashCode = (hashCode * 59) + this.BillingTiming.GetHashCode();
                }
                if (this.ChargeModelConfiguration != null)
                {
                    hashCode = (hashCode * 59) + this.ChargeModelConfiguration.GetHashCode();
                }
                if (this.ChargedThroughDate != null)
                {
                    hashCode = (hashCode * 59) + this.ChargedThroughDate.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.CreditOption.GetHashCode();
                if (this.Currency != null)
                {
                    hashCode = (hashCode * 59) + this.Currency.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.DiscountAmount.GetHashCode();
                if (this.DiscountApplyDetails != null)
                {
                    hashCode = (hashCode * 59) + this.DiscountApplyDetails.GetHashCode();
                }
                if (this.DiscountClass != null)
                {
                    hashCode = (hashCode * 59) + this.DiscountClass.GetHashCode();
                }
                if (this.DiscountLevel != null)
                {
                    hashCode = (hashCode * 59) + this.DiscountLevel.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.DiscountPercentage.GetHashCode();
                hashCode = (hashCode * 59) + this.Dmrc.GetHashCode();
                hashCode = (hashCode * 59) + this.Done.GetHashCode();
                hashCode = (hashCode * 59) + this.DrawdownRate.GetHashCode();
                if (this.DrawdownUom != null)
                {
                    hashCode = (hashCode * 59) + this.DrawdownUom.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Dtcv.GetHashCode();
                if (this.EffectiveEndDate != null)
                {
                    hashCode = (hashCode * 59) + this.EffectiveEndDate.GetHashCode();
                }
                if (this.EffectiveStartDate != null)
                {
                    hashCode = (hashCode * 59) + this.EffectiveStartDate.GetHashCode();
                }
                if (this.EndDateCondition != null)
                {
                    hashCode = (hashCode * 59) + this.EndDateCondition.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ExcludeItemBillingFromRevenueAccounting.GetHashCode();
                hashCode = (hashCode * 59) + this.ExcludeItemBookingFromRevenueAccounting.GetHashCode();
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.IncludedUnits.GetHashCode();
                hashCode = (hashCode * 59) + this.IsPrepaid.GetHashCode();
                if (this.ListPriceBase != null)
                {
                    hashCode = (hashCode * 59) + this.ListPriceBase.GetHashCode();
                }
                if (this.Model != null)
                {
                    hashCode = (hashCode * 59) + this.Model.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Mrr.GetHashCode();
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.Number != null)
                {
                    hashCode = (hashCode * 59) + this.Number.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.NumberOfPeriods.GetHashCode();
                if (this.OriginalChargeId != null)
                {
                    hashCode = (hashCode * 59) + this.OriginalChargeId.GetHashCode();
                }
                if (this.OriginalOrderDate != null)
                {
                    hashCode = (hashCode * 59) + this.OriginalOrderDate.GetHashCode();
                }
                if (this.OverageCalculationOption != null)
                {
                    hashCode = (hashCode * 59) + this.OverageCalculationOption.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.OveragePrice.GetHashCode();
                if (this.OverageUnusedUnitsCreditOption != null)
                {
                    hashCode = (hashCode * 59) + this.OverageUnusedUnitsCreditOption.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.PrepaidOperationType.GetHashCode();
                hashCode = (hashCode * 59) + this.PrepaidQuantity.GetHashCode();
                hashCode = (hashCode * 59) + this.PrepaidTotalQuantity.GetHashCode();
                if (this.PrepaidUom != null)
                {
                    hashCode = (hashCode * 59) + this.PrepaidUom.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Price.GetHashCode();
                if (this.PriceChangeOption != null)
                {
                    hashCode = (hashCode * 59) + this.PriceChangeOption.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.PriceIncreasePercentage.GetHashCode();
                if (this.PricingSummary != null)
                {
                    hashCode = (hashCode * 59) + this.PricingSummary.GetHashCode();
                }
                if (this.ProcessedThroughDate != null)
                {
                    hashCode = (hashCode * 59) + this.ProcessedThroughDate.GetHashCode();
                }
                if (this.ProductRatePlanChargeId != null)
                {
                    hashCode = (hashCode * 59) + this.ProductRatePlanChargeId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Quantity.GetHashCode();
                if (this.RatingGroup != null)
                {
                    hashCode = (hashCode * 59) + this.RatingGroup.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Segment.GetHashCode();
                if (this.SmoothingModel != null)
                {
                    hashCode = (hashCode * 59) + this.SmoothingModel.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.SpecificBillingPeriod.GetHashCode();
                if (this.SpecificEndDate != null)
                {
                    hashCode = (hashCode * 59) + this.SpecificEndDate.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Tcv.GetHashCode();
                if (this.Tiers != null)
                {
                    hashCode = (hashCode * 59) + this.Tiers.GetHashCode();
                }
                if (this.TriggerDate != null)
                {
                    hashCode = (hashCode * 59) + this.TriggerDate.GetHashCode();
                }
                if (this.TriggerEvent != null)
                {
                    hashCode = (hashCode * 59) + this.TriggerEvent.GetHashCode();
                }
                if (this.Type != null)
                {
                    hashCode = (hashCode * 59) + this.Type.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.UnusedUnitsCreditRates.GetHashCode();
                if (this.Uom != null)
                {
                    hashCode = (hashCode * 59) + this.Uom.GetHashCode();
                }
                if (this.UpToPeriods != null)
                {
                    hashCode = (hashCode * 59) + this.UpToPeriods.GetHashCode();
                }
                if (this.UpToPeriodsType != null)
                {
                    hashCode = (hashCode * 59) + this.UpToPeriodsType.GetHashCode();
                }
                if (this.UsageRecordRatingOption != null)
                {
                    hashCode = (hashCode * 59) + this.UsageRecordRatingOption.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ValidityPeriodType.GetHashCode();
                hashCode = (hashCode * 59) + this._Version.GetHashCode();
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
            yield break;
        }
    }

}
