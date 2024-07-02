﻿using System.Collections.Generic;
using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Core;
using UnityEngine;

namespace CrashKonijn.Goap.Runtime
{
    [CreateAssetMenu(menuName = "Goap/ActionConfig")]
    public class ActionConfigScriptable : ScriptableObject, IActionConfig
    {
        [Header("Settings")]
        [ActionClass]
        public string actionClass;
        public TargetKeyScriptable target;
                
        [field:SerializeField]
        public int BaseCost { get; set; } = 1;
        
        [field:SerializeField]
        public float StoppingDistance { get; set; } = 0.1f;

        [field: SerializeField]
        public bool RequiresTarget { get; } = true;

        [field:SerializeField]
        public ActionMoveMode MoveMode { get; set; }

        public IActionProperties Properties { get; }

        [Header("Conditions and Effects")]
        public List<SerializableCondition> conditions;
        public List<SerializableEffect> effects;
        
        public string ClassType
        {
            get => this.actionClass;
            set => this.actionClass = value;
        }

        public ITargetKey Target => this.target;

        public ICondition[] Conditions => this.conditions.ToArray();
        public IEffect[] Effects => this.effects.ToArray();

        public string Name => this.name;
    }
}