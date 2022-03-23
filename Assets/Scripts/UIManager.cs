using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI swordDamage_txt;
    [SerializeField] private TextMeshProUGUI swordName_txt;
    [SerializeField] private TextMeshProUGUI swordPrize_txt;
    [SerializeField] private GameObject rewardUI;
    void Start()
    {
     
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Sword.Prize <= CharCollectManager.TotalCoin)
        {
            SwordUIText();
            rewardUI.SetActive(true);
            CharachterControl.runSpeed = 0;
        }

    }
    public void changeRunSpeed()
    {
        CharachterControl.runSpeed = 2;
    }
    public void SwordUIText()
    {

        swordDamage_txt.text = Sword.Damage.ToString();
        swordName_txt.text = "Congratz! You Won " + Sword.name + " Watch An Add Get Reward!";
        swordPrize_txt.text = " " + Sword.Prize.ToString();
    }

}
