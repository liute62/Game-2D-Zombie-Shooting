using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamingGUI : MonoBehaviour {

	// Use this for initialization
	public Text ScoreText;
	public Text TimeText;
	public Text GoldText;
	public Text ClipText;
	public Text CurrentHPText;
	public Image CurrentHPImage;
	private GameAttribute gameAttribute;
	private int CurrentWeaponIndex;
	public Image[] weaponImages;
	void Start () {
		gameAttribute = GameAttribute.instance;
		CurrentWeaponIndex = gameAttribute.currentWeaponIndex;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameAttribute == null){
			gameAttribute = GameAttribute.instance;
		}
		if(GameMaster.instance.isGameOver != true){
			ScoreText.text = gameAttribute.Score.ToString();
			setTimeText ();
			GoldText.text = gameAttribute.Gold.ToString ();
			setWeapon ();
			setCurrentHPText ();
		}
	}

	private void setTimeText(){
		string minute = gameAttribute.Minute.ToString();
		string second = "";
		if (gameAttribute.Second < 10) {
			second = "0"+gameAttribute.Second.ToString();
		}else{
			second = gameAttribute.Second.ToString();
		}
		TimeText.text = minute + ":" + second;
	}

	private void setWeapon(){
		CurrentWeaponIndex = gameAttribute.currentWeaponIndex;
		setWeaponImage(CurrentWeaponIndex);
		if (CurrentWeaponIndex == 0) {
			setNullClipText ();
		} else {
			setClipText();
		}
	}

	private void setWeaponImage(int index){
		for(int i = 0; i != weaponImages.Length; i++){
			if(i == index){
				//weaponImages[i].transform.position = new Vector3(0,0,0);	
				weaponImages[i].fillAmount = 100;
			}else{
				//weaponImages[i].transform.position = new Vector3(0,0,1000);	
				weaponImages[i].fillAmount = 0;
			}
		}
	}

	private void setClipText(){
		string clip = gameAttribute.Clip.ToString ();
		string leftClip = gameAttribute.LeftClip.ToString ();
		ClipText.text = clip + "/" + leftClip;
	}

	private void setCurrentHPText(){
		float result = gameAttribute.playerCurrentHealth / gameAttribute.playerMaxHealth;
		CurrentHPText.text = (result * 100).ToString() + "%";
		setCurrentImageText (result);
	}
	
	private void setNullClipText(){
		ClipText.text = "";
	}

	private void setCurrentImageText(float percent){
		CurrentHPImage.fillAmount = percent;
	}
}
