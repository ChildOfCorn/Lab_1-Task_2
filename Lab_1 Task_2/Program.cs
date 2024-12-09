using System;

class Converter
{
	private double usdRate;
	private double eurRate;
	private double plnRate;

	public Converter(double usd, double eur, double pln)
	{
		usdRate = usd;
		eurRate = eur;
		plnRate = pln;
	}

	public double ConvertFromUAH(double amount, string currency)
	{
		return currency.ToLower() switch
		{
			"usd" => amount / usdRate,
			"eur" => amount / eurRate,
			"pln" => amount / plnRate,
			_ => throw new ArgumentException("Incorrect currency"),
		};
	}

	public double ConvertToUAH(double amount, string currency)
	{
		return currency.ToLower() switch
		{
			"usd" => amount * usdRate,
			"eur" => amount * eurRate,
			"pln" => amount * plnRate,
			_ => throw new ArgumentException("Incorrect currency"),
		};
	}
}

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Enter the currency rate (USD, EUR, PLN) against the UAH:");
		Console.Write("USD: ");
		double usdRate = double.Parse(Console.ReadLine());
		Console.Write("EUR: ");
		double eurRate = double.Parse(Console.ReadLine());
		Console.Write("PLN: ");
		double plnRate = double.Parse(Console.ReadLine());

		Converter converter = new Converter(usdRate, eurRate, plnRate);

		while (true)
		{
			Console.WriteLine("\nChoose the type of operation:");
			Console.WriteLine("1. Convert from UAH to foreign currency");
			Console.WriteLine("2. Convert from foreign currency to UAH");
			Console.WriteLine("3. Exit");
			Console.Write("Your choice: ");
			int choice = int.Parse(Console.ReadLine());

			if (choice == 3) break;

			Console.Write("Enter the amount: ");
			double amount = double.Parse(Console.ReadLine());

			Console.Write("Enter the currency (USD, EUR, PLN): ");
			string currency = Console.ReadLine();

			try
			{
				if (choice == 1)
				{
					double result = converter.ConvertFromUAH(amount, currency);
					Console.WriteLine($"{amount} UAH = {result:F2} {currency.ToUpper()}");
				}
				else if (choice == 2)
				{
					double result = converter.ConvertToUAH(amount, currency);
					Console.WriteLine($"{amount} {currency.ToUpper()} = {result:F2} UAH");
				}
				else
				{
					Console.WriteLine("Incorrect choice of operation.");
				}
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
