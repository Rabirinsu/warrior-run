
using UnityEngine;

public class Sword : MonoBehaviour
{
    public static float Damage;
    public static int Prize;
    public static string name;
   private enum Type
    {
        Level1, Level2, Level3, Level4, Level5, Level6, Level7, Level8, Level9, Level10, Level11, Level12, Level13, Level14, Level15
    }
    [SerializeField]private Type type;
    private void Start()
    {
   
        SetSwordLevel();
    }
    public void SetSwordLevel()
    {
        switch (type)
        {
            case Type.Level1:
                Damage = 50;
                Prize = 2500;
               name = "Broken Sword";
                break;
            case Type.Level2:
                Damage = 100;
                Prize = 6500;
                name = "Twilight's Sword";
                break;
            case Type.Level3:
                Damage = 150;
                Prize = 12500;
                name = "Wind's Longsword";
                break;
            case Type.Level4:
                Damage = 250;
                Prize = 20000;
                name = "Destiny's Song";
                break;
            case Type.Level5:
                Damage = 350;
                Prize = 30000;
                name = "King's Defender";
                break;
            case Type.Level6:
                Damage = 700;
                Prize = 40000;
                name = "Hollow Silence";
                break;
            case Type.Level7:
                Damage = 1000;
                Prize = 70000;
                name = "Last Words";
                break;
            case Type.Level8: // UNKNOWN
                Damage = 5000;
                Prize = 100000;
                name = "Judgement Rapier";
                break;
            case Type.Level9:
                Damage = 10000;
                Prize = 120000;
                name = "Firestorm Mithril Razor";
                break;
            case Type.Level10:
                Damage = 3000;
                Prize = 300000;
                name = "Honor's Call";
                break;
            case Type.Level11:
                Damage = 3500;
                Prize = 300000;
                name = "Unholy Might";
                break;
            case Type.Level12:
                Damage = 4000;
                Prize = 300000;
                name = "Darkness";
                break;
            case Type.Level13:
                Damage = 5000;
                Prize = 300000;
                name = "Hell's Scream";
                break;
            case Type.Level14:
                Damage = 10000;
                Prize = 300000;
                name = "Night's Edge";
                break;
            case Type.Level15:
                Damage = 3000;
                Prize = 300000;
                name = "Hollow Silence";
                break;


        }
    }
}