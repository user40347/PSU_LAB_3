using System;
using System.Text.RegularExpressions;

namespace

public static class Shared
{


    // Проверка вводимого целого числа
    let static rec readInt(prompt: string) =
    printf "%s" prompt
    match Console.ReadLine() with
    | null | "" ->
        printfn "Ошибка: введите целое число."
        readInt prompt
    | s ->
        match Int32.TryParse(s) with
        | (true, v) -> v
        | _ ->
            printfn "Ошибка: некорректный формат целого числа."
            readInt prompt

// Проверка вводимого вещественного числа
let static rec readFloat(prompt: string) =
    printf "%s" prompt
    match Console.ReadLine() with
    | null | "" ->
        printfn "Ошибка: введите число."
        readFloat prompt
    | s ->
        match Double.TryParse(s) with
        | (true, v) -> v
        | _ ->
            printfn "Ошибка: некорректный формат числа."
            readFloat prompt

// Обработка вводимого положительного целого числа
let static rec readPositiveInt(prompt: string) =
    printf "%s" prompt
    match Console.ReadLine() with
    | null | "" ->
        printfn "Ошибка: введите целое число."
        readPositiveInt prompt
    | s ->
        match Int32.TryParse(s) with
        | (true, v) when v > 0 -> v
        | _ ->
            printfn "Ошибка: введите число > 0."
            readPositiveInt prompt
}
