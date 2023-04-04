using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramacionAsincrona
{
    public partial class Form1 : Form
    {
        private string _url;
        HttpClient _httpClient;

        public Form1()
        {
            InitializeComponent();
            _url = "https://localhost:7038";
            _httpClient= new HttpClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            loadingGif.Enabled = true;

            //await Esperar();

            //var nombre = txtInput.Text;
            var tarjetas = GetTarjetas(2000);
            var sw = new Stopwatch();
            sw.Start();

            try
            {
                //var saludo = await ObtenerSaludo(nombre);
                //MessageBox.Show(saludo);
                await ProcesarTarjetas(tarjetas);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show($"Operación finalizada en {sw.ElapsedMilliseconds / 1000.0} segundos.");

            loadingGif.Enabled = false;
        }

        private async Task ProcesarTarjetas(List<string> tarjetas)
        {
            var tareas = new List<Task>();

            foreach(var t in tarjetas)
            {
                var json = JsonConvert.SerializeObject(t);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var res = _httpClient.PostAsync($"{_url}/tarjetas", content);
            }

            await Task.WhenAll(tareas);
        }

        private List<string> GetTarjetas(int cant)
        {
            var tarjetas = new List<string>();

            for(int i = 0; i < cant; i++)
            {
                tarjetas.Add(i.ToString().PadLeft(16, '0'));
            }

            return tarjetas;
        }

        private async Task Esperar()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
        }

        private async Task<string> ObtenerSaludo(string nombre)
        {
            using (var respuesta = await _httpClient.GetAsync($"{_url}/saludos/{nombre}"))
            {
                respuesta.EnsureSuccessStatusCode();
                var saludo = await respuesta.Content.ReadAsStringAsync();
                return saludo;
            }
        }
    }
}
