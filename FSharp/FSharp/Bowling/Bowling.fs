// Learn more about F# at http://fsharp.net

module Bowling

type Game() =

    let NextTwo (items : int[]) = items.[0..1]
    let NextThree (items : int[]) = items.[0..2]
    let FrameEndsInSpare (rolls : int[]) = Array.sum (NextTwo rolls) = 10

    let rec SumFrames (rolls : int[], frame : int) =
        if(frame = 10)
           then Array.sum rolls
        else
            if(FrameEndsInSpare(rolls))
                then (Array.sum (NextThree rolls)) + SumFrames(rolls.[2..], frame + 1)
            else
                (Array.sum (NextTwo rolls)) + SumFrames(rolls.[2..], frame + 1)

//    let SumFrames (rolls : int[], frame : int) = 
//        match frame with 
//        | 10 -> Array.sum rolls
//        | _ -> SumFrame(rolls, frame)
// 
    member x.GetScore (rolls : int[]) = SumFrames(rolls, 1)
