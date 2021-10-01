using Assets.Scripts.Data;
using Assets.Scripts.Ship;
using UnityEngine;


internal sealed class PlayerFactory : IPlayerFactory
{
    private readonly PlayerData _playerData;
    public Transform CreatePlayer()
    {
        var shipFactory = new ShipFactory("Player", _playerData.Sprite, _playerData.Scale, 20);
        var playerShip = shipFactory.CreateShip();
        return playerShip;
    }

    public PlayerFactory(PlayerData playerData)
    {
        _playerData = playerData;
    }
}