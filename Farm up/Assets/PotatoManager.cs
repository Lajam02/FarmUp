using UnityEngine;
using System.Collections.Generic;
public class PotatoManager : MonoBehaviour
{


    [SerializeField] private List<PotatoManController> led = new List<PotatoManController>();


    [SerializeField] private bool makeQueue = true;
    [SerializeField] private Vector3 nextPos;
}
   /* public void Update()
    {

        // while (makeQueue)
        //{
        for (int i = 0; i < led.Count; i++)
        {
            PotatoManController currentPotato = led[i];
            if (i == 0)
            {
                currentPotato.setNextMovement();
                nextPos = currentPotato.getCurrentPos();

            }
            else
            {
                //Debug.Log();
                currentPotato.setCurrentPos(nextPos);
                nextPos = currentPotato.getCurrentPos();
            }

            //  }
        }
    }
}
*/
   
    
