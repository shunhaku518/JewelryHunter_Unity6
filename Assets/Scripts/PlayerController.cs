using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;  //Player�ɂ��Ă���Riggitbody2D���������߂̕ϐ�

    float axisH; //���͂̕������L�����邽�߂̕ϐ�


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>(); //Player�ɂ��Ă���R���|�[�l���g�����擾
    }

    // Update is called once per frame
    void Update()
    {
        //Velocity�̌��ƂȂ�l�̎擾(�E�Ȃ�1.0f�A���Ȃ�-1.0f�B�����Ȃ����0)
        axisH = Input.GetAxisRaw("Horizontal");

    }

    //1�b�Ԃ�50��(50fps)�J��Ԃ��悤�ɐ��䂵�Ȃ���s���J��Ԃ����\�b�h
    private void FixedUpdate()
    {
        //Velocity�ɒl����
        rbody.linearVelocity = new Vector2(axisH, 0);
    }
}
