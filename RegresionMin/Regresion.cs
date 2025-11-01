using System;
using System.Collections.Generic;
using System.Text;

namespace RegresionMinCuadUI
{
 public static class Regresion
 {
 /// <summary>
 /// Implementación de regresión polinomial y RLM según enunciado.
 /// </summary>
 
 /// <summary>
 /// RegresionPolinomial(puntos, m, n) -> devuelve a[0..n]
 /// puntos: lista de (x,y) pares
 /// m: número de puntos
 /// n: grado del polinomio
 /// </summary>
 public static double[] RegresionPolinomial(List<(double x,double y)> puntos, int m, int n)
 {
 // crear sumatorias
 double[] sx = new double[2*n+1];
 double[] sxy = new double[n+1];
 CreaSumatorias(puntos,m,sx,sxy,n);
 // crear matriz ms (n+1)x(n+2)
 double[,] ms = new double[n+1, n+2];
 CreaMatrizSumatorias(sx,sxy,ms,n);
 // resolver con gauss-jordan
 double[] a = new double[n+1];
 GaussJordan(ms,a,n+1);
 return a;
 }
 
 /// <summary>
 /// CreaSumatorias(puntos, m, sx, sxy, n): sx[0]=m, sx[i]=sum x^i para i=1..2n; sxy[i]=sum y*x^i para i=0..n.
 /// </summary>
 public static void CreaSumatorias(List<(double x,double y)> puntos, int m, double[] sx, double[] sxy, int n)
 {
 for(int i=0;i<=2*n;i++) sx[i]=0.0;
 for(int i=0;i<=n;i++) sxy[i]=0.0;
 sx[0]=m;
 for(int i=0;i<m;i++){
 double x = puntos[i].x;
 double y = puntos[i].y;
 double xp =1.0;
 for(int j=1;j<=2*n;j++){
 xp *= x;
 sx[j]+=xp;
 }
 // sxy
 xp =1.0;
 for(int j=0;j<=n;j++){
 sxy[j]+= y * xp;
 xp *= x;
 }
 }
 }
 
 /// <summary>
 /// CreaMatrizSumatorias(sx, sxy, ms, n): ms[i,j]=sx[i+j], ms[i,n+1]=sxy[i] con ms de tamaño (n+1)x(n+2).
 /// </summary>
 public static void CreaMatrizSumatorias(double[] sx, double[] sxy, double[,] ms, int n)
 {
 for(int i=0;i<=n;i++){
 for(int j=0;j<=n;j++){
 ms[i,j]= sx[i+j];
 }
 ms[i,n+1]= sxy[i];
 }
 }
 
 /// <summary>
 /// GaussJordan con pivoteo parcial. a es la matriz aumentada con 'rows' filas y cols=rows+1
 /// Devuelve solución en x (tamaño rows)
 /// </summary>
 public static void GaussJordan(double[,] a, double[] x, int rows)
 {
 int cols = rows+1;
 for(int i=0;i<rows;i++){
 Pivotea(a,i,rows);
 double piv = a[i,i];
 if(Math.Abs(piv) <1e-12) throw new Exception("Matriz singular o pivote nulo");
 // normalize row i
 for(int j=0;j<cols;j++) a[i,j] /= piv;
 // eliminate other rows
 for(int k=0;k<rows;k++){
 if(k==i) continue;
 double factor = a[k,i];
 for(int j=0;j<cols;j++) a[k,j] -= factor * a[i,j];
 }
 }
 // solution
 for(int i=0;i<rows;i++) x[i]= a[i,cols-1];
 }
 
 /// <summary>
 /// Pivotea(a,i,n) -> intercambia la fila i con fila que tenga mayor valor absoluto en columna i
 /// </summary>
 public static void Pivotea(double[,] a, int i, int n)
 {
 int cols = n+1;
 int maxRow = i;
 double maxVal = Math.Abs(a[i,i]);
 for(int r=i+1;r<n;r++){
 double val = Math.Abs(a[r,i]);
 if(val>maxVal){ maxVal=val; maxRow=r; }
 }
 if(maxRow!=i){
 for(int c=0;c<cols;c++){
 double tmp = a[i,c]; a[i,c]=a[maxRow,c]; a[maxRow,c]=tmp;
 }
 }
 }
 
 /// <summary>
 /// RegresionLinealMultiple(puntos, m, n): ajusta y = a0 + a1*x1 + ... + an*xn.
 /// puntos: lista de arrays double[] con n variables y la última posición es y
 /// </summary>
 public static double[] RegresionLinealMultiple(List<double[]> puntos, int m, int n)
 {
 // construir matriz ms (n+1)x(n+2)
 double[,] ms = new double[n+1, n+2];
 CreaMatrizSumatoriasRLM(puntos, m, ms, n);
 double[] a = new double[n+1];
 GaussJordan(ms,a,n+1);
 return a;
 }
 
 /// <summary>
 /// CreaMatrizSumatoriasRLM(puntos, m, ms, n): construir matriz ampliada (n+1)x(n+2) usando sumatorias (x^0 =1, etc.).
 /// ms[i,j] = sum x_k^(i+j) pero en RLM se usa sum x_i * x_j entre variables; implementamos según pseudocódigo para regresión múltiple.
 /// </summary>
 public static void CreaMatrizSumatoriasRLM(List<double[]> puntos, int m, double[,] ms, int n)
 {
 // We'll build ms where indices0..n correspond to a0..an, with x0=1
 // ms[i,j] = sum over k of (x_k_i * x_k_j) where x_k_0 =1 and for j=n+1 column is sum y * x_i
 for(int i=0;i<=n;i++){
 for(int j=0;j<=n;j++){
 double sum=0.0;
 for(int k=0;k<m;k++){
 double xi = (i==0) ?1.0 : puntos[k][i-1];
 double xj = (j==0) ?1.0 : puntos[k][j-1];
 sum += xi * xj;
 }
 ms[i,j]=sum;
 }
 double rhs=0.0;
 for(int k=0;k<m;k++){
 double xi = (i==0) ?1.0 : puntos[k][i-1];
 double y = puntos[k][n];
 rhs += xi * y;
 }
 ms[i,n+1]=rhs;
 }
 }
 
 /// <summary>
 /// Formato de número en F6
 /// </summary>
 public static string F6(double v) => v.ToString("F6");
 }
}
