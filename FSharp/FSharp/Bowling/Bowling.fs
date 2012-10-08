// Learn more about F# at http://fsharp.net

module Bowling

type Game() = 
    member x.GetScore (rolls : int[]) = Array.sum rolls
