using UnityEngine;

public class GameEnd : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject EndGameEnviroment;
    public GameObject MainGameEnviroment;
    public GameStart GameStartController;
    void Start()
    {
        EndGameEnviroment.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStartController.InEnd) {
            EndGameEnviroment.SetActive(true);
            MainGameEnviroment.SetActive(false);

        }
    }
}
