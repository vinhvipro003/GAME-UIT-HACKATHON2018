using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {

    public static int numCreate = 0;
    public int create;

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag.Equals("Die") || other.gameObject.tag.Equals("Fight") || other.gameObject.tag.Equals("Coin") || other.gameObject.tag.Equals("Lethal") || other.gameObject.tag.Equals("PowerUp"))
        {
            GameObject latter = (other.gameObject.GetComponent<Column>().create < this.create) ? this.gameObject : other.gameObject;
            latter.SetActive(false);
        }

    }

}
