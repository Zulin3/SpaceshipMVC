using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ship
{
    class ShipFactory : IShipFactory
    {
        private string _name;
        private Sprite _sprite;
        private float _scale;
        private int _health;

        public Transform CreateShip()
        {
            var ship = new GameObject(_name).AddSprite(_sprite).AddComponent<SphereCollider>().transform;
            var shipCollider = ship.GetComponent<SphereCollider>();
            shipCollider.isTrigger = true;

            //shipCollider.radius = 0.5;
            ship.gameObject.AddComponent<Health>();
            var health = ship.GetComponent<Health>();
            health.InitHealth(20, 20, true);

            ship.localScale = new Vector3(_scale, _scale, _scale);
            return ship;
        }

        public ShipFactory(string name, Sprite sprite, float scale, int health)
        {
            _name = name;
            _sprite = sprite;
            _scale = scale;
            _health = health;
        }
    }
}
