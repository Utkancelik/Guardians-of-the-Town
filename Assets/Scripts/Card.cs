using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private AudioSource audioSource;
    private Vector2 initialPos, originalSize;
    private GameObject target;
    public bool amIDroppedToTarget;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("Target");
    }

    private void Start()
    {
        initialPos = transform.position;
        originalSize = GetComponent<RectTransform>().sizeDelta;
    }

    public void PointerClick()
    {
        StartCoroutine(PointerClickPlaySound());
    }
    
    public void Drag()
    {
        if (AudioManager.instance.gameStarted)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void Drop()
    {

        float distance = Vector2.Distance(target.transform.position, transform.position);
        if (distance <= 50)
        {
            transform.position = target.transform.position;
            RectTransform rect = GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(350, 180);
            amIDroppedToTarget = true;

            if (gameObject.name == "Saz")
            {
                GetComponent<Outline>().effectColor = Color.green;
                GetComponent<Outline>().enabled = true;
                transform.position = target.transform.position;
            }
            else
            {
                GetComponent<Outline>().effectColor = Color.red;
                GetComponent<Outline>().enabled = true;
                transform.position = initialPos;
                rect.sizeDelta = originalSize;
            }
        }
        else
        {
            amIDroppedToTarget = false;
            transform.position = initialPos;
        }
    }

    private IEnumerator PointerClickPlaySound()
    {
        if (AudioManager.instance.gameStarted)
        {
            audioSource.Play();
            GetComponent<Outline>().enabled = true;
            yield return new WaitForSeconds(1);
            GetComponent<Outline>().enabled = false;
        }
        yield return null;
        
    }
}
