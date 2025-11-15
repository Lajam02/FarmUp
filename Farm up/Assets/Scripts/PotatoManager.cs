using UnityEngine;
using System.Collections.Generic;
public class PotatoManager : MonoBehaviour
{


    [SerializeField] private List<PotatoManController> queue = new List<PotatoManController>();


    [SerializeField] private bool makeQueue = true;
    // [SerializeField] private Vector3 nextPos;

    public void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W)){
            queue[0].moving_first(new Vector3(0,1,0));
        }
        if(Input.GetKey(KeyCode.S)){
            queue[0].moving_first(new Vector3(0,-1,0));
        }
        if(Input.GetKey(KeyCode.A)){
            queue[0].moving_first(new Vector3(-1,0,0));
        }if(Input.GetKey(KeyCode.D)){
            queue[0].moving_first(new Vector3(1,0,0));
        }
        for (int i = 1; i < queue.Count; i++){
            // if(i == 0){
            //     queue[i].moving_first();
            // }
            queue[i].setCurrentPos(queue[i-1].transform.position);
            queue[i].moving();

            //range.currentTarget.distance. 50 px
        }


    }
}