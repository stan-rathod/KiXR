using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParentToggle : MonoBehaviour
{
    Toggle m_Toggle;

    [SerializeField] List<Toggle> sub = new List<Toggle>(); 

    private void Awake() {
        m_Toggle = GetComponent<Toggle>();
        m_Toggle.isOn = false;
        m_Toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(m_Toggle);
        });
    }

    void ToggleValueChanged(Toggle change)
    {
        foreach (var item in sub)
        {
            item.isOn = m_Toggle.isOn;
        }
    }
}
