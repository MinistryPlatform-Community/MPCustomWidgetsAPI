using MicroServices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Text.RegularExpressions;

namespace MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DataFormattingController : ControllerBase
    {
        /// <summary>
        /// Formats Strings from Data with key-value based data
        /// Automatically detects tokens in content and replaces automatically
        /// If there is no data in dataPayload, an empty string will be returned
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("FormatCollection")]
        public string FormatCollection(DataFormattingViewModel model)
        {
            // Generate List of Variables
            List<string> variables = new List<string>();
            MatchCollection mcol = Regex.Matches(model.itemTemplate, @"{{\b\S+?\b}}");

            foreach (Match m in mcol)
            {
                if (!variables.Contains(m.ToString()))
                {
                    variables.Add(m.ToString());
                }                
            }

            string items = string.Empty;

            foreach (var d in model.dataPayload)
            {
                var localItem = model.itemTemplate;
                
                foreach (var v in variables)
                {
                    if (d[v.Replace("{{", "").Replace("}}", "")] != null)
                    {
                        localItem = localItem.Replace(v, d[v.Replace("{{", "").Replace("}}", "")].ToString());
                    }
                    else
                    {
                        localItem = localItem.Replace(v, "");
                    }
                }

                items += localItem;
            }

            if (!string.IsNullOrEmpty(items))
            {
                return model.mainTemplate.Replace(model.templateItemObject, items);
            }

            return string.Empty;
        }
    }
}
