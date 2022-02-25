namespace AnkaYazilim.Blazor.Core.Helpers;

public static class ExtensionFunctions
{
    public static Guid GetEntityId<TEntity>(this TEntity entity)
    {
        var property = typeof(TEntity).GetProperty("Id");
        return (Guid)property.GetValue(entity);
    }

    public static TItem SetSelectedItem<TItem>(this IList<TItem> listDataSource, int index)
    {
        int nextIndex = index;
        if (index == listDataSource.Count)
            nextIndex = index == 0 ? 0 : index - 1;

        if (listDataSource.Count >0)
            return listDataSource[nextIndex];

        return default;


    }
}
