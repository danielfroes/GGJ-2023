using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ButtonAudioTrigger : MonoBehaviour
    {
        [SerializeField] Button _button;
        [SerializeField] AudioSource _audio;
        
        private void Start()
        {
            _button.onClick.AddListener(() =>
            {
                _audio.Play();
            });
        }

    }
}
