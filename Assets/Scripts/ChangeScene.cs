using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName; //�؂�ւ������V�[�������w��
    public bool toTitle; //�^�C�g���ւ̐؂�ւ����ǂ����̃t���O

    //�V�[����؂�ւ���@�\�����������\�b�h�쐬
    public void Load()
    {
        //�V�[�����؂�ւ��ۂ͂�����ɂ��Ă��X�e�[�W�X�R�A�̓��Z�b�g
        GameManager.stageScore = 0;

        //toTitle�t���O��true�ɂȂ��Ă���ꍇ�̓^�C�g���ɖ߂邱�Ƃ��\�z�����̂Ńg�[�^���X�R�A�����Z�b�g
        if (toTitle) GameManager.totalScore = 0;


        //�����Ɏw�肵�����O�̃V�[���ɐ؂�ւ����Ă���郁�\�b�h�̌Ăяo��
        SceneManager.LoadScene(sceneName);
    }

}
