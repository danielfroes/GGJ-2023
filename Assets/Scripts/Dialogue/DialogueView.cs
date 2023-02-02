﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Dialogue
{
    public class DialogueView : MonoBehaviour
    {
        public event Action OnContinueButton;

        [SerializeField] Image _thumb;
        [SerializeField] TextMeshProUGUI _text;
        [SerializeField] Button _continue;


        private void Start()
        {
            _continue.onClick.AddListener(() => OnContinueButton?.Invoke());    
        }

        public void SetDialogue(DialogueEntry dialogue)
        {
            _text.SetText(dialogue.Text);
            _thumb.sprite = dialogue.Thumb;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}