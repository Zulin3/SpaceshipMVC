using Assets.Scripts.Data;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Controllers _controllers;
    [SerializeField] private GameData _data;

    void Start()
    {
        _controllers = new Controllers();
        new GameInitialization(_controllers, _data);
        _controllers.Initialize();
    }

    void Update()
    {
        _controllers.Execute(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _controllers.FixedExecute();
    }
}