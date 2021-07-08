using UnityEngine;

internal sealed class InputController: IExecute
{
    private IUserInputProxy _userPcInputHorizontal;
    private IUserInputProxy _userPcInputVertical;

    private IUserMouseInputProxy _mouseInput;

    public InputController()
    {
        // Switch other platforms input here.
        _userPcInputHorizontal = new PCInput(AxisManager.HORIZONTAL);
        _userPcInputVertical = new PCInput(AxisManager.VERTICAL);

        _mouseInput = new PCMouseInput();
    }

    public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) GetKeyboardInput()
    {
        return (_userPcInputHorizontal, _userPcInputVertical);
    }
    
    public IUserMouseInputProxy GetMouseInput()
    {
        return _mouseInput;
    }

    public void Execute(float deltaTime)
    {
        _userPcInputHorizontal.InvokeAxisChange();
        _userPcInputVertical.InvokeAxisChange();
        _mouseInput.InvokeOnMouseMove();
    }

    public void Initialize()
    {
    }
}
