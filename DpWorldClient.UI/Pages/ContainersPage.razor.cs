using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using DpWorldClient.UI.Models;
using DpWorldClient.UI.Services;
using System.Text.Json;

namespace DpWorldClient.UI.Pages;

public partial class ContainersPage
{
    [Inject] private FilterStateService FilterStateService { get; set; }
    [CascadingParameter] private Action ToggleFilterDrawer { get; set; }

    private string SelectedCategory = "Contenedores";
    private string SearchTerm = string.Empty;

    private List<string> AvailableCategories = new List<string> { "Contenedores", "Otros" };
    private List<ContainerModel> Containers = new List<ContainerModel>();

    private HashSet<string> SelectedContainerIds = new HashSet<string>();

    protected override async Task OnInitializedAsync()
    {
        FilterStateService.OnFiltersChanged += OnFiltersChanged;
        await LoadContainersAsync();
    }

    private async void OnFiltersChanged()
    {
        await LoadContainersAsync();
        StateHasChanged();
    }

    private async Task LoadContainersAsync()
    {
        try
        {
            var queryParams = new List<string>();

            if (FilterStateService.SelectedState != FilterState.None)
                queryParams.Add($"lineHold={Uri.EscapeDataString(FilterStateService.SelectedState.ToString())}");

            if (FilterStateService.Size20 || FilterStateService.Size40 || FilterStateService.Size45 || FilterStateService.Size48)
            {
                var sizes = new List<string>();
                if (FilterStateService.Size20) sizes.Add("20");
                if (FilterStateService.Size40) sizes.Add("40");
                if (FilterStateService.Size45) sizes.Add("45");
                if (FilterStateService.Size48) sizes.Add("48");

                queryParams.Add($"sizes={Uri.EscapeDataString(string.Join(",", sizes))}");
            }

            if (FilterStateService.SelectedType != ContainerType.None)
                queryParams.Add($"containerType={Uri.EscapeDataString(FilterStateService.SelectedType.ToString())}");

            if (!string.IsNullOrEmpty(SearchTerm))
                queryParams.Add($"searchTerm={Uri.EscapeDataString(SearchTerm)}");

            if (FilterStateService.SelectedPriceOrder != PriceOrder.None)
            {
                queryParams.Add($"priceOrder={FilterStateService.SelectedPriceOrder.ToString().ToUpper()}");
            }

            var queryString = string.Join("&", queryParams);
            var url = "http://localhost:5000/api/containers";

            if (!string.IsNullOrEmpty(queryString))
                url += "?" + queryString;

            var response = await Http.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

                var webResponse = JsonSerializer.Deserialize<WebResponse<List<ContainerModel>>>(jsonString, options);

                if (webResponse?.IsSuccess == true)
                {
                    Containers = webResponse.Body ?? new List<ContainerModel>();
                }
                else
                {
                    Containers = new List<ContainerModel>();
                }
            }
            else
            {
                Containers = new List<ContainerModel>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió una excepción: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
            Containers = new List<ContainerModel>();
        }

        PageNumber = 1;
    }

    private IEnumerable<ContainerModel> FilteredContainers => Containers
        .Where(c =>
            (string.IsNullOrEmpty(SearchTerm) || c.ContainerNo.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
            && SelectedCategory == "Contenedores");

    private int TotalContainers => FilteredContainers.Count();

    private bool AreAllContainersSelected => FilteredContainers.All(c => SelectedContainerIds.Contains(c.RecordId)) && FilteredContainers.Any();

    private async Task OnSearchTermChanged()
    {
        await LoadContainersAsync();
    }

    private void ToggleSelectAllContainers()
    {
        var allContainerIds = FilteredContainers.Select(c => c.RecordId).ToList();
        bool selectAll = !AreAllContainersSelected;

        if (selectAll)
        {
            foreach (var id in allContainerIds)
            {
                SelectedContainerIds.Add(id);
            }
        }
        else
        {
            foreach (var id in allContainerIds)
            {
                SelectedContainerIds.Remove(id);
            }
        }
    }

    private bool IsContainerSelected(string containerId)
    {
        return SelectedContainerIds.Contains(containerId);
    }

    private void OnContainerCheckboxChanged(string containerId, bool isSelected)
    {
        if (isSelected)
        {
            SelectedContainerIds.Add(containerId);
        }
        else
        {
            SelectedContainerIds.Remove(containerId);
        }
    }

    private List<ContainerModel> SelectedContainers =>
        Containers.Where(c => SelectedContainerIds.Contains(c.RecordId)).ToList();

    private double TotalSelectedAmount => SelectedContainers.Sum(c => c.TotalChargedAmount);

    private void Proceed()
    {
        Console.WriteLine("Procediendo con los contenedores seleccionados...");
        // Aquí puedes agregar la lógica para proceder con los contenedores seleccionados
    }

    private int _pageSize = 3;
    public int PageSize
    {
        get => _pageSize;
        set
        {
            if (_pageSize != value)
            {
                _pageSize = value;
                PageNumber = 1;
                StateHasChanged();
            }
        }
    }

    private int PageNumber = 1;
    private List<int> PageSizeOptions = new List<int> { 3, 9, 12 };
    private int TotalPages => (int)Math.Ceiling((double)TotalContainers / PageSize);
    private IEnumerable<ContainerModel> PaginatedContainers => FilteredContainers
        .Skip((PageNumber - 1) * PageSize)
        .Take(PageSize);

    private void NavigateToDetails(string recordId)
    {
        NavigationManager.NavigateTo($"/container-detail/{recordId}");
    }

    private void PreviousPage()
    {
        if (PageNumber > 1)
        {
            PageNumber--;
        }
    }

    private void NextPage()
    {
        if (PageNumber < TotalPages)
        {
            PageNumber++;
        }
    }
}
