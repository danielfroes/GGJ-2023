using Assets.Scripts.Utils;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class RootsSelectionController : Singleton<RootsSelectionController>
    {
        [SerializeField] List<RootNodeRow> _nodesRow = new();
        [SerializeField] RootNode _initialNode;
        
        int _currentRow = 0;

        RootNode _nodeSelected;

        void Start()
        {
            _nodesRow.ForEach(row =>
            {
                row.HideAll();
                row.OnNodeChoosed += ChooseNode;
            });

            InitNodeRows().Forget();
        }


        async UniTaskVoid InitNodeRows()
        {
            await UniTask.Delay(2000);
            await _initialNode.EnableRoots();
            _nodeSelected = _initialNode;
            _nodesRow[0].ShowAll();
        }

        void ChooseNode(RootNode node)
        {
            _nodeSelected = node;
            _nodeSelected.SetInteractable(false);
            _nodesRow[_currentRow].HideAllBut(_nodeSelected);


            ServiceLocator.Get<TransitionService>().BlackoutTransition(() =>
            {
                Instantiate(node.LevelPrefab);
            }).Forget();
        }

        public async UniTaskVoid EnableNextRowSelection()
        {
            _currentRow++;
            if (_currentRow >= _nodesRow.Count)
            {
                TriggerEnding();
                return;
            }

            await _nodeSelected.EnableRoots();
            RootNodeRow row = _nodesRow[_currentRow];

            row.transform.position = new(_nodeSelected.transform.position.x, row.transform.position.y, row.transform.position.z);
            row.ShowAll();
        }


        void TriggerEnding()
        {
            ServiceLocator.Get<TransitionService>().BlackoutTransition(() =>
            {
                SceneManager.UnloadSceneAsync(1);
                SceneManager.LoadScene(2, LoadSceneMode.Additive); 
            }).Forget();
        }
    }
}
