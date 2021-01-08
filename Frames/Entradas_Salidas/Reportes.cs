using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using TakeControl.Datos;

namespace TakeControl
{
    public partial class Reportes : Form
    {
        public ConectaBD abc = new ConectaBD();
        public Reportes(String TipoUser)
        {
            InitializeComponent();
            GTipoUser = TipoUser;
            //MessageBox.Show("TipoUsuario" + GTipoUser);
        }
        String GTipoUser = "";

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            Herramientas herramientas = new Herramientas(GTipoUser);
            herramientas.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Ingresa todos los datos :)");
            }
            else
            {
                iTextSharp.text.Font text = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 11);

                if (comboBox1.SelectedIndex == 0)
                {
                    dataGridView1.DataSource = abc.MostrarReporte(3, inicio: monthCalendar1.SelectionStart, fin: monthCalendar2.SelectionStart);
                    PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                    pdfTable.DefaultCell.Padding = 3;
                    pdfTable.WidthPercentage = 100;
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    SaveFileDialog sfd = new SaveFileDialog();
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        pdfTable.AddCell(cell);
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value.ToString());
                        }
                    }

                    using (FileStream stream = new FileStream(@"C:\Users\idiaz\OneDrive - Instituto Politecnico Nacional\ESIME\ESIME\S6\05 - ISW\Proyecto Take Control\Reporte de Movimientos.pdf", FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(new Paragraph("                                                          REPORTE DE MOVIMIENTOS"));
                        pdfDoc.Add(new Paragraph("PERIODO: " + monthCalendar1.SelectionStart + " - " + monthCalendar2.SelectionStart));
                        pdfDoc.Add(Chunk.NEWLINE);
                        pdfDoc.Add(Chunk.NEWLINE);
                        pdfDoc.Add(new Paragraph("ENTRADAS"));
                        pdfDoc.Add(Chunk.NEWLINE);
                        pdfDoc.Add(pdfTable);
                        String TotalEntradas = abc.MostrarDatosReporte(8, inicio: monthCalendar1.SelectionStart, fin: monthCalendar2.SelectionStart);
                        pdfDoc.Add(new Paragraph("TOTAL ENTRADAS: "+TotalEntradas + " PESOS"));
                        dataGridView1.DataSource = abc.MostrarReporte(4, inicio: monthCalendar1.SelectionStart, fin: monthCalendar2.SelectionStart);
                        PdfPTable pdfTable1 = new PdfPTable(dataGridView1.Columns.Count);
                        pdfTable1.DefaultCell.Padding = 3;
                        pdfTable1.WidthPercentage = 100;
                        pdfTable1.HorizontalAlignment = Element.ALIGN_LEFT;
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                            pdfTable1.AddCell(cell);
                        }

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                pdfTable1.AddCell(cell.Value.ToString());
                            }
                        }
                        pdfDoc.Add(Chunk.NEWLINE);
                        pdfDoc.Add(new Paragraph("SALIDAS"));
                        pdfDoc.Add(Chunk.NEWLINE);
                        pdfDoc.Add(pdfTable1);
                        String TotalSalidas = abc.MostrarDatosReporte(9, inicio: monthCalendar1.SelectionStart, fin: monthCalendar2.SelectionStart);
                        pdfDoc.Add(new Paragraph("TOTAL SALIDAS: " + TotalSalidas + " PESOS"));
                        dataGridView1.DataSource = abc.MostrarReporte(5, inicio: monthCalendar1.SelectionStart, fin: monthCalendar2.SelectionStart);
                        PdfPTable pdfTable2 = new PdfPTable(dataGridView1.Columns.Count);
                        pdfTable2.DefaultCell.Padding = 3;
                        pdfTable2.WidthPercentage = 100;
                        pdfTable2.HorizontalAlignment = Element.ALIGN_LEFT;
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                            pdfTable2.AddCell(cell);
                        }

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                pdfTable2.AddCell(cell.Value.ToString());
                            }
                        }
                        pdfDoc.Add(Chunk.NEWLINE);
                        pdfDoc.Add(new Paragraph("MERMAS"));
                        pdfDoc.Add(Chunk.NEWLINE);
                        pdfDoc.Add(pdfTable2);
                        String TotalMermas = abc.MostrarDatosReporte(10, inicio: monthCalendar1.SelectionStart, fin: monthCalendar2.SelectionStart);
                        pdfDoc.Add(new Paragraph("TOTAL MERMAS: " + TotalMermas +" UNIDADES"));
                        pdfDoc.Close();
                        stream.Close();
                    }
                }

                else if (comboBox1.SelectedIndex == 1)
                {
                    dataGridView1.DataSource = abc.MostrarReporte(1, inicio: monthCalendar1.SelectionStart, fin: monthCalendar2.SelectionStart);
                    PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                    pdfTable.DefaultCell.Padding = 3;
                    pdfTable.WidthPercentage = 100;
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    SaveFileDialog sfd = new SaveFileDialog();
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        pdfTable.AddCell(cell);
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value.ToString());
                        }
                    }

                    using (FileStream stream = new FileStream(@"C:\Users\idiaz\OneDrive - Instituto Politecnico Nacional\ESIME\ESIME\S6\05 - ISW\Proyecto Take Control\Reporte de Entradas.pdf", FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(new Paragraph("                                                          REPORTE DE ENTRADAS"));
                        pdfDoc.Add(new Paragraph("PERIODO: " + monthCalendar1.SelectionStart + " - " + monthCalendar2.SelectionStart));
                        pdfDoc.Add(Chunk.NEWLINE);
                        pdfDoc.Add(pdfTable);
                        String TotalEntradas = abc.MostrarDatosReporte(8, inicio: monthCalendar1.SelectionStart, fin: monthCalendar2.SelectionStart);
                        pdfDoc.Add(new Paragraph("TOTAL ENTRADAS: " + TotalEntradas + " PESOS"));
                        pdfDoc.Close();
                        stream.Close();
                    }
                }

                else if (comboBox1.SelectedIndex == 2)
                {
                    dataGridView1.DataSource = abc.MostrarReporte(2, inicio: monthCalendar1.SelectionStart, fin: monthCalendar2.SelectionStart);
                    PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                    pdfTable.DefaultCell.Padding = 3;
                    pdfTable.WidthPercentage = 100;
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    SaveFileDialog sfd = new SaveFileDialog();
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        pdfTable.AddCell(cell);
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value.ToString());
                        }
                    }

                    using (FileStream stream = new FileStream(@"C:\Users\idiaz\OneDrive - Instituto Politecnico Nacional\ESIME\ESIME\S6\05 - ISW\Proyecto Take Control\Reporte de Salidas.pdf", FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(new Paragraph("                                                          REPORTE DE SALIDAS"));
                        pdfDoc.Add(new Paragraph("PERIODO: " + monthCalendar1.SelectionStart + " - " + monthCalendar2.SelectionStart));
                        pdfDoc.Add(Chunk.NEWLINE);
                        pdfDoc.Add(pdfTable);
                        String TotalSalidas = abc.MostrarDatosReporte(9, inicio: monthCalendar1.SelectionStart, fin: monthCalendar2.SelectionStart);
                        pdfDoc.Add(new Paragraph("TOTAL SALIDAS: " + TotalSalidas + " PESOS"));
                        pdfDoc.Close();
                        stream.Close();
                    }
                }

                else if (comboBox1.SelectedIndex == 3)
                {
                    dataGridView1.DataSource = abc.MostrarReporte(6, inicio: monthCalendar1.SelectionStart, fin: monthCalendar2.SelectionStart);
                    PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count);
                    pdfTable.DefaultCell.Padding = 3;
                    pdfTable.WidthPercentage = 100;
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    SaveFileDialog sfd = new SaveFileDialog();
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        pdfTable.AddCell(cell);
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value.ToString());
                        }
                    }

                    using (FileStream stream = new FileStream(@"C:\Users\idiaz\OneDrive - Instituto Politecnico Nacional\ESIME\ESIME\S6\05 - ISW\Proyecto Take Control\Reporte de Entradas Vs Salidas.pdf", FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(new Paragraph("                                                          REPORTE DE ENTRADAS VS SALIDAS"));
                        pdfDoc.Add(new Paragraph("PERIODO: " + monthCalendar1.SelectionStart + " - " + monthCalendar2.SelectionStart));
                        pdfDoc.Add(Chunk.NEWLINE);
                        pdfDoc.Add(Chunk.NEWLINE);
                        pdfDoc.Add(new Paragraph("ENTRADAS"));
                        pdfDoc.Add(Chunk.NEWLINE);
                        pdfDoc.Add(pdfTable);
                        String TotalEntradas = abc.MostrarDatosReporte(8, inicio: monthCalendar1.SelectionStart, fin: monthCalendar2.SelectionStart);
                        pdfDoc.Add(new Paragraph("TOTAL ENTRADAS: " + TotalEntradas + " PESOS"));
                        dataGridView1.DataSource = abc.MostrarReporte(7, inicio: monthCalendar1.SelectionStart, fin: monthCalendar2.SelectionStart);
                        PdfPTable pdfTable1 = new PdfPTable(dataGridView1.Columns.Count);
                        pdfTable1.DefaultCell.Padding = 3;
                        pdfTable1.WidthPercentage = 100;
                        pdfTable1.HorizontalAlignment = Element.ALIGN_LEFT;
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                            pdfTable1.AddCell(cell);
                        }

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                pdfTable1.AddCell(cell.Value.ToString());
                            }
                        }
                        pdfDoc.Add(Chunk.NEWLINE);
                        pdfDoc.Add(new Paragraph("SALIDAS"));
                        pdfDoc.Add(Chunk.NEWLINE);
                        pdfDoc.Add(pdfTable1);
                        String TotalSalidas = abc.MostrarDatosReporte(9, inicio: monthCalendar1.SelectionStart, fin: monthCalendar2.SelectionStart);
                        pdfDoc.Add(new Paragraph("TOTAL SALIDAS: " + TotalSalidas+" PESOS"));
                        pdfDoc.Close();
                        stream.Close();
                    }
                }
                MessageBox.Show("Se ha generado el PDF :)");
            }
        }
    }
}
