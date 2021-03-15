using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ConveyorsWithModel : MonoBehaviour
{
    public GameObject model;
    public float speed;

    private Rigidbody rigid;
    private float offset = 0f;
    private float speedModel;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PhysicConveyors();
    }

    private void LateUpdate()
    {
        AnimateModel();
    }

    private void PhysicConveyors()
    {
        var pos = rigid.position;
        rigid.position += -transform.forward * speed * Time.deltaTime;
        rigid.MovePosition(pos);
    }

    private void AnimateModel()
    {
        speedModel = speed / 40;
        var rend = model.GetComponent<Renderer>();
        offset += -transform.forward.z * speedModel * Time.deltaTime;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        if (rend.material.GetTextureOffset("_MainTex").y < -2)
        {
            offset = 0;
        }
    }
}
