using UnityEngine;
using TMPro; // Если вы используете TextMeshPro

public class UpdateRespectText : MonoBehaviour
{
    public TextMeshProUGUI level1RespectText;
    public TextMeshProUGUI level2RespectText;
    public TextMeshProUGUI level3RespectText;

    private void Start()
    {
        int level1Respect = PlayerPrefs.GetInt("Level1", 0);
        int level2Respect = PlayerPrefs.GetInt("Level2", 0);
        int level3Respect = PlayerPrefs.GetInt("Level3", 0);

        level1RespectText.text = "Level 1 Respect: " + level1Respect;
        level2RespectText.text = "Level 2 Respect: " + level2Respect;
        level3RespectText.text = "Level 3 Respect: " + level3Respect;
    }
}
//using UnityEngine;

//public class ScoreManager : MonoBehaviour
//{
//    public static ScoreManager Instance;

//    private int level1Respect;
//    private int level2Respect;
//    private int level3Respect;

//    void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//        }
//        else
//        {
//            Destroy(gameObject);
//            return;
//        }
//        DontDestroyOnLoad(gameObject);

//        level1Respect = PlayerPrefs.GetInt("Level1Respect", 0);
//        level2Respect = PlayerPrefs.GetInt("Level2Respect", 0);
//        level3Respect = PlayerPrefs.GetInt("Level3Respect", 0);
//    }

//    public void CheckForNewHighRespect(int level, int respect)
//    {
//        switch (level)
//        {
//            case 1:
//                if (respect > level1Respect)
//                {
//                    level1Respect = respect;
//                    PlayerPrefs.SetInt("Level1Respect", level1Respect);
//                }
//                break;
//            case 2:
//                if (respect > level2Respect)
//                {
//                    level2Respect = respect;
//                    PlayerPrefs.SetInt("Level2Respect", level2Respect);
//                }
//                break;
//            case 3:
//                if (respect > level3Respect)
//                {
//                    level3Respect = respect;
//                    PlayerPrefs.SetInt("Level3Respect", level3Respect);
//                }
//                break;
//        }
//    }

    
//}
