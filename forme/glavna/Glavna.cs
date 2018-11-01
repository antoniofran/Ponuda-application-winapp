using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PonudaApp
{
    public partial class Glavna : Form
    {

        public Glavna()
        {
            InitializeComponent();
        }

        /* ************************ */

        private void NovaOpremaGumb_Click(object sender, EventArgs e)
        {
            Napredak.pokreniAkciju((Button)sender);
            
            NovaOprema novaOprema = new NovaOprema();

            novaOprema.ShowDialog();

            Napredak.zavrsiAkciju((Button)sender);
        }

        private void UrediOpremeGumb_Click(object sender, EventArgs e)
        {
            Napredak.pokreniAkciju((Button)sender);
            
            UrediOpreme urediOpreme = new UrediOpreme();

            urediOpreme.ShowDialog();

            Napredak.zavrsiAkciju((Button)sender);
        }

        /* ************************ */

        private void NovaKabinaGumb_Click(object sender, EventArgs e)
        {
            Napredak.pokreniAkciju((Button)sender);
            
            NovaKabina novaKabina = new NovaKabina();

            novaKabina.ShowDialog();

            Napredak.zavrsiAkciju((Button)sender);
        }

        private void UrediKabineGumb_Click(object sender, EventArgs e)
        {
            Napredak.pokreniAkciju((Button)sender);
            
            UrediKabine urediKabine = new UrediKabine();

            urediKabine.ShowDialog();

            Napredak.zavrsiAkciju((Button)sender);
        }

        /* ************************ */

        private void NoviTraktorGumb_Click(object sender, EventArgs e)
        {
            Napredak.pokreniAkciju((Button)sender);

            NoviTraktor noviTraktor = new NoviTraktor();

            noviTraktor.ShowDialog();

            Napredak.zavrsiAkciju((Button)sender);
        }

        private void UrediTraktoreGumb_Click(object sender, EventArgs e)
        {
            Napredak.pokreniAkciju((Button)sender);
            
            UrediTraktore urediTraktore = new UrediTraktore();

            urediTraktore.ShowDialog();

            Napredak.zavrsiAkciju((Button)sender);
        }

        /* ************************ */

        private void NovaPonudaGumb_Click(object sender, EventArgs e)
        {
            Napredak.pokreniAkciju((Button)sender);
            
            NovaPonuda novaPonuda = new NovaPonuda();

            novaPonuda.ShowDialog();

            Napredak.zavrsiAkciju((Button)sender);
        }

        private void UrediPonudeGumb_Click(object sender, EventArgs e)
        {
            Napredak.pokreniAkciju((Button)sender);

            UrediPonude urediPonude = new UrediPonude();

            urediPonude.ShowDialog();

            Napredak.zavrsiAkciju((Button)sender);
        }

    }
}
