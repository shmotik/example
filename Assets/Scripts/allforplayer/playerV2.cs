using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerV2 : MonoBehaviour
{
    public float speed_Move;
    float x_Move;
    float z_move;
    CharacterController player;
    Vector3 move_Direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        x_Move = Input.GetAxis("Horizontal");
        z_move = Input.GetAxis("Vertical");
        if (player.isGrounded)
        {
            move_Direction = new Vector3(x_Move, 0f, z_move);
            move_Direction = transform.TransformDirection(move_Direction);
        }
        move_Direction.y -= 1;
        player.Move(move_Direction * speed_Move * Time.deltaTime);
    }
    
  
}
