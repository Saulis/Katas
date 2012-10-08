// Learn more about F# at http://fsharp.net

namespace Tests.Tests

open NUnit.Framework
open FsUnit
open Bowling

module BowlingTests =

    let twentyZeroes = Array.create 20 0
    let twentyOnes = Array.create 20 1
    let spareRolls = Array.append [|5; 5; 3|] (Array.create 16 0)

    [<TestFixture>] 
    type ``Given a game!`` ()=
        let game = new Game()

        [<Test>] member gutterBallGame.
         ``gutter ball game should have zero points`` ()=
            game.GetScore(twentyZeroes) |> should equal 0

        [<Test>] member onesGame.
         ``ones game should have twenty points`` ()=
            game.GetScore(twentyOnes) |> should equal 20

        [<Test>] member spareGame.
         ``spare game should have 16 points`` () =
            game.GetScore(spareRolls) |> should equal 16