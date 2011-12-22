using System;
using Amazon.S3;
using Amazon.S3.Model;

namespace AWS_Web_Project_Template.Abstractions
{
    public interface IAmazonS3Wrapper : AmazonS3
    {
        void Dispose();
        string GetPreSignedURL(GetPreSignedUrlRequest request);
        ListBucketsResponse ListBuckets();
        IAsyncResult BeginListBuckets(AsyncCallback callback, object state);
        IAsyncResult BeginListBuckets(ListBucketsRequest request, AsyncCallback callback, object state);
        ListBucketsResponse EndListBuckets(IAsyncResult asyncResult);
        ListBucketsResponse ListBuckets(ListBucketsRequest request);
        IAsyncResult BeginGetBucketLocation(GetBucketLocationRequest request, AsyncCallback callback, object state);
        GetBucketLocationResponse EndGetBucketLocation(IAsyncResult asyncResult);
        GetBucketLocationResponse GetBucketLocation(GetBucketLocationRequest request);
        IAsyncResult BeginGetBucketLogging(GetBucketLoggingRequest request, AsyncCallback callback, object state);
        GetBucketLoggingResponse EndGetBucketLogging(IAsyncResult asyncResult);
        GetBucketLoggingResponse GetBucketLogging(GetBucketLoggingRequest request);
        IAsyncResult BeginEnableBucketLogging(EnableBucketLoggingRequest request, AsyncCallback callback, object state);
        EnableBucketLoggingResponse EndEnableBucketLogging(IAsyncResult asyncResult);
        EnableBucketLoggingResponse EnableBucketLogging(EnableBucketLoggingRequest request);
        IAsyncResult BeginDisableBucketLogging(DisableBucketLoggingRequest request, AsyncCallback callback, object state);
        DisableBucketLoggingResponse EndDisableBucketLogging(IAsyncResult asyncResult);
        DisableBucketLoggingResponse DisableBucketLogging(DisableBucketLoggingRequest request);
        IAsyncResult BeginGetBucketVersioning(GetBucketVersioningRequest request, AsyncCallback callback, object state);
        GetBucketVersioningResponse EndGetBucketVersioning(IAsyncResult asyncResult);
        GetBucketVersioningResponse GetBucketVersioning(GetBucketVersioningRequest request);
        IAsyncResult BeginSetBucketVersioning(SetBucketVersioningRequest request, AsyncCallback callback, object state);
        SetBucketVersioningResponse EndSetBucketVersioning(IAsyncResult asyncResult);
        SetBucketVersioningResponse SetBucketVersioning(SetBucketVersioningRequest request);
        IAsyncResult BeginGetBucketPolicy(GetBucketPolicyRequest request, AsyncCallback callback, object state);
        GetBucketPolicyResponse EndGetBucketPolicy(IAsyncResult asyncResult);
        GetBucketPolicyResponse GetBucketPolicy(GetBucketPolicyRequest request);
        IAsyncResult BeginPutBucketPolicy(PutBucketPolicyRequest request, AsyncCallback callback, object state);
        PutBucketPolicyResponse EndPutBucketPolicy(IAsyncResult asyncResult);
        PutBucketPolicyResponse PutBucketPolicy(PutBucketPolicyRequest request);
        IAsyncResult BeginDeleteBucketPolicy(DeleteBucketPolicyRequest request, AsyncCallback callback, object state);
        DeleteBucketPolicyResponse EndDeleteBucketPolicy(IAsyncResult asyncResult);
        DeleteBucketPolicyResponse DeleteBucketPolicy(DeleteBucketPolicyRequest request);
        IAsyncResult BeginSetNotificationConfiguration(SetNotificationConfigurationRequest request, AsyncCallback callback, object state);
        SetNotificationConfigurationResponse EndSetNotificationConfiguration(IAsyncResult asyncResult);
        SetNotificationConfigurationResponse SetNotificationConfiguration(SetNotificationConfigurationRequest request);
        IAsyncResult BeginGetNotificationConfiguration(GetNotificationConfigurationRequest request, AsyncCallback callback, object state);
        GetNotificationConfigurationResponse EndGetNotificationConfiguration(IAsyncResult asyncResult);
        GetNotificationConfigurationResponse GetNotificationConfiguration(GetNotificationConfigurationRequest request);
        IAsyncResult BeginListObjects(ListObjectsRequest request, AsyncCallback callback, object state);
        ListObjectsResponse EndListObjects(IAsyncResult asyncResult);
        ListObjectsResponse ListObjects(ListObjectsRequest request);
        IAsyncResult BeginListVersions(ListVersionsRequest request, AsyncCallback callback, object state);
        ListVersionsResponse EndListVersions(IAsyncResult asyncResult);
        ListVersionsResponse ListVersions(ListVersionsRequest request);
        IAsyncResult BeginGetACL(GetACLRequest request, AsyncCallback callback, object state);
        GetACLResponse EndGetACL(IAsyncResult asyncResult);
        GetACLResponse GetACL(GetACLRequest request);
        IAsyncResult BeginSetACL(SetACLRequest request, AsyncCallback callback, object state);
        SetACLResponse EndSetACL(IAsyncResult asyncResult);
        SetACLResponse SetACL(SetACLRequest request);
        IAsyncResult BeginPutBucket(PutBucketRequest request, AsyncCallback callback, object state);
        PutBucketResponse EndPutBucket(IAsyncResult asyncResult);
        PutBucketResponse PutBucket(PutBucketRequest request);
        IAsyncResult BeginDeleteBucket(DeleteBucketRequest request, AsyncCallback callback, object state);
        DeleteBucketResponse EndDeleteBucket(IAsyncResult asyncResult);
        DeleteBucketResponse DeleteBucket(DeleteBucketRequest request);
        IAsyncResult BeginGetObject(GetObjectRequest request, AsyncCallback callback, object state);
        GetObjectResponse EndGetObject(IAsyncResult asyncResult);
        GetObjectResponse GetObject(GetObjectRequest request);
        IAsyncResult BeginGetObjectMetadata(GetObjectMetadataRequest request, AsyncCallback callback, object state);
        GetObjectMetadataResponse EndGetObjectMetadata(IAsyncResult asyncResult);
        GetObjectMetadataResponse GetObjectMetadata(GetObjectMetadataRequest request);
        IAsyncResult BeginPutObject(PutObjectRequest request, AsyncCallback callback, object state);
        PutObjectResponse EndPutObject(IAsyncResult asyncResult);
        PutObjectResponse PutObject(PutObjectRequest request);
        IAsyncResult BeginDeleteObject(DeleteObjectRequest request, AsyncCallback callback, object state);
        DeleteObjectResponse EndDeleteObject(IAsyncResult asyncResult);
        DeleteObjectResponse DeleteObject(DeleteObjectRequest request);
        IAsyncResult BeginDeleteObjects(DeleteObjectsRequest request, AsyncCallback callback, object state);
        DeleteObjectsResponse EndDeleteObjects(IAsyncResult asyncResult);
        DeleteObjectsResponse DeleteObjects(DeleteObjectsRequest request);
        IAsyncResult BeginCopyObject(CopyObjectRequest request, AsyncCallback callback, object state);
        CopyObjectResponse EndCopyObject(IAsyncResult asyncResult);
        CopyObjectResponse CopyObject(CopyObjectRequest request);
        IAsyncResult BeginInitiateMultipartUpload(InitiateMultipartUploadRequest request, AsyncCallback callback, object state);
        InitiateMultipartUploadResponse EndInitiateMultipartUpload(IAsyncResult asyncResult);
        InitiateMultipartUploadResponse InitiateMultipartUpload(InitiateMultipartUploadRequest request);
        IAsyncResult BeginUploadPart(UploadPartRequest request, AsyncCallback callback, object state);
        UploadPartResponse EndUploadPart(IAsyncResult asyncResult);
        UploadPartResponse UploadPart(UploadPartRequest request);
        IAsyncResult BeginCopyPart(CopyPartRequest request, AsyncCallback callback, object state);
        CopyPartResponse EndCopyPart(IAsyncResult asyncResult);
        CopyPartResponse CopyPart(CopyPartRequest request);
        IAsyncResult BeginListParts(ListPartsRequest request, AsyncCallback callback, object state);
        ListPartsResponse EndListParts(IAsyncResult asyncResult);
        ListPartsResponse ListParts(ListPartsRequest request);
        IAsyncResult BeginAbortMultipartUpload(AbortMultipartUploadRequest request, AsyncCallback callback, object state);
        AbortMultipartUploadResponse EndAbortMultipartUpload(IAsyncResult asyncResult);
        AbortMultipartUploadResponse AbortMultipartUpload(AbortMultipartUploadRequest request);
        IAsyncResult BeginCompleteMultipartUpload(CompleteMultipartUploadRequest request, AsyncCallback callback, object state);
        CompleteMultipartUploadResponse EndCompleteMultipartUpload(IAsyncResult asyncResult);
        CompleteMultipartUploadResponse CompleteMultipartUpload(CompleteMultipartUploadRequest request);
        IAsyncResult BeginListMultipartUploads(ListMultipartUploadsRequest request, AsyncCallback callback, object state);
        ListMultipartUploadsResponse EndListMultipartUploads(IAsyncResult asyncResult);
        ListMultipartUploadsResponse ListMultipartUploads(ListMultipartUploadsRequest request);
        IAsyncResult BeginPutBucketWebsite(PutBucketWebsiteRequest request, AsyncCallback callback, object state);
        PutBucketWebsiteResponse EndPutBucketWebsite(IAsyncResult asyncResult);
        PutBucketWebsiteResponse PutBucketWebsite(PutBucketWebsiteRequest request);
        IAsyncResult BeginGetBucketWebsite(GetBucketWebsiteRequest request, AsyncCallback callback, object state);
        GetBucketWebsiteResponse EndGetBucketWebsite(IAsyncResult asyncResult);
        GetBucketWebsiteResponse GetBucketWebsite(GetBucketWebsiteRequest request);
        IAsyncResult BeginDeleteBucketWebsite(DeleteBucketWebsiteRequest request, AsyncCallback callback, object state);
        DeleteBucketWebsiteResponse EndDeleteBucketWebsite(IAsyncResult asyncResult);
        DeleteBucketWebsiteResponse DeleteBucketWebsite(DeleteBucketWebsiteRequest request);
    }
}