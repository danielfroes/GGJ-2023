using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class TransitionService
    {
        Image _blackoutImage;

        public TransitionService(Canvas transitionCanvas)
        {
            Canvas canvas = UnityEngine.Object.Instantiate(transitionCanvas);
            _blackoutImage = canvas.GetComponentInChildren<Image>();
            _blackoutImage.gameObject.SetActive(false);
        }


        public async UniTask BlackoutTransition(Action onBlackoutCallback)
        {
            _blackoutImage.gameObject.SetActive(true);
            _blackoutImage.color = new(_blackoutImage.color.r, _blackoutImage.color.g, _blackoutImage.color.b, 0);
            await _blackoutImage.DOFade(1, 2).ToUniTask();
            onBlackoutCallback();
            await _blackoutImage.DOFade(0, 1).ToUniTask();
            _blackoutImage.gameObject.SetActive(false);
        }

    }
}
