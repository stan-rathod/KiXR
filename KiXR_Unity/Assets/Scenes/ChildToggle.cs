using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChildToggle : MonoBehaviour
{
    Toggle m_Toggle;
    public FilterExample filterExample;
    public int main = 0;
    public int sub = 0;

    private void Awake() {
        m_Toggle = GetComponent<Toggle>();
        m_Toggle.isOn = false;
        m_Toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(m_Toggle);
        });
    }

    void ToggleValueChanged(Toggle change)
    {
        filterExample.FilterOption(main, sub, m_Toggle.isOn);
    }
}
