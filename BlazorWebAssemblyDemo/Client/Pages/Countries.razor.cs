using Syncfusion.Blazor.Grids;

namespace BlazorWebAssemblyDemo.Client.Pages;
public partial class Countries
{
    [Inject] public ICountryRepository CountryRepository { get; set; }
    [Inject] private NavigationManager Navigation { get; set; }
    private bool SpinnerVisible { get; set; }

    private IEnumerable<Country> _countries = new List<Country>();
    protected async override Task OnInitializedAsync()
    {
        SpinnerVisible = true;
        _countries = await CountryRepository.GetCountriesAsync();
        SpinnerVisible = false;
    }
    private void RecordDoubleClickHandler(RecordDoubleClickEventArgs<Country> args)
    {
        //todo- load a card for country data
    }
}
