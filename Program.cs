class Program
{
    static void Main(string[] args)
    {   
        // menu 
        while (true)
        {
            Console.WriteLine("\nChoose a task to run:");
            Console.WriteLine("1 - Task 1: ");
            Console.WriteLine("2 - Task 2: ");
            Console.WriteLine("3 - Task 3: ");
            Console.WriteLine("4 - Task 4: ");
            Console.WriteLine("5 - Task 5: ");
            Console.WriteLine("6 - Task 6: ");
            Console.WriteLine("7 - Task 7: ");
            Console.WriteLine("8 - Task 8: ");
            Console.WriteLine("9 - Task 9: ");
            Console.WriteLine("0 - Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            if (choice == "0")
                break;

            switch (choice)
            {
                case "1":
                    RunTask1();
                    break;
                case "2":
                    RunTask2();
                    break;
                case "3":
                    RunTask3();
                    break;
                case "4":
                    RunTask4();
                    break;
                case "5":
                    RunTask5();
                    break;
                case "6":
                    RunTask6();
                    break;
                case "7":
                    RunTask7();
                    break;
                case "8":
                    RunTask8(args);
                    break;
                case "9":
                    RunTask9(args);
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }

    // --- tasks  ---

    // task 1
    static void RunTask1()
    {
        Console.WriteLine("\nTask 1:");
        int[] A = new int[5];
        double[,] B = new double[3, 4];
        Random rand = new Random();

        Console.WriteLine("Enter 5 numbers for array A:");
        for (int i = 0; i < A.Length; i++)
        {
            A[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Array A:");
        foreach (var item in A)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        Console.WriteLine("Array B:");
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                B[i, j] = rand.NextDouble() * 100;
                Console.Write($"{B[i, j]:F2}\t");
            }
            Console.WriteLine();
        }

        double max = A[0];
        double min = A[0];
        double sum = 0;
        double product = 1;
        int evenSumA = 0;
        double oddColumnSumB = 0;

        foreach (var item in A)
        {
            if (item > max) max = item;
            if (item < min) min = item;
            sum += item;
            product *= item;
            if (item % 2 == 0) evenSumA += item;
        }

        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (B[i, j] > max) max = B[i, j];
                if (B[i, j] < min) min = B[i, j];
                sum += B[i, j];
                product *= B[i, j];
                if (j % 2 == 1) oddColumnSumB += B[i, j];
            }
        }

        Console.WriteLine($"Overall Max: {max}");
        Console.WriteLine($"Overall Min: {min}");
        Console.WriteLine($"Overall Sum: {sum}");
        Console.WriteLine($"Overall Product: {product}");
        Console.WriteLine($"Sum of even elements in A: {evenSumA}");
        Console.WriteLine($"Sum of odd columns in B: {oddColumnSumB}");
    }

    // task 2
    static void RunTask2()
    {
        Console.WriteLine("\nTask 2:");
        Random rand = new Random();
        int[,] array2 = new int[5, 5];
        int minVal = 100, maxVal = -100;
        int minIndex = 0, maxIndex = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                array2[i, j] = rand.Next(-100, 101);
                Console.Write($"{array2[i, j]}\t");

                int index = i * 5 + j;
                if (array2[i, j] < minVal)
                {
                    minVal = array2[i, j];
                    minIndex = index;
                }
                if (array2[i, j] > maxVal)
                {
                    maxVal = array2[i, j];
                    maxIndex = index;
                }
            }
            Console.WriteLine();
        }

        if (minIndex > maxIndex)
        {
            int temp = minIndex;
            minIndex = maxIndex;
            maxIndex = temp;
        }

        int totalSum = 0;
        for (int i = minIndex + 1; i < maxIndex; i++)
        {
            totalSum += array2[i / 5, i % 5];
        }
        Console.WriteLine($"Sum between min and max elements: {totalSum}");
    }

    // task 3
    static void RunTask3()
    {
        Console.WriteLine("\nTask 3:");
        Console.WriteLine("Enter a string to encrypt:");
        string input = Console.ReadLine();
        Console.WriteLine("Enter shift:");
        int shift = int.Parse(Console.ReadLine());

        string encrypted = CaesarCipher(input, shift);
        string decrypted = CaesarCipher(encrypted, -shift);

        Console.WriteLine($"Encrypted: {encrypted}");
        Console.WriteLine($"Decrypted: {decrypted}");
    }

    // task 4
    static void RunTask4()
    {
        Console.WriteLine("\nTask 4:");
        int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
        int[,] matrix2 = { { 5, 6 }, { 7, 8 } };

        Console.WriteLine("Matrix1 multiplied by 2:");
        PrintMatrix(MultiplyMatrixByNumber(matrix1, 2));

        Console.WriteLine("Matrix1 + Matrix2:");
        PrintMatrix(AddMatrices(matrix1, matrix2));

        Console.WriteLine("Matrix1 * Matrix2:");
        PrintMatrix(MultiplyMatrices(matrix1, matrix2));
    }

    // task 5
    static void RunTask5()
    {
        Console.WriteLine("\nTask 5:");
        Console.WriteLine("Enter an expression (+ or - only):");
        string expression = Console.ReadLine();
        Console.WriteLine($"Result: {CalculateExpression(expression)}");
    }

    // task 6
    static void RunTask6()
    {
        Console.WriteLine("\nTask 6:");
        Console.WriteLine("Enter text:");
        string text = Console.ReadLine();
        Console.WriteLine($"Modified text:\n{CapitalizeSentences(text)}");
    }

    // task 7
    static void RunTask7()
    {
        Console.WriteLine("\nTask 7:");
        string forbiddenWord = "die";
        Console.WriteLine("Enter text:");
        string forbiddenText = Console.ReadLine();
        int replacements = 0;
        string censoredText = CensorText(forbiddenText, forbiddenWord, ref replacements);
        Console.WriteLine($"Censored text:\n{censoredText}");
        Console.WriteLine($"Number of replacements: {replacements}");
    }

    // task 8
    static void RunTask8(string[] args)
    {
        Console.WriteLine("\nTask 8:");
        if (args.Length >= 2)
        {
            string cmdInput = args[0];
            int cmdShift = int.Parse(args[1]);
            string cmdEncrypted = CaesarCipher(cmdInput, cmdShift);
            Console.WriteLine($"Command line encrypted: {cmdEncrypted}");
        }
        else
        {
            Console.WriteLine("No command line arguments for Task 8.");
        }
    }

    // task 9
    static void RunTask9(string[] args)
    {
        Console.WriteLine("\nTask 9:");
        if (args.Length >= 3)
        {
            int rows = int.Parse(args[0]);
            int cols = int.Parse(args[1]);
            int multiplier = int.Parse(args[2]);
            int[,] randomMatrix = new int[rows, cols];
            Random rand = new Random();

            Console.WriteLine("Generated matrix:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    randomMatrix[i, j] = rand.Next(1, 10);
                    Console.Write($"{randomMatrix[i, j]}\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nMatrix after multiplication:");
            PrintMatrix(MultiplyMatrixByNumber(randomMatrix, multiplier));
        }
        else
        {
            Console.WriteLine("No command line arguments for Task 9.");
        }
    }

    // --- help methods (addons) ---

    static string CaesarCipher(string input, int shift)
    {
        string result = "";
        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                result += (char)(((c - offset + shift + 26) % 26) + offset);
            }
            else
            {
                result += c;
            }
        }
        return result;
    }

    static int[,] MultiplyMatrixByNumber(int[,] matrix, int number)
    {
        int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];
        for (int i = 0; i < result.GetLength(0); i++)
            for (int j = 0; j < result.GetLength(1); j++)
                result[i, j] = matrix[i, j] * number;
        return result;
    }

    static int[,] AddMatrices(int[,] m1, int[,] m2)
    {
        int[,] result = new int[m1.GetLength(0), m1.GetLength(1)];
        for (int i = 0; i < result.GetLength(0); i++)
            for (int j = 0; j < result.GetLength(1); j++)
                result[i, j] = m1[i, j] + m2[i, j];
        return result;
    }

    static int[,] MultiplyMatrices(int[,] m1, int[,] m2)
    {
        int[,] result = new int[m1.GetLength(0), m2.GetLength(1)];
        for (int i = 0; i < m1.GetLength(0); i++)
            for (int j = 0; j < m2.GetLength(1); j++)
                for (int k = 0; k < m1.GetLength(1); k++)
                    result[i, j] += m1[i, k] * m2[k, j];
        return result;
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j] + "\t");
            Console.WriteLine();
        }
    }

    static int CalculateExpression(string expr)
    {
        int result = 0;
        string number = "";
        char sign = '+';

        foreach (char c in expr)
        {
            if (char.IsDigit(c))
            {
                number += c;
            }
            else if (c == '+' || c == '-')
            {
                result = sign == '+' ? result + int.Parse(number) : result - int.Parse(number);
                sign = c;
                number = "";
            }
        }
        if (number != "")
        {
            result = sign == '+' ? result + int.Parse(number) : result - int.Parse(number);
        }
        return result;
    }

    static string CapitalizeSentences(string text)
    {
        string[] sentences = text.Split(new[] { ". " }, StringSplitOptions.None);
        for (int i = 0; i < sentences.Length; i++)
        {
            if (sentences[i].Length > 0)
            {
                sentences[i] = char.ToUpper(sentences[i][0]) + sentences[i].Substring(1);
            }
        }
        return string.Join(". ", sentences);
    }

    static string CensorText(string text, string forbiddenWord, ref int replacements)
    {
        string[] words = text.Split(' ', '\n', '\r', ',', '.', ';', ':');
        foreach (var word in words)
        {
            if (word.ToLower() == forbiddenWord.ToLower())
            {
                text = text.Replace(word, new string('*', forbiddenWord.Length));
                replacements++;
            }
        }
        return text;
    }
}
