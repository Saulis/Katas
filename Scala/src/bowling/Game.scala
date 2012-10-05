package bowling

object Game {

  private def sumOfNextThreeRolls(pins: List[Int]): Int = {
    pins.take(3).sum
  }

  private def sumOfNextTwoRolls(pins: List[Int]): Int = {
    pins.take(2).sum
  }

  private def lastFrame(frame: Int): Boolean = frame == 10

  private def lastFrameTotal(pins: List[Int]): Int = {
    pins.sum
  }

  private def nextFramesTotal(frame: Int, pins: List[Int]): Int = {
    if (lastFrame(frame))
      lastFrameTotal(pins)
    else
      frameTotal(frame, pins)
  }

  private def frameTotal(frame: Int, pins: List[Int]): Int = {
    if (firstRollIsStrike(pins))
      sumOfNextThreeRolls(pins) + nextFramesTotal(frame + 1, pins.drop(1))
    else if (frameEndsWithSpare(pins))
      sumOfNextThreeRolls(pins) + nextFramesTotal(frame + 1, pins.drop(2))
    else
      sumOfNextTwoRolls(pins) + nextFramesTotal(frame + 1, pins.drop(2))
  }

  private def firstRollIsStrike(pins: List[Int]) : Boolean = {
    pins.head == 10
  }

  private def frameEndsWithSpare(pins: List[Int]) : Boolean = {
    (!firstRollIsStrike(pins) & sumOfNextTwoRolls(pins) == 10)
  }

  def roll (pins: List[Int]): Int =  {
    nextFramesTotal(1, pins)
   }
}
