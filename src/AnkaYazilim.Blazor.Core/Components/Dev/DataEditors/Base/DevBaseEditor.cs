using DevExpress.Blazor;
using DevExpress.Blazor.Base;
using Microsoft.AspNetCore.Components;

namespace AnkaYazilim.Blazor.Core.Components.Dev.DataEditors.Base
{
    public class DevBaseEditor : DxComponentBase
    {
        [Parameter] public int ColumnIndex { get; set; }
        [Parameter] public int ColumnSpan { get; set; }
        [Parameter] public string LayoutItemCssClass { get; set; }
        [Parameter] public int RowIndex { get; set; }
        [Parameter] public int RowSpan { get; set; }
        [Parameter] public bool Visible { get; set; } = true;
        [Parameter] public DataEditorClearButtonDisplayMode ClearButtonDisplayMode { get; set; } = DataEditorClearButtonDisplayMode.Never;
        [Parameter] public string EditorCssClass { get; set; }
        [Parameter] public bool Enabled { get; set; } = true;
        [Parameter] public string InpurCssClass { get; set; }
        [Parameter] public string NullText { get; set; }
        [Parameter] public bool ReadOnly { get; set; }
        [Parameter] public string Caption { get; set; }
        [Parameter] public string CaptionCssClass { get; set; } = "caption";
        [Parameter] public bool CaptionVisible { get; set; }=true;
        [Parameter] public string SeperateCaption { get; set; } = ":";
        [Parameter] public bool SeperateCaptionVisible { get; set; }=true ;
        [Parameter] public bool IsFocus { get; set; }


    }
}
