﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Veldrid;
using Veldrid.Utilities;

namespace HLView.Graphics
{
    public class Scene : IDisposable
    {
        private readonly GraphicsDevice _graphicsDevice;
        private readonly List<IRenderable> _renderables;
        private readonly List<IUpdateable> _updateables;
        
        public Scene(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            _updateables = new List<IUpdateable>();
            _renderables = new List<IRenderable>();
        }

        public void AddRenderable(IRenderable renderable)
        {
            _renderables.Add(renderable);
            renderable.CreateResources(_graphicsDevice);
        }

        public void AddUpdateable(IUpdateable updateable)
        {
            _updateables.Add(updateable);
        }

        public void Update(long milliseconds)
        {
            foreach (var updateable in _updateables) updateable.Update(milliseconds);
            foreach (var renderable in _renderables) renderable.Update(milliseconds);
        }

        public void Render(GraphicsDevice gd, CommandList cl, SceneContext sc)
        {
            foreach (var renderable in _renderables)
            {
                renderable.Render(gd, cl, sc);
            }
        }

        public void Dispose()
        {
            _graphicsDevice?.Dispose();
        }
    }
}