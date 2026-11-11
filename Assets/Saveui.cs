using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UISettingsData", menuName = "UI/Settings Data")]
public class UISettingsData : ScriptableObject
{
    [Serializable]
    public class Entry
    {
        public string key;   // element name in UXML
        public string value; // serialized value
    }

    [SerializeField] private List<Entry> entries = new();

    public void Set(string key, string value)
    {
        var e = entries.Find(x => x.key == key);
        if (e == null) entries.Add(new Entry { key = key, value = value });
        else e.value = value;
#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }

    public bool TryGet(string key, out string value)
    {
        var e = entries.Find(x => x.key == key);
        value = e?.value;
        return e != null;
    }


}
