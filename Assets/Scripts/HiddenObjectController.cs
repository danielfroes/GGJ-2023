using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HiddenObjectController : MonoBehaviour
    {
        [SerializeField] List<Button> _choiceButtons;



        private void Start()
        {
            foreach(var button in _choiceButtons) 
            {
                button.onClick.AddListener(() =>
                {
                    int index = _choiceButtons.IndexOf(button);
                    RootsSelectionController.Instance.EnableNextRowSelection(index);
                    Destroy(gameObject);
                });
            }
        }

    }
}
