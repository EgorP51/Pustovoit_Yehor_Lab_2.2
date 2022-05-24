using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace Lab_2._2
{
    class Polynomial
    {
        public int polinomDegree { get; set; }
        public int[] coefficients { get; set; }


        public Polynomial(int polinomDegree,int[] coefficients)
        {
            this.polinomDegree = polinomDegree;
            this.coefficients = coefficients;
        }

        public Polynomial()
        {

        }
        public void VariableDependence(int variable)
        {
            double sum = 0;
            int degree = polinomDegree;

            for (int i = 0; i < coefficients.Length; i++)
            {
                sum += coefficients[i] * Math.Pow(variable, degree);
                degree--;
            }
            Console.WriteLine($"The value of the polynomial with a variable x = {variable} is {sum}");
        }

        public static Polynomial Multiplication(Polynomial pol1, Polynomial pol2)
        {
            int[] temp = new int[pol1.polinomDegree + pol2.polinomDegree + 1];

            for (int i = 0; i < pol1.coefficients.Length; ++i)
            {
                for (int j = 0; j < pol2.coefficients.Length; ++j)
                {
                    temp[i + j] += pol1.coefficients[i] * pol2.coefficients[j];
                }
            }

            return new Polynomial(temp.Length - 1, temp);
        }
        
        public static Polynomial Addition(Polynomial pol1, Polynomial pol2)
        {
            int a = pol1.polinomDegree > pol2.polinomDegree ? pol1.polinomDegree + 1 : pol2.polinomDegree + 1;
            int[] coefficient1 = new int[a];
            int[] coefficient2 = new int[a];
            int[] temp = new int[a];

            Array.Reverse(pol1.coefficients);
            Array.Reverse(pol2.coefficients);

            for (int i = 0; i < pol1.coefficients.Length; i++)
            {
                coefficient1[i] = pol1.coefficients[i];
            }
            for (int i = 0; i < pol2.coefficients.Length; i++)
            {
                coefficient2[i] = pol2.coefficients[i];
            }

            Array.Reverse(coefficient1);
            Array.Reverse(coefficient2);

            for (int i = 0; i < a; i++)
            {
                temp[i] = coefficient1[i] + coefficient2[i];
            }

            Array.Reverse(pol1.coefficients);
            Array.Reverse(pol2.coefficients);

            return new Polynomial(a - 1, temp);
        }

        public static Polynomial Subtraction(Polynomial pol1, Polynomial pol2)
        {
            int a = pol1.polinomDegree > pol2.polinomDegree ? pol1.polinomDegree + 1 : pol2.polinomDegree + 1;
            int[] coefficient1 = new int[a];
            int[] coefficient2 = new int[a];    
            int[] temp = new int[a];

            Array.Reverse(pol1.coefficients);
            Array.Reverse(pol2.coefficients);

            for (int i = 0; i < pol1.coefficients.Length; i++)
            {
                coefficient1[i] = pol1.coefficients[i];
            }
            for (int i = 0; i < pol2.coefficients.Length; i++)
            {
                coefficient2[i] = pol2.coefficients[i];
            }

            Array.Reverse(coefficient1);
            Array.Reverse(coefficient2);

            for (int i = 0; i < a; i++)
            {
                temp[i] = coefficient1[i] - coefficient2[i];
            }

            Array.Reverse(pol1.coefficients);
            Array.Reverse(pol2.coefficients);

            return new Polynomial(a - 1, temp);
        }

        public void ShowPolinomial()
        {
            string polinom = "";
            int degree = polinomDegree;
            string sign;
            string lastPiece;

            for (int i = 0; i <coefficients.Length; i++)
            {
                sign = coefficients[i] > 0 && i>0 || coefficients[i] == 0  ? "+" : "";
                lastPiece = i != coefficients.Length - 1 ? "x"+"^" + degree.ToString() : "";

                polinom += sign + coefficients[i].ToString() + lastPiece;
                degree--;
            }

            Console.WriteLine(polinom);
        }

        public static void Serialize(Polynomial polinom, string filePath)
        {
            string jsonSerialize = JsonConvert.SerializeObject(polinom);
            File.WriteAllText(filePath, jsonSerialize);

        }
        public static Polynomial Deserialize(string filePath)
        {
            string jsonDeserialize = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Polynomial>(jsonDeserialize);
        }
    }
}

