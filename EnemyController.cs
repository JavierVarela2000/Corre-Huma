using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fuego"))
        {
            if (PlayerControler.sharedInstance.IsTouchingTheEnemyAtack())
            {
                Destroy(this.gameObject);
            }

        }
    }






}
