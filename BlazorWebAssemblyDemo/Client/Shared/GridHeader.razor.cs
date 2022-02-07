namespace BlazorWebAssemblyDemo.Client.Shared;

public partial class GridHeader
{
    [Parameter] public EventCallback OnButtonClick { get; set; }
    [EditorRequired] [Parameter] public string HeaderText { get; set; }
    [Parameter] public string ButtonText { get; set; }
}
