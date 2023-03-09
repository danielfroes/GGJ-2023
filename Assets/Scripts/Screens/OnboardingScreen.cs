using Assets.Scripts.Utils;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Screens
{
    public class OnboardingScreen : AScreen
    {
        [SerializeField] Button _skipButton;
        [SerializeField, Scene] int _sceneIndex;
        [SerializeField] ScrollSnapRect _scrollSnapRect;
 
        private void Start()
        {
            _scrollSnapRect.OnSlideEnded += () =>
            {
                ServiceLocator.Get<TransitionService>().BlackoutTransition(() =>
                {
                    SceneManager.LoadScene(_sceneIndex, LoadSceneMode.Additive);
                    CloseScreen();
                }).Forget();
            };
        }
    }
}
