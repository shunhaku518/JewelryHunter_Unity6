using TMPro;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public GameObject scoreText;

    void Start()
    {
        //���U���g��ʂ�ScoreText�I�u�W�F�N�g������
        //TextMeshPro(UGUI)��text����
        //GameManager��static�ϐ��ł���totalScore����
        //��������string�^�Ɍ^�ϊ����K�v
        scoreText.GetComponent<TextMeshProUGUI>().text = GameManager.totalScore.ToString();

    }
}