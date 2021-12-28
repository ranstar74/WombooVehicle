using GTA;
using RageComponent.Core;
using System.Windows.Forms;
using WombooVehicle.Core;

namespace WombooVehicle
{
    public class Main : Script
    {
        /// <summary>All womboo vehicles created by this script are stored here.</summary>
        public ComponentObjectCollection<Womboo> Womboos { get; } = new ComponentObjectCollection<Womboo>();

        public Main()
        {
            KeyDown += Main_KeyDown;
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.U)
                ConvertToWomboo();
        }

        private void ConvertToWomboo()
        {
            Vehicle pVehicle = Game.Player.Character.CurrentVehicle;
            if (pVehicle == null)
            {
                GTA.UI.Screen.ShowHelpText("In order to get womboo features you have to be in a vehicle.");
                return;
            }

            Womboos.Add(new Womboo(pVehicle));
        }
    }
}
