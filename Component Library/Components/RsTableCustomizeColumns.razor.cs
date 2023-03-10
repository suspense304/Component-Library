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
using System.ComponentModel;

namespace Component_Library
{
    public partial class RsTableCustomizeColumns
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object> UnknownParameters { get; set; }

        [Parameter]
        public EventCallback<bool> IsOpenChanged { get; set; }

        [Parameter]
        public bool? IsOpen
        {
            get => _isOpen;
            set
            {
                if (value != null)
                {
                    Manual = true;
                    if (value.Value != _isOpen)
                    {
                        Changed(value ?? false);
                        StateHasChanged();
                    }
                    _isOpen = value ?? false;
                }
            }
        }

        [Parameter]
        public Placement Placement { get; set; } = Placement.Auto;

        [Parameter]
        public ElementReference Reference { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool DismissOnNextClick { get; set; } = true;

        public bool Manual { get; set; }

        private bool _isOpen { get; set; }

        protected virtual Task Changed(bool e)
        {
            return Task.CompletedTask;
        }

        public virtual void Hide()
        {
            _isOpen = false;
            if (!Manual) Changed(_isOpen);
            IsOpenChanged.InvokeAsync(false);
        }

        protected ElementReference MyRef { get; set; }
       

        protected void OnClick()
        {
            if (DismissOnNextClick)
            {
                Hide();
            }
        }
    }

    public enum Placement
    {
        [Description("auto")]
        Auto,

        [Description("auto-start")]
        AutoStart,

        [Description("auto-end")]
        AutoEnd,

        [Description("top")]
        Top,

        [Description("top-start")]
        TopStart,

        [Description("top-end")]
        TopEnd,

        [Description("right")]
        Right,

        [Description("right-start")]
        RightStart,

        [Description("right-end")]
        EightEnd,

        [Description("bottom")]
        Bottom,

        [Description("bottom-start")]
        BottomStart,

        [Description("bottom-end")]
        BottomEnd,

        [Description("left")]
        Left,

        [Description("left-start")]
        LeftStart,

        [Description("left-end")]
        LeftEnd
    }
}
