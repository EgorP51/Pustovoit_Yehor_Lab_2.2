using Lab_2._2;
using Newtonsoft.Json;


Polynomial pol2 = new Polynomial(2, new int[] {8,-4,3});
Polynomial pol1 = new Polynomial(2, new int[] { 7, 2, 5 });

pol1.ShowPolinomial();
pol2.ShowPolinomial();

Polynomial pol3 = Polynomial.Multiplication(pol1, pol2);
Polynomial pol4 = Polynomial.Subtraction(pol2, pol1);
Polynomial pol5 = Polynomial.Addition(pol1, pol2);

Console.WriteLine("* * *");

pol5.ShowPolinomial();
pol4.ShowPolinomial();

Console.WriteLine("* * *");

pol3.ShowPolinomial();

Console.WriteLine("* * *");

pol1.VariableDependence(3);


//string filePath = @"C:\Users\Egor\OneDrive\Рабочий стол\MyJson.json";
