using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerMenuScene : MonoBehaviour
{
    public GameObject databoard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }
    public void DataBoardButton()
    {
        DataManager.Instance.LoadData();

        databoard.transform.GetChild(1).GetComponent<Text>().text ="Total Shot Bullet " + DataManager.Instance.totalShotBullet.ToString();
        databoard.transform.GetChild(2).GetComponent<Text>().text ="Total Enemy Killed " + DataManager.Instance.totalEnemyKilled.ToString();
        databoard.SetActive(true);
    }
    public void XButton()
    {
        databoard.SetActive(false);
    }
}
