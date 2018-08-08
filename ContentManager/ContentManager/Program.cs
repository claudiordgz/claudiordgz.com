using System;
using LibGit2Sharp;
using CommandLine;
// Content is created in markdown in it's own folder
// Push to repo triggerS:
// if environment variable 'INPUT' is ALL
//      process all directories
// else
//      process only specific directories
// if environment variable 'TYPE' is ORIGIN
//      process all content
// else
//      process differences between HEAD and last tag
// Each change (POST OR FEED), push to sqs
// new changes will need to get deployed
// blog
//  each POST creates new item
// feeds
//  1 xml file
//  file contains FEEDS
//  each FEED creates new item
//  each FEED triggers service that 
// study
//  each directory is STUDY and creates new item
//  each POST in STUDY creates new item
// projects
//  each directory is PROJECT and creates new item
//  each POST in PROJECT creates new item
namespace ContentManager
{

    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default
                .ParseArguments<Options>(args)
                .WithParsed<Options>(opts =>
                {
                    Console.WriteLine(opts.Type);
                    Console.WriteLine(opts.Verbose);
                    Console.WriteLine(opts.Input);
                });
        }
    }
}
