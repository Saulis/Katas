

score :: [Int] -> Int
score rolls = sumFrames (mapIntoTenFrames rolls)

mapIntoFrames :: [Int] -> [[Int]]
mapIntoFrames [] = []
mapIntoFrames (x:xs)
    | x == 10 = [[x]] ++ mapIntoFrames xs
    | length xs == 0 = [[x]]
    | otherwise = [[x, (head xs)]] ++ mapIntoFrames (tail xs)

firstNine frames = take 9 frames
foldTenthFrameFrom frames = (foldl (++) [] (drop 9 frames))
foldIntoTenFrames frames = (firstNine frames) ++ [foldTenthFrameFrom frames]
mapIntoTenFrames rolls = foldIntoTenFrames (mapIntoFrames rolls)

sumFrames :: [[Int]] -> Int
sumFrames [] = 0
sumFrames (x:xs)
    | head x == 10 = sum x + sumOfNextTwoRolls xs + sumFrames xs --strike
    | sum x == 10 = sum x + nextRoll xs + sumFrames xs -- spare
    | otherwise = sum x

nextRoll :: [[Int]] -> Int
nextRoll [] = 0
nextRoll frames = head (head frames)

sumOfNextTwoRolls :: [[Int]] -> Int
sumOfNextTwoRolls [] = 0
sumOfNextTwoRolls frames
    | length (head frames) >= 2 = sum (take 2 (head frames))
    | otherwise = nextRoll frames + nextRoll (tail frames)
