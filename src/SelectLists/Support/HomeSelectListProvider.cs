using System.Collections.Generic;
using System.Web.Mvc;

namespace SelectLists.Support
{
    public class HomeSelectListProvider : SelectListProviderBase
    {
        protected override IEnumerable<SelectListItem> GetListItems()
        {
            for (var counter = 1; counter < 6; counter++)
            {
                yield return new SelectListItem
                {
                    Text = "Home " + counter, Value = counter.ToString()
                };
            }
        }
    }
}