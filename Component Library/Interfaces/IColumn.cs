using Microsoft.AspNetCore.Components;
using System.Linq;
using System.Linq.Expressions;

namespace Component_Library
{
    public interface IColumn<TableItem>
    {
        IRsTable<TableItem> Table { get; set; }
        string Title { get; set; }  
        string Width { get; set; }
        bool Sortable { get; set; }
        bool Hideable { get; set; }
        bool Visible { get; set; }
        Task SortByAsync();
        Type Type { get; set; }
        Expression<Func<TableItem, object>> Field { get;}
        RenderFragment<TableItem> Template { get; set; }
        bool SortColumn { get; set; }
        bool SortDescending { get; set; }
        string AriaSort => SortColumn ? (SortDescending ? "descending" : "ascending") : null;
        Alignment Align { get; set; }
        string Render(TableItem item);
    }
}
