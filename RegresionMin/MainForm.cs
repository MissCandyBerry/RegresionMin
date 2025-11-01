using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RegresionMinCuadUI
{
 public partial class MainForm : Form
 {
 public MainForm()
 {
 InitializeComponent();
 SetupGridForPolynomial(1);
 }

 private void radioMode_CheckedChanged(object sender, EventArgs e)
 {
 if (radioPolinomial.Checked) SetupGridForPolynomial((int)numericDegree.Value);
 else SetupGridForRLM((int)numericDegree.Value);
 }

 private void numericDegree_ValueChanged(object sender, EventArgs e)
 {
 if (radioPolinomial.Checked) SetupGridForPolynomial((int)numericDegree.Value);
 else SetupGridForRLM((int)numericDegree.Value);
 }

 private void SetupGridForPolynomial(int degree)
 {
 // two columns x,y
 dataGridViewPoints.Columns.Clear();
 dataGridViewPoints.Columns.Add("x", "x");
 dataGridViewPoints.Columns.Add("y", "y");
 labelDegree.Text = "Grado";
 }

 private void SetupGridForRLM(int vars)
 {
 dataGridViewPoints.Columns.Clear();
 for (int i =1; i <= vars; i++) dataGridViewPoints.Columns.Add("x" + i, "x" + i);
 dataGridViewPoints.Columns.Add("y", "y");
 labelDegree.Text = "Variables";
 }

 private void buttonLoadLinea_Click(object sender, EventArgs e)
 {
 // Cargar los14 puntos exactos del enunciado
 radioPolinomial.Checked = true;
 numericDegree.Value =1;
 SetupGridForPolynomial(1);
 var xs = new double[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14 };
 var ys = new double[] {9.9,9.0,8.1,7.1,6.2,5.3,4.4,3.6,2.7,1.8,1.0, -0.7, -1.5, -2.3 };
 var datos = new List<(double, double)>();
 for (int i =0; i < xs.Length; i++) datos.Add((xs[i], ys[i]));
 LoadPointsIntoGrid(datos);
 }

 private void buttonLoadParabola_Click(object sender, EventArgs e)
 {
 // Cargar los12 puntos exactos del enunciado
 radioPolinomial.Checked = true;
 numericDegree.Value =2;
 SetupGridForPolynomial(2);
 var xs = new double[] {0,2,4,6,9,11,13,15,17,19,23,25 };
 var ys = new double[] {1.2,0.6,0.4, -0.2,0, -0.6, -0.4, -0.2, -0.4,0.2,0.4,1.2 };
 var datos = new List<(double, double)>();
 for (int i =0; i < xs.Length; i++) datos.Add((xs[i], ys[i]));
 LoadPointsIntoGrid(datos);
 }

 private void buttonLoadRLM_Click(object sender, EventArgs e)
 {
 // Cargar los8 puntos exactos del enunciado para RLM (x1,x2,y)
 radioRLM.Checked = true;
 numericDegree.Value =2;
 SetupGridForRLM(2);
 var datos = new List<double[]>
 {
 new double[]{1,1,18.0},
 new double[]{1,2,12.8},
 new double[]{2,1,25.7},
 new double[]{2,2,20.6},
 new double[]{3,1,35.0},
 new double[]{3,2,29.8},
 new double[]{4,1,45.5},
 new double[]{4,2,40.3}
 };
 LoadPointsIntoGridRLM(datos);
 }

 private void LoadPointsIntoGrid(List<(double, double)> pts)
 {
 dataGridViewPoints.Rows.Clear();
 foreach (var p in pts)
 {
 dataGridViewPoints.Rows.Add(p.Item1.ToString("F6"), p.Item2.ToString("F6"));
 }
 }

 private void LoadPointsIntoGridRLM(List<double[]> pts)
 {
 dataGridViewPoints.Rows.Clear();
 foreach (var p in pts)
 {
 var idx = dataGridViewPoints.Rows.Add();
 var row = dataGridViewPoints.Rows[idx];
 for (int i =0; i < p.Length; i++) row.Cells[i].Value = p[i].ToString("F6");
 }
 }

 private void buttonCalculate_Click(object sender, EventArgs e)
 {
 try
 {
 if (radioPolinomial.Checked)
 {
 int degree = (int)numericDegree.Value;
 var pts = ReadPointsPolynomial();

 // calcular y mostrar sumatorias y matriz ampliada antes de resolver
 double[] sx = new double[2 * degree +1];
 double[] sxy = new double[degree +1];
 Regresion.CreaSumatorias(pts, pts.Count, sx, sxy, degree);

 var sb = new System.Text.StringBuilder();
 sb.AppendLine("Puntos:");
 foreach (var p in pts) sb.AppendLine($"x={p.x:F6}, y={p.y:F6}");
 sb.AppendLine();

 sb.AppendLine("Sumatorias sx (i=0..2n):");
 for (int i =0; i < sx.Length; i++) sb.AppendLine($"sx[{i}] = {sx[i]:F6}");
 sb.AppendLine();

 sb.AppendLine("Sumatorias sxy (i=0..n):");
 for (int i =0; i < sxy.Length; i++) sb.AppendLine($"sxy[{i}] = {sxy[i]:F6}");
 sb.AppendLine();

 double[,] ms = new double[degree +1, degree +2];
 Regresion.CreaMatrizSumatorias(sx, sxy, ms, degree);

 sb.AppendLine("Matriz ampliada (ms):");
 for (int i =0; i <= degree; i++)
 {
 var row = new List<string>();
 for (int j =0; j <= degree +1; j++)
 {
 row.Add(ms[i, j].ToString("F6"));
 }
 sb.AppendLine(string.Join("\t", row));
 }
 sb.AppendLine();

 double[] a = Regresion.RegresionPolinomial(pts, pts.Count, degree);

 sb.AppendLine("Coeficientes:");
 for (int i =0; i < a.Length; i++) sb.AppendLine($"a{i} = {a[i]:F6}");
 sb.AppendLine();
 // polinomio
 var poly = new System.Text.StringBuilder();
 poly.Append("p(x) = ");
 for (int i =0; i < a.Length; i++)
 {
 if (i >0) poly.Append(" + ");
 poly.Append($"{a[i]:F6}");
 if (i >0) poly.Append($" x^{i}");
 }
 sb.AppendLine(poly.ToString());
 textBoxOutput.Text = sb.ToString();
 }
 else
 {
 int vars = (int)numericDegree.Value;
 var pts = ReadPointsRLM(vars);

 var sb = new System.Text.StringBuilder();
 sb.AppendLine("Puntos:");
 foreach (var p in pts)
 {
 var s = "";
 for (int i =0; i < vars; i++) s += $"x{i +1}={p[i]:F6}, ";
 s += $"y={p[vars]:F6}";
 sb.AppendLine(s);
 }
 sb.AppendLine();

 double[,] ms = new double[vars +1, vars +2];
 Regresion.CreaMatrizSumatoriasRLM(pts, pts.Count, ms, vars);

 sb.AppendLine("Matriz ampliada RLM (ms):");
 for (int i =0; i <= vars; i++)
 {
 var row = new List<string>();
 for (int j =0; j <= vars +1; j++) row.Add(ms[i, j].ToString("F6"));
 sb.AppendLine(string.Join("\t", row));
 }
 sb.AppendLine();

 double[] a = Regresion.RegresionLinealMultiple(pts, pts.Count, vars);

 sb.AppendLine("Coeficientes:");
 for (int i =0; i < a.Length; i++) sb.AppendLine($"a{i} = {a[i]:F6}");
 sb.AppendLine();
 var line = new System.Text.StringBuilder();
 line.Append("y = ");
 for (int i =0; i < a.Length; i++)
 {
 if (i >0) line.Append(" + ");
 line.Append($"{a[i]:F6}");
 if (i >0) line.Append($"*x{i}");
 }
 sb.AppendLine(line.ToString());
 textBoxOutput.Text = sb.ToString();
 }
 }
 catch (Exception ex)
 {
 MessageBox.Show("Error: " + ex.Message);
 }
 }

 private List<(double x, double y)> ReadPointsPolynomial()
 {
 var list = new List<(double, double)>();
 foreach (DataGridViewRow row in dataGridViewPoints.Rows)
 {
 if (row.IsNewRow) continue;
 var c0 = row.Cells[0].Value; var c1 = row.Cells[1].Value;
 if (c0 == null || c1 == null) continue;
 if (!double.TryParse(c0.ToString(), out double x)) throw new Exception("Valor x inválido");
 if (!double.TryParse(c1.ToString(), out double y)) throw new Exception("Valor y inválido");
 list.Add((x, y));
 }
 if (list.Count ==0) throw new Exception("No hay puntos ingresados");
 return list;
 }

 private List<double[]> ReadPointsRLM(int vars)
 {
 var list = new List<double[]>();
 foreach (DataGridViewRow row in dataGridViewPoints.Rows)
 {
 if (row.IsNewRow) continue;
 var arr = new double[vars +1];
 for (int i =0; i < vars +1; i++)
 {
 var v = row.Cells[i].Value;
 if (v == null) throw new Exception("Valor faltante en fila");
 if (!double.TryParse(v.ToString(), out double d)) throw new Exception("Valor inválido en RLM");
 arr[i] = d;
 }
 list.Add(arr);
 }
 if (list.Count ==0) throw new Exception("No hay puntos ingresados");
 return list;
 }
 }
}
