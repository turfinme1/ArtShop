using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ArtShop.Web.Infrastructure.ModelBinders.DecimalBinder
{
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ArgumentNullException.ThrowIfNull(bindingContext);

            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None && !string.IsNullOrEmpty(valueResult.FirstValue))
            {
                decimal result = 0M;
                bool success = false;
                string strValue = valueResult.FirstValue.Trim();

                //strValue = strValue.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
                strValue = strValue.Replace(".", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);

                try
                {
                    result = decimal.Parse(strValue, CultureInfo.InvariantCulture);
                    success = true;
                }
                catch (OverflowException exception)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, exception, bindingContext.ModelMetadata);
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
    }
}
