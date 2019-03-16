using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using TranScript;
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;

namespace TranScript
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fermeture de l'application
            Application.Exit();
        }

        private void lectureCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Height = 515;
            progressBar1.Visible = true;
            progressBar1.Value = 1;
            progressBar1.Step = 1;
            progressBar1.Maximum = dataGridView1.Rows.Count - 1;
            progressBar1.Minimum = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int nbLigne = dataGridView1.Rows.Count;

                if (row.Index < nbLigne - 1)
                {
                    string date = "";
                    string horaire = "";
                    string montantMine = "";
                    string Nomcrypto = "";
                    string id = "";
                    string symbole = "";
                    string remarque = "";
                    Decimal cours = 0;

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.ColumnIndex == 0)
                        {
                            //remplace les / par des - pour l'api
                            date = cell.Value.ToString();
                            date = date.Replace('/', '-');
                        }
                        if (cell.ColumnIndex == 1)
                        {
                            //horaire non utilisé
                            horaire = cell.Value.ToString();
                            horaire = horaire.Replace(':', '-');
                        }
                        if (cell.ColumnIndex == 2)
                        {
                            //nombre de crypto recu
                            montantMine = cell.Value.ToString();
                            montantMine = montantMine.Replace('.', ',');
                        }
                        if (cell.ColumnIndex == 3)
                        {
                            //mets le symbole en minuscule
                            Nomcrypto = cell.Value.ToString().ToLower();
                            using (var webClient = new System.Net.WebClient())
                            {
                                //recuperation du contenu du json(liste de toutes les cryptos) dans une variable
                                var json = webClient.DownloadString("https://api.coingecko.com/api/v3/coins/list");
                                //lecture du contenu du json
                                var listeCrypto = ListCrypto.FromJson(json);
                                //lit la liste et donne l'id de la crypto correspondant au symbole
                                for (int i = 1; i < listeCrypto.Count; i++)
                                {
                                    if (Nomcrypto == listeCrypto[i].Symbol.ToString())
                                    {
                                        id = listeCrypto[i].Id.ToString();
                                        symbole = listeCrypto[i].Symbol.ToString();
                                    }
                                }
                            }
                            //Si l'id de la crypto correspond à un symbole
                            if (id != ""){
                                Nomcrypto = Nomcrypto.Replace(symbole, id);
                            }
                            else
                            {
                                remarque = "Crypto non référencée";
                            }
                        }
                        if (cell.ColumnIndex == 4)
                        {
                            using (var webClient = new System.Net.WebClient())
                            {
                                //Si l'id de la crypto correspond à un symbole
                                if (id != "")
                                {
                                    //recuperation du contenu du json dans une variable suivant l'id de la crypto et la date
                                    var json = webClient.DownloadString("https://api.coingecko.com/api/v3/coins/" + Nomcrypto + "/history?date=" + date);
                                    //lecture du contenu du json
                                    var crypto = Crypto.FromJson(json);
                                    //verif si il y a un cours valide
                                    if (crypto.MarketData != null)
                                    {
                                        cours = crypto.MarketData.CurrentPrice.Eur;
                                    }
                                    else
                                    {
                                        remarque = "Aucun cours pour cette date";
                                    }
                                    cell.Value = cours.ToString();
                                }
                                //Si l'id de la crypto ne correspond à aucun symbole
                                else
                                {
                                    cell.Value = 0;
                                }
                            }
                        }
                        if (cell.ColumnIndex == 5)
                        {
                                //calcule le gain de la ligne suivant la date donnée
                                cell.Value = Convert.ToDecimal(montantMine) * cours;
                        }
                        if (cell.ColumnIndex == 6)
                        {
                            //ajout une remarque si crypto à zéro
                            cell.Value = remarque;
                            progressBar1.PerformStep();
                        }
                    }
                }
            }
            this.Height = 490;
            progressBar1.Visible = false;
        }


        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "txt files (*.txt)|*.txt| CSV Files (*.csv) | *.csv| All Files (*.*) | *.*";
            openFile.FilterIndex = 2;
            openFile.RestoreDirectory = true;
            try
            {
                //ouverture du fichier
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string file = openFile.FileName;
                    StreamReader sr = new StreamReader(file);

                    //tout le fichier dans un tableau
                    string[] str = File.ReadAllLines(file);

                    DataTable dt = new DataTable();

                    //on lit la premiere ligne pour ajouter les entetes
                    string[] temp = str[0].Split(';');

                    foreach (string t in temp)
                    {
                        dt.Columns.Add(t, typeof(string));
                    }

                    //on lit les autres lignes pour les ajouter au visuel
                    for (int i = 1; i < str.Length; i++)
                    {
                        string[] t = str[i].Split(';');
                        dt.Rows.Add(t);
                    }
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: Le fichier ne peut pas être chargé" + ex.Message);
            }
            finally
            {
                actionToolStripMenuItem.Visible = true;
                dataGridView1.Columns[6].Width = 155;
            }
        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv";
            sfd.FileName = "Output.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string stOutput = "";
                string sHeaders = "";

                //on lit la premiere ligne pour ajouter les entetes
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[0].Cells[j].ColumnIndex < dataGridView1.Columns.Count - 1)
                    {
                        sHeaders = sHeaders.ToString() + Convert.ToString(dataGridView1.Columns[j].HeaderText) + ";";
                    }
                    else
                    {
                        sHeaders = sHeaders.ToString() + Convert.ToString(dataGridView1.Columns[j].HeaderText);
                    }
                }  

                stOutput += sHeaders + "\r\n";

                //on lit les autres lignes pour les ajouter
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    string stLine = "";

                    for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].ColumnIndex < dataGridView1.Rows[i].Cells.Count - 1)
                        {
                            stLine = stLine.ToString() + Convert.ToString(dataGridView1.Rows[i].Cells[j].Value) + ";";
                        }
                        else
                        {
                            stLine = stLine.ToString() + Convert.ToString(dataGridView1.Rows[i].Cells[j].Value);
                        }
                    }
                    stOutput += stLine + "\r\n";

                }



                UTF8Encoding utf8 = new UTF8Encoding();
                
                byte[] output = utf8.GetBytes(stOutput);

                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);

                bw.Write(output, 0, output.Length); 
                bw.Flush();
                bw.Close();
                fs.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

    }
}
