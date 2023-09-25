using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickMovement : MonoBehaviour
{
    
    public static JoyStickMovement Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<JoyStickMovement>();
                if(instance == null)
                {
                    var instanceContainer = new GameObject("JoyStickMovement");
                    instance = instanceContainer.AddComponent<JoyStickMovement>();
                }
            }
            return instance;
        }
    }

    private static JoyStickMovement instance = null;

    public GameObject smallStick;
    public GameObject bigStick;
    Vector3 stickFirstPosition;
    public Vector3 joyVec;
    Vector3 joyStickFirstPosition;
    float stickRadius;

    [SerializeField]
    public Animator ani;

    private void Start()
    {
        stickRadius = bigStick.gameObject.GetComponent<RectTransform>().sizeDelta.y / 2;
        joyStickFirstPosition = bigStick.transform.position;
    }

    public void PointDown()
    {
        bigStick.transform.position = Input.mousePosition;
        smallStick.transform.position = Input.mousePosition;
        stickFirstPosition = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3 DragPosition = pointerEventData.position;
        joyVec = (DragPosition - stickFirstPosition).normalized;
        ani.SetBool("Player_Walk", true);

        float stickDistacne = Vector3.Distance(DragPosition, stickFirstPosition);

        // 조이스틱 이미지 이동 - 조이스틱 큰 배경 안에서만 이뤄지도 
        if (stickDistacne < stickRadius)
        {
            smallStick.transform.position = stickFirstPosition + joyVec * stickDistacne;
        }
        else
        {
            smallStick.transform.position = stickFirstPosition + joyVec * stickRadius;
        }
    }

    public void Drop()
    {
        joyVec = Vector3.zero;

        //Drop 시 원위치로 이동
        bigStick.transform.position = joyStickFirstPosition;
        smallStick.transform.position = joyStickFirstPosition;

        //animation.setTrigger
        ani.SetBool("Player_Walk", false);
    }
}
