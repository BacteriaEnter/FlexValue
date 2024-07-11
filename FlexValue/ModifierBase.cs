using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public abstract class ModifierBase<T>
{
    public string key;
    public ModiferOperator _modifierOperator;
    public abstract ModiferOperator ModifierOperator { get; }
    public abstract int Priority { get; }

    public abstract T ModifyValue(T value);
    public abstract void SetValue(T value);

}

public enum ModiferOperator
{
    Multiply,
    Add,
    Cover
}