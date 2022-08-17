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
    /// ProxyGetProductRatePlanCharge
    /// </summary>
    [DataContract(Name = "ProxyGetProductRatePlanCharge")]
    public partial class ProxyGetProductRatePlanCharge : IEquatable<ProxyGetProductRatePlanCharge>, IValidatableObject
    {
        /// <summary>
        /// A rating group based on which usage records are rated. Only applicable to Usage charges.  Possible values:  - &#x60;ByBillingPeriod&#x60;: The rating is based on all the usages in a billing period. - &#x60;ByUsageStartDate&#x60;: The rating is based on all the usages on the same usage start date.  - &#x60;ByUsageRecord&#x60;: The rating is based on each usage record. - &#x60;ByUsageUpload&#x60;: The rating is based on all the  usages in a uploaded usage file (&#x60;.xls&#x60; or &#x60;.csv&#x60;). - &#x60;ByGroupId&#x60;: The rating is based on all the usages in a custom group.  For more information, see [Usage rating by group](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Usage/Usage_Rating_by_Group). 
        /// </summary>
        /// <value>A rating group based on which usage records are rated. Only applicable to Usage charges.  Possible values:  - &#x60;ByBillingPeriod&#x60;: The rating is based on all the usages in a billing period. - &#x60;ByUsageStartDate&#x60;: The rating is based on all the usages on the same usage start date.  - &#x60;ByUsageRecord&#x60;: The rating is based on each usage record. - &#x60;ByUsageUpload&#x60;: The rating is based on all the  usages in a uploaded usage file (&#x60;.xls&#x60; or &#x60;.csv&#x60;). - &#x60;ByGroupId&#x60;: The rating is based on all the usages in a custom group.  For more information, see [Usage rating by group](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Usage/Usage_Rating_by_Group). </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RatingGroupEnum
        {
            /// <summary>
            /// Enum ByBillingPeriod for value: ByBillingPeriod
            /// </summary>
            [EnumMember(Value = "ByBillingPeriod")]
            ByBillingPeriod = 1,

            /// <summary>
            /// Enum ByUsageStartDate for value: ByUsageStartDate
            /// </summary>
            [EnumMember(Value = "ByUsageStartDate")]
            ByUsageStartDate = 2,

            /// <summary>
            /// Enum ByUsageRecord for value: ByUsageRecord
            /// </summary>
            [EnumMember(Value = "ByUsageRecord")]
            ByUsageRecord = 3,

            /// <summary>
            /// Enum ByUsageUpload for value: ByUsageUpload
            /// </summary>
            [EnumMember(Value = "ByUsageUpload")]
            ByUsageUpload = 4,

            /// <summary>
            /// Enum ByGroupId for value: ByGroupId
            /// </summary>
            [EnumMember(Value = "ByGroupId")]
            ByGroupId = 5

        }


        /// <summary>
        /// A rating group based on which usage records are rated. Only applicable to Usage charges.  Possible values:  - &#x60;ByBillingPeriod&#x60;: The rating is based on all the usages in a billing period. - &#x60;ByUsageStartDate&#x60;: The rating is based on all the usages on the same usage start date.  - &#x60;ByUsageRecord&#x60;: The rating is based on each usage record. - &#x60;ByUsageUpload&#x60;: The rating is based on all the  usages in a uploaded usage file (&#x60;.xls&#x60; or &#x60;.csv&#x60;). - &#x60;ByGroupId&#x60;: The rating is based on all the usages in a custom group.  For more information, see [Usage rating by group](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Usage/Usage_Rating_by_Group). 
        /// </summary>
        /// <value>A rating group based on which usage records are rated. Only applicable to Usage charges.  Possible values:  - &#x60;ByBillingPeriod&#x60;: The rating is based on all the usages in a billing period. - &#x60;ByUsageStartDate&#x60;: The rating is based on all the usages on the same usage start date.  - &#x60;ByUsageRecord&#x60;: The rating is based on each usage record. - &#x60;ByUsageUpload&#x60;: The rating is based on all the  usages in a uploaded usage file (&#x60;.xls&#x60; or &#x60;.csv&#x60;). - &#x60;ByGroupId&#x60;: The rating is based on all the usages in a custom group.  For more information, see [Usage rating by group](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Usage/Usage_Rating_by_Group). </value>
        [DataMember(Name = "RatingGroup", EmitDefaultValue = false)]
        public RatingGroupEnum? RatingGroup { get; set; }
        /// <summary>
        /// Specifies whether the corresponding item in NetSuite is visible under child subsidiaries. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Specifies whether the corresponding item in NetSuite is visible under child subsidiaries. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum IncludeChildrenNSEnum
        {
            /// <summary>
            /// Enum Yes for value: Yes
            /// </summary>
            [EnumMember(Value = "Yes")]
            Yes = 1,

            /// <summary>
            /// Enum No for value: No
            /// </summary>
            [EnumMember(Value = "No")]
            No = 2

        }


        /// <summary>
        /// Specifies whether the corresponding item in NetSuite is visible under child subsidiaries. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Specifies whether the corresponding item in NetSuite is visible under child subsidiaries. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "IncludeChildren__NS", EmitDefaultValue = false)]
        public IncludeChildrenNSEnum? IncludeChildrenNS { get; set; }
        /// <summary>
        /// Type of item that is created in NetSuite for the product rate plan charge. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Type of item that is created in NetSuite for the product rate plan charge. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ItemTypeNSEnum
        {
            /// <summary>
            /// Enum Inventory for value: Inventory
            /// </summary>
            [EnumMember(Value = "Inventory")]
            Inventory = 1,

            /// <summary>
            /// Enum NonInventory for value: Non Inventory
            /// </summary>
            [EnumMember(Value = "Non Inventory")]
            NonInventory = 2,

            /// <summary>
            /// Enum Service for value: Service
            /// </summary>
            [EnumMember(Value = "Service")]
            Service = 3

        }


        /// <summary>
        /// Type of item that is created in NetSuite for the product rate plan charge. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Type of item that is created in NetSuite for the product rate plan charge. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "ItemType__NS", EmitDefaultValue = false)]
        public ItemTypeNSEnum? ItemTypeNS { get; set; }
        /// <summary>
        /// End date condition of the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>End date condition of the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RevRecEndNSEnum
        {
            /// <summary>
            /// Enum ChargePeriodStart for value: Charge Period Start
            /// </summary>
            [EnumMember(Value = "Charge Period Start")]
            ChargePeriodStart = 1,

            /// <summary>
            /// Enum RevRecTriggerDate for value: Rev Rec Trigger Date
            /// </summary>
            [EnumMember(Value = "Rev Rec Trigger Date")]
            RevRecTriggerDate = 2,

            /// <summary>
            /// Enum UseNetSuiteRevRecTemplate for value: Use NetSuite Rev Rec Template
            /// </summary>
            [EnumMember(Value = "Use NetSuite Rev Rec Template")]
            UseNetSuiteRevRecTemplate = 3

        }


        /// <summary>
        /// End date condition of the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>End date condition of the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "RevRecEnd__NS", EmitDefaultValue = false)]
        public RevRecEndNSEnum? RevRecEndNS { get; set; }
        /// <summary>
        /// Start date condition of the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Start date condition of the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum RevRecStartNSEnum
        {
            /// <summary>
            /// Enum ChargePeriodStart for value: Charge Period Start
            /// </summary>
            [EnumMember(Value = "Charge Period Start")]
            ChargePeriodStart = 1,

            /// <summary>
            /// Enum RevRecTriggerDate for value: Rev Rec Trigger Date
            /// </summary>
            [EnumMember(Value = "Rev Rec Trigger Date")]
            RevRecTriggerDate = 2,

            /// <summary>
            /// Enum UseNetSuiteRevRecTemplate for value: Use NetSuite Rev Rec Template
            /// </summary>
            [EnumMember(Value = "Use NetSuite Rev Rec Template")]
            UseNetSuiteRevRecTemplate = 3

        }


        /// <summary>
        /// Start date condition of the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Start date condition of the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "RevRecStart__NS", EmitDefaultValue = false)]
        public RevRecStartNSEnum? RevRecStartNS { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyGetProductRatePlanCharge" /> class.
        /// </summary>
        /// <param name="accountingCode">The accounting code for the charge. Accounting codes group transactions that contain similar accounting attributes. **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts .</param>
        /// <param name="applyDiscountTo">Specifies the type of charges that you want a specific discount to apply to. All field values are case sensitive: note that these values are in all-caps. **Character limit**: 21 **Values**: one of the following:  - &#x60;ONETIME (1)&#x60; - &#x60;RECURRING (2)&#x60; - &#x60;USAGE (4)&#x60; - &#x60;ONETIMERECURRING (3)&#x60; - &#x60;ONETIMEUSAGE (5)&#x60; - &#x60;RECURRINGUSAGE (6)&#x60; - &#x60;ONETIMERECURRINGUSAGE (7)&#x60; .</param>
        /// <param name="billCycleDay"> Sets the bill cycle day (BCD) for the charge. The BCD determines which day of the month customer is billed. The BCD value in the account can override the BCD in this object. **Character limit**: 2 **Values**: a valid BCD integer, 1 - 31 .</param>
        /// <param name="billCycleType"> **Values**: one of the following:  - &#x60;DefaultFromCustomer&#x60; - &#x60;SpecificDayofMonth:&#x60; - &#x60;SubscriptionStartDay&#x60; - &#x60;ChargeTriggerDay&#x60; - &#x60;SpecificDayofWeek&#x60; - &#x60;TermStartDay&#x60; - &#x60;TermEndDay&#x60; .</param>
        /// <param name="billingPeriod"> The billing period for the charge. The start day of the billing period is also called the bill cycle day (BCD). **Character limit**: 15 **Values**: one of the following  - &#x60;Month&#x60; - &#x60;Quarter&#x60; - &#x60;Annual&#x60; - &#x60;Semi-Annual&#x60; - &#x60;Specific Months&#x60; - &#x60;Subscription Term&#x60; (This value is in **Limited Availability**.) - &#x60;Week&#x60; - &#x60;Specific Weeks&#x60; **Note**: Specify the number of months or weeks in the SpecificBillingPeriod field if you set this field to &#x60;Specific Months&#x60; or &#x60;Specific Weeks&#x60;. .</param>
        /// <param name="billingPeriodAlignment"> - &#x60;AlignToCharge&#x60; - &#x60;AlignToSubscriptionStart&#x60; - &#x60;AlignToTermStart&#x60; - &#x60;AlignToTermEnd&#x60; .</param>
        /// <param name="billingTiming"> The billing timing for the charge. You can choose to bill in advance or in arrears for recurring charge types. This field is not used in one-time or usage based charge types. **Character limit**: **Values**: one of the following:  - &#x60;In Advance&#x60; - &#x60;In Arrears&#x60;  This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  .</param>
        /// <param name="chargeModel"> Determines how to calculate charges. Charge models must be individually activated in Zuora Billing administration. **Character limit**: 27 **Values**: one of the following:  - &#x60;Discount-Fixed Amount&#x60; - &#x60;Discount-Percentage&#x60; - &#x60;Flat Fee Pricing&#x60; - &#x60;Per Unit Pricing&#x60; - &#x60;Overage Pricing&#x60; - &#x60;Tiered Pricing&#x60; - &#x60;Tiered with Overage Pricing&#x60; - &#x60;Volume Pricing&#x60; .</param>
        /// <param name="chargeType"> Specifies the type of charge. **Character limit**: 9 **Values**: one of the following:  - &#x60;OneTime&#x60; - &#x60;Recurring&#x60; - &#x60;Usage&#x60; .</param>
        /// <param name="createdById">The ID of the Zuora user who created the &#x60;ProductRatePlanCharge&#x60; object. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="createdDate"> The date when the  &#x60;ProductRatePlanCharge&#x60; object was created. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="defaultQuantity"> The default quantity of units, such as the number of authors in a hosted wiki service. This field is required if you use a per-unit pricing model.  **Character limit**: 16  **Values**: a valid quantity value. Note that when &#x60;ChargeModel&#x60; is &#x60;Tiered Pricing&#x60; or &#x60;Volume Pricing&#x60;, if this field is not specified, the value will default to &#x60;0&#x60;. .</param>
        /// <param name="deferredRevenueAccount"> The name of the deferred revenue account for this charge. **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  .</param>
        /// <param name="description">A description of the charge. **Character limit**: 500 **Values**: a string of 500 characters or fewer .</param>
        /// <param name="discountLevel"> Specifies if the discount applies to just the product rate plan, the entire subscription, or to any activity in the account. **Character limit**: 12 **Values**: one of the following:  - &#x60;rateplan&#x60; - &#x60;subscription&#x60;, &#x60;account&#x60; .</param>
        /// <param name="endDateCondition"> Defines when the charge ends after the charge trigger date. **Values**: one of the following:  - &#x60;SubscriptionEnd&#x60;: The charge ends on the subscription end date after a specified period based on the trigger date of the charge. This is the default value. - &#x60;FixedPeriod&#x60;: The charge ends after a specified period based on the trigger date of the charge. If you set this field to &#x60;FixedPeriod&#x60;, you must specify the length of the period and a period type by defining the &#x60;UpToPeriods&#x60; and &#x60;UpToPeriodsType&#x60; fields. **Note**: If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date. .</param>
        /// <param name="excludeItemBillingFromRevenueAccounting">The flag to exclude the related invoice items, invoice item adjustments, credit memo items, and debit memo items from revenue accounting.  **Note**: To use this field, you must set the &#x60;X-Zuora-WSDL-Version&#x60; request header to &#x60;115&#x60; or later. Otherwise, an error occurs.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  .</param>
        /// <param name="excludeItemBookingFromRevenueAccounting">The flag to exclude the related rate plan charges and order line items from revenue accounting.  **Note**: To use this field, you must set the &#x60;X-Zuora-WSDL-Version&#x60; request header to &#x60;115&#x60; or later. Otherwise, an error occurs.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  .</param>
        /// <param name="id">Object identifier..</param>
        /// <param name="includedUnits">Specifies the number of units in the base set of units. **Character limit**: 16 **Values**: a positive decimal value .</param>
        /// <param name="legacyRevenueReporting">legacyRevenueReporting.</param>
        /// <param name="listPriceBase">The list price base for the product rate plan charge. **Values**: one of the following:  - &#x60;Per Month&#x60; - &#x60;Per Billing Period&#x60; - &#x60;Per Week&#x60; .</param>
        /// <param name="maxQuantity"> Specifies the maximum number of units for this charge. Use this field and the &#x60;MinQuantity&#x60; field to create a range of units allowed in a product rate plan charge. **Character limit**: 16 **Values**: a positive decimal value .</param>
        /// <param name="minQuantity">Specifies the minimum number of units for this charge. Use this field and the &#x60;MaxQuantity&#x60; field to create a range of units allowed in a product rate plan charge. **Character limit**: 16 **Values**: a positive decimal value .</param>
        /// <param name="name">The name of the product rate plan charge. **Character limit**: 100 **Values**: a string of 100 characters or fewer .</param>
        /// <param name="numberOfPeriod">Specifies the number of periods to use when calculating charges in an overage smoothing charge model. **Character limit**: **Values**: a positive whole number .</param>
        /// <param name="overageCalculationOption">Determines when to calculate overage charges. If the value of the SmoothingMode field is not specified, the value of this field is ignored. **Character limit**: 20 **Values**: one of the following:  - &#x60;EndOfSmoothingPeriod&#x60;: This option is used by default. The overage is charged at the end of the smoothing period. - &#x60;PerBillingPeriod&#x60;: The overage is charged on-demand rather than waiting until the end of the smoothing period. .</param>
        /// <param name="overageUnusedUnitsCreditOption"> Determines whether to credit the customer with unused units of usage. **Character limit**: 20 **Values**: one of the following:  - &#x60;NoCredit&#x60; - &#x60;CreditBySpecificRate&#x60; .</param>
        /// <param name="priceChangeOption"> Applies an automatic price change when a termed subscription is renewed. **Character limit**: **Values**: one of the following:  - &#x60;NoChange&#x60; (default) - &#x60;SpecificPercentageValue&#x60; - &#x60;UseLatestProductCatalogPricing&#x60; .</param>
        /// <param name="priceIncreasePercentage"> Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Use this field if you set the value to &#x60;SpecificPercentageValue&#x60;. **Character limit**: 16 **Values**: a decimal value between -100 and 100 .</param>
        /// <param name="productRatePlanId"> The ID of the product rate plan associated with this product rate plan charge. **Character limit**: 32 **Values**: a valid product rate plan ID .</param>
        /// <param name="ratingGroup">A rating group based on which usage records are rated. Only applicable to Usage charges.  Possible values:  - &#x60;ByBillingPeriod&#x60;: The rating is based on all the usages in a billing period. - &#x60;ByUsageStartDate&#x60;: The rating is based on all the usages on the same usage start date.  - &#x60;ByUsageRecord&#x60;: The rating is based on each usage record. - &#x60;ByUsageUpload&#x60;: The rating is based on all the  usages in a uploaded usage file (&#x60;.xls&#x60; or &#x60;.csv&#x60;). - &#x60;ByGroupId&#x60;: The rating is based on all the usages in a custom group.  For more information, see [Usage rating by group](https://knowledgecenter.zuora.com/Billing/Billing_and_Payments/J_Billing_Operations/Usage/Usage_Rating_by_Group). .</param>
        /// <param name="recognizedRevenueAccount"> The name of the recognized revenue account for this charge.  - Required when the Allow Blank Accounting Code setting is No. - Optional when the Allow Blank Accounting Code setting is Yes.  **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  .</param>
        /// <param name="revRecCode">Associates this product rate plan charge with a specific revenue recognition code. **Character limit**: 70 **Values**: a valid revenue recognition code .</param>
        /// <param name="revRecTriggerCondition"> Specifies when revenue recognition begins. **Character limit**: 22 **Values**: one of the following:  - &#x60;ContractEffectiveDate&#x60; - &#x60;ServiceActivationDate&#x60; - &#x60;CustomerAcceptanceDate&#x60; .</param>
        /// <param name="revenueRecognitionRuleName">Determines when to recognize the revenue for this charge. **Character limit**: 25 **Values**: one of the following:  - &#x60;Recognize upon invoicing&#x60; - &#x60;Recognize daily over time&#x60; .</param>
        /// <param name="smoothingModel"> Specifies the smoothing model for an overage smoothing charge model. **Character limit**: 22 **Values**: one of the following:  - &#x60;RollingWindow&#x60; - &#x60;Rollover&#x60; .</param>
        /// <param name="specificBillingPeriod"> Customizes the number of months or weeks for the charges billing period. This field is required if you set the value of the BillingPeriod field to &#x60;Specific Months&#x60; or &#x60;Specific Weeks&#x60;. **Values**: a positive integer .</param>
        /// <param name="taxCode"> Specifies the tax code for taxation rules. Required when the Taxable field is set to &#x60;True&#x60;.  **Character limit**: 64  **Values**: a valid tax code  **Note**: This value affects the tax calculation of rate plan charges that come from the &#x60;ProductRatePlanCharge&#x60;. .</param>
        /// <param name="taxMode"> Determines how to define taxation for the charge. Required when the Taxable field is set to &#x60;True&#x60;.  **Character limit**: 12  **Values**: one of the following:  - &#x60;TaxExclusive&#x60; - &#x60;TaxInclusive&#x60;  **Note**: This value affects the tax calculation of rate plan charges that come from the &#x60;ProductRatePlanCharge&#x60;. .</param>
        /// <param name="taxable"> Determines whether the charge is taxable. When set to &#x60;True&#x60;, the TaxMode and TaxCode fields are required when creating or updating th ProductRatePlanCharge object.  **Character limit**: 5  **Values**: &#x60;True&#x60;, &#x60;False&#x60;  **Note**: This value affects the tax calculation of rate plan charges that come from the &#x60;ProductRatePlanCharge&#x60;. .</param>
        /// <param name="triggerEvent"> Specifies when to start billing the customer for the charge. **Character limit**: 18 **Values**: one of the following:  - &#x60;ContractEffective&#x60; is the date when the subscription&#39;s contract goes into effect and the charge is ready to be billed. - &#x60;ServiceActivation&#x60; is the date when the services or products for a subscription have been activated and the customers have access. - &#x60;CustomerAcceptance&#x60; is when the customer accepts the services or products for a subscription. .</param>
        /// <param name="uOM"> Specifies the units to measure usage. **Character limit**: 25 **Values**: a configured unit of measure **Note**: You must specify this field when creating the following charge models:  - Per Unit Pricing - Volume Pricing - Overage Pricing - Tiered Pricing - Tiered with Overage Pricing .</param>
        /// <param name="upToPeriods"> Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends. **Character limit**: 5 **Values**: a whole number between 0 and 65535, exclusive **Note**:  - You must use this field together with the &#x60;UpToPeriodsType&#x60; field to specify the time period. This field is applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. - If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. .</param>
        /// <param name="upToPeriodsType"> The period type used to define when the charge ends. **Character limit**: - - **Values**: one of the following:  - &#x60;Billing Periods&#x60; (default) - &#x60;Days&#x60; - &#x60;Weeks&#x60; - &#x60;Months&#x60; - &#x60;Years&#x60;  **Note**:  - You must use this field together with the &#x60;UpToPeriods&#x60; field to specify the time period. - This field is applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. .</param>
        /// <param name="updatedById">The ID of the last user to update the object. **Character limit**: 32 **Values**: automatically generated .</param>
        /// <param name="updatedDate">The date when the object was last updated. **Character limit**: 29 **Values**: automatically generated .</param>
        /// <param name="useDiscountSpecificAccountingCode">Determines whether to define a new accounting code for the new discount charge. **Character limit**: 5 **Values**: &#x60;True&#x60;, &#x60;False&#x60; .</param>
        /// <param name="useTenantDefaultForPriceChange"> Applies the tenant-level percentage uplift value for an automatic price change to a termed subscription&#39;s renewal. **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; .</param>
        /// <param name="weeklyBillCycleDay"> Specifies which day of the week as the bill cycle day (BCD) for the charge. This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  **Values**: one of the following:  - &#x60;Sunday&#x60; - &#x60;Monday&#x60; - &#x60;Tuesday&#x60; - &#x60;Wednesday&#x60; - &#x60;Thursday&#x60; - &#x60;Friday&#x60; - &#x60;Saturday&#x60; .</param>
        /// <param name="classNS">Class associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="deferredRevAccountNS">Deferrred revenue account associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="departmentNS">Department associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="includeChildrenNS">Specifies whether the corresponding item in NetSuite is visible under child subsidiaries. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="integrationIdNS">ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="integrationStatusNS">Status of the product rate plan charge&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="itemTypeNS">Type of item that is created in NetSuite for the product rate plan charge. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="locationNS">Location associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="recognizedRevAccountNS">Recognized revenue account associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="revRecEndNS">End date condition of the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="revRecStartNS">Start date condition of the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="revRecTemplateTypeNS">Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="subsidiaryNS">Subsidiary associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        /// <param name="syncDateNS">Date when the product rate plan charge was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). .</param>
        public ProxyGetProductRatePlanCharge(string accountingCode = default(string), string applyDiscountTo = default(string), int billCycleDay = default(int), string billCycleType = default(string), string billingPeriod = default(string), string billingPeriodAlignment = default(string), string billingTiming = default(string), string chargeModel = default(string), string chargeType = default(string), string createdById = default(string), DateTime createdDate = default(DateTime), double defaultQuantity = default(double), string deferredRevenueAccount = default(string), string description = default(string), string discountLevel = default(string), string endDateCondition = default(string), bool excludeItemBillingFromRevenueAccounting = default(bool), bool excludeItemBookingFromRevenueAccounting = default(bool), string id = default(string), double includedUnits = default(double), bool legacyRevenueReporting = default(bool), string listPriceBase = default(string), double maxQuantity = default(double), double minQuantity = default(double), string name = default(string), long numberOfPeriod = default(long), string overageCalculationOption = default(string), string overageUnusedUnitsCreditOption = default(string), string priceChangeOption = default(string), double priceIncreasePercentage = default(double), string productRatePlanId = default(string), RatingGroupEnum? ratingGroup = default(RatingGroupEnum?), string recognizedRevenueAccount = default(string), string revRecCode = default(string), string revRecTriggerCondition = default(string), string revenueRecognitionRuleName = default(string), string smoothingModel = default(string), long specificBillingPeriod = default(long), string taxCode = default(string), string taxMode = default(string), bool taxable = default(bool), string triggerEvent = default(string), string uOM = default(string), long upToPeriods = default(long), string upToPeriodsType = default(string), string updatedById = default(string), DateTime updatedDate = default(DateTime), bool useDiscountSpecificAccountingCode = default(bool), bool useTenantDefaultForPriceChange = default(bool), string weeklyBillCycleDay = default(string), string classNS = default(string), string deferredRevAccountNS = default(string), string departmentNS = default(string), IncludeChildrenNSEnum? includeChildrenNS = default(IncludeChildrenNSEnum?), string integrationIdNS = default(string), string integrationStatusNS = default(string), ItemTypeNSEnum? itemTypeNS = default(ItemTypeNSEnum?), string locationNS = default(string), string recognizedRevAccountNS = default(string), RevRecEndNSEnum? revRecEndNS = default(RevRecEndNSEnum?), RevRecStartNSEnum? revRecStartNS = default(RevRecStartNSEnum?), string revRecTemplateTypeNS = default(string), string subsidiaryNS = default(string), string syncDateNS = default(string))
        {
            this.AccountingCode = accountingCode;
            this.ApplyDiscountTo = applyDiscountTo;
            this.BillCycleDay = billCycleDay;
            this.BillCycleType = billCycleType;
            this.BillingPeriod = billingPeriod;
            this.BillingPeriodAlignment = billingPeriodAlignment;
            this.BillingTiming = billingTiming;
            this.ChargeModel = chargeModel;
            this.ChargeType = chargeType;
            this.CreatedById = createdById;
            this.CreatedDate = createdDate;
            this.DefaultQuantity = defaultQuantity;
            this.DeferredRevenueAccount = deferredRevenueAccount;
            this.Description = description;
            this.DiscountLevel = discountLevel;
            this.EndDateCondition = endDateCondition;
            this.ExcludeItemBillingFromRevenueAccounting = excludeItemBillingFromRevenueAccounting;
            this.ExcludeItemBookingFromRevenueAccounting = excludeItemBookingFromRevenueAccounting;
            this.Id = id;
            this.IncludedUnits = includedUnits;
            this.LegacyRevenueReporting = legacyRevenueReporting;
            this.ListPriceBase = listPriceBase;
            this.MaxQuantity = maxQuantity;
            this.MinQuantity = minQuantity;
            this.Name = name;
            this.NumberOfPeriod = numberOfPeriod;
            this.OverageCalculationOption = overageCalculationOption;
            this.OverageUnusedUnitsCreditOption = overageUnusedUnitsCreditOption;
            this.PriceChangeOption = priceChangeOption;
            this.PriceIncreasePercentage = priceIncreasePercentage;
            this.ProductRatePlanId = productRatePlanId;
            this.RatingGroup = ratingGroup;
            this.RecognizedRevenueAccount = recognizedRevenueAccount;
            this.RevRecCode = revRecCode;
            this.RevRecTriggerCondition = revRecTriggerCondition;
            this.RevenueRecognitionRuleName = revenueRecognitionRuleName;
            this.SmoothingModel = smoothingModel;
            this.SpecificBillingPeriod = specificBillingPeriod;
            this.TaxCode = taxCode;
            this.TaxMode = taxMode;
            this.Taxable = taxable;
            this.TriggerEvent = triggerEvent;
            this.UOM = uOM;
            this.UpToPeriods = upToPeriods;
            this.UpToPeriodsType = upToPeriodsType;
            this.UpdatedById = updatedById;
            this.UpdatedDate = updatedDate;
            this.UseDiscountSpecificAccountingCode = useDiscountSpecificAccountingCode;
            this.UseTenantDefaultForPriceChange = useTenantDefaultForPriceChange;
            this.WeeklyBillCycleDay = weeklyBillCycleDay;
            this.ClassNS = classNS;
            this.DeferredRevAccountNS = deferredRevAccountNS;
            this.DepartmentNS = departmentNS;
            this.IncludeChildrenNS = includeChildrenNS;
            this.IntegrationIdNS = integrationIdNS;
            this.IntegrationStatusNS = integrationStatusNS;
            this.ItemTypeNS = itemTypeNS;
            this.LocationNS = locationNS;
            this.RecognizedRevAccountNS = recognizedRevAccountNS;
            this.RevRecEndNS = revRecEndNS;
            this.RevRecStartNS = revRecStartNS;
            this.RevRecTemplateTypeNS = revRecTemplateTypeNS;
            this.SubsidiaryNS = subsidiaryNS;
            this.SyncDateNS = syncDateNS;
        }

        /// <summary>
        /// The accounting code for the charge. Accounting codes group transactions that contain similar accounting attributes. **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts 
        /// </summary>
        /// <value>The accounting code for the charge. Accounting codes group transactions that contain similar accounting attributes. **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts </value>
        [DataMember(Name = "AccountingCode", EmitDefaultValue = false)]
        public string AccountingCode { get; set; }

        /// <summary>
        /// Specifies the type of charges that you want a specific discount to apply to. All field values are case sensitive: note that these values are in all-caps. **Character limit**: 21 **Values**: one of the following:  - &#x60;ONETIME (1)&#x60; - &#x60;RECURRING (2)&#x60; - &#x60;USAGE (4)&#x60; - &#x60;ONETIMERECURRING (3)&#x60; - &#x60;ONETIMEUSAGE (5)&#x60; - &#x60;RECURRINGUSAGE (6)&#x60; - &#x60;ONETIMERECURRINGUSAGE (7)&#x60; 
        /// </summary>
        /// <value>Specifies the type of charges that you want a specific discount to apply to. All field values are case sensitive: note that these values are in all-caps. **Character limit**: 21 **Values**: one of the following:  - &#x60;ONETIME (1)&#x60; - &#x60;RECURRING (2)&#x60; - &#x60;USAGE (4)&#x60; - &#x60;ONETIMERECURRING (3)&#x60; - &#x60;ONETIMEUSAGE (5)&#x60; - &#x60;RECURRINGUSAGE (6)&#x60; - &#x60;ONETIMERECURRINGUSAGE (7)&#x60; </value>
        [DataMember(Name = "ApplyDiscountTo", EmitDefaultValue = false)]
        public string ApplyDiscountTo { get; set; }

        /// <summary>
        ///  Sets the bill cycle day (BCD) for the charge. The BCD determines which day of the month customer is billed. The BCD value in the account can override the BCD in this object. **Character limit**: 2 **Values**: a valid BCD integer, 1 - 31 
        /// </summary>
        /// <value> Sets the bill cycle day (BCD) for the charge. The BCD determines which day of the month customer is billed. The BCD value in the account can override the BCD in this object. **Character limit**: 2 **Values**: a valid BCD integer, 1 - 31 </value>
        [DataMember(Name = "BillCycleDay", EmitDefaultValue = false)]
        public int BillCycleDay { get; set; }

        /// <summary>
        ///  **Values**: one of the following:  - &#x60;DefaultFromCustomer&#x60; - &#x60;SpecificDayofMonth:&#x60; - &#x60;SubscriptionStartDay&#x60; - &#x60;ChargeTriggerDay&#x60; - &#x60;SpecificDayofWeek&#x60; - &#x60;TermStartDay&#x60; - &#x60;TermEndDay&#x60; 
        /// </summary>
        /// <value> **Values**: one of the following:  - &#x60;DefaultFromCustomer&#x60; - &#x60;SpecificDayofMonth:&#x60; - &#x60;SubscriptionStartDay&#x60; - &#x60;ChargeTriggerDay&#x60; - &#x60;SpecificDayofWeek&#x60; - &#x60;TermStartDay&#x60; - &#x60;TermEndDay&#x60; </value>
        [DataMember(Name = "BillCycleType", EmitDefaultValue = false)]
        public string BillCycleType { get; set; }

        /// <summary>
        ///  The billing period for the charge. The start day of the billing period is also called the bill cycle day (BCD). **Character limit**: 15 **Values**: one of the following  - &#x60;Month&#x60; - &#x60;Quarter&#x60; - &#x60;Annual&#x60; - &#x60;Semi-Annual&#x60; - &#x60;Specific Months&#x60; - &#x60;Subscription Term&#x60; (This value is in **Limited Availability**.) - &#x60;Week&#x60; - &#x60;Specific Weeks&#x60; **Note**: Specify the number of months or weeks in the SpecificBillingPeriod field if you set this field to &#x60;Specific Months&#x60; or &#x60;Specific Weeks&#x60;. 
        /// </summary>
        /// <value> The billing period for the charge. The start day of the billing period is also called the bill cycle day (BCD). **Character limit**: 15 **Values**: one of the following  - &#x60;Month&#x60; - &#x60;Quarter&#x60; - &#x60;Annual&#x60; - &#x60;Semi-Annual&#x60; - &#x60;Specific Months&#x60; - &#x60;Subscription Term&#x60; (This value is in **Limited Availability**.) - &#x60;Week&#x60; - &#x60;Specific Weeks&#x60; **Note**: Specify the number of months or weeks in the SpecificBillingPeriod field if you set this field to &#x60;Specific Months&#x60; or &#x60;Specific Weeks&#x60;. </value>
        [DataMember(Name = "BillingPeriod", EmitDefaultValue = false)]
        public string BillingPeriod { get; set; }

        /// <summary>
        ///  - &#x60;AlignToCharge&#x60; - &#x60;AlignToSubscriptionStart&#x60; - &#x60;AlignToTermStart&#x60; - &#x60;AlignToTermEnd&#x60; 
        /// </summary>
        /// <value> - &#x60;AlignToCharge&#x60; - &#x60;AlignToSubscriptionStart&#x60; - &#x60;AlignToTermStart&#x60; - &#x60;AlignToTermEnd&#x60; </value>
        [DataMember(Name = "BillingPeriodAlignment", EmitDefaultValue = false)]
        public string BillingPeriodAlignment { get; set; }

        /// <summary>
        ///  The billing timing for the charge. You can choose to bill in advance or in arrears for recurring charge types. This field is not used in one-time or usage based charge types. **Character limit**: **Values**: one of the following:  - &#x60;In Advance&#x60; - &#x60;In Arrears&#x60;  This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  
        /// </summary>
        /// <value> The billing timing for the charge. You can choose to bill in advance or in arrears for recurring charge types. This field is not used in one-time or usage based charge types. **Character limit**: **Values**: one of the following:  - &#x60;In Advance&#x60; - &#x60;In Arrears&#x60;  This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  </value>
        [DataMember(Name = "BillingTiming", EmitDefaultValue = false)]
        public string BillingTiming { get; set; }

        /// <summary>
        ///  Determines how to calculate charges. Charge models must be individually activated in Zuora Billing administration. **Character limit**: 27 **Values**: one of the following:  - &#x60;Discount-Fixed Amount&#x60; - &#x60;Discount-Percentage&#x60; - &#x60;Flat Fee Pricing&#x60; - &#x60;Per Unit Pricing&#x60; - &#x60;Overage Pricing&#x60; - &#x60;Tiered Pricing&#x60; - &#x60;Tiered with Overage Pricing&#x60; - &#x60;Volume Pricing&#x60; 
        /// </summary>
        /// <value> Determines how to calculate charges. Charge models must be individually activated in Zuora Billing administration. **Character limit**: 27 **Values**: one of the following:  - &#x60;Discount-Fixed Amount&#x60; - &#x60;Discount-Percentage&#x60; - &#x60;Flat Fee Pricing&#x60; - &#x60;Per Unit Pricing&#x60; - &#x60;Overage Pricing&#x60; - &#x60;Tiered Pricing&#x60; - &#x60;Tiered with Overage Pricing&#x60; - &#x60;Volume Pricing&#x60; </value>
        [DataMember(Name = "ChargeModel", EmitDefaultValue = false)]
        public string ChargeModel { get; set; }

        /// <summary>
        ///  Specifies the type of charge. **Character limit**: 9 **Values**: one of the following:  - &#x60;OneTime&#x60; - &#x60;Recurring&#x60; - &#x60;Usage&#x60; 
        /// </summary>
        /// <value> Specifies the type of charge. **Character limit**: 9 **Values**: one of the following:  - &#x60;OneTime&#x60; - &#x60;Recurring&#x60; - &#x60;Usage&#x60; </value>
        [DataMember(Name = "ChargeType", EmitDefaultValue = false)]
        public string ChargeType { get; set; }

        /// <summary>
        /// The ID of the Zuora user who created the &#x60;ProductRatePlanCharge&#x60; object. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value>The ID of the Zuora user who created the &#x60;ProductRatePlanCharge&#x60; object. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name = "CreatedById", EmitDefaultValue = false)]
        public string CreatedById { get; set; }

        /// <summary>
        ///  The date when the  &#x60;ProductRatePlanCharge&#x60; object was created. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value> The date when the  &#x60;ProductRatePlanCharge&#x60; object was created. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name = "CreatedDate", EmitDefaultValue = false)]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        ///  The default quantity of units, such as the number of authors in a hosted wiki service. This field is required if you use a per-unit pricing model.  **Character limit**: 16  **Values**: a valid quantity value. Note that when &#x60;ChargeModel&#x60; is &#x60;Tiered Pricing&#x60; or &#x60;Volume Pricing&#x60;, if this field is not specified, the value will default to &#x60;0&#x60;. 
        /// </summary>
        /// <value> The default quantity of units, such as the number of authors in a hosted wiki service. This field is required if you use a per-unit pricing model.  **Character limit**: 16  **Values**: a valid quantity value. Note that when &#x60;ChargeModel&#x60; is &#x60;Tiered Pricing&#x60; or &#x60;Volume Pricing&#x60;, if this field is not specified, the value will default to &#x60;0&#x60;. </value>
        [DataMember(Name = "DefaultQuantity", EmitDefaultValue = false)]
        public double DefaultQuantity { get; set; }

        /// <summary>
        ///  The name of the deferred revenue account for this charge. **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  
        /// </summary>
        /// <value> The name of the deferred revenue account for this charge. **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  </value>
        [DataMember(Name = "DeferredRevenueAccount", EmitDefaultValue = false)]
        public string DeferredRevenueAccount { get; set; }

        /// <summary>
        /// A description of the charge. **Character limit**: 500 **Values**: a string of 500 characters or fewer 
        /// </summary>
        /// <value>A description of the charge. **Character limit**: 500 **Values**: a string of 500 characters or fewer </value>
        [DataMember(Name = "Description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        ///  Specifies if the discount applies to just the product rate plan, the entire subscription, or to any activity in the account. **Character limit**: 12 **Values**: one of the following:  - &#x60;rateplan&#x60; - &#x60;subscription&#x60;, &#x60;account&#x60; 
        /// </summary>
        /// <value> Specifies if the discount applies to just the product rate plan, the entire subscription, or to any activity in the account. **Character limit**: 12 **Values**: one of the following:  - &#x60;rateplan&#x60; - &#x60;subscription&#x60;, &#x60;account&#x60; </value>
        [DataMember(Name = "DiscountLevel", EmitDefaultValue = false)]
        public string DiscountLevel { get; set; }

        /// <summary>
        ///  Defines when the charge ends after the charge trigger date. **Values**: one of the following:  - &#x60;SubscriptionEnd&#x60;: The charge ends on the subscription end date after a specified period based on the trigger date of the charge. This is the default value. - &#x60;FixedPeriod&#x60;: The charge ends after a specified period based on the trigger date of the charge. If you set this field to &#x60;FixedPeriod&#x60;, you must specify the length of the period and a period type by defining the &#x60;UpToPeriods&#x60; and &#x60;UpToPeriodsType&#x60; fields. **Note**: If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date. 
        /// </summary>
        /// <value> Defines when the charge ends after the charge trigger date. **Values**: one of the following:  - &#x60;SubscriptionEnd&#x60;: The charge ends on the subscription end date after a specified period based on the trigger date of the charge. This is the default value. - &#x60;FixedPeriod&#x60;: The charge ends after a specified period based on the trigger date of the charge. If you set this field to &#x60;FixedPeriod&#x60;, you must specify the length of the period and a period type by defining the &#x60;UpToPeriods&#x60; and &#x60;UpToPeriodsType&#x60; fields. **Note**: If the subscription ends before the charge end date, the charge ends when the subscription ends. But if the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge will end on the charge end date. </value>
        [DataMember(Name = "EndDateCondition", EmitDefaultValue = false)]
        public string EndDateCondition { get; set; }

        /// <summary>
        /// The flag to exclude the related invoice items, invoice item adjustments, credit memo items, and debit memo items from revenue accounting.  **Note**: To use this field, you must set the &#x60;X-Zuora-WSDL-Version&#x60; request header to &#x60;115&#x60; or later. Otherwise, an error occurs.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  
        /// </summary>
        /// <value>The flag to exclude the related invoice items, invoice item adjustments, credit memo items, and debit memo items from revenue accounting.  **Note**: To use this field, you must set the &#x60;X-Zuora-WSDL-Version&#x60; request header to &#x60;115&#x60; or later. Otherwise, an error occurs.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  </value>
        [DataMember(Name = "ExcludeItemBillingFromRevenueAccounting", EmitDefaultValue = true)]
        public bool ExcludeItemBillingFromRevenueAccounting { get; set; }

        /// <summary>
        /// The flag to exclude the related rate plan charges and order line items from revenue accounting.  **Note**: To use this field, you must set the &#x60;X-Zuora-WSDL-Version&#x60; request header to &#x60;115&#x60; or later. Otherwise, an error occurs.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  
        /// </summary>
        /// <value>The flag to exclude the related rate plan charges and order line items from revenue accounting.  **Note**: To use this field, you must set the &#x60;X-Zuora-WSDL-Version&#x60; request header to &#x60;115&#x60; or later. Otherwise, an error occurs.  **Note**: This field is only available if you have the Billing - Revenue Integration feature enabled.  </value>
        [DataMember(Name = "ExcludeItemBookingFromRevenueAccounting", EmitDefaultValue = true)]
        public bool ExcludeItemBookingFromRevenueAccounting { get; set; }

        /// <summary>
        /// Object identifier.
        /// </summary>
        /// <value>Object identifier.</value>
        [DataMember(Name = "Id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Specifies the number of units in the base set of units. **Character limit**: 16 **Values**: a positive decimal value 
        /// </summary>
        /// <value>Specifies the number of units in the base set of units. **Character limit**: 16 **Values**: a positive decimal value </value>
        [DataMember(Name = "IncludedUnits", EmitDefaultValue = false)]
        public double IncludedUnits { get; set; }

        /// <summary>
        /// Gets or Sets LegacyRevenueReporting
        /// </summary>
        [DataMember(Name = "LegacyRevenueReporting", EmitDefaultValue = true)]
        public bool LegacyRevenueReporting { get; set; }

        /// <summary>
        /// The list price base for the product rate plan charge. **Values**: one of the following:  - &#x60;Per Month&#x60; - &#x60;Per Billing Period&#x60; - &#x60;Per Week&#x60; 
        /// </summary>
        /// <value>The list price base for the product rate plan charge. **Values**: one of the following:  - &#x60;Per Month&#x60; - &#x60;Per Billing Period&#x60; - &#x60;Per Week&#x60; </value>
        [DataMember(Name = "ListPriceBase", EmitDefaultValue = false)]
        public string ListPriceBase { get; set; }

        /// <summary>
        ///  Specifies the maximum number of units for this charge. Use this field and the &#x60;MinQuantity&#x60; field to create a range of units allowed in a product rate plan charge. **Character limit**: 16 **Values**: a positive decimal value 
        /// </summary>
        /// <value> Specifies the maximum number of units for this charge. Use this field and the &#x60;MinQuantity&#x60; field to create a range of units allowed in a product rate plan charge. **Character limit**: 16 **Values**: a positive decimal value </value>
        [DataMember(Name = "MaxQuantity", EmitDefaultValue = false)]
        public double MaxQuantity { get; set; }

        /// <summary>
        /// Specifies the minimum number of units for this charge. Use this field and the &#x60;MaxQuantity&#x60; field to create a range of units allowed in a product rate plan charge. **Character limit**: 16 **Values**: a positive decimal value 
        /// </summary>
        /// <value>Specifies the minimum number of units for this charge. Use this field and the &#x60;MaxQuantity&#x60; field to create a range of units allowed in a product rate plan charge. **Character limit**: 16 **Values**: a positive decimal value </value>
        [DataMember(Name = "MinQuantity", EmitDefaultValue = false)]
        public double MinQuantity { get; set; }

        /// <summary>
        /// The name of the product rate plan charge. **Character limit**: 100 **Values**: a string of 100 characters or fewer 
        /// </summary>
        /// <value>The name of the product rate plan charge. **Character limit**: 100 **Values**: a string of 100 characters or fewer </value>
        [DataMember(Name = "Name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Specifies the number of periods to use when calculating charges in an overage smoothing charge model. **Character limit**: **Values**: a positive whole number 
        /// </summary>
        /// <value>Specifies the number of periods to use when calculating charges in an overage smoothing charge model. **Character limit**: **Values**: a positive whole number </value>
        [DataMember(Name = "NumberOfPeriod", EmitDefaultValue = false)]
        public long NumberOfPeriod { get; set; }

        /// <summary>
        /// Determines when to calculate overage charges. If the value of the SmoothingMode field is not specified, the value of this field is ignored. **Character limit**: 20 **Values**: one of the following:  - &#x60;EndOfSmoothingPeriod&#x60;: This option is used by default. The overage is charged at the end of the smoothing period. - &#x60;PerBillingPeriod&#x60;: The overage is charged on-demand rather than waiting until the end of the smoothing period. 
        /// </summary>
        /// <value>Determines when to calculate overage charges. If the value of the SmoothingMode field is not specified, the value of this field is ignored. **Character limit**: 20 **Values**: one of the following:  - &#x60;EndOfSmoothingPeriod&#x60;: This option is used by default. The overage is charged at the end of the smoothing period. - &#x60;PerBillingPeriod&#x60;: The overage is charged on-demand rather than waiting until the end of the smoothing period. </value>
        [DataMember(Name = "OverageCalculationOption", EmitDefaultValue = false)]
        public string OverageCalculationOption { get; set; }

        /// <summary>
        ///  Determines whether to credit the customer with unused units of usage. **Character limit**: 20 **Values**: one of the following:  - &#x60;NoCredit&#x60; - &#x60;CreditBySpecificRate&#x60; 
        /// </summary>
        /// <value> Determines whether to credit the customer with unused units of usage. **Character limit**: 20 **Values**: one of the following:  - &#x60;NoCredit&#x60; - &#x60;CreditBySpecificRate&#x60; </value>
        [DataMember(Name = "OverageUnusedUnitsCreditOption", EmitDefaultValue = false)]
        public string OverageUnusedUnitsCreditOption { get; set; }

        /// <summary>
        ///  Applies an automatic price change when a termed subscription is renewed. **Character limit**: **Values**: one of the following:  - &#x60;NoChange&#x60; (default) - &#x60;SpecificPercentageValue&#x60; - &#x60;UseLatestProductCatalogPricing&#x60; 
        /// </summary>
        /// <value> Applies an automatic price change when a termed subscription is renewed. **Character limit**: **Values**: one of the following:  - &#x60;NoChange&#x60; (default) - &#x60;SpecificPercentageValue&#x60; - &#x60;UseLatestProductCatalogPricing&#x60; </value>
        [DataMember(Name = "PriceChangeOption", EmitDefaultValue = false)]
        public string PriceChangeOption { get; set; }

        /// <summary>
        ///  Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Use this field if you set the value to &#x60;SpecificPercentageValue&#x60;. **Character limit**: 16 **Values**: a decimal value between -100 and 100 
        /// </summary>
        /// <value> Specifies the percentage to increase or decrease the price of a termed subscription&#39;s renewal. Use this field if you set the value to &#x60;SpecificPercentageValue&#x60;. **Character limit**: 16 **Values**: a decimal value between -100 and 100 </value>
        [DataMember(Name = "PriceIncreasePercentage", EmitDefaultValue = false)]
        public double PriceIncreasePercentage { get; set; }

        /// <summary>
        ///  The ID of the product rate plan associated with this product rate plan charge. **Character limit**: 32 **Values**: a valid product rate plan ID 
        /// </summary>
        /// <value> The ID of the product rate plan associated with this product rate plan charge. **Character limit**: 32 **Values**: a valid product rate plan ID </value>
        [DataMember(Name = "ProductRatePlanId", EmitDefaultValue = false)]
        public string ProductRatePlanId { get; set; }

        /// <summary>
        ///  The name of the recognized revenue account for this charge.  - Required when the Allow Blank Accounting Code setting is No. - Optional when the Allow Blank Accounting Code setting is Yes.  **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  
        /// </summary>
        /// <value> The name of the recognized revenue account for this charge.  - Required when the Allow Blank Accounting Code setting is No. - Optional when the Allow Blank Accounting Code setting is Yes.  **Character limit**: 100 **Values**: an active accounting code in your Zuora Chart of Accounts This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  </value>
        [DataMember(Name = "RecognizedRevenueAccount", EmitDefaultValue = false)]
        public string RecognizedRevenueAccount { get; set; }

        /// <summary>
        /// Associates this product rate plan charge with a specific revenue recognition code. **Character limit**: 70 **Values**: a valid revenue recognition code 
        /// </summary>
        /// <value>Associates this product rate plan charge with a specific revenue recognition code. **Character limit**: 70 **Values**: a valid revenue recognition code </value>
        [DataMember(Name = "RevRecCode", EmitDefaultValue = false)]
        public string RevRecCode { get; set; }

        /// <summary>
        ///  Specifies when revenue recognition begins. **Character limit**: 22 **Values**: one of the following:  - &#x60;ContractEffectiveDate&#x60; - &#x60;ServiceActivationDate&#x60; - &#x60;CustomerAcceptanceDate&#x60; 
        /// </summary>
        /// <value> Specifies when revenue recognition begins. **Character limit**: 22 **Values**: one of the following:  - &#x60;ContractEffectiveDate&#x60; - &#x60;ServiceActivationDate&#x60; - &#x60;CustomerAcceptanceDate&#x60; </value>
        [DataMember(Name = "RevRecTriggerCondition", EmitDefaultValue = false)]
        public string RevRecTriggerCondition { get; set; }

        /// <summary>
        /// Determines when to recognize the revenue for this charge. **Character limit**: 25 **Values**: one of the following:  - &#x60;Recognize upon invoicing&#x60; - &#x60;Recognize daily over time&#x60; 
        /// </summary>
        /// <value>Determines when to recognize the revenue for this charge. **Character limit**: 25 **Values**: one of the following:  - &#x60;Recognize upon invoicing&#x60; - &#x60;Recognize daily over time&#x60; </value>
        [DataMember(Name = "RevenueRecognitionRuleName", EmitDefaultValue = false)]
        public string RevenueRecognitionRuleName { get; set; }

        /// <summary>
        ///  Specifies the smoothing model for an overage smoothing charge model. **Character limit**: 22 **Values**: one of the following:  - &#x60;RollingWindow&#x60; - &#x60;Rollover&#x60; 
        /// </summary>
        /// <value> Specifies the smoothing model for an overage smoothing charge model. **Character limit**: 22 **Values**: one of the following:  - &#x60;RollingWindow&#x60; - &#x60;Rollover&#x60; </value>
        [DataMember(Name = "SmoothingModel", EmitDefaultValue = false)]
        public string SmoothingModel { get; set; }

        /// <summary>
        ///  Customizes the number of months or weeks for the charges billing period. This field is required if you set the value of the BillingPeriod field to &#x60;Specific Months&#x60; or &#x60;Specific Weeks&#x60;. **Values**: a positive integer 
        /// </summary>
        /// <value> Customizes the number of months or weeks for the charges billing period. This field is required if you set the value of the BillingPeriod field to &#x60;Specific Months&#x60; or &#x60;Specific Weeks&#x60;. **Values**: a positive integer </value>
        [DataMember(Name = "SpecificBillingPeriod", EmitDefaultValue = false)]
        public long SpecificBillingPeriod { get; set; }

        /// <summary>
        ///  Specifies the tax code for taxation rules. Required when the Taxable field is set to &#x60;True&#x60;.  **Character limit**: 64  **Values**: a valid tax code  **Note**: This value affects the tax calculation of rate plan charges that come from the &#x60;ProductRatePlanCharge&#x60;. 
        /// </summary>
        /// <value> Specifies the tax code for taxation rules. Required when the Taxable field is set to &#x60;True&#x60;.  **Character limit**: 64  **Values**: a valid tax code  **Note**: This value affects the tax calculation of rate plan charges that come from the &#x60;ProductRatePlanCharge&#x60;. </value>
        [DataMember(Name = "TaxCode", EmitDefaultValue = false)]
        public string TaxCode { get; set; }

        /// <summary>
        ///  Determines how to define taxation for the charge. Required when the Taxable field is set to &#x60;True&#x60;.  **Character limit**: 12  **Values**: one of the following:  - &#x60;TaxExclusive&#x60; - &#x60;TaxInclusive&#x60;  **Note**: This value affects the tax calculation of rate plan charges that come from the &#x60;ProductRatePlanCharge&#x60;. 
        /// </summary>
        /// <value> Determines how to define taxation for the charge. Required when the Taxable field is set to &#x60;True&#x60;.  **Character limit**: 12  **Values**: one of the following:  - &#x60;TaxExclusive&#x60; - &#x60;TaxInclusive&#x60;  **Note**: This value affects the tax calculation of rate plan charges that come from the &#x60;ProductRatePlanCharge&#x60;. </value>
        [DataMember(Name = "TaxMode", EmitDefaultValue = false)]
        public string TaxMode { get; set; }

        /// <summary>
        ///  Determines whether the charge is taxable. When set to &#x60;True&#x60;, the TaxMode and TaxCode fields are required when creating or updating th ProductRatePlanCharge object.  **Character limit**: 5  **Values**: &#x60;True&#x60;, &#x60;False&#x60;  **Note**: This value affects the tax calculation of rate plan charges that come from the &#x60;ProductRatePlanCharge&#x60;. 
        /// </summary>
        /// <value> Determines whether the charge is taxable. When set to &#x60;True&#x60;, the TaxMode and TaxCode fields are required when creating or updating th ProductRatePlanCharge object.  **Character limit**: 5  **Values**: &#x60;True&#x60;, &#x60;False&#x60;  **Note**: This value affects the tax calculation of rate plan charges that come from the &#x60;ProductRatePlanCharge&#x60;. </value>
        [DataMember(Name = "Taxable", EmitDefaultValue = true)]
        public bool Taxable { get; set; }

        /// <summary>
        ///  Specifies when to start billing the customer for the charge. **Character limit**: 18 **Values**: one of the following:  - &#x60;ContractEffective&#x60; is the date when the subscription&#39;s contract goes into effect and the charge is ready to be billed. - &#x60;ServiceActivation&#x60; is the date when the services or products for a subscription have been activated and the customers have access. - &#x60;CustomerAcceptance&#x60; is when the customer accepts the services or products for a subscription. 
        /// </summary>
        /// <value> Specifies when to start billing the customer for the charge. **Character limit**: 18 **Values**: one of the following:  - &#x60;ContractEffective&#x60; is the date when the subscription&#39;s contract goes into effect and the charge is ready to be billed. - &#x60;ServiceActivation&#x60; is the date when the services or products for a subscription have been activated and the customers have access. - &#x60;CustomerAcceptance&#x60; is when the customer accepts the services or products for a subscription. </value>
        [DataMember(Name = "TriggerEvent", EmitDefaultValue = false)]
        public string TriggerEvent { get; set; }

        /// <summary>
        ///  Specifies the units to measure usage. **Character limit**: 25 **Values**: a configured unit of measure **Note**: You must specify this field when creating the following charge models:  - Per Unit Pricing - Volume Pricing - Overage Pricing - Tiered Pricing - Tiered with Overage Pricing 
        /// </summary>
        /// <value> Specifies the units to measure usage. **Character limit**: 25 **Values**: a configured unit of measure **Note**: You must specify this field when creating the following charge models:  - Per Unit Pricing - Volume Pricing - Overage Pricing - Tiered Pricing - Tiered with Overage Pricing </value>
        [DataMember(Name = "UOM", EmitDefaultValue = false)]
        public string UOM { get; set; }

        /// <summary>
        ///  Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends. **Character limit**: 5 **Values**: a whole number between 0 and 65535, exclusive **Note**:  - You must use this field together with the &#x60;UpToPeriodsType&#x60; field to specify the time period. This field is applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. - If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. 
        /// </summary>
        /// <value> Specifies the length of the period during which the charge is active. If this period ends before the subscription ends, the charge ends when this period ends. **Character limit**: 5 **Values**: a whole number between 0 and 65535, exclusive **Note**:  - You must use this field together with the &#x60;UpToPeriodsType&#x60; field to specify the time period. This field is applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. - If the subscription end date is subsequently changed through a Renewal, or Terms and Conditions amendment, the charge end date will change accordingly up to the original period end. </value>
        [DataMember(Name = "UpToPeriods", EmitDefaultValue = false)]
        public long UpToPeriods { get; set; }

        /// <summary>
        ///  The period type used to define when the charge ends. **Character limit**: - - **Values**: one of the following:  - &#x60;Billing Periods&#x60; (default) - &#x60;Days&#x60; - &#x60;Weeks&#x60; - &#x60;Months&#x60; - &#x60;Years&#x60;  **Note**:  - You must use this field together with the &#x60;UpToPeriods&#x60; field to specify the time period. - This field is applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. 
        /// </summary>
        /// <value> The period type used to define when the charge ends. **Character limit**: - - **Values**: one of the following:  - &#x60;Billing Periods&#x60; (default) - &#x60;Days&#x60; - &#x60;Weeks&#x60; - &#x60;Months&#x60; - &#x60;Years&#x60;  **Note**:  - You must use this field together with the &#x60;UpToPeriods&#x60; field to specify the time period. - This field is applicable only when the &#x60;EndDateCondition&#x60; field is set to &#x60;FixedPeriod&#x60;. </value>
        [DataMember(Name = "UpToPeriodsType", EmitDefaultValue = false)]
        public string UpToPeriodsType { get; set; }

        /// <summary>
        /// The ID of the last user to update the object. **Character limit**: 32 **Values**: automatically generated 
        /// </summary>
        /// <value>The ID of the last user to update the object. **Character limit**: 32 **Values**: automatically generated </value>
        [DataMember(Name = "UpdatedById", EmitDefaultValue = false)]
        public string UpdatedById { get; set; }

        /// <summary>
        /// The date when the object was last updated. **Character limit**: 29 **Values**: automatically generated 
        /// </summary>
        /// <value>The date when the object was last updated. **Character limit**: 29 **Values**: automatically generated </value>
        [DataMember(Name = "UpdatedDate", EmitDefaultValue = false)]
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// Determines whether to define a new accounting code for the new discount charge. **Character limit**: 5 **Values**: &#x60;True&#x60;, &#x60;False&#x60; 
        /// </summary>
        /// <value>Determines whether to define a new accounting code for the new discount charge. **Character limit**: 5 **Values**: &#x60;True&#x60;, &#x60;False&#x60; </value>
        [DataMember(Name = "UseDiscountSpecificAccountingCode", EmitDefaultValue = true)]
        public bool UseDiscountSpecificAccountingCode { get; set; }

        /// <summary>
        ///  Applies the tenant-level percentage uplift value for an automatic price change to a termed subscription&#39;s renewal. **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; 
        /// </summary>
        /// <value> Applies the tenant-level percentage uplift value for an automatic price change to a termed subscription&#39;s renewal. **Character limit**: 5 **Values**: &#x60;true&#x60;, &#x60;false&#x60; </value>
        [DataMember(Name = "UseTenantDefaultForPriceChange", EmitDefaultValue = true)]
        public bool UseTenantDefaultForPriceChange { get; set; }

        /// <summary>
        ///  Specifies which day of the week as the bill cycle day (BCD) for the charge. This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  **Values**: one of the following:  - &#x60;Sunday&#x60; - &#x60;Monday&#x60; - &#x60;Tuesday&#x60; - &#x60;Wednesday&#x60; - &#x60;Thursday&#x60; - &#x60;Friday&#x60; - &#x60;Saturday&#x60; 
        /// </summary>
        /// <value> Specifies which day of the week as the bill cycle day (BCD) for the charge. This feature is in **Limited Availability**. If you wish to have access to the feature, submit a request at [Zuora Global Support](http://support.zuora.com/).  **Values**: one of the following:  - &#x60;Sunday&#x60; - &#x60;Monday&#x60; - &#x60;Tuesday&#x60; - &#x60;Wednesday&#x60; - &#x60;Thursday&#x60; - &#x60;Friday&#x60; - &#x60;Saturday&#x60; </value>
        [DataMember(Name = "WeeklyBillCycleDay", EmitDefaultValue = false)]
        public string WeeklyBillCycleDay { get; set; }

        /// <summary>
        /// Class associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Class associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "Class__NS", EmitDefaultValue = false)]
        public string ClassNS { get; set; }

        /// <summary>
        /// Deferrred revenue account associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Deferrred revenue account associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "DeferredRevAccount__NS", EmitDefaultValue = false)]
        public string DeferredRevAccountNS { get; set; }

        /// <summary>
        /// Department associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Department associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "Department__NS", EmitDefaultValue = false)]
        public string DepartmentNS { get; set; }

        /// <summary>
        /// ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>ID of the corresponding object in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "IntegrationId__NS", EmitDefaultValue = false)]
        public string IntegrationIdNS { get; set; }

        /// <summary>
        /// Status of the product rate plan charge&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Status of the product rate plan charge&#39;s synchronization with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "IntegrationStatus__NS", EmitDefaultValue = false)]
        public string IntegrationStatusNS { get; set; }

        /// <summary>
        /// Location associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Location associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "Location__NS", EmitDefaultValue = false)]
        public string LocationNS { get; set; }

        /// <summary>
        /// Recognized revenue account associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Recognized revenue account associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "RecognizedRevAccount__NS", EmitDefaultValue = false)]
        public string RecognizedRevAccountNS { get; set; }

        /// <summary>
        /// Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "RevRecTemplateType__NS", EmitDefaultValue = false)]
        public string RevRecTemplateTypeNS { get; set; }

        /// <summary>
        /// Subsidiary associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Subsidiary associated with the corresponding item in NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "Subsidiary__NS", EmitDefaultValue = false)]
        public string SubsidiaryNS { get; set; }

        /// <summary>
        /// Date when the product rate plan charge was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). 
        /// </summary>
        /// <value>Date when the product rate plan charge was synchronized with NetSuite. Only available if you have installed the [Zuora Connector for NetSuite](https://www.zuora.com/connect/app/?appId&#x3D;265). </value>
        [DataMember(Name = "SyncDate__NS", EmitDefaultValue = false)]
        public string SyncDateNS { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ProxyGetProductRatePlanCharge {\n");
            sb.Append("  AccountingCode: ").Append(AccountingCode).Append("\n");
            sb.Append("  ApplyDiscountTo: ").Append(ApplyDiscountTo).Append("\n");
            sb.Append("  BillCycleDay: ").Append(BillCycleDay).Append("\n");
            sb.Append("  BillCycleType: ").Append(BillCycleType).Append("\n");
            sb.Append("  BillingPeriod: ").Append(BillingPeriod).Append("\n");
            sb.Append("  BillingPeriodAlignment: ").Append(BillingPeriodAlignment).Append("\n");
            sb.Append("  BillingTiming: ").Append(BillingTiming).Append("\n");
            sb.Append("  ChargeModel: ").Append(ChargeModel).Append("\n");
            sb.Append("  ChargeType: ").Append(ChargeType).Append("\n");
            sb.Append("  CreatedById: ").Append(CreatedById).Append("\n");
            sb.Append("  CreatedDate: ").Append(CreatedDate).Append("\n");
            sb.Append("  DefaultQuantity: ").Append(DefaultQuantity).Append("\n");
            sb.Append("  DeferredRevenueAccount: ").Append(DeferredRevenueAccount).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  DiscountLevel: ").Append(DiscountLevel).Append("\n");
            sb.Append("  EndDateCondition: ").Append(EndDateCondition).Append("\n");
            sb.Append("  ExcludeItemBillingFromRevenueAccounting: ").Append(ExcludeItemBillingFromRevenueAccounting).Append("\n");
            sb.Append("  ExcludeItemBookingFromRevenueAccounting: ").Append(ExcludeItemBookingFromRevenueAccounting).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  IncludedUnits: ").Append(IncludedUnits).Append("\n");
            sb.Append("  LegacyRevenueReporting: ").Append(LegacyRevenueReporting).Append("\n");
            sb.Append("  ListPriceBase: ").Append(ListPriceBase).Append("\n");
            sb.Append("  MaxQuantity: ").Append(MaxQuantity).Append("\n");
            sb.Append("  MinQuantity: ").Append(MinQuantity).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  NumberOfPeriod: ").Append(NumberOfPeriod).Append("\n");
            sb.Append("  OverageCalculationOption: ").Append(OverageCalculationOption).Append("\n");
            sb.Append("  OverageUnusedUnitsCreditOption: ").Append(OverageUnusedUnitsCreditOption).Append("\n");
            sb.Append("  PriceChangeOption: ").Append(PriceChangeOption).Append("\n");
            sb.Append("  PriceIncreasePercentage: ").Append(PriceIncreasePercentage).Append("\n");
            sb.Append("  ProductRatePlanId: ").Append(ProductRatePlanId).Append("\n");
            sb.Append("  RatingGroup: ").Append(RatingGroup).Append("\n");
            sb.Append("  RecognizedRevenueAccount: ").Append(RecognizedRevenueAccount).Append("\n");
            sb.Append("  RevRecCode: ").Append(RevRecCode).Append("\n");
            sb.Append("  RevRecTriggerCondition: ").Append(RevRecTriggerCondition).Append("\n");
            sb.Append("  RevenueRecognitionRuleName: ").Append(RevenueRecognitionRuleName).Append("\n");
            sb.Append("  SmoothingModel: ").Append(SmoothingModel).Append("\n");
            sb.Append("  SpecificBillingPeriod: ").Append(SpecificBillingPeriod).Append("\n");
            sb.Append("  TaxCode: ").Append(TaxCode).Append("\n");
            sb.Append("  TaxMode: ").Append(TaxMode).Append("\n");
            sb.Append("  Taxable: ").Append(Taxable).Append("\n");
            sb.Append("  TriggerEvent: ").Append(TriggerEvent).Append("\n");
            sb.Append("  UOM: ").Append(UOM).Append("\n");
            sb.Append("  UpToPeriods: ").Append(UpToPeriods).Append("\n");
            sb.Append("  UpToPeriodsType: ").Append(UpToPeriodsType).Append("\n");
            sb.Append("  UpdatedById: ").Append(UpdatedById).Append("\n");
            sb.Append("  UpdatedDate: ").Append(UpdatedDate).Append("\n");
            sb.Append("  UseDiscountSpecificAccountingCode: ").Append(UseDiscountSpecificAccountingCode).Append("\n");
            sb.Append("  UseTenantDefaultForPriceChange: ").Append(UseTenantDefaultForPriceChange).Append("\n");
            sb.Append("  WeeklyBillCycleDay: ").Append(WeeklyBillCycleDay).Append("\n");
            sb.Append("  ClassNS: ").Append(ClassNS).Append("\n");
            sb.Append("  DeferredRevAccountNS: ").Append(DeferredRevAccountNS).Append("\n");
            sb.Append("  DepartmentNS: ").Append(DepartmentNS).Append("\n");
            sb.Append("  IncludeChildrenNS: ").Append(IncludeChildrenNS).Append("\n");
            sb.Append("  IntegrationIdNS: ").Append(IntegrationIdNS).Append("\n");
            sb.Append("  IntegrationStatusNS: ").Append(IntegrationStatusNS).Append("\n");
            sb.Append("  ItemTypeNS: ").Append(ItemTypeNS).Append("\n");
            sb.Append("  LocationNS: ").Append(LocationNS).Append("\n");
            sb.Append("  RecognizedRevAccountNS: ").Append(RecognizedRevAccountNS).Append("\n");
            sb.Append("  RevRecEndNS: ").Append(RevRecEndNS).Append("\n");
            sb.Append("  RevRecStartNS: ").Append(RevRecStartNS).Append("\n");
            sb.Append("  RevRecTemplateTypeNS: ").Append(RevRecTemplateTypeNS).Append("\n");
            sb.Append("  SubsidiaryNS: ").Append(SubsidiaryNS).Append("\n");
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
            return this.Equals(input as ProxyGetProductRatePlanCharge);
        }

        /// <summary>
        /// Returns true if ProxyGetProductRatePlanCharge instances are equal
        /// </summary>
        /// <param name="input">Instance of ProxyGetProductRatePlanCharge to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProxyGetProductRatePlanCharge input)
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
                    this.ApplyDiscountTo == input.ApplyDiscountTo ||
                    (this.ApplyDiscountTo != null &&
                    this.ApplyDiscountTo.Equals(input.ApplyDiscountTo))
                ) && 
                (
                    this.BillCycleDay == input.BillCycleDay ||
                    this.BillCycleDay.Equals(input.BillCycleDay)
                ) && 
                (
                    this.BillCycleType == input.BillCycleType ||
                    (this.BillCycleType != null &&
                    this.BillCycleType.Equals(input.BillCycleType))
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
                    this.ChargeModel == input.ChargeModel ||
                    (this.ChargeModel != null &&
                    this.ChargeModel.Equals(input.ChargeModel))
                ) && 
                (
                    this.ChargeType == input.ChargeType ||
                    (this.ChargeType != null &&
                    this.ChargeType.Equals(input.ChargeType))
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
                    this.DefaultQuantity == input.DefaultQuantity ||
                    this.DefaultQuantity.Equals(input.DefaultQuantity)
                ) && 
                (
                    this.DeferredRevenueAccount == input.DeferredRevenueAccount ||
                    (this.DeferredRevenueAccount != null &&
                    this.DeferredRevenueAccount.Equals(input.DeferredRevenueAccount))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.DiscountLevel == input.DiscountLevel ||
                    (this.DiscountLevel != null &&
                    this.DiscountLevel.Equals(input.DiscountLevel))
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
                    this.LegacyRevenueReporting == input.LegacyRevenueReporting ||
                    this.LegacyRevenueReporting.Equals(input.LegacyRevenueReporting)
                ) && 
                (
                    this.ListPriceBase == input.ListPriceBase ||
                    (this.ListPriceBase != null &&
                    this.ListPriceBase.Equals(input.ListPriceBase))
                ) && 
                (
                    this.MaxQuantity == input.MaxQuantity ||
                    this.MaxQuantity.Equals(input.MaxQuantity)
                ) && 
                (
                    this.MinQuantity == input.MinQuantity ||
                    this.MinQuantity.Equals(input.MinQuantity)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.NumberOfPeriod == input.NumberOfPeriod ||
                    this.NumberOfPeriod.Equals(input.NumberOfPeriod)
                ) && 
                (
                    this.OverageCalculationOption == input.OverageCalculationOption ||
                    (this.OverageCalculationOption != null &&
                    this.OverageCalculationOption.Equals(input.OverageCalculationOption))
                ) && 
                (
                    this.OverageUnusedUnitsCreditOption == input.OverageUnusedUnitsCreditOption ||
                    (this.OverageUnusedUnitsCreditOption != null &&
                    this.OverageUnusedUnitsCreditOption.Equals(input.OverageUnusedUnitsCreditOption))
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
                    this.ProductRatePlanId == input.ProductRatePlanId ||
                    (this.ProductRatePlanId != null &&
                    this.ProductRatePlanId.Equals(input.ProductRatePlanId))
                ) && 
                (
                    this.RatingGroup == input.RatingGroup ||
                    this.RatingGroup.Equals(input.RatingGroup)
                ) && 
                (
                    this.RecognizedRevenueAccount == input.RecognizedRevenueAccount ||
                    (this.RecognizedRevenueAccount != null &&
                    this.RecognizedRevenueAccount.Equals(input.RecognizedRevenueAccount))
                ) && 
                (
                    this.RevRecCode == input.RevRecCode ||
                    (this.RevRecCode != null &&
                    this.RevRecCode.Equals(input.RevRecCode))
                ) && 
                (
                    this.RevRecTriggerCondition == input.RevRecTriggerCondition ||
                    (this.RevRecTriggerCondition != null &&
                    this.RevRecTriggerCondition.Equals(input.RevRecTriggerCondition))
                ) && 
                (
                    this.RevenueRecognitionRuleName == input.RevenueRecognitionRuleName ||
                    (this.RevenueRecognitionRuleName != null &&
                    this.RevenueRecognitionRuleName.Equals(input.RevenueRecognitionRuleName))
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
                    this.Taxable == input.Taxable ||
                    this.Taxable.Equals(input.Taxable)
                ) && 
                (
                    this.TriggerEvent == input.TriggerEvent ||
                    (this.TriggerEvent != null &&
                    this.TriggerEvent.Equals(input.TriggerEvent))
                ) && 
                (
                    this.UOM == input.UOM ||
                    (this.UOM != null &&
                    this.UOM.Equals(input.UOM))
                ) && 
                (
                    this.UpToPeriods == input.UpToPeriods ||
                    this.UpToPeriods.Equals(input.UpToPeriods)
                ) && 
                (
                    this.UpToPeriodsType == input.UpToPeriodsType ||
                    (this.UpToPeriodsType != null &&
                    this.UpToPeriodsType.Equals(input.UpToPeriodsType))
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
                    this.UseDiscountSpecificAccountingCode == input.UseDiscountSpecificAccountingCode ||
                    this.UseDiscountSpecificAccountingCode.Equals(input.UseDiscountSpecificAccountingCode)
                ) && 
                (
                    this.UseTenantDefaultForPriceChange == input.UseTenantDefaultForPriceChange ||
                    this.UseTenantDefaultForPriceChange.Equals(input.UseTenantDefaultForPriceChange)
                ) && 
                (
                    this.WeeklyBillCycleDay == input.WeeklyBillCycleDay ||
                    (this.WeeklyBillCycleDay != null &&
                    this.WeeklyBillCycleDay.Equals(input.WeeklyBillCycleDay))
                ) && 
                (
                    this.ClassNS == input.ClassNS ||
                    (this.ClassNS != null &&
                    this.ClassNS.Equals(input.ClassNS))
                ) && 
                (
                    this.DeferredRevAccountNS == input.DeferredRevAccountNS ||
                    (this.DeferredRevAccountNS != null &&
                    this.DeferredRevAccountNS.Equals(input.DeferredRevAccountNS))
                ) && 
                (
                    this.DepartmentNS == input.DepartmentNS ||
                    (this.DepartmentNS != null &&
                    this.DepartmentNS.Equals(input.DepartmentNS))
                ) && 
                (
                    this.IncludeChildrenNS == input.IncludeChildrenNS ||
                    this.IncludeChildrenNS.Equals(input.IncludeChildrenNS)
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
                    this.ItemTypeNS == input.ItemTypeNS ||
                    this.ItemTypeNS.Equals(input.ItemTypeNS)
                ) && 
                (
                    this.LocationNS == input.LocationNS ||
                    (this.LocationNS != null &&
                    this.LocationNS.Equals(input.LocationNS))
                ) && 
                (
                    this.RecognizedRevAccountNS == input.RecognizedRevAccountNS ||
                    (this.RecognizedRevAccountNS != null &&
                    this.RecognizedRevAccountNS.Equals(input.RecognizedRevAccountNS))
                ) && 
                (
                    this.RevRecEndNS == input.RevRecEndNS ||
                    this.RevRecEndNS.Equals(input.RevRecEndNS)
                ) && 
                (
                    this.RevRecStartNS == input.RevRecStartNS ||
                    this.RevRecStartNS.Equals(input.RevRecStartNS)
                ) && 
                (
                    this.RevRecTemplateTypeNS == input.RevRecTemplateTypeNS ||
                    (this.RevRecTemplateTypeNS != null &&
                    this.RevRecTemplateTypeNS.Equals(input.RevRecTemplateTypeNS))
                ) && 
                (
                    this.SubsidiaryNS == input.SubsidiaryNS ||
                    (this.SubsidiaryNS != null &&
                    this.SubsidiaryNS.Equals(input.SubsidiaryNS))
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
                if (this.ApplyDiscountTo != null)
                {
                    hashCode = (hashCode * 59) + this.ApplyDiscountTo.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.BillCycleDay.GetHashCode();
                if (this.BillCycleType != null)
                {
                    hashCode = (hashCode * 59) + this.BillCycleType.GetHashCode();
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
                if (this.ChargeModel != null)
                {
                    hashCode = (hashCode * 59) + this.ChargeModel.GetHashCode();
                }
                if (this.ChargeType != null)
                {
                    hashCode = (hashCode * 59) + this.ChargeType.GetHashCode();
                }
                if (this.CreatedById != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedById.GetHashCode();
                }
                if (this.CreatedDate != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedDate.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.DefaultQuantity.GetHashCode();
                if (this.DeferredRevenueAccount != null)
                {
                    hashCode = (hashCode * 59) + this.DeferredRevenueAccount.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                if (this.DiscountLevel != null)
                {
                    hashCode = (hashCode * 59) + this.DiscountLevel.GetHashCode();
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
                hashCode = (hashCode * 59) + this.LegacyRevenueReporting.GetHashCode();
                if (this.ListPriceBase != null)
                {
                    hashCode = (hashCode * 59) + this.ListPriceBase.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.MaxQuantity.GetHashCode();
                hashCode = (hashCode * 59) + this.MinQuantity.GetHashCode();
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.NumberOfPeriod.GetHashCode();
                if (this.OverageCalculationOption != null)
                {
                    hashCode = (hashCode * 59) + this.OverageCalculationOption.GetHashCode();
                }
                if (this.OverageUnusedUnitsCreditOption != null)
                {
                    hashCode = (hashCode * 59) + this.OverageUnusedUnitsCreditOption.GetHashCode();
                }
                if (this.PriceChangeOption != null)
                {
                    hashCode = (hashCode * 59) + this.PriceChangeOption.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.PriceIncreasePercentage.GetHashCode();
                if (this.ProductRatePlanId != null)
                {
                    hashCode = (hashCode * 59) + this.ProductRatePlanId.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.RatingGroup.GetHashCode();
                if (this.RecognizedRevenueAccount != null)
                {
                    hashCode = (hashCode * 59) + this.RecognizedRevenueAccount.GetHashCode();
                }
                if (this.RevRecCode != null)
                {
                    hashCode = (hashCode * 59) + this.RevRecCode.GetHashCode();
                }
                if (this.RevRecTriggerCondition != null)
                {
                    hashCode = (hashCode * 59) + this.RevRecTriggerCondition.GetHashCode();
                }
                if (this.RevenueRecognitionRuleName != null)
                {
                    hashCode = (hashCode * 59) + this.RevenueRecognitionRuleName.GetHashCode();
                }
                if (this.SmoothingModel != null)
                {
                    hashCode = (hashCode * 59) + this.SmoothingModel.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.SpecificBillingPeriod.GetHashCode();
                if (this.TaxCode != null)
                {
                    hashCode = (hashCode * 59) + this.TaxCode.GetHashCode();
                }
                if (this.TaxMode != null)
                {
                    hashCode = (hashCode * 59) + this.TaxMode.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Taxable.GetHashCode();
                if (this.TriggerEvent != null)
                {
                    hashCode = (hashCode * 59) + this.TriggerEvent.GetHashCode();
                }
                if (this.UOM != null)
                {
                    hashCode = (hashCode * 59) + this.UOM.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.UpToPeriods.GetHashCode();
                if (this.UpToPeriodsType != null)
                {
                    hashCode = (hashCode * 59) + this.UpToPeriodsType.GetHashCode();
                }
                if (this.UpdatedById != null)
                {
                    hashCode = (hashCode * 59) + this.UpdatedById.GetHashCode();
                }
                if (this.UpdatedDate != null)
                {
                    hashCode = (hashCode * 59) + this.UpdatedDate.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.UseDiscountSpecificAccountingCode.GetHashCode();
                hashCode = (hashCode * 59) + this.UseTenantDefaultForPriceChange.GetHashCode();
                if (this.WeeklyBillCycleDay != null)
                {
                    hashCode = (hashCode * 59) + this.WeeklyBillCycleDay.GetHashCode();
                }
                if (this.ClassNS != null)
                {
                    hashCode = (hashCode * 59) + this.ClassNS.GetHashCode();
                }
                if (this.DeferredRevAccountNS != null)
                {
                    hashCode = (hashCode * 59) + this.DeferredRevAccountNS.GetHashCode();
                }
                if (this.DepartmentNS != null)
                {
                    hashCode = (hashCode * 59) + this.DepartmentNS.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.IncludeChildrenNS.GetHashCode();
                if (this.IntegrationIdNS != null)
                {
                    hashCode = (hashCode * 59) + this.IntegrationIdNS.GetHashCode();
                }
                if (this.IntegrationStatusNS != null)
                {
                    hashCode = (hashCode * 59) + this.IntegrationStatusNS.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.ItemTypeNS.GetHashCode();
                if (this.LocationNS != null)
                {
                    hashCode = (hashCode * 59) + this.LocationNS.GetHashCode();
                }
                if (this.RecognizedRevAccountNS != null)
                {
                    hashCode = (hashCode * 59) + this.RecognizedRevAccountNS.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.RevRecEndNS.GetHashCode();
                hashCode = (hashCode * 59) + this.RevRecStartNS.GetHashCode();
                if (this.RevRecTemplateTypeNS != null)
                {
                    hashCode = (hashCode * 59) + this.RevRecTemplateTypeNS.GetHashCode();
                }
                if (this.SubsidiaryNS != null)
                {
                    hashCode = (hashCode * 59) + this.SubsidiaryNS.GetHashCode();
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
            // ClassNS (string) maxLength
            if (this.ClassNS != null && this.ClassNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for ClassNS, length must be less than 255.", new [] { "ClassNS" });
            }

            // DeferredRevAccountNS (string) maxLength
            if (this.DeferredRevAccountNS != null && this.DeferredRevAccountNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for DeferredRevAccountNS, length must be less than 255.", new [] { "DeferredRevAccountNS" });
            }

            // DepartmentNS (string) maxLength
            if (this.DepartmentNS != null && this.DepartmentNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for DepartmentNS, length must be less than 255.", new [] { "DepartmentNS" });
            }

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

            // LocationNS (string) maxLength
            if (this.LocationNS != null && this.LocationNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for LocationNS, length must be less than 255.", new [] { "LocationNS" });
            }

            // RecognizedRevAccountNS (string) maxLength
            if (this.RecognizedRevAccountNS != null && this.RecognizedRevAccountNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for RecognizedRevAccountNS, length must be less than 255.", new [] { "RecognizedRevAccountNS" });
            }

            // RevRecTemplateTypeNS (string) maxLength
            if (this.RevRecTemplateTypeNS != null && this.RevRecTemplateTypeNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for RevRecTemplateTypeNS, length must be less than 255.", new [] { "RevRecTemplateTypeNS" });
            }

            // SubsidiaryNS (string) maxLength
            if (this.SubsidiaryNS != null && this.SubsidiaryNS.Length > 255)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for SubsidiaryNS, length must be less than 255.", new [] { "SubsidiaryNS" });
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
