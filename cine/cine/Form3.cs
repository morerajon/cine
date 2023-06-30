using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cine
{
    public partial class Form3 : Form
    {
        public Form3(Image imagen)
        {
            InitializeComponent();
            pbPeli.Image = imagen;
        }

        TICKET ticket = new TICKET();
        cliente Cliente = new cliente();

        private void Form3_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = ticket.Pelicula;
            lblSala.Text = ticket.Sala;
            lblDia.Text = ticket.Dia;
            lblCantidad.Text =ticket.Cantidad.ToString();
             txtLugares.Text= ticket.Asientos[0];

            for (int i = 1; i < ticket.Asientos.Count; i++)
            {
                txtLugares.Text= txtLugares.Text+", "+ ticket.Asientos[i];
            }

            txtNombre.Text = Cliente.nombre;
            txtApellido.Text = Cliente.apellido;
            txtMail.Text = Cliente.mail;


            if (Cliente.tarjeta==null)
            {
                pnlPagoTj.Hide();
                pbPago.Image = imageList1.Images[0];
                pbPago.Location = new Point(167,146);
         
            }
            else
            {
                pnlPagoTj.Show();
                txtTj.Text = Cliente.tarjeta.ToString();
                txtVto.Text = Cliente.vto;
                pbPago.Image= imageList1.Images[1];
            }
            
           



        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Su compra fue realizada con exito");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        
        

    }
}
