using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Conveyors : MonoBehaviour
{
    public float speed;
    private Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var pos = rigid.position;
        rigid.position += -transform.forward * speed * Time.deltaTime;
        rigid.MovePosition(pos);
    }
}
