using NaughtyAttributes;
using UnityEngine;

namespace Assets.Scripts.Dialogue
{
    [CreateAssetMenu(fileName = "new CharacterData", menuName = "CharacterData")]
    public class CharacterDialogueData : ScriptableObject
    {
        public string Name;
        public string Title;
        [ShowAssetPreview] public Sprite Thumb;
    }
}