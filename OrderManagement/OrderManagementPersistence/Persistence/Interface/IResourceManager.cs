namespace OrderManagement.Infrastructure.Persistence.Interface
{
    public interface IResourceManager
    {
        string GetLocalResourceString(string resourceSet, string name);
    }
}
