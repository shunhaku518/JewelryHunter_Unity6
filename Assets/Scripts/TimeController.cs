using UnityEngine;

public class TimeController : MonoBehaviour
{
    //�J�E���g�_�E���ɂ��邩�ǂ����̃t���O
    //false�Ȃ�J�E���g�A�b�v
    public bool isCountDown = false;

    //�Q�[���̊�ƂȂ鎞��
    public float gameTime = 0;

    //�J�E���g�_�E�����~�߂�ǂ����̃t���O
    //false�Ȃ�J�E���g��������Atrue�Ȃ�J�E���g�I��
    public�@bool isTimeOver = false;

    //���[�U�[�Ɍ����鎞��
    public float displayTime = 0;

    //�Q�[���̌o�ߎ���
    float times = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�����J�E���g�_�E���ł���Ί���Ԃ����[�U�[�Ɍ�����悤�ɂ���
        if (isCountDown)
        {
            displayTime = gameTime;

        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (isTimeOver == false)
        if(!isTimeOver) 
        {
            //��~�t���O�������Ă��Ȃ��̂ŏ�����������
            //�Q�[���X�e�[�^�X��playing�łȂ��Ȃ������͎~�߂���
            if(GameManager.gameState != "playing")
            {
                isTimeOver = true; //��~�t���O��ON
            }

            //�J�E���g�̏�������

            //�o�ߎ��Ԃ̒~��
            times += Time. deltaTime; //�f���^�^�C���̒~��

            if(isCountDown)
            {
                //���[�U�[�Ɍ����������ԁi�c���ԁj
                //�c���ԂɁi�����-�o�ߎ��ԁj����
                displayTime = gameTime - times;

                if(displayTime <= 0)
                {
                    displayTime = 0; //0�Ƃ����\�L�ɓ���
                    isTimeOver = true; //��~�t���O��ON
                    GameManager.gameState = "gameover";
                }

            }

            else //�J�E���g�A�b�v�`���������ꍇ
            {
                //�o�ߎ��Ԃ����[�U�[�Ɍ����������Ԃɑ��
                displayTime = times;
                if(displayTime >= gameTime)
                {
                    //���[�U�[�Ɍ����������Ԃ�����Ԃɂ���
                    displayTime = gameTime;
                    isTimeOver = true; //��~�t���O��ON
                    GameManager.gameState = "gameover";
                }
            }

            Debug.Log(displayTime);
        }
    }
}
