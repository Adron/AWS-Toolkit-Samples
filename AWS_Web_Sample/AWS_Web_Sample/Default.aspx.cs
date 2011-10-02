using System;
using System.Configuration;
using System.Text;
using System.IO;
using System.Collections.Specialized;

using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.SimpleDB;
using Amazon.SimpleDB.Model;
using Amazon.S3;

namespace AWS_Web_Sample
{
    public partial class _Default : System.Web.UI.Page
    {
        protected AmazonEC2 ec2;
        protected AmazonS3 s3;
        protected AmazonSimpleDB sdb;
        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection appConfig = ConfigurationManager.AppSettings;

            var sb = new StringBuilder(1024);
            using (var sr = new StringWriter(sb))
            {
                try
                {
                    ec2 = AWSClientFactory.CreateAmazonEC2Client(
                        appConfig["AWSAccessKey"],
                        appConfig["AWSSecretKey"],
                        new AmazonEC2Config().WithServiceURL("https://ec2.us-west-1.amazonaws.com")
                        );
                    WriteEc2Info();
                }
                catch (AmazonEC2Exception ex)
                {
                    if (ex.ErrorCode != null && ex.ErrorCode.Equals("AuthFailure"))
                    {
                        sr.WriteLine("The account you are using is not signed up for Amazon EC2.");
                        sr.WriteLine("<br />");
                        sr.WriteLine("You can sign up for Amazon EC2 at http://aws.amazon.com/ec2");
                        sr.WriteLine("<br />");
                        sr.WriteLine("<br />");
                    }
                    else
                    {
                        sr.WriteLine("Caught Exception: " + ex.Message);
                        sr.WriteLine("<br />");
                        sr.WriteLine("Response Status Code: " + ex.StatusCode);
                        sr.WriteLine("<br />");
                        sr.WriteLine("Error Code: " + ex.ErrorCode);
                        sr.WriteLine("<br />");
                        sr.WriteLine("Error Type: " + ex.ErrorType);
                        sr.WriteLine("<br />");
                        sr.WriteLine("Request ID: " + ex.RequestId);
                        sr.WriteLine("<br />");
                        sr.WriteLine("XML: " + ex.XML);
                        sr.WriteLine("<br />");
                        sr.WriteLine("<br />");
                    }
                    ec2Placeholder.Text = sr.ToString();
                }
            }

            sb = new StringBuilder(1024);
            using (var sr = new StringWriter(sb))
            {
                try
                {
                    s3 = AWSClientFactory.CreateAmazonS3Client(
                        appConfig["AWSAccessKey"],
                        appConfig["AWSSecretKey"]
                        );
                    WriteS3Info();
                }
                catch (AmazonS3Exception ex)
                {
                    if (ex.ErrorCode != null && (ex.ErrorCode.Equals("InvalidAccessKeyId") ||
                        ex.ErrorCode.Equals("InvalidSecurity")))
                    {
                        sr.WriteLine("The account you are using is not signed up for Amazon S3");
                        sr.WriteLine("<br />");
                        sr.WriteLine("You can sign up for Amazon S3 at http://aws.amazon.com/s3");
                        sr.WriteLine("<br />");
                        sr.WriteLine("<br />");
                    }
                    else
                    {
                        sr.WriteLine("Caught Exception: " + ex.Message);
                        sr.WriteLine("<br />");
                        sr.WriteLine("Response Status Code: " + ex.StatusCode);
                        sr.WriteLine("<br />");
                        sr.WriteLine("Error Code: " + ex.ErrorCode);
                        sr.WriteLine("<br />");
                        sr.WriteLine("Request ID: " + ex.RequestId);
                        sr.WriteLine("<br />");
                        sr.WriteLine("XML: " + ex.XML);
                        sr.WriteLine("<br />");
                        sr.WriteLine("<br />");
                    }
                    s3Placeholder.Text = sr.ToString();
                }
            }

            sb = new StringBuilder(1024);
            using (var sr = new StringWriter(sb))
            {
                try
                {
                    sdb = AWSClientFactory.CreateAmazonSimpleDBClient(
                        appConfig["AWSAccessKey"],
                        appConfig["AWSSecretKey"]
                        );
                    WriteSimpleDbInfo();
                }
                catch (AmazonSimpleDBException ex)
                {
                    if (ex.ErrorCode != null && ex.ErrorCode.Equals("InvalidClientTokenId"))
                    {
                        sr.WriteLine("The account you are using is not signed up for Amazon SimpleDB.");
                        sr.WriteLine("<br />");
                        sr.WriteLine("You can sign up for Amazon SimpleDB at http://aws.amazon.com/simpledb");
                        sr.WriteLine("<br />");
                        sr.WriteLine("<br />");
                    }
                    else
                    {
                        sr.WriteLine("Exception Message: " + ex.Message);
                        sr.WriteLine("<br />");
                        sr.WriteLine("Response Status Code: " + ex.StatusCode);
                        sr.WriteLine("<br />");
                        sr.WriteLine("Error Code: " + ex.ErrorCode);
                        sr.WriteLine("<br />");
                        sr.WriteLine("Error Type: " + ex.ErrorType);
                        sr.WriteLine("<br />");
                        sr.WriteLine("Request ID: " + ex.RequestId);
                        sr.WriteLine("<br />");
                        sr.WriteLine("XML: " + ex.XML);
                        sr.WriteLine("<br />");
                        sr.WriteLine("<br />");
                    }
                    sdbPlaceholder.Text = sr.ToString();
                }
            }
        }

        private void WriteEc2Info()
        {
            var output = new StringBuilder();
            var ec2Request = new DescribeInstancesRequest();
            var ec2Response = ec2.DescribeInstances(ec2Request);
            foreach (var reservation in ec2Response.DescribeInstancesResult.Reservation)
            {
                foreach (var instance in reservation.RunningInstance)
                {
                    output.AppendFormat("<li>{0}</br>{1}</br>{2}</li>", instance.InstanceId, instance.InstanceState.Name, instance.IpAddress);
                }
            }
            ec2Placeholder.Text = output.ToString();
        }

        private void WriteS3Info()
        {
            var output = new StringBuilder();
            var response = s3.ListBuckets();
            if (response.Buckets != null && response.Buckets.Count > 0)
                foreach (var theBucket in response.Buckets)
                {
                    output.AppendFormat("<li>{0}</li>", theBucket.BucketName);
                }
            s3Placeholder.Text = output.ToString();
        }

        private void WriteSimpleDbInfo()
        {
            var output = new StringBuilder();
            var sdbRequest = new ListDomainsRequest();
            var sdbResponse = sdb.ListDomains(sdbRequest);
            foreach (var domain in sdbResponse.ListDomainsResult.DomainName)
            {
                output.AppendFormat("<li>{0}</li>", domain);
            }
            sdbPlaceholder.Text = output.ToString();
        }
    }
}