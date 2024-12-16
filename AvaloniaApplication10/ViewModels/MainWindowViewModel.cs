using System;
using System.Collections.ObjectModel;
using System.Linq;
using AvaloniaApplication10.Models;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaApplication10.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    #region Properties
    
    public ObservableCollection<StrClass> StrItems { get; set; } = [];
    
    /*private readonly SourceList<StrClass> _strItemsSource = new();
    
    private readonly ReadOnlyObservableCollection<StrClass> _strItems;
    public ReadOnlyObservableCollection<StrClass> StrItems => _strItems;*/
    
    [Reactive] public string? InputSearchText { get; set; }

    #endregion

    public MainWindowViewModel()
    {
        InitStrItems();

        this.WhenValueChanged(x => x.InputSearchText)
            .Subscribe(inputSearchText =>
            {
                if (string.IsNullOrWhiteSpace(inputSearchText))
                {
                    InitStrItems();
                }
                else
                {
                    InitStrItems();
                    var temp = StrItems.ToList();
                    StrItems.Clear();

                    var items = temp.Where(i => i.Str.Contains(InputSearchText!));
                    StrItems.AddRange(items);
                }
            });
        /*_strItemsSource
            .Connect()
            .Filter(i => i.Str.Contains(InputSearchText ?? string.Empty))
            .ObserveOn(RxApp.MainThreadScheduler)
            .Bind(out _strItems)
            .DisposeMany()
            .Subscribe();*/
    }

    private void InitStrItems()
    {
        StrItems.Clear();
        
        StrItems.Add(new StrClass { Str = "1", IsActive = true });
        StrItems.Add(new StrClass { Str = "11", IsActive = true });
        StrItems.Add(new StrClass { Str = "111", IsActive = true });
        StrItems.Add(new StrClass { Str = "11", IsActive = false });
        
        StrItems.Add(new StrClass { Str = "2", IsActive = true });
        StrItems.Add(new StrClass { Str = "22", IsActive = true });
        StrItems.Add(new StrClass { Str = "222", IsActive = true });
        StrItems.Add(new StrClass { Str = "22", IsActive = false });
        
        StrItems.Add(new StrClass { Str = "3", IsActive = true });
        StrItems.Add(new StrClass { Str = "311", IsActive = true });
        StrItems.Add(new StrClass { Str = "3111", IsActive = true });
        StrItems.Add(new StrClass { Str = "311", IsActive = false });
        
        /*_strItemsSource.Add(new StrClass { Str = "1", IsActive = true });
        _strItemsSource.Add(new StrClass { Str = "11", IsActive = true });
        _strItemsSource.Add(new StrClass { Str = "111", IsActive = true });
        _strItemsSource.Add(new StrClass { Str = "11", IsActive = false });
        
        _strItemsSource.Add(new StrClass { Str = "2", IsActive = true });
        _strItemsSource.Add(new StrClass { Str = "22", IsActive = true });
        _strItemsSource.Add(new StrClass { Str = "222", IsActive = true });
        _strItemsSource.Add(new StrClass { Str = "22", IsActive = false });
        
        _strItemsSource.Add(new StrClass { Str = "3", IsActive = true });
        _strItemsSource.Add(new StrClass { Str = "311", IsActive = true });
        _strItemsSource.Add(new StrClass { Str = "3111", IsActive = true });
        _strItemsSource.Add(new StrClass { Str = "311", IsActive = false });*/
    }
}