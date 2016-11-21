using System.Collections.Generic;
using Books.App.Core.UI;

namespace Books.App.Providers.Contracts
{
    public interface IMenuProvider
    {
        IEnumerable<MenuItem> GetMainMenuItems();
        IEnumerable<MenuItem> GetOptionsMenuItems();
    }
}
