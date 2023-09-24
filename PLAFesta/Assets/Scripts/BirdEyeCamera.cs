using UnityEngine;

public class BirdEyeCamera : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // クリック位置をスクリーン座標からワールド座標に変換
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);



            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // ヒットしたオブジェクトからStandコンポーネントを取得
                Debug.Log(hit.collider.gameObject.name);
                Stand hitStand = hit.collider.GetComponent<Stand>();
                if (hitStand != null)
                {
                    hitStand.setStandPicture();
                }
            }
        }
    }
}
