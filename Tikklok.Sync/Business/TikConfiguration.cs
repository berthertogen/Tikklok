using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tikklok.Sync.Business
{
    public class TikConfiguration
    {
        public string Path { get; set; }
        public char Padder { get; set; } = '_';
        public string Endpoint { get; set; }

        // TODO refacter
        public static TikConfiguration Create(params string[] args)
        {
            string pathArgs = null, padderArgs = null, endpointArg = null;
            foreach (var arg in args.Select(arg => arg.ToLower()))
            {
                var splitted = arg.Split("=");
                if (splitted.Length == 2)
                {
                    if (splitted[0] == "path")
                    {
                        pathArgs = splitted[1];
                    }
                    else if (splitted[0] == "padder")
                    {
                        padderArgs = splitted[1];
                    }
                    else if (splitted[0] == "endpoint")
                    {
                        endpointArg = splitted[1];
                    }
                }
            }
            var result = new TikConfiguration
            {
                Path = pathArgs,
                Endpoint = endpointArg,
            };
            if (!string.IsNullOrWhiteSpace(padderArgs))
            {
                result.Padder = padderArgs[0];
            }
            return result;
        }
    }
}
