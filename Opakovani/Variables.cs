namespace Opakovani.Variables
{
	// modifikátor přístupu public - třída je dostupná odkudkoliv
	public class Variables
	{
		// konstruktor - zavolá se vždy při inicializaci objektu třídy Variables
		public Variables()
		{

		}

		public void WorkWithVariables()
		{
			int cislo; // deklarace promenne
            cislo = 10; // inicializace promenne

			uint cislo5 = 2121;

			int cislo1 = 10;
			int cislo2 = 20;
			int sum = cislo1 + cislo2; // scitani
			int sum2 = cislo1 - cislo2; // odcitani
			int sum3 = cislo1 / cislo2; // nasobeni
			int sum4 = cislo1 * cislo2; // deleni

			cislo1 += cislo2; // zkraceny zapis

			int preIncrement = 0;
			int postIncrement = 0;

			++preIncrement;
			postIncrement++;
			--preIncrement;
			postIncrement--;

			int result1 = ++preIncrement;
			int result2 = postIncrement++;
			int result3 = 10 + postIncrement++; // prvni se vyhodnoti vyraz a pak zvysi o 1
		}

		public void BooleanExpressions()
		{
			bool isAtWork = true;
			bool isAvailable = false;
			bool isWorking = isAtWork == true && isAvailable == true; // false
			bool isSomething = isAtWork || isAvailable; // true

			bool lessThan = 10 < 20; // true
			bool greatherThan = 20 > 10; // true
			bool lessOrEqual = 10 <= 20; // true
			bool greatherOrEqual = 10 >= 20; // false
		}

		public void ConvertingTypes()
		{
			short number1 = 10;
			int number2 = number1; // implicitni pretypovani
			var number3 = (int)number1;  // explicitni pretypovani

			int number4 = 10;
			short number5 = Convert.ToInt16(number4); // pretypovani s tridou Convert
		}

		public void WorkWithStrings()
		{
			char aChar = 'a'; // nejmensi jednotka retezcu
			string text = "text"; // string je na pozadi pole charu, my vsak muzeme pracovat komfortne takto bez pole
			string emptyText = "";
			string emptyText2 = String.Empty;

			// Formatovani
			Console.WriteLine($"Formatovany text: {text}");
			Console.WriteLine(text + " ... " + string.Empty);
			Console.WriteLine(string.Format("Formatovany text: {0}{1}", text, emptyText));
		}

		public void InputOutput()
		{
			string input = Console.ReadLine(); // nacte vstup z konzole
			int inputNumber = int.Parse(input);
		}

		public void Scopes()
		{
			int variable = 10;
			int hiddenVariable; // nemohu deklarovat v podmince, jinak k ni nemohu pristoupit na konci metody

			if (variable >= 10)
			{
				hiddenVariable = 25;
			}

			// Console.WriteLine(hiddenVariable);
		}

		public void Conditions()
		{
			int i = 0;

			if (i > 10)
			{
				Console.WriteLine("Vetsi nez 10");
			}
			else if (i < 10 && i > 0)
			{
				Console.WriteLine("vetsi jak 0, mensi nez 10");
			}
			else
			{
				Console.WriteLine("mensi nez 10 ");
			}
		}

		public void Cycles()
		{
			// deklarace, podminka, akce(inkrementace)
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(i);
			}

			int j = 0;

			while(j < 10)
			{
				Console.WriteLine(j);
				j++;
			}

			int k = 0;
			// provede se prvni iterace a pak se vyhodnocuje podminka
			do
			{
				Console.WriteLine(k);
				k++;
			} while (k < 10);

			int counter = 0;
			while(true)
			{
				counter++;

				// pokud je counter < 10, tak pokracuj na dalsi iteraci
				if (counter < 10) continue;

				// vypise 10
				Console.WriteLine(counter);

				// pokud je counter 10, tak prerus cyklus
				if (counter == 10) break;
			}

			// nekonecny for cyklus
			for(;;)
			{
				break; // muzeme prerusit breakem
			}
		}

		public void Arrays()
		{
			// deklarace a inicializace pole
			int[] integerArray = new int[] { 1, 2, 3, 4};

			Console.WriteLine(integerArray[0]);

			for(int i = 0; i < integerArray.Length; i++)
			{
				Console.WriteLine(integerArray[i]);
			}

			foreach(int element in integerArray)
			{
				Console.WriteLine(element);
			}

			// pole je referencni datovy typ, takhle pouze predame referenci, ale nezkopirujeme
			int[] newArray = integerArray;
			// po editaci se zedituje i puvodni pole prave kvuli tomu, ze ukazuje na stejne data jako pole puvodni
			newArray[0] = 10;
			Console.WriteLine(newArray[0]);
			Console.WriteLine(integerArray[0]);

			int[] clonedArray = new int[integerArray.Length];

			// rucni naklonovani pole
			for (int i = 0; i < clonedArray.Length; i++)
			{
				clonedArray[i] = integerArray[i];
 			}

			// naklonovani pomoci Array.CopyTo()
			integerArray.CopyTo(clonedArray, 0);
			Array.Copy(integerArray, clonedArray, integerArray.Length);
        }

		public void MultidimensionalArray()
		{
			// pole polí 
			int[,] multidimensionalArray = new int[2, 3]
			{
				{ 1, 2, 3 },
				{ 4, 5, 6}
			};

			// vypsani prvku multidimenzionalniho pole
			Console.WriteLine(multidimensionalArray[0,0]);

			// muzeme vypsat vsechny prvnky v poli, ale bez indexu
			foreach(int i in multidimensionalArray)
			{
				Console.WriteLine(i);
			}

			for (int k = 0; k < multidimensionalArray.GetLength(0); k++)
			{
				for(int j = 0; j < multidimensionalArray.GetLength(1); j++)
				{
					Console.WriteLine(multidimensionalArray[k, j]);
				}
			}
		}

		enum Color
		{
			Red,
			Blue
		}

		// struktura je hodnotovy datovy typ
		struct Cube
		{
			// fieldy struktury
			private double length;

			public Color color;

			// muze mit kontruktor
			public Cube(double length, Color color)
			{
				this.length = length;
				this.color = color;
			}

			// muze mit metody
			public double Content()
			{
				return Math.Pow(length, 3);
			}
		}

		public void Structures()
		{
			Cube cube = new Cube(10, Color.Red);
			Cube cube2;

			// struktura je hodnotovy datovy typ, dojde k prekopirovani hodnot, nikoliv  k predani reference
			cube2 = cube;
			cube2.color = Color.Blue;

			Console.WriteLine(cube2.color);
			Console.WriteLine(cube.color);
		}

		public void ReferenceAddNumber(ref int number)
		{
			number += 10;
		}
	}
}
