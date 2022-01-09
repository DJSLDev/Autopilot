using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GTA;
using GTA.Math;
using GTA.Native;

namespace Autopilot
{
    public class Captain : Script
    {
        public bool autopilotEnabled = false;

        public float cruiseSpeed = 30f;
        public float maxCruiseSpeed = 160f;

        public Captain()
        {
            this.Tick += onTick;
            this.KeyUp += onKeyUp;
            this.KeyDown += onKeyDown;
        }

        private void onTick(object sender, EventArgs e)
        {
            if (autopilotEnabled == true)
            {
                //Game.Player.Character.CurrentVehicle.

                if (Game.Player.Character.IsInVehicle())
                {
                    GTA.UI.Notification.Show("You are a big puff");
                }
            }
        }

        private void onKeyUp(object sender, KeyEventArgs e)
        {

        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad5)
            {
                if (autopilotEnabled == false)
                {
                    autopilotEnabled = true;
                }
                else
                {
                    autopilotEnabled = false;
                }
            }

            if (e.KeyCode == Keys.NumPad8)
            {
                if (cruiseSpeed < maxCruiseSpeed)
                {
                    cruiseSpeed += 5f;
                }
            }

            if (e.KeyCode == Keys.NumPad2)
            {
                if (cruiseSpeed > 0)
                {
                    cruiseSpeed -= 5f;
                }
            }
        }
    }
}
