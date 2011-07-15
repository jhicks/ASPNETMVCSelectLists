using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SelectLists.Support
{
    public class CustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var attributeList = attributes.ToList();
            var modelMetadata = base.CreateMetadata(attributeList, containerType, modelAccessor, modelType, propertyName);

            ProvideSelectList(modelType, propertyName, modelMetadata, attributeList);

            return modelMetadata;
        }

        private static void ProvideSelectList(Type modelType, string propertyName, ModelMetadata modelMetadata, IEnumerable<Attribute> attributeList)
        {
            var attr = attributeList.OfType<SelectListProvidedByAttribute>().SingleOrDefault();
            if (attr == null)
            {
                return;
            }

            var providerType = attr.SelectListProvider;

            // NOTE: replace this with some type of IoC in real app
            //var provider = DependencyResolver.Current.GetService(providerType) as ISelectListProvider;
            var provider = Activator.CreateInstance(providerType) as ISelectListProvider;

            if (provider == null)
            {
                throw new Exception(String.Format("Could not find a select list provider of type {0} as defined on property {1} of {2}", providerType, propertyName, modelType));
            }

            provider.Provide(modelMetadata);
        }
    }
}