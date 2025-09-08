using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    float x, y, z; //�J�����̍��W�����߂邽�߂̕ϐ�

    [Header("�J�����̌��E�n")]
    public float leftLimit;
    public float rightLimit;
    public float topLimit;
    public float bottomLimit;

    [Header("�J�����̃X�N���[���ݒ�")]
    public bool isScrollX; //�������ɋ����X�N���[�����邩�̃t���O
    public float scrollSpeeedX = 0.5f;
    public bool isScrollY;�@//�������ɋ����X�N���[�����邩�̃t���O
    public float scrollSpeedY = 0.5f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Player�^�O���������Q�[���I�u�W�F�N�g��T���āA�ϐ�player�ɑ��
        player = GameObject.FindGameObjectWithTag("Player");
        //�J������Z���W�͏����l�̂܂܂��ێ�������

        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {


            //��������v���C���[��X���W�AY���W�̈ʒu��ϐ��Ɏ擾
            x = player.transform.position.x;
            y = player.transform.position.y;

            //���������̋����X�N���[���t���O�������Ă�����
            if (isScrollX)
            {
                //�O�̍��W�ɕϐ����������������W
                x = transform.position.x + (scrollSpeeedX * Time.deltaTime);
            }

            //���������E�̌��E�܂Ńv���C���[���ړ�������
            if (x < leftLimit)
            {
                x = leftLimit;
            }
            else if (x > rightLimit)
            {
                x = rightLimit;
            }

            //�������c�̋����X�N���[���t���O�������Ă�����
            if (isScrollY)
            {
                //�O�̍��W�ɕϐ����������������W
                y = transform.position.y + (scrollSpeedY * Time.deltaTime);
            }

            //�������㉺�̌��E�܂Ńv���C���[���ړ�������
            if (y < bottomLimit)
            {
                y = bottomLimit;
            }
            else if (y > topLimit)
            {
                y = topLimit;
            }

        

        //��茈�߂��e�ϐ�x,y,z�̒l���J�����̃|�W�V�����Ƃ���
        transform.position = new Vector3(x, y, z);
        
        }
    }
}
