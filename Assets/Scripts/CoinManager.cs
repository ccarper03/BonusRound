using System.Collections;
using UnityEngine;
using DG.Tweening;
public class CoinManager : Singleton<CoinManager>
{
    public Transform coinPosTrans;
    private Transform coinObjectTrans;

    private Vector3 firstPosition;
    private Vector3 firstScale;
    private Quaternion firstRotation;

    private Camera mainCamera;
    private Vector3 worldPos;
    private bool isDespawned = false;

    private void Start()
    {
        mainCamera = Camera.main;

        if (coinPosTrans == null)
        {
            coinPosTrans = GameObject.FindGameObjectWithTag("CoinTargetPos").transform;
        }

        Vector3 screenPoint = coinPosTrans.position + new Vector3(0, 0, 5);
        worldPos = mainCamera.ScreenToWorldPoint(screenPoint);

        firstPosition = this.transform.position;
        firstRotation = this.transform.rotation;
        firstScale = this.transform.localScale;

    }

    private void FixedUpdate()
    {
        if (!isDespawned)
        {
            MoveToCoinPos();
        }
    }

    public void MoveToCoinPos()
    {
        transform.localScale = this.transform.localScale / 1.05f;
        transform.position = Vector3.MoveTowards(transform.position, worldPos, 10 * Time.deltaTime);
    }

    public void MoveToCoinPos(float duration)
    {
        Vector3 path1 = new Vector3(transform.position.x + 0.25f, transform.position.y + 0.25f, transform.position.z);
        Vector3 path2 = worldPos;
        Vector3[] arrPath = new Vector3[2];
        arrPath[0] = path1;
        arrPath[1] = path2;
        transform.DOLocalPath(arrPath, duration);
    }

    public void Despawn(float duration)
    {
        StartCoroutine(ReturnCoinPos(duration));
    }

    private void ReturnFirstPos()
    {
        isDespawned = true;
        this.transform.position = firstPosition;
        this.transform.rotation = firstRotation;
        this.transform.localScale = firstScale;
    }

    private IEnumerator ReturnCoinPos(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
        ReturnFirstPos();
    }
}
