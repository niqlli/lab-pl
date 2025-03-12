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

let rec getFloat num =
    printf "Введите %d-й элемент списка: " num
    let input = Console.ReadLine()
    match Double.TryParse(input) with
    | (true, n) -> n
    | (false, _) ->
        printfn "Ошибка (введено не число)"
        getFloat num

let getNumbers n =
    let rec loop i list =
        if i > n then
            list
        else
            let number = getFloat i
            let numberToInsert = 
                if number = 0.0 then 0.0 
                else 1.0 / number  
            loop (i + 1) (list @ [numberToInsert])
    loop 1 []

let number = getNatural ()
let list1 = getNumbers number
printfn "Список из чисел, обратных вводимым значениям: %A" list1