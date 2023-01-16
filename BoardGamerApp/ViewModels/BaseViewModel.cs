using System.ComponentModel;

namespace BoardGamerApp.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    protected void SetProperty<T>(
        ref T field,
        T value,
        string propertyName)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return;

        field = value;
        RaisePropertyChangedEvent(propertyName);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChangedEvent(params string[] propertyNames)
    {
        foreach(var propertyName in propertyNames)
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
