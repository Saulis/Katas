package bowling

object Game {

  def roll (rolls: List[Int]): Int = sumFrames(mapIntoTenFrames(rolls))

  private def mapIntoTenFrames (rolls: List[Int]) : List[List[Int]] = {
	  reduceIntoTenFrames(mapIntoFrames(rolls))
  }
  
  private def reduceIntoTenFrames (frames: List[List[Int]]): List[List[Int]] = {
    frames.take(9) ++ reduceTenthFrame(frames)
  }
  
  private def reduceTenthFrame(frames: List[List[Int]]): List[List[Int]] = {
    reduceFrames(frames.drop(9))
  }
  
  private def reduceFrames(frames: List[List[Int]]): List[List[Int]] = {
    List(frames.reduceLeft[List[Int]] { (acc, n) => acc ++ n })
  }
  
  private def mapIntoFrames (rolls: List[Int]): List[List[Int]] = {
	if(rolls.isEmpty)  
		List()
	
	else if(rolls.length == 1)
	  List(List(rolls.head))
		
    else if(rolls.head == 10)
	    List(List(rolls.head)) ++ mapIntoFrames(rolls.tail)
	    else
	      List(rolls.take(2)) ++ mapIntoFrames(rolls.drop(2))
  }
  
  private def sumFrames (frames: List[List[Int]]): Int = {
    if(frames.isEmpty)
      0
      else if (frames.length == 1)
        frames.head.sum
      else if (frameEndsWithStrike(frames.head))
      frames.head.sum + sumOfNextTwoRolls(frames.tail) + sumFrames(frames.tail)
      else if(frameEndsWithSpare(frames.head))
        frames.head.sum + nextRoll(frames.tail) + sumFrames(frames.tail)
        else
          frames.head.sum + sumFrames(frames.tail)
  }
  
  private def sumOfNextTwoRolls(frames: List[List[Int]]): Int = {
    if(frames.head.length >= 2) 
      frames.head.take(2).sum
      else
       nextRoll(frames) + nextRoll(frames.tail)
  }
  
  private def frameEndsWithStrike(frame: List[Int]) : Boolean = frame.head == 10
  private def frameEndsWithSpare(frame: List[Int]) : Boolean = !frameEndsWithStrike(frame) & frame.sum == 10
  private def nextRoll(frames: List[List[Int]]): Int = frames.head.head
  
  }
