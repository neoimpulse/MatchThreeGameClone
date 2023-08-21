using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _winText;

    // Start is called before the first frame update
    void Start()
    {
        _winText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerWinsSequence()
    {
        Debug.Log("Player Win Sequence!");
        _winText.gameObject.SetActive(true);

    }
}
