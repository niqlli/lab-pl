implement main
    open core, console

class predicates
    find_min_max_digits : (integer N [in], integer Min [out], integer Max [out]).
    find_min_max_helper : (integer N [in], integer CurrentMin [in], integer CurrentMax [in], integer Min [out], integer Max [out]).

clauses
    run() :-
        init(),
        write("Enter the natural number n: "),
        nl,
        Nstring = readLine(),
        N = toTerm(integer, Nstring),
        nl,
        find_min_max_digits(N, Min, Max),
        writef("min digit: %, max digit: %\n", Min, Max),
        nl,
        _ = readLine().

    find_min_max_digits(N, Min, Max) :-
        find_min_max_helper(N, 9, 0, Min, Max).

    find_min_max_helper(0, CurrentMin, CurrentMax, CurrentMin, CurrentMax) :-
        !.

    find_min_max_helper(N, CurrentMin, CurrentMax, Min, Max) :-
        Digit = N mod 10,
        NewMin = if Digit < CurrentMin then Digit else CurrentMin end if,
        NewMax = if Digit > CurrentMax then Digit else CurrentMax end if,
        NextN = N div 10,
        find_min_max_helper(NextN, NewMin, NewMax, Min, Max).

end implement main

goal
    console::runUtf8(main::run).
