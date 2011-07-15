using System;
using System.ComponentModel.DataAnnotations;

namespace SelectLists.Support
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SelectListProvidedByAttribute : UIHintAttribute
    {
        private static readonly Type RequiredType = typeof(ISelectListProvider);

        public Type SelectListProvider { get; private set; }

        public SelectListProvidedByAttribute(Type selectListProvider) : base("SelectListProvider")
        {
            if (!RequiredType.IsAssignableFrom(selectListProvider))
            {
                var message = String.Format("{0} does not implement {1}", selectListProvider, RequiredType);
                throw new ArgumentException(message, "selectListProvider");
            }

            SelectListProvider = selectListProvider;
        }
    }
}