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
        public Transform CreateShip()
        {
            var ship = new GameObject(_name).AddSprite(_sprite).transform;
            ship.localScale = new Vector3(_scale, _scale, _scale);
            return ship;
        }

        public ShipFactory(string name, Sprite sprite, float scale)
        {
            _name = name;
            _sprite = sprite;
            _scale = scale;
        }
    }
}
