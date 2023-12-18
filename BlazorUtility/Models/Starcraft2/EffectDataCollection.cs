using System.ComponentModel;

namespace BlazorUtility;

public class EffectDataCollection : INotifyPropertyChanged
{
    private double _baseValue = 0;

    private readonly List<EffectData> _effects;

    public IEnumerable<EffectData> Effects => _effects.AsReadOnly();

    public event PropertyChangedEventHandler? PropertyChanged;

    public EffectDataCollection() => _effects = [];

    public double BaseValue
    {
        get => _baseValue;
        set
        {
            _baseValue = Math.Round(value, 2);
            OnPropertyChanged(nameof(BaseValue));
        }
    }

    public void Add()
    {
        var newEffectData = new EffectData();
        _effects.Add(newEffectData);
        newEffectData.PropertyChanged += ItemPropertyChanged;
        OnPropertyChanged(nameof(Effects));
    }

    public void Remove(EffectData effectData)
    {
        if (_effects.Contains(effectData))
        {
            effectData.PropertyChanged -= ItemPropertyChanged;
            _effects.Remove(effectData);
            OnPropertyChanged(nameof(Effects));
        }
    }

    private void ItemPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        // Optionally, handle the PropertyChanged event of each EffectData item here
        // For example, you can raise a PropertyChanged event for the "Effects" property
        // if a property of an EffectData item changes:
        OnPropertyChanged(e.PropertyName ?? "");
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Cleanup()
    {
        //foreach (var effect in _effects)
        //{
        //    effect.PropertyChanged -= ItemPropertyChanged;
        //}
        // Optionally, clear the list if the items are no longer needed
        _effects.Clear();
    }
}