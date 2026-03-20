open Shared.InputControl
open Shared.Sequence


let rec takeFirst (x:float) =
    let x = abs (int (x))
    if x < 10 then 
        x 
    else 
        takeFirst (float (x / 10))

[<EntryPoint>]
let main argv =
    let items = Seq.empty<float>
    let n = readPositiveInt "Введите количество чисел. \n"
    let selectMethod = readSelectedMethod ()
    let resultSeq = Seq.map takeFirst (
        fillSeq items n selectMethod
                    )
    printfn "Полученная последовательность: %A" resultSeq
    0