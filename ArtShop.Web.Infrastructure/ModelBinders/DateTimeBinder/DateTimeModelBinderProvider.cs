using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ArtShop.Web.Infrastructure.ModelBinders.DateTimeBinder
{
    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            if (context.Metadata.ModelType == typeof(DateTime)
                || context.Metadata.ModelType == typeof(DateTime?))
            {
                return new DateTimeModelBinder();
            }

            return null;
        }
    }
}
