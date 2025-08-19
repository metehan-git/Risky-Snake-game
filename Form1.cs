using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace yılan_oyunu
{
    public partial class Form1 : Form
    {
        private int shakeCount = 0;
        private bool isShaking = false;
        private Panel odul = new Panel();
        private Panel duvar = new Panel();
        private Panel duvar1 = new Panel();
        private Panel duvar2 = new Panel();
        private Panel duvar3 = new Panel();
        private Panel duvar4 = new Panel();
        private Panel duvar5 = new Panel();
        private Panel duvar6 = new Panel();
        private Panel duvar7 = new Panel();
        private Panel parca;
        private Panel elma = new Panel();
        private Panel elma1 = new Panel();
        private Panel elma2 = new Panel();
        private Panel elma3 = new Panel();
        private Panel elma4 = new Panel();
        private Panel engel = new Panel();
        private SoundPlayer player = new SoundPlayer();
        private List<Panel> yilan = new List<Panel>();
        private string yon;

        public Form1()
        {
            InitializeComponent();

        }

        

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            panelTemizle();
            string dosyaYolu = Path.Combine(Application.StartupPath, "portal-2-end-credits-song-want-you-gone-by-jonathan-coulton-1080p-hd.wav");
            player.SoundLocation = dosyaYolu;
            player.Play();

            parca = new Panel();
            parca.Location = new Point(140, 160);
            parca.Size = new Size(20, 20);
            parca.BackColor = Color.Black;
            yilan.Add(parca);
            panel1.Controls.Add(yilan[0]);
            parcaEkle(); parcaEkle(); parcaEkle(); parcaEkle();
            timer1.Start();
            elmaOlustur();
            duvarOlustur();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int locX = yilan[0].Location.X;
            int locY = yilan[0].Location.Y;
            elmaYeme();
            hareket();
            carpisma();

            if (yon == "sağ")
            {
                if (locX < 580)
                    locX += 20;
                else
                    locX = 0;
            }

            if (yon == "sol")
            {
                if (locX > 0)
                    locX -= 20;
                else
                    locX = 580;
            }

            if (yon == "aşağı")
            {
                if (locY < 580)
                    locY += 20;
                else
                    locY = 0;
            }

            if (yon == "yukarı")
            {
                if (locY > 0)
                    locY -= 20;
                else
                    locY = 580;
            }

            yilan[0].Location = new Point(locX, locY);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (((e.KeyCode == Keys.Right) || (e.KeyCode == Keys.D)) && (yon != "sol"))
                yon = "sağ";
            if (((e.KeyCode == Keys.Left) || (e.KeyCode == Keys.A)) && (yon != "sağ"))
                yon = "sol";
            if (((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.W)) && (yon != "aşağı"))
                yon = "yukarı";
            if (((e.KeyCode == Keys.Down) || (e.KeyCode == Keys.S)) && (yon != "yukarı"))
                yon = "aşağı";
            if ((e.KeyCode == Keys.Space))
                label3_Click(sender, e);
        }

        private void engeller()
        {
            Random rnd1 = new Random();
            int engelX, engelY;
            engelX = rnd1.Next(580);
            engelY = rnd1.Next(580);
            engelX -= engelX % 20;
            engelY -= engelY % 20;
            engel.Size = new Size(20, 20);
            engel.BackColor = Color.Red;
            engel.Location = new Point(engelX, engelY);
            panel1.Controls.Add(engel);
        }

        private void elmaOlustur()
        {
            Random rnd = new Random();

            int elmaX, elmaY;
            elmaX = rnd.Next(580);
            elmaY = rnd.Next(580);

            elmaX -= elmaX % 20;
            elmaY -= elmaY % 20;

            elma.Size = new Size(20, 20);
            elma.BackColor = Color.Red;
            elma.Location = new Point(elmaX, elmaY);
            panel1.Controls.Add(elma);

            Random rnd2 = new Random();

            int elma1X, elma1Y;
            elma1X = rnd2.Next(580);
            elma1Y = rnd2.Next(580);

            elma1X -= elma1X % 20;
            elma1Y -= elma1Y % 20;

            elma1.Size = new Size(20, 20);
            elma1.BackColor = Color.Red;
            elma1.Location = new Point(elma1X, elma1Y);
            panel1.Controls.Add(elma1);

            Random rnd3 = new Random();

            int elma2X, elma2Y;
            elma2X = rnd3.Next(580);
            elma2Y = rnd3.Next(580);

            elma2X -= elma2X % 20;
            elma2Y -= elma2Y % 20;

            elma2.Size = new Size(20, 20);
            elma2.BackColor = Color.Red;
            elma2.Location = new Point(elma2X, elma2Y);
            panel1.Controls.Add(elma2);

            Random rnd4 = new Random();

            int elma3X, elma3Y;
            elma3X = rnd4.Next(580);
            elma3Y = rnd4.Next(580);

            elma3X -= elma3X % 20;
            elma3Y -= elma3Y % 20;

            elma3.Size = new Size(20, 20);
            elma3.BackColor = Color.Red;
            elma3.Location = new Point(elma3X, elma3Y);
            panel1.Controls.Add(elma3);

            Random rnd5 = new Random();

            int elma4X, elma4Y;
            elma4X = rnd5.Next(580);
            elma4Y = rnd5.Next(580);

            elma4X -= elma4X % 20;
            elma4Y -= elma4Y % 20;

            elma4.Size = new Size(20, 20);
            elma4.BackColor = Color.Red;
            elma4.Location = new Point(elma4X, elma4Y);
            panel1.Controls.Add(elma4);
        }

        private void elmaYeme()
        {
            int puan = int.Parse(label2.Text);
            if (yilan[0].Location == elma.Location || yilan[0].Location == elma1.Location || yilan[0].Location == elma2.Location
                 || yilan[0].Location == elma3.Location || yilan[0].Location == elma4.Location)
            {
                puan += 10;
                label2.Text = puan.ToString();
                elmaOlustur();
                parcaEkle();
                engeller();
                StartShaking();
            }

            if (yilan[0].Location == odul.Location)
            {
                puan += 100;
                label2.Text = puan.ToString();
                parcaEkle(); parcaEkle(); parcaEkle(); parcaEkle(); parcaEkle();
                parcaEkle(); parcaEkle(); parcaEkle(); parcaEkle(); parcaEkle();
                odul.Location = new Point(-120, -120);
                panel1.Controls.Add(odul);
                panel1.Controls.Remove(odul);
            }
        }

        private void parcaEkle()
        {
            Panel ekParca = new Panel();
            ekParca.Size = new Size(20, 20);
            ekParca.BackColor = Color.Green;
            panel1.Controls.Add(ekParca);
            ekParca.Location = new Point(-100, -100);
            yilan.Add(ekParca);
        }

        private void hareket()
        {
            for (int i = yilan.Count - 1; i > 0; i--)
                yilan[i].Location = yilan[i - 1].Location;
        }

        private void carpisma()
        {
            for (int i = 2; i < yilan.Count; i++)
            {
                if (yilan[0].Location == yilan[i].Location)
                {
                    label4.Visible = true;
                    label4.Text = "KAYBETTİNİZ";
                    label3.Text = "TEKRAR BAŞLA";
                    label3.BackColor = Color.Orange;
                    timer1.Stop();
                    player.Stop();
                }
            }

            if (yilan[0].Location == engel.Location)
            {
                label4.Visible = true;
                label4.Text = "KAYBETTİNİZ";
                label3.Text = "TEKRAR BAŞLA";
                label3.BackColor = Color.Orange;
                timer1.Stop();
                player.Stop();
            }

            if (yilan[0].Location == duvar.Location || yilan[0].Location == duvar1.Location || yilan[0].Location == duvar2.Location || yilan[0].Location == duvar3.Location
                || yilan[0].Location == duvar4.Location || yilan[0].Location == duvar5.Location || yilan[0].Location == duvar6.Location || yilan[0].Location == duvar7.Location)
            {
                label4.Visible = true;
                label4.Text = "KAYBETTİNİZ";
                label3.Text = "TEKRAR BAŞLA";
                label3.BackColor = Color.Orange;
                timer1.Stop();
                player.Stop();
            }
        }

        private void panelTemizle()
        {
            yon = "sağ";
            label2.Text = "0";
            label4.Visible = false;
            label3.Text = "YENİLE";
            label3.BackColor = Color.Lime;
            yilan.Clear();
            panel1.Controls.Clear();
        }

        private void StartShaking()
        {
            if (!isShaking)
            {
                isShaking = true;
                shakeCount = 0;
                timer2.Start();
            }
        }

        private void duvarOlustur()
        {
            int odulX = 120, odulY = 120;
            int duvarX = 100, duvarY = 100;
            int duvar1X = 140, duvar1Y = 100;
            int duvar2X = 100, duvar2Y = 140;
            int duvar3X = 140, duvar3Y = 140;
            int duvar4X = 60, duvar4Y = 120;
            int duvar5X = 180, duvar5Y = 120;
            int duvar6X = 120, duvar6Y = 60;
            int duvar7X = 120, duvar7Y = 180;

            duvar.Size = new Size(20, 20);
            duvar.BackColor = Color.Blue;
            duvar.Location = new Point(duvarX, duvarY);
            panel1.Controls.Add(duvar);

            duvar1.Size = new Size(20, 20);
            duvar1.BackColor = Color.Blue;
            duvar1.Location = new Point(duvar1X, duvar1Y);
            panel1.Controls.Add(duvar1);

            duvar2.Size = new Size(20, 20);
            duvar2.BackColor = Color.Blue;
            duvar2.Location = new Point(duvar2X, duvar2Y);
            panel1.Controls.Add(duvar2);

            duvar3.Size = new Size(20, 20);
            duvar3.BackColor = Color.Blue;
            duvar3.Location = new Point(duvar3X, duvar3Y);
            panel1.Controls.Add(duvar3);

            duvar4.Size = new Size(20, 20);
            duvar4.BackColor = Color.Blue;
            duvar4.Location = new Point(duvar4X, duvar4Y);
            panel1.Controls.Add(duvar4);

            duvar5.Size = new Size(20, 20);
            duvar5.BackColor = Color.Blue;
            duvar5.Location = new Point(duvar5X, duvar5Y);
            panel1.Controls.Add(duvar5);

            duvar6.Size = new Size(20, 20);
            duvar6.BackColor = Color.Blue;
            duvar6.Location = new Point(duvar6X, duvar6Y);
            panel1.Controls.Add(duvar6);

            duvar7.Size = new Size(20, 20);
            duvar7.BackColor = Color.Blue;
            duvar7.Location = new Point(duvar7X, duvar7Y);
            panel1.Controls.Add(duvar7);

            odul.Size = new Size(20, 20);
            odul.BackColor = Color.DarkGoldenrod;
            odul.Location = new Point(odulX, odulY);
            panel1.Controls.Add(odul);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (shakeCount < 10)
            {
                if (shakeCount % 2 == 0)
                    this.Location = new Point(this.Location.X + 5, this.Location.Y + 5);
                else
                    this.Location = new Point(this.Location.X - 5, this.Location.Y - 5);

                shakeCount++;
            }
            else
            {
                // Titretmeyi durdur
                timer2.Stop();
                shakeCount = 0;
                isShaking = false;

                Random rn1 = new Random();

                int yerX, yerY;

                yerX = rn1.Next(600);
                yerY = rn1.Next(300);

                this.Location = new Point(yerX, yerY); // Formu orijinal konumuna geri getir
            }
        }
    }
}
