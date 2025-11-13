using UnityEngine;
using System.Collections;

public class PotatoManController : MonoBehaviour
{
    [SerializeField] private int moveSpeed;
    [SerializeField] private PotatoManModel model;
    [SerializeField] private PotatoManView view;

    [SerializeField] private float coolDown = 1f;
    public bool isOncooldown = false;
    public float radius;
    private Vector3 currentTarget;

    public PotatoManController(PotatoManModel Model, PotatoManView view)
    {
        this.model = Model;
        this.view = view;
    }

    public void Start()
    {
        currentTarget = setTarget();
    }
    public void FixedUpdate()
    {
        if (!isOncooldown)
        {
            moving();
        }
    }
    public void setCurrentPos(Vector3 pos)
    {
        this.model.setCurrentPos(pos);
    }
    public Vector3 getCurrentPos()
    {
        return model.getCurrentPos();
    }

    public void moving()
    {

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.fixedDeltaTime);
        if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
        {
            StartCoroutine(StartCooldown());
        }
    }

    public Vector3 setTarget()
    {
        return this.model.getNewPos();
    }

    IEnumerator StartCooldown()
    {
        isOncooldown = true;
        float cd = this.model.getCooldown();
        Debug.Log("Cooldown: " + cd);

        yield return new WaitForSeconds(cd);

        Debug.Log("Cooldown finished!");
        currentTarget = setTarget();
        isOncooldown = false;
    }
}
