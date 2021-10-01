using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public sealed class Asteroid: Enemy
    {
        public float _angularSpeed = 0;
        public float _speedHorizontal;
        public float _speedVertical;

        private void Update()
        {
            _moveImplementation.Move(_speedHorizontal, _speedVertical, Time.deltaTime);
            _rotationImplementation.RotateOn(_angularSpeed * Time.deltaTime);
        }
    }
}
