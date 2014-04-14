using Projektarbete.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projektarbete
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
            Game.Player.Inventory.Add(new Item("Test", "", 20, -1, 0, 0));
            Fillup();
            
        }

        private void btnAnswer1_Click(object sender, EventArgs e)
        {

        }

        private void btnAnswer2_Click(object sender, EventArgs e)
        {

        }

        private void btnAnswer3_Click(object sender, EventArgs e)
        {

        }

        private void picWeapon_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.ShowDialog(this);

            if (inventory.Item != null)
                lblWeapon.Text = inventory.Item.ToString();
            else
                lblWeapon.Text = "n/a";

            Fillstats();
        }


        private void Fillup()
        {
            foreach (Item item in Game.Player.Inventory)
                lblInventory.Text += item.ToString();

            txtEvents.AppendText(Game.Event.Description);

            Fillstats();

            lblAnswer1.Text = Game.Event.GetChoice(0);
            lblAnswer2.Text = Game.Event.GetChoice(1);
            lblAnswer3.Text = Game.Event.GetChoice(2);

            if (Game.Event.GetChoice(0) == "")
                lblAnswer1.Visible = false;
            else
                lblAnswer1.Visible = true;
            if (Game.Event.GetChoice(1) == "")
                lblAnswer2.Visible = false;
            else
                lblAnswer2.Visible = true;
            if (Game.Event.GetChoice(2)== "")
                lblAnswer3.Visible = false;
            else 
                lblAnswer3.Visible = true;

            lblHealth.Text = Game.Player.Health.ToString();
            lblAtkP.Text = Game.Player.AttackPower.ToString();
            lblAtkS.Text = Game.Player.Speed.ToString();
            lblChC.Text = Game.Player.CriticalHitChance.ToString();

                

        }

        private void lblInventory_Click(object sender, EventArgs e)
        {

        }

        private void Fillstats()
        {
            if (Game.Player.Health > Game.Player.BaseHealth)
                lblHealth.ForeColor = Color.Green;
            else if (Game.Player.Health < Game.Player.BaseHealth)
                lblHealth.ForeColor = Color.Red;
            else
                lblHealth.ForeColor = Color.White;

            if (Game.Player.AttackPower > Game.Player.BaseAttackPower)
                lblAtkP.ForeColor = Color.Green;
            else if (Game.Player.AttackPower < Game.Player.BaseAttackPower)
                lblAtkP.ForeColor = Color.Red;
            else
                lblAtkP.ForeColor = Color.White;

            if (Game.Player.Speed > Game.Player.BaseSpeed)
                lblAtkS.ForeColor = Color.Green;
            else if (Game.Player.Speed < Game.Player.BaseSpeed)
                lblAtkS.ForeColor = Color.Red;
            else
                lblAtkS.ForeColor = Color.White;

            if (Game.Player.CriticalHitChance > Game.Player.BaseCriticalHitChance)
                lblChC.ForeColor = Color.Green;
            else if (Game.Player.CriticalHitChance < Game.Player.BaseCriticalHitChance)
                lblAtkS.ForeColor = Color.Red;
            else
                lblAtkS.ForeColor = Color.White;
           
        }

        private void picWeapon_MouseHover(object sender, EventArgs e)
        {
            this.picWeapon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void picWeapon_MouseLeave(object sender, EventArgs e)
        {
            this.picWeapon.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }


    }
}
