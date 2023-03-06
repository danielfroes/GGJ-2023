using Assets.Scripts.Dialogue;
using UnityEngine;

namespace Assets.Scripts.Screens
{
    [CreateAssetMenu(fileName = "new LevelData", menuName = "Level Data")]
    public class LevelData : ScriptableObject
    {
        public string Description;
        public CharacterDialogueData Character;
        public HiddenObjectController LevelPrefab;
    }
}