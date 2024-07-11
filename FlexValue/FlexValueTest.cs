using System;
using UnityEngine;

public class FlexValueTest:MonoBehaviour
{
    public FlexValueFloat health;
    public FlexValueInt atk;


    private void Start()
    {
        Debug.Log($"Health value changed.Now:{health.Value}");
        Debug.Log($"Atk value changed.Now:{atk.Value}");
    }
}