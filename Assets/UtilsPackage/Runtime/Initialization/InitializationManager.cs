using Assets.Game.Scripts.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Initialization
{
    public class InitializationManager : MonoBehaviour
    {
        [SerializeReferenceMenu] [SerializeReference] List<IInitializationStep> _steps;

        void Awake()
        {
            _steps.ForEach(step => step.Run());    
        }

        void OnDestroy()
        {
            _steps.ForEach(step => step.Dispose());
        }
    }

}
