using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject mainImage; //アナウンスをする画像
    public GameObject buttonPanel; //ボタンをグループ化しているパネル

    public GameObject retryButton; //リトライボタン
    public GameObject nextButton; //ネクストボタン

    public Sprite gameClearSprite; //ゲームクリアの絵
    public Sprite gameOverSprite; //ゲームオーバーの絵

    TimeController timeCnt; //TimeController.csの参照
    public GameObject timeText;  //ゲームオブジェクトであるTimeText

    public GameObject scoreText; //スコアテキスト


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeCnt = GetComponent<TimeController>(); 

        buttonPanel.SetActive(false); //存在を非表示

        //時間差でメソッドを発動
        Invoke("InactiveImage",1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameState == "gameclear")
        {
            buttonPanel.SetActive(true); //ボタンパネルの復活
            mainImage.SetActive(true); //メイン画像の復活
            //メイン画像オブジェクトのImageコンポーネントが所持している変数sprite に ”ステージクリア”の絵を代入
            mainImage.GetComponent<Image>().sprite = gameClearSprite;
            //リトライボタンオブジェクトのButtonコンポーネントが所持している変数interactableを無効（ボタン機能を無効）
            retryButton.GetComponent<Button>().interactable = false;
        }
        else if (GameManager.gameState == "gameover")
        {
            buttonPanel.SetActive(true); //ボタンパネルの復活
            mainImage.SetActive(true); //メイン画像の復活
            //メイン画像オブジェクトのImageコンポーネントが所持している変数sprite に ”ゲームオーバー”の絵を代入
            mainImage.GetComponent<Image>().sprite = gameOverSprite;
            //ネクストボタンオブジェクトのButtonコンポーネントが所持している変数interactableを無効（ボタン機能を無効）
            nextButton.GetComponent<Button>().interactable = false;
        }
        else if(GameManager.gameState == "playing")
        {
            //いったんdisplayTimeの数字を変数timesに渡す
            float times = timeCnt.displayTime;
            timeText.GetComponent<TextMeshProUGUI>().text = Mathf.Ceil(times).ToString();
        }
    }

    //メイン画像を非表示するためだけのメソッド
    void InactiveImage()
    {
        mainImage.SetActive(false);
    }

    //スコアボードを更新
    void UpdataScore()
    {
        int score = GameManager.stageScore + GameManager.totalScore;
        scoreText.GetComponent<TextMeshProUGUI>().text = score.ToString();
    }



}
