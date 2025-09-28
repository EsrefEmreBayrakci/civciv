using System.Collections.Generic;
using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance { get; private set; }

    public Language CurrentLanguage { get; private set; } = Language.English;

    public delegate void LanguageChanged(Language newLang);
    public event LanguageChanged OnLanguageChanged;

    private Dictionary<string, string> english = new Dictionary<string, string>
    {
        {"play", "Play"},
        {"quit", "Quit"},
        {"resume", "Resume"},
        {"settings", "Settings"},
        {"english", "English"},
        {"turkish", "Türkçe"},
        // add other keys here
    };

    private Dictionary<string, string> turkish = new Dictionary<string, string>
    {
        {"play", "Oyna"},
        {"quit", "Çıkış"},
        {"resume", "Devam"},
        {"settings", "Ayarlar"},
        {"english", "English"},
        {"turkish", "Türkçe"},
        // add other keys here
    };

    private Dictionary<Language, Dictionary<string, string>> _translations;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        _translations = new Dictionary<Language, Dictionary<string, string>>
        {
            { Language.English, english },
            { Language.Turkish, turkish }
        };
    }

    public string Get(string key)
    {
        if (_translations[CurrentLanguage].TryGetValue(key, out string value))
        {
            return value;
        }
        // fallback to key if missing
        return key;
    }

    public void SetLanguage(Language lang)
    {
        if (CurrentLanguage == lang) return;
        CurrentLanguage = lang;
        OnLanguageChanged?.Invoke(lang);
    }
}