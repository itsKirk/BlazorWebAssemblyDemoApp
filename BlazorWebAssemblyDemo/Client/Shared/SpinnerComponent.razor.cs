using Syncfusion.Blazor.Spinner;
namespace BlazorWebAssemblyDemo.Client.Shared;
public partial class SpinnerComponent
{
    [Parameter] public bool SpinnerVisible { get; set; }
    [Parameter] public string Label { get; set; } = "Loading data...";
    [Parameter] public string LabelWeight { get; set; }
    [Parameter] public SpinnerType SpinnerType { get; set; } = SpinnerType.Material;
}
