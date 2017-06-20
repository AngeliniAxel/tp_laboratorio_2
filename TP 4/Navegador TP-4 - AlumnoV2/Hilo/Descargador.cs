using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        public delegate void FinDescargaCallback(string html);
        public delegate void ProgresoDescargaCallback(int progreso);

        public event FinDescargaCallback DescargaFinalizada;
        public event ProgresoDescargaCallback DescargaEnProgreso;

        private string html;
        private Uri direccion;

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DescargaEnProgreso(e.ProgressPercentage);
        }

        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                // Guardo el resultado y lo lanzo con el evento
                this.html = e.Result;
                DescargaFinalizada(e.Result);
            }
            catch (Exception ex)
            {
                //En caso de error, lanzo el evento con el mensaje
                this.DescargaFinalizada(ex.Message);
            }
        }
    }
}
