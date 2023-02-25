using UnityEngine;
using System;

namespace Assets.Game.Scripts.Utils
{
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public class SerializeReferenceMenuAttribute : PropertyAttribute
    {

    }

}