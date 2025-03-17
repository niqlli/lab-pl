open System

type BinaryTree =
    | Empty
    | Node of string * BinaryTree * BinaryTree

let rec insert (tree: BinaryTree) (value: string ) =
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

let rec getString num =
    printf "Введите %d-й элемент дерева: " num
    Console.ReadLine()

let rec printTree (tree: BinaryTree) lCur tCur level =
    match tree with
    | Node(inf, left, right) ->
        Console.SetCursorPosition(lCur, tCur)
        printf "%s" inf
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

let isLeaf node =
    match node with
    | Node(_, Empty, Empty) -> true
    | _ -> false

let rec foldTree tree =
    let rec helper parentNode tree acc =
        match tree with
        | Empty -> acc
        | Node(value, left, right) ->
            let leftIsLeaf = isLeaf left
            let rightIsLeaf = isLeaf right
            let acc' =
                if leftIsLeaf && rightIsLeaf then acc // Игнорируем, если оба потомка - листья
                elif leftIsLeaf && not rightIsLeaf then  
                    match parentNode with
                    | Some(Node(_,_,_)) -> value :: acc //Добавляем, если есть родитель, и только левый потомок - лист
                    | _ -> acc          // Игнорируем корень (у него не может быть одного потомка-листа)

                elif not leftIsLeaf && rightIsLeaf then 
                     match parentNode with
                     | Some(Node(_,_,_)) -> value :: acc //Добавляем, если есть родитель, и только правый потомок - лист
                     | _ -> acc
                else acc // Игнорируем, если ни один потомок не лист или оба не листья
            helper (Some tree) left (helper (Some tree) right acc')
    helper None tree []

let rec buildTree count tree =
    if count <= 0 then tree
    else
        let value = getString count
        buildTree (count - 1) (insert tree value)

[<EntryPoint>]
let main argv =
    let count = getNatural ()
    let treeRoot = buildTree count Empty

    printfn "Построенное дерево:"
    let currentPos = Console.GetCursorPosition()
    let x, y = (10 * depth treeRoot), snd(currentPos.ToTuple())
    printTree treeRoot x y 1

    Console.SetCursorPosition(0, y + depth treeRoot + 2)

    let singleLeafNodes = foldTree treeRoot
    printfn "Узлы с одним листом: %A" singleLeafNodes

    0