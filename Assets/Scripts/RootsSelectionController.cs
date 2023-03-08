using Assets.Scripts.Screens;
using Assets.Scripts.Utils;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class RootsSelectionController : Singleton<RootsSelectionController>
    {
        [SerializeField] List<RootNodeRow> _nodesRow = new();
        [SerializeField] RootNode _initialNode;
        [SerializeField, Scene] int _gameScene;
        [SerializeField, Scene] int _finalScene;
        [SerializeField] AudioSource _rainAudio;

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
            ServiceLocator.Get<ScreenService>().Show<SelectionLevelScreen>(new SelectionLevelScreenArgs()
            {
                Data = node.Level,
                OnPlay = () =>
                {
                    _nodeSelected = node;
                    _nodeSelected.SetInteractable(false);
                    _nodesRow[_currentRow].HideAllBut(_nodeSelected);
                    _rainAudio.mute = true;
                }
            });
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
            _rainAudio.mute = false;
            row.transform.position = new(_nodeSelected.transform.position.x, row.transform.position.y, row.transform.position.z);
            row.ShowAll();
        }


        void TriggerEnding()
        {
            ServiceLocator.Get<TransitionService>().BlackoutTransition(() =>
            {
                SceneManager.UnloadSceneAsync(_gameScene);
                SceneManager.LoadScene(_finalScene, LoadSceneMode.Additive); 
            }).Forget();
        }
    }
}
