namespace DpWorldClient.UI.Services;

public class ContainerSelectionService
{
    private HashSet<string> _selectedContainerIds = new HashSet<string>();
    
    public event Action OnChange;

    public bool IsSelected(string containerId) => _selectedContainerIds.Contains(containerId);

    public void ToggleSelection(string containerId)
    {
        if (_selectedContainerIds.Contains(containerId))
            _selectedContainerIds.Remove(containerId);
        else
            _selectedContainerIds.Add(containerId);
        
        OnChange?.Invoke();
    }

    public void SetAllSelected(IEnumerable<string> containerIds, bool isSelected)
    {
        if (isSelected)
            _selectedContainerIds.UnionWith(containerIds);
        else
            _selectedContainerIds.ExceptWith(containerIds);
        
        OnChange?.Invoke();
    }

    public IReadOnlyCollection<string> GetSelectedContainerIds() => _selectedContainerIds;
}