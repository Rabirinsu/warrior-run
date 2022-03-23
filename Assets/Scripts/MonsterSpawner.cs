
using System.Collections.Generic;
using UnityEngine;


public class MonsterSpawner : MonoBehaviour
{
    private Vector3 bossSpawnLocation;
    [SerializeField] private List<GameObject> Monsters;
    public static GameObject GolemClone;
    public static GameObject SpiderClone;
    public static GameObject BlackSpiderClone;
    public static GameObject BlackGolemClone;
    public static GameObject SkeletonClone;
    public static GameObject DragonClone;
    [SerializeField] private GameObject Coin;
    private int coinRateMax=35, coinRateMin = 10;

    private float xPosition = 21;
    private float yPosition = 10.67f;
    private float leftzPosition = 0.03f;
    private float rightzPosition = -2;
    private float coinyPosition = 11.35f;
    private float monsteryPosition = 12.3f;
    [SerializeField] private List<GameObject> powerUp;

    void Awake()
    {
   
        bossSpawnLocation = new Vector3(26.34f, 12.3f, -1.17f);
        Levels.LevelCount = PlayerPrefs.GetInt("LevelNumber", Levels.LevelCount);
        SpawnLevels();
        
    }
   
    void Update()
    {
     
    }
    public void SpawnLevels()
    {
        switch (Levels.LevelCount)
        {
            case 0:
                level1_Enviroment();
                break;
            case 1:
                level2_Enviroment();
                break;
            case 2:
                level3_Enviroment();
                break;
            case 3:
                level4_Enviroment();
                break;
            case 4:
                level5_Enviroment();
                break;
            case 5:
                level6_Enviroment();
                break;
            case 6:
                level7_Enviroment();
                break;
        }
        if(Levels.LevelCount > 6)
        {
            PlayerPrefs.DeleteAll();
            level1_Enviroment();
            Levels.LevelCount = 0;
        }   

    }
  
    private void level1_Enviroment()
    {

        SpiderClone = Instantiate(Monsters[0], bossSpawnLocation, Quaternion.LookRotation(Vector3.left));

        Instantiate(powerUp[Random.Range(0, powerUp.Count)], RandomizeLocation(), Quaternion.identity);
        Instantiate(powerUp[Random.Range(0, powerUp.Count)], RandomizeLocation(), Quaternion.identity);
        for (var i = 0; i < 10; i++)
        {
            Instantiate(Coin, coinSpawnLocation(), Quaternion.Euler(-50, 0, 0));
        }
    }

    private void level2_Enviroment()
    {
        GolemClone = Instantiate(Monsters[1], bossSpawnLocation, Quaternion.LookRotation(Vector3.left));
      
        for (var i = 0; i < 4; i++)
        {
            Instantiate(powerUp[Random.Range(0, powerUp.Count)], RandomizeLocation(), Quaternion.identity);
        }
        
        for (var i = 0; i < 15; i++)
        {
         
            Instantiate(Coin, RandomizeLocation(), Quaternion.identity);
        }
    }

    private void level3_Enviroment()
    {


        BlackSpiderClone = Instantiate(Monsters[2], bossSpawnLocation, Quaternion.LookRotation(Vector3.left));

        Instantiate(powerUp[Random.Range(0, powerUp.Count)], RandomizeLocation(), Quaternion.identity);
        Instantiate(powerUp[Random.Range(0, powerUp.Count)], RandomizeLocation(), Quaternion.identity);

        for (var i = 0; i < 15; i++)
        {
          
            Instantiate(Coin, RandomizeLocation(), Quaternion.identity);
        }
    }
    private void level4_Enviroment()
    {

        BlackGolemClone = Instantiate(Monsters[3], bossSpawnLocation, Quaternion.LookRotation(Vector3.left));

        for (var i = 0; i < 4; i++)
        {
            Instantiate(powerUp[Random.Range(0, powerUp.Count)], RandomizeLocation(), Quaternion.identity);
        }

        for (var i = 0; i < 20; i++)
        {
          
            Instantiate(Coin, RandomizeLocation(), Quaternion.identity);
        }
    }

    private void level5_Enviroment()
    {
       
        SkeletonClone = Instantiate(Monsters[4], bossSpawnLocation, Quaternion.LookRotation(Vector3.left));

        for (var i = 0; i < 3; i++)
        {
            Instantiate(powerUp[Random.Range(0, powerUp.Count)], RandomizeLocation(), Quaternion.identity);
        }

        for (var i = 0; i < 25; i++)
        {

            Instantiate(Coin, RandomizeLocation(), Quaternion.identity);
        }
    }
    private void level6_Enviroment()
    {

        DragonClone = Instantiate(Monsters[5], bossSpawnLocation, Quaternion.LookRotation(Vector3.left));

        for (var i = 0; i < 3; i++)
        {
            Instantiate(powerUp[Random.Range(0, powerUp.Count)], RandomizeLocation(), Quaternion.identity);
        }

        for (var i = 0; i < 25; i++)
        {

            Instantiate(Coin, RandomizeLocation(), Quaternion.identity);
        }
    }
    private void level7_Enviroment()
        {
            SpiderClone = Instantiate(Monsters[0], monsterSpawnLocation(), Quaternion.LookRotation(Vector3.left));
            GolemClone = Instantiate(Monsters[1], monsterSpawnLocation(), Quaternion.LookRotation(Vector3.left));
            BlackSpiderClone = Instantiate(Monsters[2], monsterSpawnLocation(), Quaternion.LookRotation(Vector3.left));
            BlackGolemClone = Instantiate(Monsters[3], monsterSpawnLocation(), Quaternion.LookRotation(Vector3.left));
            SkeletonClone = Instantiate(Monsters[4], monsterSpawnLocation(), Quaternion.LookRotation(Vector3.left));
        DragonClone = Instantiate(Monsters[5], bossSpawnLocation, Quaternion.LookRotation(Vector3.left));


        for (var i = 0; i < Random.Range(coinRateMin, coinRateMax); i++)
            {

                Instantiate(Coin, RandomizeLocation(), Quaternion.identity);
            }
        }
   
    private Vector3 RandomizeLocation()
    {
        return new Vector3(Random.Range(-xPosition, xPosition), yPosition, Random.Range(rightzPosition, leftzPosition));
    }

    private Vector3 coinSpawnLocation()
    {
        return new Vector3(Random.Range(-xPosition, xPosition), coinyPosition, Random.Range(rightzPosition, leftzPosition));
    }
    private Vector3 monsterSpawnLocation()
    {
        return new Vector3(Random.Range(-xPosition, xPosition), monsteryPosition, Random.Range(rightzPosition, leftzPosition));
    }
}
