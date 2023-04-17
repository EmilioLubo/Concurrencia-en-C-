using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramacionAsincrona
{
    public partial class Form1 : Form
    {
        private string _url;
        private HttpClient _httpClient;
        private CancellationTokenSource _cancellationTokenSource;


        public Form1()
        {
            InitializeComponent();
            _url = "https://localhost:7038";
            _httpClient = new HttpClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(30));
            loadingGif.Enabled = true;

            var nombres = new List<string>() { "Felipe", "Claudio" };

            foreach (var n in nombres)
            {
                Console.WriteLine(n);
            }

            //var reportarProgreso = new Progress<int>(ReportarProgresoTarjetas);

            //try
            //{
            //    var r = await Task.Run(async () =>
            //    {
            //        await Task.Delay(5000);
            //        return 7;
            //    }).WithCancellation(_cancellationTokenSource.Token);

            //    Console.WriteLine(r);
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    _cancellationTokenSource.Dispose();
            //}

            //var nuevaT = EvaluarValor(txtInput.Text);

            //Console.WriteLine("inicio");
            //Console.WriteLine(nuevaT.IsCompleted);
            //Console.WriteLine(nuevaT.IsCanceled);
            //Console.WriteLine(nuevaT.IsFaulted);

            //try
            //{
            //    await nuevaT;
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Console.WriteLine("fin");
            //Console.WriteLine("----------------------------------------------");

            //var reintentos = 3;
            //var tiempo = 500;

            //for (int i = 0;i < reintentos; i++)
            //{
            //    try
            //    {
            //        //operación
            //        break;
            //    }
            //    catch(Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        await Task.Delay(tiempo);
            //    }
            //}

            //await Esperar();

            //var nombres = new[] { "Mateo", "Marcos", "Lucas", "Juan" };

            //var tareas = nombres.Select(n => ObtenerSaludo(n, _cancellationTokenSource.Token));
            //var t = await Task.WhenAny(tareas);
            //var contenido = await t;
            //Console.WriteLine(contenido.ToUpper());
            //_cancellationTokenSource.Cancel();

            //try
            //{
            //    var contenido = await Reintentar(async () =>
            //    {
            //        using (var respuesta = await _httpClient.GetAsync($"{_url}/saludos2/Felipe"))
            //        {
            //            respuesta.EnsureSuccessStatusCode();
            //            return await respuesta.Content.ReadAsStringAsync();
            //        }
            //    });
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine($"ULTIMO INTENTO = {ex.Message}");
            //}

            CheckForIllegalCrossThreadCalls = true;

            //btnCcl.Text = "antes";
            //await Task.Delay(1000).ConfigureAwait(continueOnCapturedContext: true);
            //btnCcl.Text = "después";

            //var nombre = txtInput.Text;
            //await ObtenerSaludo("Juan Carlos");
            var sw = new Stopwatch();
            sw.Start();
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            //await Task.Delay(1000);
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            //try
            //{
            //    var tarjetas = await GetTarjetas(10, _cancellationTokenSource.Token);
            //    //var saludo = await ObtenerSaludo(nombre);
            //    //MessageBox.Show(saludo);
            //    await ProcesarTarjetas(tarjetas, reportarProgreso, _cancellationTokenSource.Token);
            //    pgProcesamiento.Value = 100;

            //}
            //catch (HttpRequestException ex)
            //{
            //    loadingGif.Enabled = false;
            //    MessageBox.Show(ex.Message);
            //}
            //catch (TaskCanceledException ex)
            //{
            //    loadingGif.Enabled = false;
            //    MessageBox.Show("La operación ha sido cancelada", ex.Message);
            //}
            //try
            //{
            //    await foreach (var n in GenerarNombres(_cancellationTokenSource.Token))
            //    {
            //        Console.WriteLine(n);
            //        //break;
            //    }
            //}
            //catch (TaskCanceledException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    _cancellationTokenSource?.Dispose();
            //}

            var nombresI = GenerarNombres();
            await ProcesarNombres(nombresI);
            Console.WriteLine("Fin");

            loadingGif.Enabled = false;
            MessageBox.Show($"Operación finalizada en {sw.ElapsedMilliseconds / 1000.0} segundos.");

            pgProcesamiento.Value = 0;
        }

        private async Task ProcesarNombres(IAsyncEnumerable<string> nombresI)
        {
            try
            {
                await foreach(var n in nombresI.WithCancellation(_cancellationTokenSource.Token))
                {
                    Console.WriteLine(n);
                }
            }
            catch(TaskCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _cancellationTokenSource?.Dispose();
            }
        }

        private async IAsyncEnumerable<string> GenerarNombres([EnumeratorCancellation] CancellationToken ct = default)
        {
            yield return "Emilio";
            await Task.Delay(3000, ct);
            yield return "Claudia";
            await Task.Delay(3000, ct);
            yield return "Pedro";
        }

        public Task EvaluarValor(string v)
        {
            var tcs = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

            if (v == "1")
            {
                tcs.SetResult(null);
            }
            else if (v == "2")
            {
                tcs.SetCanceled();
            }
            else
            {
                tcs.SetException(new ApplicationException($"Valor inválido: {v}"));
            }
            return tcs.Task;
        }

        private async Task<T> Reintentar<T>(Func<Task<T>> f, int reintentos = 3, int tiempo = 500)
        {
            for (int i = 0; i < reintentos - 1; i++)
            {
                try
                {
                    return await f();
                    break;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    await Task.Delay(tiempo);
                }

            }
            return await f();
        }

        private void ReportarProgresoTarjetas(int porcentaje)
        {
            pgProcesamiento.Value = porcentaje;
        }

        private Task ProcesarTarjetasMock(List<string> tarjetas, IProgress<int> progress = null, CancellationToken ct = default)
        {
            return Task.CompletedTask;
        }

        private async Task ProcesarTarjetas(List<string> tarjetas, IProgress<int> progress = null, CancellationToken ct = default)
        {
            using var semaforo = new SemaphoreSlim(3000); 

            var tareas = new List<Task<HttpResponseMessage>>();

            var i = 0;

            tareas = tarjetas.Select(async t =>
            {
                var json = JsonConvert.SerializeObject(t);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                await semaforo.WaitAsync();
                try
                {
                    //var tareaInterna = await _httpClient.PostAsync($"{_url}/tarjetas", content);

                    //if (progress != null)
                    //{
                    //    i++;
                    //    var porcentaje = (double) i / tarjetas.Count;
                    //    porcentaje = porcentaje * 100;
                    //    var porcentajeInt = (int)Math.Round(porcentaje, 0);
                    //    progress.Report(porcentajeInt);
                    //}

                    //return tareaInterna;
                    return await _httpClient.PostAsync($"{_url}/tarjetas", content, ct);
                }
                finally 
                { 
                    semaforo.Release(); 
                }
            }).ToList();

            //await Task.Run(() =>
            //{
            //    foreach(var t in tarjetas)
            //    {
                    
            //    }
            //});

            var res = Task.WhenAll(tareas);

            if(progress != null)
            {
                while(await Task.WhenAny(res, Task.Delay(1000)) != res)
                {
                    var completas = tareas.Where(t => t.IsCompleted).Count();
                    var porcentaje = (double) completas / tarjetas.Count;
                    porcentaje = porcentaje * 100;
                    var porcentajeInt = (int)Math.Round(porcentaje, 0);
                    progress.Report(porcentajeInt);
                }
            }

            var rt = await res;

            var rechazadas = new List<string>();

            foreach(var r in rt)
            {
                var contenido = await r.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<ResponseTarjeta>(contenido);
                if (!respuesta.Aprobada)
                {
                    rechazadas.Add(respuesta.Tarjeta);
                }
            }

            foreach(var t in rechazadas)
            {
                Console.WriteLine(t);
            }
        }

        private Task<List<string>> GetTarjetasMock(int cant, CancellationToken ct = default)
        {
            var tarjetas = new List<string>();
            tarjetas.Add("000000001");

            return Task.FromResult(tarjetas);
        }

        private Task ObtenerTreaConError()
        {
            return Task.FromException(new ApplicationException());
        }

        private Task ObtenerTreaCancelada()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            return Task.FromCanceled(_cancellationTokenSource.Token);
        }

        private async Task<List<string>> GetTarjetas(int cant, CancellationToken ct = default)
        {
            return await Task.Run(async () =>
            {
                var tarjetas = new List<string>();

                for(int i = 0; i < cant; i++)
                {
                    await Task.Delay(1000);
                    tarjetas.Add(i.ToString().PadLeft(16, '0'));

                    Console.WriteLine($"Han sido generadas {tarjetas.Count} tarjetas");

                    if (_cancellationTokenSource.IsCancellationRequested)
                    {
                        throw new TaskCanceledException();
                    }
                }

                return tarjetas;
            });
        }

        private async Task Esperar()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
        }

        private async Task<string> ObtenerSaludo(string nombre, CancellationToken ct = default)
        {
            using (var respuesta = await _httpClient.GetAsync($"{_url}/saludos/delay/{nombre}", ct))
            {
                respuesta.EnsureSuccessStatusCode();
                var saludo = await respuesta.Content.ReadAsStringAsync();
                return saludo;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
        }
    }
}
