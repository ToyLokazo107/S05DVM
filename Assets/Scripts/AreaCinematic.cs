using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class AreaCinematic : MonoBehaviour
{
    public CinemachineCamera camA;
    public CinemachineSplineDolly SplineCamA;
    public CinemachineCamera camB;
    public CinemachineCamera camC;
    public CinemachineCamera camD;
    public CinemachineCamera camPlayer;
    public bool cinematicEnable = false;
    public float tiempo;
    void Start()
    {
    }

    void Update()
    {
        if (cinematicEnable == true)
        {
            tiempo += Time.deltaTime;
            if (tiempo >= 0.01 && tiempo <= 20.00)
            {
                camPlayer.Priority = 0;
                camA.Priority = 1;
                SplineCamA.AutomaticDolly.Enabled = true;
            }
            if (tiempo >= 20.01 && tiempo <= 25.00)
            {
                camA.Priority = 0;
                camB.Priority = 1;
            }
            if (tiempo >= 25.01 && tiempo <= 30.00)
            {
                camB.Priority = 0;
                camC.Priority = 1;
            }
            if (tiempo >= 30.01 && tiempo <= 35.00)
            {
                camC.Priority = 0;
                camD.Priority = 1;
            }
            if (tiempo >= 35.01)
            {
                camD.Priority = 0;
                camPlayer.Priority = 1;
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<FirstPersonController>().enabled = true;
                gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cinematicEnable = true;
            other.GetComponent<FirstPersonController>().enabled = false;
        }
    }
}
