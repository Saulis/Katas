import Test.HUnit
import Calculator

test1 = TestCase (assertEqual "Empty should have zero sum" 0 (Calculator.add ""))
test2 = TestCase (assertEqual "One should have the sum of one" 1 (Calculator.add "1"))
test3 = TestCase (assertEqual "Two should have the sum of two" 2 (Calculator.add "2"))

tests = TestList [TestLabel "Empty should have zero length" test1,
				  TestLabel "One should have the sum of one" test2,
				  TestLabel "Two should have the sum of two" test3]
--tests = test [ "foo1" ~:  "foo" ~: 0 ~=? Calculator.add [1,2]]

main = runTestTT tests