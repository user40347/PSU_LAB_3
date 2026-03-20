open System
open System.IO

// Функция, 
// возвращающая последовательность путей ко всем *.txt-файлам
let rec AllTextFiles (directory: string) : seq<string> =
    seq {
        // Все *.txt-файлы в текущем каталоге
        yield! 
            Directory.EnumerateFiles(
                                directory,
                                "*.txt",
                                SearchOption.TopDirectoryOnly)
        // Рекурсивно спускаемся в каждый подкаталог
        for subdir in 
            Directory.EnumerateDirectories (directory) do
            yield! 
                AllTextFiles subdir
    }

let rec GetCatalog s =
        let rootDir = Console.ReadLine().Trim()
        if not (Directory.Exists rootDir) then
            printfn "Указанный каталог не найден. \n"
            GetCatalog s
        else
            rootDir

let PrintSeq sequence=
        if Seq.length (sequence) <> 0 then
            sequence |> Seq.iter (printfn"%s")
        else
            printf "В каталоге и подкаталогах нет файлов с расширением .txt"

[<EntryPoint>]
let main argv =
    printf "Введите путь к каталогу: "
    let rootDir = GetCatalog "Введите путь к каталогу: "
    let res = AllTextFiles rootDir
    PrintSeq res
    0
