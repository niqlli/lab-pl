implement main
    open core, console

domains
    subject = string.

class facts
    fact1 : (subject).

class predicates
    uniqueRoles : (subject, subject, subject, subject, subject, subject) nondeterm.
clauses
    fact1("History").
    fact1("Math").
    fact1("Biology").
    fact1("Geography").
    fact1("English").
    fact1("French").
    uniqueRoles(Subject1, Subject2, Subject3, Subject4, Subject5, Subject6) :-
        Subject1 < Subject2,
        Subject3 < Subject4,
        Subject5 < Subject6,

        (
            Subject5 = "Geography" and Subject1 = "French"
            or Subject2 = "French" and Subject5 = "Geography"
            or Subject5 = "Geography" and Subject3 = "French"
            or Subject4 = "French" and Subject5 = "Geography"),

        Subject1 <> "Biology",
        Subject2 <> "Biology",

        Subject5 <> "Biology",
        Subject6 <> "Biology",
        Subject5 <> "French",
        Subject6 <> "French",

        Subject1 <> "Math",
        Subject2 <> "English",
        Subject2 <> "Math",
        Subject1 <> "English",

        Subject1 <> Subject2,
        Subject1 <> Subject3,
        Subject1 <> Subject4,
        Subject1 <> Subject5,
        Subject1 <> Subject6,
        Subject2 <> Subject3,
        Subject2 <> Subject4,
        Subject2 <> Subject5,
        Subject2 <> Subject6,
        Subject3 <> Subject4,
        Subject3 <> Subject5,
        Subject3 <> Subject6,
        Subject4 <> Subject5,
        Subject4 <> Subject6,
        Subject5 <> Subject6.

    run() :-
        fact1(Subject1),
        fact1(Subject2),
        fact1(Subject3),
        fact1(Subject4),
        fact1(Subject5),
        fact1(Subject6),

        uniqueRoles(Subject1, Subject2, Subject3, Subject4, Subject5, Subject6),
        write("Morozov: ", Subject1, ", ", Subject2),
        nl,
        write("Vasilyev: ", Subject3, ", ", Subject4),
        nl,
        write("Tokarev: ", Subject5, ", ", Subject6),
        nl,
        fail
        or
        succeed,
        _ = readLine().

end implement main

goal
    console::runUtf8(main::run).
