using System;
using UnityEngine;

public sealed class PCInput : IUserInputProxy
{
    private string _axis;

    public PCInput(string Axis)
    {
        _axis = Axis;
    }

    public event Action<float> AxisOnChange = delegate(float f) { };

    public void InvokeAxisChange()
    {
        AxisOnChange.Invoke(Input.GetAxis(_axis));
    }
}
