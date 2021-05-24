using System.Collections;
using UnityEngine;

public class CameraEffectRipple : CameraEffect
{
	private const string PropertyName = "_Magnitude";

	[SerializeField]
	[Range(0, .1f)]
	private float startMagnitude = .03f;

	[SerializeField]
	private float fallOffPerSecond = .015f;

	private IEnumerator rippleOut;
	private IEnumerator rippleIn;

	protected override void Awake()
	{
		base.Awake();
		ResetMagnitude();
#if UNITY_EDITOR
		//EditorEventManager.ExitingPlayMode += OnExitingPlayMode;
#endif
	}

#if UNITY_EDITOR

	private void OnDestroy()
	{
		//EditorEventManager.ExitingPlayMode -= OnExitingPlayMode;
	}

	private void OnExitingPlayMode()
	{
		if (rippleOut != null)
		{
			StopCoroutine(rippleOut);
		}
		if (rippleIn != null)
		{
			StopCoroutine(rippleIn);
		}
		ResetMagnitude();
	}

#endif

	public void StartRippleOut()
	{
		rippleOut = RippleOut();
		StartCoroutine(rippleOut);
	}

	public void StartRippleIn(bool thenRippleOut = false)
	{
		rippleIn = RippleIn(thenRippleOut);
		StartCoroutine(rippleIn);
	}

	private IEnumerator RippleOut()
	{
		float currentMagnitude = effectMat.GetFloat(PropertyName);
		while (currentMagnitude > 0)
		{
			yield return new WaitForEndOfFrame();
			effectMat.SetFloat(PropertyName, currentMagnitude -= (fallOffPerSecond * Time.deltaTime));
		}
		enabled = false;
		ResetMagnitude();
	}

	private IEnumerator RippleIn(bool thenRippleOut)
	{
		enabled = true;
		float currentMagnitude = effectMat.GetFloat(PropertyName);
		while (currentMagnitude < startMagnitude)
		{
			yield return new WaitForEndOfFrame();
			effectMat.SetFloat(PropertyName, currentMagnitude += (fallOffPerSecond * Time.deltaTime));
		}
		ResetMagnitude();
		if (thenRippleOut)
		{
			StartRippleOut();
		}
	}

	private void ResetMagnitude()
	{
		effectMat.SetFloat(PropertyName, startMagnitude);
	}
}
