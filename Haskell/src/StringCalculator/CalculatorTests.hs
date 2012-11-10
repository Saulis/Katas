import Test.HUnit
import Calculator

test1 = TestCase (assertEqual "Empty should have zero length" 0 (Calculator.add ""))

tests = TestList [TestLabel "Empty should have zero length" test1]
--tests = test [ "foo1" ~:  "foo" ~: 0 ~=? Calculator.add [1,2]]

main = runTestTT tests