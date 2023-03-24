using MessengerSystem.MessageTargets;
using System;
using System.Collections.Generic;

namespace MessengerSystem
{
    public static class Messenger
    {
        private static readonly Dictionary<Type, List<IMessageTarget>> targets;

        static Messenger()
        {
            targets = new Dictionary<Type, List<IMessageTarget>>();
        }

        public static void Register<TMessageTarget>(TMessageTarget messageTarget)
            where TMessageTarget : class, IMessageTarget
        {
            var type = typeof(TMessageTarget);
            if (!targets.ContainsKey(type))
            {
                targets[type] = new List<IMessageTarget>();
            }
            targets[type].Add(messageTarget);
        }

        public static void UnRegister<TMessageTarget>(TMessageTarget messageTarget)
            where TMessageTarget : class, IMessageTarget
        {
            var type = typeof(TMessageTarget);
            if (!targets.ContainsKey(type)) return;
            targets[type].Remove(messageTarget);
            if (targets[type].Count == 0)
            {
                targets.Remove(type);
            }
        }

        public static void Execute<TMessageTarget>(Action<TMessageTarget> functor)
            where TMessageTarget : class, IMessageTarget
        {
            var type = typeof(TMessageTarget);
            if (!targets.ContainsKey(type)) return;
            var foundNull = false;
            foreach (var messageTarget in targets[type])
            {
                if (messageTarget == null)
                {
                    foundNull = true;
                    continue;
                }
                functor?.Invoke(messageTarget as TMessageTarget);
            }
            if (foundNull)
            {
                CleanupNulls(type);
            }
        }

        private static void CleanupNulls(Type key)
        {
            if (!targets.ContainsKey(key)) return;
            var targetsOfType = targets[key];
            for (var i = 0; i < targetsOfType.Count; i++)
            {
                if (targetsOfType[i] == null)
                {
                    targetsOfType.RemoveAt(i--);
                }
            }
            if (targetsOfType.Count == 0)
            {
                targets.Remove(key);
            }
        }
    }
}