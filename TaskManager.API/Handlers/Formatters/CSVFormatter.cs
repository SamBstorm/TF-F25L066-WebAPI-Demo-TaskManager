using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Reflection;
using System.Text;
using TaskManager.API.Models;

namespace TaskManager.API.Handlers.Formatters
{
    public class CSVFormatter : TextOutputFormatter
    {
        public CSVFormatter()
        {
            // 1. Définir les types de médias (MIME Types) que ce Formatter gère.
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));

            // 2. Définir l'encodage supporté.
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            HttpResponse response = context.HttpContext.Response;
            StringBuilder builder = new StringBuilder();
            switch(context.Object)
            {
                case UserModel um:
                    ToCSV(builder, um);
                    break;
                case IEnumerable<UserModel> ul:
                    ToCSV(builder, ul);
                    break;
                case EnumerableResult<UserModel> er:
                    ToCSV(builder, er.Result);
                    break;
            }
            await response.WriteAsync(builder.ToString());
        }

        protected override bool CanWriteType(Type? type)
        {
            if(
                typeof(UserModel).IsAssignableFrom(type) || 
                typeof(IEnumerable<UserModel>).IsAssignableFrom(type) || 
                typeof(EnumerableResult<UserModel>).IsAssignableFrom(type)
                )
            {
                return base.CanWriteType(type);
            }
            return false;
        }

        private void ToCSV(StringBuilder builder, UserModel entity)
        {
            if(builder.Length == 0)
            {
                builder.AppendLine("\"UserId\", \"Email\", \"Password\", \"Role\", \"CreationDate\", \"IsActive\"");
            }
            builder.AppendLine($"\"{entity.UserId}\", \"{entity.Email}\", \"{entity.Password}\", \"{entity.Role.ToString()}\", \"{entity.CreationDate}\", \"{entity.IsActive}\"");
        }
        private void ToCSV(StringBuilder builder, IEnumerable<UserModel> entity)
        {
            foreach (UserModel u in entity)
            {
                ToCSV(builder, u);
            }
        }
    }
}
