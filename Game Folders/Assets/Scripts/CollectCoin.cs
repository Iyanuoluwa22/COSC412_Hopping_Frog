using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectCoin : MonoBehaviour
{
    public int coinsCollected;
    public GameObject[] flyCoins;
    private GameObject coins;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        flyCoins = GameObject.FindGameObjectsWithTag("FlyCoin");
        for(int i = 0; i < flyCoins.Length; i++) flyCoins[i].GetComponent<Collider2D>().isTrigger = true;
        coinsCollected = 0;
        coins = GameObject.Find("Coins");
        text = coins.GetComponentInChildren<TextMeshProUGUI>();
        text.text = 0.ToString();
    }

    
    void OnTriggerEnter2D(Collider2D collision) //this function makes sure that when the ball is touching the ground then onGround is true
    {
        if (collision.gameObject.tag == "FlyCoin") //can also use game.Object.tag if you want to tag multiple objects without changing their names
        {
            Destroy(GameObject.Find(collision.gameObject.name));
            coinsCollected++;
            text.text = coinsCollected.ToString();
        }
    }
}
