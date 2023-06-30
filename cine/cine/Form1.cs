using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Transitions;
using System.Windows.Forms;
using System.Globalization;


namespace cine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int contadorEntradas;
        
        List<string> lugares = new List<string>();
        List<PictureBox> film;
        List<Button> salas;
        List<Button> dias;
        TICKET ticket = new TICKET();
        DateTime hoy = DateTime.Today;
        CultureInfo cultura = new CultureInfo("es-ES");
        PictureBox principal;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        
        {
            
            principal = pbFilm1;
            film = new List<PictureBox> {pbFilm1,pbFilm2,pbFilm3,pbFilm4,pbFilm5,pbFilm6,pbFilm7,pbFilm8,pbFilm9,pbFilm10,pbFilm11};
            salas = new List<Button> {btn2DCast,btn2DSub,btn3DSub,btn3DCast };
            dias = new List<Button> { btnDia1,btnDia2,btnDia3,btnDia4,btnDia5,btnDia6,btnDia7};
            int dia = hoy.Day;
            btnDia1.Text = dia.ToString();
            btnDia2.Text = dia.ToString();
            btnDia3.Text = dia.ToString();
            btnDia4.Text = (dia + 1).ToString();
            btnDia5.Text = (dia + 1).ToString();
            btnDia6.Text = (dia + 1).ToString();
            btnDia7.Text = (dia + 2).ToString();

            lblMes.Text = cultura.DateTimeFormat.GetMonthName(hoy.Month);
            Random random = new Random();
            int numeroAleatorio = random.Next(9,16);
            lblDia1.Text = numeroAleatorio + ":00";
            btnDia1.Tag = lblDia1.Text;
            lblDia2.Text = numeroAleatorio+2 + ":00";
            btnDia2.Tag = lblDia2.Text;
            lblDia3.Text = numeroAleatorio+4 + ":00";
            btnDia3.Tag = lblDia3.Text;
            lblDia4.Text = numeroAleatorio+1 + ":00";
            btnDia4.Tag = lblDia4.Text;
            lblDia5.Text = numeroAleatorio+3 + ":00";
            btnDia5.Tag = lblDia5.Text;
            lblDia6.Text = numeroAleatorio+5 + ":00";
            btnDia6.Tag = lblDia6.Text;
            lblDia7.Text = numeroAleatorio + ":00";
            btnDia7.Tag = lblDia7.Text;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked == true)
            {
                checkBox.ImageIndex = checkBox.ImageIndex + 1;
                contadorEntradas = contadorEntradas + 1;
                ticket.Asientos.Add(checkBox.Tag.ToString());
                ticket.Cantidad = contadorEntradas;
            }
            if(checkBox.Checked == false)
            {
                contadorEntradas=contadorEntradas-1;
                checkBox.ImageIndex = 0;
                ticket.Cantidad = ticket.Cantidad - 1;
                
                for (int i = ticket.Asientos.Count - 1; i >= 0; i--)
                {
                    var asiento = ticket.Asientos[i];
                    if (checkBox.Tag.ToString() == asiento)
                    {
                        ticket.Asientos.RemoveAt(i);
                    }
                }

            }

           
           
        }

        private void pbFilmsmov_Click(object sender, EventArgs e)
        {
            PictureBox peli = (PictureBox)sender;
            int x = peli.Location.X;
            int y = peli.Location.Y;


            Transition t3 = new Transition(new TransitionType_EaseInEaseOut(1000));
            t3.add(peli, "Left", 606);
            t3.run();

            Transition t4 = new Transition(new TransitionType_EaseInEaseOut(900));
            t4.add(peli, "Top", 71);
            t4.run();

        


            Transition t2 = new Transition(new TransitionType_EaseInEaseOut(1000));
            t2.add(principal, "Left", x);
            t2.run();

            Transition t1 = new Transition(new TransitionType_EaseInEaseOut(900));
            t1.add(principal, "Top", y);
            t1.run();
            principal.BringToFront();
            peli.BringToFront();
            principal = peli;

            lblTag.Text = principal.Tag.ToString();
            ticket.Pelicula = lblTag.Text;
            lblTag.TextAlign = ContentAlignment.MiddleCenter;
           
            


            
        }

        private void panel_MouseHover(object sender, EventArgs e)
        {
            pnlBorder1.BackColor = Color.FromArgb(1,196,231);
        }

        private void pnl_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;

            if (panel.Name== "pnlSala")
            {
                pnlBorder1.BackColor = Color.FromArgb(1,196,231);
                lblSala.ForeColor = Color.FromArgb(1, 196, 231);
            }

            if (panel.Name == "pnlDia")
            {
                pnlBorder2.BackColor = Color.FromArgb(1, 196, 231);
                lblDia.ForeColor = Color.FromArgb(1, 196, 231);
                lblMes.ForeColor = Color.FromArgb(1, 196, 231);
            }

            if (panel.Name == "pnlAsiento")
            {
                pnlBorder3.BackColor = Color.FromArgb(1, 196, 231);
                lblAsiento.ForeColor = Color.FromArgb(1, 196, 231);
            }


        }

        private void pnl_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;

            if (panel.Name == "pnlSala")
            {
                pnlBorder1.BackColor = Color.Gold;
                lblSala.ForeColor = Color.Gold;
            }

            if (panel.Name == "pnlDia")
            {
                pnlBorder2.BackColor = Color.Gold;
                lblDia.ForeColor = Color.Gold;
                lblMes.ForeColor = Color.Gold;
            }

            if (panel.Name == "pnlAsiento")
            {
                pnlBorder3.BackColor = Color.Gold;
                lblAsiento.ForeColor = Color.Gold;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(1, 196, 231);
            ticket.Sala = btn.Text + " "+btn.Tag.ToString();

            foreach (Button boton in salas)
            {
                if (boton != btn)
                    boton.BackColor = Color.FromArgb(86, 98, 70);
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Button btn2 = (Button)sender;
            btn2.BackColor = Color.FromArgb(1, 196, 231);

            ticket.Dia =lblMes.Text+" " +btn2.Text + " ," +"hora:" +btn2.Tag.ToString();

            foreach (Button boton2 in dias)
            {
                if (boton2 != btn2)
                    boton2.BackColor = Color.FromArgb(86, 98, 70);
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

            if (ticket.Asientos.Count!= 0 && ticket.Dia!= string.Empty && ticket.Cantidad!= 0 && ticket.Sala!= null && ticket.Pelicula!= string.Empty)
            {
                Form2 form2 = new Form2(principal.Image);
                form2.ShowDialog();
            }
            else {
                MessageBox.Show("Elija las opciones deseadas para continuar,por favor");
            }
            
        }

       

    }
}
