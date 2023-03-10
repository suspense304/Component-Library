using Microsoft.AspNetCore.Components;

namespace Component_Library
{
    public interface IRsTable<TableItem> : ITable
    {
        List<IColumn<TableItem>> Columns { get; }
        void AddColumn(IColumn<TableItem> column);
        void RemoveColumn(IColumn<TableItem> column);
        IQueryable<TableItem> ItemsQueryable { get; set; }
        IEnumerable<TableItem> Items { get; set; }
        IEnumerable<TableItem> FilteredItems { get; }
        
    }
}
