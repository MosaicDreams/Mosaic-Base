using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mosaic.Base.Waiter
{
    public class Waiter : MonoBehaviour
    {
        private static Waiter instance = null;
        
        private static Waiter Instance
        {
            get
            {
                if (instance == null)
                {
					instance = new GameObject("Waiter: Instance").AddComponent<Waiter>();
                    DontDestroyOnLoad(instance.gameObject);
				}
				return instance;
            }
        }

        private void Awake()
        {
            instance = this;
        }

        private void OnDestroy()
        {
            if (instance == this)
                instance = null;
        }

        IEnumerator WaitRoutine(float duration, System.Action callback)
        {
            yield return new WaitForSeconds(duration);
            callback?.Invoke();
        }

		public Coroutine Wait(float seconds, System.Action callback)
		{
			return StartCoroutine(WaitRoutine(seconds, callback));
		}

		public static Coroutine InstanceWait(float seconds, System.Action callback)
        {
            return Instance.StartCoroutine(Instance.WaitRoutine(seconds, callback));
        }

        public static void StopCoroutines(List<Coroutine> list)
        {
            foreach(Coroutine c in list)
                Instance.StopCoroutine(c);
        }

        public static Waiter GetUniqueInstance(string name, bool dontDestroyOnLoad = true)
        {
            Waiter waiter = new GameObject($"Waiter: {name}").AddComponent<Waiter>();

            if (dontDestroyOnLoad)
                DontDestroyOnLoad(waiter.gameObject);

            return waiter;
		}
    }
}
