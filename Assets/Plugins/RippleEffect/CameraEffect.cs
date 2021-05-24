using UnityEngine;
using System.Collections;

public class CameraEffect : MonoBehaviour
{
	[SerializeField]
	protected Material effectMat = default;

	protected virtual void Awake()
	{
		StartCoroutine(Animate());
	}

	protected virtual void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		Graphics.Blit(src, dest, effectMat);
	}
	IEnumerator Animate()
    {
        while (true)
        {
			yield return new WaitForSeconds(.5f);
			effectMat.SetFloat("_DriftX", -2);
			effectMat.SetFloat("_DriftY", -2);

			yield return new WaitForSeconds(.5f);
			effectMat.SetFloat("_DriftX", 2);
			effectMat.SetFloat("_DriftY", 2);
		}
		
	}
}
