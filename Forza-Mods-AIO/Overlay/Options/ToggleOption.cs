﻿using System;
using System.Windows;

namespace Forza_Mods_AIO.Overlay.Options;

public class ToggleOption : MenuOption
{
    public bool IsOn
    {
        get => _isOn;
        set
        {
            if (_isOn == value)
            {
                return;
            }
            
            _isOn = value;
            OnToggled();
        }
    }
    private bool _isOn;

    public event EventHandler? Toggled;

    protected virtual void OnToggled()
    {
        var handler = Toggled;
        if (handler == null)
        {
            return;
        }

        Application.Current.Dispatcher.BeginInvoke(() => handler(this, EventArgs.Empty));
    }
    
    public ToggleOption(string name, bool isOn, string? description = null, bool isEnabled = true)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException(@"Name cannot be null or empty.", nameof(name));
        }

        Name = name;
        IsOn = isOn;
        Description = description;
        IsEnabled = isEnabled;
    }
}