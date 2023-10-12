using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mosaic.Base.Pages
{
	public class PageParent : MonoBehaviour
	{
		private PageElement[] elements;

		private void OnEnable()
		{
			elements = this.GetComponentsInChildren<PageElement>();
		}

		public void StartTransitionIn()
		{
			foreach (PageElement el in elements)
			{
				el.TransitionIn();
			}
		}

		public void StartTransitionOut()
		{
			foreach (PageElement el in elements)
			{
				el.TransitionOut();
			}
		}
	}
}
