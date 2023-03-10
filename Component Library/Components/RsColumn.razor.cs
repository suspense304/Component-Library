using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using Component_Library;
using Component_Library.Shared;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;

namespace Component_Library
{
    public partial class RsColumn<TableItem> : ComponentBase, IColumn<TableItem>
    {
        [CascadingParameter(Name = "Table")]
        public IRsTable<TableItem> Table { get; set; }

        private string _title;

        [Parameter]
        public string Title {
            get { return _title ?? Field.GetPropertyMemberInfo()?.Name; }
            set { _title = value; }
        }
        [Parameter]
        public string Width { get; set; }
        [Parameter]
        public bool Sortable { get; set; }
        [Parameter]
        public bool Hideable { get; set; }

        private bool _visible = true;
        public bool Visible {
            get { return _visible; }
            set
            {
                _visible = value;
                Table.Refresh();
            }
        }
        [Parameter]
        public Type Type { get; set; }

        [Parameter]
        public Expression<Func<TableItem, object>> Field { get; set; }

        public RenderFragment<TableItem> Template { get; set; }
        public bool SortColumn { get;set; } 
        public bool SortDescending { get; set; }

        [Parameter]
        public Alignment Align { get; set; }

        protected override void OnInitialized()
        {
            Table.AddColumn(this);
        }

        protected override void OnParametersSet()
        {
            if ((Sortable && Field == null) || (Field == null))
            {
                throw new InvalidOperationException($"Column {Title} Property parameter is null");
            }

            if (Title == null && Field == null)
            {
                throw new InvalidOperationException("A Column has both Title and Property parameters null");
            }

            if (Type == null)
            {
                Type = Field?.GetPropertyMemberInfo().GetMemberUnderlyingType();
            }
        }

        public string Render(TableItem item)
        {
            if (item == null || Field == null) return string.Empty;

            if (renderCompiled == null)
                renderCompiled = Field.Compile();

            object value = null;

            try
            {
                value = renderCompiled.Invoke(item);
            }
            catch (NullReferenceException) { }

            if (value == null) return string.Empty;

            return string.Format(CultureInfo.CurrentCulture, $"{value}");
        }

        public async Task SortByAsync()
        {
            if (Sortable)
            {
                if (SortColumn)
                {
                    SortDescending = !SortDescending;
                }

                Table.Columns.ForEach(x => x.SortColumn = false);

                SortColumn = true;

                await Table.UpdateAsync().ConfigureAwait(false);
            }
        }

        private Func<TableItem, object> renderCompiled;
    }
}