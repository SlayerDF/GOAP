﻿using System.Collections.Generic;
using CrashKonijn.Goap.Core.Enums;

namespace CrashKonijn.Goap.Core.Interfaces
{
    public interface IAgent
    {
        float DistanceMultiplier { get; }
        AgentState State { get; }
        AgentMoveState MoveState { get; }
        IAgentType AgentType { get; }
        IGoal CurrentGoal { get; }
        IAction CurrentAction { get; }
        IActionData CurrentActionData { get; }
        IWorldData WorldData { get; }
        List<IAction> CurrentActionPath { get; }
        IAgentEvents Events { get; }
        IDataReferenceInjector Injector { get; }
        IAgentDistanceObserver DistanceObserver { get; }
        IAgentTimers Timers { get; }
        IActionRunState RunState { get; }
        ITarget CurrentTarget { get; }

        void Run();
        
        void SetGoal<TGoal>(bool endAction) where TGoal : IGoal;

        void SetGoal(IGoal goal, bool endAction);
        void SetAction(IAction action, List<IAction> path, ITarget target);
        void StopAction(bool resolveAction = true);
        void CompleteAction(bool resolveAction = true);
        void SetDistanceMultiplierSpeed(float speed);
        void ResolveAction();
    }
}