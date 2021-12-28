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
            Aborted += Main_Aborted;
        }

        private void Main_Aborted(object sender, System.EventArgs e)
        {
            // No need to do it in our case because we don't have
            // any unmanaged resource

            // Womboos.DisposeAllAndClear();
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

            if(Womboos.Contains(pVehicle.Handle))
            {
                GTA.UI.Screen.ShowHelpText("Womboo features are already actived.");
                return;
            }

            Womboos.Add(new Womboo(pVehicle));

            GTA.UI.Screen.ShowHelpText("Womboo features actived.");
        }
    }
}
