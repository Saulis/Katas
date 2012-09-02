(ns Bowling.core-test
  (:use clojure.test
        Bowling.core))

(deftest a-test
  (testing "FIXME, I fail."
    (is (= 0 1))))

(deftest gutterball-game
  (testing "Gutter ball game"
    (is (= (score twentyZeros) 0))))

(deftest ones-game
  (testing "Ones game"
    (is (= (score twentyOnes) 20))))

(deftest one-spare-game
  (testing "One spare game"
    (is (= (score (into [5 5 3] (many 17 0))) 16))))

(deftest one-strike-game
  (testing "One strike game"
    (is (= (score (into [10 3 4] (many 17 0))) 24))))

(defn twentyZeros [] 
  (twenty 0))

(defn twentyOnes []
  (twenty 1))

(defn twenty [item]
	into []
          (for [x (range 0 20)]
            item))

(defn many [times item]
  into []
  	(for [x (range 0 times)]
      item))