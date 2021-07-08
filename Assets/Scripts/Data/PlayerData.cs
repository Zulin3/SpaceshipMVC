using Assets.Scripts.Data;
using Assets.Scripts.Ship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
    public sealed class PlayerData : ScriptableObject
    {
        public Sprite Sprite;
        [SerializeField] private float _speed;
        [SerializeField] private Vector2 _position;
        [SerializeField] private float _scale;
        [SerializeField] private MovementType _movementType;

        public float Scale
        {
            get
            {
                return _scale;
            }
        }

        public float Speed
        {
            get
            {
                return _speed;
            }
        }

        public MovementType MovementType
        {
            get
            {
                return _movementType;
            }
        }

        public Vector2 Position
        {
            get
            {
                return _position;
            }
        }
    }
}
