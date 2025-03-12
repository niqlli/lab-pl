open System
let rec getNatural () =
    printf "Введите количество элементов списка: "
    let input = Console.ReadLine()
    match Int32.TryParse(input) with
    | (true, n) when n > 0 -> n
    | (true, _) ->
        printfn "Ошибка (число ненатуральное)"
        getNatural ()
    | (false, _) ->
        printfn "Ошибка (введено не число)"
        getNatural ()

let CountEvenDigits n =
    let rec kol (n: int) (a: int) =
        if n = 0 then a
        else 
            let digit = n % 10
            if digit % 2 = 0 then
                kol (n / 10) (a + 1)
            else
                kol (n / 10) a
    kol n 0

let number = getNatural ()
let result = CountEvenDigits number
printfn "Количество чётных цифр в данном натуральном числе: %d" result