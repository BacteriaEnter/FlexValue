
using System;
using UnityEngine;

public class GenericFlexTest:MonoBehaviour
{
    private GenericFlexValue<float> gFlex=new GenericFlexValue<float>();

    private void Start()
    {
        gFlex.AddModifier(new ModifierFloat("add1",1,ModiferOperator.Add));
        gFlex.AddModifier(new ModifierFloat("mul1",10,ModiferOperator.Multiply));
        gFlex.AddModifier(new ModifierFloat("add2",22,ModiferOperator.Add));
        
        Debug.Log($"Health value changed.Now:{gFlex.Value}");
    }
}