﻿using System.Numerics;

namespace HLView.Formats.Mdl
{
    public struct Bone
    {
        public string Name;
        public int Parent;
        public int Flags;
        public int[] Controllers;
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 PositionScale;
        public Vector3 RotationScale;
    }
}