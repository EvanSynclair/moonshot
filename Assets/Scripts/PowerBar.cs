using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    //powerbar Variables
    public GameObject powerBarGO;
    public Image PowerBarMask;
    public float barChangeSpeed = 1;
    float maxPowerBarValue = 100;
    float currentPowerBarValue;
    bool powerIsIncreasing;
    bool PowerBarON;
    public float powerMultiplied = 10f;

    //Rigidbody AddForce variables
    public Rigidbody rb;
    Vector3 dir;
    public Transform target;

    void Start()
    {
        //AddForce
        dir = target.transform.position - transform.position;
        dir = dir.normalized;

        //PowerBar
        currentPowerBarValue = 0;
        powerIsIncreasing = true;
        PowerBarON = true;
        StartCoroutine(UpdatePowerBar());
    }

    IEnumerator UpdatePowerBar()
    {
        while (PowerBarON)
        {
            if (!powerIsIncreasing)
            {
                currentPowerBarValue -= barChangeSpeed;
                if (currentPowerBarValue <= 0)
                {
                    powerIsIncreasing = true;
                }
            }
            if (powerIsIncreasing)
            {
                currentPowerBarValue += barChangeSpeed;
                if (currentPowerBarValue >= maxPowerBarValue)
                {
                    powerIsIncreasing = false;
                }
            }

            float fill = currentPowerBarValue / maxPowerBarValue;
            PowerBarMask.fillAmount = fill;
            yield return new WaitForSeconds(0.02f);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                PowerBarON = false;
                ShotTaken();
                StartCoroutine(TurnOffPowerBar());

            }
        }
        yield return null;
    }
    IEnumerator TurnOffPowerBar()
    {
        yield return new WaitForSeconds(0.5f);
        powerBarGO.SetActive(false);
    }

    public void ShotTaken()
    {
        Debug.Log("Hit");
        Debug.Log(currentPowerBarValue);
        //Animation for character to hit ball would go here
        //The force would be the currentPowerBarValue
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            rb.AddForce(dir * (currentPowerBarValue * powerMultiplied));
        }
    }
}
