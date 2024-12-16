using ReactiveUI.Fody.Helpers;

namespace AvaloniaApplication10.Models;

public class StrClass 
{
    public string Str { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeactivate => !IsActive;
}