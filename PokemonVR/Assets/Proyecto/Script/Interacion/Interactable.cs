using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IBM.Watsson.Examples;
using UnityEngine.SceneManagement;

public class Interactable : MonoBehaviour
{
    public bool isInsideZone = false;
    public bool battle = false;
    public bool gazedAt = false;
    public int randNum;
    public Scene Battle;
    public float gazeInteractTime = 2f;
    public float gazeTimer = 0;
    public string voiceCommand = "brincar";


    // Start is called before the first frame update

    // Update is called once per frame

    void Start()
    {

    }

    public void OnVoiceCommandRecognized(string command)
    {
        if (command.ToLower() == voiceCommand.ToLower() && gazedAt)
        {
            Interact();
        }
    }
    public virtual void Update()
    {
        if(isInsideZone && (randNum == 0)){
            gazedAt = false;
            Debug.Log("Empieza pélea");
            battle = true;
        } 
        else
        {
            battle = false;
        }
        if (gazedAt)
        {
            if ((gazeTimer += Time.deltaTime) >= gazeInteractTime)
            {
                Interact();
                gazedAt = false;
                gazeTimer = 0f;
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        Debug.Log("Entró en el área");
        Debug.Log(randNum = Random.Range(0,30));
        isInsideZone = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        Debug.Log("Salió en el área");
        isInsideZone = false;
    }

    public void SetGazedAt(bool gazedAt)
    {
        this.gazedAt = gazedAt;
        if (!gazedAt)
        {
            gazeTimer = 0f;
        }
    }

    public void OnPointerEnter()
    {
        gazedAt = true;
        gazeTimer = 0f;
    }

    public void OnPointerExit()
    {
        gazedAt = false;
        gazeTimer = 0f;
    }
    public virtual void Interact()
    {

    }       
}

