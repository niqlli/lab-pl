open System

let rec getNatural (text : string) =
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

let rec getSingleCharacter (text : string) =
    printf "%s" text
    let input = Console.ReadLine()
    if input.Length = 1 then
        input
    else
        printfn "Ошибка (введено больше одного символа или ничего). Пожалуйста, введите один символ."
        getSingleCharacter text 

let RandomStrings (count: int) (maxLength: int) : string list =
    let random = Random()
    let chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789" 

    let RandomString (length: int) =
        let randomChars = 
            [| for _ in 1..length -> chars.[random.Next(chars.Length)] |]
        String(randomChars)

    [ for _ in 1..count -> 
        let length = random.Next(1, maxLength + 1) 
        RandomString length ]

let rec ListCreate () =
    printfn "Выберите действие:"
    printfn "1 - Создать список вводом с клавиатуры"
    printfn "2 - Сгенерировать список случайным способом"
    printf "Ваш выбор: "
    let a = Console.ReadLine()
    let text = "Введите количество элементов в списке: "
    let text1 = "Введите максимальную длину строки в списке: "
    
    match a with
    | "1" -> 
        let number = getNatural text
        let newList = 
            [ for i in 1..number do
                printf "Введите %d-й элемент списка: " i
                let h = Console.ReadLine()
                yield h ]
        newList
    | "2" -> 
        let number = getNatural text
        let max = getNatural text1
        RandomStrings number max
    | _ -> 
        printfn "Неверный выбор. Попробуйте снова."
        ListCreate ()

let list = ListCreate ()

let symbol = getSingleCharacter "Введите символ для добавления к каждой строке: "

let newList = List.map (fun str -> str + symbol) list

printfn "Итоговый список: %A" newList
