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
 
        private void Start()
        {
            _skipButton.onClick.AddListener(() =>
            {
                ServiceLocator.Get<TransitionService>().BlackoutTransition(() =>
                {
                    SceneManager.LoadScene(_sceneIndex, LoadSceneMode.Additive);
                    CloseScreen();
                }).Forget();
            });
        }
    }
}
