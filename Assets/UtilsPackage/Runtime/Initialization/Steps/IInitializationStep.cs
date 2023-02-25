using System;

namespace Assets.Scripts.Initialization
{
    public interface IInitializationStep : IDisposable
    {
        public abstract void Run();
    }

}