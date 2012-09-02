(ns Bowling.core)

(defn -main
  "I don't do a whole lot."
  [& args]
  (println "Hello, World!"))

(defn next-roll-is-strike [rolls]
  (if (= (first rolls) 10)
    true
    false))

(defn score-strike [rolls]
  (score-next-three rolls))

(defn score-after-strike [rolls]
  (if (is-last-frame rolls)
    0
  	(score (drop 1 rolls))))

(defn score-after-second-roll [rolls]
  (if (is-last-frame rolls)
    0
  	(score (drop 2 rolls))))

(defn is-last-frame [rolls]
  (<= (count rolls) 3))

(defn score-next-three [rolls]
  (reduce + (next-three rolls)))

(defn score-second-roll [rolls]
  (if (second-roll-is-spare rolls)
    (score-spare rolls)
    (score-next-two rolls)))

(defn second-roll-is-spare [rolls]
  (= (score-next-two rolls) 10))

(defn score-spare [rolls]
  (score-next-three rolls))

(defn score-next-two [rolls]
  (reduce + (next-two rolls)))

(defn next-two [rolls]
  (take 2 rolls))

(defn next-three [rolls]
  (take 3 rolls))

(defn score [rolls]
  (if (empty? rolls)
    0
    (if (next-roll-is-strike rolls)
      (+ (score-strike rolls) (score-after-strike rolls))
      (+ (score-second-roll rolls) (score-after-second-roll rolls)))))