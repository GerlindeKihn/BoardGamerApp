using System.ComponentModel;

namespace BoardGamerApp.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    protected void SetProperty<T>(
        ref T field,
        T value,
        string propertyName,
        IEqualityComparer<T> comparer = null)
    {
        comparer ??= EqualityComparer<T>.Default;
        if (comparer.Equals(field, value)) return;

        field = value;
        RaisePropertyChangedEvent(propertyName);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void RaisePropertyChangedEvent(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
