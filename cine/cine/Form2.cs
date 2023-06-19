using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Transitions;

namespace cine
{
    public partial class Form2 : Form
    {
        public Form2(Image imagen)
        {
            InitializeComponent();
            pbPeli.Image = imagen;
        }
        TICKET ticket = new TICKET();
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            lblSala.Text = ticket.Sala;
            lblDia.Text = ticket.Dia;
            lblTitulo.Text = ticket.Pelicula;
            lblCantidad.Text = ticket.Cantidad.ToString();

            for (int i = ticket.Asientos.Count - 1; i >= 0; i--)
            {
                if (txtLugares.Text == string.Empty)
                {
                    txtLugares.Text = ticket.Asientos[i];

                }
                else if (ticket.Asientos.Count != i)
                {
                    txtLugares.Text = txtLugares.Text + ", " + ticket.Asientos[i];

                }
            }
        }

        private void txtLugares_TextChanged(object sender, EventArgs e)
        {
            int numLineas = txtLugares.GetLineFromCharIndex(txtLugares.TextLength) + 1;
            int lineasHeight = txtLugares.Font.Height;
            int nuevaHeight = (numLineas * lineasHeight) + (txtLugares.Padding.Top + txtLugares.Padding.Bottom);
            txtLugares.Height = nuevaHeight;

        }

       

        private void rBMP_CheckedChanged(object sender, EventArgs e)
        {
            pnlPagoMp.Show();
            pnlPagoTj.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pnlPagoTj.Show();
            pnlPagoMp.Hide();
            rBMP.Hide();
            Transition t3 = new Transition(new TransitionType_EaseInEaseOut(1000));
            t3.add(radioButton2, "Left", rBMP.Location.X);
            t3.run();

            Transition t4 = new Transition(new TransitionType_EaseInEaseOut(900));
            t4.add(radioButton2, "Top", rBMP.Location.Y);
            t4.run();
        }

       
    }
}