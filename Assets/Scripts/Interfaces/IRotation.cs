using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IRotation
{
    void Rotate(Vector3 direction);
    void RotateOn(float v);
}
