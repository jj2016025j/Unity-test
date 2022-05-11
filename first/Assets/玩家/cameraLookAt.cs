using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraLookAt : MonoBehaviour
{
    //定義鏡頭與角色的初始距離，開始的時候定義成私有變量，我改成公有變量，爲了方便在代碼面板上修改
    public float m_distanceAway = 4.5f;
    //鏡頭初始高度
    public float m_distanceUp = 1.5f;
    //鏡頭改變時的平滑度
    private float m_smooth = 5f;
    //玩家對象
    public Transform m_player;
    //自己
    private Transform m_transsform;

    private float maxSuo = 100.0f;//鏡頭縮放範圍
    private float minSuo = 2.0f;

    private float maxSD = 20.0f;
    private float minSD = 1f;
    void Start()
    {
        m_transsform = this.transform;//定義自己
        m_player = GameObject.Find("Player").transform;
    }


    void Update()
    {
        Zoom();//縮放
        CameraSet();//相機設置
        //定義一條射線
        RaycastHit hit;
        if (Physics.Linecast(m_player.position + Vector3.up, m_transsform.position, out hit))
        {
            string name = hit.collider.gameObject.tag;
            if (name != "MainCamera")
            {
                //如果射線碰撞的不是相機，那麼就取得射線碰撞點到玩家的距離
                float currentDistance = Vector3.Distance(hit.point, m_player.position);
                //如果射線碰撞點小於玩家與相機本來的距離，就說明角色身後是有東西，爲了避免穿牆，就把相機拉近
                if (currentDistance < m_distanceAway)
                {
                    m_transsform.position = hit.point;
                }
            }
        }
    }
    /// <summary>
    /// 設置相機
    /// </summary>
    void CameraSet()
    {
        //取得相機旋轉的角度
        float m_wangtedRotationAngel = m_player.transform.eulerAngles.y;
        //獲取相機移動的高度
        float m_wangtedHeight = m_player.transform.position.y + m_distanceUp;
        //獲得相機當前角度
        float m_currentRotationAngle = m_transsform.eulerAngles.y;
        //獲取相機當前的高度
        float m_currentHeight = m_transsform.position.y;
        //在一定時間內將當前角度更改爲角色面對的角度
        m_currentRotationAngle = Mathf.LerpAngle(m_currentRotationAngle, m_wangtedRotationAngel, m_smooth * Time.deltaTime);
        //更改當前高度
        m_currentHeight = Mathf.Lerp(m_currentHeight, m_wangtedHeight, m_smooth * Time.deltaTime);
        //返回一個Y軸旋轉玩家當前角度那麼多的度數
        Quaternion m_currentRotation = Quaternion.Euler(0, m_currentRotationAngle, 0);
        //玩家的位置
        Vector3 m_position = m_player.transform.position;
        //相機位置差不多計算出來了
        m_position -= m_currentRotation * Vector3.forward * m_distanceAway;
        //將相機應當到達的高度加進應當到達的座標，這就是相機的新位置
        m_position = new Vector3(m_position.x, m_currentHeight, m_position.z);
        m_transsform.position = Vector3.Lerp(m_transsform.position, m_position, Time.time);
        //注視玩家
        m_transsform.LookAt(m_player);
    }

    /// <summary>
    /// 按鼠標滾輪縮放
    /// </summary>
    void Zoom()
    {
        //實現滑輪拖動
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= maxSuo)//縮放的範圍
            {
                Camera.main.fieldOfView += 2;
            }
            if (Camera.main.orthographicSize <= maxSD)
            {
                Camera.main.orthographicSize += 0.5f;
            }
        }

        //Zoom in
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView >= minSuo)
            {
                Camera.main.fieldOfView -= 2;
            }
            if (Camera.main.orthographicSize >= minSD)
            {
                Camera.main.orthographicSize -= 0.5f;
            }
        }
    }
}