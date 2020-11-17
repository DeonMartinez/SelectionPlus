using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour
{
    public List<GameObject> ChangableObjects;

    private List<IChangable> _changeableObjects = new List<IChangable>();

    private void Start()
    {
        for (int i =0; i < ChangableObjects.Count; i++)
        {
            var changableObjects = ChangableObjects[i].GetComponent<IChangable>();
            _changeableObjects.Add(changableObjects);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            for(int i = 0; i < _changeableObjects.Count; i++)
            {
                _changeableObjects[i].Next();
            }
        }
    }
}
