﻿using System;

namespace RoverGUI.Mvvm
{
    public class WeakAction
    {
        private readonly Action _action;

        private readonly WeakReference _reference;

        public WeakAction(Action action)
            : this(action.Target, action)
        {
        }

        public WeakAction(object target, Action action)
        {
            if (target != null)
            {
                _reference = new WeakReference(target);
            }
            _action = action;
        }

        public void Execute()
        {
            if ((_action != null) && (IsAlive || IsStatic))
            {
                _action();
            }
        }

        public Action Action
        {
            get
            {
                return _action;
            }
        }

        public bool IsAlive
        {
            get
            {
                if (_reference == null)
                {
                    return false;
                }
                return _reference.IsAlive;
            }
        }

        public bool IsStatic
        {
            get
            {
                return ((_action != null) && (_action.Target == null));
            }
        }
    }
}