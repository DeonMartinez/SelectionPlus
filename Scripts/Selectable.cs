using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Selectable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lookPercentageLable;

    [HideInInspector] public float LookPercentage;
    void Update()
    {
        lookPercentageLable.text = LookPercentage.ToString("F3");
    }
}
