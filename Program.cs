using System;
using System.Text.Json;

namespace BertMlNet
{
    class Program
    {
        static void Main(string[] args)
        {

            //string startupPath = System.IO.Directory.GetCurrentDirectory();

            //string startupPath2 = System.IO.Path.GetFullPath(@"..\..\..\");

            var model = new Bert(@"..\..\..\\Assets\\Vocabulary\\vocab.txt",
                               @"..\..\..\\Assets\\Model\\bertsquad-10.onnx");
            //var model = new Bert("..\\BertMlNet\\Assets\\Vocabulary\\vocab.txt",
            //                               "..\\BertMlNet\\Assets\\Model\\bertsquad-10.onnx");
            //"\"Jim is walking through the woods.\" \"What is his name?\""
            A:
            Console.WriteLine("write the information:");
            string arg1 = Console.ReadLine();
            Console.WriteLine("ask the question about the information:");
            string arg2 = Console.ReadLine();

            var (tokens, probability) = model.Predict(arg1, arg2);
            //var (tokens, probability) = model.Predict(args[0], args[1]);

            Console.WriteLine(JsonSerializer.Serialize(new
            {
                Probability = probability,
                Tokens = tokens
            }));
            Console.WriteLine(tokens[0]);

            Console.WriteLine("if you want to contunue write 'c':");
           string endind=Console.ReadLine();
            if (endind=="c")
            {
                goto A;

            }

        }
    }
}