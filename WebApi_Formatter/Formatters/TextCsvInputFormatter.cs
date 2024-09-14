using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApi_Formatter.Dto;

namespace WebApi_Formatter.Formatters
{
    public class TextCsvInputFormatter : TextInputFormatter
    {
        public TextCsvInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var request = context.HttpContext.Request;
            return await ReadCustomType(request, encoding);
        }
        private async Task<InputFormatterResult> ReadCustomType(HttpRequest request, Encoding encoding)
        {
            using (var reader = new StreamReader(request.Body, encoding))
            {
                var content = await reader.ReadToEndAsync();
                var temp = content.Split('-');

                if (temp.Length != 4)
                {
                    return await InputFormatterResult.FailureAsync();

                }

                var dto = new StudentAddDto
                {
                    Fullname = temp[0].Trim(),
                    SeriaNo = temp[1].Trim(),
                    Age = int.Parse(temp[2].Trim()),
                    Score = double.Parse(temp[3].Trim())
                };
                return await InputFormatterResult.SuccessAsync(dto);

            }
        }
    }
}
