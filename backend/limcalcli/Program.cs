using System;

class Program {
	// Splits a string to a list of monomials, using - or + as separators. Omits +, while leaving -
	static List<string> SplitToMonomials(string input) {
		List<string> monomials = new List<string>(); // List to store monomials
		int startIndex = 0; 
		
		for (int i = 1; i < input.Length; i++)
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


	// Finds the highest number after ^, and returns it
	static int findHighestPower(List<string> input) {
		// Iterate over the input
		int highestPower = 1;
		foreach (string str in input) {
			// Find the '^' in the string
			int index = str.IndexOf('^');
			
			// If we found it
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
	
	// 1. Find the powers which match the highest one exactly
	// 2. Turn those items from "3x^5" into "+3"
	// 3. Turn all other items in 0
	static string finalizeDivision(List<string> input, int inputPow) {
		// Create a list to hold the output strings
		List<string> outputStrings = new List<string>();

		// Loop trough each string in the input list
		foreach (string str in input) {
			// Find the index of the ^ symbol in the string
			int index = str.IndexOf('^');

			// If it's found
			if (index != -1) {
				// Extract the substring after the ^ symbol
				string numString = str.Substring(index + 1);

				// Parse the substring as int
				int currentPower = int.Parse(numString);

				if (currentPower == inputPow) {
					if (str.StartsWith("-")) {
						outputStrings.Add(str.Substring(0, index - 1));
					}
					else {
						outputStrings.Add("+" + str.Substring(0, index - 1));
					}

					// Go to the next string
					continue;
				}
			}

			// If there is no ^ symbol or the power doesn't match, add -0 or +0 to the output list
			if (str.StartsWith("-")) {
				outputStrings.Add("-0");
			}
			else {
				outputStrings.Add("+0");
			}
		}

		// Turn the list of strings into one string
		string separator = "";
		string output = string.Join(separator, outputStrings);

		return output;
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
		
		// !!! IMPORTANT !!!
		// THIS IS THE FIRST OUTPUT OF THE BACKEND, WILL BE USED TO PROCESS THE SOLVING STEPS BY FRONTEND
		Console.WriteLine(highestPower);
		Console.WriteLine("");

		// 1. Find the powers which match the highest one exactly
		// 2. Turn those items from "3x^5" into "3"
		// 3. Turn all other items in 0
		string numeratorDiv = finalizeDivision(numeratorSplit, highestPower);
		string denominatorDiv = finalizeDivision(denominatorSplit, highestPower);

		Console.WriteLine(numeratorDiv);
		Console.WriteLine(denominatorDiv);
    }
}

