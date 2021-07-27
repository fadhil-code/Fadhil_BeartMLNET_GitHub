using System.Collections.Generic;
using System.IO;

namespace BertMlNet.Helpers
{
    public static class FileReader
    {
        public static List<string> ReadFile(string filename)
        {
            var result = new List<string>();

            using (var reader = new StreamReader(filename))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        result.Add(line);
                    }
                }
            }
            //Error Microsoft.ML currently supports 'x64' and 'x86' processor architectures. Please ensure your application is targeting 'x64' or 'x86'.BeartMLNET

            return result;
        }
    }
}