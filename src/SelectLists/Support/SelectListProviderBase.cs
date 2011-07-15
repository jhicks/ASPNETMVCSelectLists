using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SelectLists.Support
{
    public abstract class SelectListProviderBase : ISelectListProvider
    {
        private static readonly SelectListItem EmptyItem = new SelectListItem {Text = "",Value = ""};

    public void Provide(ModelMetadata modelMetadata)
    {
        var modelType = modelMetadata.ModelType;
        var value = modelMetadata.Model;

        var items = new List<SelectListItem>();
        items.AddRange(GetListItems());

        object selectList;
        if (modelType.IsArray)
        {
            selectList = new MultiSelectList(items, "Value", "Text", value as Array);
        }
        else
        {
            if (modelType.IsClass || (modelType.IsGenericType && modelType.GetGenericTypeDefinition().Equals(typeof(Nullable<>))))
            {
                items.Insert(0,EmptyItem);
            }

            selectList = new SelectList(items, "Value", "Text", value);
        }
        modelMetadata.AdditionalValues.Add("SelectList", selectList);
    }

        protected abstract IEnumerable<SelectListItem> GetListItems();
    }
}