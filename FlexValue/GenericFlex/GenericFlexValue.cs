using System.Collections.Generic;
using System.Linq;

public class GenericFlexValue<T>
{
    private T _value;
    public T Value => _value;
    private List<ModifierBase<T>> _modifiers = new List<ModifierBase<T>>();
    
    public void AddModifier(ModifierBase<T> modifier)
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
    
    public void RemoveModifier(string key, bool removeAll)
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

    private void RefreshValue(bool sort)
    {
        _value = default;
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

    private int ComparePriority(ModifierBase<T> x, ModifierBase<T> y)
    {
        if (x.Priority == y.Priority)
            return 0;
        return x.Priority > y.Priority ? -1 : 1;
    }
}