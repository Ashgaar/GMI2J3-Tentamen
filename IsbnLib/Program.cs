using System;
using System.Text;
// https://github.com/tomakita/Colorful.Console
using Console = Colorful.Console;
using System.Drawing;
using Figgle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Autofac;
using IsbnLib.Controller;
using IsbnLib.Interfaces;


namespace IsbnLib
{
    class Program
    {
        // for Autofac
        private static IContainer Container { get; set; }

        // valid isbns, but may not point to an actual book
        private static string[] ValidIsbns = new string[] {
            "1617290890",
            "1590593006",
            "9783878313793",
            "978-3-16-148410-0",
            "15-84885-40-8",
            "0-8436-1072-7",
            "316148410X",
            "978-158488-540-5",
            "15 8488 5408",
        };

        // non-valid isbns
        private static string[] NonValidIsbns = new string[] {
            null,
            "",
            " ",
            "2.5",
            "ttt",
            "123-45-567-8-9",
            "3878313798",
            "0-14-020652-4",
            "970-3-16-148410-0",
            "978-3-16-148410-3",
            "abcdefghix",
            "abcdefghixabc",
            "abcdefghi1",
            "abcdefghixab1",
            "0 - 14 - 020652 - 4",
        };

        /// <summary>
        /// Castle Windsor https://github.com/castleproject/Windsor is best of breed, mature Inversion of Control
        /// https://github.com/castleproject/Windsor/blob/master/docs/ioc.md container available for .NET.
        /// </summary>
        /// <returns></returns>
        private static IIsbnProcessor GetIsbnContainerWindsor()
        {
            // CREATE A WINDSOR CONTAINER OBJECT AND REGISTER THE INTERFACES, AND THEIR CONCRETE IMPLEMENTATIONS
            var container = new WindsorContainer();
            container.Register(Component.For<IIsbnProcessor>().ImplementedBy<IsbnProcessorStud>());
            // CREATE THE MAIN OBJECTS AND INVOKE ITS METHOD(S) AS DESIRED
            return container.Resolve<IIsbnProcessor>();
        }

        /// <summary>
        /// Autofac https://github.com/autofac/ 
        /// https://autofac.org/
        /// https://autofaccn.readthedocs.io/en/latest/getting-started/index.html
        /// </summary>
        /// <returns></returns>
        private static IIsbnProcessor GetIsbnContainerAutofac()
        {
            // CREATE AUTFAC CONTAINER
            var builder = new ContainerBuilder();
            builder.RegisterType<IsbnProcessorStud>().As<IIsbnProcessor>();
            // build can only be called once
            Container = builder.Build();
            return Container.Resolve<IIsbnProcessor>();
        }

        /// <summary>
        /// Get real IsbnProcessorStud object, not using any interface
        /// </summary>
        /// <returns></returns>
        private static IsbnProcessorStud GetRealIsbnObject()
        {
            return new IsbnProcessorStud();
        }

        /// <summary>
        /// Get an IsbnProcessor interface variable
        /// </summary>
        /// <returns></returns>
        private static IIsbnProcessor GetIsbnInterfaceVar()
        {
            return new IsbnProcessorStud();
        }

        static void Main(string[] args)
        {
            // render chars correct in the console output
            Console.OutputEncoding = Encoding.Default;

            bool showMenu = true;

            Console.WriteLine(FiggleFonts.Standard.Render("ISBN Lib"));

            // it does not matter what you use here of container, real object or interface variable
            //var IsbnLib = GetIsbnContainerWindsor();
            //var IsbnLib = GetIsbnContainerAutofac();
            //var IsbnLib = GetRealIsbnObject();
            var IsbnLib = GetIsbnInterfaceVar();

            while (showMenu)
            {
                int count = 1;
                Console.WriteLine("Choose 'A' to Validate valid ISBNs", Color.Yellow);
                Console.WriteLine("Choose 'B' to Validate non-valid ISBNs", Color.Yellow);
                Console.WriteLine("Choose 'C' to Create book URL from valid ISBNs", Color.Yellow);
                Console.WriteLine("Choose 'D' to Create book URL from non-valid ISBNs", Color.Yellow);
                Console.WriteLine("Choose 'E' to Convert and validate valid ISBNs", Color.Yellow);
                Console.WriteLine("Choose 'F' to Convert and validate non-valid ISBNs", Color.Yellow);
                //Console.WriteLine("Choose '???' to Perform other command");
                Console.WriteLine("Choose 'Q' to Exit");
                Console.Write("\r\nPerform your choice: ");
                var command1 = Console.ReadLine();
                var command = command1.ToUpper();


                switch (command)
                {
                    case "A":
                        foreach (var isbn in ValidIsbns)
                        {
                            try
                            {
                                Console.WriteLine($"Checking valid ISBN #{count++}: {isbn}", Color.Cyan);
                                Console.WriteLine($"IsValid ISBN-10/13: {isbn} ? {IsbnLib.TryValidate(isbn)}" + Environment.NewLine, Color.Magenta);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Exception: {e}", Color.Red);
                            }
                        }
                        break;
                    case "B":
                        foreach (var isbn in NonValidIsbns)
                        {
                            try
                            {
                                Console.WriteLine($"Checking non-valid ISBN #{count++}: {isbn}", Color.Cyan);
                                Console.WriteLine($"IsValid ISBN-10/13: {isbn} ? {IsbnLib.TryValidate(isbn)}" + Environment.NewLine, Color.Magenta);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Exception: {e}", Color.Red);
                            }
                        }
                        break;
                    case "C":
                        foreach (var isbn in ValidIsbns)
                        {
                            try
                            {
                                Console.WriteLine($"Create book URL from valid ISBN #{count++}: {isbn}", Color.Cyan);
                                Console.WriteLine($"BookUrl: {IsbnLib.CreateBookUrl("", isbn)}" + Environment.NewLine, Color.Magenta);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Exception: {e}", Color.Red);
                            }
                        }
                        break;
                    case "D":
                        foreach (var isbn in NonValidIsbns)
                        {
                            try
                            {
                                Console.WriteLine($"Create book URL from non-valid ISBN #{count++}: {isbn}", Color.Cyan);
                                Console.WriteLine($"BookUrl: {IsbnLib.CreateBookUrl("", isbn)}" + Environment.NewLine, Color.Magenta);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Exception: {e}", Color.Red);
                            }
                        }
                        break;
                    case "E":
                        foreach (var isbn in ValidIsbns)
                        {
                            try
                            {
                                Console.WriteLine($"Convert valid ISBN-10/13 #{count++} to ISBN-13/10: {isbn} ? " +
                                    $"{IsbnLib.TryValidate(IsbnLib.TryConvert(isbn))} " + Environment.NewLine, Color.Cyan);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Exception: {e}", Color.Red);
                            }
                        }
                        break;
                    case "F":
                        foreach (var isbn in NonValidIsbns)
                        {
                            try
                            {
                                Console.WriteLine($"Convert non-valid ISBN-10/13 #{count++} to ISBN-13/10: {isbn} ? " +
                                    $"{IsbnLib.TryValidate(IsbnLib.TryConvert(isbn))} " + Environment.NewLine, Color.Cyan);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Exception: {e}", Color.Red);
                            }
                        }
                        break;
                    case "Q":
                        showMenu = false;
                        break;
                    default:
                        Console.WriteLine("Unknown command!", Color.Red);
                        break;
                }
            }
        }
    }
}