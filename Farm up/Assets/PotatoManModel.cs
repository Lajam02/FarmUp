using UnityEngine;

public class PotatoManModel : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private string name;
   [SerializeField] private GameObject potatoType;
   [SerializeField] private int age;
    [SerializeField] private float moveRadius =1f;
    [SerializeField] private Vector3 currentpos;
    [SerializeField] private Vector3 nextPos;

    [SerializeField] private float minCd = 3f;

    [SerializeField] private float maxCd = 12;

    public PotatoManModel(string Name, GameObject Type, int Age)
    {
        this.name = Name;
        this.potatoType = Type;
        this.age = Age;
    }

    public string getName()
    {
        return this.name;
    }
    public string getAge()
    {
        return this.name;
    }
    public string changeName()
    {
        return this.name;
    }

    public float getCooldown()
    {
        return Random.Range(minCd, maxCd);
    }

    public void setCurrentPos(Vector3 pos)
    {
        this.currentpos = pos;
    }
    public Vector3 getCurrentPos()
    {
        return this.currentpos;
    }
    public Vector3 getNewPos()
    {
        nextPos = Random.insideUnitCircle * moveRadius;
        nextPos = new Vector3(currentpos.x + nextPos.x, currentpos.y + nextPos.y, currentpos.z);
        this.currentpos = nextPos;
        return nextPos;


    }

}
