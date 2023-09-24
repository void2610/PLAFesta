using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stand : MonoBehaviour
{
    [SerializeField]
    private string standName = "stand";
    private bool IsOpen = false;
    private Sprite image = null;
    public void setStandPicture()
    {
        DialogAnimater.instance.image.sprite = this.image;
    }

    void Start()
    {
        image = Resources.Load<Sprite>("StandInfo/" + standName);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        //接触したオブジェクトのタグが"Player"のとき
        if (other.gameObject.name == "Player")
        {
            DialogAnimater.instance.image.sprite = this.image;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //接触したオブジェクトのタグが"Player"のとき
        if (other.gameObject.name == "Player")
        {
            DialogAnimater.instance.image.sprite = null;
        }
    }
}