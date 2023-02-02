using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Dialogue
{
    public class DialogueManager : Singleton<DialogueManager>
    {
        [SerializeField] DialogueView _view;
        private bool _continueTrigger;

        bool ContinueTrigger
        {
            get
            {
                var trigger = _continueTrigger;
                _continueTrigger = false;
                return trigger;
            }
            set => _continueTrigger = value;
        }


        private void Start()
        {
            _view.Hide();
            _view.OnContinueButton += TriggerNextDialogue;
        }

        void TriggerNextDialogue()
        {
            ContinueTrigger = true;
        }

        public async UniTask ShowDialogue(DialogueData dialogue)
        {
            _view.Show();
            ContinueTrigger = false;
            foreach(var entry in dialogue.Entries) 
            {
                _view.SetDialogue(entry);
                await UniTask.WaitUntil(() => ContinueTrigger );
            }

            _view.Hide();
        }


        void OnDestroy()
        {
            _view.OnContinueButton -= TriggerNextDialogue;
        }
    }

}
