using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class RootNode : MonoBehaviour 
    {
        [SerializeField] Button _button;
        [SerializeField] HiddenObjectController _hiddenObjectPrefab;

        public void Hide()
        {
            _button.interactable = false;
        }

        public void Show()
        {
            _button.interactable = true;
        }

        void Start()
        {
            _button.onClick.AddListener(SelectNode);
        }

        void SelectNode()
        {
            Hide();
            Instantiate(_hiddenObjectPrefab);
        }
    }
}
