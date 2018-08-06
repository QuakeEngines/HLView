﻿namespace HLView.Formats.Mdl
{
    public struct Texture
    {
        public string Name;
        public TextureFlags Flags;
        public int Width;
        public int Height;
        public int Index;

        public byte[] Data;
        public byte[] Palette;
    }
}