using System;
using UnityEngine;
[Serializable]
public class ModifierInt: ModifierBase<int>
{
    [SerializeField] private int _modifyValue;
    public override ModiferOperator ModifierOperator => _modifierOperator;
    public override int Priority => (int)ModifierOperator;
    public override int ModifyValue(int value)
    {
        return _modifierOperator switch
        {
            ModiferOperator.Multiply => value * _modifyValue,
            ModiferOperator.Add => value + _modifyValue,
            _ => _modifyValue
        };
    }
    
    public override void SetValue(int value)
    {
        _modifyValue = value;
    }
    
    public ModifierInt()
    {
        
    }

    public ModifierInt(string key,int value, ModiferOperator modiferOperator)
    {
        this.key = key;
        _modifyValue = value;
        _modifierOperator = modiferOperator;
    }
}