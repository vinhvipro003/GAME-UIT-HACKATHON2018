using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour {

    public bool canCreated = false;

    private void OnCollisionStay(Collision collision)
    {
        canCreated = true;
    }

    private IEnumerator Deplay(float sec)
    {
        yield return new WaitForSeconds(sec);
        canCreated = false;
    }
}
