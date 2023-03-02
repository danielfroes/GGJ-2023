using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class RootNodeRow : MonoBehaviour
    {
        public event Action<RootNode> OnNodeChoosed
        {
            add => _nodes.ForEach(node => node.OnClicked += value);
            remove => _nodes.ForEach(node => node.OnClicked -= value);
        }

        [SerializeField] List<RootNode> _nodes = new();

        public void ShowAll()
        {
            _nodes.ForEach(node => node.Show());
        }

        public void HideAll()
        {
            _nodes.ForEach(node => node.Hide());
        }

        public void HideAllBut(RootNode nodeSelected)
        {
            _nodes.ForEach(node => 
            { 
                if(node != nodeSelected)
                    node.Hide(); 
            });
        }
    }
}
