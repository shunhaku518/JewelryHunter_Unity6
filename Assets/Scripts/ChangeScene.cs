using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneName; //�؂�ւ������V�[�������w��

    //�V�[����؂�ւ���@�\�����������\�b�h�쐬
    public void Load()
    {
        //�����Ɏw�肵�����O�̃V�[���؂�ւ����Ă���郁�\�b�h�Ăяo��
        SceneManager.LoadScene(sceneName);
    }
   
}
