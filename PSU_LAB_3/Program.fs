open Shared.InputControl
open Shared.Sequence


let rec TakeFirst (x:float) =
    let x = abs (int (x))
    if x < 10 then 
        x 
    else 
        TakeFirst (float (x / 10))

[<EntryPoint>]
let main argv =
    let items = Seq.empty<float>
    let n = ReadPositiveInt "Введите количество чисел. \n"
    let selectMethod = ReadSelectedMethod ()
    let resultSeq = Seq.map TakeFirst (
        FillSeq items n selectMethod
                    )
    printfn "Полученная последовательность: %A" resultSeq
    0