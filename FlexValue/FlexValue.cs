using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

[Serializable]
public abstract class FlexValue<T>
{
    [SerializeField] protected T _value;
    public T Value => _value;

    public abstract void RemoveModifier(string key, bool removeAll);

    protected abstract void RefreshValue(bool sort);

    protected int ComparePriority(ModifierBase<T> x, ModifierBase<T> y)
    {
        if (x.Priority == y.Priority)
            return 0;
        return x.Priority > y.Priority ? -1 : 1;
    }
}