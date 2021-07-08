using System;

public interface IUserInputProxy
{
    event Action<float> AxisOnChange;
    void InvokeAxisChange();
}
