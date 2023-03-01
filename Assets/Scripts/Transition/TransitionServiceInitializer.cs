using Assets.Scripts.Initialization;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets
{
    public class TransitionServiceInitializer : IInitializationStep
    {
        [SerializeField] Canvas _transitionCanvas;
        public void Dispose()
        {
            ServiceLocator.Unregister<TransitionService>();
        }

        public void Run()
        {
            ServiceLocator.Register(new TransitionService(_transitionCanvas));
        }
    }
}
