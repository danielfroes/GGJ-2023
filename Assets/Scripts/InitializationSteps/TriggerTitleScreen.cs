using Assets.Scripts.Initialization;
using Assets.Scripts.Screens;
using Assets.Scripts.Utils;
using System;

namespace Assets.Scripts.InitializationSteps
{
    public class TriggerTitleScreen : IInitializationStep
    {
        public void Run()
        {
            ServiceLocator.Get<ScreenService>().Show<TitleScreen>();
        }

        public void Dispose()
        {
            
        }

    }
}
