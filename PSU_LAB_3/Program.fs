open System
open Shared.InputControl


// Выбор метода заполнения списка
let rec readSelectedMethod () =
    printfn "Выберите способ заполнения:\n1) С клавиатуры\n2) Путем заполнения случайными числами"
    match Console.ReadLine() with
    | "1" | "2" as method -> method
    | _ ->
        printfn "Такого метода нет. Попробуйте снова."
        readSelectedMethod ()


let rec FillSeq sequment n selectmethod=
    if n <= 0 then
        printfn "Текущий список: %A" sequment
        sequment 
    else
        if (selectmethod = "1") then
            (FillSeq ((sequment |> Seq.insertAt 0 (readFloat("Введите число \n")))) (n - 1) selectmethod)
        else if (selectmethod = "2") then
            let rnd = Random()
            FillSeq (sequment |> Seq.insertAt 0 (float(rnd.Next(10,1000))/10.0)) (n - 1) selectmethod
        else
            sequment
    
let rec takeFirst (x:float) =
    let x = abs (int(x))
    if x < 10 then 
        x 
    else 
        takeFirst (float(x / 10))


   



[<EntryPoint>]
let main argv =
    let items = Seq.empty<float>
    let TryAddToSeq (sequment)= 
        (items |> Seq.insertAt 0 (readFloat("Введите число: ")))
    let n = (readPositiveInt("Введите количество чисел. \n"))
    let selectmethod = readSelectedMethod()
    FillSeq items n
    let resultSeq = Seq.map takeFirst (FillSeq items n selectmethod);
    printfn "Полученная последовательность: %A" resultSeq
    0