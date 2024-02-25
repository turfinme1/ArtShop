using System.Globalization;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ArtShop.Web.Infrastructure.ModelBinders.DateTimeBinder
{
    public class DateTimeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ArgumentNullException.ThrowIfNull(bindingContext);

            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None && !string.IsNullOrEmpty(valueResult.FirstValue))
            {
                DateTime result = default;
                bool success = false;
                string strValue = valueResult.FirstValue.Trim();

                try
                {
                    result = DateTime.ParseExact(strValue, GetDateTimeFormats(), CultureInfo.InvariantCulture, DateTimeStyles.None);
                    success = true;
                }
                catch (FormatException exception)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, exception, bindingContext.ModelMetadata);
                }

                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(result);
                }
            }

            return Task.CompletedTask;
        }

        private static string[] GetDateTimeFormats()
        {
            return
            [
                "dd/MM/yy",
                "dd/MM/yyyy",
                "dd/MM/yy H:mm",
                "dd/MM/yyyy H:mm",
                "dd/MM/yyyy HH:mm",
                "dd-MM-yy",
                "dd-MM-yyyy",
                "dd-MM-yy H:mm",
                "dd-MM-yyyy H:mm",
                "MM/dd/yy",
                "MM/dd/yyyy",
                "MM/dd/yy H:mm",
                "MM/dd/yyyy H:mm",
                "yyyy-MM-dd",
                "yyyy-MM-dd H:mm",
                "yyyy-MM-dd HH:mm",
            ];
        }
    }
}
