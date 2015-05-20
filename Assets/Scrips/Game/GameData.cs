using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

	public static void Reset(){
		setCurrentLevel (1);
		setMaxHealth (Human.maxHealth[0]);
		setCurrentHealth (Human.currentHealth[0]);
		setGold (0);
		setScore (0);
		setCurrentWeaponIndex (0);
		setPlayerInitialSpeed (5);
		resetZombie ();
		setKeyGetByLevel (1,0);
	}

	public static void resetZombie(){
		setZombieInitialSpeedByIndex (0,5);
		setZombieInitialAttackByIndex (0,10);
		setZombieInitialAttackIntervelByIndex (0,1);
		setZombieInitialAttackRangeByIndex (0,1.5f);
		setZombieInitialFindRangeByIndex (0,10);
		setZombieInitialHealthByIndex (0,100);
		setZombieInitialScoreByIndex (0, "100");
		setZombieInitialGoldByIndex (0,"100");

		setZombieInitialSpeedByIndex (1,6);
		setZombieInitialAttackByIndex (1,15);
		setZombieInitialAttackIntervelByIndex (1,2);
		setZombieInitialAttackRangeByIndex (1,2f);
		setZombieInitialFindRangeByIndex (1,20);
		setZombieInitialHealthByIndex (1,200);
		setZombieInitialScoreByIndex (1, "300");
		setZombieInitialGoldByIndex (1,"200");

		setZombieInitialSpeedByIndex (2,6);
		setZombieInitialAttackByIndex (2,15);
		setZombieInitialAttackIntervelByIndex (2,2);
		setZombieInitialAttackRangeByIndex (2,2f);
		setZombieInitialFindRangeByIndex (2,20);
		setZombieInitialHealthByIndex (2,200);
		setZombieInitialScoreByIndex (2, "300");
		setZombieInitialGoldByIndex (2,"200");

		setZombieInitialSpeedByIndex (2,6);
		setZombieInitialAttackByIndex (2,15);
		setZombieInitialAttackIntervelByIndex (2,2);
		setZombieInitialAttackRangeByIndex (2,2f);
		setZombieInitialFindRangeByIndex (2,20);
		setZombieInitialHealthByIndex (2,200);
		setZombieInitialScoreByIndex (2, "300");
		setZombieInitialGoldByIndex (2,"200");
	}

	public class Human{
		public static string name = "Human";
		public static float initialSpeed = 1;
		public static float turnSpeed = 2;
		public static float [] currentHealth = {100,200,300};
		public static float [] maxHealth = {100,200,300};
		public static int index;
	}

	public class Weapon{
		
		public class Pistol{
			public static int power = 20;
		}

		public class Rifile{
			public static int power = 40;
		}
	}

	public class Level_1{

		public class General{
			public static int timeMinute = 10;
			public static int timeSecond = 0;
		}

		public class Zombie{
			public static string [] zombieName = {
				"Zombie_1","Zombie_2"
			};
			public static float [] zombieAttack = {
				1,2,3,4
			};
			public static float [] zombieAttackRange = {
				1,2,3,4
			};
			public static float [] zombieAttackIntervel = {
				1,2,3,4
			};
			public static float [] zombieInitialSpeed = {
				1,2,3,4
			};
			public static float [] zombieHealth = {
				100,200,300,400
			};
			public static float [] zombieScore = {
				100,200,300,400
			};
		}
	}

	public class Level_2{
		public class General{
			public static int timeMinute = 3;
			public static int timeSecond = 0;
		}
	}

	public class Level_3{
		public class General{
			public static int timeMinute = 20;
			public static int timeSecond = 0;
		}
	}

	public static void saveTheGame(){
	
	}
	/**********************Player**********************/
	public static float getPlayerInitialSpeed(){
		return PlayerPrefs.GetFloat ("Player_InitialSpeed");
	}

	public static void setPlayerInitialSpeed(float speed){
		PlayerPrefs.SetFloat ("Player_InitialSpeed",speed);
	}

	/**********************Zombie**********************/
	public static float getZombieInitialSpeedByIndex(int index){
		return PlayerPrefs.GetFloat ("Zombie_"+index.ToString()+"_InitialSpeed");
	}

	public static void setZombieInitialSpeedByIndex(int index,float speed){
		PlayerPrefs.SetFloat ("Zombie_"+index.ToString()+"_InitialSpeed",speed);
	}

	public static float getZombieInitialAttackByIndex(int index){
		return PlayerPrefs.GetFloat ("Zombie_"+index.ToString()+"_InitialAttack");
	}
	
	public static void setZombieInitialAttackByIndex(int index,float attack){
		PlayerPrefs.SetFloat ("Zombie_"+index.ToString()+"_InitialAttack",attack);
	}

	public static float getZombieInitialAttackRangeByIndex(int index){
		return PlayerPrefs.GetFloat ("Zombie_"+index.ToString()+"_InitialAttackRange");
	}
	
	public static void setZombieInitialAttackRangeByIndex(int index,float attackRange){
		PlayerPrefs.SetFloat ("Zombie_"+index.ToString()+"_InitialAttackRange",attackRange);
	}

	public static float getZombieInitialAttackIntervelByIndex(int index){
		return PlayerPrefs.GetFloat ("Zombie_"+index.ToString()+"_InitialAttackIntervel");
	}
	
	public static void setZombieInitialAttackIntervelByIndex(int index,float attackIntervel){
		PlayerPrefs.SetFloat ("Zombie_"+index.ToString()+"_InitialAttackIntervel",attackIntervel);
	}

	public static float getZombieInitialFindRangeByIndex(int index){
		return PlayerPrefs.GetFloat ("Zombie_"+index.ToString()+"_InitialFindRange");
	}
	
	public static void setZombieInitialFindRangeByIndex(int index,float findRange){
		PlayerPrefs.SetFloat ("Zombie_"+index.ToString()+"_InitialFindRange",findRange);
	}

	public static float getZombieHealthByIndex(int index){
		return PlayerPrefs.GetFloat ("Zombie_"+index.ToString()+"_InitialHealth");
	}
	
	public static void setZombieInitialHealthByIndex(int index,float health){
		PlayerPrefs.SetFloat ("Zombie_"+index.ToString()+"_InitialHealth",health);
	}

	public static string getZombieInitialScoreByIndex(int index){
		return PlayerPrefs.GetString ("Zombie_"+index.ToString()+"_InitialScore");
	}
	
	public static void setZombieInitialScoreByIndex(int index,string score){
		PlayerPrefs.SetString ("Zombie_"+index.ToString()+"_InitialScore",score);
	}

	public static string getZombieInitialGoldByIndex(int index){
		return PlayerPrefs.GetString ("Zombie_"+index.ToString()+"_InitialGold");
	}
	
	public static void setZombieInitialGoldByIndex(int index,string gold){
		PlayerPrefs.SetString ("Zombie_"+index.ToString()+"_InitialGold",gold);
	}


	/**********************Level**********************/
	public static int getCurrentLevel(){
		return PlayerPrefs.GetInt ("Level_Current");
	}

	public static void setCurrentLevel(int level){
		PlayerPrefs.SetInt ("Level_Current",level);
	}

	public static void setNextLevel(){
		int level = getCurrentLevel ();
		level++;
		PlayerPrefs.SetInt ("Level_Current",level);
	}

	public static string getCurrentLevelName(){
		int index = GameData.getCurrentLevel ();
		return getLevelNameByIndex (index);
	}
	public static string getLevelNameByIndex(int index){
		string result = "";
		switch (index) {
			case 1:
				result = "CollapsedBuildingLevel";
				break;
			case 2:
				result = "StreetLevel";
				break;
			case 3:
				result = "shelter_level";
				break;
		}
		return result;
	}

	/**********************Health**********************/
	public static float getMaxHealth(){
		return PlayerPrefs.GetFloat("Player_Max_Health");
	}

	public static void setMaxHealth(float health){
		PlayerPrefs.SetFloat ("Player_Max_Health",health);
	}

	public static void setCurrentHealth(float health){
		PlayerPrefs.SetFloat ("Player_Current_Health",health);
	}

	public static float getCurrentHealth(){
		return PlayerPrefs.GetFloat ("Player_Current_Health");
	}

	/**********************Gold**********************/
	public static int getGold(){
		return PlayerPrefs.GetInt ("Player_Gold");
	}

	public static void setGold(int value){
		PlayerPrefs.SetInt ("Player_Gold",value);
	}

	/**********************Score**********************/
	public static string getScore(){
		string tmp = PlayerPrefs.GetString ("Player_Score");
		if (tmp == null || tmp.Trim ().Equals ("")) {
			tmp = "0";
		}
		return tmp;
	}

	public static void setScore(long score){
		PlayerPrefs.SetString ("Player_Score",score.ToString());
	}

	public static void setScore(string score){
		PlayerPrefs.SetString ("Player_Score",score);
	}

	public static void setScore(int score){
		PlayerPrefs.SetString ("Player_Score",score.ToString());
	}

	/**********************Weapon**********************/
	public static int getCurrentWeaponIndex(){
		return PlayerPrefs.GetInt ("Weapon_Current_Index");
	}

	public static void setCurrentWeaponIndex(int index){
		PlayerPrefs.SetInt ("Weapon_Current_Index",index);
	}

	public static int getCurrentWeaponPower(){
		int index = getCurrentWeaponIndex ();
		return PlayerPrefs.GetInt ("Weapon_Current_"+index.ToString()+"_"+"Power");
	}
	
	public static void setCurrentWeaponPower(int power){
		int index = getCurrentWeaponIndex ();
		PlayerPrefs.SetInt ("Weapon_Current_"+index.ToString()+"_"+"Power",power);
	}

	public static int getCurrentWeaponAmmoInitial(){
		int index = getCurrentWeaponIndex ();
		return PlayerPrefs.GetInt("Weapon_Current_"+index.ToString()+"_"+"Ammo"+"_Initial");
	}
	
	public static void setCurrentWeaponAmmoInitial(int ammo){
		int index = getCurrentWeaponIndex ();
		PlayerPrefs.SetInt("Weapon_Current_"+index.ToString()+"_"+"Ammo"+"_Initial",ammo);
	}
	
	public static int getCurrentWeaponAmmoUsing(){
		int index = getCurrentWeaponIndex ();
		return PlayerPrefs.GetInt("Weapon_Current_"+index.ToString()+"_"+"Ammo"+"_Using");
	}

	public static void setCurrentWeaponAmmoUsing(int ammo){
		int index = getCurrentWeaponIndex ();
		PlayerPrefs.SetInt("Weapon_Current_"+index.ToString()+"_"+"Ammo"+"_Using",ammo);
	}

	public static int getCurrentWeaponAmmoInitialUsing(){
		int index = getCurrentWeaponIndex ();
		return PlayerPrefs.GetInt("Weapon_Current_"+index.ToString()+"_"+"Ammo"+"_InitialUsing");
	}
	
	public static void setCurrentWeaponAmmoInitialUsing(int ammo){
		int index = getCurrentWeaponIndex ();
		PlayerPrefs.SetInt("Weapon_Current_"+index.ToString()+"_"+"Ammo"+"_InitialUsing",ammo);
	}


	public static int getCurrentWeaponAmmoLeft(){
		int index = getCurrentWeaponIndex ();
		return PlayerPrefs.GetInt("Weapon_Current_"+index.ToString()+"_"+"Ammo"+"_Left");
	}
	
	public static void setCurrentWeaponAmmoLeft(int ammo){
		int index = getCurrentWeaponIndex ();
		PlayerPrefs.SetInt("Weapon_Current_"+index.ToString()+"_"+"Ammo"+"_Left",ammo);
	}

	public static int getCurrentWeaponAmmoInitialLeft(){
		int index = getCurrentWeaponIndex ();
		return PlayerPrefs.GetInt("Weapon_Current_"+index.ToString()+"_"+"Ammo"+"_InitialLeft");
	}
	
	public static void setCurrentWeaponAmmoInitialLeft(int ammo){
		int index = getCurrentWeaponIndex ();
		PlayerPrefs.SetInt("Weapon_Current_"+index.ToString()+"_"+"Ammo"+"_InitialLeft",ammo);
	}

	/**********************Weapon**********************/
	public static void setKeyGetByLevel(int level,int trueOrFalse){
		PlayerPrefs.SetInt("Key_"+level.ToString()+"_"+"Get",trueOrFalse);
	}

	public static int getKeyGet(int level){
		return PlayerPrefs.GetInt("Key_"+level.ToString()+"_"+"Get");
	}

	public static void setCurrentLevelKeyGet(int trueOrFalse){
		int level = getCurrentLevel ();
		PlayerPrefs.SetInt("Key_"+level.ToString()+"_"+"Get",trueOrFalse);
	}

	public static int getCurrentLevelKeyGet(){
		int level = getCurrentLevel ();
		return PlayerPrefs.GetInt("Key_"+level.ToString()+"_"+"Get");
	}
}
