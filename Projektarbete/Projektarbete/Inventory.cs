﻿using Projektarbete.Data;
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
    public partial class Inventory : Form
    {
        public Item item { get; private set; }

        public Inventory()
        {
            InitializeComponent();

            foreach ( Item item in Game.Player.Inventory)
            {
                ListViewItem list = lstInventory.Items.Add(item.Name);
                list.SubItems.Add(item.Health.ToString());
                list.SubItems.Add(item.AttackPower.ToString());
                list.SubItems.Add(item.Speed.ToString());
                list.SubItems.Add(item.CriticalHitChance.ToString());
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstInventory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lstInventory.SelectedIndices.Count
            //lstInventory.SelectedIndices[0]
            //Game.Player.Inventory[index]
            //Item = Game.Player.Inventory[index];
        }

    }
}
