using UnityEngine;
using System.Collections; 

public class NpcController : MonoBehaviour
{
    [SerializeField] private int moveSpeed;
    [SerializeField] private Transform position;
    [SerializeField] private float coolDown = 1f;
    public bool isOncooldown = false;
    public float radius;
    private Vector3 currentTarget;
    private Vector3 nextPos;
    [SerializeField] private float minMoveRadius =1f;
    [SerializeField] private float maxMoveRadius =20f;
    [SerializeField] private float minCd = 3f;

    [SerializeField] private float maxCd = 12;

    public bool isInQueue=false;
    public void Start()
    {
        //currentTarget = setTarget();
    }
    public void FixedUpdate()
    {
        if (!isInQueue && !isOncooldown)
        {
            moving_first(currentTarget);
        }
    }
    public void getCurrentTarget()
    {
        float moveRadius = Random.Range(minMoveRadius, maxMoveRadius);

        nextPos = Random.insideUnitCircle * moveRadius;
        nextPos = new Vector3(currentTarget.x + nextPos.x, currentTarget.y + nextPos.y, currentTarget.z);
    }
    public void setCurrentPos(Vector3 pos)
    {
        currentTarget = pos;
    }
    public float getCooldown()
    {
        return coolDown = Random.Range(minCd, maxCd);
    }

    public void setQueueState(bool queState)
    {
        isInQueue = queState;
    }

    public void moving_first(Vector3 direction)
    {      
            transform.position = Vector3.MoveTowards(transform.position, direction, moveSpeed * Time.fixedDeltaTime);
            if (Vector3.Distance(transform.position, direction) < 0.1f)
            {
                StartCoroutine(StartCooldown());
            }
    }
    public void moving()
    {
        
        if(Vector3.Distance(transform.position, currentTarget) > 0.56f){
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.fixedDeltaTime);
        }
    }

    IEnumerator StartCooldown()
    {
        isOncooldown = true;
        float cd = getCooldown();
        Debug.Log("Cooldown: " + cd);

        yield return new WaitForSeconds(cd);

        Debug.Log("Cooldown finished!");
        getCurrentTarget();
        currentTarget = nextPos;
        isOncooldown = false;
    }
}
