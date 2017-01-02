﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stateless
{
    public partial class StateMachine<TState, TTrigger>
    {
        internal class IgnoredTriggerBehaviour : TriggerBehaviour
        {
            public IgnoredTriggerBehaviour(TTrigger trigger, Func<bool> guard)
                : this(trigger, guard, string.Empty)
            {
            }

            public IgnoredTriggerBehaviour(TTrigger trigger, Func<bool> guard, string description)
                : base(trigger, new TransitionGuard(guard, description))
            {
            }

            public IgnoredTriggerBehaviour(TTrigger trigger, TransitionGuard transitionGuard)
                : base(trigger, transitionGuard)
            {
            }

            public override bool ResultsInTransitionFrom(TState source, object[] args, out TState destination)
            {
                destination = default(TState);
                return false;
            }
        }
    }
}
