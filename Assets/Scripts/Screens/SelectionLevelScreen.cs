using Assets.Scripts.Utils;
using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Screens
{

    public class SelectionLevelScreenArgs
    {
        public Action OnPlay;
        public LevelData Data;
    }

    public class SelectionLevelScreen : AScreen
    {
        [SerializeField] Button _playButton;
        [SerializeField] Button _backButton;
        [SerializeField] TMP_Text _description;
        [SerializeField] TMP_Text _title;
        [SerializeField] TMP_Text _name;
        [SerializeField] Image _thumb;

        LevelData _data;

        public override void OnShow(object[] args)
        {
            base.OnShow(args);

            var levelParameters = (SelectionLevelScreenArgs) args[0];

            _data = levelParameters.Data;

            _description.SetText(_data.Description);
            _title.SetText(_data.Character.Title);
            _name.SetText(_data.Character.Name);
            _thumb.sprite = _data.Character.Thumb;

            _playButton.onClick.AddListener(() =>
            {
                ServiceLocator.Get<TransitionService>().BlackoutTransition(() =>
                {
                    Instantiate(_data.LevelPrefab);
                    levelParameters.OnPlay?.Invoke();
                    CloseScreen();
                }).Forget();
            });

            _backButton.onClick.AddListener(() =>
            {
                CloseScreen();
            });
        }
    }
}
