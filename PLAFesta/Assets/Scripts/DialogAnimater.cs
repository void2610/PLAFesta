using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// ダイアログのアニメーション
/// </summary>
public class DialogAnimater : MonoBehaviour
{

    public static DialogAnimater instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public float maxScale = 1f;
    public bool IsOpen = false;
    public Image image;
    private float openStartTime = 0f;
    private float closeStartTime = 0f;
    private float animationTime = 0.2f;

    private bool isOpening = false;
    private bool isClosing = false;

    // ダイアログを開く
    public void Open()
    {
        if (IsOpen) return;

        openStartTime = Time.time;
        IsOpen = true;
        isOpening = true;
    }

    // ダイアログを閉じる
    public void Close()
    {
        if (!IsOpen) return;

        closeStartTime = Time.time;
        IsOpen = false;
        isClosing = true;
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOpening || isClosing || this.image.sprite == null) return;
            if (IsOpen)
            {
                Close();
            }
            else
            {
                Open();
            }
        }

        if (isOpening)
        {
            //imageの大きさを大きくする
            image.rectTransform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * maxScale, (Time.time - openStartTime) / animationTime);
        }

        if (isClosing)
        {
            //imageの大きさを小さくする
            image.rectTransform.localScale = Vector3.Lerp(Vector3.one * maxScale, Vector3.zero, (Time.time - closeStartTime) / animationTime);
        }

        if (Time.time - openStartTime > animationTime)
        {
            isOpening = false;
        }

        if (Time.time - closeStartTime > animationTime)
        {
            isClosing = false;
        }
    }
}