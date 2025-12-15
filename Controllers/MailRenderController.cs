using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace MailTemplateService.Controllers
{
        [Route("Mail")]
        public class MailRenderController : Controller
        {
            [HttpGet("Render")]
            public IActionResult Render(
                string template,
                string PromotionId = null,
                string IncrementCode = null,
                string Token = null,
                string EmployeeCode = null,
                string ApproverName = null,
                string EmployeeName = null,
                string EmployeeId = null,
                string OldDesignation = null,
                string NewDesignation = null,
                string EffectiveFrom = null,
                string PreviousGross = null,
                string ProposedGross = null,
                string BaseUrl = null
            )
            {
                if (string.IsNullOrWhiteSpace(template))
                    return BadRequest("Template is required");

                // Path to HTML template
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                                               "wwwroot",
                                               "MailTemplates",
                                               template + ".html");

                if (!System.IO.File.Exists(filePath))
                    return NotFound("Template not found");

                string htmlContent = System.IO.File.ReadAllText(filePath);

                // Replace all placeholders safely
                htmlContent = htmlContent.Replace("{PromotionId}", HttpUtility.HtmlEncode(PromotionId ?? ""))
                                         .Replace("{IncrementCode}", HttpUtility.HtmlEncode(IncrementCode ?? ""))
                                         .Replace("{Token}", HttpUtility.HtmlEncode(Token ?? ""))
                                         .Replace("{EmployeeCode}", HttpUtility.HtmlEncode(EmployeeCode ?? ""))
                                         .Replace("{ApproverName}", HttpUtility.HtmlEncode(ApproverName ?? ""))
                                         .Replace("{EmployeeName}", HttpUtility.HtmlEncode(EmployeeName ?? ""))
                                         .Replace("{EmployeeId}", HttpUtility.HtmlEncode(EmployeeId ?? ""))
                                         .Replace("{OldDesignation}", HttpUtility.HtmlEncode(OldDesignation ?? ""))
                                         .Replace("{NewDesignation}", HttpUtility.HtmlEncode(NewDesignation ?? ""))
                                         .Replace("{EffectiveFrom}", HttpUtility.HtmlEncode(EffectiveFrom ?? ""))
                                         .Replace("{PreviousGross}", HttpUtility.HtmlEncode(PreviousGross ?? ""))
                                         .Replace("{ProposedGross}", HttpUtility.HtmlEncode(ProposedGross ?? ""))
                                         .Replace("{BaseUrl}", HttpUtility.HtmlEncode(BaseUrl ?? ""));

                return Content(htmlContent, "text/html");
        }
    }
}
