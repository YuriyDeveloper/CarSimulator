using System.Collections.Generic;

namespace Scripts.Infrastructure.Cache
{
    public class Pool<Type>
    {
        List<Type> _pool = new List<Type>();

        public delegate bool IsActiveCallback(Type poolTiem);

        public delegate void ActivateCallback(Type poolTiem);

        public delegate Type InstantiateCallback();


        public IsActiveCallback IsActive;

        public ActivateCallback Activate;

        public InstantiateCallback Instantiate;

        public Type Get(bool prewarm = false)
        {
            if (IsActive != null)
            {
                foreach (Type item in _pool)
                {
                    if (!IsActive(item))
                    {
                        if (Activate != null && !prewarm)
                        {
                            Activate(item);
                        }

                        return item;
                    }

                }
            }
            if (Instantiate != null)
            {
                Type item = Instantiate();
                _pool.Add(item);
                if (Activate != null && !prewarm)
                {
                    Activate(item);
                }
                return item;
            }
            return default(Type);
        }

        public Type[] GetActiveItems()
        {
            List<Type> activeItems = new List<Type>();
            foreach (Type item in _pool)
            {
                if (IsActive(item))
                {
                    activeItems.Add(item);
                }
            }
            return activeItems.ToArray();
        }
    }
}
