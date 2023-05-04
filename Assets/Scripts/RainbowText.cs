using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RainbowText : MonoBehaviour
{
    private TMP_Text textMesh;
    [SerializeField] float cyclingSpeed = 20f;            
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.color = Color.HSVToRGB(Mathf.PingPong(Time.time * cyclingSpeed, 1), 1, 1);
    }
}
