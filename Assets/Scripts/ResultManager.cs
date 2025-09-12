using TMPro;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public GameObject scoreText;

    void Start()
    {
        //リザルト画面のScoreTextオブジェクトがもつ
        //TextMeshPro(UGUI)のtext欄に
        //GameManagerのstatic変数であるtotalScoreを代入
        //※ただしstring型に型変換が必要
        scoreText.GetComponent<TextMeshProUGUI>().text = GameManager.totalScore.ToString();

    }
}