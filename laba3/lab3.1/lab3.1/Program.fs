open System

let rec getNatural (text: string) =
    printf "%s" text
    let input = Console.ReadLine()
    match Int32.TryParse(input) with
    | (true, n) when n > 0 -> n
    | (true, _) ->
        printfn "Ошибка (число ненатуральное)"
        getNatural text
    | (false, _) ->
        printfn "Ошибка (введено не число)"
        getNatural text

let rec getSingleCharacter (text: string) =
    printf "%s" text
    let input = Console.ReadLine()
    if input.Length = 1 then
        input
    else
        printfn "Ошибка (введено больше одного символа или ничего). Пожалуйста, введите один символ."
        getSingleCharacter text

let number = lazy (getNatural "Введите количество элементов в последовательности: ")

let sequence = lazy (
    seq {
        for i in 1 .. number.Value do
            printf "Введите %d-й элемент последовательности: " i
            yield Console.ReadLine()
    }
)
let symbol = getSingleCharacter "Введите символ для добавления к каждой строке: "

let modifiedSequence = lazy (
    sequence.Value
    |> Seq.map (fun str ->
        printfn "Обработка элемента: %s" str 
        str + symbol)
)

modifiedSequence.Value |> Seq.iter (printfn "%s")