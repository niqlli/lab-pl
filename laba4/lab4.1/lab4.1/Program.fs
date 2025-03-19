open System
type BinaryTree =
    | Empty
    | Node of float * BinaryTree * BinaryTree

let rec insert (tree: BinaryTree) (value: float) =
    match tree with
    | Empty -> Node(value, Empty, Empty)
    | Node(v, left, right) ->
        if value < v then
            Node(v, insert left value, right)
        else
            Node(v, left, insert right value)

let rec getNatural () =
    printf "Введите количество элементов дерева: "
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
    printf "Введите %d-й элемент дерева: " num
    let input = Console.ReadLine()
    match Double.TryParse(input) with
    | (true, n) -> n
    | (false, _) ->
        printfn "Ошибка (введено не число)"
        getFloat num

let rec printTree (tree: BinaryTree) lCur tCur level =
    match tree with
    | Node(inf, left, right) -> 
        Console.SetCursorPosition(lCur, tCur)
        printf "%f" inf  
        if left <> Empty then 
            Console.SetCursorPosition(lCur - (5 / level), tCur + 1)
            printf "/"
        if right <> Empty then 
            Console.SetCursorPosition(lCur + 2, tCur + 1)  
            printf "\\"
        printTree left (lCur - (10 / level)) (tCur + 2) (level + 1)
        printTree right (lCur + (10 / level)) (tCur + 2) (level + 1)
    | Empty -> ()

let rec depth (tree: BinaryTree) =
    match tree with
    | Empty -> 0
    | Node(_, left, right) -> 1 + max (depth left) (depth right)

let rec mapTree (tree: BinaryTree) =
    match tree with
    | Empty -> Empty
    | Node(value, left, right) ->
        let newValue = float (int value)  
        Node(newValue, mapTree left, mapTree right) 

let rec buildTree count values tree =
    match values with
    | [] -> tree
    | head :: tail -> buildTree (count - 1) tail (insert tree head)

[<EntryPoint>]
let main argv =
    let count = getNatural()
    let values = [ for i in 1 .. count -> getFloat i ]

    let treeRoot = buildTree count values Empty

    printfn "Исходное дерево:"
    let currentPos = Console.GetCursorPosition()
    let x, y = (10 * depth treeRoot), snd(currentPos.ToTuple())
    printTree treeRoot x y 1
    printfn ""

    let intTreeRoot = mapTree treeRoot

    printfn "Дерево с отброшенной дробной частью:"
    let currentPos = Console.GetCursorPosition()
    let x, y = (10 * depth intTreeRoot), snd(currentPos.ToTuple())
    printTree intTreeRoot x y 1

    0 
