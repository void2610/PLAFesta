using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform targetTransform;  // 目標座標と角度のTransform
    public float moveSpeed = 5f;       // 移動速度
    public float rotationSpeed = 90f;  // 回転速度
    public bool isMoving = false;     // 移動中かどうかを示すフラグ
    public GameObject targetObject;

    private void Start()
    {
        // ターゲットのTransformを設定します
        targetTransform = this.transform;
    }

    private void Update()
    {
        // スペースキーが押されたら移動を開始または停止します
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = !isMoving;
        }

        if (isMoving)
        {
            // 目標座標への方向ベクトルを計算します
            Vector3 targetPosition = targetTransform.position;

            // 目標の角度への回転を計算します
            Quaternion targetRotation = targetTransform.rotation;

            // 移動と回転を滑らかに補間します
            targetObject.transform.position = Vector3.Lerp(targetObject.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            targetObject.transform.rotation = Quaternion.RotateTowards(targetObject.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            float positionDistance = Vector3.Distance(targetObject.transform.position, targetPosition);
            float rotationAngle = Quaternion.Angle(targetObject.transform.rotation, targetRotation);
            if (positionDistance < 0.01f && rotationAngle < 1.0f)
            {
                isMoving = false;
            }
        }
    }
}
