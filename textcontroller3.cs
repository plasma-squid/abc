using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.IO; 
using static ImageEXT;


public class textcontroller3 : MonoBehaviour 
{
	//gitの確認用に挿入

	//sourcetree確認用に挿入->ヤマキタ
	//codeを追加->ヤマキタ
	private string name = "ヤマキタ";

	//練習用にさらに追加
	//さらに追加
	//さらに追加

    public Text nameText;//publicで宣言した〇〇型の変数はinspectorから素材を指定できる
    public Text mainText;
    public Image nameImage;
    public Image mainImage;
    public Image leftImage;
    public Image rightImage;
	public Image centerImage;
    public Image background;
    public Sprite[] background1;//[]は配列であり、inspectorから複数指定できる
    public Sprite[] chara1_Sprites;
    public Sprite[] chara2_Sprites;
    public Sprite[] chara3_Sprites;
    public Sprite[] chara4_Sprites;
    public Sprite[] chara5_Sprites;
    public Sprite[] chara6_Sprites;	


    Entity_Sheet1 es;//ここは毎度要チェック
	[SerializeField] Text uiText;

	[SerializeField][Range(0.001f, 0.3f)]
	float intervalForCharacterDisplay = 0.05f;//会話送りのスピードを0.001から0.3の間で選択できる。デフォルトは0.05

	private string currentText = string.Empty;
	private float timeUntilDisplay = 0;
	private float timeElapsed = 1;
	private int i = 1;
	private int lastUpdateCharacter = -1;

	// 文字の表示が完了しているかどうか
	public bool IsCompleteDisplayText 
	{
		get { return  Time.time > timeElapsed + timeUntilDisplay; }//後々のif文のためにget returnを使っているだけ
	}

	void Start()
	{
        leftImage.enabled = false;
        rightImage.enabled = false;
		centerImage.enabled=false;
        es = Resources.Load("common") as Entity_Sheet1;//scriptableobjectから読み取り
		SetNextLine();
	}

	void Update () 
	{
		// 文字の表示が完了してるならクリック時に次の行を表示する
		if( IsCompleteDisplayText ){//bool型のIsCompleteDisplay関数がtrue、つまり現在の時間がある1文表示のための時間より経っているか＝表示完了しているか
			if(i < es.param.Count && Input.GetMouseButtonDown(0)){//マウスクリックかつ
				SetNextLine();
			}
		}else{
		// 完了してないなら文字をすべて表示する
			if(Input.GetMouseButtonDown(0)){
				timeUntilDisplay = 0;//マウスをクリックしたら文字の表示時間を0にして強制的に表示させる
			}
		}

		int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);//Mathf.Clamp01は0から1の間に制限。割合の計算で便利
        //範囲内に収めた値=Mathf.Clamp(範囲内に指定したい値,最小値,最大値);
		if( displayCharacterCount != lastUpdateCharacter ){
			uiText.text = currentText.Substring(0, displayCharacterCount);
			lastUpdateCharacter = displayCharacterCount;
		}
	}


	void SetNextLine()
	{
		DisplayBackground();
		DisplayChara();
        nameText.text=es.param[i].name;//表示したい名前をtextオブジェクトに入れる。i=0は宣言済み
		currentText = es.param[i].conversation; //表示したい文をcurrenttextに入れる
		timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;//入れた文の長さと1文字ずつ表示する時間をかけて、1つの文の表示にかける時間とする
		timeElapsed = Time.time;//開始からの時間を代入
		i ++;//次の名前と文を表示するためにiを1つ増やす
		lastUpdateCharacter = -1;//この変数を初期化
	}

    void DisplayChara(){//取得した名前に合わせてキャラを表示
            switch(es.param[i].name){
                case "コナー": if(es.param[i].position=="左"){
					leftImage.enabled = false;
					leftImage.enabled = true;
                	leftImage.sprite = chara1_Sprites[0];
				}else if(es.param[i].position=="中"){
					centerImage.enabled=false;
					centerImage.enabled = true;
					centerImage.sprite = chara1_Sprites[0];
				}else if(es.param[i].position=="右"){
					rightImage.enabled = false;
					rightImage.enabled = true;
					rightImage.sprite = chara1_Sprites[0];
				}
                break;
                case "フレディ": if(es.param[i].position=="左"){
					leftImage.enabled = false;
					leftImage.enabled = true;
                	leftImage.sprite = chara2_Sprites[0];
				}else if(es.param[i].position=="中"){
					centerImage.enabled=false;
					centerImage.enabled = true;
					centerImage.sprite = chara2_Sprites[0];
				}else if(es.param[i].position=="右"){
					rightImage.enabled = false;
					rightImage.enabled = true;
					rightImage.sprite = chara2_Sprites[0];
				}
                break;
                case "ハーマン": if(es.param[i].position=="左"){
					leftImage.enabled = false;
					leftImage.enabled = true;
                	leftImage.sprite = chara3_Sprites[0];
				}else if(es.param[i].position=="中"){
					centerImage.enabled=false;
					centerImage.enabled = true;
					centerImage.sprite = chara3_Sprites[0];
				}else if(es.param[i].position=="右"){
					rightImage.enabled = false;
					rightImage.enabled = true;
					rightImage.sprite = chara3_Sprites[0];
				}
				break;
                case "イザベラ": if(es.param[i].position=="左"){
					leftImage.enabled = false;
					leftImage.enabled = true;
                	leftImage.sprite = chara4_Sprites[0];
				}else if(es.param[i].position=="中"){
					centerImage.enabled=false;
					centerImage.enabled = true;
					centerImage.sprite = chara4_Sprites[0];
				}else if(es.param[i].position=="右"){
					rightImage.enabled = false;
					rightImage.enabled = true;
					rightImage.sprite = chara4_Sprites[0];
				}
                break;
                case "ジャック": if(es.param[i].position=="左"){
					leftImage.enabled = false;
					leftImage.enabled = true;
                	leftImage.sprite = chara5_Sprites[0];
				}else if(es.param[i].position=="中"){
					centerImage.enabled=false;
					centerImage.enabled = true;
					centerImage.sprite = chara5_Sprites[0];
				}else if(es.param[i].position=="右"){
					rightImage.enabled = false;
					rightImage.enabled = true;
					rightImage.sprite = chara5_Sprites[0];
				}
                break;
                case "オリヴィア": if(es.param[i].position=="左"){
					leftImage.enabled = false;
					leftImage.enabled = true;
                	leftImage.sprite = chara6_Sprites[0];
				}else if(es.param[i].position=="中"){
					centerImage.enabled=false;
					centerImage.enabled = true;
					centerImage.sprite = chara6_Sprites[0];
				}else if(es.param[i].position=="右"){
					rightImage.enabled = false;
					rightImage.enabled = true;
					rightImage.sprite = chara6_Sprites[0];
				} 
                break;				
            }
	}
    

	void DisplayBackground(){
		switch(es.param[i].back){
			case "大広間" : background.sprite = background1[0];
			break;
			case "ダイニング":background.sprite = background1[1];
			break;
			case "キッチン":background.sprite = background1[2];
			break;
			case "書斎":background.sprite = background1[3];
			break;
			case "フレディの部屋":background.sprite = background1[4];
			break;
			case "コナーの部屋":background.sprite = background1[5];
			break;
			case "イザベラの部屋":background.sprite = background1[6];
			break;
			case "ハーマンの部屋":background.sprite = background1[7];
			break;
			case "黒":background.sprite = background1[8];
			break;
			case "暗転" : StartCoroutine("ChangeAlpha");
			break;
		}
	}

	IEnumerator ChangeAlpha(){
		GameObject target = GameObject.Find("alphachange");
		Image image = target.GetComponent<Image>();
		float k=0f;
		while(k<1.0f){
			image.SetOpacity(k);
			k=k+0.005f;
			yield return null;
		}
		yield return new WaitForSeconds(2.0f);
		k=1.0f;
		while(k>0f){
			image.SetOpacity(k);
			k=k-0.005f;
			yield return null;
		}
		yield return null;
	}	
	
}

/*void SetNextLine()
	{
		currentText = scenarios[currentLine];
		timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
		timeElapsed = Time.time;
		currentLine ++;
		lastUpdateCharacter = -1;
	}*/

