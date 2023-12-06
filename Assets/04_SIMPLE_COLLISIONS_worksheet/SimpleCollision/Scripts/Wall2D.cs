using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Collision
{
    public class Wall2D : MonoBehaviour
    {
        public Transform top;
        public Transform bottom;

        public Vector2 wallVec { get; private set; }
        public Vector2 normalVec { get; private set; }

        private void Awake()
        {
            wallVec = top.position - bottom.position;
            normalVec = Vector2.Perpendicular(wallVec).normalized;
        }
    }
}
