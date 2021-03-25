using System;
using System.Data;

namespace ConsoleCalculator
{
    class Program
    {
        static bool ExitProgram = false;        // Exit flag for menu loop.
        static bool NumberParseError = false;   // Error flag for conversion error.

        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 40);
            MainLoop();
        }

        static void MainLoop()
        {
            int MenuItem;
            do
            {
                DisplayMenu();
                MenuItem = ReadMenuItem();
                ExecuteMenuItem(MenuItem);
                NumberParseError = false;       // Reset Number error flag if it ocurred.
            }
            while (ExitProgram == false);
        }

        // ************************
        // Menu on screen
        // 
        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("           Kalkylator 1.0  By Ronny S. 2021 03");
            Console.WriteLine();
            Console.WriteLine("           0. Avsluta.");
            Console.WriteLine();
            Console.WriteLine("           1. Addition.");
            Console.WriteLine("           2. Subtraktion.");
            Console.WriteLine("           3. Division.");
            Console.WriteLine("           4. Multiplikation.");
            Console.WriteLine("           5. Roten ur.");
            Console.WriteLine("           6. Kvadratroten ur.");
            Console.WriteLine("           7. Upphöjt till.");
            Console.WriteLine();
            Console.WriteLine("           8. Formel kalkylator.");
            Console.WriteLine();
            Console.WriteLine("           Välj önskat alternativ.");
            Console.WriteLine();
            Console.Write("Ditt val: ");
        }


        // ************************
        // Read and check menu item for validity.
        // 
        static int ReadMenuItem()
        {
            string R = Console.ReadLine();
            int Nr;
            if (int.TryParse(R, out Nr) == false) return -1;            // Invalid input. Will be ignored
            return Nr;                                                  // Return valid input.
        }

        /// <summary>
        /// Execute selected menu item.
        /// </summary>
        /// <param name="Item"></param>
        static void ExecuteMenuItem(int Item)
        {
            switch (Item)
            {
                // VB autoformaterar raderna så de blir svåra att läsa.
                // Gillar C#  Lätt att snygga till.  
                case 0: { ExitProgram = true; break; }
                case 1: { Add();              break; }
                case 2: { Sub();              break; }
                case 3: { Div();              break; }
                case 4: { Mult();             break; }
                case 5: { Root();             break; }
                case 6: { SqRoot();           break; }
                case 7: { Power();            break; }
                case 8: { Advanced();         break; }
                                              
                case 9: { dummy();            break; }
                default: { dummy();           break; }
            }
        }

        /// <summary>
        /// For debug.
        /// </summary>
        static void dummy()
        {
            // For debug and development. Does noting right now...)
        }

        /// <summary>
        /// Addition
        /// </summary>
        // 2 på samma rad... Jag vet. Men coden blir så mycket lättare att läsa.  Tycker jag ;-)
        static void Add()
        {
            Head("Addition.");  
            double a = ConvertToDouble("Ange värde 1.  ");  if (NumberParseError == true) return;  
            double b = ConvertToDouble("Ange värde 2.  ");  if (NumberParseError == true) return;             

            Console.WriteLine();
            Console.WriteLine("Resultat: " + a + " + " + b + " = " + (a + b));

            Foot();
        }

        /// <summary>
        /// Substraction
        /// </summary>
        static void Sub()
        {
            Head("Substraktion.");
            double a = ConvertToDouble("Ange värde 1.  "); if (NumberParseError == true) return;  
            double b = ConvertToDouble("Ange värde 2.  "); if (NumberParseError == true) return;  

            Console.WriteLine();
            Console.WriteLine("Resultat: " + a + " - " + b + " = " + (a - b));

            Foot();
        }

        /// <summary>
        /// Division... Try 0 , 0 just for fun
        /// </summary>
        static void Div()
        {
            Head("Division.");
            double a = ConvertToDouble("Ange värde 1.  "); if (NumberParseError == true) return;  
            double b = ConvertToDouble("Ange värde 2.  "); if (NumberParseError == true) return;  

            Console.WriteLine();

            // Infinity test.
            if (a == 0 && b == 0 || b == 0) // a & b can't be zero OR only b cant be zero.
            {
                Console.WriteLine("Kan inte beräkna division med noll!");
                Console.WriteLine("Försök inte. Min lilla hjärna exploderar.");
                Console.WriteLine("Vill du försöka ändå?  Ja / Nej  ");
                string s = Console.ReadLine().ToLower();
                if (s == "j" || s == "ja")
                {
                    Boom();
                }
                
                return;
            }

            Console.WriteLine("Resultat: " + a + " / " + b + " = " + (a / b));
            Foot();
        }

        /// <summary>
        /// Multiplication
        /// </summary>
        static void Mult()
        {
            Head("Multiplication.");
            double a = ConvertToDouble("Ange värde 1.  "); if (NumberParseError == true) return;  
            double b = ConvertToDouble("Ange värde 2.  "); if (NumberParseError == true) return;  

            Console.WriteLine(); 
            Console.WriteLine("Resultat: " + a + " * " + b + " = " + (a * b)); 
            Foot();
        }

        /// <summary>
        /// Root
        /// </summary>
        // Reference.
        //https://stackoverflow.com/questions/18657508/c-sharp-find-nth-root/18657674
        static void Root()
        {
            Head("Roten ur.");
            double a = ConvertToDouble("Ange värde 1.  "); if (NumberParseError == true) return;
            int b = ConvertToInt("Ange värde 2.  "); if (NumberParseError == true) return;

            Console.WriteLine();
            Console.WriteLine("Resultat: Roten ur " + a + " av " + b + " = " + Math.Pow(a, 1.0 / b));
            Foot();
        }

        /// <summary>
        /// Square root
        /// </summary>
        static void SqRoot()
        {

            Head("Kvadratroten ur.");
            double a = ConvertToDouble("Ange värdet: "); if (NumberParseError == true) return;          

            Console.WriteLine();
            Console.WriteLine("Resultat: Kvadratroten ur " + a + " = " + Math.Sqrt(a));
            Foot();

        }

        /// <summary>
        /// Power of x
        /// </summary>
        static void Power()
        {
            Head("Upphöjt till.");
            double a = ConvertToDouble("Ange värde 1.  "); if (NumberParseError == true) return;
            double b = ConvertToDouble("Ange värde 2.  "); if (NumberParseError == true) return;

            Console.WriteLine();
            Console.WriteLine("Resultat: " + a + " upphöjt till " + b + " = " + Math.Pow(a, b));
            Foot();
        }

        // -----------------------------------------------------------

        /// <summary>
        /// Function calculator.
        /// </summary>
        static void Advanced()
        {
            Head("Formel.");
            DisplayAdvancedMenu();
          
            Console.Write("Skriv din formel: ");
            string s = Console.ReadLine();
            if (s == "") return;
            double result = ParseFormula(s);
            Console.WriteLine();
            Console.Write("Resultat av din formel [ ");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write ( s );
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ] blir ");
            Console.Write(result);
            Console.WriteLine();
            Console.WriteLine();
            Foot();
        }

        /// <summary>
        /// Parse formula using  DataTable().Compute
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        // https://stackoverflow.com/questions/355062/is-there-a-string-math-evaluator-in-net
        static double ParseFormula(string s)
        {
            s = s.Replace(',', '.');     // covert any "," to "."  Important...
            double result;
            try
            {
                 result = Convert.ToDouble(new DataTable().Compute(s, null)); // This function use DOT for decimal not comma...
            }
            catch
            {
                FormulaErrorMsg(s);
                return 0;
            }

            if (double.IsNaN(result))
            {
                FormulaErrorMsg(s);
                return 0;
            }
            //double result = Convert.ToDouble(new DataTable().Compute(s, null)); // This function use DOT for decimal not comma...
            return result;
        }

        /// <summary>
        /// Error message from formula
        /// </summary>
        /// <param name="s"></param>
        static void FormulaErrorMsg(string s)
        {
            Console.WriteLine();
            Console.WriteLine("Oj oj hoppsan....");
            Console.WriteLine("Något är fel med din formel! -->  " + s);
            Console.WriteLine("Den går inte att beräkna.");
            Console.WriteLine("Returvärdet blir Noll.");
            Console.WriteLine();
            Console.WriteLine("Tryck en tangent.");
            ReadKey();
        }

        /// <summary>
        /// Formula deskription
        /// </summary>
        static void DisplayAdvancedMenu()
        {
            Console.Clear();
            Console.WriteLine();

            Console.WriteLine("                 Skriv din formel på en rad...");
            Console.WriteLine("                 Ex. 3+4 * 4/2-6 + 1.3 * (1+2)");
            Console.WriteLine("                 Obs beräknar bara + , - , * , / och Mod %");
            Console.WriteLine();
            Console.WriteLine("                 Tryck därefter enter.");
            Console.WriteLine("                 -------------------------------");
            Console.WriteLine();
        }

            // ------------------------------------------------------------
            // ************************
            // First line for every menu item.
            // Clear screen and write menu header text.
            static void Head(string Header)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(Header);
            Console.WriteLine();
        }

        // ************************
        // Wait for user input to exit menu item.
        static void Foot()
        {
            Console.WriteLine();
            Console.WriteLine("Tryck en tangent för att avsluta.");
            ReadKey();
        }

        // ************************
        // Read user input key.
        static char ReadKey()
        {
            ConsoleKeyInfo Reply = Console.ReadKey();
            return Reply.KeyChar;
        }

        // ************************************************
        // Accept only Decimal(double) number here.
        // User can exit by only press enter.

        /// <summary>
        /// Convert to double using extra test.
        /// </summary>
        /// <param name="InputText"></param>
        /// <returns></returns>
        static double ConvertToDouble(string InputText)
        {
            string Test;
            double Nr = 0;
            // Get input. If NAN then try max 3 times.
            for (var UserTry = 1; UserTry <= 3; UserTry++)
            {
                Console.Write(InputText);
                Test = Console.ReadLine();
                Test = Test.Replace('.', ',');     // covert any "." to ","

                // Try to use string as double
                if (double.TryParse(Test,out Nr))
                {
                    return Nr;
                }
                else
                {
                    Console.WriteLine("Endast nummer är giltliga här! Försök igen.  Försök " + UserTry + " av 3.");
                }                   
            }
            NumberParseError = true;
            return 0; //EXITDBL;     // Return Error flag.
        }

        /// <summary>
        /// Convert to integer using extra test.
        /// </summary>
        /// <param name="InputText"></param>
        /// <returns></returns>
        static int ConvertToInt(string InputText)
        {
            string Test;
            int Nr = 0;

            for (var UserTry = 1; UserTry <= 3; UserTry++)
            {
                Console.Write(InputText);
                Test = Console.ReadLine();
                Test = Test.Replace('.', ',');     // covert any "." to ","

                // Try to use string as double
                if (int.TryParse(Test, out Nr))
                {
                    return Nr;
                }
                else
                {
                    Console.WriteLine("Endast heltal (int) är giltliga här! Försök igen.  Försök " + UserTry + " av 3.");
                }
            }
            NumberParseError = true;
            return 0;     // Return Error flag.
        }


        /// <summary>
        /// Division by Zero...
        /// </summary>
        static void Boom()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed; // = OrgCol;
            //Console.Clear();
           
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("         Pfft..             ");
            Console.WriteLine("                            ");
            Console.WriteLine("                            ");
            Console.WriteLine("     _.-^^---....,,--       ");
            Console.WriteLine(" _--                  --_   ");
            Console.WriteLine("<         BADA           >) ");
            Console.WriteLine("|       BooooooM          | ");
            Console.WriteLine(" \\. _                   _./ ");
            Console.WriteLine("    ```--. . , ; .--'''     ");
            Console.WriteLine("          | |   |           ");
            Console.WriteLine("       .-=||  | |= -.       ");
            Console.WriteLine("       `-=#$%&%$#=-'        ");
            Console.WriteLine("          | ;  :|           ");
            Console.WriteLine("  _____.,-#%&$@%#&#~,._____ ");
            Console.WriteLine("                            ");
            Console.WriteLine("    ERROR ERROR             ");
            Console.WriteLine("                ERORer      ");
            Console.WriteLine("   !&$€%€@*  Tryck enter.   ");
            ReadKey();
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
