module BowlingGame (score) where

score :: [Int] -> Int
score rolls = sumFrames (mapIntoTenFrames rolls)

mapIntoTenFrames rolls = foldIntoTenFrames (mapIntoFrames rolls)
foldIntoTenFrames frames = (firstNine frames) ++ [foldTenthFrameFrom frames]

firstNine frames = take 9 frames
foldTenthFrameFrom frames = (foldl (++) [] (drop 9 frames))

mapIntoFrames :: [Int] -> [[Int]]
mapIntoFrames [] = []
mapIntoFrames (x:xs)
    | x == 10 = [[x]] ++ mapIntoFrames xs
    | length xs == 0 = [[x]]
    | otherwise = [[x, (head xs)]] ++ mapIntoFrames (tail xs)

sumFrames :: [[Int]] -> Int
sumFrames [] = 0
sumFrames (frame:nextFrames)
    | endsWithStrike frame = sum frame + sumOfNextTwoRolls nextFrames + sumFrames nextFrames
    | endsWithSpare frame = sum frame + nextRoll nextFrames + sumFrames nextFrames
    | otherwise = sum frame + sumFrames nextFrames

endsWithStrike frame = head frame == 10
endsWithSpare frame = sum frame == 10

nextRoll :: [[Int]] -> Int
nextRoll [] = 0
nextRoll frames = head (head frames)

sumOfNextTwoRolls :: [[Int]] -> Int
sumOfNextTwoRolls [] = 0
sumOfNextTwoRolls (frame:nextFrames)
    | length frame >= 2 = sum (take 2 frame)
    | otherwise = nextRoll [frame] + nextRoll nextFrames
