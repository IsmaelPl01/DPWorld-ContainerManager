using DpWorldClient.UI.Models;
namespace DpWorldClient.UI.Services
{
    public class FilterStateService
    {
        public FilterState SelectedState { get; set; } = FilterState.None;
        public bool Size20 { get; set; }
        public bool Size40 { get; set; }
        public bool Size45 { get; set; }
        public bool Size48 { get; set; }
        public ContainerType SelectedType { get; set; } = ContainerType.None;
        public PriceOrder SelectedPriceOrder { get; set; } = PriceOrder.None;

        public event Action OnFiltersChanged;

        public void ApplyFilters()
        {
            OnFiltersChanged?.Invoke();
        }

        public void ResetFilters()
        {
            SelectedState = FilterState.None;
            Size20 = false;
            Size40 = false;
            Size45 = false;
            Size48 = false;
            SelectedType = ContainerType.None;
            SelectedPriceOrder = PriceOrder.None;

            OnFiltersChanged?.Invoke();
        }
    }
}
