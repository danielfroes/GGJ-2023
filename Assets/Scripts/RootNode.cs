using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class RootNode : MonoBehaviour 
    {
        public event Action<RootNode> OnClicked;
        
        [SerializeField] Button _button;
        [SerializeField] HiddenObjectController _hiddenObjectPrefab;
        [SerializeField] List<GameObject> _roots;

        public HiddenObjectController LevelPrefab => _hiddenObjectPrefab;

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public async UniTask EnableRoots()
        {
            _roots.ForEach(root => root.SetActive(true));
            await UniTask.Delay(1500);
        }

        void Start()
        {
            _button.onClick.AddListener(SelectNode);
        }

        void SelectNode()
        {
            OnClicked?.Invoke(this);
        }

        public void SetInteractable(bool value)
        {
            _button.interactable = value;
        }
    }
}
