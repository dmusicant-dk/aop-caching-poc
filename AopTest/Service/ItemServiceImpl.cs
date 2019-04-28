using Interception.Caching;

namespace AopTest.Service
{
    public class ItemServiceImpl : ItemService
    {
        [Cacheable("ItemCache")]
        public string getItem(string name)
        {
            return "one";
        }
    }
}