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
    /// InvoiceItem
    /// </summary>
    [DataContract(Name = "InvoiceItem")]
    public partial class InvoiceItem : IEquatable<InvoiceItem>, IValidatableObject
    {
        /// <summary>
        /// The date when revenue recognition is triggered. 
        /// </summary>
        /// <value>The date when revenue recognition is triggered. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RevRecTriggerConditionEnum
        {
            /// <summary>
            /// Enum ContractEffectiveDate for value: ContractEffectiveDate
            /// </summary>
            [EnumMember(Value = "ContractEffectiveDate")]
            ContractEffectiveDate = 1,

            /// <summary>
            /// Enum ServiceActivationDate for value: ServiceActivationDate
            /// </summary>
            [EnumMember(Value = "ServiceActivationDate")]
            ServiceActivationDate = 2,

            /// <summary>
            /// Enum CustomerAcceptanceDate for value: CustomerAcceptanceDate
            /// </summary>
            [EnumMember(Value = "CustomerAcceptanceDate")]
            CustomerAcceptanceDate = 3

        }


        /// <summary>
        /// The date when revenue recognition is triggered. 
        /// </summary>
        /// <value>The date when revenue recognition is triggered. </value>
        [DataMember(Name = "revRecTriggerCondition", EmitDefaultValue = false)]
        public RevRecTriggerConditionEnum? RevRecTriggerCondition { get; set; }
        /// <summary>
        /// The type of the source item. 
        /// </summary>
        /// <value>The type of the source item. </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SourceItemTypeEnum
        {
            /// <summary>
            /// Enum SubscriptionComponent for value: SubscriptionComponent
            /// </summary>
            [EnumMember(Value = "SubscriptionComponent")]
            SubscriptionComponent = 1,

            /// <summary>
            /// Enum Rounding for value: Rounding
            /// </summary>
            [EnumMember(Value = "Rounding")]
            Rounding = 2,

            /// <summary>
            /// Enum ProductRatePlanCharge for value: ProductRatePlanCharge
            /// </summary>
            [EnumMember(Value = "ProductRatePlanCharge")]
            ProductRatePlanCharge = 3,

            /// <summary>
            /// Enum None for value: None
            /// </summary>
            [EnumMember(Value = "None")]
            None = 4,

            /// <summary>
            /// Enum OrderLineItem for value: OrderLineItem
            /// </summary>
            [EnumMember(Value = "OrderLineItem")]
            OrderLineItem = 5

        }


        /// <summary>
        /// The type of the source item. 
        /// </summary>
        /// <value>The type of the source item. </value>
        [DataMember(Name = "sourceItemType", EmitDefaultValue = false)]
        public SourceItemTypeEnum? SourceItemType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceItem" /> class.
        /// </summary>
        /// <param name="accountingCode">The accounting code associated with the invoice item..</param>
        /// <param name="adjustmentLiabilityAccountingCode">The accounting code for adjustment liability.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  .</param>
        /// <param name="adjustmentRevenueAccountingCode">The accounting code for adjustment revenue.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  .</param>
        /// <param name="appliedToItemId">The unique ID of the invoice item that the discount charge is applied to..</param>
        /// <param name="availableToCreditAmount">The amount of the invoice item that is available to credit.         .</param>
        /// <param name="balance">The balance of the invoice item..</param>
        /// <param name="bookingReference">The booking reference of the invoice item. .</param>
        /// <param name="chargeAmount">The amount of the charge.   This amount does not include taxes regardless if the charge&#39;s tax mode is inclusive or exclusive. .</param>
        /// <param name="chargeDescription">The description of the charge..</param>
        /// <param name="chargeId">The unique ID of the charge..</param>
        /// <param name="chargeName">The name of the charge..</param>
        /// <param name="contractAssetAccountingCode">The accounting code for contract asset.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  .</param>
        /// <param name="contractLiabilityAccountingCode">The accounting code for contract liability.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  .</param>
        /// <param name="contractRecognizedRevenueAccountingCode">The accounting code for contract recognized revenue.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  .</param>
        /// <param name="deferredRevenueAccountingCode">The deferred revenue accounting code associated with the invoice item.  **Note:** This field is only available if you have Zuora Finance enabled. .</param>
        /// <param name="description">The description of the invoice item..</param>
        /// <param name="excludeItemBillingFromRevenueAccounting">The flag to exclude the invoice item from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  .</param>
        /// <param name="id">Item ID..</param>
        /// <param name="itemType">The type of the invoice item. .</param>
        /// <param name="productName">Name of the product associated with this item..</param>
        /// <param name="productRatePlanChargeId">The ID of the product rate plan charge that the invoice item is created from. .</param>
        /// <param name="purchaseOrderNumber">The purchase order number associated with the invoice item. .</param>
        /// <param name="quantity">The quantity of this item, in the configured unit of measure for the charge..</param>
        /// <param name="recognizedRevenueAccountingCode">The recognized revenue accounting code associated with the invoice item.  **Note:** This field is only available if you have Zuora Finance enabled. .</param>
        /// <param name="revRecCode">The revenue recognition code. .</param>
        /// <param name="revRecTriggerCondition">The date when revenue recognition is triggered. .</param>
        /// <param name="revenueRecognitionRuleName">The tevenue recognition rule of the invoice item.  **Note:** This field is only available if you have Zuora Finance enabled. .</param>
        /// <param name="serviceEndDate">The end date of the service period for this item, i.e., the last day of the service period, as _yyyy-mm-dd_..</param>
        /// <param name="serviceStartDate">The start date of the service period for this item, as _yyyy-mm-dd_. For a one-time fee item, the date of the charge..</param>
        /// <param name="sku">The SKU of the invoice item. .</param>
        /// <param name="sourceItemType">The type of the source item. .</param>
        /// <param name="subscriptionId">The ID of the subscription for this item..</param>
        /// <param name="subscriptionName">The name of the subscription for this item..</param>
        /// <param name="success">Returns &#x60;true&#x60; if the request was processed successfully..</param>
        /// <param name="taxAmount">Tax applied to the charge..</param>
        /// <param name="taxCode">The tax code of the invoice item. **Note** Only when taxation feature is enabled, this field can be presented. .</param>
        /// <param name="taxMode">The tax mode of the invoice item. **Note** Only when taxation feature is enabled, this field can be presented. .</param>
        /// <param name="taxationItems">taxationItems.</param>
        /// <param name="unbilledReceivablesAccountingCode">The accounting code for unbilled receivables.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  .</param>
        /// <param name="unitOfMeasure">Unit used to measure consumption..</param>
        /// <param name="unitPrice">The per-unit price of the invoice item..</param>
        /// <param name="integrationIdNS">ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="integrationStatusNS">Status of the invoice item&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="syncDateNS">Date when the invoice item was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        public InvoiceItem(string accountingCode = default(string), string adjustmentLiabilityAccountingCode = default(string), string adjustmentRevenueAccountingCode = default(string), string appliedToItemId = default(string), decimal availableToCreditAmount = default(decimal), decimal balance = default(decimal), string bookingReference = default(string), decimal chargeAmount = default(decimal), string chargeDescription = default(string), string chargeId = default(string), string chargeName = default(string), string contractAssetAccountingCode = default(string), string contractLiabilityAccountingCode = default(string), string contractRecognizedRevenueAccountingCode = default(string), string deferredRevenueAccountingCode = default(string), string description = default(string), bool excludeItemBillingFromRevenueAccounting = default(bool), string id = default(string), string itemType = default(string), string productName = default(string), string productRatePlanChargeId = default(string), string purchaseOrderNumber = default(string), decimal quantity = default(decimal), string recognizedRevenueAccountingCode = default(string), string revRecCode = default(string), RevRecTriggerConditionEnum? revRecTriggerCondition = default(RevRecTriggerConditionEnum?), string revenueRecognitionRuleName = default(string), DateTime serviceEndDate = default(DateTime), DateTime serviceStartDate = default(DateTime), string sku = default(string), SourceItemTypeEnum? sourceItemType = default(SourceItemTypeEnum?), string subscriptionId = default(string), string subscriptionName = default(string), bool success = default(bool), decimal taxAmount = default(decimal), string taxCode = default(string), string taxMode = default(string), InvoiceItemAllOfTaxationItems taxationItems = default(InvoiceItemAllOfTaxationItems), string unbilledReceivablesAccountingCode = default(string), string unitOfMeasure = default(string), double unitPrice = default(double), string integrationIdNS = default(string), string integrationStatusNS = default(string), string syncDateNS = default(string))
        {
            this.AccountingCode = accountingCode;
            this.AdjustmentLiabilityAccountingCode = adjustmentLiabilityAccountingCode;
            this.AdjustmentRevenueAccountingCode = adjustmentRevenueAccountingCode;
            this.AppliedToItemId = appliedToItemId;
            this.AvailableToCreditAmount = availableToCreditAmount;
            this.Balance = balance;
            this.BookingReference = bookingReference;
            this.ChargeAmount = chargeAmount;
            this.ChargeDescription = chargeDescription;
            this.ChargeId = chargeId;
            this.ChargeName = chargeName;
            this.ContractAssetAccountingCode = contractAssetAccountingCode;
            this.ContractLiabilityAccountingCode = contractLiabilityAccountingCode;
            this.ContractRecognizedRevenueAccountingCode = contractRecognizedRevenueAccountingCode;
            this.DeferredRevenueAccountingCode = deferredRevenueAccountingCode;
            this.Description = description;
            this.ExcludeItemBillingFromRevenueAccounting = excludeItemBillingFromRevenueAccounting;
            this.Id = id;
            this.ItemType = itemType;
            this.ProductName = productName;
            this.ProductRatePlanChargeId = productRatePlanChargeId;
            this.PurchaseOrderNumber = purchaseOrderNumber;
            this.Quantity = quantity;
            this.RecognizedRevenueAccountingCode = recognizedRevenueAccountingCode;
            this.RevRecCode = revRecCode;
            this.RevRecTriggerCondition = revRecTriggerCondition;
            this.RevenueRecognitionRuleName = revenueRecognitionRuleName;
            this.ServiceEndDate = serviceEndDate;
            this.ServiceStartDate = serviceStartDate;
            this.Sku = sku;
            this.SourceItemType = sourceItemType;
            this.SubscriptionId = subscriptionId;
            this.SubscriptionName = subscriptionName;
            this.Success = success;
            this.TaxAmount = taxAmount;
            this.TaxCode = taxCode;
            this.TaxMode = taxMode;
            this.TaxationItems = taxationItems;
            this.UnbilledReceivablesAccountingCode = unbilledReceivablesAccountingCode;
            this.UnitOfMeasure = unitOfMeasure;
            this.UnitPrice = unitPrice;
            this.IntegrationIdNS = integrationIdNS;
            this.IntegrationStatusNS = integrationStatusNS;
            this.SyncDateNS = syncDateNS;
        }

        /// <summary>
        /// The accounting code associated with the invoice item.
        /// </summary>
        /// <value>The accounting code associated with the invoice item.</value>
        [DataMember(Name = "accountingCode", EmitDefaultValue = false)]
        public string AccountingCode { get; set; }

        /// <summary>
        /// The accounting code for adjustment liability.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  
        /// </summary>
        /// <value>The accounting code for adjustment liability.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  </value>
        [DataMember(Name = "adjustmentLiabilityAccountingCode", EmitDefaultValue = false)]
        public string AdjustmentLiabilityAccountingCode { get; set; }

        /// <summary>
        /// The accounting code for adjustment revenue.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  
        /// </summary>
        /// <value>The accounting code for adjustment revenue.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  </value>
        [DataMember(Name = "adjustmentRevenueAccountingCode", EmitDefaultValue = false)]
        public string AdjustmentRevenueAccountingCode { get; set; }

        /// <summary>
        /// The unique ID of the invoice item that the discount charge is applied to.
        /// </summary>
        /// <value>The unique ID of the invoice item that the discount charge is applied to.</value>
        [DataMember(Name = "appliedToItemId", EmitDefaultValue = false)]
        public string AppliedToItemId { get; set; }

        /// <summary>
        /// The amount of the invoice item that is available to credit.         
        /// </summary>
        /// <value>The amount of the invoice item that is available to credit.         </value>
        [DataMember(Name = "availableToCreditAmount", EmitDefaultValue = false)]
        public decimal AvailableToCreditAmount { get; set; }

        /// <summary>
        /// The balance of the invoice item.
        /// </summary>
        /// <value>The balance of the invoice item.</value>
        [DataMember(Name = "balance", EmitDefaultValue = false)]
        public decimal Balance { get; set; }

        /// <summary>
        /// The booking reference of the invoice item. 
        /// </summary>
        /// <value>The booking reference of the invoice item. </value>
        [DataMember(Name = "bookingReference", EmitDefaultValue = false)]
        public string BookingReference { get; set; }

        /// <summary>
        /// The amount of the charge.   This amount does not include taxes regardless if the charge&#39;s tax mode is inclusive or exclusive. 
        /// </summary>
        /// <value>The amount of the charge.   This amount does not include taxes regardless if the charge&#39;s tax mode is inclusive or exclusive. </value>
        [DataMember(Name = "chargeAmount", EmitDefaultValue = false)]
        public decimal ChargeAmount { get; set; }

        /// <summary>
        /// The description of the charge.
        /// </summary>
        /// <value>The description of the charge.</value>
        [DataMember(Name = "chargeDescription", EmitDefaultValue = false)]
        public string ChargeDescription { get; set; }

        /// <summary>
        /// The unique ID of the charge.
        /// </summary>
        /// <value>The unique ID of the charge.</value>
        [DataMember(Name = "chargeId", EmitDefaultValue = false)]
        public string ChargeId { get; set; }

        /// <summary>
        /// The name of the charge.
        /// </summary>
        /// <value>The name of the charge.</value>
        [DataMember(Name = "chargeName", EmitDefaultValue = false)]
        public string ChargeName { get; set; }

        /// <summary>
        /// The accounting code for contract asset.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  
        /// </summary>
        /// <value>The accounting code for contract asset.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  </value>
        [DataMember(Name = "contractAssetAccountingCode", EmitDefaultValue = false)]
        public string ContractAssetAccountingCode { get; set; }

        /// <summary>
        /// The accounting code for contract liability.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  
        /// </summary>
        /// <value>The accounting code for contract liability.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  </value>
        [DataMember(Name = "contractLiabilityAccountingCode", EmitDefaultValue = false)]
        public string ContractLiabilityAccountingCode { get; set; }

        /// <summary>
        /// The accounting code for contract recognized revenue.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  
        /// </summary>
        /// <value>The accounting code for contract recognized revenue.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  </value>
        [DataMember(Name = "contractRecognizedRevenueAccountingCode", EmitDefaultValue = false)]
        public string ContractRecognizedRevenueAccountingCode { get; set; }

        /// <summary>
        /// The deferred revenue accounting code associated with the invoice item.  **Note:** This field is only available if you have Zuora Finance enabled. 
        /// </summary>
        /// <value>The deferred revenue accounting code associated with the invoice item.  **Note:** This field is only available if you have Zuora Finance enabled. </value>
        [DataMember(Name = "deferredRevenueAccountingCode", EmitDefaultValue = false)]
        public string DeferredRevenueAccountingCode { get; set; }

        /// <summary>
        /// The description of the invoice item.
        /// </summary>
        /// <value>The description of the invoice item.</value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// The flag to exclude the invoice item from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  
        /// </summary>
        /// <value>The flag to exclude the invoice item from revenue accounting.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  </value>
        [DataMember(Name = "excludeItemBillingFromRevenueAccounting", EmitDefaultValue = true)]
        public bool ExcludeItemBillingFromRevenueAccounting { get; set; }

        /// <summary>
        /// Item ID.
        /// </summary>
        /// <value>Item ID.</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// The type of the invoice item. 
        /// </summary>
        /// <value>The type of the invoice item. </value>
        [DataMember(Name = "itemType", EmitDefaultValue = false)]
        public string ItemType { get; set; }

        /// <summary>
        /// Name of the product associated with this item.
        /// </summary>
        /// <value>Name of the product associated with this item.</value>
        [DataMember(Name = "productName", EmitDefaultValue = false)]
        public string ProductName { get; set; }

        /// <summary>
        /// The ID of the product rate plan charge that the invoice item is created from. 
        /// </summary>
        /// <value>The ID of the product rate plan charge that the invoice item is created from. </value>
        [DataMember(Name = "productRatePlanChargeId", EmitDefaultValue = false)]
        public string ProductRatePlanChargeId { get; set; }

        /// <summary>
        /// The purchase order number associated with the invoice item. 
        /// </summary>
        /// <value>The purchase order number associated with the invoice item. </value>
        [DataMember(Name = "purchaseOrderNumber", EmitDefaultValue = false)]
        public string PurchaseOrderNumber { get; set; }

        /// <summary>
        /// The quantity of this item, in the configured unit of measure for the charge.
        /// </summary>
        /// <value>The quantity of this item, in the configured unit of measure for the charge.</value>
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public decimal Quantity { get; set; }

        /// <summary>
        /// The recognized revenue accounting code associated with the invoice item.  **Note:** This field is only available if you have Zuora Finance enabled. 
        /// </summary>
        /// <value>The recognized revenue accounting code associated with the invoice item.  **Note:** This field is only available if you have Zuora Finance enabled. </value>
        [DataMember(Name = "recognizedRevenueAccountingCode", EmitDefaultValue = false)]
        public string RecognizedRevenueAccountingCode { get; set; }

        /// <summary>
        /// The revenue recognition code. 
        /// </summary>
        /// <value>The revenue recognition code. </value>
        [DataMember(Name = "revRecCode", EmitDefaultValue = false)]
        public string RevRecCode { get; set; }

        /// <summary>
        /// The tevenue recognition rule of the invoice item.  **Note:** This field is only available if you have Zuora Finance enabled. 
        /// </summary>
        /// <value>The tevenue recognition rule of the invoice item.  **Note:** This field is only available if you have Zuora Finance enabled. </value>
        [DataMember(Name = "revenueRecognitionRuleName", EmitDefaultValue = false)]
        public string RevenueRecognitionRuleName { get; set; }

        /// <summary>
        /// The end date of the service period for this item, i.e., the last day of the service period, as _yyyy-mm-dd_.
        /// </summary>
        /// <value>The end date of the service period for this item, i.e., the last day of the service period, as _yyyy-mm-dd_.</value>
        [DataMember(Name = "serviceEndDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime ServiceEndDate { get; set; }

        /// <summary>
        /// The start date of the service period for this item, as _yyyy-mm-dd_. For a one-time fee item, the date of the charge.
        /// </summary>
        /// <value>The start date of the service period for this item, as _yyyy-mm-dd_. For a one-time fee item, the date of the charge.</value>
        [DataMember(Name = "serviceStartDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime ServiceStartDate { get; set; }

        /// <summary>
        /// The SKU of the invoice item. 
        /// </summary>
        /// <value>The SKU of the invoice item. </value>
        [DataMember(Name = "sku", EmitDefaultValue = false)]
        public string Sku { get; set; }

        /// <summary>
        /// The ID of the subscription for this item.
        /// </summary>
        /// <value>The ID of the subscription for this item.</value>
        [DataMember(Name = "subscriptionId", EmitDefaultValue = false)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// The name of the subscription for this item.
        /// </summary>
        /// <value>The name of the subscription for this item.</value>
        [DataMember(Name = "subscriptionName", EmitDefaultValue = false)]
        public string SubscriptionName { get; set; }

        /// <summary>
        /// Returns &#x60;true&#x60; if the request was processed successfully.
        /// </summary>
        /// <value>Returns &#x60;true&#x60; if the request was processed successfully.</value>
        [DataMember(Name = "success", EmitDefaultValue = true)]
        public bool Success { get; set; }

        /// <summary>
        /// Tax applied to the charge.
        /// </summary>
        /// <value>Tax applied to the charge.</value>
        [DataMember(Name = "taxAmount", EmitDefaultValue = false)]
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// The tax code of the invoice item. **Note** Only when taxation feature is enabled, this field can be presented. 
        /// </summary>
        /// <value>The tax code of the invoice item. **Note** Only when taxation feature is enabled, this field can be presented. </value>
        [DataMember(Name = "taxCode", EmitDefaultValue = false)]
        public string TaxCode { get; set; }

        /// <summary>
        /// The tax mode of the invoice item. **Note** Only when taxation feature is enabled, this field can be presented. 
        /// </summary>
        /// <value>The tax mode of the invoice item. **Note** Only when taxation feature is enabled, this field can be presented. </value>
        [DataMember(Name = "taxMode", EmitDefaultValue = false)]
        public string TaxMode { get; set; }

        /// <summary>
        /// Gets or Sets TaxationItems
        /// </summary>
        [DataMember(Name = "taxationItems", EmitDefaultValue = false)]
        public InvoiceItemAllOfTaxationItems TaxationItems { get; set; }

        /// <summary>
        /// The accounting code for unbilled receivables.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  
        /// </summary>
        /// <value>The accounting code for unbilled receivables.         **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  </value>
        [DataMember(Name = "unbilledReceivablesAccountingCode", EmitDefaultValue = false)]
        public string UnbilledReceivablesAccountingCode { get; set; }

        /// <summary>
        /// Unit used to measure consumption.
        /// </summary>
        /// <value>Unit used to measure consumption.</value>
        [DataMember(Name = "unitOfMeasure", EmitDefaultValue = false)]
        public string UnitOfMeasure { get; set; }

        /// <summary>
        /// The per-unit price of the invoice item.
        /// </summary>
        /// <value>The per-unit price of the invoice item.</value>
        [DataMember(Name = "unitPrice", EmitDefaultValue = false)]
        public double UnitPrice { get; set; }

        /// <summary>
        /// ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "IntegrationId__NS", EmitDefaultValue = false)]
        public string IntegrationIdNS { get; set; }

        /// <summary>
        /// Status of the invoice item&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Status of the invoice item&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "IntegrationStatus__NS", EmitDefaultValue = false)]
        public string IntegrationStatusNS { get; set; }

        /// <summary>
        /// Date when the invoice item was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Date when the invoice item was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "SyncDate__NS", EmitDefaultValue = false)]
        public string SyncDateNS { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class InvoiceItem {\n");
            sb.Append("  AccountingCode: ").Append(AccountingCode).Append("\n");
            sb.Append("  AdjustmentLiabilityAccountingCode: ").Append(AdjustmentLiabilityAccountingCode).Append("\n");
            sb.Append("  AdjustmentRevenueAccountingCode: ").Append(AdjustmentRevenueAccountingCode).Append("\n");
            sb.Append("  AppliedToItemId: ").Append(AppliedToItemId).Append("\n");
            sb.Append("  AvailableToCreditAmount: ").Append(AvailableToCreditAmount).Append("\n");
            sb.Append("  Balance: ").Append(Balance).Append("\n");
            sb.Append("  BookingReference: ").Append(BookingReference).Append("\n");
            sb.Append("  ChargeAmount: ").Append(ChargeAmount).Append("\n");
            sb.Append("  ChargeDescription: ").Append(ChargeDescription).Append("\n");
            sb.Append("  ChargeId: ").Append(ChargeId).Append("\n");
            sb.Append("  ChargeName: ").Append(ChargeName).Append("\n");
            sb.Append("  ContractAssetAccountingCode: ").Append(ContractAssetAccountingCode).Append("\n");
            sb.Append("  ContractLiabilityAccountingCode: ").Append(ContractLiabilityAccountingCode).Append("\n");
            sb.Append("  ContractRecognizedRevenueAccountingCode: ").Append(ContractRecognizedRevenueAccountingCode).Append("\n");
            sb.Append("  DeferredRevenueAccountingCode: ").Append(DeferredRevenueAccountingCode).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  ExcludeItemBillingFromRevenueAccounting: ").Append(ExcludeItemBillingFromRevenueAccounting).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ItemType: ").Append(ItemType).Append("\n");
            sb.Append("  ProductName: ").Append(ProductName).Append("\n");
            sb.Append("  ProductRatePlanChargeId: ").Append(ProductRatePlanChargeId).Append("\n");
            sb.Append("  PurchaseOrderNumber: ").Append(PurchaseOrderNumber).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  RecognizedRevenueAccountingCode: ").Append(RecognizedRevenueAccountingCode).Append("\n");
            sb.Append("  RevRecCode: ").Append(RevRecCode).Append("\n");
            sb.Append("  RevRecTriggerCondition: ").Append(RevRecTriggerCondition).Append("\n");
            sb.Append("  RevenueRecognitionRuleName: ").Append(RevenueRecognitionRuleName).Append("\n");
            sb.Append("  ServiceEndDate: ").Append(ServiceEndDate).Append("\n");
            sb.Append("  ServiceStartDate: ").Append(ServiceStartDate).Append("\n");
            sb.Append("  Sku: ").Append(Sku).Append("\n");
            sb.Append("  SourceItemType: ").Append(SourceItemType).Append("\n");
            sb.Append("  SubscriptionId: ").Append(SubscriptionId).Append("\n");
            sb.Append("  SubscriptionName: ").Append(SubscriptionName).Append("\n");
            sb.Append("  Success: ").Append(Success).Append("\n");
            sb.Append("  TaxAmount: ").Append(TaxAmount).Append("\n");
            sb.Append("  TaxCode: ").Append(TaxCode).Append("\n");
            sb.Append("  TaxMode: ").Append(TaxMode).Append("\n");
            sb.Append("  TaxationItems: ").Append(TaxationItems).Append("\n");
            sb.Append("  UnbilledReceivablesAccountingCode: ").Append(UnbilledReceivablesAccountingCode).Append("\n");
            sb.Append("  UnitOfMeasure: ").Append(UnitOfMeasure).Append("\n");
            sb.Append("  UnitPrice: ").Append(UnitPrice).Append("\n");
            sb.Append("  IntegrationIdNS: ").Append(IntegrationIdNS).Append("\n");
            sb.Append("  IntegrationStatusNS: ").Append(IntegrationStatusNS).Append("\n");
            sb.Append("  SyncDateNS: ").Append(SyncDateNS).Append("\n");
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
            return this.Equals(input as InvoiceItem);
        }

        /// <summary>
        /// Returns true if InvoiceItem instances are equal
        /// </summary>
        /// <param name="input">Instance of InvoiceItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(InvoiceItem input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.AccountingCode == input.AccountingCode ||
                    (this.AccountingCode != null &&
                    this.AccountingCode.Equals(input.AccountingCode))
                ) && 
                (
                    this.AdjustmentLiabilityAccountingCode == input.AdjustmentLiabilityAccountingCode ||
                    (this.AdjustmentLiabilityAccountingCode != null &&
                    this.AdjustmentLiabilityAccountingCode.Equals(input.AdjustmentLiabilityAccountingCode))
                ) && 
                (
                    this.AdjustmentRevenueAccountingCode == input.AdjustmentRevenueAccountingCode ||
                    (this.AdjustmentRevenueAccountingCode != null &&
                    this.AdjustmentRevenueAccountingCode.Equals(input.AdjustmentRevenueAccountingCode))
                ) && 
                (
                    this.AppliedToItemId == input.AppliedToItemId ||
                    (this.AppliedToItemId != null &&
                    this.AppliedToItemId.Equals(input.AppliedToItemId))
                ) && 
                (
                    this.AvailableToCreditAmount == input.AvailableToCreditAmount ||
                    this.AvailableToCreditAmount.Equals(input.AvailableToCreditAmount)
                ) && 
                (
                    this.Balance == input.Balance ||
                    this.Balance.Equals(input.Balance)
                ) && 
                (
                    this.BookingReference == input.BookingReference ||
                    (this.BookingReference != null &&
                    this.BookingReference.Equals(input.BookingReference))
                ) && 
                (
                    this.ChargeAmount == input.ChargeAmount ||
                    this.ChargeAmount.Equals(input.ChargeAmount)
                ) && 
                (
                    this.ChargeDescription == input.ChargeDescription ||
                    (this.ChargeDescription != null &&
                    this.ChargeDescription.Equals(input.ChargeDescription))
                ) && 
                (
                    this.ChargeId == input.ChargeId ||
                    (this.ChargeId != null &&
                    this.ChargeId.Equals(input.ChargeId))
                ) && 
                (
                    this.ChargeName == input.ChargeName ||
                    (this.ChargeName != null &&
                    this.ChargeName.Equals(input.ChargeName))
                ) && 
                (
                    this.ContractAssetAccountingCode == input.ContractAssetAccountingCode ||
                    (this.ContractAssetAccountingCode != null &&
                    this.ContractAssetAccountingCode.Equals(input.ContractAssetAccountingCode))
                ) && 
                (
                    this.ContractLiabilityAccountingCode == input.ContractLiabilityAccountingCode ||
                    (this.ContractLiabilityAccountingCode != null &&
                    this.ContractLiabilityAccountingCode.Equals(input.ContractLiabilityAccountingCode))
                ) && 
                (
                    this.ContractRecognizedRevenueAccountingCode == input.ContractRecognizedRevenueAccountingCode ||
                    (this.ContractRecognizedRevenueAccountingCode != null &&
                    this.ContractRecognizedRevenueAccountingCode.Equals(input.ContractRecognizedRevenueAccountingCode))
                ) && 
                (
                    this.DeferredRevenueAccountingCode == input.DeferredRevenueAccountingCode ||
                    (this.DeferredRevenueAccountingCode != null &&
                    this.DeferredRevenueAccountingCode.Equals(input.DeferredRevenueAccountingCode))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
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
                    this.ItemType == input.ItemType ||
                    (this.ItemType != null &&
                    this.ItemType.Equals(input.ItemType))
                ) && 
                (
                    this.ProductName == input.ProductName ||
                    (this.ProductName != null &&
                    this.ProductName.Equals(input.ProductName))
                ) && 
                (
                    this.ProductRatePlanChargeId == input.ProductRatePlanChargeId ||
                    (this.ProductRatePlanChargeId != null &&
                    this.ProductRatePlanChargeId.Equals(input.ProductRatePlanChargeId))
                ) && 
                (
                    this.PurchaseOrderNumber == input.PurchaseOrderNumber ||
                    (this.PurchaseOrderNumber != null &&
                    this.PurchaseOrderNumber.Equals(input.PurchaseOrderNumber))
                ) && 
                (
                    this.Quantity == input.Quantity ||
                    this.Quantity.Equals(input.Quantity)
                ) && 
                (
                    this.RecognizedRevenueAccountingCode == input.RecognizedRevenueAccountingCode ||
                    (this.RecognizedRevenueAccountingCode != null &&
                    this.RecognizedRevenueAccountingCode.Equals(input.RecognizedRevenueAccountingCode))
                ) && 
                (
                    this.RevRecCode == input.RevRecCode ||
                    (this.RevRecCode != null &&
                    this.RevRecCode.Equals(input.RevRecCode))
                ) && 
                (
                    this.RevRecTriggerCondition == input.RevRecTriggerCondition ||
                    this.RevRecTriggerCondition.Equals(input.RevRecTriggerCondition)
                ) && 
                (
                    this.RevenueRecognitionRuleName == input.RevenueRecognitionRuleName ||
                    (this.RevenueRecognitionRuleName != null &&
                    this.RevenueRecognitionRuleName.Equals(input.RevenueRecognitionRuleName))
                ) && 
                (
                    this.ServiceEndDate == input.ServiceEndDate ||
                    (this.ServiceEndDate != null &&
                    this.ServiceEndDate.Equals(input.ServiceEndDate))
                ) && 
                (
                    this.ServiceStartDate == input.ServiceStartDate ||
                    (this.ServiceStartDate != null &&
                    this.ServiceStartDate.Equals(input.ServiceStartDate))
                ) && 
                (
                    this.Sku == input.Sku ||
                    (this.Sku != null &&
                    this.Sku.Equals(input.Sku))
                ) && 
                (
                    this.SourceItemType == input.SourceItemType ||
                    this.SourceItemType.Equals(input.SourceItemType)
                ) && 
                (
                    this.SubscriptionId == input.SubscriptionId ||
                    (this.SubscriptionId != null &&
                    this.SubscriptionId.Equals(input.SubscriptionId))
                ) && 
                (
                    this.SubscriptionName == input.SubscriptionName ||
                    (this.SubscriptionName != null &&
                    this.SubscriptionName.Equals(input.SubscriptionName))
                ) && 
                (
                    this.Success == input.Success ||
                    this.Success.Equals(input.Success)
                ) && 
                (
                    this.TaxAmount == input.TaxAmount ||
                    this.TaxAmount.Equals(input.TaxAmount)
                ) && 
                (
                    this.TaxCode == input.TaxCode ||
                    (this.TaxCode != null &&
                    this.TaxCode.Equals(input.TaxCode))
                ) && 
                (
                    this.TaxMode == input.TaxMode ||
                    (this.TaxMode != null &&
                    this.TaxMode.Equals(input.TaxMode))
                ) && 
                (
                    this.TaxationItems == input.TaxationItems ||
                    (this.TaxationItems != null &&
                    this.TaxationItems.Equals(input.TaxationItems))
                ) && 
                (
                    this.UnbilledReceivablesAccountingCode == input.UnbilledReceivablesAccountingCode ||
                    (this.UnbilledReceivablesAccountingCode != null &&
                    this.UnbilledReceivablesAccountingCode.Equals(input.UnbilledReceivablesAccountingCode))
                ) && 
                (
                    this.UnitOfMeasure == input.UnitOfMeasure ||
                    (this.UnitOfMeasure != null &&
                    this.UnitOfMeasure.Equals(input.UnitOfMeasure))
                ) && 
                (
                    this.UnitPrice == input.UnitPrice ||
                    this.UnitPrice.Equals(input.UnitPrice)
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
                    this.SyncDateNS == input.SyncDateNS ||
                    (this.SyncDateNS != null &&
                    this.SyncDateNS.Equals(input.SyncDateNS))
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
                if (this.AccountingCode != null)
                {
                    hashCode = (hashCode * 59) + this.AccountingCode.GetHashCode();
                }
                if (this.AdjustmentLiabilityAccountingCode != null)
                {
                    hashCode = (hashCode * 59) + this.AdjustmentLiabilityAccountingCode.GetHashCode();
                }
                if (this.AdjustmentRevenueAccountingCode != null)
                {
                    hashCode = (hashCode * 59) + this.AdjustmentRevenueAccountingCode.GetHashCode();
                }
                if (this.AppliedToItemId != null)
                {
                    hashCode = (hashCode * 59) + this.AppliedToItemId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.AvailableToCreditAmount.GetHashCode();
                hashCode = (hashCode * 59) + this.Balance.GetHashCode();
                if (this.BookingReference != null)
                {
                    hashCode = (hashCode * 59) + this.BookingReference.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ChargeAmount.GetHashCode();
                if (this.ChargeDescription != null)
                {
                    hashCode = (hashCode * 59) + this.ChargeDescription.GetHashCode();
                }
                if (this.ChargeId != null)
                {
                    hashCode = (hashCode * 59) + this.ChargeId.GetHashCode();
                }
                if (this.ChargeName != null)
                {
                    hashCode = (hashCode * 59) + this.ChargeName.GetHashCode();
                }
                if (this.ContractAssetAccountingCode != null)
                {
                    hashCode = (hashCode * 59) + this.ContractAssetAccountingCode.GetHashCode();
                }
                if (this.ContractLiabilityAccountingCode != null)
                {
                    hashCode = (hashCode * 59) + this.ContractLiabilityAccountingCode.GetHashCode();
                }
                if (this.ContractRecognizedRevenueAccountingCode != null)
                {
                    hashCode = (hashCode * 59) + this.ContractRecognizedRevenueAccountingCode.GetHashCode();
                }
                if (this.DeferredRevenueAccountingCode != null)
                {
                    hashCode = (hashCode * 59) + this.DeferredRevenueAccountingCode.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ExcludeItemBillingFromRevenueAccounting.GetHashCode();
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.ItemType != null)
                {
                    hashCode = (hashCode * 59) + this.ItemType.GetHashCode();
                }
                if (this.ProductName != null)
                {
                    hashCode = (hashCode * 59) + this.ProductName.GetHashCode();
                }
                if (this.ProductRatePlanChargeId != null)
                {
                    hashCode = (hashCode * 59) + this.ProductRatePlanChargeId.GetHashCode();
                }
                if (this.PurchaseOrderNumber != null)
                {
                    hashCode = (hashCode * 59) + this.PurchaseOrderNumber.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Quantity.GetHashCode();
                if (this.RecognizedRevenueAccountingCode != null)
                {
                    hashCode = (hashCode * 59) + this.RecognizedRevenueAccountingCode.GetHashCode();
                }
                if (this.RevRecCode != null)
                {
                    hashCode = (hashCode * 59) + this.RevRecCode.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.RevRecTriggerCondition.GetHashCode();
                if (this.RevenueRecognitionRuleName != null)
                {
                    hashCode = (hashCode * 59) + this.RevenueRecognitionRuleName.GetHashCode();
                }
                if (this.ServiceEndDate != null)
                {
                    hashCode = (hashCode * 59) + this.ServiceEndDate.GetHashCode();
                }
                if (this.ServiceStartDate != null)
                {
                    hashCode = (hashCode * 59) + this.ServiceStartDate.GetHashCode();
                }
                if (this.Sku != null)
                {
                    hashCode = (hashCode * 59) + this.Sku.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.SourceItemType.GetHashCode();
                if (this.SubscriptionId != null)
                {
                    hashCode = (hashCode * 59) + this.SubscriptionId.GetHashCode();
                }
                if (this.SubscriptionName != null)
                {
                    hashCode = (hashCode * 59) + this.SubscriptionName.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Success.GetHashCode();
                hashCode = (hashCode * 59) + this.TaxAmount.GetHashCode();
                if (this.TaxCode != null)
                {
                    hashCode = (hashCode * 59) + this.TaxCode.GetHashCode();
                }
                if (this.TaxMode != null)
                {
                    hashCode = (hashCode * 59) + this.TaxMode.GetHashCode();
                }
                if (this.TaxationItems != null)
                {
                    hashCode = (hashCode * 59) + this.TaxationItems.GetHashCode();
                }
                if (this.UnbilledReceivablesAccountingCode != null)
                {
                    hashCode = (hashCode * 59) + this.UnbilledReceivablesAccountingCode.GetHashCode();
                }
                if (this.UnitOfMeasure != null)
                {
                    hashCode = (hashCode * 59) + this.UnitOfMeasure.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.UnitPrice.GetHashCode();
                if (this.IntegrationIdNS != null)
                {
                    hashCode = (hashCode * 59) + this.IntegrationIdNS.GetHashCode();
                }
                if (this.IntegrationStatusNS != null)
                {
                    hashCode = (hashCode * 59) + this.IntegrationStatusNS.GetHashCode();
                }
                if (this.SyncDateNS != null)
                {
                    hashCode = (hashCode * 59) + this.SyncDateNS.GetHashCode();
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

            // SyncDateNS (string) maxLength
            if (this.SyncDateNS != null && this.SyncDateNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SyncDateNS, length must be less than 255.", new [] { "SyncDateNS" });
            }

            yield break;
        }
    }

}
