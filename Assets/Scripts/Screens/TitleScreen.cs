
using Assets.Scripts.Utils;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Screens
{
    public class TitleScreen : AScreen
    {
        [SerializeField] Button _playButton;
        [SerializeField] Button _quitButton;
        [Scene][SerializeField] int _gameScene;
        
        
        void Start()
        {
            _playButton.onClick.AddListener(() =>
            {
                TransitionService transitionService = ServiceLocator.Get<TransitionService>();
                transitionService.BlackoutTransition(() =>
                {
                    ServiceLocator.Get<ScreenService>().Show<OnboardingScreen>();
                }).Forget();
            });
            
            
            
            _quitButton.onClick.AddListener(() => Application.Quit());
        }

    }
}
