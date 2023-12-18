using System.ComponentModel;

namespace BlazorUtility;

public class EffectData : INotifyPropertyChanged
{
    private double _value;
    private bool _toggle = true;
    private int _stack = 1;

    public double Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
    }

    public bool Toggle
    {
        get => _toggle;
        set
        {
            if (_toggle != value)
            {
                _toggle = value;
                OnPropertyChanged(nameof(Toggle));
            }
        }
    }

    public int Stack
    {
        get => _stack;
        set
        {
            if (_stack != value)
            {
                _stack = value;
                OnPropertyChanged(nameof(Stack));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}