using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CharCollectManager : MonoBehaviour
{
    public static int TotalCoin;
    [SerializeField] private TextMeshProUGUI TotalCoinText;
    private int CoinValue = 500;
    [SerializeField] private GameObject rewardUI;
    [SerializeField] private AudioSource coinPick_SFX;
    [SerializeField] private AudioClip coinPickClip;
    [SerializeField] private AudioClip VictoryClip;
    [SerializeField] private GameObject NotEnoughGoldUI;
    [SerializeField] private GameObject powerupMask;
    [SerializeField] private AudioClip powerupClip;
    [SerializeField] private GameObject devilParticle;
    public static int powerupCount;
    private int powerupDamage = 100;
    public static bool LevelEnd;
    [SerializeField] private List<Material> charSkins;
    [SerializeField] private GameObject tempChar;
    [SerializeField] private TextMeshProUGUI charTitle;
    [SerializeField] private ParticleSystem ConfetiFX;
    void Start()
    {
        getTotalCoins();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("level1PowerUp"))
        {
            Sword.Damage += powerupDamage;
            Destroy(other.gameObject);
            Debug.Log(Sword.Damage);

            coinPick_SFX.PlayOneShot(powerupClip, 1);
            powerupCount++;
            switch(powerupCount)
            {
                case 1:
                    powerupMask.SetActive(true);
                    tempChar.GetComponent<Renderer>().material = charSkins[2];
                    charTitle.text = "Rebellious";
                    charTitle.color = Color.red;
                    break;
                case 2:
                    devilParticle.SetActive(true);
                    tempChar.GetComponent<Renderer>().material = charSkins[1];
                    charTitle.text = "Knight";
                    charTitle.color = Color.green;
                    break;
                case 3:
                    tempChar.GetComponent<Renderer>().material = charSkins[0];
                    charTitle.text = "Immortal";
                    charTitle.color = Color.yellow;
                    break;
            }

            Debug.Log("Sword damage" + Sword.Damage);
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            TotalCoin += CoinValue;
            TotalCoinText.text = TotalCoin.ToString();
            PlayerPrefs.SetInt("totalCoins", TotalCoin);
            Handheld.Vibrate();
            coinPick_SFX.PlayOneShot(coinPickClip, 1f);
        }
        if (other.gameObject.CompareTag("LevelEndTrigger"))
        {
    StartCoroutine(nameof(callRewardUI));
            LevelEnd = true;
            transform.position = new Vector3(39.7f, 17.1f, 11.2f);
            transform.localScale = new Vector3(4, 4, 4);
            ConfetiFX.Play();
            coinPick_SFX.PlayOneShot(VictoryClip, 1f);
            CharInteraction.CharState = CharInteraction.CharachterState.End;
            CharInteraction.SetAnimation();
         
        }
       
    }
    IEnumerator  callRewardUI()
    {
        yield return new WaitForSeconds(4);
    
            rewardUI.SetActive(true);
     
    }

    void getTotalCoins()
    {
        TotalCoinText.text = PlayerPrefs.GetInt("totalCoins").ToString();
        TotalCoin = PlayerPrefs.GetInt("totalCoins");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
