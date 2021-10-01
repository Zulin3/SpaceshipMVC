using System;

public interface IUserMouseInputProxy
{
    event Action OnMouseClick;

    event Action<float, float> OnMouseMove;
    void InvokeOnMouseMove();
    void InvokeOnMouseClick();
}