module Bowling

type Game() =

    let Next (items : int[]) = items.[0]
    let NextTwo (items : int[]) = items.[0..1]
    let NextThree (items : int[]) = items.[0..2]
    let WithoutNext (items : int[]) = items.[1..]
    let WithoutNextTwo (items : int[]) = items.[2..]
    let Sum (items : int[]) = Array.sum items
    let SumNextTwo (items : int[]) = Sum (NextTwo items)
    let SumNextThree (items : int[]) = Sum (NextThree items)
    let FrameEndsInSpare (rolls : int[]) = Sum (NextTwo rolls) = 10
    let FrameEndsInStrike (rolls : int[]) = Next rolls = 10

    let rec SumRolls (rolls : int[], frame : int) =
        if frame = 10
           then Sum rolls
        else if FrameEndsInStrike(rolls)
            then SumNextThree rolls + SumRolls(WithoutNext rolls, frame + 1)
        else if FrameEndsInSpare(rolls)
            then SumNextThree rolls + SumRolls(WithoutNextTwo rolls, frame + 1)
        else
            SumNextTwo rolls + SumRolls(WithoutNextTwo rolls, frame + 1)

    member x.GetScore (rolls : int[]) = SumRolls(rolls, 1)
