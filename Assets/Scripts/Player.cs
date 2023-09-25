using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    
    private static Player instance = null;
    private Rigidbody rigid;
    [SerializeField]
    private Room room; 

    public static Player Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<Player>();
                if(Instance == null)
                {
                    var instanceContainer = new GameObject("Player");
                    instance = instanceContainer.AddComponent<Player>();
                }
            }
            return instance;
        }
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        /*float moveDirX = Input.GetAxisRaw("Horizontal");
        float moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * moveDirX;
        Vector3 moveVertical = transform.forward * moveDirZ;

        Vector3 _vcelocity = (moveHorizontal + moveVertical).normalized * moveSpeed;

        //rigid.MovePosition(transform.position + _velocity * Time.deltaTime);
        rigid.velocity = new Vector3(moveDirX * moveSpeed, rigid.velocity.y, moveDirZ * moveSpeed);
        *///rigid.velocity = _vcelocity;
        rigid.velocity = new Vector3(JoyStickMovement.Instance.joyVec.x, rigid.velocity.y, JoyStickMovement.Instance.joyVec.y).normalized * moveSpeed;
        rigid.rotation = Quaternion.LookRotation(new Vector3(JoyStickMovement.Instance.joyVec.x, 0, JoyStickMovement.Instance.joyVec.y));
    }

    void Targeting()
    {
        for(int i = 0; i < room.MonsterListInRoom.Count; 
        RaycastHit hit = Physics.Raycast(transform.position, room.MonsterListInRoom[index]);
    }
}
