using UnityEngine;
using UnityEngine.Events;
using Mosaic.Base.TweenActions;
using Mosaic.Base.EditorTools;
using DG.Tweening;
using UnityEngine.UI;

namespace Mosaic.Base.Pages
{
	public class PageElement : MonoBehaviour
	{
		[SerializeField] private TweenActionCore transitionIn = null;
		[SerializeField] private TweenActionCore transitionOut = null;

		[System.Serializable]
		private struct Values
		{
			public Vector3 position;
			public Vector3 rotation;
			public Vector3 scale;
			public Color color;
		}

		[SerializeField] private Values beforeTransitionIn;
		[SerializeField] private Values beforeTransitionOut;

		[SerializeField] private UnityEvent onStartTransition = null;
		[SerializeField] private UnityEvent onCompleteTransition = null;

		private Image image;

		private void Awake()
		{
			image = GetComponent<Image>();
		}

		private void Setup(Values values)
		{
			transform.localPosition = values.position;
			transform.localRotation = Quaternion.Euler(values.rotation);
			transform.localScale = values.scale;

			if(image)
				image.color = values.color;
		}

		public void TransitionIn()
		{
			Setup(beforeTransitionIn);
			DG.Tweening.Tween tween = transitionIn.Act(this.gameObject);
			tween.OnStart(() => onStartTransition?.Invoke());
			tween.OnComplete(() => onCompleteTransition?.Invoke());
		}

		public void TransitionOut()
		{
			Setup(beforeTransitionOut);
			DG.Tweening.Tween tween = transitionOut.Act(this.gameObject);
			tween.OnStart(() => onStartTransition?.Invoke());
			tween.OnComplete(() => onCompleteTransition?.Invoke());
		}

		[Button]
		private void RecordBeforeTransitionIn() 
		{
			beforeTransitionIn.position = transform.localPosition;
			beforeTransitionIn.rotation = transform.localRotation.eulerAngles;
			beforeTransitionIn.scale = transform.localScale;
			image = GetComponent<Image>();
			if (image) beforeTransitionIn.color = image.color;
		}

		[Button]
		private void RecordBeforeTransitionOut()
		{
			beforeTransitionOut.position = transform.localPosition;
			beforeTransitionOut.rotation = transform.localRotation.eulerAngles;
			beforeTransitionOut.scale = transform.localScale;
			image = GetComponent<Image>();
			if (image) beforeTransitionOut.color = image.color;
		}
	}
}
