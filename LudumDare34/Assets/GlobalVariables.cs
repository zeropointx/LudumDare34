using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlobalVariables : MonoBehaviour {
    public Text hpText;
    public Text moneyText;
    public static GlobalVariables globalVariables;
    public int hp = 100;
    public int money = 100;
	// Use this for initialization
    void Awake()
    {
        globalVariables = this;
    }
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        hpText.text = hp+"";
        moneyText.text = money+"";
	}
    public void addHp(int amount)
    {
        hp += amount;
    }
    public void reduceHp(int amount)
    {
        hp -= amount;
    }
    public void addMoney(int amount)
    {
        money += amount;
    }
    public void reduceMoney(int amount)
    {
        money -= amount;
    }
    public int GetMoney()
    {
        return money;
    }
    public int GetHp()
    {
        return hp;
    }
}
