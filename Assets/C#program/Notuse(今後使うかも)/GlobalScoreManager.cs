using UnityEngine;//score keepper bitween scane 

public class GlobalScoreManager : MonoBehaviour
{
    private static GlobalScoreManager instance;
    public int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GlobalScoreManager GetInstance()
    {
        return instance;
    }
}
