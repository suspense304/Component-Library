
using Component_Library.Models;
using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;
using System.Text;

namespace Component_Library
{
    public partial class RsTable<TableItem> : ComponentBase, IRsTable<TableItem>
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public List<IColumn<TableItem>> Columns { get; } = new List<IColumn<TableItem>>();

        [Parameter]
        public IQueryable<TableItem> ItemsQueryable { get; set; }

        [Parameter]
        public IEnumerable<TableItem> Items { get; set; } = Enumerable.Empty<TableItem>();

        public IEnumerable<TableItem> FilteredItems { get; private set; }
        private ElementReference VisibilityMenuIconRef { get; set; }
        private bool VisibilityMenuOpen { get; set; }

        [Parameter]
        public string GlobalSearch { get; set; }

        [Parameter]
        public bool ShowSearchBar { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await UpdateAsync().ConfigureAwait(false);
        }

        private IEnumerable<TableItem> GetData()
        {
            if (Items == null && ItemsQueryable == null)
            {
                return Items;
            }
            if (Items != null)
            {
                ItemsQueryable = Items.AsQueryable();
            }

            var sortColumn = Columns.Find(x => x.SortColumn);

            if (sortColumn != null)
            {
                ItemsQueryable = sortColumn.SortDescending ?
                    ItemsQueryable.OrderByDescending(sortColumn.Field) :
                    ItemsQueryable.OrderBy(sortColumn.Field);
            }

            return ItemsQueryable.ToList();
        }

        public void AddColumn(IColumn<TableItem> column)
        {
            column.Table = this;

            if (column.Type == null)
            {
                column.Type = column.Field?.GetPropertyMemberInfo().GetMemberUnderlyingType();
            }

            Columns.Add(column);
            Refresh();
        }

        public void Refresh()
        {
            InvokeAsync(StateHasChanged);
        }

        public void RemoveColumn(IColumn<TableItem> column)
        {
            Columns.Remove(column);
            Refresh();
        }

        public async Task UpdateAsync()
        {
            FilteredItems = GetData();
            Refresh();
        }
    }
}