using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Levels: MonoBehaviour
{

    [SerializeField] private List<GameObject> Swords;
    [SerializeField]  private TextMeshProUGUI TotalCoinText;
    [SerializeField] private TextMeshProUGUI LevelCountText;
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private GameObject powerupMask;
    [SerializeField] private GameObject devilParticle;
    public static int swordCount;
    public static int LevelCount;
    
   
    public static bool isGameOver;
    void Start()
    {
   
    // PlayerPrefs.DeleteAll();

        GetLevelID();
        getActiveSword();


    }
    private void Update()
    {

   
        if (Monster.PlayerHealth <= 0)
        {
           GameOverUI.SetActive(true);
           isGameOver = true;
            switch(LevelCount)
            {
                case 0:
                    Destroy(MonsterSpawner.SpiderClone);
                    break;
                case 1:
                    Destroy(MonsterSpawner.GolemClone);
                    break;
                case 2:
                    Destroy(MonsterSpawner.BlackSpiderClone);
                    break;
                case 3:
                    Destroy(MonsterSpawner.BlackGolemClone);
                    break;
                case 4:
                    Destroy(MonsterSpawner.SkeletonClone);
                    break;
                case 5:
                    Destroy(MonsterSpawner.DragonClone);
                    break;
                case 6:
                    Destroy(MonsterSpawner.SpiderClone);
                    Destroy(MonsterSpawner.GolemClone);
                    Destroy(MonsterSpawner.BlackSpiderClone);
                    Destroy(MonsterSpawner.BlackGolemClone);
                    Destroy(MonsterSpawner.SkeletonClone);
                    Destroy(MonsterSpawner.DragonClone);
                    break;
            }
          
        }
     
    }
    public void PlayAgainLevel()
    {
        if (LevelCount == 0)
            Monster.PlayerHealth = 500;
        SceneManager.LoadScene(1);
        Monster.PlayerHealth = PlayerPrefs.GetInt("PlayerHealth", Monster.PlayerHealth);
        CharInteraction.CharState = CharInteraction.CharachterState.Run;
        CharInteraction.SetAnimation();
      GameOverUI.SetActive(false);
        powerupMask.SetActive(false);
        devilParticle.SetActive(false);
        CharCollectManager.powerupCount = 0;
        getActiveSword();

    }

    public void UpgradeSword()  // if total coin is enough button active true;
    {
        swordCount++;
        PlayerPrefs.SetInt("UpgradeSword", swordCount);
        swordCount = PlayerPrefs.GetInt("UpgradeSword", swordCount);
  Swords[PlayerPrefs.GetInt("UpgradeSword", swordCount)-1].SetActive(false);
        Swords[PlayerPrefs.GetInt("UpgradeSword", swordCount)].SetActive(true);
    }
  private void getActiveSword()
    {
        swordCount = PlayerPrefs.GetInt("UpgradeSword", swordCount);
        if (PlayerPrefs.GetInt("UpgradeSword", swordCount) > 0)
        {
            Swords[0].SetActive(false);
            Swords[PlayerPrefs.GetInt("UpgradeSword", swordCount) - 1].SetActive(false);
        }
          
        Swords[PlayerPrefs.GetInt("UpgradeSword", swordCount)].SetActive(true);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(1);
        Monster.PlayerHealth += 1000;
        PlayerPrefs.SetInt("PlayerHealth", Monster.PlayerHealth);
        LevelCount++;
        powerupMask.SetActive(false);
        devilParticle.SetActive(false);
        CharCollectManager.powerupCount = 0;
        PlayerPrefs.SetInt("LevelNumber", LevelCount);
        CharInteraction.CharState = CharInteraction.CharachterState.Run;
        CharInteraction.SetAnimation();

    }
    private void GetLevelID()
    {
        LevelCount = PlayerPrefs.GetInt("LevelNumber", LevelCount);
        LevelCountText.text = "Level " + PlayerPrefs.GetInt("LevelNumber").ToString();
    }
    public void PaySwordPrize()
    {
        CharCollectManager.TotalCoin -= Sword.Prize;
        TotalCoinText.text = CharCollectManager.TotalCoin.ToString();
        PlayerPrefs.SetInt("totalCoins", CharCollectManager.TotalCoin);
    }
}
