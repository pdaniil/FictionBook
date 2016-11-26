namespace Books.App.Providers.Contracts
{
    using System.Collections.Generic;

    using Models.Controls;

    public interface IMenuProvider
    {
        IEnumerable<MenuItem> GetMainMenuItems();
        IEnumerable<MenuItem> GetOptionsMenuItems();
    }
}
