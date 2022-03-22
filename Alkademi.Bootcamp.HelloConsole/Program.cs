// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int i = 1;

foreach (var item in args)
{
    Console.WriteLine($"arg ke {i}: {item}");
    i++;    
}
