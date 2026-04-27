using OrderManagement.Infrastructure.Persistence.Interface;

namespace OrderManagement.Infrastructure.Persistence.Service
{
    public class DefaultResourceManager : IResourceManager
    {
        public string GetLocalResourceString(string resourceSet, string name)
        {
            return name;
        }
    }
}
