module BowlingGameTests (main) where

import Test.HUnit

test1 = TestCase $ assertEqual
  "Should get Nothing from an empty string" 3 1

tests = TestList [TestLabel "Gutter Game" test1]

main = runTestTT tests

