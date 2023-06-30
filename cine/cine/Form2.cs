using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
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
        cliente Cliente = new cliente();

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
            radioButton2.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            pnlPagoMp.Hide();
            rBMP.Hide();
            Transition t3 = new Transition(new TransitionType_EaseInEaseOut(1000));
            t3.add(radioButton2, "Left", rBMP.Location.X);
            t3.run();

            Transition t4 = new Transition(new TransitionType_EaseInEaseOut(900));
            t4.add(radioButton2, "Top", rBMP.Location.Y);
            t4.run();

            pnlPagoTj.Show();

        }

        private void btnCancelOP_Click(object sender, EventArgs e)
        {

            rBMP.Checked = false;
            radioButton2.Checked = false;
            pnlPagoMp.Hide();
            pnlPagoTj.Hide();

            rBMP.Show();
            radioButton2.Show();

            if (radioButton2.Location == rBMP.Location)
            {

                Transition t2 = new Transition(new TransitionType_EaseInEaseOut(1000));
                t2.add(radioButton2, "Left", 101);
                t2.run();

                Transition t1 = new Transition(new TransitionType_EaseInEaseOut(900));
                t1.add(radioButton2, "Top", 154);
                t1.run();



            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.ContieneLetrasyEspacios(e);
           
          
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.ContieneLetrasyEspacios(e);
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            bool valido = Validaciones.mailValido(txtMail.Text);


            if (valido == true)
            {
                txtMail.ForeColor = Color.Green;
                Cliente.mail = txtMail.Text;
            }
            else { txtMail.ForeColor = Color.White; }
        }

        private void txtTj_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.ContieneNumeros(e);
            if (txtTj.Text.Length >= 18)
            {
                txtTj.ForeColor = Color.Green;
                Cliente.tarjeta = txtTj.Text;
                e.Handled = true;
            }
            else { txtTj.ForeColor = Color.White; }
        }
       
       
        private void txtCVV_TextChanged(object sender, EventArgs e)
        {
            if (txtCVV.Text.Length > 3)
            {
                txtCVV.ForeColor = Color.Green;
                Cliente.Cvv = Convert.ToInt32(txtCVV.Text);
            }
            else { txtCVV.ForeColor = Color.White; }
        }

        private void txtCVV_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.ContieneNumeros(e);
        }

        private void txtVto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.ContieneNumeros(e);


            string textoActual = txtVto.Text;

  
            if (txtVto.SelectionStart == 2 && txtVto.SelectionLength == 0 && !char.IsControl(e.KeyChar))
            {
                txtVto.Text = textoActual + "/";
                txtVto.SelectionStart = txtVto.Text.Length;
                txtVto.SelectionStart++;
            }

           
            if (txtVto.Text.Length >= 5 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; 
                return;
            }
            txtVto.SelectionStart = txtVto.Text.Length;

            if (char.IsControl(e.KeyChar))
            {
                txtVto.ForeColor = Color.White;
            }
        }

        private void txtVto_TextChanged(object sender, EventArgs e)
        {
            if (txtVto.Text.Length==5)
            {
                if (Validaciones.validarFecha(txtVto.Text))
                {
                    txtVto.ForeColor = Color.Green;
                    Cliente.vto = txtVto.Text;
                }
                else {
                    txtVto.ForeColor = Color.Red;
                }
            }
        }


        private void btnContinuar_MouseEnter(object sender, EventArgs e)
        {
            btnContinuar.ImageIndex = 1;
        }



        private void btnContinuar_MouseLeave(object sender, EventArgs e)
        {
            btnContinuar.ImageIndex = 0;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            Cliente.nombre = txtNombre.Text;
            Cliente.apellido = txtApellido.Text;
            if (rBMP.Checked == true && txtNombre.Text != string.Empty && txtApellido.Text != string.Empty && txtMail.Text != string.Empty)
            {
                Form3 f3 = new Form3(pbPeli.Image);
                f3.ShowDialog();
            }
            else
            {
                if (txtTj.ForeColor==Color.Green && txtCVV.ForeColor==Color.Green && txtVto.ForeColor==Color.Green && txtNombre.Text!= string.Empty && txtApellido.Text!= string.Empty && txtMail.Text!= string.Empty )
                {
                    Form3 f3 = new Form3(pbPeli.Image);
                    f3.ShowDialog();
                    this.Close();
                }
                
                else if (txtNombre.Text == string.Empty && txtApellido.Text == string.Empty && txtMail.Text == string.Empty)
                {
                    MessageBox.Show("Complete todos los datos para continuar, por favor");

                }

                else if (rBMP.Checked==false && radioButton2.Checked== false)
                {
                    MessageBox.Show("Elija un medio de pago,por favor");

                }
                else if (radioButton2.Checked==true || txtTj.ForeColor != Color.Green || txtCVV.ForeColor != Color.Green || txtVto.ForeColor != Color.Green)
                {
                    MessageBox.Show("tarjeta invalida, ingrese los datos correctos, por favor");
                    txtTj.Clear();
                    txtVto.Clear();
                    txtCVV.Clear();
                }
            }
        }

    }

       
    }
