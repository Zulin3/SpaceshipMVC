using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ship
{
    class Rotation : IRotation
    {
        private readonly Transform _transform;

        public Rotation(Transform transform)
        {
            _transform = transform;
        }

        public void Rotate(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }
}
