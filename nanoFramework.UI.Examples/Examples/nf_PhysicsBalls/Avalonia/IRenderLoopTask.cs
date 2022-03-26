using System;

namespace Avalonia.Rendering
{
    public interface IRenderLoopTask
    {
        bool NeedsUpdate { get; }

        void Render();
        void Update(TimeSpan time);
    }
}