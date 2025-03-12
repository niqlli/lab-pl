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

let number = getNatural "Введите количество элементов в последовательности: "

let compareStrings (shortest, minLength) (str: string) =
    let currentLength = String.length str
    match shortest with
    | None -> (Some (Seq.singleton str), currentLength)
    | Some currentShortest ->
        if currentLength < minLength then
            (Some (Seq.singleton str), currentLength)
        elif currentLength = minLength then
            (Some (Seq.append currentShortest (Seq.singleton str)), minLength)
        else
            (Some currentShortest, minLength)

let sequence = lazy (
    seq {
        for i in 1 .. number do
            printf "Введите %d-й элемент последовательности: " i
            yield Console.ReadLine()
    }
)

let shortestStrings = lazy (
    sequence.Value
    |> Seq.fold compareStrings (None, Int32.MaxValue) 
    |> fst
    |> function
        | Some s -> s
        | None -> Seq.empty 
)

printfn "Самые короткие строки: %A" shortestStrings.Value