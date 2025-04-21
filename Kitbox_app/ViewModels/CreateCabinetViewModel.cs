using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Kitbox_app.Services;
using System.Collections.ObjectModel;

namespace Kitbox_app.ViewModels;

public partial class CreateCabinetViewModel : ViewModelBase
{
    private readonly INavigationService _navigation;

    [ObservableProperty]
    private ObservableCollection<string> heightOptions = new() { "32", "40", "56" };

    [ObservableProperty]
    private ObservableCollection<string> widthOptions = new() { "62", "100" };

    [ObservableProperty]
    private ObservableCollection<string> depthOptions = new() { "50", "60" };

    [ObservableProperty]
    private string selectedHeight;

    [ObservableProperty]
    private string selectedWidth;

    [ObservableProperty]
    private string selectedDepth;

    [ObservableProperty]
    private ObservableCollection<string> lockers = new();

    public bool CanAddLocker => Lockers.Count < 7;

    public CreateCabinetViewModel(INavigationService navigation)
    {
        _navigation = navigation;

        SelectedHeight = HeightOptions[0];
        SelectedWidth = WidthOptions[0];
        SelectedDepth = DepthOptions[0];
    }

    [RelayCommand]
    private void AddLocker()
    {
        if (CanAddLocker)
        {
            Lockers.Add($"Locker - H:{SelectedHeight}, W:{SelectedWidth}, D:{SelectedDepth}");
            OnPropertyChanged(nameof(CanAddLocker));
        }
    }

    [RelayCommand]
    private void RemoveLocker(string locker)
    {
        Lockers.Remove(locker);
        OnPropertyChanged(nameof(CanAddLocker));
    }

    [RelayCommand]
    private void GoBack()
    {
        _navigation.NavigateTo(new HomeViewModel(_navigation));
    }
}
