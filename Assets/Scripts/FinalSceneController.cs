using Assets;
using Assets.Scripts.Screens;
using Assets.Scripts.Utils;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalSceneController : MonoBehaviour
{
    [SerializeField] Button _replayButton;
    [SerializeField, Scene] int _finalScene;

    // Start is called before the first frame update
    void Start()
    {
        _replayButton.onClick.AddListener(() =>
        {
            ServiceLocator.Get<TransitionService>().BlackoutTransition(() =>
            {
                ServiceLocator.Get<ScreenService>().Show<TitleScreen>();
                SceneManager.UnloadSceneAsync(_finalScene);
            }).Forget();
        });
    }

}
