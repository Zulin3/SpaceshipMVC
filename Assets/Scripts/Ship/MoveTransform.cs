﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Ship
{
    class MoveTransform : IMove
    {
        private readonly Transform _transform;
        private Vector3 _move;
        public float Speed { get; protected set; }

        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _transform.localPosition += _move;
        }

        public void MoveForward(float deltaTime)
        {
            _move = _transform.right * Speed * deltaTime;
            _transform.localPosition += _move;
        }
    }
}
