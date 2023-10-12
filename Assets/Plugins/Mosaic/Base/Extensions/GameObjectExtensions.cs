using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mosaic.Base.Extensions
{
	public static class GameObjectExtensions
	{
		public static Coroutine SetActive(this GameObject gameObject, bool state, float seconds)
		{
			return Waiter.Waiter.Wait(seconds, () => { if (gameObject != null) gameObject.SetActive(state); });
		}

		public static Coroutine Destroy(this GameObject gameObject, float seconds)
		{
			return Waiter.Waiter.Wait(seconds, () => { if (gameObject != null) GameObject.Destroy(gameObject); });
		}
	}
}
