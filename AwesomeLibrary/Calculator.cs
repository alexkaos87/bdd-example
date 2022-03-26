namespace AwesomeLibrary
{
    public class Calculator
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }

        public int Add() => FirstNumber + SecondNumber;

        public int Substract() => FirstNumber - SecondNumber;

        public int Multiply() => FirstNumber * SecondNumber;

        public double Divide() => FirstNumber / SecondNumber;
    }
}