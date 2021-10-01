using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Ship
{
    public interface IMove
    {
        float Speed { get; }
        void Move(float horizontal, float vertical, float deltaTime);
        void MoveForward(float deltaTime);
    }
}
