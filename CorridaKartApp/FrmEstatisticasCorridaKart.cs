using CorridaKart.Dados;
using CorridaKart.Entidade;
using CorridaKart.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorridaKartApp
{
    public partial class FrmEstatisticasCorridaKart : Form
    {
        public FrmEstatisticasCorridaKart()
        {
            InitializeComponent();
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            try
            {
                //Objeto externo - Instancio objeto neste ponto 
                //para permitir posteriormente realizar a injecao de dependencia
                //para que seja possivel realizar os testes unitários (MOQ)
                Arquivo arquivo = new Arquivo(txtCaminhoArquivo.Text);

                TratarCorrida corridaRealizada = new TratarCorrida(arquivo);
                List<ResultadoCorridaPiloto> estatisticasPilotoCorrida = corridaRealizada.ObterEstatisticasPilotosCorrida();
                List<ResultadoCorrida> estatisticasCorrida = corridaRealizada.ObterEstatisticasCorrida(estatisticasPilotoCorrida);

                dgvEstatisticaCorrida.DataSource = estatisticasCorrida;
                dgvEstatisticaPilotosCorrida.DataSource = estatisticasPilotoCorrida;
            }
            catch(Exception ex)
            {
                // Não pode carregar a imagem (problemas de permissão)
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmEstatisticasCorridaKart_Load(object sender, EventArgs e)
        {

        }

        private void btnProcurarArquivo_Click(object sender, EventArgs e)
        {
            //define as propriedades do controle 
            //OpenFileDialog
            this.ofd1.Multiselect = false;
            this.ofd1.Title = "Selecionar Arquivo";
            ofd1.InitialDirectory = @"C:\";
            //filtra para exibir somente arquivos de imagens
            //ofd1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
            ofd1.CheckFileExists = true;
            ofd1.CheckPathExists = true;
            ofd1.FilterIndex = 2;
            ofd1.RestoreDirectory = true;
            ofd1.ReadOnlyChecked = true;
            ofd1.ShowReadOnly = true;

            DialogResult dr = this.ofd1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {             
                txtCaminhoArquivo.Text = ofd1.FileName;

                    //catch (Exception ex)
                    //{
                    //    // Não pode carregar a imagem (problemas de permissão)
                    //    MessageBox.Show("Não é possível exibir a imagem : " + arquivo.Substring(file.LastIndexOf('\\'))
                    //                               + ". Você pode não ter permissão para ler o arquivo , ou " +
                    //                               " ele pode estar corrompido.\n\nErro reportado : " + ex.Message);
                    //}
            }
        }
    }
}
