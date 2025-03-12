open System
type Complex = { Real: float; Imaginary: float }
// Функция для ввода действительного числа
let rec getFloat prompt =
    printf "%s" prompt
    let input = Console.ReadLine()
    match Double.TryParse(input) with
    | true, v -> v
    | false, _ ->
        printfn "Ошибка(введено не число)."
        getFloat prompt

// Функция для ввода комплексного числа
let getComplex () =
    { Real = getFloat "Введите действительную часть: "; Imaginary = getFloat "Введите мнимую часть: " }

// Функция для ввода натурального числа
let rec getNatural prompt =
    printf "%s" prompt
    let input = Console.ReadLine()
    match Int32.TryParse(input) with
    | true, n when n > 0 -> n
    | true, _ ->
        printfn "Ошибка (число ненатуральное)"
        getNatural prompt
    | false, _ ->
        printfn "Ошибка (введено не число)"
        getNatural prompt

// Сложение
let add (z1: Complex) (z2: Complex) =
    { Real = z1.Real + z2.Real; Imaginary = z1.Imaginary + z2.Imaginary }

// Вычитание
let subtract (z1: Complex) (z2: Complex) =
    { Real = z1.Real - z2.Real; Imaginary = z1.Imaginary - z2.Imaginary }

// Умножение
let multiply (z1: Complex) (z2: Complex) =
    { Real = z1.Real * z2.Real - z1.Imaginary * z2.Imaginary
      Imaginary = z1.Real * z2.Imaginary + z1.Imaginary * z2.Real }

// Деление
let divide (z1: Complex) (z2: Complex) =
    let denominator = z2.Real * z2.Real + z2.Imaginary * z2.Imaginary
    if denominator = 0.0 then
        printfn "Ошибка (деление на 0)"
        { Real = 0.0; Imaginary = 0.0 } // Возвращаем 0 + 0i в случае ошибки
    else
        { Real = (z1.Real * z2.Real + z1.Imaginary * z2.Imaginary) / denominator
          Imaginary = (z1.Imaginary * z2.Real - z1.Real * z2.Imaginary) / denominator }

// Возведение в степень
let rec power (z: Complex) (n: int) =
    if n = 1 then z
    else multiply z (power z (n - 1))

// Основное меню
let rec mainMenu () =
    printfn "Выберите операцию с комплексными числами:"
    printfn "1. Сложение"
    printfn "2. Вычитание"
    printfn "3. Умножение"
    printfn "4. Деление"
    printfn "5. Возведение в степень (только положительный показатель степени)"
    printfn "6. Выйти"
    printf "Ваш выбор: "
    let choice = Console.ReadLine()

    match choice with
    | "1" ->
        let z1 = getComplex()
        let z2 = getComplex()
        let result = add z1 z2
        printfn "Результат сложения: %.2f + %.2fi" result.Real result.Imaginary
        mainMenu ()
    | "2" ->
        let z1 = getComplex()
        let z2 = getComplex()
        let result = subtract z1 z2
        printfn "Результат вычитания: %.2f + %.2fi" result.Real result.Imaginary
        mainMenu ()
    | "3" ->
        let z1 = getComplex()
        let z2 = getComplex()
        let result = multiply z1 z2
        printfn "Результат умножения: %.2f + %.2fi" result.Real result.Imaginary
        mainMenu ()
    | "4" ->
        let z1 = getComplex()
        let z2 = getComplex()
        let result = divide z1 z2
        printfn "Результат деления: %.2f + %.2fi" result.Real result.Imaginary
        mainMenu ()
    | "5" ->
        let z = getComplex()
        let n = getNatural "Введите показатель степени: "
        let result = power z n
        printfn "Результат возведения в степень: %.2f + %.2fi" result.Real result.Imaginary
        mainMenu ()
    | "6" ->
        printfn "Программа завершена."
    | _ ->
        printfn "Неверный выбор. Попробуйте снова."
        mainMenu ()

[<EntryPoint>]
let main argv =
    mainMenu ()
    0