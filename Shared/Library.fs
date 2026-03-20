namespace Shared

open System

module InputControl =

        // Проверка вводимого целого числа
    let rec ReadInt (prompt: string) =
        printf "%s" prompt
        match System.Console.ReadLine() with
        | null | "" ->
            printfn "Ошибка: введите целое число."
            ReadInt prompt
        | s ->
            match System.Int32.TryParse(s) with
            | true, v -> v
            | _ ->
                printfn 
                    "Ошибка: некорректный формат целого числа."
                ReadInt prompt

    // Проверка вводимого вещественного числа
    let rec ReadFloat (prompt: string) =
        printf "%s" prompt
        match System.Console.ReadLine() with
        | null | "" ->
            printfn "Ошибка: введите число."
            ReadFloat prompt
        | s ->
            match System.Double.TryParse(s) with
            | true, v -> v
            | _ ->
                printfn "Ошибка: некорректный формат числа."
                ReadFloat prompt

    // Обработка вводимого положительного целого числа
    let rec ReadPositiveInt (prompt: string) =
        printf "%s" prompt
        match System.Console.ReadLine() with
        | null | "" ->
            printfn "Ошибка: введите целое число."
            ReadPositiveInt prompt
        | s ->
            match System.Int32.TryParse(s) with
            | true, v when v > 0 -> v
            | _ ->
                printfn "Ошибка: введите число > 0."
                ReadPositiveInt prompt


module Sequence =
        // Выбор метода заполнения списка
    let rec ReadSelectedMethod () =
        printfn "Выберите способ заполнения:
    1) С клавиатуры
    2) Путем заполнения случайными числами"

        match Console.ReadLine() with
        | "1" | "2" as method -> method
        | _ ->
            printfn "Такого метода нет. Попробуйте снова."
            ReadSelectedMethod ()


    let rec FillSeq sequment n selectmethod=
        if n <= 0 then
            printfn "Текущий список: %A" sequment
            sequment 
        else
            if (selectmethod = "1") then
                FillSeq (
                    (sequment |> Seq.insertAt 0 (
                        InputControl.ReadFloat(
                            "Введите число \n"
                        )))) (n - 1) selectmethod
            else if (selectmethod = "2") then
                let rnd = Random()
                FillSeq (
                    sequment |> Seq.insertAt 0 (
                        float(
                            rnd.Next(
                                10,1000
                            ))/10.0)) (n - 1) selectmethod
            else
                sequment