using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manChild : MonoBehaviour {
    
    public static manChild instance;
    public GameObject m_object;
    private GameObject m_sobject;
	// Use this for initialization
	void Start () {
        Vector3 def = new Vector3(-100, -100, 0);
        m_sobject = new GameObject();
        m_sobject = Instantiate(m_object, def, Quaternion.identity);
        m_sobject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
       if (PlayerController.player.hitSmoke)
        {
            m_sobject.transform.position = new Vector3(
                                                       PlayerController.player.whereX,
                                                       PlayerController.player.whereY,
                                                       PlayerController.player.whereZ);
            m_sobject.SetActive(true);
        }
    }
}
