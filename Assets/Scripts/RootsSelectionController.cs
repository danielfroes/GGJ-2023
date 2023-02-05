using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class RootsSelectionController : Singleton<RootsSelectionController>
    {
        [SerializeField] List<RootNode> _nodes = new();

        int _currentNode = 0;

        public void EnableNextRowSelection()
        {
            _currentNode++;
            if (_currentNode >= _nodes.Count)
            {
                TriggerEnding();
                return;
            }

            _nodes[_currentNode].Show ();
        }

        private void TriggerEnding()
        {
            Debug.Log("End Game");
        }

        private void Start()
        {
            _nodes.ForEach(node => node.Hide());
            _nodes[0].Show();
        }
    }
}
