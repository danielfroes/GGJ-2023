using Assets.Scripts.Dialogue;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HiddenItem: MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] Image _image;
        [SerializeField] DialogueData _dialogue;

        public bool Found { get; private set; }
        public Sprite Sprite => _image.sprite;

        public event Action<HiddenItem> OnFound;

        public void OnPointerClick(PointerEventData eventData)
        {
            FindItemAsync().Forget();
        }

        async UniTask FindItemAsync()
        {
            if (Found)
                return;

            Found = true;

            if (_dialogue != null)
            {
                await DialogueManager.Instance.ShowDialogue(_dialogue);
            }

            gameObject.SetActive(false); 
            OnFound?.Invoke(this);
        }

    }
}
