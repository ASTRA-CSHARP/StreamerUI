using BepInEx;
using System;
using UnityEngine;
using Utilla;
using Photon.Pun;
using UnityEngine.InputSystem;
using GorillaNetworking;
using static Photon.Pun.UtilityScripts.TabViewManager;
using Steamworks;
using Unity.Burst.Intrinsics;
namespace StreamerUI
{

    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool open;
        bool hidecode;
        static string display;
        int lolz;
        Rect window = new Rect(10f, 10f, 200f, 200f);

        void Start()
        {
            
        }

        void OnEnable()
        {
            

            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            

            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            
        }

        void Update()
        {
            if (Keyboard.current.tabKey.wasPressedThisFrame)
            {
                open = !open;
            }
            
            
        }

        void OnGUI()
        {
            GUI.backgroundColor = Color.white;
            GUI.skin.textArea.fontStyle = FontStyle.Bold;
            if (!open)
            {
                if (PhotonNetwork.InRoom)
                {
                    window = GUI.Window(lolz, window, new GUI.WindowFunction(drawTabs), "<color=black>STREAMER UI</color>");
                }
            }
        }

        void drawTabs(int lolz)
        {
            display = GUI.TextArea(new Rect(10f, 40f, 160f, 50f), display);

            display = string.Concat(new string[]
            {
                    "CURRENT ROOM: ",
                    PhotonNetwork.CurrentRoom.Name,
                    "\nPLAYER COUNT: ",
                    PhotonNetwork.CurrentRoom.PlayerCount.ToString(),
                    "/10\nQUEUE: ",
                    GorillaComputer.instance.currentQueue

            });

            hidecode = GUI.Toggle(new Rect(10f, 165f, 160f, 15f), hidecode, "HIDE ROOM CODE");
            if (hidecode)
            {
                display = "HIDDEN ROOM DATA";
            }
            GUI.DragWindow();
        }

    }
}
