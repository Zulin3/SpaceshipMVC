using System;

public interface IUserMouseInputProxy
{
    event Action<float, float> OnMouseMove;
    void InvokeOnMouseMove();
}