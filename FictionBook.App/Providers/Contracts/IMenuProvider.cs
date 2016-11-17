using System.Collections.Generic;
using FictionBook.App.Core.UI;

namespace FictionBook.App.Providers.Contracts
{
    public interface IMenuProvider
    {
        IEnumerable<MenuItem> GetMainMenuItems();
        IEnumerable<MenuItem> GetOptionsMenuItems();
    }
}
