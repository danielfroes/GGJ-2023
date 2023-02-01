using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class RootsSelectionController : Singleton<RootsSelectionController>
    {
        [SerializeField] List<RootNodeRow> _rows = new();

        int _currentRow = 0;

        public void EnableNextRowSelection(int choosenNode)
        {
            _currentRow++;
            if (_currentRow >= _rows.Count)
            {
                Debug.Log("End Game");
                return;
            }

            _rows[_currentRow].Show(choosenNode);
        }

        private void Start()
        {
            _rows.ForEach(row => row.HideAll());
            _rows[0].Show(0);
        }


        
    }
}
