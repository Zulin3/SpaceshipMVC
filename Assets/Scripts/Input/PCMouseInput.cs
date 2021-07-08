using System;
using UnityEngine;

public sealed class PCMouseInput : IUserMouseInputProxy
{
    public PCMouseInput()
    {
    }

    public event Action<float, float> OnMouseMove = delegate (float x, float y) { };

    public void InvokeOnMouseMove()
    {
        OnMouseMove.Invoke(Input.mousePosition.x, Input.mousePosition.y);
    }
}
