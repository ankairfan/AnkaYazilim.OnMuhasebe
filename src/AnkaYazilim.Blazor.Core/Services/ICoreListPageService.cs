﻿namespace AnkaYazilim.Blazor.Core.Services;

public interface ICoreListPageService
{
    public bool ToolbarCheckBoxVisible { get; set; }
    public bool IsActiveCards { get; set; }
    public string LoadingCaption { get; }
    public string LoadingText { get; }
    public bool IsPopUpListPage { get; set; }
    public bool EditPageVisible { get; set; }




}
