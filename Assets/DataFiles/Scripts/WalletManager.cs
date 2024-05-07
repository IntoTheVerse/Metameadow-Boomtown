using System;
using System.Collections.Generic;
using GoogleSheetsToUnity;
using UnityEngine;

public struct UserData
{
    public string username;
    public int character;
}

public class WalletManager : MonoBehaviour
{
    public static WalletManager Instance;
    [HideInInspector] public string WalletAddress = "";
    [HideInInspector] public string Username = "";
    [HideInInspector] public int Character;
    [HideInInspector] public string Currency;

    private const string SPREADSHEET_PUBLIC_ID = "1YOIkUpiL1mMEk6llqTHadk6jaNUc8noZV8a3rV6jbDo";
    private const string SPREADSHEET_NAME = "WalletAddress";
    private GstuSpreadSheet spreadSheet;

    private void Awake() 
    {
        if (Instance != null && Instance != this) Destroy(this);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetWalletAddress(string walletAddress)
    {
        WalletAddress = walletAddress;
        GetSheet(val => 
        {
            if (val) GetData();
        });
    }

    public void SetData(UserData data)
    {
        List<string> holder = new() { };
        List<string> newValues = new()
        {
            WalletAddress,
            data.username,
            data.character.ToString()
        };

        List<List<string>> combined = new()
        {
            holder,
            newValues,
        };

        GetSheet((result) =>
        {
            if (result)
            {
                SpreadsheetManager.Write(
                    new GSTU_Search(SPREADSHEET_PUBLIC_ID, SPREADSHEET_NAME, $"A{spreadSheet.rows.primaryDictionary.Count}"),
                    new ValueRange(combined),
                    () => 
                    {
                        GetSheet(val =>
                        {
                            if (val) GetData();
                        });
                    }
                );
            }
        });
    }

    private void GetData()
    {
        UserData? data = null;
        for (int i = 1; i < spreadSheet.rows.primaryDictionary.Count; i++)
        {
            if (spreadSheet.columns["Wallet Address"][i].value == WalletAddress)
            {
                data = new()
                {
                    character = int.Parse(spreadSheet.columns["Character"][i].value),
                    username = spreadSheet.columns["Username"][i].value,
                };
            }
        }

        if (data == null)
        {
            Debug.Log("Can't get data!");
            FindObjectOfType<MenuCharacterManager>().GetPlayerData();
        }
        else
        {
            Username = data?.username;
            Character = (int)data?.character;
            LoadGame();
        }
    }

    private void GetSheet(Action<bool> result)
    {
        SpreadsheetManager.ReadPublicSpreadsheet(new GSTU_Search(SPREADSHEET_PUBLIC_ID, SPREADSHEET_NAME), (sheet) =>
        {
            if (sheet == null)
            {
                result(obj: false);
                Debug.LogError("Couldn't Load Sheets!");
            }
            else
            {
                spreadSheet = sheet;
                result(true);
            }
        });
    }

    private void LoadGame()
    {
        FindObjectOfType<PvPConnectToServer>().Connect();
    }
}