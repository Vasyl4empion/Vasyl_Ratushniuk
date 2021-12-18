using NUnit.Framework;
using RestSharp;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
namespace WebAPI
{
    [TestFixture]
    public class Tests
    {
        ExtentReports extent = null;

        [SetUp]
        public void Setup()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"D:\3-rd course\Extent reports\TestReport.html");
            extent.AttachReporter(htmlReporter);
        }

            [Test]
        public void Upload_GetMetadata_Delete_File()
        {
            ExtentTest test = extent.CreateTest("Test uploading,getting metadata,deleting file on dropbox").Info("Test started");
            //Uploading file

           var client_upload = new RestClient("https://content.dropboxapi.com/2/files/upload");
            client_upload.Timeout = -1;
            var request_upload = new RestRequest(Method.POST);
            request_upload.AddHeader("Content-Type", "application/octet-stream");
            request_upload.AddHeader("Dropbox-API-Arg", "{\"path\": \"/File.txt\",\"mode\": \"add\",\"autorename\": true,\"mute\": false,\"strict_conflict\": false}");
            request_upload.AddHeader("Authorization", "Bearer sl.A-atjGRgMiFgQnLHvaIO2pcxwLl6aVoaMFaPvCI6225pCnGmqwMkHzI-JVUQ4XaS4b6Y9B-rSMJYO7pMpqfXe546O7E3ofhK1z9L7eA-ysaNBYnoQ9lIh5ymOyrnwA54fi_50CT4");
            var body_upload = @"Text";
            request_upload.AddParameter("application/octet-stream", body_upload, ParameterType.RequestBody);
            IRestResponse response_upload = client_upload.Execute(request_upload);
            string id = "";
            for (int i = 0; i < response_upload.Content.Length; i++)
            {
                string index = "";
                for (int j = 0; j < 3; j++)
                {
                    index += response_upload.Content[i + j];
                }
                if (index == "id:")
                {
                    while (response_upload.Content[i + 3] != '\"')
                    {
                        id += response_upload.Content[i + 3];
                        i++;
                    }
                    break;
                }
            }
            test.Log(Status.Info, "File Uploaded!");

            //Getting metadata

            var client_getmetadata = new RestClient("https://api.dropboxapi.com/2/files/get_metadata");
            client_getmetadata.Timeout = -1;
            var request_getmetadata = new RestRequest(Method.POST);
            request_getmetadata.AddHeader("Content-Type", "application/json");
            request_getmetadata.AddHeader("Authorization", "Bearer sl.A-atjGRgMiFgQnLHvaIO2pcxwLl6aVoaMFaPvCI6225pCnGmqwMkHzI-JVUQ4XaS4b6Y9B-rSMJYO7pMpqfXe546O7E3ofhK1z9L7eA-ysaNBYnoQ9lIh5ymOyrnwA54fi_50CT4");
            var body_getmetadata = @"{" + "\n" +
            @"    ""path"": ""/File.txt""," + "\n" +
            @"    ""include_media_info"": false," + "\n" +
            @"    ""include_deleted"": false," + "\n" +
            @"    ""include_has_explicit_shared_members"": false" + "\n" +
            @"}";
            request_getmetadata.AddParameter("application/json", body_getmetadata, ParameterType.RequestBody);
            IRestResponse response_getmetadata = client_getmetadata.Execute(request_getmetadata);
            Assert.IsTrue(response_getmetadata.Content.Contains(id));
            test.Log(Status.Info, "We got metadata!");
            //Delting file

            var client_delete = new RestClient("https://api.dropboxapi.com/2/files/delete_v2");
            client_delete.Timeout = -1;
            var request_delete = new RestRequest(Method.POST);
            request_delete.AddHeader("Content-Type", "application/json");
            request_delete.AddHeader("Authorization", "Bearer sl.A-atjGRgMiFgQnLHvaIO2pcxwLl6aVoaMFaPvCI6225pCnGmqwMkHzI-JVUQ4XaS4b6Y9B-rSMJYO7pMpqfXe546O7E3ofhK1z9L7eA-ysaNBYnoQ9lIh5ymOyrnwA54fi_50CT4");
            var body_delete = @"{" + "\n" +
            @"    ""path"": ""/File.txt""" + "\n" + @"}";
            request_delete.AddParameter("application/json", body_delete, ParameterType.RequestBody);
            IRestResponse response_delete = client_delete.Execute(request_delete);
            Assert.IsTrue(response_delete.Content.Contains(id));
            test.Log(Status.Info, "File Deleted!");
            test.Log(Status.Pass, "All tests passed!");
        }
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
    }
}