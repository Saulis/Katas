import Test.HUnit
import BowlingGame

twentyZeroes = replicate 20 0
twentyOnes = replicate 20 1
spareGameRolls = [5,5,3] ++ replicate 17 0
strikeGameRolls = [10, 3, 4] ++ replicate 16 0
perfectRolls = replicate 12 10
almostPerfectGameRolls = replicate 9 10 ++ [5,5]
lastMomentFailGameRolls = replicate 10 10 ++ [5,5]


gutterGameTest = TestCase $ assertEqual
  "Should get zero points from twenty gutter balls" 0 (BowlingGame.score twentyZeroes)

onesGameTest = TestCase $ assertEqual
  "Should get twenty points from twenty hits" 20 (BowlingGame.score twentyOnes)

spareGameTest = TestCase $ assertEqual
  "Should get sixteen points from spare game" 16 (BowlingGame.score spareGameRolls)

strikeGameTest = TestCase $ assertEqual
  "Should get 24 points from strike game" 24 (BowlingGame.score strikeGameRolls)

perfectGameTest = TestCase $ assertEqual
  "Should get 300 points from perfect game" 300 (BowlingGame.score perfectRolls)

almostPerfectGameTest = TestCase $ assertEqual
  "Should get 265 points from almost perfect game" 265 (BowlingGame.score almostPerfectGameRolls)

lastMomentFailGameTest = TestCase $ assertEqual
  "Should get 285 points from last moment fail game" 285 (BowlingGame.score lastMomentFailGameRolls)

tests = TestList [TestLabel "Gutter Game" gutterGameTest,
                  TestLabel "Ones Game" onesGameTest,
                  TestLabel "Spare Game" spareGameTest,
                  TestLabel "Strike Game" strikeGameTest,
                  TestLabel "Perfect Game" perfectGameTest,
                  TestLabel "Almost Perfect Game" almostPerfectGameTest,
                  TestLabel "Last Moment Fail Game" lastMomentFailGameTest]

main = runTestTT tests

