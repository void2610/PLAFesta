using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour
{
    [SerializeField]
    private string name = null;
    private bool enabled = false;
    private Texture2D image = null;
    public void ShowInfo()
    {
        if (!enabled)
        {
            Debug.Log("Stand: " + name);
            enabled = true;
        }
        else if (enabled)
        {
            enabled = false;
        }
    }

    void Start()
    {
        image = Resources.Load<Texture2D>("StandInfo/" + name);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        //接触したオブジェクトのタグが"Player"のとき
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                ShowInfo();
            }
        }
    }
}
