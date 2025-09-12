using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    //�����ȒB
    public AudioClip bgm_Title;
    public AudioClip bgm_Stage;
    public AudioClip bgm_Result;
    public AudioClip bgm_GameClear;
    public AudioClip bgm_GameOver;

    AudioSource audio; //Canvas�ɂ��Ă���AudioSource�̏��

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>(); //AudioSource�̏��擾

        //���݃V�[�����̎擾
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Title")
        {
            //�^�C�g���̋Ȃ�炷����
            PlayBGM(bgm_Title);
        }
        else if (currentSceneName == "Result")
        {
            //���U���g�̋Ȃ�炷����
            PlayBGM(bgm_Result);
        }
        else
        {
            //�X�e�[�W�̋Ȃ�炷����
            PlayBGM(bgm_Stage);
        }
    }

    //�����Ɏw�肵���Ȃ�炷���\�b�h
    void PlayBGM(AudioClip clip)
    {
        audio.clip = clip;
        audio.loop = true; //BGM�̓��[�v����ݒ�
        audio.Play(); //�Đ�����
    }


}
