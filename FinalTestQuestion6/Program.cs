using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Xml;

class PlayerSettings
{
    public string PlayerName { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public List<string> Inventory { get; set; }
    public string LicenseKey { get; set; }

   
    private static PlayerSettings instance;

    private PlayerSettings()
    {
        
    }

    public static PlayerSettings Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerSettings();
            }
            return instance;
        }
    }

    public void LoadSettings(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            instance = JsonConvert.DeserializeObject<PlayerSettings>(json);
            Console.WriteLine("Settings loaded successfully.");
        }
        else
        {
            Console.WriteLine("Settings file not found. Creating new settings.");
        }
    }

    public void SaveSettings(string filePath)
    {
        string json = JsonConvert.SerializeObject(instance, Formatting.Indented);
        File.WriteAllText(filePath, json);
        Console.WriteLine("Settings saved successfully.");
    }
}

class Program
{
    static void Main()
    {
        PlayerSettings.Instance.LoadSettings("playerSettings.json");

        PlayerSettings.Instance.PlayerName = "dschuh";
        PlayerSettings.Instance.Level = 4;
        PlayerSettings.Instance.HP = 99;
        PlayerSettings.Instance.Inventory = new List<string>
        {
            "spear", "water bottle", "hammer", "sonic screwdriver", "cannonball",
            "wood", "Scooby snack", "Hydra", "poisonous potato", "dead bush", "repair powder"
        };
        PlayerSettings.Instance.LicenseKey = "DFGU99-1454";
        
        PlayerSettings.Instance.SaveSettings("playerSettings.json");

        Console.WriteLine("Current Player Settings:");
        Console.WriteLine($"Player Name: {PlayerSettings.Instance.PlayerName}");
        Console.WriteLine($"Level: {PlayerSettings.Instance.Level}");
        Console.WriteLine($"HP: {PlayerSettings.Instance.HP}");
        Console.WriteLine($"Inventory: {string.Join(", ", PlayerSettings.Instance.Inventory)}");
        Console.WriteLine($"License Key: {PlayerSettings.Instance.LicenseKey}");
    }
}
