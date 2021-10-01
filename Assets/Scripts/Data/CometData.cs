using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(fileName = "CometData", menuName = "Data/CometData")]
    public sealed class CometData : ScriptableObject
    {
        [SerializeField] private Vector2 _speedLimits;
        [SerializeField] private float _colliderRadius;

        public (float x, float y) SpeedLimits
        {
            get
            {
                return (_speedLimits.x, _speedLimits.y);
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
