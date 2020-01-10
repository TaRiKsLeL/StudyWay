using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float m_Speed = 1f;
    Rigidbody m_Rigidbody;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * 7 * m_Speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * 7 * m_Speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * m_Speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * m_Speed * Time.deltaTime;
        }

    }

    public void Idle_Ani()
    {
        anim.SetTrigger("Idle");
    }

    public void Move_Ani()
    {
        anim.SetTrigger("Move");

    }

    public void Damage_Ani()
    {
        anim.SetTrigger("Damage");
    }

    public void Death_Ani()
    {
        anim.SetTrigger("Death");
    }

}