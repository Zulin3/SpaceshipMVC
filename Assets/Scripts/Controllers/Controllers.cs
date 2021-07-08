using System.Collections.Generic;
using UnityEngine;

public sealed class Controllers : IInitialization, IExecute, IFixedExecute, ICleanup
{
    private readonly List<IInitialization> _initControllers;
    private readonly List<IExecute> _executeControllers;
    private readonly List<IFixedExecute> _fixedExecControllers;
    private readonly List<ICleanup> _cleanupControllers;

    internal Controllers()
    {
        _initControllers = new List<IInitialization>();
        _executeControllers = new List<IExecute>();
        _fixedExecControllers = new List<IFixedExecute>();
        _cleanupControllers = new List<ICleanup>();
    }

    internal Controllers Add(IController controller)
    {
        if (controller is IInitialization initCon)
        {
            _initControllers.Add(initCon);
        }

        if (controller is IExecute execCon)
        {
            _executeControllers.Add(execCon);
        }

        if (controller is IFixedExecute fixedExecCon)
        {
            _fixedExecControllers.Add(fixedExecCon);
        }

        if (controller is ICleanup cleanCon)
        {
            _cleanupControllers.Add(cleanCon);
        }

        return this;
    }

    public void Cleanup()
    {
        foreach (ICleanup cleanCon in _cleanupControllers)
        {
            cleanCon.Cleanup();
        }
    }

    public void Execute(float deltaTime)
    {
        foreach (IExecute execCon in _executeControllers)
        {
            execCon.Execute(deltaTime);
        }
    }

    public void FixedExecute()
    {
        foreach (IFixedExecute fixedExecCon in _fixedExecControllers)
        {
            fixedExecCon.FixedExecute();
        }
    }

    public void Initialize()
    {
        foreach (IInitialization initCon in _initControllers)
        {
            initCon.Initialize();
        }
    }
}