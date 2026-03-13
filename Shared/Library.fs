namespace Shared

module InputControl =
        // Проверка вводимого целого числа
    let rec readInt (prompt: string) =
        printf "%s" prompt
        match System.Console.ReadLine() with
        | null | "" ->
            printfn "Ошибка: введите целое число."
            readInt prompt
        | s ->
            match System.Int32.TryParse(s) with
            | (true, v) -> v
            | _ ->
                printfn "Ошибка: некорректный формат целого числа."
                readInt prompt

    // Проверка вводимого вещественного числа
    let rec readFloat (prompt: string) =
        printf "%s" prompt
        match System.Console.ReadLine() with
        | null | "" ->
            printfn "Ошибка: введите число."
            readFloat prompt
        | s ->
            match System.Double.TryParse(s) with
            | (true, v) -> v
            | _ ->
                printfn "Ошибка: некорректный формат числа."
                readFloat prompt

    // Обработка вводимого положительного целого числа
    let rec readPositiveInt (prompt: string) =
        printf "%s" prompt
        match System.Console.ReadLine() with
        | null | "" ->
            printfn "Ошибка: введите целое число."
            readPositiveInt prompt
        | s ->
            match System.Int32.TryParse(s) with
            | (true, v) when v > 0 -> v
            | _ ->
                printfn "Ошибка: введите число > 0."
                readPositiveInt prompt