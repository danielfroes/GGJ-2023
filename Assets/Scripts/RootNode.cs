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
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        void Start()
        {
            _button.onClick.AddListener(SelectNode);
        }

        void SelectNode()
        {
            Instantiate(_hiddenObjectPrefab);
            
        }
    }
}
