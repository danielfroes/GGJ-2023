using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Dialogue
{
    [CreateAssetMenu(fileName = "new dialogueEntry", menuName = "DialogueData")]
    public class DialogueData : ScriptableObject
    {
        [SerializeField] List<DialogueEntry> _entries;
        public IReadOnlyList<DialogueEntry> Entries => _entries;
    }

    [Serializable]
    public struct DialogueEntry
    {
        [ResizableTextArea] public string Text;
        [ShowAssetPreview] public Sprite Thumb;
    }
}
