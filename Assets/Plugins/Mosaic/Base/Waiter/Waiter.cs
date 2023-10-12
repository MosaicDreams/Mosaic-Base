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
                    instance = new GameObject("Extensions: Waiter").AddComponent<Waiter>();
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

        public static Coroutine Wait(float seconds, System.Action callback)
        {
            return Instance.StartCoroutine(Instance.WaitRoutine(seconds, callback));
        }

        public static void StopCoroutines(List<Coroutine> list)
        {
            foreach(Coroutine c in list)
                Instance.StopCoroutine(c);
        }
    }
}
