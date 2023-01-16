using BoardGamerApp.Enums;

namespace BoardGamerApp.ViewModels;

public class RatingViewModel : BaseViewModel
{
    private Rating? value;
    public Rating? Value
    {
        get { return value; }
        set
        {
            if (this.value == value) return;
            this.value = value;

            RaisePropertyChangedEvent(
                nameof(Glad),
                nameof(Mad),
                nameof(Sad));
        }
    }

    public Color Glad => GetColor(Rating.Glad);
    public Color Mad => GetColor(Rating.Mad);
    public Color Sad => GetColor(Rating.Sad);

    private Color GetColor(Rating rating) =>
        Value == rating
        ? Colors.Yellow
        : Colors.Transparent;
}
