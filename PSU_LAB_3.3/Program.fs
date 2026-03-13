open System
open System.IO

/// Рекурсивная функция, возвращающая последовательность путей ко всем *.txt-файлам
let rec allTextFiles (directory: string) : seq<string> =
    seq {
        // Все *.txt-файлы в текущем каталоге
        yield! Directory.EnumerateFiles(directory, "*.txt", SearchOption.TopDirectoryOnly)
        // Рекурсивно спускаемся в каждый подкаталог
        for subdir in Directory.EnumerateDirectories(directory) do
            yield! allTextFiles subdir
    }

// Чтение пути к каталогу от пользователя
printf "Введите путь к каталогу: "
let rootDir = Console.ReadLine().Trim()
if not (Directory.Exists rootDir) then
    printfn "Указанный каталог не найден."
else
    // Итерация по ленивой последовательности и вывод путей
    allTextFiles rootDir
    |> Seq.iter (printfn "%s")
