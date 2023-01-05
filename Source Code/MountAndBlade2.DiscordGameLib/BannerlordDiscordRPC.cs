using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MountAndBlade2.DiscordGameLib
{
    public class MB2BannerlordDiscordRPC
    {
        public DiscordRpcClient client;
        public void InitBannerlordRPC()
        {
            client = new DiscordRpcClient("1060585705618808902"); //Please Create Application to Execute Mount And Blade 2 Bannerlord :D
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            //Subscribe to events
            client.OnReady += (sender, e) =>
            {
                MessageBox.Show($"User Is Connected... {e.User.Username}");
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                MessageBox.Show($"Received Update!!! {e.Presence}");
            };

            //Connect to the RPC
            client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(new RichPresence()
            {
                Details = "Mount And Blade 2 Bannerlord",
                State = "Playing...",
                Assets = new Assets()
                {
                    //Assets :D
                    LargeImageKey = Environment.CurrentDirectory + "\\DiscordRPC\\BannerlordLarge.png",
                    LargeImageText = "Mount And Blade 2 Bannerlord",
                    SmallImageText = "Playing Mount And Blade 2 Bannerlord",
                    SmallImageKey = Environment.CurrentDirectory + "\\DiscordRPC\\BannerlordSmall.png"
                }
            });
            if (client.IsInitialized)
            {
                MessageBox.Show("DiscordRPC Is Initializated Succesfull");
            }
            else
            {
                MessageBox.Show("DiscordRPC Is Not Initializated...");
                Thread.Sleep(5000);
                Environment.Exit(112);
            }
        }
    }
}
