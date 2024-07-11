using System.Collections.Generic;
using System.Linq;

public class FlexValueInt:FlexValue<int>
{
    private List<ModifierInt> _modifiers = new List<ModifierInt>();
    
    public void AddModifier(ModifierInt modifier)
    {
        bool sort = true;
        if (modifier.ModifierOperator == ModiferOperator.Cover)
        {
            _modifiers.Insert(0, modifier);
            sort = false;
        }
        else
        {
            _modifiers.Add(modifier);
        }
        
        RefreshValue(sort);
    }

    
    public override void RemoveModifier(string key, bool removeAll)
    {
        if (_modifiers.All(x => x.key != key))
        {
            return;
        }
        
        if (removeAll)
        {
            _modifiers.RemoveAll(modifier => modifier.key == key);
        }
        else
        {
            _modifiers.Remove(_modifiers.First(modifier => modifier.key == key));
        }
        
        RefreshValue(true);
    }
    
    
    protected override void RefreshValue(bool sort)
    {
        _value = 0;
        if (_modifiers.Count<=0)
        {
            return;
        }
        if (sort)
        {
            _modifiers.Sort(ComparePriority);
        }
        foreach (var modifier in _modifiers)
        {
            _value = modifier.ModifyValue(_value);
            if (modifier.ModifierOperator == ModiferOperator.Cover)
            {
                return;
            }
        }
    }
    
}

