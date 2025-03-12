open System
open System.IO

let rec getDirectory (text: string) =
    printf "%s" text
    let input = Console.ReadLine()
    if Directory.Exists(input) then
        input
    else
        printfn "Ошибка (каталог не существует). Пожалуйста, введите корректный путь."
        getDirectory text

let directoryPath = getDirectory "Введите путь к каталогу: "

let rec getFiles directoryPath =
    seq {
        yield! Directory.EnumerateFiles(directoryPath) 
    }

let files = lazy (getFiles directoryPath)  

let lastFile = 
    files.Value
    |> Seq.sort 
    |> Seq.tryLast 

match lastFile with
| Some file -> printfn "Последний файл по алфавиту: %s" file
| None -> printfn "В каталоге нет файлов."
