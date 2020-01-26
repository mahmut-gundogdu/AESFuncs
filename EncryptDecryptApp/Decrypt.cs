using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EncryptDecryptApp
{
    public static class Decrypt
    {
        [FunctionName("Decrypt")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Decrypt HTTP trigger function processed a request.");

            string text = req.Query["Text"];
            string IV = req.Query["IV"];
            string Key = req.Query["Key"];
            if (string.IsNullOrEmpty(text)) return new BadRequestObjectResult("Please pass a 'Text' on the query string");
            if (string.IsNullOrEmpty(IV)) return new BadRequestObjectResult("Please pass a 'IV' on the query string");
            if (string.IsNullOrEmpty(Key)) return new BadRequestObjectResult("Please pass a 'Key' on the query string");


            var IV_asByte =  IV.FormatToByteArray();
            var key_asByte = Key.FormatToByteArray();
            var text_asByte = text.FormatToByteArray();
            var encrypted = AESManager.Decrypt(text_asByte, key_asByte, IV_asByte) ;
            return new OkObjectResult(encrypted);
        }
    }
}
