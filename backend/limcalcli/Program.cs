using System;

class Program {
	static List<string> SplitToMonomials(string input) {
		List<string> monomials = new List<string>(); // List to store monomials
		int startIndex = 0; 
		
		for (int i = 0; i < input.Length; i++)
		{
			if (input[i] == '+' || input[i] == '-') // Check for '+' or '-' character
			{
				string segment = input.Substring(startIndex, i - startIndex); // Extract monomial
				monomials.Add(segment); // Add monomial to the list
				if (input[i] == '+') {
					startIndex = i + 1; // Update start index for next segment
				}
				else {
					startIndex = i; // Update start index for next segment
				}
			}
		}

		// Add last monomial after the last '+' or '-' character (if any)
		string lastSegment = input.Substring(startIndex);
		monomials.Add(lastSegment);

		return monomials; // Return the list of monomials
	}

	static int findHighestPower(List<string> input) {
		// Iterate over the input
		int highestPower = 1;
		foreach (string str in input) {
			// Find the '^' in the string
			int index = str.IndexOf('^');
			
			// If we found a '^'
			if (index != -1) {
				// Store the currentPower as a string to compare it to the highestPower
				string currentPowerStr = str.Substring(index + 1);
				int currentPower = int.Parse(currentPowerStr);
				if (currentPower > highestPower) {
					highestPower = currentPower;
				}
			}
		}
		return highestPower;
	}


    static void Main(string[] args) {
		// Deny user if there are less or more than 2 strings as an input
        if(args.Length != 2) {
            Console.WriteLine("Please provide 2 strings as arguments.");
            return;
        }
        string numerator = args[0];
        string denominator = args[1];

		// Divide numerator to segments (monomials)
		List<string> numeratorSplit = SplitToMonomials(numerator);
		List<string> denominatorSplit = SplitToMonomials(denominator);
		

		// Find the highest power in the lists
		int highestPower = findHighestPower(numeratorSplit);
		int highestPowerDenominator = findHighestPower(denominatorSplit);
		if (highestPowerDenominator > highestPower) {
			highestPower = highestPowerDenominator;
		}

		Console.WriteLine(highestPower);
    }
}

