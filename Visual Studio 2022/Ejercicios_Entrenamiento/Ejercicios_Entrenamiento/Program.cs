// 1. Escribe un programa que imprima “PASS” si la variable entera “mark”
// es mayor o igual a 50; o imprime “FAIL” en otro caso. 
int mark = 40;

if (mark > 50){
    Console.WriteLine("PASS");
}
else{
    Console.WriteLine("FAIL");
}
Console.WriteLine();


// 2. Escribe un programa que imprima “Número Impar” si la variable
// entera “numero” es impar o par si la variable es par.

int numero = 11;

if (numero%2 == 0){
    Console.WriteLine("Número Par");
}
else{
    Console.WriteLine("Número Impar");
}
Console.WriteLine();


// 3. Escribe un programa que calcule la suma de 1,2,3,…,
// a un número especificado como cota superior ( por ejemplo . 100).
// Además  calcula y muestra la media.

int cota = 100;
int suma = 0;
int media = 0;

for(int i = 0; i <= cota; i++) {
    suma = suma + (i*i);
}
media = suma / cota;
Console.WriteLine("La suma es: " + suma);
Console.WriteLine("La media es: " + media);
Console.WriteLine();


int num = 0;
int res = 0;
int med = 0;
while (num <= cota){
    res = res + (num*num);
    num++;
}
med = res / cota;
Console.WriteLine("La suma es: " + res);
Console.WriteLine("La media es: " +  med);
Console.WriteLine();


int n = 0;
int sum = 0;
int m = 0;
do
{
    sum = sum + (n * n);
    n++;
} while (n <= cota);
m = sum / cota;
Console.WriteLine("La suma es: " + sum);
Console.WriteLine("La media es: " + m);
Console.WriteLine();



// 4. Escribe un programa que calculo la suma de las series armónicas,
// como se muestra en la figura de abajo, donde n=50000. El programa
// podrá cualquier la suma de izquierda a derecha como también de
// derecha a izquierda. Obten la diferencia entre las dos sumas y explica
// la diferencia de qué suma es más precisa

int inicio = 1;
double harmonico = 0;
n = 10;
while (inicio <= n){
    harmonico = harmonico + (1.0 / inicio);
    inicio++;
}
Console.WriteLine("Resultado armonico de " + n + " : " + harmonico);
Console.WriteLine();

// 8. Escribe un programa cuyo usuario pueda introducir el radio
// ( tipo de dato double) y que calcule el volumen y el Surface
// del área de una esfera.
// La salida se muestra similar a la siguiente:
const double Math_PI = 3.1416;
Console.Write("Introduce el radio: "); 
string leido = Console.ReadLine();
double radio = Convert.ToDouble(leido);
double volumen = 0.0;
double superficie = 0.0;

volumen = (4 / 3) * Math_PI * (radio * radio * radio);
superficie = (4 / 3) * Math_PI * (radio * radio);


Console.WriteLine($"El volumen es: " + volumen);
Console.WriteLine("La superficie es: " + superficie);
Console.WriteLine();
