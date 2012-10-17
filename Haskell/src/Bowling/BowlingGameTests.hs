module BowlingGameTests (main) where

import Test.HUnit
import BowlingGame

twentyZeroes = replicate 20 0
twentyOnes = replicate 20 1

gutterGameTest = TestCase $ assertEqual
  "Should get zero points from twenty gutter balls" 0 (BowlingGame.score twentyZeroes)

onesGameTest = TestCase $ assertEqual
  "Should get twenty points from twenty hits" 20 (BowlingGame.score twentyOnes)

tests = TestList [TestLabel "Gutter Game" gutterGameTest,
                  TestLabel "Ones Game" onesGameTest]

main = runTestTT tests

