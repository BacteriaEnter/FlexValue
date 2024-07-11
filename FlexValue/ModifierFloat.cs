using System;
using UnityEngine;
[Serializable]
public class ModifierFloat : ModifierBase<float>
{
    [SerializeField] private float _modifyValue;
    public override ModiferOperator ModifierOperator => _modifierOperator;
    public override int Priority => (int)ModifierOperator;

    public override float ModifyValue(float value)
    {
        return _modifierOperator switch
        {
            ModiferOperator.Multiply => value * _modifyValue,
            ModiferOperator.Add => value + _modifyValue,
            _ => _modifyValue
        };
    }

    public override void SetValue(float value)
    {
        _modifyValue = value;
    }


    public ModifierFloat()
    {
        
    }

    public ModifierFloat(string key,float value, ModiferOperator modiferOperator)
    {
        this.key = key;
        _modifyValue = value;
        _modifierOperator = modiferOperator;
    }
}