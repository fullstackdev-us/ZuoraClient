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
    /// ProxyModifyPaymentMethod
    /// </summary>
    [DataContract(Name = "ProxyModifyPaymentMethod")]
    public partial class ProxyModifyPaymentMethod : IEquatable<ProxyModifyPaymentMethod>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyModifyPaymentMethod" /> class.
        /// </summary>
        /// <param name="accountId"> The ID of the customer account associated with this payment method.  **Note:** If a payment method was created without an account ID associated, you can update the payment method to specify an account ID in this operation. However, if a payment method is already associated with a customer account, you cannot update the payment method to associate it with another account ID. You cannot remove the previous account ID and leave the &#x60;AccountId&#x60; filed empty in this operation. .</param>
        /// <param name="achAbaCode"> The nine-digit routing number or ABA number used by banks. Use this field for ACH payment methods.  **Character limit**: 9 **Values**: a string of 9 characters or fewer .</param>
        /// <param name="achAccountName"> The name of the account holder, which can be either a person or a company. Use this field for ACH payment methods.  **Character limit**: 70 **Values**: a string of 70 characters or fewer .</param>
        /// <param name="achAccountType"> The type of bank account associated with the ACH payment. Use this field for ACH payment methods. When creating an ACH payment method on Adyen, this field is required by Zuora but it is not required by Adyen. To create the ACH payment method successfully, specify a real value for this field if you can. If it is not possible to get the real value for it, specify any of the allowed values as a dummy value, &#x60;Checking&#x60; preferably.  **Character limit**: 16 **Values**:  - &#x60;BusinessChecking&#x60; - &#x60;BusinessSaving&#x60; - &#x60;Checking&#x60; - &#x60;Saving&#x60; .</param>
        /// <param name="achAddress1"> Line 1 for the ACH address. Required on create for the Vantiv payment gateway. Optional for other gateways.  **Character limit:** **Values:** an address .</param>
        /// <param name="achAddress2"> Line 2 for the ACH address. Required on create for the Vantiv payment gateway. Optional for other gateways.  **Character limit:** **Values:** an address .</param>
        /// <param name="achBankName"> The name of the bank where the ACH payment account is held. Use this field for ACH payment methods. When creating an ACH payment method on Adyen, this field is required by Zuora but it is not required by Adyen. To create the ACH payment method successfully, specify a real value for this field if you can. If it is not possible to get the real value for it, specify a dummy value.  **Character limit**: 70 **Values**: a string of 70 characters or fewer .</param>
        /// <param name="achCity">The city of the ACH address. Use this field for ACH payment methods. **Note**: This field is only specific to the NMI payment gateway. **Character limit**: 40 **Values**: a string of 40 characters or fewer .</param>
        /// <param name="achCountry">The country of the ACH address. See [Country Names and Their ISO Standard 2- and 3-Digit Codes](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Country%2C_State%2C_and_Province_Codes/A_Country_Names_and_Their_ISO_Codes) for the list of supported country names. Use this field for ACH methods. **Note**: This field is only specific to the NMI payment gateway.  **Character limit**: 44 **Values**: a supported country name .</param>
        /// <param name="achPostalCode">The billing address&#39;s zip code. This field is required only when you define an ACH payment method. **Note**: This field is only specific to the NMI payment gateway.  **Character limit**: 20 **Values**: a string of 40 characters or fewer .</param>
        /// <param name="achState">The billing address&#39;s state. Use this field is if the &#x60;ACHCountry&#x60; value is either &#x60;Canada&#x60; or the &#x60;US&#x60;. State names must be spelled in full. For more information, see the list of [supported state names](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Country%2C_State%2C_and_Province_Codes/B_State_Names_and_2-Digit_Codes). This field is required only when you define an ACH payment method. **Note**: This field is only specific to the NMI payment gateway.  **Character limit**: 50 **Values**: a valid state name .</param>
        /// <param name="bankBranchCode">The branch code of the bank used for direct debit. Use this field for the following bank transfer payment methods:   - Sweden Direct Debit (&#x60;Autogiro&#x60;)   - Direct Debit NZ (&#x60;DirectDebitNZ&#x60;)   - Pre-Authorized Debit (&#x60;PAD&#x60;)  **Character limit**: 10 .</param>
        /// <param name="bankCheckDigit">The check digit in the international bank account number, which confirms the validity of the account. Use this field for direct debit payment methods.  **Character limit**: 4 **Values**:  string of 4 characters or fewer .</param>
        /// <param name="bankCode">The sort code or number that identifies the bank. This is also known as the sort code. Use this field for the following bank transfer payment methods:   - Direct Debit UK (&#x60;Bacs&#x60;)   - Denmark Direct Debit (&#x60;Betalingsservice&#x60;)   - Direct Debit NZ (&#x60;DirectDebitNZ&#x60;)   - Pre-Authorized Debit (&#x60;PAD&#x60;) .</param>
        /// <param name="bankTransferType">The type of direct debit transfer. The value of this field is dependent on the country of the user. This field is only required if the &#x60;Type&#x60; field is set to &#x60;BankTransfer&#x60;.  **Values**:     - &#x60;SEPA&#x60;    - &#x60;DirectEntryAU&#x60; (Australia)    - &#x60;DirectDebitUK&#x60; (UK)    - &#x60;Autogiro&#x60; (Sweden)    - &#x60;Betalingsservice&#x60; (Denmark)    - &#x60;DirectDebitNZ&#x60; (New Zealand)      - &#x60;PAD&#x60; (Canada)       - &#x60;AutomatischIncasso&#x60; (Netherlands)    - &#x60;LastschriftDE&#x60; (Germany)    - &#x60;LastschriftAT&#x60; (Austria)    - &#x60;DemandeDePrelevement&#x60; (France)    - &#x60;Domicil&#x60; (Belgium)    - &#x60;LastschriftCH&#x60; (Switzerland)    - &#x60;RID&#x60; (Italy)    - &#x60;OrdenDeDomiciliacion&#x60; (Spain) .</param>
        /// <param name="businessIdentificationCode"> The business identification code for Swiss direct payment methods that use the Global Collect payment gateway. Use this field only for direct debit payments in Switzerland with Global Collect.  **Character limit**: 11 **Values**: string of 11 characters or fewer .</param>
        /// <param name="city"> The city of the customer&#39;s address. Use this field for direct debit payment methods.  **Character limit**:80 **Values**:  string of 80 characters or fewer .</param>
        /// <param name="companyName">The name of the company.  Zuora does not recommend that you use this field. .</param>
        /// <param name="country">The two-letter country code of the customer&#39;s address. Use this field for the following bank transfer payment methods:   - &#x60;Autogiro&#x60;   - &#x60;Betalingsservice&#x60;   - &#x60;DirectDebitUK&#x60;   - &#x60;DirectEntryAU&#x60;   - &#x60;DirectDebitNZ&#x60;   - &#x60;PAD&#x60; .</param>
        /// <param name="creditCardAddress1"> The first line of the card holder&#39;s address, which is often a street address or business name. Use this field for credit card and direct debit payment methods.  **Character limit**: 255 **Values**: a string of 255 characters or fewer .</param>
        /// <param name="creditCardAddress2"> The second line of the card holder&#39;s address. Use this field for credit card and direct debit payment methods.  **Character limit**: 255 **Values**: a string of 255 characters or fewer .</param>
        /// <param name="creditCardCity"> The city of the card holder&#39;s address. Use this field for credit card and direct debit payment methods  **Character limit**: 40 **Values**: a string of 40 characters or fewer .</param>
        /// <param name="creditCardCountry"> The country of the card holder&#39;s address. .</param>
        /// <param name="creditCardExpirationMonth"> The expiration month of the credit card or debit card. Use this field for credit card and direct debit payment methods.  **Character limit**: 2 **Values**: a two-digit number, 01 - 12 .</param>
        /// <param name="creditCardExpirationYear"> The expiration month of the credit card or debit card. Use this field for credit card and direct debit payment methods.  **Character limit**: 4 **Values**: a four-digit number .</param>
        /// <param name="creditCardHolderName"> The full name of the card holder. Use this field for credit card and direct debit payment methods.  **Character limit**: 50 **Values**: a string of 50 characters or fewer .</param>
        /// <param name="creditCardPostalCode"> The billing address&#39;s zip code. This field is required only when you define a debit card or credit card payment. **Character limit**: 20 **Values**: a string of 20 characters or fewer .</param>
        /// <param name="creditCardSecurityCode"> The CVV or CVV2 security code. See [How do I control what information Zuora sends over to the Payment Gateway?](https://knowledgecenter.zuora.com/kb/How_do_I_control_information_sent_to_payment_gateways_when_verifying_payment_methods%3F) for more information. To ensure PCI compliance, this value is not stored and cannot be queried. **Values**: a valid CVV or CVV2 security code .</param>
        /// <param name="creditCardState"> The billing address&#39;s state. Use this field is if the &#x60;CreditCardCountry&#39; value is either Canada or the US. State names must be spelled in full. .</param>
        /// <param name="creditCardType">The type of the credit card.  Possible values  include &#x60;Visa&#x60;, &#x60;MasterCard&#x60;, &#x60;AmericanExpress&#x60;, &#x60;Discover&#x60;, &#x60;JCB&#x60;, and &#x60;Diners&#x60;. For more information about credit card types supported by different payment gateways, see [Supported Payment Gateways](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways). .</param>
        /// <param name="deviceSessionId"> The session ID of the user when the &#x60;PaymentMethod&#x60; was created or updated. Some gateways use this field for fraud prevention. If this field is passed to Zuora, then Zuora passes this field to supported gateways. Currently only Verifi supports this field. **Character limit**: 255 **Values**: .</param>
        /// <param name="email"> An email address for the payment method in addition to the bill to contact email address. **Character limit**: 80 **Values**: a string of 80 characters or fewer .</param>
        /// <param name="existingMandate"> Indicates if the customer has an existing mandate or a new mandate. A mandate is a signed authorization for UK and NL customers. When you are migrating mandates from another system, be sure to set this field correctly. If you indicate that a new mandate is an existing mandate or vice-versa, then transactions fail. This field is used only for the direct debit payment method. **Character limit**: 3 **Values**: &#x60;Yes&#x60;, &#x60;No&#x60; .</param>
        /// <param name="firstName"> The customer&#39;s first name. This field is used only for the direct debit payment method. **Character limit**: 30 **Values**: a string of 30 characters or fewer .</param>
        /// <param name="iBAN"> The International Bank Account Number. This field is used only for the direct debit payment method. **Character limit**: 42 **Values**: a string of 42 characters or fewer .</param>
        /// <param name="iPAddress"> The IP address of the user when the payment method was created or updated. Some gateways use this field for fraud prevention. If this field is passed to Zuora, then Zuora passes this field to supported gateways. Currently PayPal, CyberSource, Authorize.Net, Verifi, and WorldPay support this field. **Character limit**: 15 **Values**: a string of 15 characters or fewer .</param>
        /// <param name="identityNumber">The unique identity number of the customer account.   This field is required only if the &#x60;BankTransferType&#x60; field is set to &#x60;Autogiro&#x60; or &#x60;Betalingsservice&#x60;. It is a string of 12 characters for a Swedish identity number, and a string of 10 characters for a Denish identity number. .</param>
        /// <param name="isCompany">Whether the customer account is a company.  Zuora does not recommend that you use this field.  (default to false).</param>
        /// <param name="lastName"> The customer&#39;s last name. This field is used only for the direct debit payment method. **Character limit**: 70 **Values**: a string of 70 characters or fewer .</param>
        /// <param name="lastTransactionDateTime"> The date of the most recent transaction. **Character limit**: 29 **Values**: a valid date and time value .</param>
        /// <param name="mandateCreationDate"> The date when the mandate was created, in &#x60;yyyy-mm-dd&#x60; format. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 29 .</param>
        /// <param name="mandateID"> The ID of the mandate. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 36 **Values**: a string of 36 characters or fewer .</param>
        /// <param name="mandateReceived"> Indicates if  the mandate was received. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 3 **Values**: &#x60;Yes&#x60;, &#x60;No &#x60;(case-sensitive) .</param>
        /// <param name="mandateUpdateDate"> The date when the mandate was last updated, in &#x60;yyyy-mm-dd&#x60; format. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 29 .</param>
        /// <param name="maxConsecutivePaymentFailures"> Specifies the number of allowable consecutive failures Zuora attempts with the payment method before stopping. **Values**: a valid number .</param>
        /// <param name="numConsecutiveFailures">The number of consecutive failed payments for this payment method. It is reset to &#x60;0&#x60; upon successful payment.  .</param>
        /// <param name="paymentMethodStatus"> This field is used to indicate the status of the payment method created within an account. It is set to &#x60;Active&#x60; on creation. **Character limit**: 6 **Values**: &#x60;Active&#x60; or &#x60;Closed&#x60; .</param>
        /// <param name="paymentRetryWindow"> The retry interval setting, which prevents making a payment attempt if the last failed attempt was within the last specified number of hours. This field is required if the &#x60;UseDefaultRetryRule&#x60; field value is set to &#x60;false&#x60;. **Character limit**: 4 **Values**: a whole number between 1 and 1000, exclusive .</param>
        /// <param name="phone"> The phone number that the account holder registered with the bank. This field is used for credit card validation when passing to a gateway. **Character limit**: 40 **Values**: a string of 40 characters or fewer .</param>
        /// <param name="postalCode"> The zip code of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 20 **Values**: a string of 20 characters or fewer .</param>
        /// <param name="secondTokenId">A gateway unique identifier that replaces sensitive payment method data. &#x60;SecondTokenId&#x60; is conditionally required only when &#x60;TokenId&#x60; is being used to represent a gateway customer profile. &#x60;TokenID&#x60; is being used to represent a gateway customer profile. &#x60;SecondTokenId&#x60; is used in the CC Reference Transaction payment method. **Character limit**: 64 **Values**: a string of 64 characters or fewer .</param>
        /// <param name="state"> The state of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 70 **Values**: a string of 70 characters or fewer .</param>
        /// <param name="streetName"> The street name of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 100 **Values**: a string of 100 characters or fewer .</param>
        /// <param name="streetNumber"> The street number of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 30 **Values**: a string of 30 characters or fewer .</param>
        /// <param name="useDefaultRetryRule"> Determines whether to use the default retry rules configured in the Zuora Payments settings. Set this to &#x60;true&#x60; to use the default retry rules. Set this to &#x60;false&#x60; to set the specific rules for this payment method. If you set this value to &#x60;false&#x60;, then the fields, &#x60;PaymentRetryWindow&#x60; and &#x60;MaxConsecutivePaymentFailures&#x60;, are required. **Character limit**: 5 **Values**: &#x60;true&#x60; or &#x60;false&#x60; .</param>
        public ProxyModifyPaymentMethod(string accountId = default(string), string achAbaCode = default(string), string achAccountName = default(string), string achAccountType = default(string), string achAddress1 = default(string), string achAddress2 = default(string), string achBankName = default(string), string achCity = default(string), string achCountry = default(string), string achPostalCode = default(string), string achState = default(string), string bankBranchCode = default(string), string bankCheckDigit = default(string), string bankCode = default(string), string bankTransferType = default(string), string businessIdentificationCode = default(string), string city = default(string), string companyName = default(string), string country = default(string), string creditCardAddress1 = default(string), string creditCardAddress2 = default(string), string creditCardCity = default(string), string creditCardCountry = default(string), int creditCardExpirationMonth = default(int), int creditCardExpirationYear = default(int), string creditCardHolderName = default(string), string creditCardPostalCode = default(string), string creditCardSecurityCode = default(string), string creditCardState = default(string), string creditCardType = default(string), string deviceSessionId = default(string), string email = default(string), string existingMandate = default(string), string firstName = default(string), string iBAN = default(string), string iPAddress = default(string), string identityNumber = default(string), bool isCompany = false, string lastName = default(string), DateTime lastTransactionDateTime = default(DateTime), DateTime mandateCreationDate = default(DateTime), string mandateID = default(string), string mandateReceived = default(string), DateTime mandateUpdateDate = default(DateTime), int maxConsecutivePaymentFailures = default(int), int numConsecutiveFailures = default(int), string paymentMethodStatus = default(string), int paymentRetryWindow = default(int), string phone = default(string), string postalCode = default(string), string secondTokenId = default(string), string state = default(string), string streetName = default(string), string streetNumber = default(string), bool useDefaultRetryRule = default(bool))
        {
            this.AccountId = accountId;
            this.AchAbaCode = achAbaCode;
            this.AchAccountName = achAccountName;
            this.AchAccountType = achAccountType;
            this.AchAddress1 = achAddress1;
            this.AchAddress2 = achAddress2;
            this.AchBankName = achBankName;
            this.AchCity = achCity;
            this.AchCountry = achCountry;
            this.AchPostalCode = achPostalCode;
            this.AchState = achState;
            this.BankBranchCode = bankBranchCode;
            this.BankCheckDigit = bankCheckDigit;
            this.BankCode = bankCode;
            this.BankTransferType = bankTransferType;
            this.BusinessIdentificationCode = businessIdentificationCode;
            this.City = city;
            this.CompanyName = companyName;
            this.Country = country;
            this.CreditCardAddress1 = creditCardAddress1;
            this.CreditCardAddress2 = creditCardAddress2;
            this.CreditCardCity = creditCardCity;
            this.CreditCardCountry = creditCardCountry;
            this.CreditCardExpirationMonth = creditCardExpirationMonth;
            this.CreditCardExpirationYear = creditCardExpirationYear;
            this.CreditCardHolderName = creditCardHolderName;
            this.CreditCardPostalCode = creditCardPostalCode;
            this.CreditCardSecurityCode = creditCardSecurityCode;
            this.CreditCardState = creditCardState;
            this.CreditCardType = creditCardType;
            this.DeviceSessionId = deviceSessionId;
            this.Email = email;
            this.ExistingMandate = existingMandate;
            this.FirstName = firstName;
            this.IBAN = iBAN;
            this.IPAddress = iPAddress;
            this.IdentityNumber = identityNumber;
            this.IsCompany = isCompany;
            this.LastName = lastName;
            this.LastTransactionDateTime = lastTransactionDateTime;
            this.MandateCreationDate = mandateCreationDate;
            this.MandateID = mandateID;
            this.MandateReceived = mandateReceived;
            this.MandateUpdateDate = mandateUpdateDate;
            this.MaxConsecutivePaymentFailures = maxConsecutivePaymentFailures;
            this.NumConsecutiveFailures = numConsecutiveFailures;
            this.PaymentMethodStatus = paymentMethodStatus;
            this.PaymentRetryWindow = paymentRetryWindow;
            this.Phone = phone;
            this.PostalCode = postalCode;
            this.SecondTokenId = secondTokenId;
            this.State = state;
            this.StreetName = streetName;
            this.StreetNumber = streetNumber;
            this.UseDefaultRetryRule = useDefaultRetryRule;
        }

        /// <summary>
        ///  The ID of the customer account associated with this payment method.  **Note:** If a payment method was created without an account ID associated, you can update the payment method to specify an account ID in this operation. However, if a payment method is already associated with a customer account, you cannot update the payment method to associate it with another account ID. You cannot remove the previous account ID and leave the &#x60;AccountId&#x60; filed empty in this operation. 
        /// </summary>
        /// <value> The ID of the customer account associated with this payment method.  **Note:** If a payment method was created without an account ID associated, you can update the payment method to specify an account ID in this operation. However, if a payment method is already associated with a customer account, you cannot update the payment method to associate it with another account ID. You cannot remove the previous account ID and leave the &#x60;AccountId&#x60; filed empty in this operation. </value>
        [DataMember(Name = "AccountId", EmitDefaultValue = false)]
        public string AccountId { get; set; }

        /// <summary>
        ///  The nine-digit routing number or ABA number used by banks. Use this field for ACH payment methods.  **Character limit**: 9 **Values**: a string of 9 characters or fewer 
        /// </summary>
        /// <value> The nine-digit routing number or ABA number used by banks. Use this field for ACH payment methods.  **Character limit**: 9 **Values**: a string of 9 characters or fewer </value>
        [DataMember(Name = "AchAbaCode", EmitDefaultValue = false)]
        public string AchAbaCode { get; set; }

        /// <summary>
        ///  The name of the account holder, which can be either a person or a company. Use this field for ACH payment methods.  **Character limit**: 70 **Values**: a string of 70 characters or fewer 
        /// </summary>
        /// <value> The name of the account holder, which can be either a person or a company. Use this field for ACH payment methods.  **Character limit**: 70 **Values**: a string of 70 characters or fewer </value>
        [DataMember(Name = "AchAccountName", EmitDefaultValue = false)]
        public string AchAccountName { get; set; }

        /// <summary>
        ///  The type of bank account associated with the ACH payment. Use this field for ACH payment methods. When creating an ACH payment method on Adyen, this field is required by Zuora but it is not required by Adyen. To create the ACH payment method successfully, specify a real value for this field if you can. If it is not possible to get the real value for it, specify any of the allowed values as a dummy value, &#x60;Checking&#x60; preferably.  **Character limit**: 16 **Values**:  - &#x60;BusinessChecking&#x60; - &#x60;BusinessSaving&#x60; - &#x60;Checking&#x60; - &#x60;Saving&#x60; 
        /// </summary>
        /// <value> The type of bank account associated with the ACH payment. Use this field for ACH payment methods. When creating an ACH payment method on Adyen, this field is required by Zuora but it is not required by Adyen. To create the ACH payment method successfully, specify a real value for this field if you can. If it is not possible to get the real value for it, specify any of the allowed values as a dummy value, &#x60;Checking&#x60; preferably.  **Character limit**: 16 **Values**:  - &#x60;BusinessChecking&#x60; - &#x60;BusinessSaving&#x60; - &#x60;Checking&#x60; - &#x60;Saving&#x60; </value>
        [DataMember(Name = "AchAccountType", EmitDefaultValue = false)]
        public string AchAccountType { get; set; }

        /// <summary>
        ///  Line 1 for the ACH address. Required on create for the Vantiv payment gateway. Optional for other gateways.  **Character limit:** **Values:** an address 
        /// </summary>
        /// <value> Line 1 for the ACH address. Required on create for the Vantiv payment gateway. Optional for other gateways.  **Character limit:** **Values:** an address </value>
        [DataMember(Name = "AchAddress1", EmitDefaultValue = false)]
        public string AchAddress1 { get; set; }

        /// <summary>
        ///  Line 2 for the ACH address. Required on create for the Vantiv payment gateway. Optional for other gateways.  **Character limit:** **Values:** an address 
        /// </summary>
        /// <value> Line 2 for the ACH address. Required on create for the Vantiv payment gateway. Optional for other gateways.  **Character limit:** **Values:** an address </value>
        [DataMember(Name = "AchAddress2", EmitDefaultValue = false)]
        public string AchAddress2 { get; set; }

        /// <summary>
        ///  The name of the bank where the ACH payment account is held. Use this field for ACH payment methods. When creating an ACH payment method on Adyen, this field is required by Zuora but it is not required by Adyen. To create the ACH payment method successfully, specify a real value for this field if you can. If it is not possible to get the real value for it, specify a dummy value.  **Character limit**: 70 **Values**: a string of 70 characters or fewer 
        /// </summary>
        /// <value> The name of the bank where the ACH payment account is held. Use this field for ACH payment methods. When creating an ACH payment method on Adyen, this field is required by Zuora but it is not required by Adyen. To create the ACH payment method successfully, specify a real value for this field if you can. If it is not possible to get the real value for it, specify a dummy value.  **Character limit**: 70 **Values**: a string of 70 characters or fewer </value>
        [DataMember(Name = "AchBankName", EmitDefaultValue = false)]
        public string AchBankName { get; set; }

        /// <summary>
        /// The city of the ACH address. Use this field for ACH payment methods. **Note**: This field is only specific to the NMI payment gateway. **Character limit**: 40 **Values**: a string of 40 characters or fewer 
        /// </summary>
        /// <value>The city of the ACH address. Use this field for ACH payment methods. **Note**: This field is only specific to the NMI payment gateway. **Character limit**: 40 **Values**: a string of 40 characters or fewer </value>
        [DataMember(Name = "AchCity", EmitDefaultValue = false)]
        public string AchCity { get; set; }

        /// <summary>
        /// The country of the ACH address. See [Country Names and Their ISO Standard 2- and 3-Digit Codes](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Country%2C_State%2C_and_Province_Codes/A_Country_Names_and_Their_ISO_Codes) for the list of supported country names. Use this field for ACH methods. **Note**: This field is only specific to the NMI payment gateway.  **Character limit**: 44 **Values**: a supported country name 
        /// </summary>
        /// <value>The country of the ACH address. See [Country Names and Their ISO Standard 2- and 3-Digit Codes](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Country%2C_State%2C_and_Province_Codes/A_Country_Names_and_Their_ISO_Codes) for the list of supported country names. Use this field for ACH methods. **Note**: This field is only specific to the NMI payment gateway.  **Character limit**: 44 **Values**: a supported country name </value>
        [DataMember(Name = "AchCountry", EmitDefaultValue = false)]
        public string AchCountry { get; set; }

        /// <summary>
        /// The billing address&#39;s zip code. This field is required only when you define an ACH payment method. **Note**: This field is only specific to the NMI payment gateway.  **Character limit**: 20 **Values**: a string of 40 characters or fewer 
        /// </summary>
        /// <value>The billing address&#39;s zip code. This field is required only when you define an ACH payment method. **Note**: This field is only specific to the NMI payment gateway.  **Character limit**: 20 **Values**: a string of 40 characters or fewer </value>
        [DataMember(Name = "AchPostalCode", EmitDefaultValue = false)]
        public string AchPostalCode { get; set; }

        /// <summary>
        /// The billing address&#39;s state. Use this field is if the &#x60;ACHCountry&#x60; value is either &#x60;Canada&#x60; or the &#x60;US&#x60;. State names must be spelled in full. For more information, see the list of [supported state names](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Country%2C_State%2C_and_Province_Codes/B_State_Names_and_2-Digit_Codes). This field is required only when you define an ACH payment method. **Note**: This field is only specific to the NMI payment gateway.  **Character limit**: 50 **Values**: a valid state name 
        /// </summary>
        /// <value>The billing address&#39;s state. Use this field is if the &#x60;ACHCountry&#x60; value is either &#x60;Canada&#x60; or the &#x60;US&#x60;. State names must be spelled in full. For more information, see the list of [supported state names](https://knowledgecenter.zuora.com/BB_Introducing_Z_Business/D_Country%2C_State%2C_and_Province_Codes/B_State_Names_and_2-Digit_Codes). This field is required only when you define an ACH payment method. **Note**: This field is only specific to the NMI payment gateway.  **Character limit**: 50 **Values**: a valid state name </value>
        [DataMember(Name = "AchState", EmitDefaultValue = false)]
        public string AchState { get; set; }

        /// <summary>
        /// The branch code of the bank used for direct debit. Use this field for the following bank transfer payment methods:   - Sweden Direct Debit (&#x60;Autogiro&#x60;)   - Direct Debit NZ (&#x60;DirectDebitNZ&#x60;)   - Pre-Authorized Debit (&#x60;PAD&#x60;)  **Character limit**: 10 
        /// </summary>
        /// <value>The branch code of the bank used for direct debit. Use this field for the following bank transfer payment methods:   - Sweden Direct Debit (&#x60;Autogiro&#x60;)   - Direct Debit NZ (&#x60;DirectDebitNZ&#x60;)   - Pre-Authorized Debit (&#x60;PAD&#x60;)  **Character limit**: 10 </value>
        [DataMember(Name = "BankBranchCode", EmitDefaultValue = false)]
        public string BankBranchCode { get; set; }

        /// <summary>
        /// The check digit in the international bank account number, which confirms the validity of the account. Use this field for direct debit payment methods.  **Character limit**: 4 **Values**:  string of 4 characters or fewer 
        /// </summary>
        /// <value>The check digit in the international bank account number, which confirms the validity of the account. Use this field for direct debit payment methods.  **Character limit**: 4 **Values**:  string of 4 characters or fewer </value>
        [DataMember(Name = "BankCheckDigit", EmitDefaultValue = false)]
        public string BankCheckDigit { get; set; }

        /// <summary>
        /// The sort code or number that identifies the bank. This is also known as the sort code. Use this field for the following bank transfer payment methods:   - Direct Debit UK (&#x60;Bacs&#x60;)   - Denmark Direct Debit (&#x60;Betalingsservice&#x60;)   - Direct Debit NZ (&#x60;DirectDebitNZ&#x60;)   - Pre-Authorized Debit (&#x60;PAD&#x60;) 
        /// </summary>
        /// <value>The sort code or number that identifies the bank. This is also known as the sort code. Use this field for the following bank transfer payment methods:   - Direct Debit UK (&#x60;Bacs&#x60;)   - Denmark Direct Debit (&#x60;Betalingsservice&#x60;)   - Direct Debit NZ (&#x60;DirectDebitNZ&#x60;)   - Pre-Authorized Debit (&#x60;PAD&#x60;) </value>
        [DataMember(Name = "BankCode", EmitDefaultValue = false)]
        public string BankCode { get; set; }

        /// <summary>
        /// The type of direct debit transfer. The value of this field is dependent on the country of the user. This field is only required if the &#x60;Type&#x60; field is set to &#x60;BankTransfer&#x60;.  **Values**:     - &#x60;SEPA&#x60;    - &#x60;DirectEntryAU&#x60; (Australia)    - &#x60;DirectDebitUK&#x60; (UK)    - &#x60;Autogiro&#x60; (Sweden)    - &#x60;Betalingsservice&#x60; (Denmark)    - &#x60;DirectDebitNZ&#x60; (New Zealand)      - &#x60;PAD&#x60; (Canada)       - &#x60;AutomatischIncasso&#x60; (Netherlands)    - &#x60;LastschriftDE&#x60; (Germany)    - &#x60;LastschriftAT&#x60; (Austria)    - &#x60;DemandeDePrelevement&#x60; (France)    - &#x60;Domicil&#x60; (Belgium)    - &#x60;LastschriftCH&#x60; (Switzerland)    - &#x60;RID&#x60; (Italy)    - &#x60;OrdenDeDomiciliacion&#x60; (Spain) 
        /// </summary>
        /// <value>The type of direct debit transfer. The value of this field is dependent on the country of the user. This field is only required if the &#x60;Type&#x60; field is set to &#x60;BankTransfer&#x60;.  **Values**:     - &#x60;SEPA&#x60;    - &#x60;DirectEntryAU&#x60; (Australia)    - &#x60;DirectDebitUK&#x60; (UK)    - &#x60;Autogiro&#x60; (Sweden)    - &#x60;Betalingsservice&#x60; (Denmark)    - &#x60;DirectDebitNZ&#x60; (New Zealand)      - &#x60;PAD&#x60; (Canada)       - &#x60;AutomatischIncasso&#x60; (Netherlands)    - &#x60;LastschriftDE&#x60; (Germany)    - &#x60;LastschriftAT&#x60; (Austria)    - &#x60;DemandeDePrelevement&#x60; (France)    - &#x60;Domicil&#x60; (Belgium)    - &#x60;LastschriftCH&#x60; (Switzerland)    - &#x60;RID&#x60; (Italy)    - &#x60;OrdenDeDomiciliacion&#x60; (Spain) </value>
        [DataMember(Name = "BankTransferType", EmitDefaultValue = false)]
        public string BankTransferType { get; set; }

        /// <summary>
        ///  The business identification code for Swiss direct payment methods that use the Global Collect payment gateway. Use this field only for direct debit payments in Switzerland with Global Collect.  **Character limit**: 11 **Values**: string of 11 characters or fewer 
        /// </summary>
        /// <value> The business identification code for Swiss direct payment methods that use the Global Collect payment gateway. Use this field only for direct debit payments in Switzerland with Global Collect.  **Character limit**: 11 **Values**: string of 11 characters or fewer </value>
        [DataMember(Name = "BusinessIdentificationCode", EmitDefaultValue = false)]
        public string BusinessIdentificationCode { get; set; }

        /// <summary>
        ///  The city of the customer&#39;s address. Use this field for direct debit payment methods.  **Character limit**:80 **Values**:  string of 80 characters or fewer 
        /// </summary>
        /// <value> The city of the customer&#39;s address. Use this field for direct debit payment methods.  **Character limit**:80 **Values**:  string of 80 characters or fewer </value>
        [DataMember(Name = "City", EmitDefaultValue = false)]
        public string City { get; set; }

        /// <summary>
        /// The name of the company.  Zuora does not recommend that you use this field. 
        /// </summary>
        /// <value>The name of the company.  Zuora does not recommend that you use this field. </value>
        [DataMember(Name = "CompanyName", EmitDefaultValue = false)]
        public string CompanyName { get; set; }

        /// <summary>
        /// The two-letter country code of the customer&#39;s address. Use this field for the following bank transfer payment methods:   - &#x60;Autogiro&#x60;   - &#x60;Betalingsservice&#x60;   - &#x60;DirectDebitUK&#x60;   - &#x60;DirectEntryAU&#x60;   - &#x60;DirectDebitNZ&#x60;   - &#x60;PAD&#x60; 
        /// </summary>
        /// <value>The two-letter country code of the customer&#39;s address. Use this field for the following bank transfer payment methods:   - &#x60;Autogiro&#x60;   - &#x60;Betalingsservice&#x60;   - &#x60;DirectDebitUK&#x60;   - &#x60;DirectEntryAU&#x60;   - &#x60;DirectDebitNZ&#x60;   - &#x60;PAD&#x60; </value>
        [DataMember(Name = "Country", EmitDefaultValue = false)]
        public string Country { get; set; }

        /// <summary>
        ///  The first line of the card holder&#39;s address, which is often a street address or business name. Use this field for credit card and direct debit payment methods.  **Character limit**: 255 **Values**: a string of 255 characters or fewer 
        /// </summary>
        /// <value> The first line of the card holder&#39;s address, which is often a street address or business name. Use this field for credit card and direct debit payment methods.  **Character limit**: 255 **Values**: a string of 255 characters or fewer </value>
        [DataMember(Name = "CreditCardAddress1", EmitDefaultValue = false)]
        public string CreditCardAddress1 { get; set; }

        /// <summary>
        ///  The second line of the card holder&#39;s address. Use this field for credit card and direct debit payment methods.  **Character limit**: 255 **Values**: a string of 255 characters or fewer 
        /// </summary>
        /// <value> The second line of the card holder&#39;s address. Use this field for credit card and direct debit payment methods.  **Character limit**: 255 **Values**: a string of 255 characters or fewer </value>
        [DataMember(Name = "CreditCardAddress2", EmitDefaultValue = false)]
        public string CreditCardAddress2 { get; set; }

        /// <summary>
        ///  The city of the card holder&#39;s address. Use this field for credit card and direct debit payment methods  **Character limit**: 40 **Values**: a string of 40 characters or fewer 
        /// </summary>
        /// <value> The city of the card holder&#39;s address. Use this field for credit card and direct debit payment methods  **Character limit**: 40 **Values**: a string of 40 characters or fewer </value>
        [DataMember(Name = "CreditCardCity", EmitDefaultValue = false)]
        public string CreditCardCity { get; set; }

        /// <summary>
        ///  The country of the card holder&#39;s address. 
        /// </summary>
        /// <value> The country of the card holder&#39;s address. </value>
        [DataMember(Name = "CreditCardCountry", EmitDefaultValue = false)]
        public string CreditCardCountry { get; set; }

        /// <summary>
        ///  The expiration month of the credit card or debit card. Use this field for credit card and direct debit payment methods.  **Character limit**: 2 **Values**: a two-digit number, 01 - 12 
        /// </summary>
        /// <value> The expiration month of the credit card or debit card. Use this field for credit card and direct debit payment methods.  **Character limit**: 2 **Values**: a two-digit number, 01 - 12 </value>
        [DataMember(Name = "CreditCardExpirationMonth", EmitDefaultValue = false)]
        public int CreditCardExpirationMonth { get; set; }

        /// <summary>
        ///  The expiration month of the credit card or debit card. Use this field for credit card and direct debit payment methods.  **Character limit**: 4 **Values**: a four-digit number 
        /// </summary>
        /// <value> The expiration month of the credit card or debit card. Use this field for credit card and direct debit payment methods.  **Character limit**: 4 **Values**: a four-digit number </value>
        [DataMember(Name = "CreditCardExpirationYear", EmitDefaultValue = false)]
        public int CreditCardExpirationYear { get; set; }

        /// <summary>
        ///  The full name of the card holder. Use this field for credit card and direct debit payment methods.  **Character limit**: 50 **Values**: a string of 50 characters or fewer 
        /// </summary>
        /// <value> The full name of the card holder. Use this field for credit card and direct debit payment methods.  **Character limit**: 50 **Values**: a string of 50 characters or fewer </value>
        [DataMember(Name = "CreditCardHolderName", EmitDefaultValue = false)]
        public string CreditCardHolderName { get; set; }

        /// <summary>
        ///  The billing address&#39;s zip code. This field is required only when you define a debit card or credit card payment. **Character limit**: 20 **Values**: a string of 20 characters or fewer 
        /// </summary>
        /// <value> The billing address&#39;s zip code. This field is required only when you define a debit card or credit card payment. **Character limit**: 20 **Values**: a string of 20 characters or fewer </value>
        [DataMember(Name = "CreditCardPostalCode", EmitDefaultValue = false)]
        public string CreditCardPostalCode { get; set; }

        /// <summary>
        ///  The CVV or CVV2 security code. See [How do I control what information Zuora sends over to the Payment Gateway?](https://knowledgecenter.zuora.com/kb/How_do_I_control_information_sent_to_payment_gateways_when_verifying_payment_methods%3F) for more information. To ensure PCI compliance, this value is not stored and cannot be queried. **Values**: a valid CVV or CVV2 security code 
        /// </summary>
        /// <value> The CVV or CVV2 security code. See [How do I control what information Zuora sends over to the Payment Gateway?](https://knowledgecenter.zuora.com/kb/How_do_I_control_information_sent_to_payment_gateways_when_verifying_payment_methods%3F) for more information. To ensure PCI compliance, this value is not stored and cannot be queried. **Values**: a valid CVV or CVV2 security code </value>
        [DataMember(Name = "CreditCardSecurityCode", EmitDefaultValue = false)]
        public string CreditCardSecurityCode { get; set; }

        /// <summary>
        ///  The billing address&#39;s state. Use this field is if the &#x60;CreditCardCountry&#39; value is either Canada or the US. State names must be spelled in full. 
        /// </summary>
        /// <value> The billing address&#39;s state. Use this field is if the &#x60;CreditCardCountry&#39; value is either Canada or the US. State names must be spelled in full. </value>
        [DataMember(Name = "CreditCardState", EmitDefaultValue = false)]
        public string CreditCardState { get; set; }

        /// <summary>
        /// The type of the credit card.  Possible values  include &#x60;Visa&#x60;, &#x60;MasterCard&#x60;, &#x60;AmericanExpress&#x60;, &#x60;Discover&#x60;, &#x60;JCB&#x60;, and &#x60;Diners&#x60;. For more information about credit card types supported by different payment gateways, see [Supported Payment Gateways](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways). 
        /// </summary>
        /// <value>The type of the credit card.  Possible values  include &#x60;Visa&#x60;, &#x60;MasterCard&#x60;, &#x60;AmericanExpress&#x60;, &#x60;Discover&#x60;, &#x60;JCB&#x60;, and &#x60;Diners&#x60;. For more information about credit card types supported by different payment gateways, see [Supported Payment Gateways](https://knowledgecenter.zuora.com/CB_Billing/M_Payment_Gateways/Supported_Payment_Gateways). </value>
        [DataMember(Name = "CreditCardType", EmitDefaultValue = false)]
        public string CreditCardType { get; set; }

        /// <summary>
        ///  The session ID of the user when the &#x60;PaymentMethod&#x60; was created or updated. Some gateways use this field for fraud prevention. If this field is passed to Zuora, then Zuora passes this field to supported gateways. Currently only Verifi supports this field. **Character limit**: 255 **Values**: 
        /// </summary>
        /// <value> The session ID of the user when the &#x60;PaymentMethod&#x60; was created or updated. Some gateways use this field for fraud prevention. If this field is passed to Zuora, then Zuora passes this field to supported gateways. Currently only Verifi supports this field. **Character limit**: 255 **Values**: </value>
        [DataMember(Name = "DeviceSessionId", EmitDefaultValue = false)]
        public string DeviceSessionId { get; set; }

        /// <summary>
        ///  An email address for the payment method in addition to the bill to contact email address. **Character limit**: 80 **Values**: a string of 80 characters or fewer 
        /// </summary>
        /// <value> An email address for the payment method in addition to the bill to contact email address. **Character limit**: 80 **Values**: a string of 80 characters or fewer </value>
        [DataMember(Name = "Email", EmitDefaultValue = false)]
        public string Email { get; set; }

        /// <summary>
        ///  Indicates if the customer has an existing mandate or a new mandate. A mandate is a signed authorization for UK and NL customers. When you are migrating mandates from another system, be sure to set this field correctly. If you indicate that a new mandate is an existing mandate or vice-versa, then transactions fail. This field is used only for the direct debit payment method. **Character limit**: 3 **Values**: &#x60;Yes&#x60;, &#x60;No&#x60; 
        /// </summary>
        /// <value> Indicates if the customer has an existing mandate or a new mandate. A mandate is a signed authorization for UK and NL customers. When you are migrating mandates from another system, be sure to set this field correctly. If you indicate that a new mandate is an existing mandate or vice-versa, then transactions fail. This field is used only for the direct debit payment method. **Character limit**: 3 **Values**: &#x60;Yes&#x60;, &#x60;No&#x60; </value>
        [DataMember(Name = "ExistingMandate", EmitDefaultValue = false)]
        public string ExistingMandate { get; set; }

        /// <summary>
        ///  The customer&#39;s first name. This field is used only for the direct debit payment method. **Character limit**: 30 **Values**: a string of 30 characters or fewer 
        /// </summary>
        /// <value> The customer&#39;s first name. This field is used only for the direct debit payment method. **Character limit**: 30 **Values**: a string of 30 characters or fewer </value>
        [DataMember(Name = "FirstName", EmitDefaultValue = false)]
        public string FirstName { get; set; }

        /// <summary>
        ///  The International Bank Account Number. This field is used only for the direct debit payment method. **Character limit**: 42 **Values**: a string of 42 characters or fewer 
        /// </summary>
        /// <value> The International Bank Account Number. This field is used only for the direct debit payment method. **Character limit**: 42 **Values**: a string of 42 characters or fewer </value>
        [DataMember(Name = "IBAN", EmitDefaultValue = false)]
        public string IBAN { get; set; }

        /// <summary>
        ///  The IP address of the user when the payment method was created or updated. Some gateways use this field for fraud prevention. If this field is passed to Zuora, then Zuora passes this field to supported gateways. Currently PayPal, CyberSource, Authorize.Net, Verifi, and WorldPay support this field. **Character limit**: 15 **Values**: a string of 15 characters or fewer 
        /// </summary>
        /// <value> The IP address of the user when the payment method was created or updated. Some gateways use this field for fraud prevention. If this field is passed to Zuora, then Zuora passes this field to supported gateways. Currently PayPal, CyberSource, Authorize.Net, Verifi, and WorldPay support this field. **Character limit**: 15 **Values**: a string of 15 characters or fewer </value>
        [DataMember(Name = "IPAddress", EmitDefaultValue = false)]
        public string IPAddress { get; set; }

        /// <summary>
        /// The unique identity number of the customer account.   This field is required only if the &#x60;BankTransferType&#x60; field is set to &#x60;Autogiro&#x60; or &#x60;Betalingsservice&#x60;. It is a string of 12 characters for a Swedish identity number, and a string of 10 characters for a Denish identity number. 
        /// </summary>
        /// <value>The unique identity number of the customer account.   This field is required only if the &#x60;BankTransferType&#x60; field is set to &#x60;Autogiro&#x60; or &#x60;Betalingsservice&#x60;. It is a string of 12 characters for a Swedish identity number, and a string of 10 characters for a Denish identity number. </value>
        [DataMember(Name = "IdentityNumber", EmitDefaultValue = false)]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Whether the customer account is a company.  Zuora does not recommend that you use this field. 
        /// </summary>
        /// <value>Whether the customer account is a company.  Zuora does not recommend that you use this field. </value>
        [DataMember(Name = "IsCompany", EmitDefaultValue = true)]
        public bool IsCompany { get; set; }

        /// <summary>
        ///  The customer&#39;s last name. This field is used only for the direct debit payment method. **Character limit**: 70 **Values**: a string of 70 characters or fewer 
        /// </summary>
        /// <value> The customer&#39;s last name. This field is used only for the direct debit payment method. **Character limit**: 70 **Values**: a string of 70 characters or fewer </value>
        [DataMember(Name = "LastName", EmitDefaultValue = false)]
        public string LastName { get; set; }

        /// <summary>
        ///  The date of the most recent transaction. **Character limit**: 29 **Values**: a valid date and time value 
        /// </summary>
        /// <value> The date of the most recent transaction. **Character limit**: 29 **Values**: a valid date and time value </value>
        [DataMember(Name = "LastTransactionDateTime", EmitDefaultValue = false)]
        public DateTime LastTransactionDateTime { get; set; }

        /// <summary>
        ///  The date when the mandate was created, in &#x60;yyyy-mm-dd&#x60; format. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 29 
        /// </summary>
        /// <value> The date when the mandate was created, in &#x60;yyyy-mm-dd&#x60; format. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 29 </value>
        [DataMember(Name = "MandateCreationDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime MandateCreationDate { get; set; }

        /// <summary>
        ///  The ID of the mandate. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 36 **Values**: a string of 36 characters or fewer 
        /// </summary>
        /// <value> The ID of the mandate. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 36 **Values**: a string of 36 characters or fewer </value>
        [DataMember(Name = "MandateID", EmitDefaultValue = false)]
        public string MandateID { get; set; }

        /// <summary>
        ///  Indicates if  the mandate was received. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 3 **Values**: &#x60;Yes&#x60;, &#x60;No &#x60;(case-sensitive) 
        /// </summary>
        /// <value> Indicates if  the mandate was received. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 3 **Values**: &#x60;Yes&#x60;, &#x60;No &#x60;(case-sensitive) </value>
        [DataMember(Name = "MandateReceived", EmitDefaultValue = false)]
        public string MandateReceived { get; set; }

        /// <summary>
        ///  The date when the mandate was last updated, in &#x60;yyyy-mm-dd&#x60; format. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 29 
        /// </summary>
        /// <value> The date when the mandate was last updated, in &#x60;yyyy-mm-dd&#x60; format. A mandate is a signed authorization for UK and NL customers. This field is used only for the direct debit payment method. **Character limit**: 29 </value>
        [DataMember(Name = "MandateUpdateDate", EmitDefaultValue = false)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime MandateUpdateDate { get; set; }

        /// <summary>
        ///  Specifies the number of allowable consecutive failures Zuora attempts with the payment method before stopping. **Values**: a valid number 
        /// </summary>
        /// <value> Specifies the number of allowable consecutive failures Zuora attempts with the payment method before stopping. **Values**: a valid number </value>
        [DataMember(Name = "MaxConsecutivePaymentFailures", EmitDefaultValue = false)]
        public int MaxConsecutivePaymentFailures { get; set; }

        /// <summary>
        /// The number of consecutive failed payments for this payment method. It is reset to &#x60;0&#x60; upon successful payment.  
        /// </summary>
        /// <value>The number of consecutive failed payments for this payment method. It is reset to &#x60;0&#x60; upon successful payment.  </value>
        [DataMember(Name = "NumConsecutiveFailures", EmitDefaultValue = false)]
        public int NumConsecutiveFailures { get; set; }

        /// <summary>
        ///  This field is used to indicate the status of the payment method created within an account. It is set to &#x60;Active&#x60; on creation. **Character limit**: 6 **Values**: &#x60;Active&#x60; or &#x60;Closed&#x60; 
        /// </summary>
        /// <value> This field is used to indicate the status of the payment method created within an account. It is set to &#x60;Active&#x60; on creation. **Character limit**: 6 **Values**: &#x60;Active&#x60; or &#x60;Closed&#x60; </value>
        [DataMember(Name = "PaymentMethodStatus", EmitDefaultValue = false)]
        public string PaymentMethodStatus { get; set; }

        /// <summary>
        ///  The retry interval setting, which prevents making a payment attempt if the last failed attempt was within the last specified number of hours. This field is required if the &#x60;UseDefaultRetryRule&#x60; field value is set to &#x60;false&#x60;. **Character limit**: 4 **Values**: a whole number between 1 and 1000, exclusive 
        /// </summary>
        /// <value> The retry interval setting, which prevents making a payment attempt if the last failed attempt was within the last specified number of hours. This field is required if the &#x60;UseDefaultRetryRule&#x60; field value is set to &#x60;false&#x60;. **Character limit**: 4 **Values**: a whole number between 1 and 1000, exclusive </value>
        [DataMember(Name = "PaymentRetryWindow", EmitDefaultValue = false)]
        public int PaymentRetryWindow { get; set; }

        /// <summary>
        ///  The phone number that the account holder registered with the bank. This field is used for credit card validation when passing to a gateway. **Character limit**: 40 **Values**: a string of 40 characters or fewer 
        /// </summary>
        /// <value> The phone number that the account holder registered with the bank. This field is used for credit card validation when passing to a gateway. **Character limit**: 40 **Values**: a string of 40 characters or fewer </value>
        [DataMember(Name = "Phone", EmitDefaultValue = false)]
        public string Phone { get; set; }

        /// <summary>
        ///  The zip code of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 20 **Values**: a string of 20 characters or fewer 
        /// </summary>
        /// <value> The zip code of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 20 **Values**: a string of 20 characters or fewer </value>
        [DataMember(Name = "PostalCode", EmitDefaultValue = false)]
        public string PostalCode { get; set; }

        /// <summary>
        /// A gateway unique identifier that replaces sensitive payment method data. &#x60;SecondTokenId&#x60; is conditionally required only when &#x60;TokenId&#x60; is being used to represent a gateway customer profile. &#x60;TokenID&#x60; is being used to represent a gateway customer profile. &#x60;SecondTokenId&#x60; is used in the CC Reference Transaction payment method. **Character limit**: 64 **Values**: a string of 64 characters or fewer 
        /// </summary>
        /// <value>A gateway unique identifier that replaces sensitive payment method data. &#x60;SecondTokenId&#x60; is conditionally required only when &#x60;TokenId&#x60; is being used to represent a gateway customer profile. &#x60;TokenID&#x60; is being used to represent a gateway customer profile. &#x60;SecondTokenId&#x60; is used in the CC Reference Transaction payment method. **Character limit**: 64 **Values**: a string of 64 characters or fewer </value>
        [DataMember(Name = "SecondTokenId", EmitDefaultValue = false)]
        public string SecondTokenId { get; set; }

        /// <summary>
        ///  The state of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 70 **Values**: a string of 70 characters or fewer 
        /// </summary>
        /// <value> The state of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 70 **Values**: a string of 70 characters or fewer </value>
        [DataMember(Name = "State", EmitDefaultValue = false)]
        public string State { get; set; }

        /// <summary>
        ///  The street name of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 100 **Values**: a string of 100 characters or fewer 
        /// </summary>
        /// <value> The street name of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 100 **Values**: a string of 100 characters or fewer </value>
        [DataMember(Name = "StreetName", EmitDefaultValue = false)]
        public string StreetName { get; set; }

        /// <summary>
        ///  The street number of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 30 **Values**: a string of 30 characters or fewer 
        /// </summary>
        /// <value> The street number of the customer&#39;s address. This field is used only for the direct debit payment method. **Character limit**: 30 **Values**: a string of 30 characters or fewer </value>
        [DataMember(Name = "StreetNumber", EmitDefaultValue = false)]
        public string StreetNumber { get; set; }

        /// <summary>
        ///  Determines whether to use the default retry rules configured in the Zuora Payments settings. Set this to &#x60;true&#x60; to use the default retry rules. Set this to &#x60;false&#x60; to set the specific rules for this payment method. If you set this value to &#x60;false&#x60;, then the fields, &#x60;PaymentRetryWindow&#x60; and &#x60;MaxConsecutivePaymentFailures&#x60;, are required. **Character limit**: 5 **Values**: &#x60;true&#x60; or &#x60;false&#x60; 
        /// </summary>
        /// <value> Determines whether to use the default retry rules configured in the Zuora Payments settings. Set this to &#x60;true&#x60; to use the default retry rules. Set this to &#x60;false&#x60; to set the specific rules for this payment method. If you set this value to &#x60;false&#x60;, then the fields, &#x60;PaymentRetryWindow&#x60; and &#x60;MaxConsecutivePaymentFailures&#x60;, are required. **Character limit**: 5 **Values**: &#x60;true&#x60; or &#x60;false&#x60; </value>
        [DataMember(Name = "UseDefaultRetryRule", EmitDefaultValue = true)]
        public bool UseDefaultRetryRule { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ProxyModifyPaymentMethod {\n");
            sb.Append("  AccountId: ").Append(AccountId).Append("\n");
            sb.Append("  AchAbaCode: ").Append(AchAbaCode).Append("\n");
            sb.Append("  AchAccountName: ").Append(AchAccountName).Append("\n");
            sb.Append("  AchAccountType: ").Append(AchAccountType).Append("\n");
            sb.Append("  AchAddress1: ").Append(AchAddress1).Append("\n");
            sb.Append("  AchAddress2: ").Append(AchAddress2).Append("\n");
            sb.Append("  AchBankName: ").Append(AchBankName).Append("\n");
            sb.Append("  AchCity: ").Append(AchCity).Append("\n");
            sb.Append("  AchCountry: ").Append(AchCountry).Append("\n");
            sb.Append("  AchPostalCode: ").Append(AchPostalCode).Append("\n");
            sb.Append("  AchState: ").Append(AchState).Append("\n");
            sb.Append("  BankBranchCode: ").Append(BankBranchCode).Append("\n");
            sb.Append("  BankCheckDigit: ").Append(BankCheckDigit).Append("\n");
            sb.Append("  BankCode: ").Append(BankCode).Append("\n");
            sb.Append("  BankTransferType: ").Append(BankTransferType).Append("\n");
            sb.Append("  BusinessIdentificationCode: ").Append(BusinessIdentificationCode).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  CompanyName: ").Append(CompanyName).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  CreditCardAddress1: ").Append(CreditCardAddress1).Append("\n");
            sb.Append("  CreditCardAddress2: ").Append(CreditCardAddress2).Append("\n");
            sb.Append("  CreditCardCity: ").Append(CreditCardCity).Append("\n");
            sb.Append("  CreditCardCountry: ").Append(CreditCardCountry).Append("\n");
            sb.Append("  CreditCardExpirationMonth: ").Append(CreditCardExpirationMonth).Append("\n");
            sb.Append("  CreditCardExpirationYear: ").Append(CreditCardExpirationYear).Append("\n");
            sb.Append("  CreditCardHolderName: ").Append(CreditCardHolderName).Append("\n");
            sb.Append("  CreditCardPostalCode: ").Append(CreditCardPostalCode).Append("\n");
            sb.Append("  CreditCardSecurityCode: ").Append(CreditCardSecurityCode).Append("\n");
            sb.Append("  CreditCardState: ").Append(CreditCardState).Append("\n");
            sb.Append("  CreditCardType: ").Append(CreditCardType).Append("\n");
            sb.Append("  DeviceSessionId: ").Append(DeviceSessionId).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  ExistingMandate: ").Append(ExistingMandate).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  IBAN: ").Append(IBAN).Append("\n");
            sb.Append("  IPAddress: ").Append(IPAddress).Append("\n");
            sb.Append("  IdentityNumber: ").Append(IdentityNumber).Append("\n");
            sb.Append("  IsCompany: ").Append(IsCompany).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  LastTransactionDateTime: ").Append(LastTransactionDateTime).Append("\n");
            sb.Append("  MandateCreationDate: ").Append(MandateCreationDate).Append("\n");
            sb.Append("  MandateID: ").Append(MandateID).Append("\n");
            sb.Append("  MandateReceived: ").Append(MandateReceived).Append("\n");
            sb.Append("  MandateUpdateDate: ").Append(MandateUpdateDate).Append("\n");
            sb.Append("  MaxConsecutivePaymentFailures: ").Append(MaxConsecutivePaymentFailures).Append("\n");
            sb.Append("  NumConsecutiveFailures: ").Append(NumConsecutiveFailures).Append("\n");
            sb.Append("  PaymentMethodStatus: ").Append(PaymentMethodStatus).Append("\n");
            sb.Append("  PaymentRetryWindow: ").Append(PaymentRetryWindow).Append("\n");
            sb.Append("  Phone: ").Append(Phone).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
            sb.Append("  SecondTokenId: ").Append(SecondTokenId).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  StreetName: ").Append(StreetName).Append("\n");
            sb.Append("  StreetNumber: ").Append(StreetNumber).Append("\n");
            sb.Append("  UseDefaultRetryRule: ").Append(UseDefaultRetryRule).Append("\n");
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
            return this.Equals(input as ProxyModifyPaymentMethod);
        }

        /// <summary>
        /// Returns true if ProxyModifyPaymentMethod instances are equal
        /// </summary>
        /// <param name="input">Instance of ProxyModifyPaymentMethod to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProxyModifyPaymentMethod input)
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
                    this.AchAbaCode == input.AchAbaCode ||
                    (this.AchAbaCode != null &&
                    this.AchAbaCode.Equals(input.AchAbaCode))
                ) && 
                (
                    this.AchAccountName == input.AchAccountName ||
                    (this.AchAccountName != null &&
                    this.AchAccountName.Equals(input.AchAccountName))
                ) && 
                (
                    this.AchAccountType == input.AchAccountType ||
                    (this.AchAccountType != null &&
                    this.AchAccountType.Equals(input.AchAccountType))
                ) && 
                (
                    this.AchAddress1 == input.AchAddress1 ||
                    (this.AchAddress1 != null &&
                    this.AchAddress1.Equals(input.AchAddress1))
                ) && 
                (
                    this.AchAddress2 == input.AchAddress2 ||
                    (this.AchAddress2 != null &&
                    this.AchAddress2.Equals(input.AchAddress2))
                ) && 
                (
                    this.AchBankName == input.AchBankName ||
                    (this.AchBankName != null &&
                    this.AchBankName.Equals(input.AchBankName))
                ) && 
                (
                    this.AchCity == input.AchCity ||
                    (this.AchCity != null &&
                    this.AchCity.Equals(input.AchCity))
                ) && 
                (
                    this.AchCountry == input.AchCountry ||
                    (this.AchCountry != null &&
                    this.AchCountry.Equals(input.AchCountry))
                ) && 
                (
                    this.AchPostalCode == input.AchPostalCode ||
                    (this.AchPostalCode != null &&
                    this.AchPostalCode.Equals(input.AchPostalCode))
                ) && 
                (
                    this.AchState == input.AchState ||
                    (this.AchState != null &&
                    this.AchState.Equals(input.AchState))
                ) && 
                (
                    this.BankBranchCode == input.BankBranchCode ||
                    (this.BankBranchCode != null &&
                    this.BankBranchCode.Equals(input.BankBranchCode))
                ) && 
                (
                    this.BankCheckDigit == input.BankCheckDigit ||
                    (this.BankCheckDigit != null &&
                    this.BankCheckDigit.Equals(input.BankCheckDigit))
                ) && 
                (
                    this.BankCode == input.BankCode ||
                    (this.BankCode != null &&
                    this.BankCode.Equals(input.BankCode))
                ) && 
                (
                    this.BankTransferType == input.BankTransferType ||
                    (this.BankTransferType != null &&
                    this.BankTransferType.Equals(input.BankTransferType))
                ) && 
                (
                    this.BusinessIdentificationCode == input.BusinessIdentificationCode ||
                    (this.BusinessIdentificationCode != null &&
                    this.BusinessIdentificationCode.Equals(input.BusinessIdentificationCode))
                ) && 
                (
                    this.City == input.City ||
                    (this.City != null &&
                    this.City.Equals(input.City))
                ) && 
                (
                    this.CompanyName == input.CompanyName ||
                    (this.CompanyName != null &&
                    this.CompanyName.Equals(input.CompanyName))
                ) && 
                (
                    this.Country == input.Country ||
                    (this.Country != null &&
                    this.Country.Equals(input.Country))
                ) && 
                (
                    this.CreditCardAddress1 == input.CreditCardAddress1 ||
                    (this.CreditCardAddress1 != null &&
                    this.CreditCardAddress1.Equals(input.CreditCardAddress1))
                ) && 
                (
                    this.CreditCardAddress2 == input.CreditCardAddress2 ||
                    (this.CreditCardAddress2 != null &&
                    this.CreditCardAddress2.Equals(input.CreditCardAddress2))
                ) && 
                (
                    this.CreditCardCity == input.CreditCardCity ||
                    (this.CreditCardCity != null &&
                    this.CreditCardCity.Equals(input.CreditCardCity))
                ) && 
                (
                    this.CreditCardCountry == input.CreditCardCountry ||
                    (this.CreditCardCountry != null &&
                    this.CreditCardCountry.Equals(input.CreditCardCountry))
                ) && 
                (
                    this.CreditCardExpirationMonth == input.CreditCardExpirationMonth ||
                    this.CreditCardExpirationMonth.Equals(input.CreditCardExpirationMonth)
                ) && 
                (
                    this.CreditCardExpirationYear == input.CreditCardExpirationYear ||
                    this.CreditCardExpirationYear.Equals(input.CreditCardExpirationYear)
                ) && 
                (
                    this.CreditCardHolderName == input.CreditCardHolderName ||
                    (this.CreditCardHolderName != null &&
                    this.CreditCardHolderName.Equals(input.CreditCardHolderName))
                ) && 
                (
                    this.CreditCardPostalCode == input.CreditCardPostalCode ||
                    (this.CreditCardPostalCode != null &&
                    this.CreditCardPostalCode.Equals(input.CreditCardPostalCode))
                ) && 
                (
                    this.CreditCardSecurityCode == input.CreditCardSecurityCode ||
                    (this.CreditCardSecurityCode != null &&
                    this.CreditCardSecurityCode.Equals(input.CreditCardSecurityCode))
                ) && 
                (
                    this.CreditCardState == input.CreditCardState ||
                    (this.CreditCardState != null &&
                    this.CreditCardState.Equals(input.CreditCardState))
                ) && 
                (
                    this.CreditCardType == input.CreditCardType ||
                    (this.CreditCardType != null &&
                    this.CreditCardType.Equals(input.CreditCardType))
                ) && 
                (
                    this.DeviceSessionId == input.DeviceSessionId ||
                    (this.DeviceSessionId != null &&
                    this.DeviceSessionId.Equals(input.DeviceSessionId))
                ) && 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && 
                (
                    this.ExistingMandate == input.ExistingMandate ||
                    (this.ExistingMandate != null &&
                    this.ExistingMandate.Equals(input.ExistingMandate))
                ) && 
                (
                    this.FirstName == input.FirstName ||
                    (this.FirstName != null &&
                    this.FirstName.Equals(input.FirstName))
                ) && 
                (
                    this.IBAN == input.IBAN ||
                    (this.IBAN != null &&
                    this.IBAN.Equals(input.IBAN))
                ) && 
                (
                    this.IPAddress == input.IPAddress ||
                    (this.IPAddress != null &&
                    this.IPAddress.Equals(input.IPAddress))
                ) && 
                (
                    this.IdentityNumber == input.IdentityNumber ||
                    (this.IdentityNumber != null &&
                    this.IdentityNumber.Equals(input.IdentityNumber))
                ) && 
                (
                    this.IsCompany == input.IsCompany ||
                    this.IsCompany.Equals(input.IsCompany)
                ) && 
                (
                    this.LastName == input.LastName ||
                    (this.LastName != null &&
                    this.LastName.Equals(input.LastName))
                ) && 
                (
                    this.LastTransactionDateTime == input.LastTransactionDateTime ||
                    (this.LastTransactionDateTime != null &&
                    this.LastTransactionDateTime.Equals(input.LastTransactionDateTime))
                ) && 
                (
                    this.MandateCreationDate == input.MandateCreationDate ||
                    (this.MandateCreationDate != null &&
                    this.MandateCreationDate.Equals(input.MandateCreationDate))
                ) && 
                (
                    this.MandateID == input.MandateID ||
                    (this.MandateID != null &&
                    this.MandateID.Equals(input.MandateID))
                ) && 
                (
                    this.MandateReceived == input.MandateReceived ||
                    (this.MandateReceived != null &&
                    this.MandateReceived.Equals(input.MandateReceived))
                ) && 
                (
                    this.MandateUpdateDate == input.MandateUpdateDate ||
                    (this.MandateUpdateDate != null &&
                    this.MandateUpdateDate.Equals(input.MandateUpdateDate))
                ) && 
                (
                    this.MaxConsecutivePaymentFailures == input.MaxConsecutivePaymentFailures ||
                    this.MaxConsecutivePaymentFailures.Equals(input.MaxConsecutivePaymentFailures)
                ) && 
                (
                    this.NumConsecutiveFailures == input.NumConsecutiveFailures ||
                    this.NumConsecutiveFailures.Equals(input.NumConsecutiveFailures)
                ) && 
                (
                    this.PaymentMethodStatus == input.PaymentMethodStatus ||
                    (this.PaymentMethodStatus != null &&
                    this.PaymentMethodStatus.Equals(input.PaymentMethodStatus))
                ) && 
                (
                    this.PaymentRetryWindow == input.PaymentRetryWindow ||
                    this.PaymentRetryWindow.Equals(input.PaymentRetryWindow)
                ) && 
                (
                    this.Phone == input.Phone ||
                    (this.Phone != null &&
                    this.Phone.Equals(input.Phone))
                ) && 
                (
                    this.PostalCode == input.PostalCode ||
                    (this.PostalCode != null &&
                    this.PostalCode.Equals(input.PostalCode))
                ) && 
                (
                    this.SecondTokenId == input.SecondTokenId ||
                    (this.SecondTokenId != null &&
                    this.SecondTokenId.Equals(input.SecondTokenId))
                ) && 
                (
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
                ) && 
                (
                    this.StreetName == input.StreetName ||
                    (this.StreetName != null &&
                    this.StreetName.Equals(input.StreetName))
                ) && 
                (
                    this.StreetNumber == input.StreetNumber ||
                    (this.StreetNumber != null &&
                    this.StreetNumber.Equals(input.StreetNumber))
                ) && 
                (
                    this.UseDefaultRetryRule == input.UseDefaultRetryRule ||
                    this.UseDefaultRetryRule.Equals(input.UseDefaultRetryRule)
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
                if (this.AchAbaCode != null)
                {
                    hashCode = (hashCode * 59) + this.AchAbaCode.GetHashCode();
                }
                if (this.AchAccountName != null)
                {
                    hashCode = (hashCode * 59) + this.AchAccountName.GetHashCode();
                }
                if (this.AchAccountType != null)
                {
                    hashCode = (hashCode * 59) + this.AchAccountType.GetHashCode();
                }
                if (this.AchAddress1 != null)
                {
                    hashCode = (hashCode * 59) + this.AchAddress1.GetHashCode();
                }
                if (this.AchAddress2 != null)
                {
                    hashCode = (hashCode * 59) + this.AchAddress2.GetHashCode();
                }
                if (this.AchBankName != null)
                {
                    hashCode = (hashCode * 59) + this.AchBankName.GetHashCode();
                }
                if (this.AchCity != null)
                {
                    hashCode = (hashCode * 59) + this.AchCity.GetHashCode();
                }
                if (this.AchCountry != null)
                {
                    hashCode = (hashCode * 59) + this.AchCountry.GetHashCode();
                }
                if (this.AchPostalCode != null)
                {
                    hashCode = (hashCode * 59) + this.AchPostalCode.GetHashCode();
                }
                if (this.AchState != null)
                {
                    hashCode = (hashCode * 59) + this.AchState.GetHashCode();
                }
                if (this.BankBranchCode != null)
                {
                    hashCode = (hashCode * 59) + this.BankBranchCode.GetHashCode();
                }
                if (this.BankCheckDigit != null)
                {
                    hashCode = (hashCode * 59) + this.BankCheckDigit.GetHashCode();
                }
                if (this.BankCode != null)
                {
                    hashCode = (hashCode * 59) + this.BankCode.GetHashCode();
                }
                if (this.BankTransferType != null)
                {
                    hashCode = (hashCode * 59) + this.BankTransferType.GetHashCode();
                }
                if (this.BusinessIdentificationCode != null)
                {
                    hashCode = (hashCode * 59) + this.BusinessIdentificationCode.GetHashCode();
                }
                if (this.City != null)
                {
                    hashCode = (hashCode * 59) + this.City.GetHashCode();
                }
                if (this.CompanyName != null)
                {
                    hashCode = (hashCode * 59) + this.CompanyName.GetHashCode();
                }
                if (this.Country != null)
                {
                    hashCode = (hashCode * 59) + this.Country.GetHashCode();
                }
                if (this.CreditCardAddress1 != null)
                {
                    hashCode = (hashCode * 59) + this.CreditCardAddress1.GetHashCode();
                }
                if (this.CreditCardAddress2 != null)
                {
                    hashCode = (hashCode * 59) + this.CreditCardAddress2.GetHashCode();
                }
                if (this.CreditCardCity != null)
                {
                    hashCode = (hashCode * 59) + this.CreditCardCity.GetHashCode();
                }
                if (this.CreditCardCountry != null)
                {
                    hashCode = (hashCode * 59) + this.CreditCardCountry.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.CreditCardExpirationMonth.GetHashCode();
                hashCode = (hashCode * 59) + this.CreditCardExpirationYear.GetHashCode();
                if (this.CreditCardHolderName != null)
                {
                    hashCode = (hashCode * 59) + this.CreditCardHolderName.GetHashCode();
                }
                if (this.CreditCardPostalCode != null)
                {
                    hashCode = (hashCode * 59) + this.CreditCardPostalCode.GetHashCode();
                }
                if (this.CreditCardSecurityCode != null)
                {
                    hashCode = (hashCode * 59) + this.CreditCardSecurityCode.GetHashCode();
                }
                if (this.CreditCardState != null)
                {
                    hashCode = (hashCode * 59) + this.CreditCardState.GetHashCode();
                }
                if (this.CreditCardType != null)
                {
                    hashCode = (hashCode * 59) + this.CreditCardType.GetHashCode();
                }
                if (this.DeviceSessionId != null)
                {
                    hashCode = (hashCode * 59) + this.DeviceSessionId.GetHashCode();
                }
                if (this.Email != null)
                {
                    hashCode = (hashCode * 59) + this.Email.GetHashCode();
                }
                if (this.ExistingMandate != null)
                {
                    hashCode = (hashCode * 59) + this.ExistingMandate.GetHashCode();
                }
                if (this.FirstName != null)
                {
                    hashCode = (hashCode * 59) + this.FirstName.GetHashCode();
                }
                if (this.IBAN != null)
                {
                    hashCode = (hashCode * 59) + this.IBAN.GetHashCode();
                }
                if (this.IPAddress != null)
                {
                    hashCode = (hashCode * 59) + this.IPAddress.GetHashCode();
                }
                if (this.IdentityNumber != null)
                {
                    hashCode = (hashCode * 59) + this.IdentityNumber.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.IsCompany.GetHashCode();
                if (this.LastName != null)
                {
                    hashCode = (hashCode * 59) + this.LastName.GetHashCode();
                }
                if (this.LastTransactionDateTime != null)
                {
                    hashCode = (hashCode * 59) + this.LastTransactionDateTime.GetHashCode();
                }
                if (this.MandateCreationDate != null)
                {
                    hashCode = (hashCode * 59) + this.MandateCreationDate.GetHashCode();
                }
                if (this.MandateID != null)
                {
                    hashCode = (hashCode * 59) + this.MandateID.GetHashCode();
                }
                if (this.MandateReceived != null)
                {
                    hashCode = (hashCode * 59) + this.MandateReceived.GetHashCode();
                }
                if (this.MandateUpdateDate != null)
                {
                    hashCode = (hashCode * 59) + this.MandateUpdateDate.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.MaxConsecutivePaymentFailures.GetHashCode();
                hashCode = (hashCode * 59) + this.NumConsecutiveFailures.GetHashCode();
                if (this.PaymentMethodStatus != null)
                {
                    hashCode = (hashCode * 59) + this.PaymentMethodStatus.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.PaymentRetryWindow.GetHashCode();
                if (this.Phone != null)
                {
                    hashCode = (hashCode * 59) + this.Phone.GetHashCode();
                }
                if (this.PostalCode != null)
                {
                    hashCode = (hashCode * 59) + this.PostalCode.GetHashCode();
                }
                if (this.SecondTokenId != null)
                {
                    hashCode = (hashCode * 59) + this.SecondTokenId.GetHashCode();
                }
                if (this.State != null)
                {
                    hashCode = (hashCode * 59) + this.State.GetHashCode();
                }
                if (this.StreetName != null)
                {
                    hashCode = (hashCode * 59) + this.StreetName.GetHashCode();
                }
                if (this.StreetNumber != null)
                {
                    hashCode = (hashCode * 59) + this.StreetNumber.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.UseDefaultRetryRule.GetHashCode();
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
            // BankTransferType (string) maxLength
            if (this.BankTransferType != null && this.BankTransferType.Length > 20)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for BankTransferType, length must be less than 20.", new [] { "BankTransferType" });
            }

            // CompanyName (string) maxLength
            if (this.CompanyName != null && this.CompanyName.Length > 80)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for CompanyName, length must be less than 80.", new [] { "CompanyName" });
            }

            // NumConsecutiveFailures (int) maximum
            if (this.NumConsecutiveFailures > (int)100)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for NumConsecutiveFailures, must be a value less than or equal to 100.", new [] { "NumConsecutiveFailures" });
            }

            // NumConsecutiveFailures (int) minimum
            if (this.NumConsecutiveFailures < (int)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for NumConsecutiveFailures, must be a value greater than or equal to 0.", new [] { "NumConsecutiveFailures" });
            }

            yield break;
        }
    }

}
