using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CompositeSwlwctionResponse : MonoBehaviour, ISelectionResponse, IChangable
{
    [SerializeField] private GameObject selectionResponseHolder;

    private List<ISelectionResponse> _selectionResponses;
    private int _currentIndex;
    private Transform _currSel;

    private void Start()
    {
        _selectionResponses = selectionResponseHolder.GetComponents<ISelectionResponse>().ToList();
    }

    [ContextMenu("Next")]
    public void Next()
    {
        _selectionResponses[_currentIndex].OnDeselect(_currSel);
        _currentIndex = (_currentIndex + 1) % _selectionResponses.Count;
        _selectionResponses[_currentIndex].OnSelect(_currSel);
    }

    public void OnDeselect(Transform selection)
    {
        _currSel = null;
        if (HasSelection())
        {
            _selectionResponses[_currentIndex].OnDeselect(selection);
        }
    }

    public void OnSelect(Transform selection)
    {
        _currSel = selection;
        if (HasSelection())
        {
            _selectionResponses[_currentIndex].OnSelect(selection);
        }
    }

    private bool HasSelection()
    {
        return _currentIndex > -1 && _currentIndex < _selectionResponses.Count;
    }
}
