using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace EncryptDecryptApp
{
    public static class Encrypt
    {
        [FunctionName("Encrypt")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Encrypt HTTP trigger function processed a request.");

            string text = req.Query["Text"];
            string IV = req.Query["IV"];
            string Key = req.Query["Key"];
            if (string.IsNullOrEmpty(text)) return new BadRequestObjectResult("Please pass a 'Text' on the query string");
            if (string.IsNullOrEmpty(IV)) return new BadRequestObjectResult("Please pass a 'IV' on the query string");
            if (string.IsNullOrEmpty(Key)) return new BadRequestObjectResult("Please pass a 'Key' on the query string");


            var IV_asByte = IV.FormatToByteArray();
            var key_asByte = Key.FormatToByteArray();
            var encrypted = AESManager.Encrypt(text, key_asByte, IV_asByte);
            return new OkObjectResult(encrypted.FormatToString());
        }
    }
}
