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


    // Start is called before the first frame update
    private void Start()
    {
        mainCamera = Camera.main;

        if (coinPosTrans == null)
        {
            coinPosTrans = GameObject.FindGameObjectWithTag("CoinTargetPos").transform;
        }

        //Convert position of rectangle transform to world point on Scene
        Vector3 screenPoint = coinPosTrans.position + new Vector3(0, 0, 5);
        worldPos = mainCamera.ScreenToWorldPoint(screenPoint);

        firstPosition = this.transform.position;
        firstRotation = this.transform.rotation;
        firstScale = this.transform.localScale;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!isDespawned)
        {
            MoveToCoinPos();
        }
    }


    /// <summary>
    /// Move coin to text position on canvas UI
    /// </summary>
    public void MoveToCoinPos()
    {
        //move towards the world space positio
        transform.localScale = this.transform.localScale / 1.05f;
        transform.position = Vector3.MoveTowards(transform.position, worldPos, 10 * Time.deltaTime);
    }

    /// <summary>
    /// Move coin to text position on canvas UI using Tween
    /// </summary>
    /// <param name=”duration”></param>
    public void MoveToCoinPos(float duration)
    {
        Vector3 path1 = new Vector3(transform.position.x + 0.25f, transform.position.y + 0.25f, transform.position.z);
        Vector3 path2 = worldPos;

        Vector3[] arrPath = new Vector3[2];
        arrPath[0] = path1;
        arrPath[1] = path2;

        transform.DOLocalPath(arrPath, duration);
    }

    /// <summary>
    /// Disable coin object
    /// </summary>
    /// <param name=”duration”></param>
    public void Despawn(float duration)
    {
        StartCoroutine(ReturnCoinPos(duration));
    }

    /// <summary>
    /// Return coin object to first position
    /// </summary>
    private void ReturnFirstPos()
    {
        //coinObjectTrans.position = firstPosition;
        //coinObjectTrans.rotation = firstRotation;
        isDespawned = true;
        this.transform.position = firstPosition;
        this.transform.rotation = firstRotation;
        this.transform.localScale = firstScale;
    }

    /// <summary>
    /// Coroutine for return coin first position
    /// </summary>
    /// <param name=”duration”></param>
    /// <returns></returns>
    private IEnumerator ReturnCoinPos(float duration)
    {
        yield return new WaitForSeconds(duration);

        //coinObjectTrans.gameObject.SetActive(false);
        Destroy(this.gameObject);
        //this.gameObject.SetActive(false);
        //isDespawned = true;

        ReturnFirstPos();
    }
}
