using Assets.Scripts.Dialogue;
using Assets.Scripts.Utils;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HiddenObjectController : MonoBehaviour
    {
        [SerializeField] List<HiddenItem> _items;

        [SerializeField] GameObject _itemsViewGroup;
        [SerializeField] HiddenItemViewCell _itemViewCellPrefab;

        [SerializeField] GameObject _highlightBackground;
        [SerializeField] Image _highligthImage;

        [SerializeField] AudioSource _audio;
        private void Start()
        {
            _items.ForEach(item => item.OnFound += FindItem);

            _highlightBackground.SetActive(false);  

            PopulateUi();
        }

        private void PopulateUi()
        {
            foreach(var item in _items)
            {
                var itemCell = Instantiate(_itemViewCellPrefab, _itemsViewGroup.transform);
                itemCell.Populate(item);
            }
        }

        private void FindItem(HiddenItem item) => FindItemAsync(item).Forget();

        async UniTaskVoid FindItemAsync(HiddenItem item)
        {
            if (item.Dialogue != null)
            {
                _audio.Play();
                _highligthImage.sprite = item.Sprite;
                _highlightBackground.SetActive(true);
                await DialogueManager.Instance.ShowDialogue(item.Dialogue);
                _highlightBackground.SetActive(false);
            }

            CheckForWinCondition().Forget();
        }

        private async UniTaskVoid CheckForWinCondition()
        {
            if (_items.TrueForAll(item => item.Found))
            {
                await ServiceLocator.Get<TransitionService>().BlackoutTransition(() =>
                    {
                        gameObject.SetActive(false);
                    });

                RootsSelectionController.Instance.EnableNextRowSelection().Forget();
                Destroy(gameObject);
            }
        }
    }
}
