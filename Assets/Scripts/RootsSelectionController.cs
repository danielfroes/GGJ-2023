using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class RootsSelectionController : Singleton<RootsSelectionController>
    {
        [SerializeField] List<RootNodeRow> _rows = new();

        int _currentRow = 0;

        public void EnableNextRowSelection()
        {
            _currentRow++;
            if (_currentRow >= _rows.Count)
            {
                TriggerEnding();
                return;
            }

            _rows[_currentRow].ShowAll();
        }

        private void TriggerEnding()
        {
            Debug.Log("End Game");
        }

        private void Start()
        {
            _rows.ForEach(row => row.HideAll());
            _rows[0].ShowAll();
        }
    }
}
