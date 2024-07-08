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
}