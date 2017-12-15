// Дополнительные сведения о F# см. на http://fsharp.org
// Дополнительную справку см. в проекте "Учебник по F#".

open System
open System.Security.AccessControl
open System.Security.Cryptography.X509Certificates

type SquareRootResult=
    |NoRoots
    |OneRoot of double
    |TwoRoots of double*double
    //Вроде как можно не писать сюда типы, но как

let CalculateRoots(a:double,b:double,c:double):SquareRootResult=
    let D=b*b-4.0*a*c;
    if D<0.0 then NoRoots
    else if D=0.0 then 
        let rt= -b/(2.0*a)
        OneRoot rt
    else
        let sqrtD=Math.Sqrt(D)
        let rt1 = (-b+sqrtD)/(2.0*a);
        let rt2= (-b-sqrtD)/(2.0*a);
        TwoRoots(rt1,rt2)

let PrintRoots(a:double, b:double,c:double):unit =
    printf "Коэффициенты: a=%A, b=%A, c=%A. " a b c
    let root = CalculateRoots(a,b,c)
    let textResult = 
        match root with
        |NoRoots->"Корней нет"
        |OneRoot(rt)->"Один коренm "+rt.ToString()
        |TwoRoots(rt1,rt2)->"Два корня " + rt1.ToString() + " и " + rt2.ToString()
    printfn "%s" textResult

let rec ReadInDouble() = 
    match System.Double.TryParse(System.Console.ReadLine()) with
    |false, _-> printfn "Введите еще раз"; ReadInDouble()
    |_, x -> x

[<EntryPoint>]
let main argv = 
    
    printf "Введите коэффициенты квадратного уравнения: ";
    Console.WriteLine("\n");
    let mutable a = ReadInDouble();
        //System.Double.TryParse(System.Console.ReadLine())
    let mutable b = ReadInDouble();
        //System.Double.TryParse(System.Console.ReadLine())
    let mutable c = ReadInDouble();
        //System.Double.TryParse(System.Console.ReadLine())
    PrintRoots(a,b,c)

  //  printfn "%A" argv
    Console.ReadLine()|> ignore
    0 // возвращение целочисленного кода выхода
