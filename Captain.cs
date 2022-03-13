using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GTA;
using GTA.Math;
using GTA.UI;
using GTA.Native;

namespace Autopilot
{
    public class Captain : Script
    {
        private bool autopilotEnabled = false;

        private float cruiseSpeed = 0f;

        private float defaultCruiseSpeed = 30f;
        private float maxCruiseSpeed = 160f;

        public Captain()
        {
            this.Tick += OnTick;
            this.KeyDown += OnKeyDown;
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (autopilotEnabled == true)
            {
                //Game.Player.Character;
                //Game.Player.Character.CurrentVehicle.Speed = 1f;

                if (Game.Player.Character.IsInVehicle())
                {
                    Game.Player.Character.CurrentVehicle.Speed = cruiseSpeed;
                }
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (Game.Player.Character.IsInVehicle())
            {
                if (e.KeyCode == Keys.NumPad5)
                {
                    if (autopilotEnabled == false)
                    {
                        autopilotEnabled = true;
                        Notification.Show("Autopilot Enabled");
                    }
                    else
                    {
                        autopilotEnabled = false;
                        Notification.Show("Autopilot Disabled");
                    }
                }

                if (e.KeyCode == Keys.NumPad8)
                {
                    if (cruiseSpeed < maxCruiseSpeed)
                    {
                        cruiseSpeed += 5f;
                        Notification.Show("Cruise Control Speed: " + cruiseSpeed);
                    }
                }

                if (e.KeyCode == Keys.NumPad2)
                {
                    if (cruiseSpeed > 0)
                    {
                        cruiseSpeed -= 5f;
                        Notification.Show("Cruise Control Speed: " + cruiseSpeed);
                    }
                }

                if (e.KeyCode == Keys.NumPad3)
                {
                    cruiseSpeed = defaultCruiseSpeed;
                    Notification.Show("Cruise Speed Set To Default");
                }
            }
        }
    }
}
