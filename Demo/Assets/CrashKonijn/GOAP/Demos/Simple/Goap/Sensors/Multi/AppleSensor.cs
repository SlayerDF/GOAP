﻿using CrashKonijn.Goap.Demos.Simple.Behaviours;
using CrashKonijn.Goap.Demos.Simple.Goap.TargetKeys;
using CrashKonijn.Goap.Demos.Simple.Goap.WorldKeys;
using CrashKonijn.Goap.Runtime;
using Demos;
using UnityEngine;

namespace CrashKonijn.Goap.Demos.Simple.Goap.Sensors.Multi
{
    [GoapId("Simple-AppleSensor")]
    public class AppleSensor : MultiSensorBase
    {
        private AppleCollection apples;
        private TreeBehaviour[] trees;

        public override void Created()
        {
            this.apples = Compatibility.FindObjectOfType<AppleCollection>();
            this.trees = Compatibility.FindObjectsOfType<TreeBehaviour>();
        }

        public override void Update()
        {
            
        }

        public AppleSensor()
        {
            this.AddLocalTargetSensor<ClosestApple>((agent, references) =>
            {
                var closestApple = this.apples.Get().Closest(agent.Transform.position);

                if (closestApple is null)
                    return null;
            
                return new TransformTarget(closestApple.transform);
            });
            
            this.AddLocalTargetSensor<ClosestTree>((agent, references) =>
            {
                return new TransformTarget(this.trees.Closest(agent.Transform.position).transform);
            });
            
            this.AddLocalWorldSensor<HasApple>((agent, references) =>
            {
                var inventory = references.GetCachedComponent<InventoryBehaviour>();

                if (inventory == null)
                    return false;
                
                return inventory.Apples.Count > 0;
            });
            
            this.AddGlobalWorldSensor<ThereAreApples>(() =>
            {
                return this.apples.Any();
            });
        }
    }
}