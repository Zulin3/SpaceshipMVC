using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    internal sealed class Comet: Enemy
    {
        public float _speed;

        public void Update()
        {
            _moveImplementation.MoveForward(Time.deltaTime);
        }
    }
}
