﻿using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RoverGUI.Mvvm
{
    public abstract class ViewModelBase : ObservableObject
    {
        protected Dictionary<string, object> Values = new Dictionary<string, object>();

        protected bool SetValue<T>(T value, [CallerMemberName] string propertyName = "")
        {
            if (Values.ContainsKey(propertyName) && EqualityComparer<T>.Default.Equals((T)Values[propertyName], value))
                return false;

            Values[propertyName] = value;

            OnPropertyChanged(propertyName);

            return true;
        }

        protected T GetValue<T>([CallerMemberName] string propertyName = "")
        {
            if (!Values.ContainsKey(propertyName))
                return default(T);

            return (T) Values[propertyName];
        }
    }
}