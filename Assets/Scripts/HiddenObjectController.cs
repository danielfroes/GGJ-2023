using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class HiddenObjectController : MonoBehaviour
    {
        [SerializeField] List<HiddenItem> _items;

        [SerializeField] GameObject _itemsViewGroup;
        [SerializeField] HiddenItemViewCell _itemViewCellPrefab;

        private void Start()
        {
            _items.ForEach(item => item.OnFound += FindItem);

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

        private void FindItem(HiddenItem item)
        {
            CheckForWinCondition();
        }

        private void CheckForWinCondition()
        {
            if (_items.TrueForAll(item => item.Found))
            {
                RootsSelectionController.Instance.EnableNextRowSelection();
                Destroy(gameObject);
            }
        }
    }
}
