using System.Web.Mvc;

namespace SelectLists.Support
{
    public interface ISelectListProvider
    {
        void Provide(ModelMetadata modelMetadata);
    }
}