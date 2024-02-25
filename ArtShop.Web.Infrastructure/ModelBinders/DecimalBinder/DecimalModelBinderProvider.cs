using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ArtShop.Web.Infrastructure.ModelBinders.DecimalBinder
{
    public class DecimalModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            if (context.Metadata.ModelType == typeof(decimal)
                || context.Metadata.ModelType == typeof(decimal?))
            {
                return new DecimalModelBinder();
            }

            return null;
        }
    }
}
