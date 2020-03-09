using System;

namespace Domain
{
    public class SavingAccount
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public decimal Balance { get; set; }

        public SavingAccount(string number, string name, string city, decimal balance)
        {
            Number = number;
            Name = name;
            City = city;
            Balance = balance;
        }

        public string Consign(string city, decimal value)
        {
            if (value <= 0)
            {
                return "El valor a consignar es incorrecto";
            }
            else if (Balance == 0 && value < 50000)
            {
                return "El valor minimo de la primera consignacion debe ser de $50.000. Su nuevo saldo es 0 pesos";
            }
            else if (!City.Equals(city))
            {
                value -= 10000;
                Balance += value;
                return $"Su nuevo saldo es de ${Balance} pesos m/c";
            }
            else
            {
                Balance += value;
                return $"Su nuevo saldo es de ${Balance} pesos m/c";
            }
        }
    }
}
