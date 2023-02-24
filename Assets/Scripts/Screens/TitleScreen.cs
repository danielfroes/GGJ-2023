
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
            _playButton.onClick.AddListener(() => SceneManager.LoadScene(_gameScene));
            _quitButton.onClick.AddListener(() => Application.Quit());
        }

    }
}
