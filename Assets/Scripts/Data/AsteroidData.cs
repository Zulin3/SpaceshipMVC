using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(fileName = "AsteroidData", menuName = "Data/AsteroidData")]

    public sealed class AsteroidData: ScriptableObject
    {
        [SerializeField] private Vector2 _speedLimits;
        [SerializeField] private Vector2 _angularSpeedLimits;
        [SerializeField] private float _colliderRadius;

        public (float x, float y) SpeedLimits
        {
            get
            {
                return (_speedLimits.x, _speedLimits.y);
            }
        }

        public (float x, float y) AngularSpeedLimits
        {
            get
            {
                return (_angularSpeedLimits.x, _angularSpeedLimits.y);
            }
        }

        public float ColliderRadius
        {
            get
            {
                return _colliderRadius;
            }
        }
    }
}
