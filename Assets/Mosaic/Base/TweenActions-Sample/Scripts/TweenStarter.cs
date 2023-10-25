using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mosaic.Base.TweenActions.Sample
{
	public class TweenStarter : MonoBehaviour
	{
		[SerializeField] TweenActionCore action;

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
				action.Act(this.gameObject);
		}
	}
}
