using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PluginConnector : MonoBehaviour
{
    public delegate uint FuncDelegate(uint handle);

    private uint _incValue = 13;

    [DllImport("plugin")]
    private static extern void SetValueInPlugin(uint value);

    [DllImport("plugin")]
    private static extern uint GetValueFromPlugin();

    [DllImport("plugin")]
    private static extern void SetUnityFunction(FuncDelegate func);

    [DllImport("plugin")]
    private static extern void CallUnityFunction();

    private static uint StaticIncrease(uint value)
    {
        return value + 1;
    }

    private uint InstanceIncrease(uint value)
    {
        return value + _incValue;
    }

    void Start()
    {
        uint value = 42;
        Debug.Log("Sending value " + value + " to plugin");
        SetValueInPlugin(value);
        Debug.Log("Retrieving value");
        var value2 = GetValueFromPlugin();
        Debug.Log("Result: " + value2);

        Debug.Log("Increasing value using static function");
        SetUnityFunction(StaticIncrease);
        CallUnityFunction();
        value2 = GetValueFromPlugin();
        Debug.Log("Result: " + value2);

        Debug.Log("Increasing value using instance function");
        Debug.Log("Increasing by " + _incValue);
        SetUnityFunction(InstanceIncrease);
        CallUnityFunction();
        value2 = GetValueFromPlugin();
        Debug.Log("Result: " + value2);

        _incValue = 37;
        Debug.Log("Increasing by " + _incValue);
        CallUnityFunction();
        value2 = GetValueFromPlugin();
        Debug.Log("Result: " + value2);
    }

    void Update()
    {
    }
}