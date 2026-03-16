open Shared.InputControl
open Shared.Sequence


let rec takeFirst (x:float) =
    let x = abs (int(x))
    if x < 10 then 
        x 
    else 
        takeFirst (float(x / 10))

let countOfMatches list target = 
    list |> Seq.fold (
        fun acc x -> if x = target then 
                                    acc + 1 
                     else 
                        acc
                        ) 0


[<EntryPoint>]
let main argv =
    let items = Seq.empty<float>
    let n = (ReadPositiveInt("Введите количество чисел. \n"))
    let selectmethod = ReadSelectedMethod()
    let resultSeq = (FillSeq items n selectmethod)
    let compnum = (ReadFloat ("Введите число для подсчета: "))
    printfn "Количество чисел %f в списке: %d" 
        compnum (countOfMatches resultSeq compnum
        )
    0