using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SelectLists.Support
{
    public class EnumSelectListProvider<TEnum> : SelectListProviderBase
    {
        protected override IEnumerable<SelectListItem> GetListItems()
        {
            var enumType = typeof (TEnum);
            var values = Enum.GetValues(enumType);
            return from object entry in values
                   select new SelectListItem
                   {
                       Text = Enum.GetName(enumType, entry),
                       Value = entry.ToString()
                   };
        }
    }
}