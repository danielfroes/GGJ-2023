using Cysharp.Threading.Tasks;
using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Dialogue
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] DialogueData _data;


        void Start()
        {
            DialogueManager.Instance.ShowDialogue(_data).Forget();
        }
    }
}
