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
    private void Update()
    {
        if (audioSource.isPlaying)
        {
            GetComponent<Outline>().enabled = true;
        }
        else
        {
            GetComponent<Outline>().enabled = false;
        }
    }

    public void Clicked()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void Drag()
    {
        transform.position = Input.mousePosition;
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
}
