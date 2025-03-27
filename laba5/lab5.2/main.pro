% Определить количество нечётных отрицательных элементов в списке целых чисел.

implement main
    open core, console

class predicates
    counterNegative : (integer* L [in], integer N [out]).
    inList : (integer N [in], integer* L [out]).
    outList : (integer* L [in]).

clauses
    run() :-
        init(),
        write("Enter quantity number of list items: "),
        nl,
        Nstring = readLine(),
        N = toTerm(integer, Nstring),
        inList(N, L),
        write("List: "),
        outList(L),
        counterNegative(L, K),
        nl,
        writef("quantity of odd negative items: % ", K),
        nl,
        _ = readLine().

    counterNegative(L, N) :-
        counterNegative(L, 0, N),
        !.

    inList(0, []) :-
        !.

    inList(N, [H | T]) :-
        N > 0,
        write("Enter integer number:"),
        nl,
        Nstring = readLine(),
        H = toTerm(integer, Nstring),
        New = N - 1,
        inList(New, T),
        !.

    inList(_, []) :-
        !.

    outList([H | T]) :-
        writef("%, ", H),
        outList(T).
    outList([]) :-
        !.

class predicates
    counterNegative : (integer* L [in], integer Q [in], integer N [out]).
clauses
    counterNegative([], Q, Q).

    counterNegative([H | T], Q, R) :-
        H < 0,
        H mod 2 = 1,
        New = Q + 1,
        counterNegative(T, New, R),
        !.

    counterNegative([_ | T], Q, R) :-
        counterNegative(T, Q, R),
        !.

end implement main

goal
    console::runUtf8(main::run).
