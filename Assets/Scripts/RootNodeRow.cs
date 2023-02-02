using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class RootNodeRow : MonoBehaviour  
    {
        [SerializeField] List<RootNode> _nodes = new();

        public void HideAll()
        {
            _nodes.ForEach(node => node.Hide());
        }

        public void Show(int selectedNodeIndex)
        {
            _nodes[selectedNodeIndex].Show();
        }
    }
}
